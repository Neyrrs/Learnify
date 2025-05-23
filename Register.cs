﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Leaernify
{
    public partial class Register : UserControl
    {
        private Auth auth;

        public Register(Auth form)
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
                    DialogResult confirm = MessageBox.Show("Yakin untuk membuat akun?", "System", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirm == DialogResult.Yes)
                    {
                        con.Open();
                        string query = "insert into users VALUES(@nama,@password,@alamat,@email, @noTelp, 'siswa', @namaLengkap)";
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@nama", txtUsername.Text);
                            cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                            cmd.Parameters.AddWithValue("@alamat", textArea.Text);
                            cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                            cmd.Parameters.AddWithValue("@noTelp", txtNoTelp.Text);
                            cmd.Parameters.AddWithValue("@namaLengkap", txtNamaLengkap.Text);

                            object result = cmd.ExecuteScalar();
                            MessageBox.Show("Akun berhasil dibuat", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Login loginPage = new Login(auth);
                            loginPage.Show();
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Username atau password harus diisi dengan benar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void button1_Click(object sender, EventArgs e)
        {
            auth.loadPage(new Login(auth));
        }
    }
}
