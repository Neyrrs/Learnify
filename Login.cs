using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Leaernify
{
    public partial class Login : UserControl
    {
        private Auth auth;

        public Login(Auth form)
        {
            InitializeComponent();
            this.auth = form;
        }

        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Learnify;Integrated Security=True;");
        SqlCommand cmd;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsername.Text != "" && txtPassword.Text != "")
                {
                    con.Open();
                    string query = "SELECT id, role FROM users WHERE Username=@username AND password=@password";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                        cmd.Parameters.AddWithValue("@password", txtPassword.Text);

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            int userId = reader.GetInt32(0);
                            string role = reader.GetString(1).ToLower();

                            userSession.username = txtUsername.Text;
                            userSession.password = txtPassword.Text;
                            userSession.id = userId;

                            if (role == "admin")
                            {
                                Dashboard dashboard = new Dashboard();
                                ParentForm.Hide();
                                dashboard.Show();
                            }
                            else if (role == "user")
                            {
                                Home home = new Home();
                                ParentForm.Hide();
                                home.Show();
                            }
                            else
                            {
                                MessageBox.Show("Role pengguna tidak dikenali!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Salah memasukkan username atau password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        reader.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Mohon isi username dan password!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally 
            {
                con.Close();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            auth.loadPage(new Register(auth));

        }
    }
}
