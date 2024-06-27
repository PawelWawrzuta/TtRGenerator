using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using TtRGenerator.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TtRGenerator.Clingo_forms
{
    public partial class FormGenerateBoardWithoutP : Form
    {
        string gameDetailsId;
        private string connectionString;
        List<VerticesClingo> vertices;
        List<Edge> edges;

        public FormGenerateBoardWithoutP(string p)
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["TtRGeneratorDatabaseCS"].ConnectionString;
            gameDetailsId = p;
        }

        private void FormGenerateBoardWithoutP_Load(object sender, EventArgs e)
        {
            List<Vertices> v = GetVertices(gameDetailsId);
            vertices = v.Select(v => new VerticesClingo(v)).ToList();
            ClingoCode clingoCode = new ClingoCode(vertices);
            bool c = clingoCode.GetFullClingoResult();

            if (!c) this.Close();

            edges = clingoCode.edges;


            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 1;
            comboBox3.SelectedIndex = 2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Invalidate();
            panel1.Update();
            panel1.Visible = true;
            panel1.Width = Convert.ToInt32(comboBox1.Text);
            panel1.Height = Convert.ToInt32(comboBox2.Text);

            button2.Enabled = true;
            label3.Visible = true;
            label4.Visible = true;
            label3.Text = $"Number of paths: {edges.Count}";
            label4.Text = $"Number of cities: {vertices.Count}";

            Graphics gra = this.panel1.CreateGraphics();
            DrawGame(gra);
            SetGameImageData();
        }
        private void checkBox3_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
                comboBox3.Enabled = true;
            else
                comboBox3.Enabled = false;

        }

        //Save board
        private void button2_Click_1(object sender, EventArgs e)
        {
            SafePanelAsPNG();
        }


        private void SafePanelAsPNG()
        {
            Bitmap bmp = new Bitmap(panel1.Width, panel1.Height);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(panel1.BackColor);
                DrawGame(g);
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Pliki PNG|*.png";
            saveFileDialog.Title = "Wybierz miejsce zapisu";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                bmp.Save(saveFileDialog.FileName, ImageFormat.Png);
                MessageBox.Show("Plik zapisano pomyślnie.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            bmp.Dispose();
        }

        //------------- Drawing
        private void DrawGame(Graphics gra)
        {
            double xmin = vertices.Min(v => v.Longitude);
            double xmax = vertices.Max(v => v.Longitude);
            double ymin = vertices.Min(v => v.Latitude);
            double ymax = vertices.Max(v => v.Latitude);

            double xRange = xmax - xmin;
            double yRange = ymax - ymin;

            float pointSize = 0.01f * panel1.Width; // Vertex size

            // Scaling coordinates of vertices
            float scaleX = (0.9f * panel1.Width - pointSize) / (float)xRange;
            float scaleY = (0.9f * panel1.Height - pointSize) / (float)yRange;
            float scale = Math.Min(scaleX, scaleY); // Ensure consistent scaling

            // Offsets for centering the drawing
            float offsetX = (panel1.Width - (float)xRange * scale) / 2;
            float offsetY = (panel1.Height - (float)yRange * scale) / 2;

            using (Pen vertexPen = new Pen(Color.Black, 5))
            using (Font font = new Font("Arial", 10))
            using (SolidBrush brush = new SolidBrush(Color.Black))
            {
                // Panel borders
                using (Pen borderPen = new Pen(Color.Black, 2))
                {
                    gra.DrawRectangle(borderPen, 0, 0, panel1.Width - 1, panel1.Height - 1);
                }

                // Drawing vertices
                foreach (var vertex in vertices)
                {
                    float x = ((float)((vertex.Longitude - xmin) * scale) + offsetX);
                    float y = ((float)((ymax - vertex.Latitude) * scale) + offsetY);


                    RectangleF rect = new RectangleF(x - pointSize / 2, y - pointSize / 2, pointSize, pointSize);
                    gra.FillEllipse(vertexPen.Brush, rect);

                    // Vertex labels
                    if (checkBox1.Checked)
                    {
                        PointF textPoint = new PointF(rect.Right + 5, rect.Top + 10);
                        gra.DrawString(vertex.VertexName, font, brush, textPoint);
                    }
                }

                foreach (var item in edges)
                {
                    item.Color = Color.Empty;
                }
                Edge.AssignColorsToEdges(edges);

                if (checkBox3.Checked)
                    Edge.EstimateNumberOfTrains(edges, Convert.ToDouble(comboBox3.Text));

                // Drawing edges, conditional color
                foreach (var edge in edges)
                {
                    Color penColor = Color.Black;
                    Brush textBrush = new SolidBrush(Color.Black);
                    if (checkBox2.Checked)
                    {
                        penColor = edge.Color;
                        textBrush = new SolidBrush(edge.Color);
                    }

                    using (Pen edgePen = new Pen(penColor, 2))
                    {
                        float startX = (float)((edge.Start.Longitude - xmin) * scale) + offsetX;
                        float startY = (float)((ymax - edge.Start.Latitude) * scale) + offsetY;
                        float endX = (float)((edge.End.Longitude - xmin) * scale) + offsetX;
                        float endY = (float)((ymax - edge.End.Latitude) * scale) + offsetY;

                        gra.DrawLine(edgePen, startX, startY, endX, endY);

                        if (checkBox3.Checked)
                        {
                            float textX = (startX + endX) / 2;
                            float textY = (startY + endY) / 2;

                            // Number of trains on the connection
                            string text = edge.NumberOfTrains.ToString();
                            gra.DrawString(text, font, textBrush, textX, textY);
                            textBrush.Dispose();
                        }
                    }
                }
            }
        }
        //--------------Getting data
        private List<Vertices> GetVertices(string gameDetailsId)
        {

            string query = $"SELECT * FROM Vertices WHERE GameDetailsId = {gameDetailsId}";
            List<Vertices> vertices = new List<Vertices>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter(query, connection);
                DataTable dt1 = new DataTable();
                sqlDa.Fill(dt1);
                connection.Close();

                foreach (DataRow row in dt1.Rows)
                {
                    Vertices vertex = new Vertices
                    {
                        VertexId = Convert.ToInt32(row["VertexID"]),
                        GameDetailsId = Convert.ToInt32(row["GameDetailsId"]),
                        VertexName = row["VertexName"].ToString(),
                        Latitude = decimal.Parse(row["Latitude"].ToString(), CultureInfo.InvariantCulture),
                        Longitude = decimal.Parse(row["Longitude"].ToString(), CultureInfo.InvariantCulture)
                    };
                    vertices.Add(vertex);
                }

                return vertices;
            }
        }

        //-------------Others

        void SetGameImageData()
        {
            Bitmap bmp = new Bitmap(panel1.Width, panel1.Height);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(panel1.BackColor);
                DrawGame(g);
            }
            Bitmap bmp2 = new Bitmap(bmp, new Size(182, 182));

            byte[] imageBytes;
            using (MemoryStream ms = new MemoryStream())
            {
                bmp2.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                imageBytes = ms.ToArray();
            }

            string query = "UPDATE GameDetails SET ImageData = @ImageData WHERE GameDetailsId = @GameDetailsId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ImageData", imageBytes);
                    command.Parameters.AddWithValue("@GameDetailsId", gameDetailsId);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }


    }
}
