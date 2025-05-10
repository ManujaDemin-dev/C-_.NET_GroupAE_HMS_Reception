using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace TrustWell_Hospital
{
    public partial class Labpayment2 : Form
    {
        private List<(int TestID, string TestName, decimal TestPrice)> selectedTests = new List<(int, string, decimal)>();

        public Labpayment2()
        {
            InitializeComponent();
            LoadLabpayment2();
            this.btnsearch.Click += new System.EventHandler(this.button1_search);
            this.Checkout.Click += new System.EventHandler(this.Checkout_Click);
            this.dataGridView1.CellContentClick += new DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
        }

        private void Labpayment2_Load(object sender, EventArgs e) { }

        public void LoadLabpayment2(string name = "")
        {
            string query = "SELECT TestID, TestName, TestPrice, TestType FROM Testtypes WHERE 1=1";
            var parameters = new List<MySqlParameter>();

            if (!string.IsNullOrWhiteSpace(name))
            {
                query += " AND (TestName LIKE @name OR TestID LIKE @name)";
                parameters.Add(new MySqlParameter("@name", "%" + name + "%"));
            }

            DataTable dt = Database.ExecuteQuery(query, parameters.ToArray());
            dataGridView1.DataSource = dt;

            if (!dataGridView1.Columns.Contains("Add"))
            {
                DataGridViewButtonColumn viewBtn = new DataGridViewButtonColumn();
                viewBtn.HeaderText = "";
                viewBtn.Text = "Add";
                viewBtn.UseColumnTextForButtonValue = true;
                viewBtn.Name = "Add";
                dataGridView1.Columns.Add(viewBtn);
            }
        }

        private void txtname_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_search(object sender, EventArgs e)
        {
            LoadLabpayment2(txtname.Text.Trim());
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "Add")
            {
                int testID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["TestID"].Value);
                string testName = dataGridView1.Rows[e.RowIndex].Cells["TestName"].Value.ToString();
                decimal testPrice = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["TestPrice"].Value);

                // Avoid duplicates
                if (!selectedTests.Any(t => t.TestID == testID))
                {
                    selectedTests.Add((testID, testName, testPrice));
                    MessageBox.Show($"Test '{testName}' added to bill.", "Test Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Test '{testName}' is already added.", "Duplicate Test", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void Checkout_Click(object sender, EventArgs e)
        {
            if (selectedTests.Count == 0)
            {
                MessageBox.Show("No tests selected for billing.", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Labbill1 billForm = new Labbill1(selectedTests);
            billForm.StartPosition = FormStartPosition.CenterScreen;
            billForm.ShowDialog();
            this.Hide();
        }
    }
}
