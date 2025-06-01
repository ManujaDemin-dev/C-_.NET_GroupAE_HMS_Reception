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

    public class DateTimeUpdater
    {
        private Timer timer;

        public void StartDateTimeClock(Label Time ,Label Date)
        {
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += (s, e) =>
            {
                Time.Text = DateTime.Now.ToString("HH:mm:ss");
                Date.Text = DateTime.Now.ToString("yyyy-MM-dd");
               
            };
            timer.Start();
        }
    }

}
