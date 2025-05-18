using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace TrustWell_Hospital
{
    public partial class Labpayment2 : Form
    {
        private List<(int TestID, string TestName, decimal TestPrice)> cart = new List<(int, string, decimal)>();

        private string patientName;
        private string referenceNo;
        private string contactNumber;
        private int   patientID;
        

        public Labpayment2(string patientName, string referenceNo, string contactNumber,int  patientID)
        {
            InitializeComponent();
            this.patientName = patientName;
            this.referenceNo = referenceNo;
            this.contactNumber = contactNumber;
            this.patientID = patientID;

            LoadLabpayment2();

            this.btnsearch.Click += button1_search;
            this.DataGridView1.CellContentClick += dataGridView1_CellContentClick;
            this.cartDataGridView.CellContentClick += cartDataGridView_CellContentClick;
            this.Checkout.Click += Checkout_Click;
            this.btnToggleCart.Click += BtnToggleCart_Click;

            // Hide cart panel initially
            panelCart.Visible = false;

            // Add label for cart count (superscript for the View Cart button)
            Label lblCartBadge = new Label
            {
                Name = "lblCartBadge", // Name it for easy reference
                Text = "0",  // Initial count is 0
                ForeColor = Color.Black,
                BackColor = Color.Transparent, // Background color for the badge
                Font = new Font("Arial", 10, FontStyle.Bold),
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleCenter,
                Padding = new Padding(4, 2, 4, 2),
                Location = new Point(btnToggleCart.Width - 25, 2), // Adjust the position on the button
                Visible = true
            };
            btnToggleCart.Controls.Add(lblCartBadge); // Add the label to the button

            lblCartBadge.SendToBack();
        }

        private void Labpayment2_Load(object sender, EventArgs e) { }

        public void LoadLabpayment2(string name = "")
        {
            string query = "SELECT TestID, TestName, TestPrice, Type FROM Testtypes WHERE 1=1";
            var parameters = new List<MySqlParameter>();

            if (!string.IsNullOrWhiteSpace(name))
            {
                query += " AND (TestName LIKE @name OR TestID LIKE @name)";
                parameters.Add(new MySqlParameter("@name", "%" + name + "%"));
            }

            DataTable dt = Database.ExecuteQuery(query, parameters.ToArray());
            DataGridView1.DataSource = dt;

            if (!DataGridView1.Columns.Contains("Add"))
            {
                DataGridViewButtonColumn addBtn = new DataGridViewButtonColumn
                {
                    HeaderText = "",
                    Text = "Add",
                    UseColumnTextForButtonValue = true,
                    Name = "Add"
                };
                DataGridView1.Columns.Add(addBtn);
            }

            if (cartDataGridView.Columns.Count == 0)
            {
                cartDataGridView.Columns.Add("TestID", "Test ID");
                cartDataGridView.Columns.Add("TestName", "Test Name");
                cartDataGridView.Columns.Add("TestPrice", "Price");

                DataGridViewButtonColumn removeBtn = new DataGridViewButtonColumn
                {
                    HeaderText = "",
                    Text = "Remove",
                    UseColumnTextForButtonValue = true,
                    Name = "Remove"
                };
                cartDataGridView.Columns.Add(removeBtn);
            }

            RefreshCart();
        }

        private void button1_search(object sender, EventArgs e)
        {
            LoadLabpayment2(txtname.Text.Trim());
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && DataGridView1.Columns[e.ColumnIndex].Name == "Add")
            {
                int testID = Convert.ToInt32(DataGridView1.Rows[e.RowIndex].Cells["TestID"].Value);
                string testName = DataGridView1.Rows[e.RowIndex].Cells["TestName"].Value.ToString();
                decimal testPrice = Convert.ToDecimal(DataGridView1.Rows[e.RowIndex].Cells["TestPrice"].Value);

                if (!cart.Any(t => t.TestID == testID))
                {
                    cart.Add((testID, testName, testPrice));
                    MessageBox.Show($"Test '{testName}' added to cart.", "Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshCart();
                }
                else
                {
                    MessageBox.Show($"Test '{testName}' is already in the cart.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void cartDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && cartDataGridView.Columns[e.ColumnIndex].Name == "Remove")
            {
                int testID = Convert.ToInt32(cartDataGridView.Rows[e.RowIndex].Cells["TestID"].Value);
                cart.RemoveAll(t => t.TestID == testID);
                MessageBox.Show("Test removed from cart.", "Removed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshCart();
            }
        }

        private void RefreshCart()
        {
            cartDataGridView.Rows.Clear();

            foreach (var test in cart)
            {
                cartDataGridView.Rows.Add(test.TestID, test.TestName, test.TestPrice);
            }

            // Update total
            decimal total = cart.Sum(t => t.TestPrice);
            lblTotal.Text = $"Total: Rs. {total:N2}";

            // Update the cart badge (item count)
            Label lblCartBadge = btnToggleCart.Controls["lblCartBadge"] as Label;
            if (lblCartBadge != null)
            {
                lblCartBadge.Text = cart.Count.ToString();  // Update the number in the badge
            }
        }

        private void BtnToggleCart_Click(object sender, EventArgs e)
        {
            panelCart.Visible = !panelCart.Visible;
            btnToggleCart.Text = panelCart.Visible ? "Hide Cart" : "View Cart";
        }

        private void Checkout_Click(object sender, EventArgs e)
        {
            if (cart.Count == 0)
            {
                MessageBox.Show("No tests in cart.", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.Hide();
            Labbill1 billForm = new Labbill1(cart, patientName, referenceNo, contactNumber, patientID);
            billForm.StartPosition = FormStartPosition.CenterScreen;
            billForm.ShowDialog();
            this.Close();
        }

        private void lblTotal_Click(object sender, EventArgs e) { }

        private void Checkout_Click_1(object sender, EventArgs e) { }
    }
}
