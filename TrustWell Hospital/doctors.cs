using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto.Parameters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography;
using System.Windows.Forms;
using WindowsFormsApp1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TrustWell_Hospital
{
    public partial class doctors : UserControl
    {
        private int docid;
        private int comVal;

        public doctors()
        {
            InitializeComponent();
            LoadSpecializations();
            LoadDoctors();
        }

        private void LoadDoctors(string name = "", string specializationId = "")
        {
            //gunaDataGridView1.Columns.Add("ID", "ID");
            //gunaDataGridView1.Columns.Add("Name", "Name");
            //gunaDataGridView1.Columns.Add("Age", "Age");

            //^^^^^look i thought were gonna need this guys but we dont :)
            string query = "SELECT d.DoctorID, d.DoctorName, s.Specialization, d.Fees, d.ContactNumber FROM Doctors d JOIN Doc_specialization s ON d.Specialization = s.specialization_id WHERE 1=1";

            var parameters = new List<MySqlParameter>();


            if (!string.IsNullOrWhiteSpace(name))
            {
                query += " AND d.DoctorName LIKE @name ";
                parameters.Add(new MySqlParameter("@name", "%" + name + "%"));
                //parameters.Add(new MySqlParameter("@nic", "%" +  + "%"));
            }

            if (!string.IsNullOrWhiteSpace(specializationId))
            {
                query += " AND s.Specialization = @spec";
                parameters.Add(new MySqlParameter("@spec", specializationId));

            }


            DataTable dt = Database.ExecuteQuery(query, parameters.ToArray());

            gunaDataGridView1.DataSource = dt;

            if (!gunaDataGridView1.Columns.Contains("AddAppointment"))
            {
                DataGridViewButtonColumn AddAppointment = new DataGridViewButtonColumn();
                AddAppointment.HeaderText = "AddAppointment";
                AddAppointment.Text = "AddAppointment";
                AddAppointment.UseColumnTextForButtonValue = true;
                AddAppointment.Name = "AddAppointment";
                gunaDataGridView1.Columns.Add(AddAppointment);
            }

            if (!gunaDataGridView1.Columns.Contains("View"))
            {
                DataGridViewButtonColumn viewBtn = new DataGridViewButtonColumn();
                viewBtn.HeaderText = "View Details";
                viewBtn.Text = "View";
                viewBtn.UseColumnTextForButtonValue = true;
                viewBtn.Name = "View";
                gunaDataGridView1.Columns.Add(viewBtn);
            }

            if (gunaDataGridView1.Columns.Contains("DoctorID"))
            {
                gunaDataGridView1.Columns["DoctorId"].Visible = false;
            }

        }


        // private void DoctorsForm_Load(object sender, EventArgs e)
        // {
        //     // Add custom buttons manually if not added in designer

        // }


        private void LoadSpecializations()
        {
            string query = "SELECT * FROM Doc_specialization";
            DataTable dt = Database.ExecuteQuery(query, null);
            ComboBox1.DisplayMember = "Specialization";
            ComboBox1.ValueMember = "specialization_id";
            ComboBox1.DataSource = dt;
            ComboBox1.SelectedIndex = -1;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void doctors_Load(object sender, EventArgs e)
        {

        }

        private void gunaDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void doctors_Load_1(object sender, EventArgs e)
        {

        }

        private void gunaDataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && gunaDataGridView1.Columns[e.ColumnIndex].Name == "View")
            {
                int DOCID = Convert.ToInt32(gunaDataGridView1.Rows[e.RowIndex].Cells["DoctorID"].Value);
                view_btn_doc popup = new view_btn_doc(DOCID);
                popup.StartPosition = FormStartPosition.CenterParent;
                popup.ShowDialog();
            }

            if (e.RowIndex >= 0 && gunaDataGridView1.Columns[e.ColumnIndex].Name == "AddAppointment")
            {
                int Docid = Convert.ToInt32(gunaDataGridView1.Rows[e.RowIndex].Cells["DoctorID"].Value);
                string Docname = gunaDataGridView1.Rows[e.RowIndex].Cells["DoctorName"].Value.ToString();
                string spec = gunaDataGridView1.Rows[e.RowIndex].Cells["Specialization"].Value.ToString();
                int Docfee = Convert.ToInt32(gunaDataGridView1.Rows[e.RowIndex].Cells["Fees"].Value);
                appointment_doc popup = new appointment_doc(Docid, Docname, spec, Docfee);
                popup.StartPosition = FormStartPosition.CenterParent;
                popup.ShowDialog();
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            //comVal = int.Parse(ComboBox1.Text);

            //MessageBox.Show($"{ComboBox1.Text}");

            LoadDoctors(TextBox1.Text, ComboBox1.Text);
        }

        private void TextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
