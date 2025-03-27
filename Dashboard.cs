using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Leaernify
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            LoadPage(new BookingLog());
        }
        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Learnify;Integrated Security=True;");
        SqlCommand cmd;

        private void LoadPage(UserControl page)
        {
            mainLayout.Controls.Clear();
            page.Dock = DockStyle.Fill;
            mainLayout.Controls.Add(page);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            LoadPage(new Main());
        }

        private void btnRequest_Click(object sender, EventArgs e)
        {
            LoadPage(new UserRequest());
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void mainLayout_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnHome_Click_1(object sender, EventArgs e)
        {
            LoadPage(new BookingLog());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadPage(new UserRequest());

        }
    }
}
