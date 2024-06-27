using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using TtRGenerator.Clingo_forms;

namespace TtRGenerator.Models
{
    public class Edge
    {
        public VerticesClingo Start { get; set; }
        public VerticesClingo End { get; set; }
        public Color Color { get; set; }
        public double EdgeLength {  get; set; }
        public int NumberOfTrains { get; set; }

        public Edge(VerticesClingo start, VerticesClingo end)
        {
            Start = start;
            End = end;
            EdgeLength = CalculateLength();
        }

        public double CalculateLength()
        {
            double deltaX = End.Latitude - Start.Latitude;
            double deltaY = End.Longitude - Start.Longitude;
            double length=Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
            return length;
        }
        public static void EstimateNumberOfTrains(List<Edge>edges, double maxTrains)
        {
            double maxLength = 0.0;
            foreach (Edge edge in edges)
            {
                double length = edge.CalculateLength();
                if (length > maxLength)
                {
                    maxLength = length;
                }
            }


            foreach (Edge edge in edges)
            {
                double edgeLength = edge.CalculateLength();
                int numberOfTrains;

                if (maxLength != 0)
                {
                    numberOfTrains = Math.Max(1, (int)(maxTrains * (edgeLength / maxLength)));
                }
                else
                {
                    numberOfTrains = 1;
                }

                edge.NumberOfTrains = numberOfTrains;
            }
        }

        public static void AssignColorsToEdges(List<Edge> edges)
        {
            string[] colors =new string[] { "White", "Gray", "Black",  "Yellow", "Red", "Green", "Purple" }; 
            int howMany = edges.Count / colors.Length;
            int addColor= edges.Count % colors.Length;

            List<string> colorsToAdd = new List<string>();
            for (int i = 0; i < howMany; i++)
            {
                for (int j = 0; j < colors.Length; j++)
                {
                    colorsToAdd.Add(colors[j]);
                }
            }

            Random rnd = new Random();
            for (int i = 0; i < addColor; i++)
            {
                string newColor = colors[rnd.Next(colors.Length)];
                colorsToAdd.Add(newColor);
                RemoveColor(colors, newColor);
            }

            //Algorytm Fisher-Yates
            for (int i = colorsToAdd.Count - 1; i > 0; i--)
            {
                int randomIndex = rnd.Next(0, i + 1);
                string temp = colorsToAdd[i];
                colorsToAdd[i] = colorsToAdd[randomIndex];
                colorsToAdd[randomIndex] = temp;
            }

            for(int i = 0;i < edges.Count; i++)
            {
                edges[i].Color = Color.FromName(colorsToAdd[i]);
            }

        }
        public static string[] RemoveColor(string[] colors, string colorToRemove)
        {
            // Przekształcenie tablicy na listę
            List<string> colorList = colors.ToList();

            // Usunięcie koloru
            colorList.Remove(colorToRemove);

            // Przekształcenie listy z powrotem na tablicę
            return colorList.ToArray();
        }
    }
}
