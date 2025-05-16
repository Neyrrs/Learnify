using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Leaernify
{
    public partial class Auth : Form
    {
        public Auth()
        {
            InitializeComponent();
            loadPage(new Login(this));
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public void loadPage(UserControl page)
        {
            panel1.Controls.Clear();
            page.Dock = DockStyle.Fill;
            panel1.Controls.Add(page);
        }

        private void Auth_Load(object sender, EventArgs e)
        {

        }
    }
}
