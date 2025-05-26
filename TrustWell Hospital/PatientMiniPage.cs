using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using WindowsFormsApp1;

namespace TrustWell_Hospital
{
    public partial class PatientMiniPage : Form
    {
        private int patientID;
        public PatientMiniPage(int id)
        {
            InitializeComponent();
            patientID = id;
            LoadPatientDetails();
        }

        private void PatientMiniPage_Load(object sender, EventArgs e)
        {



        }
        private void LoadPatientDetails()
        {
            string query = "SELECT * FROM Patients WHERE PatientID = @id";
            MySqlParameter[] parameters = {
            new MySqlParameter("@id", patientID)
        };

            DataTable dt = Database.ExecuteQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                lblName.Text = "Name: " + row["PatientName"].ToString();
                lblNIC.Text = "NIC: " + row["patientNIC"].ToString();
                label5.Text = "Gender: " + row["Gender"].ToString();
                lblDOB.Text = "DOB: " + Convert.ToDateTime(row["DateOfBirth"]).ToString("yyyy-MM-dd");
                lblPhone.Text = "Phone: " + row["ContactNumber"].ToString();
                lblEmail.Text = "Email: " + row["Email"].ToString();
                lblAddress.Text = "Address: " + row["Address"].ToString();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }

} 


