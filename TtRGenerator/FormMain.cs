using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
namespace TtRGenerator
{
    public partial class FormMain : Form
    {
        private string connectionString;
        public FormMain()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["TtRGeneratorDatabaseCS"].ConnectionString;

        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            GetAllGames();
            if (dgvAllGameNames.Rows.Count > 0)
            {
                textBox1.Text = dgvAllGameNames.Rows[0].Cells["GameName"].Value.ToString();
                textBox2.Text = dgvAllGameNames.Rows[0].Cells["GameDetailsId"].Value.ToString();
                GameGraphics(dgvAllGameNames.Rows[0]);
            }
            else
            {
                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
            }
        }
        public void GetAllGames()
        {
            string query = "SELECT * FROM GameDetails";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter(query, connection);
                DataTable dt1 = new DataTable();
                sqlDa.Fill(dt1);
                connection.Close();

                dgvAllGameNames.DataSource = null;
                dgvAllGameNames.AutoGenerateColumns = false;
                dgvAllGameNames.DataSource = dt1;
            }
            timer1.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            GetAllGames();
        }

        //Clicked on datagridView
        private void dgvAllGameNames_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (e.RowIndex >= 0 && e.RowIndex < dgvAllGameNames.Rows.Count)
            {
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;

                pictureBox1.Image=null;
                DataGridViewRow selectedRow = dgvAllGameNames.Rows[index];
                textBox1.Text = selectedRow.Cells[0].Value.ToString();
                textBox2.Text = selectedRow.Cells[1].Value.ToString();
                GameGraphics(selectedRow);

            }
        }

        private void GameGraphics(DataGridViewRow selectedRow)
        {
            if (selectedRow.Cells[2].Value != DBNull.Value && selectedRow.Cells[2].Value != null)
            {
                byte[] imageData = (byte[])selectedRow.Cells[2].Value;

                if (imageData != null && imageData.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        pictureBox1.Visible = true;
                        pictureBox1.Image = Image.FromStream(ms);
                    }
                }
            }
        }

        //Clicked elsewhere
        private void FormMain_Click(object sender, EventArgs e)
        {
            if (!dgvAllGameNames.Bounds.Contains(dgvAllGameNames.PointToClient(Cursor.Position)))
            {
                textBox1.Text = "";
                textBox2.Text = "";
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;

                pictureBox1.Image = null;
                pictureBox1.Visible = false;
            }
        }

        //Add new game
        private void button1_Click(object sender, EventArgs e)
        {
            var myForm = new FormCreateGameDetails();
            myForm.Show();
        }

        //Use selected game
        private void button2_Click(object sender, EventArgs e)
        {
            string gameDetailsId = textBox2.Text;
            string gameDetailsName = textBox1.Text;

            if (CheckConditions(gameDetailsId))
            {
                var myForm = new FormUseSelectedGame(gameDetailsId);
                myForm.Show();
            }
            else
                MessageBox.Show($"Error! Can not find '{gameDetailsName}'!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }

        //Delete selected game
        private void button3_Click(object sender, EventArgs e)
        {
            string gameDetailsId = textBox2.Text;
            string gameDetailsName = textBox1.Text;

            if (CheckConditions(gameDetailsId))
            {
                var myForm = new FormDeleteGameDetails(gameDetailsId);
                myForm.Show();
            }
            else
                MessageBox.Show($"Error! Can not find '{gameDetailsName}'!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        //Edit selected game
        private void button4_Click(object sender, EventArgs e)
        {
            string gameDetailsId = textBox2.Text;
            string gameDetailsName = textBox1.Text;

            if (CheckConditions(gameDetailsId))
            {
                var myForm = new FormEditGameDetails(gameDetailsId);
                myForm.Show();
            }
            else
                MessageBox.Show($"Error! Can not find '{gameDetailsName}'!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private bool CheckConditions(string gameDetailsId)
        {
            string query = $"SELECT * FROM GameDetails WHERE GameDetailsId = {gameDetailsId}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter(query, connection);
                DataTable dt1 = new DataTable();
                sqlDa.Fill(dt1);
                connection.Close();

                if (dt1.Rows.Count > 0)
                    return true;
                else

                    return false;
            }
        }


    }
}
