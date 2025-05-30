using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using WindowsFormsApp1;

namespace TrustWell_Hospital
{
    public partial class LabPayment1 : UserControl
    {
        public LabPayment1()
        {
            InitializeComponent();
            LoadLabpayment();
            this.btnsearch.Click += new System.EventHandler(this.button1_search);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        public void LoadLabpayment(string name = "", string mobile = "")
        {
            string query = "SELECT PatientID, PatientName, patientNIC, ContactNumber FROM Patients WHERE 1=1";
            var parameters = new List<MySqlParameter>();
            if (!string.IsNullOrWhiteSpace(name))
            {
                query += " AND (PatientName LIKE @name OR patientNIC  LIKE @name)";
                parameters.Add(new MySqlParameter("@name", "%" + name + "%"));
                //parameters.Add(new MySqlParameter("@nic", "%" +  + "%"));
            }

            if (!string.IsNullOrWhiteSpace(mobile))
            {
                query += " AND (ContactNumber LIKE @mobile OR patientNIC LIKE @nic";
                parameters.Add(new MySqlParameter("@mobile", "%" + mobile + "%"));

            }
            DataTable dt = Database.ExecuteQuery(query, parameters.ToArray());

            dataGridView1.DataSource = dt;
            if (dataGridView1.Columns.Contains("PatientID"))
                dataGridView1.Columns["PatientID"].Visible = false;

            if (!dataGridView1.Columns.Contains("View"))
            {
                DataGridViewButtonColumn viewBtn = new DataGridViewButtonColumn();
                viewBtn.HeaderText = "";
                viewBtn.Text = "View";
                viewBtn.UseColumnTextForButtonValue = true;
                viewBtn.Name = "View";
                dataGridView1.Columns.Add(viewBtn);
            }
        }
        private void button1_search(object sender, EventArgs e)
        {
            LoadLabpayment(txtname.Text.Trim(), txtmobile.Text.Trim());
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "View")
            {
                int patientID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["PatientID"].Value);
                string patientName = dataGridView1.Rows[e.RowIndex].Cells["PatientName"].Value.ToString();
                string contactNumber = dataGridView1.Rows[e.RowIndex].Cells["ContactNumber"].Value.ToString();

                // Generate a Reference Number — customize this as needed
                string referenceNo = $"REF-{DateTime.Now:yyyyMMddHHmmss}";
                Labpayment2 testsPage = new Labpayment2(patientName, referenceNo, contactNumber,patientID);
                testsPage.StartPosition = FormStartPosition.CenterParent;
                testsPage.ShowDialog();
            }
        }


        private void txtname_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gunaTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtmobile_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
