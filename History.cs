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
    public partial class History : UserControl
    {
        public History()
        {
            InitializeComponent();
            getData();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Learnify;Integrated Security=True;");
        SqlCommand cmd;

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Aksi"].Index && e.RowIndex >= 0)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells["id"] != null &&
                    dataGridView1.Rows[e.RowIndex].Cells["id"].Value != null)
                {
                    string pengajarID = dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString();

                    DialogResult result = MessageBox.Show("Apakah Anda yakin ingin membatalkan booking?",
                                                          "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes && con.State == ConnectionState.Closed)
                    {
                        try
                        {
                            con.Open(); 
                            string query = "UPDATE pengajar SET status = 'booked' WHERE id = @id";
                            using (SqlCommand cmd = new SqlCommand(query, con))
                            {
                                cmd.Parameters.AddWithValue("@id", pengajarID);
                                cmd.ExecuteNonQuery();
                            }

                            getData();
                            MessageBox.Show("Booking berhasil dibatalkan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Terjadi kesalahan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            con.Close();
                            getData();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Data ID tidak ditemukan!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }


        public void getData()
        {
            if (con.State == ConnectionState.Closed)
            { 
            try
            {
                con.Open();
                string query = "SELECT * FROM pengajar where status = 'available'";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;

                if (dataGridView1.Columns["Aksi"] == null)
                {
                    DataGridViewButtonColumn btnCancel = new DataGridViewButtonColumn();
                    btnCancel.HeaderText = "Aksi";
                    btnCancel.Text = "Cancel Booking";
                    btnCancel.UseColumnTextForButtonValue = true;
                    btnCancel.Name = "Aksi";
                        dataGridView1.Columns.Add(btnCancel);
                    con.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message);
            }
            }
        }

        private void History_Load(object sender, EventArgs e)
        {
            dataGridView1.CellClick += dataGridView1_CellContentClick;

        }
    }
}
