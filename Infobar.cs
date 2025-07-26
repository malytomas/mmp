using System;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;

namespace mmp
{
    public partial class Infobar : Form
    {
        public MainWindow main;
        private bool disapearing;
        private int time;
        private bool autoEnabled;

        public static int disapearDelay;
        public static int disapearDuration;
        public static int autoDuration;

        public Infobar(bool auto)
        {
            InitializeComponent();
            System.Drawing.Rectangle desk = Screen.GetWorkingArea(this);
            Location = new System.Drawing.Point(desk.Left + desk.Width - Width, desk.Top + desk.Height - Height);
            disapearing = false;
            time = 0;
            timer2.Interval = autoDuration;
            timer2.Enabled = auto;
            autoEnabled = auto;
        }

        private float opacityCalc(float x)
        {
            return x * x;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            recalculate();
            if (disapearing)
            {
                time += timer1.Interval;
                if (time >= disapearDelay && disapearDuration > 0)
                    Opacity = opacityCalc((disapearDelay + disapearDuration - time) / (float)disapearDuration);
                if (Opacity < 0.03)
                    Close();
            }
            else
                time = 0;
        }

        private void Infobar_Activated(object sender, EventArgs e)
        {
            timer2.Enabled = false;
            disapearing = false;
            Opacity = 1;
        }

        private void Infobar_Deactivate(object sender, EventArgs e)
        {
            disapearing = true;
        }

        private string zerofill(int num)
        {
            if (num < 10)
                return "0" + num.ToString();
            else
                return num.ToString();
        }

        private string timetext(int num)
        {
            return zerofill((num / 1000 / 60 / 60)) + ":" + zerofill((num / 1000 / 60) % 60) + ":" + zerofill((num / 1000) % 60);
        }

        public void recalculate()
        {
            progressBar.Value = (int)main.player.GetPosition();
            progressLabel.Text = timetext(progressBar.Value) + " / " + timetext(progressBar.Maximum);
        }

        private void Infobar_FormClosed(object sender, FormClosedEventArgs e)
        {
            main.infobar = null;
        }

        private void progressBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            main.player.Position((uint)((e.X - progressBar.Left) * progressBar.Maximum / (float)progressBar.Width));
            if (!main.player.IsPlaying())
                main.player.Play();
        }

        private void Infobar_Shown(object sender, EventArgs e)
        {
            /*
            if (!autoEnabled)
                Activate();*/
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Enabled = false;
            disapearing = true;
        }

        protected override bool ShowWithoutActivation
        {
            get { return autoEnabled; }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                int WS_EX_TOPMOST = 0x00000008;
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= WS_EX_TOPMOST;
                return cp;
            }
        }
    }
}
