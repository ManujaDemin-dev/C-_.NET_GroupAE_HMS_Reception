using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrustWell_Hospital
{
    public partial class DashboardForm: Form
    {
        private DateTimeDisplay dateTimeDisplay;

        public DashboardForm()
        {
            InitializeComponent();
            dateTimeDisplay = new DateTimeDisplay(label1, label2);
            this.Doctors.Click += new System.EventHandler(this.Doctors_Click);


        }

        private void LoadUserControl(UserControl uc)
        {
            panel3.Controls.Clear();   // Make sure this matches the panel name
            uc.Dock = DockStyle.Fill;
            panel3.Controls.Add(uc);
        }

        private void Doctors_Click(object sender, EventArgs e)
        {
            LoadUserControl(new doctors());
        }
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
