using Guna.UI.WinForms;
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

            if (!gunaDataGridViewPatients.Columns.Contains("Add"))
            {
                DataGridViewButtonColumn addBtn = new DataGridViewButtonColumn();
                addBtn.HeaderText = "Add";
                addBtn.Text = "Add";
                addBtn.UseColumnTextForButtonValue = true;
                addBtn.Name = "Add";
                gunaDataGridViewPatients.Columns.Add(addBtn);
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

        private void gunaDataGridViewPatients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && gunaDataGridViewPatients.Columns[e.ColumnIndex].Name == "Add")
            {
                string PatientName = gunaDataGridViewPatients.Rows[e.RowIndex].Cells["PatientName"].Value.ToString();
                string Contact = gunaDataGridViewPatients.Rows[e.RowIndex].Cells["ContactNumber"].Value.ToString();
                Schedule_doc popup = new Schedule_doc(doctorid,doctorName,special,fees,PatientName,PatientName+doctorName,Contact);
                popup.StartPosition = FormStartPosition.CenterParent;
                popup.ShowDialog();
            }
        }
    }
}
