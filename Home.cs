using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Leaernify
{
    public partial class Home : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Learnify;Integrated Security=True;");
        SqlCommand cmd;

        public Home()
        {
            InitializeComponent();
            LoadPage(new Main());
            getData();
        }

        public void getData()
        {
            try
            {
                con.Open();
                string query = "SELECT username FROM users WHERE username = @username";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@username", userSession.username);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtUsername.Text = reader["username"].ToString();
                        }
                        else
                        {
                            txtUsername.Text = "User tidak ditemukan";
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            getData();
        }

        public void edit()
        {
            //String username = txtName.Text;
            con.Open();
            string query = "Update users set username = @username where role = 'user'";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                //cmd.Parameters.AddWithValue("@username", username);
                int rowsAffected = cmd.ExecuteNonQuery();
            }
        }



        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LoadPage(UserControl page)
        {
            mainLayout.Controls.Clear();
            page.Dock = DockStyle.Fill;
            mainLayout.Controls.Add(page);
        }


        private void button1_Click(object sender, EventArgs e)
        {

            con.Open();
            //String id = txtEdit.Text;
            string query = "Update Booking set status = 'Pending cancel' where user_id = @id";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                //cmd.Parameters.AddWithValue("@id", id);
                int rowsAffected = cmd.ExecuteNonQuery();
            }
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                //txtEdit.Text = row.Cells["id"].Value.ToString(); 
            }
        }


        private void btnHome_Click(object sender, EventArgs e)
        {
            LoadPage(new Main());
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            LoadPage(new History());
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void txtUsername_Click(object sender, EventArgs e)
        {

        }

        private void sideBar_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}