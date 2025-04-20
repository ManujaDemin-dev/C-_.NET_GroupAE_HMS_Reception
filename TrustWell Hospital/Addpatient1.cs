using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using WindowsFormsApp1;

namespace TrustWell_Hospital
{
    public partial class Addpatient1: UserControl
    {
        public Addpatient1()
        {
            InitializeComponent();
            textBox1.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    textBox2.Focus();
                }
            };

            button1.Click += CheckPatientNIC;
        }

        private void CheckPatientNIC(object sender, EventArgs e)
        {
            string patientName = textBox1.Text.Trim();
            string patientNIC = textBox2.Text.Trim();
            

            if (string.IsNullOrWhiteSpace(patientNIC))
            {
                label3.Text = "NIC and Name are required.";
                return;
            }

            string query = "SELECT * FROM Patients WHERE patientNIC = @nic";
            MySqlParameter[] parameters = {
            new MySqlParameter("@nic", patientNIC)
        };

            DataTable dt = Database.ExecuteQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                string existingPatientName = dt.Rows[0]["patientName"].ToString();
                label3.Text = "This patient is already registered. Name: " + existingPatientName;
                existingPatientName = patientName;
            }
            else
            {
               
                  
                    //Addpatients2 addPage = new Addpatients2(patientName, patientNIC);
                    //parentForm.LoadUserControl(addPage); 
                    LoadUserControl(new Addpatients2(patientName, patientNIC));
                
            }
        }
        private void LoadUserControl(UserControl uc)
        {
            panel1.Controls.Clear();   
            uc.Dock = DockStyle.Fill;
            panel1.Controls.Add(uc);
        }

        private void Addpatient1_Load(object sender, EventArgs e)
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
