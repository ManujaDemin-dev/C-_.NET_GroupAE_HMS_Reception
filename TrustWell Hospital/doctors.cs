using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;
using MySql.Data.MySqlClient;

namespace TrustWell_Hospital
{
    public partial class doctors: UserControl
    {
        public doctors()
        {
            InitializeComponent();
            //LoadDoctorData();
        }

        

        private void FillSpecializationCombo()
        {
            string query = "SELECT DISTINCT Specialization FROM Doctors";
            DataTable dt = Database.ExecuteQuery(query, null);
            cmbSpecialization.Items.Clear();
            cmbSpecialization.Items.Add("All");

            foreach (DataRow row in dt.Rows)
            {
                cmbSpecialization.Items.Add(row["Specialization"].ToString());
            }
            cmbSpecialization.SelectedIndex = 0;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadDoctorData();
        }

        private void LoadDoctorData()  
        {
            string query = "SELECT DoctorID, DoctorName, Specialization FROM Doctors";
            List<MySqlParameter> parameters = new List<MySqlParameter>();

            if (!string.IsNullOrWhiteSpace(txtDoctorName.Text))
            {
                query += " AND DoctorName LIKE @name";
                parameters.Add(new MySqlParameter("@name", "%" + txtDoctorName.Text + "%"));
            }

            if (cmbSpecialization.SelectedItem?.ToString() != "All")
            {
                query += " AND Specialization = @special";
                parameters.Add(new MySqlParameter("@special", cmbSpecialization.SelectedItem.ToString()));
            }

            DataTable dt = Database.ExecuteQuery(query, parameters.ToArray());
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("DoctorName", "Doctor Name");
            dataGridView1.Columns.Add("Specialization", "Specialization");

            DataGridViewButtonColumn btnAppointment = new DataGridViewButtonColumn
            {
                Text = "Add Appointment",
                UseColumnTextForButtonValue = true,
                HeaderText = "Add Appointment"
            };
            dataGridView1.Columns.Add(btnAppointment);

            DataGridViewButtonColumn btnView = new DataGridViewButtonColumn
            {
                Text = "View",
                UseColumnTextForButtonValue = true,
                HeaderText = "View"
            };
            dataGridView1.Columns.Add(btnView);

            foreach (DataRow row in dt.Rows)
            {
                dataGridView1.Rows.Add(row["DoctorName"], row["Specialization"]);
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Tag = row["DoctorID"]; // store DoctorID in row.Tag
            }


        }
        private void dgvDoctors_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int doctorID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Tag);

            // Add Appointment Button
            if (e.ColumnIndex == 2) // Add Appointment column
            {
                //var appointmentForm = new AddAppointment(doctorID); // you create this
                //appointmentForm.ShowDialog();
            }

            // View Button
            if (e.ColumnIndex == 3) // View column
            {
                //var viewPopup = new DoctorDetailsPopup(doctorID); // you create this
                //viewPopup.ShowDialog();
            }
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
    }
}
