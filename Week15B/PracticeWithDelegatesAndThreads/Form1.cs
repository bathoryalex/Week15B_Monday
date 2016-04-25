using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticeWithDelegatesAndThreads
{
    public partial class Form1 : Form
    {
        bool Cancel;

        public Form1()
        {
            InitializeComponent();
        }

        private void TimeConsumingMethod(object Time)
        {
            int seconds;
            seconds = (int)Time;
            for (int j = 1; j <= seconds; j++)
            {
                SetProgress((int)(j * 100) / seconds);
                System.Threading.Thread.Sleep(1000);
                if (Cancel)
                {
                    break;
                }
            }
            if (Cancel)
            {
                System.Windows.Forms.MessageBox.Show("Cancelled");
                Cancel = false;
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Complete");
            }

        }

        private delegate void TimeConsumingMethodDelegate(int seconds);

        public delegate void SetProgressDelegate(int val);
        public void SetProgress(int val)
        {
            if (ProgressBar1.InvokeRequired)
            {
                SetProgressDelegate del = new SetProgressDelegate(SetProgress);
                this.Invoke(del, new object[] { val });
            }
            else
            {
                ProgressBar1.Value = val;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            System.Threading.Thread aThread = new System.Threading.Thread(TimeConsumingMethod);
            aThread.Start(int.Parse(textBox1.Text));
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Cancel = true;
        }
    }
}
