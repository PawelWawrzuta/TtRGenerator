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
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TtRGenerator.Clingo_forms;
using TtRGenerator.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TtRGenerator
{
    public partial class FormUseSelectedGame : Form
    {
        private string connectionString;
        string gameDetailsId;
        List<Vertices> verticesList;
        ErrorProvider errorProvider;
        public FormUseSelectedGame(string p)
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["TtRGeneratorDatabaseCS"].ConnectionString;
            gameDetailsId = p;
            verticesList = new List<Vertices>();
            errorProvider = new ErrorProvider();

        }
        private void FormUseSelectedGame_Load(object sender, EventArgs e)
        {
            GetGameDetails();
            GetVertices();
            if (verticesList.Count < 3)
            {
                MessageBox.Show("Can not draw board, too few cities!","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                button2.Enabled = false;
                button3.Enabled = false;
            }
        }

        private void GetGameDetails()
        {

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
                    GameDetails gameDetails = new GameDetails();

                    gameDetails.GameDetailsId = dt1.Rows[0].Field<int>(0);
                    gameDetails.GameName = dt1.Rows[0].Field<string>(1);

                    label1.Text = $"Using {gameDetails.GameName}";
                }
            }
        }

        private void GetVertices()
        {

            string query = $"SELECT * FROM Vertices WHERE GameDetailsId = {gameDetailsId}";

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
                if (verticesList.IsNullOrEmpty())
                {
                    verticesList.Add(new Vertices(-1, "null", 0, 0));
                }

                dgvAllVertices.AutoGenerateColumns = false;
                dgvAllVertices.DataSource = verticesList;
            }

            if (verticesList.Count == 1 && verticesList.Any(v => v.VertexName == "null"))
            {
                label7.Text = $"Number of cities: 0";
            }
            else
                label7.Text = $"Number of cities: {verticesList.Count()}";
        }

        //Cancel
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Generate board without parameter
        private void button2_Click(object sender, EventArgs e)
        {
            var myForm = new FormGenerateBoardWithoutP(gameDetailsId);
            myForm.Show();
        }

        //Generate board with parameter
        private void button3_Click(object sender, EventArgs e)
        {
            if (!ValidateParameter())
                return;
            
            var myForm = new FormGenerateBoardWithP(gameDetailsId,textBox1.Text);
            myForm.Show();

        }

        private bool ValidateParameter()
        {
            List<string> errorMessages = new List<string>();
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                errorProvider.SetError(textBox1, "Parameter can not be empty!");
                errorMessages.Add("Parameter can not be empty!");
            }
            else
            {
                string pattern = @"^[1-9]\d*$";
                if (!Regex.IsMatch(textBox1.Text, pattern) || !Regex.IsMatch(textBox1.Text, pattern))
                {
                    errorProvider.SetError(textBox1, "Parameter must be integer greater than 0!");
                    errorMessages.Add("Parameter must be integer greater than 0!");
                }
                else
                {
                    if (Convert.ToInt32(textBox1.Text)>verticesList.Count)
                    {
                        errorProvider.SetError(textBox1, "Parameter can not be greater than number of cities!");
                        errorMessages.Add("Parameter can not be greater than number of cities!");
                    }
                    else
                    {
                        errorProvider.SetError(textBox1, "");
                    }
                }
            }

            return errorMessages.Count == 0;
        }
    }
}
