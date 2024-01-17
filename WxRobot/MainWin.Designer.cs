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
            推送日志ToolStripMenuItem = new ToolStripMenuItem();
            启动服务ToolStripMenuItem = new ToolStripMenuItem();
            停止服务ToolStripMenuItem = new ToolStripMenuItem();
            退出程序ToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            tslRunningStatus = new ToolStripStatusLabel();
            tslPort = new ToolStripStatusLabel();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            tsslQueue = new ToolStripStatusLabel();
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            tslWxPid = new ToolStripStatusLabel();
            btnStart = new Button();
            btnStop = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            label1 = new Label();
            label2 = new Label();
            linkLabel1 = new LinkLabel();
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
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { 推送日志ToolStripMenuItem, 启动服务ToolStripMenuItem, 停止服务ToolStripMenuItem, 退出程序ToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(125, 92);
            // 
            // 推送日志ToolStripMenuItem
            // 
            推送日志ToolStripMenuItem.Name = "推送日志ToolStripMenuItem";
            推送日志ToolStripMenuItem.Size = new Size(124, 22);
            推送日志ToolStripMenuItem.Text = "推送日志";
            推送日志ToolStripMenuItem.Click += 推送日志ToolStripMenuItem_Click;
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
            statusStrip1.Items.AddRange(new ToolStripItem[] { tslRunningStatus, tslPort, toolStripStatusLabel1, tsslQueue, toolStripStatusLabel2, tslWxPid });
            statusStrip1.Location = new Point(0, 188);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(506, 22);
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
            tslPort.Size = new Size(56, 17);
            tslPort.Text = "服务端口";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(118, 17);
            toolStripStatusLabel1.Spring = true;
            // 
            // tsslQueue
            // 
            tsslQueue.Name = "tsslQueue";
            tsslQueue.Size = new Size(75, 17);
            tsslQueue.Text = "发送队列：0";
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new Size(118, 17);
            toolStripStatusLabel2.Spring = true;
            // 
            // tslWxPid
            // 
            tslWxPid.Name = "tslWxPid";
            tslWxPid.Size = new Size(80, 17);
            tslWxPid.Text = "微信进程信息";
            // 
            // btnStart
            // 
            btnStart.Image = Properties.Resources.启动;
            btnStart.Location = new Point(430, 50);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(64, 64);
            btnStart.TabIndex = 2;
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnStop
            // 
            btnStop.Image = Properties.Resources.停止;
            btnStop.Location = new Point(430, 120);
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.Highlight;
            label1.Location = new Point(146, 9);
            label1.Name = "label1";
            label1.Size = new Size(223, 21);
            label1.TabIndex = 4;
            label1.Text = "基于微信PC版的消息推送服务";
            // 
            // label2
            // 
            label2.Location = new Point(12, 36);
            label2.Name = "label2";
            label2.Size = new Size(412, 93);
            label2.TabIndex = 5;
            label2.Text = "本服务实现原理为模拟人工操作，需要激活微信窗体才能发送消息\r\n所以：\r\n1. 必须保证微信处于登录状态\r\n2. 必须保证没有前台激活窗体，否则导致程序无法激活窗体而导致发送失败";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.LinkBehavior = LinkBehavior.HoverUnderline;
            linkLabel1.Location = new Point(199, 167);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(225, 17);
            linkLabel1.TabIndex = 6;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "https://github.com/cxwl3sxl/WxRobot";
            linkLabel1.VisitedLinkColor = Color.Blue;
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // MainWin
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(506, 210);
            Controls.Add(linkLabel1);
            Controls.Add(label2);
            Controls.Add(label1);
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
            Load += MainWin_Load;
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
        private ToolStripMenuItem 推送日志ToolStripMenuItem;
        private Label label1;
        private Label label2;
        private LinkLabel linkLabel1;
        private ToolStripStatusLabel tsslQueue;
        private ToolStripStatusLabel toolStripStatusLabel2;
    }
}