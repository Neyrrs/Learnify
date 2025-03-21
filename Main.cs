using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Leaernify
{
    public partial class Main : UserControl
    {
        public Main()
        {
            InitializeComponent();
            loadDoesenCard();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Learnify;Integrated Security=True;");
        SqlCommand cmd;

        public void loadDoesenCard(){
            con.Open();
            string query = "SELECT * FROM pengajar";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {

                    while (reader.Read()) // Loop untuk setiap dosen
                    {
                        int id = reader.GetInt32(0);
                        string nama = reader.GetString(1);

                        string mataPelajaran = reader.GetString(2);
                        string status = reader.GetString(3);

                        if (status != null)
                        {

                            Panel dosenCard = CreateDosenCard(id, nama, mataPelajaran, status);
                            flowLayoutPanel1.Controls.Add(dosenCard);
                        }
                        else
                        {
                            Panel dosenCard = CreateDosenCard(id, "", "", status);
                            flowLayoutPanel1.Controls.Add(dosenCard);
                        }
                    }
                }

            }
        }

        private Panel CreateDosenCard(int id, string nama, string mataPelajaran, string status)
        {
            Panel card = new Panel
            {
                Size = new Size(250, 150),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White,
                Margin = new Padding(10),

            };

            Label lblNama = new Label
            {
                Font = new Font("Poppins", 12, FontStyle.Regular),
                Text = "Nama: " + nama,
                Location = new Point(10, 30),
                AutoSize = true
            };

            Label lblMataPelajaran = new Label
            {
                Font = new Font("Poppins", 10, FontStyle.Regular),
                Text = "Mata Pelajaran: " + mataPelajaran,
                AutoSize = true,
                Location = new Point(10, 60),
            };

            Button btnBooking = new Button
            {
                Font = new Font("Poppins", 7, FontStyle.Bold),
                Text = "Status",
                Location = new Point(10, 90),
                Enabled = (status != "Booked"),
                Tag = id,
                AutoSize = true,
                BackColor = Color.FromArgb(96, 139,193),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            // Tambahkan elemen ke dalam card
            card.Controls.Add(lblNama);
            card.Controls.Add(lblMataPelajaran);
            card.Controls.Add(btnBooking);

            return card;
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
