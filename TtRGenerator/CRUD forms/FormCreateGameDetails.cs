using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TtRGenerator.Clingo_forms;
using TtRGenerator.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace TtRGenerator
{
    public partial class FormCreateGameDetails : Form
    {
        private string connectionString;
        List<Vertices> vertices;
        List<GameDetails> gamesList;
        string newGameName;
        private ErrorProvider errorProvider;
        public FormCreateGameDetails()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["TtRGeneratorDatabaseCS"].ConnectionString;
        }
        private void FormCreateGameDetails_Load(object sender, EventArgs e)
        {
            errorProvider = new ErrorProvider();
            vertices = new List<Vertices>();
            gamesList = new List<GameDetails>();
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
                string newGameName = textBox1.Text.Trim();
                bool nameExists = gamesList.Any(x => x.GameName.Equals(newGameName, StringComparison.OrdinalIgnoreCase));
                if (nameExists)
                {
                    errorProvider.SetError(textBox1, "Game name must be uniqe!");
                    errorMessages.Add("Game name must be uniqe!");
                }
                else
                    errorProvider.SetError(textBox1, "");
            }
            return errorMessages.Count == 0;
        }

        private void GetAllGames()
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidateGameDetails() == false)
                return;

            newGameName = textBox1.Text;
            label1.Text = "City name";
            textBox1.Visible = false;
            button1.Visible = false;

            button4.Enabled = true;
            label2.Text = newGameName;
            label2.Visible = true;
            groupBox1.Visible = true;
            groupBox2.Visible = true;
            label3.Visible = true;
            dgvAllVertices.Visible = true;
        }

        private void FillDataGridView()
        {
            dgvAllVertices.DataSource = null;
            dgvAllVertices.AutoGenerateColumns = false;
            dgvAllVertices.DataSource = vertices;

            label3.Text = $"Number of cities: {vertices.Count}";
            button3.Visible = true;
            button5.Visible = false;

        }

        //Cancel
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidateVertex()
        {
            List<string> errorMessages = new List<string>();

            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                errorProvider.SetError(textBox4, "City name can not be empty!");
                errorMessages.Add("City name can not be empty!");
            }
            else
            {
                // Sprawdź unikalność nazwy wierzchołka
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
                // Sprawdź unikalność współrzędnych geograficznych
                decimal lat = decimal.Parse(textBox5.Text, CultureInfo.InvariantCulture);
                decimal lon = decimal.Parse(textBox6.Text, CultureInfo.InvariantCulture);
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

            }

            return errorMessages.Count == 0;
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

                button3.Visible = false;
                button5.Visible = true;
            }
        }

        //Clicked elsewhere
        private void FormCreateGameDetails_Click(object sender, EventArgs e)
        {
            if (!dgvAllVertices.Bounds.Contains(dgvAllVertices.PointToClient(Cursor.Position)))
            {
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                button3.Visible = true;
                button5.Visible = false;

                errorProvider.SetError(textBox4, "");
                errorProvider.SetError(textBox5, "");
                errorProvider.SetError(textBox6, "");
            }

        }

        //Add new city //
        private void button3_Click(object sender, EventArgs e)
        {
            if (ValidateVertex() == false)
                return;

            string latS = textBox5.Text.Replace(',', '.');
            string lonS = textBox6.Text.Replace(',', '.');
            decimal lat = decimal.Parse(latS, CultureInfo.InvariantCulture);
            decimal lon = decimal.Parse(lonS, CultureInfo.InvariantCulture);
            Vertices vertex = new Vertices(textBox4.Text.ToString(), lat, lon);

            vertices.Add(vertex);
            FillDataGridView();
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";

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
                        string vertexName = row.Cell(1).GetValue<string>();
                        string latS = row.Cell(2).GetValue<string>().Replace(',', '.');
                        decimal latitude = decimal.Parse(latS, CultureInfo.InvariantCulture);

                        string lonS = row.Cell(3).GetValue<string>().Replace(',', '.');
                        decimal longitude = decimal.Parse(lonS, CultureInfo.InvariantCulture);

                        Vertices vertex = new Vertices(vertexName, latitude, longitude);

                        if (ValidateExcelVertex(vertex))
                        {
                            vertices.Add(vertex);
                        }
                        progressBar1.Value += progressIncrement;
                        progressBar1.Refresh();
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

        //Delete selected city
        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "")
                vertices.RemoveAll(x => x.VertexName == textBox4.Text.ToString());

            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";

            FillDataGridView();
        }

        //Confirm Changes
        private void button4_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to create this game?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
                return;

            string query = "INSERT INTO GameDetails (GameName) VALUES (@GameName)";
            string query2 = "SELECT TOP 1 GameDetailsId FROM GameDetails ORDER BY GameDetailsId DESC";
            string query3 = "INSERT INTO Vertices (GameDetailsId, VertexName, Latitude, Longitude) VALUES (@GameDetailsId, @VertexName, @Latitude, @Longitude)";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //---------------Adding new game
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@GameName", newGameName);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }

                //---------------Getting new game id
                connection.Open();
                SqlDataAdapter sqlDa1 = new SqlDataAdapter(query2, connection);
                connection.Close();
                DataTable dt1 = new DataTable();
                sqlDa1.Fill(dt1);

                int id = 0;
                if (dt1.Rows.Count > 0 && dt1.Rows[0]["GameDetailsId"] != DBNull.Value)
                {
                    id = Convert.ToInt32(dt1.Rows[0]["GameDetailsId"]);
                }
                else
                {
                    MessageBox.Show("Can not find maching game!");
                    this.Close();
                }


                //---------------Adding vertices
                using (SqlCommand command = new SqlCommand(query3, connection))
                {
                    connection.Open();
                    foreach (Vertices vertex in vertices)
                    {
                        command.Parameters.Clear(); // Wyczyść parametry przed ponownym użyciem
                        command.Parameters.AddWithValue("@GameDetailsId", id);
                        command.Parameters.AddWithValue("@VertexName", vertex.VertexName);
                        command.Parameters.AddWithValue("@Latitude", vertex.Latitude);
                        command.Parameters.AddWithValue("@Longitude", vertex.Longitude);

                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }
            }
            MessageBox.Show("Added game details!");
            this.Close();
        }


    }
}
