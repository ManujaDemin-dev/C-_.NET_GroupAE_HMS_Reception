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
using Guna.UI.WinForms;

namespace TrustWell_Hospital
{
    public partial class patients1: UserControl
    {
        public patients1()
        {
            InitializeComponent();
            LoadPatients();
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            this.dataGridViewPatients.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPatients_CellContentClick);



        }

        private void patients1_Load(object sender, EventArgs e)
        {

        }

        public void LoadPatients(string name = "", string mobile = "")
        {
            DataTable dt = publicfunctions.GetPatients(name, mobile);
            dataGridViewPatients.DataSource = dt;

            

            if (dataGridViewPatients.Columns.Contains("PatientID"))
                dataGridViewPatients.Columns["PatientID"].Visible = false;

            if (!dataGridViewPatients.Columns.Contains("View"))
            {
                DataGridViewButtonColumn viewBtn = new DataGridViewButtonColumn();
                viewBtn.HeaderText = "Action";
                viewBtn.Text = "View";
                viewBtn.UseColumnTextForButtonValue = true;
                viewBtn.Name = "View";
                dataGridViewPatients.Columns.Add(viewBtn);
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadPatients(txtNameSearch.Text.Trim(), txtMobileSearch.Text.Trim());
        }

        private void dataGridViewPatients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridViewPatients.Columns[e.ColumnIndex].Name == "View")
            {
                int patientID = Convert.ToInt32(dataGridViewPatients.Rows[e.RowIndex].Cells["PatientID"].Value);
                PatientMiniPage popup = new PatientMiniPage(patientID);
                popup.StartPosition = FormStartPosition.CenterParent;
                popup.ShowDialog(); 
            }
        }

        private void dataGridViewPatients_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunaLabel1_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {

        }
    }
}
