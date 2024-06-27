using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using TtRGenerator.Models;

namespace TtRGenerator.Clingo_forms
{
    public class ClingoCode
    {
        public List<Edge> edges { get; set; }
        public List<VerticesClingo> vertices { get; set; }
        public int p { get; set; }
        public ClingoCode(List<VerticesClingo> v)
        {
            vertices = v;
            p = 0;
        }
        public ClingoCode(List<VerticesClingo> v, string parameter)
        {
            vertices = v;
            p = Convert.ToInt32(parameter);
        }


        public bool GetFullClingoResult()
        {
            List<Edge> allEdges = new List<Edge>();
            List<Cross> crosses = new List<Cross>();

            //Krawędzie bez parametru i z
            if (p > 0)
                allEdges = GenerateNearestEdges(vertices, p);
            else
                allEdges = GenerateAllEdges(vertices);


            crosses = GenerateCrosses(allEdges);

            string crossesS = ""; //Tworzenie faktów do Clingo
            if (vertices != null)
            {
                foreach (var item in vertices)
                {
                    crossesS += $"v(\"{item.VertexName}\").\n";
                }
            }
            else
            {
                MessageBox.Show($"Error! Could not find cities!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (allEdges != null)
            {
                foreach (var item in allEdges)
                {
                    crossesS += $"e(\"{item.Start.VertexName}\",\"{item.End.VertexName}\").\n";
                }
            }
            else
            {
                MessageBox.Show($"Error! Could not find paths!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            foreach (var item in crosses)
            {
                crossesS += $"cross(\"{item.E1.Start.VertexName}\",\"{item.E1.End.VertexName}\"," +
                    $"\"{item.E2.Start.VertexName}\",\"{item.E2.End.VertexName}\").\n";
            }


            edges = ClingoPart(crossesS, vertices);
            return true;
        }


        public List<Edge> GenerateAllEdges(List<VerticesClingo> vertices)
        {
            List<Edge> edges = new List<Edge>();

            for (int i = 0; i < vertices.Count; i++)
            {
                for (int j = 0; j < vertices.Count; j++)
                {
                    //Usunięcie krawędzi do tego samego wierzchołka 
                    if (vertices[i] != vertices[j])
                    {
                        edges.Add(new Edge(vertices[i], vertices[j]));
                    }
                }
            }
            return edges;
        }

        public static List<Cross> GenerateCrosses(List<Edge> edge)
        {
            List<Cross> crosses = new List<Cross>();

            for (int i = 0; i < edge.Count; i++)
            {
                for (int j = 0; j < edge.Count; j++)
                {
                    //Usunięcie 2 takich samych krawędzi
                    if (edge[i] != edge[j])
                    {
                        crosses.Add(new Cross(edge[i], edge[j]));
                    }

                }
            }

            List<Cross> crosses2 = new List<Cross>();
            foreach (var item in crosses)
            {
                if (item.Status == 2 || item.Status == 3)
                {
                    crosses2.Add(item);
                }
            }
            return crosses2;
        }

        public List<Edge> ClingoPart(string crossesS, List<VerticesClingo> vertices)
        {
            string baseFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "clingo_code", "clingoCodeBase.lp");
            string modifiedFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "clingo_code", "clingoCodeModified.lp");
            List<Edge> edges = new List<Edge>();

            // Odczytanie zawartości pliku z kodem Clingo oraz dopisanie do niego faktów
            try
            {

                string existingContent = File.ReadAllText(baseFilePath);
                string newContent = crossesS + existingContent;
                File.WriteAllText(modifiedFilePath, newContent);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error! Could not make Clingo file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Obszar działania Clingo
            try
            {
                // Ścieżka do pliku wykonywalnego Clingo
                string clingoPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "clingo_code", "clingo.exe");


                string clingoArgs = $"--outf=2 \"{modifiedFilePath}\"";
                ProcessStartInfo startInfo = new ProcessStartInfo(clingoPath, clingoArgs);
                startInfo.RedirectStandardOutput = true;
                startInfo.UseShellExecute = false;


                Process clingoProcess = new Process();
                clingoProcess.StartInfo = startInfo;
                clingoProcess.Start();
                string output = clingoProcess.StandardOutput.ReadToEnd();


                JObject json = JObject.Parse(output);

                if (json["Call"][0]["Witnesses"] != null)
                {
                    // Wyciąganie danych "in("x","y")" z tablicy Witnesses
                    JArray witnesses = (JArray)json["Call"][0]["Witnesses"];
                    JObject lastWitness = (JObject)witnesses.Last;
                    JArray lastWitnessValues = (JArray)lastWitness["Value"];


                    foreach (JValue item in lastWitnessValues)
                    {
                        // Wyrwanie wszystkich nazw z wyniku pracy działania Clingo
                        string[] vertex = item.ToString().Split(new char[] { '(', '"', ',', ')' }, StringSplitOptions.RemoveEmptyEntries);

                        // vertex[0]="in" vertex[1]=vertexStart vertex[2]=vertexEnd
                        VerticesClingo vertexStart = vertices.FirstOrDefault(x => x.VertexName == vertex[1].ToString());
                        VerticesClingo vertexEnd = vertices.FirstOrDefault(x => x.VertexName == vertex[2].ToString());

                        if (vertexStart == null || vertexEnd == null)
                        {
                            edges = null;
                            return edges;
                        }

                        Edge edge = new Edge(vertexStart, vertexEnd);
                        edges.Add(edge);
                    }
                }
                else
                {
                    MessageBox.Show($"Error! Could not find matching model!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return edges;
                }

                clingoProcess.WaitForExit();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Clingo Error:{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Usunięcie pliku zmodyfikowanego kodu Clingo
            if (File.Exists(modifiedFilePath))
            {
                try
                {
                    File.Delete(modifiedFilePath);
                }
                catch (IOException e)
                {
                    MessageBox.Show($"Error! Could not delete clingo file: {e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return edges;
        }


        //-----------------GenerateWithParameter
        /// <summary>
        /// Generuje krawędzie do n najbliższych sąsiadów
        /// </summary>
        /// <param name="vertices"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static List<Edge> GenerateNearestEdges(List<VerticesClingo> vertices, int n)
        {
            List<Edge> edges = new List<Edge>();

            foreach (var vertex in vertices)
            {
                List<VerticesClingo> nearestNeighbors = FindNearestNeighbors(vertex, vertices, n);

                foreach (var neighbor in nearestNeighbors)
                {
                    if (!edges.Any(e => (e.Start == vertex && e.End == neighbor) || (e.Start == neighbor && e.End == vertex)))
                    {
                        edges.Add(new Edge(vertex, neighbor));
                        edges.Add(new Edge(neighbor, vertex));
                    }
                }
            }
            return edges;
        }

        /// <summary>
        /// Algorytm kNN
        /// </summary>
        /// <param name="vertex"></param>
        /// <param name="vertices"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        static List<VerticesClingo> FindNearestNeighbors(VerticesClingo vertex, List<VerticesClingo> vertices, int n)
        {
            // Odległość między wierzchołkiem i wszystkimi jego sąsiadami
            var distances = vertices.Select(v => new
            {
                Vertex = v,
                Distance = Cross.CalculateDistance(vertex, v)
            });


            var sortedNeighbors = distances.OrderBy(d => d.Distance);

            // Wybranie najbliższych sąsiadów
            var nearestNeighbors = sortedNeighbors.Take(n + 1).Select(d => d.Vertex).ToList();
            //Usunięcie krawędzi między wierzchołkiem i samym sobą
            nearestNeighbors.RemoveAll(v => v.VertexName == vertex.VertexName);

            return nearestNeighbors;
        }

    }
}
