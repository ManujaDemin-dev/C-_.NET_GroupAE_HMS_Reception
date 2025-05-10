using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrustWell_Hospital
{
    public partial class Labbill1 : Form
    {
        //store the selected test details
        private List<(int TestID, string TestName, decimal TestPrice)> selectedTests;
        //constructor that receives from the other form
        public Labbill1(List<(int TestID, string TestName, decimal TestPrice)> selectedTests)
        {
            InitializeComponent();
            this.selectedTests=selectedTests;
            this.Load += Labbill_Load;
            btnCancel.Click += btnCancel_Click;
            btnPrint.Click += btnPrint_Click;
        }
        private void Labbill_Load(object sender, EventArgs e)
        {
            txtDateTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");//Date setting and time 

            string summary = "";
            decimal total = 0;

            foreach (var test in selectedTests)
            {
                summary  += test.TestName + " - Rs. " + test.TestPrice.ToString("N2") + "\n";//N2 means need decimal points
                total += test.TestPrice;
            }

            summary += "\nTotal Price: Rs." +total.ToString("N2");

            txtBillSummary.Text = summary;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bill is printed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
