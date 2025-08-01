﻿namespace mmp
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.settingRootPathBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.icon = new System.Windows.Forms.NotifyIcon(this.components);
            this.iconMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showHideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadDevicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.volumeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabAbout = new System.Windows.Forms.TabPage();
            this.aboutBox = new System.Windows.Forms.RichTextBox();
            this.tabSetting = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.infobarShowMode = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.devicesReloadButton = new System.Windows.Forms.Button();
            this.devicesComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rootPathChangeButton = new System.Windows.Forms.Button();
            this.rootPathReloadButton = new System.Windows.Forms.Button();
            this.settingRootPathText = new System.Windows.Forms.TextBox();
            this.tabPlaymode = new System.Windows.Forms.TabPage();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.tabPlaylist = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.iconReshow = new System.Windows.Forms.Timer(this.components);
            this.directory = new mmp.TriTreeView();
            this.iconMenu.SuspendLayout();
            this.tabAbout.SuspendLayout();
            this.tabSetting.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPlaymode.SuspendLayout();
            this.tabPlaylist.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // settingRootPathBrowser
            // 
            this.settingRootPathBrowser.Description = "Choose path to music root directory";
            this.settingRootPathBrowser.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // icon
            // 
            this.icon.ContextMenuStrip = this.iconMenu;
            this.icon.Icon = ((System.Drawing.Icon)(resources.GetObject("icon.Icon")));
            this.icon.Text = "mmp";
            this.icon.Visible = true;
            this.icon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            // 
            // iconMenu
            // 
            this.iconMenu.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.iconMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showHideToolStripMenuItem,
            this.playerToolStripMenuItem,
            this.playModeToolStripMenuItem,
            this.volumeToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.iconMenu.Name = "contextMenuStrip1";
            this.iconMenu.Size = new System.Drawing.Size(220, 194);
            // 
            // showHideToolStripMenuItem
            // 
            this.showHideToolStripMenuItem.Name = "showHideToolStripMenuItem";
            this.showHideToolStripMenuItem.Size = new System.Drawing.Size(219, 38);
            this.showHideToolStripMenuItem.Text = "Show / Hide";
            this.showHideToolStripMenuItem.Click += new System.EventHandler(this.showHideToolStripMenuItem_Click);
            // 
            // playerToolStripMenuItem
            // 
            this.playerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.nextToolStripMenuItem,
            this.reloadDevicesToolStripMenuItem});
            this.playerToolStripMenuItem.Name = "playerToolStripMenuItem";
            this.playerToolStripMenuItem.Size = new System.Drawing.Size(219, 38);
            this.playerToolStripMenuItem.Text = "Player";
            // 
            // playToolStripMenuItem
            // 
            this.playToolStripMenuItem.Name = "playToolStripMenuItem";
            this.playToolStripMenuItem.Size = new System.Drawing.Size(308, 44);
            this.playToolStripMenuItem.Text = "Play / Pause";
            this.playToolStripMenuItem.Click += new System.EventHandler(this.playToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(308, 44);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // nextToolStripMenuItem
            // 
            this.nextToolStripMenuItem.Name = "nextToolStripMenuItem";
            this.nextToolStripMenuItem.Size = new System.Drawing.Size(308, 44);
            this.nextToolStripMenuItem.Text = "Next";
            this.nextToolStripMenuItem.Click += new System.EventHandler(this.nextToolStripMenuItem_Click);
            // 
            // reloadDevicesToolStripMenuItem
            // 
            this.reloadDevicesToolStripMenuItem.Name = "reloadDevicesToolStripMenuItem";
            this.reloadDevicesToolStripMenuItem.Size = new System.Drawing.Size(308, 44);
            this.reloadDevicesToolStripMenuItem.Text = "Reload Devices";
            this.reloadDevicesToolStripMenuItem.Click += new System.EventHandler(this.devicesReloadButton_Click);
            // 
            // playModeToolStripMenuItem
            // 
            this.playModeToolStripMenuItem.Name = "playModeToolStripMenuItem";
            this.playModeToolStripMenuItem.Size = new System.Drawing.Size(219, 38);
            this.playModeToolStripMenuItem.Text = "Play mode";
            // 
            // volumeToolStripMenuItem
            // 
            this.volumeToolStripMenuItem.Name = "volumeToolStripMenuItem";
            this.volumeToolStripMenuItem.Size = new System.Drawing.Size(219, 38);
            this.volumeToolStripMenuItem.Text = "Volume";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(219, 38);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tabAbout
            // 
            this.tabAbout.Controls.Add(this.aboutBox);
            this.tabAbout.Location = new System.Drawing.Point(8, 8);
            this.tabAbout.Margin = new System.Windows.Forms.Padding(6);
            this.tabAbout.Name = "tabAbout";
            this.tabAbout.Size = new System.Drawing.Size(700, 1310);
            this.tabAbout.TabIndex = 4;
            this.tabAbout.Text = "About";
            this.tabAbout.UseVisualStyleBackColor = true;
            // 
            // aboutBox
            // 
            this.aboutBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.aboutBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aboutBox.Location = new System.Drawing.Point(0, 0);
            this.aboutBox.Margin = new System.Windows.Forms.Padding(6);
            this.aboutBox.Name = "aboutBox";
            this.aboutBox.ReadOnly = true;
            this.aboutBox.Size = new System.Drawing.Size(700, 1322);
            this.aboutBox.TabIndex = 0;
            this.aboutBox.Text = resources.GetString("aboutBox.Text");
            // 
            // tabSetting
            // 
            this.tabSetting.Controls.Add(this.groupBox3);
            this.tabSetting.Controls.Add(this.groupBox2);
            this.tabSetting.Controls.Add(this.groupBox1);
            this.tabSetting.Location = new System.Drawing.Point(8, 8);
            this.tabSetting.Margin = new System.Windows.Forms.Padding(6);
            this.tabSetting.Name = "tabSetting";
            this.tabSetting.Size = new System.Drawing.Size(700, 1310);
            this.tabSetting.TabIndex = 2;
            this.tabSetting.Text = "Setting";
            this.tabSetting.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.infobarShowMode);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 277);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox3.Size = new System.Drawing.Size(700, 100);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Song info window";
            // 
            // infobarShowMode
            // 
            this.infobarShowMode.Dock = System.Windows.Forms.DockStyle.Top;
            this.infobarShowMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.infobarShowMode.Items.AddRange(new object[] {
            "Open when song starts",
            "Manual open only"});
            this.infobarShowMode.Location = new System.Drawing.Point(6, 42);
            this.infobarShowMode.Margin = new System.Windows.Forms.Padding(6);
            this.infobarShowMode.Name = "infobarShowMode";
            this.infobarShowMode.Size = new System.Drawing.Size(688, 45);
            this.infobarShowMode.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.devicesReloadButton);
            this.groupBox2.Controls.Add(this.devicesComboBox);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 135);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox2.Size = new System.Drawing.Size(700, 142);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Audio device";
            // 
            // devicesReloadButton
            // 
            this.devicesReloadButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.devicesReloadButton.Location = new System.Drawing.Point(544, 87);
            this.devicesReloadButton.Margin = new System.Windows.Forms.Padding(6);
            this.devicesReloadButton.Name = "devicesReloadButton";
            this.devicesReloadButton.Size = new System.Drawing.Size(150, 49);
            this.devicesReloadButton.TabIndex = 5;
            this.devicesReloadButton.Text = "Reload";
            this.devicesReloadButton.UseVisualStyleBackColor = true;
            this.devicesReloadButton.Click += new System.EventHandler(this.devicesReloadButton_Click);
            // 
            // devicesComboBox
            // 
            this.devicesComboBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.devicesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.devicesComboBox.FormattingEnabled = true;
            this.devicesComboBox.Location = new System.Drawing.Point(6, 42);
            this.devicesComboBox.Margin = new System.Windows.Forms.Padding(6);
            this.devicesComboBox.Name = "devicesComboBox";
            this.devicesComboBox.Size = new System.Drawing.Size(688, 45);
            this.devicesComboBox.TabIndex = 4;
            this.devicesComboBox.SelectionChangeCommitted += new System.EventHandler(this.devicesComboBox_SelectionChangeCommitted);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rootPathChangeButton);
            this.groupBox1.Controls.Add(this.rootPathReloadButton);
            this.groupBox1.Controls.Add(this.settingRootPathText);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox1.Size = new System.Drawing.Size(700, 135);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Music root path";
            // 
            // rootPathChangeButton
            // 
            this.rootPathChangeButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.rootPathChangeButton.Location = new System.Drawing.Point(6, 85);
            this.rootPathChangeButton.Margin = new System.Windows.Forms.Padding(6);
            this.rootPathChangeButton.Name = "rootPathChangeButton";
            this.rootPathChangeButton.Size = new System.Drawing.Size(150, 44);
            this.rootPathChangeButton.TabIndex = 7;
            this.rootPathChangeButton.Text = "Change";
            this.rootPathChangeButton.UseVisualStyleBackColor = true;
            this.rootPathChangeButton.Click += new System.EventHandler(this.rootPathChangeButton_Click);
            // 
            // rootPathReloadButton
            // 
            this.rootPathReloadButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.rootPathReloadButton.Location = new System.Drawing.Point(544, 85);
            this.rootPathReloadButton.Margin = new System.Windows.Forms.Padding(6);
            this.rootPathReloadButton.Name = "rootPathReloadButton";
            this.rootPathReloadButton.Size = new System.Drawing.Size(150, 44);
            this.rootPathReloadButton.TabIndex = 6;
            this.rootPathReloadButton.Text = "Reload";
            this.rootPathReloadButton.UseVisualStyleBackColor = true;
            this.rootPathReloadButton.Click += new System.EventHandler(this.rootPathReloadButton_Click);
            // 
            // settingRootPathText
            // 
            this.settingRootPathText.Dock = System.Windows.Forms.DockStyle.Top;
            this.settingRootPathText.Location = new System.Drawing.Point(6, 42);
            this.settingRootPathText.Margin = new System.Windows.Forms.Padding(6);
            this.settingRootPathText.Name = "settingRootPathText";
            this.settingRootPathText.ReadOnly = true;
            this.settingRootPathText.Size = new System.Drawing.Size(688, 43);
            this.settingRootPathText.TabIndex = 3;
            // 
            // tabPlaymode
            // 
            this.tabPlaymode.Controls.Add(this.radioButton4);
            this.tabPlaymode.Controls.Add(this.radioButton3);
            this.tabPlaymode.Controls.Add(this.radioButton2);
            this.tabPlaymode.Controls.Add(this.radioButton1);
            this.tabPlaymode.Location = new System.Drawing.Point(8, 8);
            this.tabPlaymode.Margin = new System.Windows.Forms.Padding(6);
            this.tabPlaymode.Name = "tabPlaymode";
            this.tabPlaymode.Padding = new System.Windows.Forms.Padding(6);
            this.tabPlaymode.Size = new System.Drawing.Size(700, 1310);
            this.tabPlaymode.TabIndex = 1;
            this.tabPlaymode.Text = "Play mode";
            this.tabPlaymode.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoCheck = false;
            this.radioButton4.AutoSize = true;
            this.radioButton4.Dock = System.Windows.Forms.DockStyle.Top;
            this.radioButton4.Location = new System.Drawing.Point(6, 129);
            this.radioButton4.Margin = new System.Windows.Forms.Padding(6);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(688, 41);
            this.radioButton4.TabIndex = 3;
            this.radioButton4.Text = "Random";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoCheck = false;
            this.radioButton3.AutoSize = true;
            this.radioButton3.Dock = System.Windows.Forms.DockStyle.Top;
            this.radioButton3.Location = new System.Drawing.Point(6, 88);
            this.radioButton3.Margin = new System.Windows.Forms.Padding(6);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(688, 41);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.Text = "Continue";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoCheck = false;
            this.radioButton2.AutoSize = true;
            this.radioButton2.Dock = System.Windows.Forms.DockStyle.Top;
            this.radioButton2.Location = new System.Drawing.Point(6, 47);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(6);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(688, 41);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "Repeat";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoCheck = false;
            this.radioButton1.AutoSize = true;
            this.radioButton1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radioButton1.Location = new System.Drawing.Point(6, 6);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(6);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(688, 41);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.Text = "Single";
            // 
            // tabPlaylist
            // 
            this.tabPlaylist.Controls.Add(this.directory);
            this.tabPlaylist.Location = new System.Drawing.Point(8, 8);
            this.tabPlaylist.Margin = new System.Windows.Forms.Padding(6);
            this.tabPlaylist.Name = "tabPlaylist";
            this.tabPlaylist.Padding = new System.Windows.Forms.Padding(6);
            this.tabPlaylist.Size = new System.Drawing.Size(700, 1310);
            this.tabPlaylist.TabIndex = 0;
            this.tabPlaylist.Text = "Playlist";
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Controls.Add(this.tabPlaylist);
            this.tabControl1.Controls.Add(this.tabPlaymode);
            this.tabControl1.Controls.Add(this.tabSetting);
            this.tabControl1.Controls.Add(this.tabAbout);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(716, 1369);
            this.tabControl1.TabIndex = 1;
            // 
            // iconReshow
            // 
            this.iconReshow.Enabled = true;
            this.iconReshow.Interval = 30000;
            this.iconReshow.Tick += new System.EventHandler(this.iconReshow_Tick);
            // 
            // directory
            // 
            this.directory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.directory.Location = new System.Drawing.Point(6, 6);
            this.directory.Margin = new System.Windows.Forms.Padding(6);
            this.directory.Name = "directory";
            this.directory.ShowRootLines = false;
            this.directory.Size = new System.Drawing.Size(688, 1298);
            this.directory.TabIndex = 1;
            this.directory.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.directory_BeforeCollapse);
            this.directory.DoubleClick += new System.EventHandler(this.directory_DoubleClick);
            this.directory.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.directory_KeyPress);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(716, 1369);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(574, 71);
            this.Name = "MainWindow";
            this.Text = "mmp";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.tabsWindow_FormClosed);
            this.Load += new System.EventHandler(this.tabsWindow_Load);
            this.iconMenu.ResumeLayout(false);
            this.tabAbout.ResumeLayout(false);
            this.tabSetting.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPlaymode.ResumeLayout(false);
            this.tabPlaymode.PerformLayout();
            this.tabPlaylist.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog settingRootPathBrowser;
        private System.Windows.Forms.NotifyIcon icon;
        private System.Windows.Forms.ContextMenuStrip iconMenu;
        private System.Windows.Forms.ToolStripMenuItem showHideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem volumeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nextToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TabPage tabAbout;
        private System.Windows.Forms.RichTextBox aboutBox;
        private System.Windows.Forms.TabPage tabSetting;
        private System.Windows.Forms.TabPage tabPlaymode;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TabPage tabPlaylist;
        private TriTreeView directory;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Timer iconReshow;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button devicesReloadButton;
        private System.Windows.Forms.ComboBox devicesComboBox;
        private System.Windows.Forms.TextBox settingRootPathText;
        private System.Windows.Forms.ToolStripMenuItem reloadDevicesToolStripMenuItem;
        private System.Windows.Forms.Button rootPathReloadButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox infobarShowMode;
        private System.Windows.Forms.Button rootPathChangeButton;
    }
}

