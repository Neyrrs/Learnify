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

namespace Leaernify
{
    public partial class BookingLog : UserControl
    {
        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Learnify;Integrated Security=True;");
        SqlCommand cmd;

        public BookingLog()
        {
            InitializeComponent();
        }

        private void BookingLog_Load(object sender, EventArgs e)
        {
            getData(); // Panggil getData() setelah komponen UI siap
        }

        public void getData()
        {
            try
            {
                // Cek apakah dataGridView1 sudah ada
                if (dataGridView1 == null)
                {
                    MessageBox.Show("Error: dataGridView1 belum diinisialisasi!");
                    return;
                }

                con.Open();
                string query = @"
                SELECT 
                b.id AS Booking_ID, 
                b.user_id AS User_ID, 
                u.username AS Nama_User,
                b.pengajar_id AS Pengajar_ID, 
                p.nama AS Nama_Pengajar,
                FORMAT(b.tanggal_booking, 'dd MMM yyyy - HH:mm') AS Tanggal_Booking, 
                b.status AS Status
                FROM Booking b
                JOIN Users u ON b.user_id = u.id
                JOIN Pengajar p ON b.pengajar_id = p.id";

                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;

                // Ubah header DataGridView
                dataGridView1.Columns["Booking_ID"].HeaderText = "ID Booking";
                dataGridView1.Columns["Nama_User"].HeaderText = "Nama User";
                dataGridView1.Columns["Nama_Pengajar"].HeaderText = "Nama Pengajar";
                dataGridView1.Columns["Tanggal_Booking"].HeaderText = "Tanggal Booking";
                dataGridView1.Columns["Status"].HeaderText = "Status Booking";

                

                // Ubah warna teks berdasarkan status
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    var statusCell = row.Cells["Status"].Value;
                    if (statusCell != null)
                    {
                        string statusText = statusCell.ToString();
                        if (statusText == "Pending cancel")
                        {
                            row.Cells["Status"].Style.ForeColor = Color.Orange;
                        }
                        else if (statusText == "Approved")
                        {
                            row.Cells["Status"].Style.ForeColor = Color.Green;
                        }
                        else if (statusText == "Rejected")
                        {
                            row.Cells["Status"].Style.ForeColor = Color.Red;
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
