using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace TrustWell_Hospital
{
    public partial class appointment_doc : Form
    {
        private int doctorid;
        private string doctorName;
        private string special;
        private int fees;
        public appointment_doc(int DocID, string DOCNAME ,string speci,int fee)
        {
            InitializeComponent();
            doctorid = DocID;
            doctorName = DOCNAME;
            special = speci;
            fees = fee;
            LoadDocDetails();
            LoadPatients();

        }

        private void LoadDocDetails()
        {
            label7.Text = $"Doctor ID : {doctorid}";
            label4.Text = $"Doctor Name : {doctorName}";
            label2.Text = $"Specialization : {special}";
        }


        private void LoadPatients(string name = "", string mobile = "")
        {
            string query = "SELECT PatientID, PatientName, patientNIC, ContactNumber FROM Patients WHERE 1=1";

            var parameters = new List<MySqlParameter>();


            DataTable dt = Database.ExecuteQuery(query, parameters.ToArray());

            gunaDataGridViewPatients.DataSource = dt;

            if (!gunaDataGridViewPatients.Columns.Contains("View"))
            {
                DataGridViewButtonColumn viewBtn = new DataGridViewButtonColumn();
                viewBtn.HeaderText = "Action";
                viewBtn.Text = "View";
                viewBtn.UseColumnTextForButtonValue = true;
                viewBtn.Name = "View";
                gunaDataGridViewPatients.Columns.Add(viewBtn);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void appointment_doc_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
