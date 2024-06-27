using ClosedXML.Excel;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TtRGenerator.Models;

namespace TtRGenerator
{
    public partial class FormEditGameDetails : Form
    {
        private string connectionString;
        int gameDetailsId;
        List<Vertices> vertices;
        List<GameDetails> gamesList;
        private ErrorProvider errorProvider;


        public FormEditGameDetails(string p)
        {

            InitializeComponent();

            connectionString = ConfigurationManager.ConnectionStrings["TtRGeneratorDatabaseCS"].ConnectionString;
            gameDetailsId = Convert.ToInt32(p);

        }
        private void FormEditGameDetails_Load(object sender, EventArgs e)
        {
            GameDetails gameDetail = GetGameDetails();
            textBox1.Text = gameDetail.GameName;

            vertices = GetVertices();
            gamesList = new List<GameDetails>();

            FillDataGridView();
            errorProvider = new ErrorProvider();
        }

        public void FillDataGridView()
        {
            dgvAllVertices.DataSource = null;
            dgvAllVertices.AutoGenerateColumns = false;
            dgvAllVertices.DataSource = vertices;

            if (vertices.Count == 1 && vertices.Any(v => v.VertexName == "null"))
            {
                label9.Text = $"Number of cities: 0";
            }
            else
                label9.Text = $"Number of cities: {vertices.Count()}";


            if (textBox4.Text == "" && textBox5.Text == "" && textBox6.Text == "")
            {
                button3.Visible = true;
                button4.Visible = false;
            }
        }

        private List<GameDetails> GetAllGames()
        {
            string query = $"SELECT * FROM GameDetails";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter(query, connection);
                DataTable dt1 = new DataTable();
                sqlDa.Fill(dt1);
                connection.Close();

                foreach (DataRow row in dt1.Rows)
                {
                    GameDetails game = new GameDetails
                    {
                        GameDetailsId = Convert.ToInt32(row["GameDetailsId"]),
                        GameName = row["GameName"].ToString()
                    };

                    gamesList.Add(game);
                }
            }
            return gamesList;
        }

        private GameDetails GetGameDetails()
        {
            GameDetails gameDetails = null;
            string query = $"SELECT * FROM GameDetails WHERE GameDetailsId = '{gameDetailsId}'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter(query, connection);
                DataTable dt1 = new DataTable();
                sqlDa.Fill(dt1);
                connection.Close();

                if (dt1.Rows.Count > 0)
                {
                    DataRow row = dt1.Rows[0];
                    gameDetails = new GameDetails
                    {
                        GameDetailsId = Convert.ToInt32(row["GameDetailsId"]),
                        GameName = row["GameName"].ToString()
                    };
                }
            }
            return gameDetails;

        }
        private List<Vertices> GetVertices()
        {

            string query = $"SELECT * FROM Vertices WHERE GameDetailsId = {gameDetailsId}";
            List<Vertices> verticesList = new List<Vertices>();

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
                    verticesList.Add(vertex);
                }
            }

            if (verticesList.IsNullOrEmpty())
            {
                verticesList.Add(new Vertices(-1, "null", 0, 0));
            }
            return verticesList;
        }
        //Cancel
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Clicked on datagridView
        private void dgvAllVertices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (e.RowIndex >= 0 && e.RowIndex < dgvAllVertices.Rows.Count)
            {
                DataGridViewRow selectedRow = dgvAllVertices.Rows[index];
                textBox4.Text = selectedRow.Cells[0].Value.ToString(); //VertexName
                textBox5.Text = selectedRow.Cells[1].Value.ToString(); //Latitude
                textBox6.Text = selectedRow.Cells[2].Value.ToString(); //Longitude
                textBox7.Text = selectedRow.Cells[3].Value.ToString(); //VertexID
                button4.Visible = true;
                button3.Visible = false;
            }
        }
        //Click elsewhere
        private void FormEditGameDetails_Click(object sender, EventArgs e)
        {
            if (!dgvAllVertices.Bounds.Contains(dgvAllVertices.PointToClient(Cursor.Position)))
            {
                textBox7.Text = "VertexId";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";

                errorProvider.SetError(textBox4, "");
                errorProvider.SetError(textBox5, "");
                errorProvider.SetError(textBox6, "");

                button4.Visible = false;
                button3.Visible = true;
            }
        }

        //Add new city
        private void button3_Click(object sender, EventArgs e)
        {
            if (ValidationVertex() == false)
                return;
            if (ValidationVertexCoordExisting() == false)
                return;

            string vertexId = textBox7.Text.ToString();

            if (vertexId == "VertexId") //Adding
            {
                int maxVertexID = 0;
                if (vertices.Count > 0)
                {
                    maxVertexID = vertices.Max(v => v.VertexId);
                }

                string latS = textBox5.Text.Replace(',', '.');
                string lonS = textBox6.Text.Replace(',', '.');
                decimal lat =decimal.Parse(latS, CultureInfo.InvariantCulture);
                decimal lon = decimal.Parse(lonS, CultureInfo.InvariantCulture);
                Vertices vertex = new Vertices(maxVertexID + 1, textBox4.Text.ToString(), lat, lon);
                vertices.Add(vertex);
                vertices.RemoveAll(x => x.VertexId == -1);
            }


            textBox7.Text = "VertexId";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            FillDataGridView();
        }

        //Delete city
        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "")
                vertices.RemoveAll(x => x.VertexId == Convert.ToInt32(textBox7.Text.ToString()));


            textBox7.Text = "VertexId";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            FillDataGridView();
        }


        private bool ValidateGameDetails()
        {
            List<string> errorMessages = new List<string>();
            GetAllGames();

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                errorProvider.SetError(textBox1, "Game name can not be empty!");
                errorMessages.Add("Game name can not be empty!");
            }
            else
            {
                errorProvider.SetError(textBox1, "");

                string newGameName = textBox1.Text.Trim();
                gamesList.RemoveAll(x => x.GameDetailsId == gameDetailsId);
                bool nameExists = gamesList.Any(x => x.GameName.Equals(newGameName, StringComparison.OrdinalIgnoreCase));
                if (nameExists)
                {
                    errorProvider.SetError(textBox1, "Game name must be uniqe!");
                    errorMessages.Add("Game name must be uniqe!");
                }
            }

            return errorMessages.Count == 0;
        }

        //Update all
        private void button2_Click(object sender, EventArgs e)
        {
            if (ValidateGameDetails() == false)
                return;

            var result = MessageBox.Show("Are you sure you want to apply changes?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
                return;

            string deleteQuery = "DELETE FROM Vertices WHERE GameDetailsId = @GameDetailsId";
            string insertQuery = "INSERT INTO Vertices (GameDetailsId, VertexName, Latitude, Longitude) VALUES (@GameDetailsId, @VertexName, @Latitude, @Longitude)";
            string updateQuery = "UPDATE GameDetails SET GameName = @GameName WHERE GameDetailsId = @GameDetailsId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Usuwanie wierzchołków
                using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@GameDetailsId", gameDetailsId);
                    int rowsAffected = command.ExecuteNonQuery();
                    // Obsługa błędów
                    if (rowsAffected < 0)
                    {
                        MessageBox.Show("Error occurred while deleting vertices.");
                        return;
                    }
                }

                // Dodawanie nowych wierzchołków
                foreach (Vertices vertex in vertices)
                {
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@GameDetailsId", gameDetailsId);
                        command.Parameters.AddWithValue("@VertexName", vertex.VertexName);
                        command.Parameters.AddWithValue("@Latitude", vertex.Latitude);
                        command.Parameters.AddWithValue("@Longitude", vertex.Longitude);
                        command.ExecuteNonQuery();
                    }
                }

                // Aktualizacja danych gry
                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@GameName", textBox1.Text);
                    command.Parameters.AddWithValue("@GameDetailsId", gameDetailsId);
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }

            MessageBox.Show("Updated game details!");
            this.Close();
        }


        private bool ValidationVertex()
        {
            List<string> errorMessages = new List<string>();

            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                errorProvider.SetError(textBox4, "City name can not be empty!");
                errorMessages.Add("City name can not be empty!");
            }
            else
            {
                string vertexName = textBox4.Text.Trim();
                if (vertices.Any(v => v.VertexName.Equals(vertexName, StringComparison.OrdinalIgnoreCase)))
                {
                    errorProvider.SetError(textBox4, "City name must be unique!");
                    errorMessages.Add("City name must be unique!");
                }
                else
                    errorProvider.SetError(textBox4, "");
            }

            string pattern = @"^(-?\d{1,3}([.,]\d{1,5})?)$";
            if (!Regex.IsMatch(textBox5.Text, pattern) || !Regex.IsMatch(textBox6.Text, pattern))
            {
                errorProvider.SetError(textBox5, "Correct format is XXX,XXX or -XXX,XXX");
                errorProvider.SetError(textBox6, "Correct format is XXX,XXX or -XXX,XXX");
                errorMessages.Add("Correct format is XXX,XXX or -XXX,XXX");
            }
            else
            {
                errorProvider.SetError(textBox5, "");
                errorProvider.SetError(textBox6, "");
            }
            return errorMessages.Count == 0;
        }

        private bool ValidationVertexCoordExisting()
        {
            List<string> errorMessages = new List<string>();

            string latS = textBox5.Text.Replace(',', '.');
            string lonS = textBox6.Text.Replace(',', '.');
            decimal lat = decimal.Parse(latS, CultureInfo.InvariantCulture);
            decimal lon = decimal.Parse(lonS, CultureInfo.InvariantCulture);
            if (vertices.Any(v => v.Latitude == lat && v.Longitude == lon))
            {
                errorProvider.SetError(textBox5, "There is already a city with the same coordinates!");
                errorProvider.SetError(textBox6, "There is already a city with the same coordinates!");
                errorMessages.Add("There is already a city with the same coordinates!");
            }
            else
            {
                errorProvider.SetError(textBox5, "");
                errorProvider.SetError(textBox6, "");
            }
            return errorMessages.Count == 0;
        }

        //Load new cities from Excel File
        private void button6_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel Files|*.xlsx";
                openFileDialog.Title = "Select a Excel File";

                progressBar1.Visible = true;
                progressBar1.Value = 25;
                progressBar1.Refresh();
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    progressBar1.Value += 25;
                    progressBar1.Refresh();

                    textBox7.Text = "VertexId";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";

                    errorProvider.SetError(textBox4, "");
                    errorProvider.SetError(textBox5, "");
                    errorProvider.SetError(textBox6, "");

                    LoadVerticesFromExcel(filePath);
                }
            }
        }
        private void LoadVerticesFromExcel(string filePath)
        {
            try
            {
                using (var workbook = new XLWorkbook(filePath))
                {
                    var worksheet = workbook.Worksheet(1);
                    var rows = worksheet.RowsUsed();
                    int progressIncrement = 50 / rows.Count();

                    foreach (var row in worksheet.RowsUsed())
                    {
                        

                        string vertexId = textBox7.Text.ToString();

                        if (vertexId == "VertexId") //Adding
                        {
                            int maxVertexID = 0;
                            if (vertices.Count > 0)
                            {
                                maxVertexID = vertices.Max(v => v.VertexId);
                            }
                            string vertexName = row.Cell(1).GetValue<string>();

                            string latS = row.Cell(2).GetValue<string>().Replace(',', '.');
                            decimal latitude = decimal.Parse(latS, CultureInfo.InvariantCulture);

                            string lonS = row.Cell(3).GetValue<string>().Replace(',', '.');
                            decimal longitude = decimal.Parse(lonS, CultureInfo.InvariantCulture);
                            Vertices vertex = new Vertices(maxVertexID + 1,vertexName, latitude, longitude);
                            if (ValidateExcelVertex(vertex))
                            {
                                vertices.Add(vertex);
                            }
                            progressBar1.Value += progressIncrement;
                            progressBar1.Refresh();

                        }

                        textBox7.Text = "VertexId";

                    }
                }

                progressBar1.Value = 100;
                progressBar1.Refresh();
                FillDataGridView();
                MessageBox.Show("Data loaded successfully from Excel file.");
            }
            catch (Exception ex)
            {
                progressBar1.Value = 0;
                progressBar1.Refresh();
                progressBar1.Visible = false;
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool ValidateExcelVertex(Vertices vertex)
        {
            List<string> errorMessages = new List<string>();

            string vertexName = vertex.VertexName;
            if (vertices.Any(v => v.VertexName.Equals(vertexName, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show($"Error city: {vertexName}. Name must be unique!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorMessages.Add("City name must be unique!");
            }
            else
            {

                decimal lat = vertex.Latitude;
                decimal lon = vertex.Longitude;
                if (vertices.Any(v => v.Latitude == lat && v.Longitude == lon))
                {
                    MessageBox.Show($"Error city: {vertexName}. There is already a city with the same coordinates!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    errorMessages.Add("There is already a city with the same coordinates!");
                }
            }

            return errorMessages.Count == 0;
        }

    }
}

