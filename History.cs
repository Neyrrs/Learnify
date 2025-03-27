using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Leaernify
{
    public partial class History : UserControl
    {
        public History()
        {
            InitializeComponent();
            getData();
        }

        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Learnify;Integrated Security=True;");

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Aksi" && e.RowIndex >= 0)
            {
                var statusCell = dataGridView1.Rows[e.RowIndex].Cells["Status"].Value;
                if (statusCell != null && statusCell.ToString() != "Booked")
                {
                    MessageBox.Show("Hanya booking dengan status 'Booked' yang bisa dibatalkan!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var bookingIDCell = dataGridView1.Rows[e.RowIndex].Cells["Booking_ID"].Value;

                if (bookingIDCell != null)
                {
                    string bookingID = bookingIDCell.ToString();

                    DialogResult result = MessageBox.Show("Apakah Anda yakin ingin membatalkan booking?",
                                                          "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            con.Open();
                            string queryBooking = "UPDATE Booking SET status = 'Pending cancel' WHERE id = @bookingID";
                            using (SqlCommand cmdBooking = new SqlCommand(queryBooking, con))
                            {
                                cmdBooking.Parameters.AddWithValue("@bookingID", bookingID);
                                cmdBooking.ExecuteNonQuery();
                            }

                            MessageBox.Show("Booking berhasil dibatalkan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                else
                {
                    MessageBox.Show("Data Booking ID tidak ditemukan!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        public void getData()
        {
            try
            {
                con.Open();
                int userID = userSession.id;

                string query = @"
                    SELECT 
                        b.id AS Booking_ID, 
                        b.pengajar_id AS pengajar_id, 
                        p.nama AS Nama_Pengajar, 
                        FORMAT(b.tanggal_booking, 'dd MMM yyyy - HH:mm') AS Tanggal_Booking, 
                        b.status AS Status
                    FROM Booking b
                    JOIN Pengajar p ON b.pengajar_id = p.id
                    WHERE b.user_id = @id AND b.status != 'cancelled'";

                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                sda.SelectCommand.Parameters.AddWithValue("@id", userID);

                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;

                dataGridView1.Columns["Booking_ID"].HeaderText = "ID Booking";
                dataGridView1.Columns["Nama_Pengajar"].HeaderText = "Nama Pengajar";
                dataGridView1.Columns["Tanggal_Booking"].HeaderText = "Tanggal Booking";
                dataGridView1.Columns["Status"].HeaderText = "Status Booking";

                if (dataGridView1.Columns["Aksi"] == null)
                {
                    DataGridViewButtonColumn btnCancel = new DataGridViewButtonColumn();
                    btnCancel.HeaderText = "Aksi";
                    btnCancel.Text = "Cancel Booking";
                    btnCancel.UseColumnTextForButtonValue = true;
                    btnCancel.Name = "Aksi";
                    dataGridView1.Columns.Add(btnCancel);
                }

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    var statusCell = row.Cells["Status"].Value;

                    if (statusCell != null)
                    {
                        string status = statusCell.ToString();

                        if (status == "Booked")
                        {
                            row.Cells["Status"].Style.ForeColor = Color.Blue;
                        }
                        else if (status == "Cancelled")
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

        private void History_Load(object sender, EventArgs e)
        {
            dataGridView1.CellClick += dataGridView1_CellContentClick;
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Aksi" && e.RowIndex >= 0)
            {
                var statusCell = dataGridView1.Rows[e.RowIndex].Cells["Status"].Value;
                if (statusCell != null && statusCell.ToString() != "Booked")
                {
                    dataGridView1.Rows[e.RowIndex].Cells["Aksi"].ReadOnly = true;
                    dataGridView1.Rows[e.RowIndex].Cells["Aksi"].Style.ForeColor = Color.Gray;
                    dataGridView1.Rows[e.RowIndex].Cells["Aksi"].Style.BackColor = Color.LightGray;
                }
            }
        }
    }
}
