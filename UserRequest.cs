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
    public partial class UserRequest : UserControl
    {
        public UserRequest()
        {
            InitializeComponent();
            getData();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Learnify;Integrated Security=True;");
        SqlCommand cmd;

        public void getData()
        {
            try
            {
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
                JOIN Pengajar p ON b.pengajar_id = p.id
                WHERE b.status = 'Pending cancel'";

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

                // Tambahkan tombol "Terima" jika belum ada
                if (dataGridView1.Columns["Terima"] == null)
                {
                    DataGridViewButtonColumn btnTerima = new DataGridViewButtonColumn();
                    btnTerima.HeaderText = "Aksi";
                    btnTerima.Text = "Terima";
                    btnTerima.UseColumnTextForButtonValue = true;
                    btnTerima.Name = "Terima";
                    dataGridView1.Columns.Add(btnTerima);
                }

                // Tambahkan tombol "Tolak" jika belum ada
                if (dataGridView1.Columns["Tolak"] == null)
                {
                    DataGridViewButtonColumn btnTolak = new DataGridViewButtonColumn();
                    btnTolak.HeaderText = "Aksi";
                    btnTolak.Text = "Tolak";
                    btnTolak.UseColumnTextForButtonValue = true;
                    btnTolak.Name = "Tolak";
                    dataGridView1.Columns.Add(btnTolak);
                }

                // Ubah warna teks berdasarkan status
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    var statusCell = row.Cells["Status"].Value;
                    if (statusCell != null && statusCell.ToString() == "Pending cancel")
                    {
                        row.Cells["Status"].Style.ForeColor = Color.Orange;
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

        private void UserRequest_Load(object sender, EventArgs e)
        {
            getData();
            dataGridView1.CellClick += dataGridView1_CellContentClick_1;
        }

        private void UpdateBookingStatus(string bookingID, string status, string successMessage)
        {
            DialogResult result = MessageBox.Show($"Apakah Anda yakin ingin mengubah status booking menjadi {status}?",
                                                  "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    con.Open();
                    string query = "UPDATE Booking SET status = @status WHERE id = @bookingID";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@status", status);
                        cmd.Parameters.AddWithValue("@bookingID", bookingID);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show(successMessage, "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    getData();
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
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var bookingIDCell = dataGridView1.Rows[e.RowIndex].Cells["Booking_ID"].Value;
                if (bookingIDCell != null)
                {
                    string bookingID = bookingIDCell.ToString();

                    if (e.ColumnIndex == dataGridView1.Columns["Terima"].Index)
                    {
                        // Admin menerima permintaan pembatalan
                        UpdateBookingStatus(bookingID, "Cancelled", "Booking berhasil dibatalkan.");
                    }
                    else if (e.ColumnIndex == dataGridView1.Columns["Tolak"].Index)
                    {
                        // Admin menolak permintaan pembatalan
                        UpdateBookingStatus(bookingID, "Booked", "Permintaan pembatalan ditolak.");
                    }
                }
                else
                {
                    MessageBox.Show("Data Booking ID tidak ditemukan!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
