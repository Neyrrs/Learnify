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
                    string query = "SELECT id, nama, alamat, email, noTelp, role, namaLengkap FROM users WHERE nama=@nama AND password=@password";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@nama", txtUsername.Text);
                        cmd.Parameters.AddWithValue("@password", txtPassword.Text);

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string nama = reader.GetString(1).ToLower();
                            string alamat = reader.GetString(2).ToLower();
                            string email = reader.GetString(3).ToLower();
                            string noTelp = reader.GetString(4).ToLower();
                            string role = reader.GetString(5).ToLower();
                            string namaLengkap = reader.GetString(6).ToLower();

                            userSession.id = id;
                            userSession.nama = txtUsername.Text;
                            userSession.namaLengkap = namaLengkap;
                            userSession.alamat = alamat;
                            userSession.email = email;
                            userSession.noTelp = noTelp;
                            userSession.password = txtPassword.Text;
                            userSession.role = role;
                            Console.WriteLine(nama, namaLengkap, alamat, email, noTelp, txtPassword.Text, role);

                            if (role == "admin")
                            {
                                Dashboard dashboard = new Dashboard();
                                ParentForm.Hide();
                                dashboard.Show();
                            }
                            else if (role == "siswa")
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
