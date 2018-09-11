using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace izaxon_powercord_alarm
{
    public partial class Form1 : Form
    {
        private bool started = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // System.Diagnostics.Debug.WriteLine(SystemInformation.PowerStatus.PowerLineStatus);
            if (started && SystemInformation.PowerStatus.PowerLineStatus == PowerLineStatus.Offline)
            {
                Console.Beep(2000, 500);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            if(SystemInformation.PowerStatus.PowerLineStatus == PowerLineStatus.Offline)
            {
                Console.Beep(2000, 500);
                MessageBox.Show("Please connect the power coord now! This is needed for the alarm to work properly");
                started = true;
            }
            else
            {
                Console.Beep(1000, 1000);
                Console.Beep(2000, 200);
                started = true;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
