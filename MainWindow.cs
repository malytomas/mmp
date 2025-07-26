using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace mmp
{
    public partial class MainWindow : Form
    {
        Random random;
        KeyboardHook hook;
        TreeNode current;
        int playmode;
        List<string> extensionSupported;

        public Player player;
        public Infobar infobar;
        public Volumebar volumebar;
        public fullscreenDetector fsDetector;

        public MainWindow()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            InitializeComponent();
            fsDetector = new fullscreenDetector();
            random = new Random();
            hook = new KeyboardHook();
            hook.HookedKeys.Add(Keys.MediaNextTrack);
            hook.HookedKeys.Add(Keys.MediaPlayPause);
            hook.HookedKeys.Add(Keys.MediaStop);
            hook.KeyUp += new KeyEventHandler(hook_KeyUp);
            for (int i = 0; i < 11; i++)
            {
                ToolStripMenuItem but = new ToolStripMenuItem();
                but.Text = (i * 10).ToString() + " %";
                but.Click += new EventHandler(volumeButtonToolStripMenuItem_Click);
                but.Tag = i;
                volumeToolStripMenuItem.DropDownItems.Add(but);
            }
            for (int i = 0; i < tabPlaymode.Controls.Count; i++)
            {
                ToolStripMenuItem but = new ToolStripMenuItem();
                RadioButton brt = tabPlaymode.Controls[3 - i] as RadioButton;
                but.Click += new EventHandler(playmodeToolStripMenuItem_Click);
                brt.Click += new EventHandler(playmodeToolStripMenuItem_Click);
                but.Tag = brt.Tag = i;
                but.Text = brt.Text;
                playModeToolStripMenuItem.DropDownItems.Add(but);
            }
        }

        public bool PlayerLoad(TreeNode node)
        {
            player.Stop();
            if (!player.Load(node.FullPath))
                return false;
            current = node;
            directory.Invalidate();
            if (infobar != null)
                InfobarOpen(false);
            return true;
        }

        public void PlayerTogglePlayPause()
        {
            if (player.IsPlaying())
            {
                if (player.IsPaused())
                    player.Resume();
                else
                    player.Pause();
            }
            else
                player.Play();
        }

        public void PlayerNext()
        {
            player.Stop();
            if (directory.Nodes.Count == 0 || (directory.Nodes[0].Tag as TriTreeView.CheckedCounter).Checked == 0)
                return;
            switch (playmode)
            {
                case 1:
                    player.Play();
                    break;
                case 2:
                    PlayerNextContinue();
                    break;
                case 3:
                    PlayerNextRandom();
                    break;
            }
        }

        public void PlayerPlayMode(int mode)
        {
            playmode = mode;
            for (int i = 0; i < tabPlaymode.Controls.Count; i++)
            {
                ToolStripMenuItem but = playModeToolStripMenuItem.DropDownItems[i] as ToolStripMenuItem;
                RadioButton brt = tabPlaymode.Controls[i] as RadioButton;
                but.Checked = (Convert.ToInt32(but.Tag) == playmode);
                brt.Checked = (Convert.ToInt32(brt.Tag) == playmode);
            }
        }

        public void WindowShow()
        {
            TopMost = true;
            Show();
            TopMost = false;
            if (infobar != null && infobar.Visible)
                infobar.Close();
        }

        public void WindowHide()
        {
            Hide();
        }

        public void WindowToggleShowHide()
        {
            if (Visible)
                WindowHide();
            else
                WindowShow();
        }

        public void VolumebarOpen()
        {
            if (volumebar != null)
                volumebar.Close();
            volumebar = new Volumebar();
            volumebar.main = this;
            volumebar.Show();
        }

        public void InfobarOpen(bool auto)
        {
            if (infobar != null)
                infobar.Close();
            if (current == null)
                return;
            infobar = new Infobar(auto);
            infobar.main = this;
            infobar.progressBar.Maximum = (int)player.GetLength();
            infobar.recalculate();
            infobar.nameLabel.Text = current.FullPath;
            infobar.Show();
        }

        private string extractName(string path)
        {
            int r = path.LastIndexOf("\\");
            return path.Substring(r + 1);
        }

        private void DirectoryLoadOne(string path, TreeNodeCollection nodes)
        {
            TreeNode node = new TreeNode(extractName(path));
            nodes.Add(node);

            try
            {
                foreach (string dir in Directory.GetDirectories(path))
                    DirectoryLoadOne(dir, node.Nodes);
            }
            catch (System.Exception)
            { }

            try
            {
                foreach (string fil in Directory.GetFiles(path))
                {
                    if (extensionSupported.Contains(fil.Substring(fil.LastIndexOf(".") + 1)))
                    {
                        TreeNode n = new TreeNode(extractName(fil));
                        node.Nodes.Add(n);
                    }
                }
            }
            catch (System.Exception)
            { }

            if (node.Nodes.Count == 0)
                nodes.Remove(node);
        }

        private TreeNode DirectoryLoadCheckFind(TreeNodeCollection nodes, string what)
        {
            if (nodes == null)
                return null;
            foreach (TreeNode node in nodes)
                if (node.Text == what)
                    return node;
            return null;
        }

        private void DirectoryLoadCheck()
        {
            StreamReader r = File.OpenText("playlist.mmp");
            Stack<TreeNodeCollection> nodes = new Stack<TreeNodeCollection>();
            nodes.Push(directory.Nodes);
            while (true)
            {
                string line = r.ReadLine();
                if (line == null)
                    break;
                if (line == "")
                    continue;
                if (line.EndsWith("{"))
                {
                    TreeNode n = DirectoryLoadCheckFind(nodes.Peek(), line.Substring(0, line.Length - 1));
                    if (n == null)
                        nodes.Push(null);
                    else
                        nodes.Push(n.Nodes);
                }
                else if (line == "}")
                    nodes.Pop();
                else
                    directory.ToggleNodeState(DirectoryLoadCheckFind(nodes.Peek(), line));
            }
            r.Close();
        }

        private void DirectoryLoad()
        {
            directory.BeginUpdate();
            directory.Nodes.Clear();
            current = null;
            DirectoryLoadOne(settingRootPathText.Text, directory.Nodes);
            if (directory.Nodes.Count > 0)
            {
                directory.Nodes[0].Text = settingRootPathText.Text;
                directory.PrepareNodeCounters();
                if (File.Exists("playlist.mmp"))
                    DirectoryLoadCheck();
                directory.Nodes[0].Expand();
            }
            directory.EndUpdate();
        }

        private void DirectorySaveOne(TreeNodeCollection nodes, StreamWriter w)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.StateImageIndex != (int)TriTreeView.CheckedState.UnChecked)
                {
                    w.Write(node.Text);
                    if (node.Nodes.Count > 0 && node.StateImageIndex != (int)TriTreeView.CheckedState.Checked)
                    {
                        w.WriteLine("{");
                        DirectorySaveOne(node.Nodes, w);
                        w.Write("}");
                    }
                    w.WriteLine();
                }
            }
        }

        private void DirectorySave()
        {
            directory.BeginUpdate();
            StreamWriter w = File.CreateText("playlist.mmp");
            DirectorySaveOne(directory.Nodes, w);
            w.Close();
            directory.EndUpdate();
        }

        private string ConfLoad()
        {
            string curr = "";
            Ini c = new Ini("mmp.ini");
            settingRootPathText.Text = c.Read("path", "root", System.IO.Directory.GetCurrentDirectory());
            curr = c.Read("path", "current", "");
            player.Volume(c.Read("player", "volume", 1f));
            PlayerPlayMode(c.Read("player", "playmode", 2));
            deviceSetByName(c.Read("player", "device", "<default>"));
            int x = c.Read("window", "left", Location.X),
                y = c.Read("window", "top", Location.Y),
                w = c.Read("window", "width", Size.Width),
                h = c.Read("window", "height", Size.Height);
            Location = new System.Drawing.Point(x, y);
            Size = new System.Drawing.Size(w, h);
            if (c.Read("window", "hide", "") == "true")
                PostMessage(Handle, 0x0112, 0xF020, 0);
            Infobar.disapearDelay = c.Read("infobar", "delay", 1000);
            Infobar.disapearDuration = c.Read("infobar", "disappear-duration", 2000);
            Infobar.autoDuration = c.Read("infobar", "auto-duration", 10000);
            infobarShowMode.SelectedIndex = c.Read("infobar", "show-mode", 0);
            Volumebar.disapearDelay = c.Read("volumebar", "delay", 1000);
            Volumebar.disapearDuration = c.Read("volumebar", "duration", 2000);
            c.Close();
            return curr;
        }

        private void ConfSave()
        {
            Ini c = new Ini("mmp.ini");
            c.Clear();
            c.Write("path", "root", settingRootPathText.Text);
            c.Write("path", "current", current == null ? "" : current.FullPath);
            c.Write("player", "volume", player.GetVolume().ToString());
            c.Write("player", "playmode", playmode.ToString());
            c.Write("player", "device", (string)devicesComboBox.SelectedItem);
            c.Write("window", "left", Location.X.ToString());
            c.Write("window", "top", Location.Y.ToString());
            c.Write("window", "width", Size.Width.ToString());
            c.Write("window", "height", Size.Height.ToString());
            c.Write("window", "hide", !Visible ? "true" : "false");
            c.Write("infobar", "delay", Infobar.disapearDelay.ToString());
            c.Write("infobar", "disappear-duration", Infobar.disapearDuration.ToString());
            c.Write("infobar", "auto-duration", Infobar.autoDuration.ToString());
            c.Write("infobar", "show-mode", infobarShowMode.SelectedIndex.ToString());
            c.Write("volumebar", "delay", Volumebar.disapearDelay.ToString());
            c.Write("volumebar", "duration", Volumebar.disapearDuration.ToString());
            c.Close();
        }

        private TreeNode PlayerNextContinueOne(TreeNode n)
        {
            if (n == null)
            {
                n = directory.Nodes[0];
                while (n.Nodes.Count > 0)
                    n = n.Nodes[0];
                return n;
            }
            if (n.NextNode != null)
                return n.NextNode;
            while (n.NextNode == null)
            {
                if (n.Parent == null)
                    return PlayerNextContinueOne(null);
                n = n.Parent;
            }
            n = n.NextNode;
            while (n.Nodes.Count > 0)
                n = n.Nodes[0];
            return n;
        }

        private void PlayerNextContinue()
        {
            TreeNode n = PlayerNextContinueOne(current);
            while ((n.Tag as TriTreeView.CheckedCounter).Checked == 0)
                n = PlayerNextContinueOne(n);
            PlayerLoad(n);
            player.Play();
        }

        private void PlayerNextRandom()
        {
            TreeNode n = directory.Nodes[0];
            int slc = random.Next((n.Tag as TriTreeView.CheckedCounter).Checked) + 1;
            while (slc > 0)
            {
                if (n.Nodes.Count > 0 && (n.Tag as TriTreeView.CheckedCounter).Checked >= slc)
                    n = n.Nodes[0];
                else
                {
                    slc -= (n.Tag as TriTreeView.CheckedCounter).Checked;
                    if (slc > 0)
                        n = n.NextNode;
                }
            }
            PlayerLoad(n);
            player.Play();
        }

        private void tabsWindow_LoadCurr(string path, TreeNodeCollection nodes)
        {
            foreach (TreeNode n in nodes)
            {
                if (path.StartsWith(n.Text))
                {
                    if (n.Nodes.Count > 0)
                        tabsWindow_LoadCurr(path.Substring(n.Text.Length + 1), n.Nodes);
                    else if (n.Text == path)
                        PlayerLoad(n);
                }
            }
        }

        private void tabsWindow_Load(object sender, EventArgs e)
        {
            try
            {
                player = new Player();
            }
            catch (System.Exception)
            {
                MessageBox.Show("FMOD Initialization failed.");
                Environment.Exit(1);
                return;
            }
            player.onPlay += this.playerOnPlay;
            extensionSupported = player.GetExtensionsSupported();
            string curr = ConfLoad();
            devicesReloadButton_Click(null, null);
            DirectoryLoad();
            if (curr != "")
                tabsWindow_LoadCurr(curr, directory.Nodes);
        }

        private void tabsWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            ConfSave();
            DirectorySave();
        }

        private void hook_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.MediaNextTrack:
                    PlayerNext();
                    break;
                case Keys.MediaPlayPause:
                    PlayerTogglePlayPause();
                    break;
                case Keys.MediaStop:
                    player.Stop();
                    break;
            }
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case System.Windows.Forms.MouseButtons.Left:
                    if (System.Windows.Input.Keyboard.Modifiers == System.Windows.Input.ModifierKeys.Shift)
                        WindowToggleShowHide();
                    else if (System.Windows.Input.Keyboard.Modifiers == System.Windows.Input.ModifierKeys.Control)
                        PlayerTogglePlayPause();
                    else if (System.Windows.Input.Keyboard.Modifiers == System.Windows.Input.ModifierKeys.Alt)
                        PlayerNext();
                    else
                        InfobarOpen(false);
                    break;
                case System.Windows.Forms.MouseButtons.Middle:
                    if (System.Windows.Input.Keyboard.Modifiers == System.Windows.Input.ModifierKeys.Shift)
                        player.Volume(1);
                    else if (System.Windows.Input.Keyboard.Modifiers == System.Windows.Input.ModifierKeys.Control)
                        player.Volume(0.5f);
                    else if (System.Windows.Input.Keyboard.Modifiers == System.Windows.Input.ModifierKeys.Alt)
                        player.Volume(0);
                    else
                        VolumebarOpen();
                    break;
            }
        }

        private void volumeButtonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            player.Volume(((float)Convert.ToInt32((sender as ToolStripMenuItem).Tag)) * 0.1f);
        }

        private void playmodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                PlayerPlayMode(Convert.ToInt32((sender as RadioButton).Tag));
                return;
            }
            catch (System.Exception)
            { }
            try
            {
                PlayerPlayMode(Convert.ToInt32((sender as ToolStripMenuItem).Tag));
                return;
            }
            catch (System.Exception)
            { }
        }

        private void showHideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowToggleShowHide();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void playToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlayerTogglePlayPause();
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            player.Stop();
        }

        private void nextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlayerNext();
        }

        private void playCurrentlySelected()
        {
            if (directory.SelectedNode != null && directory.SelectedNode.Nodes.Count == 0)
            {
                if (PlayerLoad(directory.SelectedNode))
                    player.Play();
            }
        }

        private void directory_DoubleClick(object sender, EventArgs e)
        {
            MouseEventArgs myArgs = (MouseEventArgs)e;
            if (myArgs.Button == MouseButtons.Left)
                playCurrentlySelected();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (player.Tick())
                PlayerNext();
        }

        private void directory_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            e.Cancel = e.Node.Parent == null;
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0112 && (m.WParam.ToInt32() & 0xfff0) == 0xF020)
            {
                Hide();
                return;
            }
            base.WndProc(ref m);
        }

        [DllImport("User32.dll", EntryPoint = "PostMessage")]
        private static extern int PostMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void iconReshow_Tick(object sender, EventArgs e)
        {
            iconReshow.Enabled = false;
            icon.Visible = false;
            icon.Visible = true;
        }

        private void directory_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                playCurrentlySelected();
            }
        }

        private void playerOnPlay()
        {
            if (!fsDetector.detectFullscreenApplication() && infobarShowMode.SelectedIndex == 0)
            {
                InfobarOpen(true);
            }
        }

        private void deviceSetByName(string name)
        {
            player.SetDevice(0);
            List<KeyValuePair<FMOD.GUID, string>> devices = player.GetDeviceList();
            devicesComboBox.Items.Clear();
            devicesComboBox.Items.Add("<default>");
            devicesComboBox.SelectedIndex = 0;
            foreach (KeyValuePair<FMOD.GUID, string> dev in devices)
            {
                int curr = devicesComboBox.Items.Add(dev.Value);
                if (dev.Value == name)
                    devicesComboBox.SelectedIndex = curr;
            }
            int d = devicesComboBox.SelectedIndex;
            if (d > 0)
                d--;
            player.SetDevice(d);
        }

        private void devicesReloadButton_Click(object sender, EventArgs e)
        {
            deviceSetByName((string)devicesComboBox.SelectedItem);
        }

        private void devicesComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            deviceSetByName((string)devicesComboBox.SelectedItem);
        }

        private void rootPathReloadButton_Click(object sender, EventArgs e)
        {
            DirectorySave();
            DirectoryLoad();
        }

        private void rootPathChangeButton_Click(object sender, EventArgs e)
        {
            if (settingRootPathBrowser.ShowDialog() == DialogResult.OK)
            {
                settingRootPathText.Text = settingRootPathBrowser.SelectedPath;
                DirectorySave();
                ConfSave();
                DirectoryLoad();
            }
        }
    }
}
