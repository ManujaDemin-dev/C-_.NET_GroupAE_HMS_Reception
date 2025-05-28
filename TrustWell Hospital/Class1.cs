using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TrustWell_Hospital
{
    class Class1
    {
    }

    public class DateTimeDisplay
    {
        private Label labelDate;
        private Label labelTime;
        private Timer timer;

        public DateTimeDisplay(Label dateLabel, Label timeLabel)
        {
            labelDate = dateLabel;
            labelTime = timeLabel;

            timer = new Timer();
            timer.Interval = 1000; 
            timer.Tick += UpdateDateTime;
            timer.Start();

            UpdateDateTime(null, null); 
        }

        private void UpdateDateTime(object sender, EventArgs e)
        {
            labelDate.Text = DateTime.Now.ToString("dd MMMM yyyy");
            labelTime.Text = DateTime.Now.ToString("hh:mm tt");
        }
    }

}
