using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace mmp
{
    public partial class Volumebar : Form
    {
        public MainWindow main;
        private bool disapearing;
        private int time;

        public static int disapearDelay;
        public static int disapearDuration;

        public Volumebar()
        {
            InitializeComponent();
            MinimumSize = new System.Drawing.Size(10, 30);
            System.Drawing.Rectangle desk = Screen.GetWorkingArea(this);
            Location = new System.Drawing.Point(desk.Left + desk.Width - Width, desk.Top + desk.Height - Height);
            disapearing = false;
            time = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value = (int)(100f * main.player.GetVolume());
            if (disapearing)
            {
                time += timer1.Interval;
                if (time >= disapearDelay && disapearDuration > 0)
                    Opacity = (disapearDelay + disapearDuration - time) / (float)disapearDuration;
                if (time >= disapearDelay + disapearDuration)
                    Close();
            }
            else
                time = 0;
        }

        private void Volumebar_FormClosed(object sender, FormClosedEventArgs e)
        {
            main.volumebar = null;
        }

        private void Volumebar_Activated(object sender, EventArgs e)
        {
            disapearing = false;
            Opacity = 1;
        }

        private void Volumebar_Deactivate(object sender, EventArgs e)
        {
            disapearing = true;
        }

        private void progressBar1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            main.player.Volume(1f - (e.Y - progressBar1.Top) / (float)progressBar1.Height);
        }

        private void Volumebar_Shown(object sender, EventArgs e)
        {
            Activate();
        }
    }
}
