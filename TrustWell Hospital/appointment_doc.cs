using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace TrustWell_Hospital
{
    public partial class appointment_doc : Form
    {
        public appointment_doc(int DocID)
        {
            InitializeComponent();
        }

        //private void LoadPatientDeatails()
        //{
        //    string query = "SELECT * FROM Patients WHERE DFGDFG = @id";
        //    MySqlParameter[] parameters =
        //    {
        //        new MySqlParameter("@id" , DFGDFG)
        //    };

        //    DataTable dt = Database.ExecuteQuery(query, parameters);

        //    if(dt.Rows.Count > 0)
        //    {
        //        DataRow row = dt.Rows[0];
        //        //now we can add data that are retrived from database :)
        //    }
        //}
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void appointment_doc_Load(object sender, EventArgs e)
        {

        }
    }
}
