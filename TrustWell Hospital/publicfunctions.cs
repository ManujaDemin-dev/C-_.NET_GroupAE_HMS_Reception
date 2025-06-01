using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1;

namespace TrustWell_Hospital
{
    public static class publicfunctions
    {
        public static DataTable GetPatients(string name = "", string mobile = "")
        {
            string query = "SELECT PatientID, PatientName, patientNIC, ContactNumber FROM Patients WHERE 1=1";
            var parameters = new List<MySqlParameter>();

            if (!string.IsNullOrWhiteSpace(name))
            {
                query += " AND (PatientName LIKE @name OR patientNIC LIKE @name)";
                parameters.Add(new MySqlParameter("@name", "%" + name + "%"));
            }

            if (!string.IsNullOrWhiteSpace(mobile))
            {
                query += " AND ContactNumber LIKE @mobile";
                parameters.Add(new MySqlParameter("@mobile", "%" + mobile + "%"));
            }

            return Database.ExecuteQuery(query, parameters.ToArray());
        }
    }
}
