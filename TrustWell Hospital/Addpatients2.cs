using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrustWell_Hospital
{
    public partial class Addpatients2: UserControl
    {
        private string _name;
        private string _nic;
        public Addpatients2()
        {
            InitializeComponent();
        }
        public Addpatients2(string name, string nic)
        {
            InitializeComponent();
            _name = name;
            _nic = nic;

            // Display received data (for example in labels or textboxes)
            pName.Text = _name;
            NIC.Text = _nic;
        }
        private void Addpatients2_Load(object sender, EventArgs e)
        {
            dob.Format = DateTimePickerFormat.Custom;
            dob.CustomFormat = " "; // blank
        }

        private void dob_ValueChanged(object sender, EventArgs e)
        {
            this.dob.Format = DateTimePickerFormat.Custom;
            this.dob.CustomFormat = "yyyy - MMM - dd";

            DateTime dob = this.dob.Value;
            DateTime today = DateTime.Today;

            int age = today.Year - dob.Year;


            //birthday has not arrived yet..
            if (dob.Date > today.AddYears(-age))
            {
                age--;          //age is 1 year younger
            }

            this.age.Text = age.ToString();
        }

        private void submit_Click(object sender, EventArgs e)
        {
            //validation
            if (string.IsNullOrWhiteSpace(pName.Text))
            {
                MessageBox.Show("Please enter the patient's name.");
                pName.Focus();
                return;
            }

            if (this.age.Value == 0)
            {
                MessageBox.Show("Please enter the patient's age.");
                this.age.Focus();
                return;
            }

            if (this.gender.SelectedIndex == -1)
            {
                MessageBox.Show("Please select gender.");
                this.gender.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(this.address.Text))
            {
                MessageBox.Show("Please enter the patient's address.");
                this.address.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(this.phone.Text))
            {
                MessageBox.Show("Please enter the patient's phone number.");
                this.phone.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(this.email.Text))
            {
                MessageBox.Show("Please enter the patient's email.");
                this.email.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(this.NIC.Text))
            {
                MessageBox.Show("Please enter the patient's email.");
                this.NIC.Focus();
                return;
            }

            if (!this.dob.Checked)
            {
                MessageBox.Show("Please select date of birth.");
                this.dob.Focus();
                return;
            }

            if (this.age.Value < 0 || this.age.Value > 120)
            {
                MessageBox.Show("Please enter a valid age.");
                this.age.Focus();
                return;
            }

            if (!this.phone.Text.All(char.IsDigit) || this.phone.Text.Length != 10)
            {
                MessageBox.Show("Please enter a valid phone number.");
                this.phone.Focus();
                return;
            }

            if (!this.email.Text.Contains("@") || !this.email.Text.Contains("."))
            {
                MessageBox.Show("Please enter a valid email address.");
                this.email.Focus();
                return;
            }


            if (!this.contact.Text.All(char.IsDigit) || this.contact.Text.Length != 10)
            {
                MessageBox.Show("Please enter a valid phone number.");
                this.contact.Focus();
                return;
            }

            if (!this.gEmail.Text.Contains("@") || !this.gEmail.Text.Contains("."))
            {
                MessageBox.Show("Please enter a valid email address.");
                this.gEmail.Focus();
                return;
            }



            //if validation is complete..

            string name = this.pName.Text.Trim();
            int age = (int)this.age.Value;
            string dob = this.dob.Value.ToString("yyyy-MM-dd");
            string gender = this.gender.SelectedItem.ToString();
            string address = this.address.Text.Trim();
            string phone = this.phone.Text.Trim();
            string email = this.email.Text.Trim();
            string NIC = this.NIC.Text.Trim();

            string gName = this.gName.Text.Trim();
            string gPhone = this.contact.Text.Trim();
            string gGender = this.gGender.SelectedItem.ToString();
            string relation = this.relation.Text.Trim();
            string Gemail = this.gEmail.Text.Trim();
            string gNIC = this.gNIC.Text.Trim();

        }
    }
}
