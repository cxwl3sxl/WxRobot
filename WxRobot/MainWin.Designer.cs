namespace WxRobot
{
    partial class MainWin
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWin));
            notifyIcon1 = new NotifyIcon(components);
            contextMenuStrip1 = new ContextMenuStrip(components);
            启动服务ToolStripMenuItem = new ToolStripMenuItem();
            停止服务ToolStripMenuItem = new ToolStripMenuItem();
            退出程序ToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            tslRunningStatus = new ToolStripStatusLabel();
            tslPort = new ToolStripStatusLabel();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            tslWxPid = new ToolStripStatusLabel();
            btnStart = new Button();
            btnStop = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            contextMenuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // notifyIcon1
            // 
            notifyIcon1.ContextMenuStrip = contextMenuStrip1;
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "微信消息发送服务";
            notifyIcon1.Visible = true;
            notifyIcon1.MouseDoubleClick += notifyIcon1_MouseDoubleClick;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { 启动服务ToolStripMenuItem, 停止服务ToolStripMenuItem, 退出程序ToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(125, 70);
            // 
            // 启动服务ToolStripMenuItem
            // 
            启动服务ToolStripMenuItem.Name = "启动服务ToolStripMenuItem";
            启动服务ToolStripMenuItem.Size = new Size(124, 22);
            启动服务ToolStripMenuItem.Text = "启动服务";
            启动服务ToolStripMenuItem.Click += 启动服务ToolStripMenuItem_Click;
            // 
            // 停止服务ToolStripMenuItem
            // 
            停止服务ToolStripMenuItem.Name = "停止服务ToolStripMenuItem";
            停止服务ToolStripMenuItem.Size = new Size(124, 22);
            停止服务ToolStripMenuItem.Text = "停止服务";
            停止服务ToolStripMenuItem.Click += 停止服务ToolStripMenuItem_Click;
            // 
            // 退出程序ToolStripMenuItem
            // 
            退出程序ToolStripMenuItem.Name = "退出程序ToolStripMenuItem";
            退出程序ToolStripMenuItem.Size = new Size(124, 22);
            退出程序ToolStripMenuItem.Text = "退出程序";
            退出程序ToolStripMenuItem.Click += 退出程序ToolStripMenuItem_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { tslRunningStatus, tslPort, toolStripStatusLabel1, tslWxPid });
            statusStrip1.Location = new Point(0, 99);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(360, 22);
            statusStrip1.SizingGrip = false;
            statusStrip1.Stretch = false;
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // tslRunningStatus
            // 
            tslRunningStatus.Name = "tslRunningStatus";
            tslRunningStatus.Size = new Size(44, 17);
            tslRunningStatus.Text = "已停止";
            // 
            // tslPort
            // 
            tslPort.Name = "tslPort";
            tslPort.Size = new Size(0, 17);
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(301, 17);
            toolStripStatusLabel1.Spring = true;
            // 
            // tslWxPid
            // 
            tslWxPid.Name = "tslWxPid";
            tslWxPid.Size = new Size(0, 17);
            // 
            // btnStart
            // 
            btnStart.Image = Properties.Resources.启动;
            btnStart.Location = new Point(103, 22);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(64, 64);
            btnStart.TabIndex = 2;
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnStop
            // 
            btnStop.Image = Properties.Resources.停止;
            btnStop.Location = new Point(193, 22);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(64, 64);
            btnStop.TabIndex = 3;
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // MainWin
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(360, 121);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Controls.Add(statusStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainWin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "微信消息推送服务";
            contextMenuStrip1.ResumeLayout(false);
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private NotifyIcon notifyIcon1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel tslRunningStatus;
        private ToolStripStatusLabel tslWxPid;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private Button btnStart;
        private Button btnStop;
        private ToolStripStatusLabel tslPort;
        private System.Windows.Forms.Timer timer1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem 启动服务ToolStripMenuItem;
        private ToolStripMenuItem 停止服务ToolStripMenuItem;
        private ToolStripMenuItem 退出程序ToolStripMenuItem;
    }
}