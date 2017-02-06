using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pomodoro
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int hour, min, sec, ms = 0;
        int sessionLength;

        private void notifyIcon1_BalloonTipClicked(object sender, EventArgs e)
        {
            clock.Text = "Break Started";
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            timer1.Start();
            sessionLength = Convert.ToInt32(textBox1.Text);

            if (timer1.Enabled && startButton.Text == "Pause")
            {
                timer1.Stop();
                startButton.Text = "Start";
            }
            if (timer1.Enabled && startButton.Text == "Start")
            {
                startButton.Text = "Pause";
            }          
        }


        private void resetButton_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            clock.Text = "00:00";
            hour = 0;
            min = 0;
            sec = 0;
            ms = 0;
            startButton.Text = "Start";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            clock.Text = hour + ":" + min + ":" + sec + ":" + ms.ToString();
            ms++;
            if (ms > 10)
            {
                sec++;
                ms = 0;
            }
            if (sec >= 60)
            {
                min++;
                sec = 0;
            }
            if (min == sessionLength)
            {
                clock.Text = "You're Done!";
                timer1.Stop();
                notifyIcon1.BalloonTipTitle = "Pomodoro Finished";
                notifyIcon1.BalloonTipText = "Start Break";
                notifyIcon1.ShowBalloonTip(3000);
            }
        }
    }
}
