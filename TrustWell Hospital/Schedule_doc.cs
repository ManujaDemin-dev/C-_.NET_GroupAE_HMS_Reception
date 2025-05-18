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
    public partial class Schedule_doc: Form
    {
        private int DOCID;
        public Schedule_doc(int doctorID)
        {
            InitializeComponent();
            DOCID = doctorID;
            label1.Text = $"hELLOW DOC ID : {DOCID}";
        }

        private void Schedule_doc_Load(object sender, EventArgs e)
        {

        }
    }
}
