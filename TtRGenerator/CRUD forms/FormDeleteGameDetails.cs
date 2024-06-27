using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TtRGenerator.Models;

namespace TtRGenerator
{
    public partial class FormDeleteGameDetails : Form
    {
        private string connectionString;
        string gameDetailsId;
        public FormDeleteGameDetails(string p)
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["TtRGeneratorDatabaseCS"].ConnectionString;
            gameDetailsId = p;
        }

        private void FormDeleteGameDetails_Load(object sender, EventArgs e)
        {
            GetGameDetails();
            GetVertices();
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

                    label2.Text = gameDetails.GameName;
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

                dgvAllVertices.AutoGenerateColumns = false;
                dgvAllVertices.DataSource = dt1;
            }
        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            button2.Enabled = radioButton1.Checked;
        }

        //Delete button
        private void button2_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to delete this game?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
                return;


            string query = $"DELETE FROM Vertices WHERE GameDetailsId = {gameDetailsId}";
            string query2 = $"DELETE FROM GameDetails WHERE GameDetailsId = {gameDetailsId}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        connection.Close();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"Deleted {rowsAffected} cities!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}");
                    }
                }
                using (SqlCommand command = new SqlCommand(query2, connection))
                {
                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        connection.Close();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"Deleted game!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}");
                    }
                }
                this.Close();
            }
        }

        //Cancel button
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
