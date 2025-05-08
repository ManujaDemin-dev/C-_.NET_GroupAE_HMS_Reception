using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

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
            this.button5.Click += new System.EventHandler(this.button5_Click);
            this.button2.Click += new System.EventHandler(this.button2_Click);



        }

        private void LoadUserControl(UserControl uc)
        {
            panel3.Controls.Clear();   // Make sure this matches the panel name
            uc.Dock = DockStyle.Fill;
            panel3.Controls.Add(uc);
        }

        private void Doctors_Click(object sender, EventArgs e)
        {
        }
        private void button2_Click(object sender, EventArgs e)
        {
            LoadUserControl(new patients1());

        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
           
            this.label6.Text = $"Welcome, {UserSession.Username}";


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void NewAppointment_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            LoadUserControl(new Addpatient1());
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {















        }

        private void Doctors_Click_1(object sender, EventArgs e)
        {

        }

       
    }
}
