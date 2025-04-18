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
            label1.Text = $"Name: {_name}";
            label2.Text = $"NIC: {_nic}";
        }
        private void Addpatients2_Load(object sender, EventArgs e)
        {

        }
    }
}
