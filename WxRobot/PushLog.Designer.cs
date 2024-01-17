namespace WxRobot
{
    partial class PushLog
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
            label1 = new Label();
            tbFriend = new TextBox();
            label2 = new Label();
            dtpBegin = new DateTimePicker();
            dtpEnd = new DateTimePicker();
            label3 = new Label();
            btnSearch = new Button();
            statusStrip1 = new StatusStrip();
            tsslStatus = new ToolStripStatusLabel();
            dgvData = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewCheckBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 15);
            label1.Name = "label1";
            label1.Size = new Size(56, 17);
            label1.TabIndex = 0;
            label1.Text = "收信人：";
            // 
            // tbFriend
            // 
            tbFriend.Location = new Point(75, 12);
            tbFriend.Name = "tbFriend";
            tbFriend.Size = new Size(230, 23);
            tbFriend.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(311, 15);
            label2.Name = "label2";
            label2.Size = new Size(68, 17);
            label2.TabIndex = 2;
            label2.Text = "开始时间：";
            // 
            // dtpBegin
            // 
            dtpBegin.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            dtpBegin.Format = DateTimePickerFormat.Custom;
            dtpBegin.Location = new Point(385, 12);
            dtpBegin.Name = "dtpBegin";
            dtpBegin.Size = new Size(160, 23);
            dtpBegin.TabIndex = 3;
            // 
            // dtpEnd
            // 
            dtpEnd.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            dtpEnd.Format = DateTimePickerFormat.Custom;
            dtpEnd.Location = new Point(625, 12);
            dtpEnd.Name = "dtpEnd";
            dtpEnd.Size = new Size(160, 23);
            dtpEnd.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(551, 15);
            label3.Name = "label3";
            label3.Size = new Size(68, 17);
            label3.TabIndex = 4;
            label3.Text = "结束时间：";
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(800, 12);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 6;
            btnSearch.Text = "查询";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { tsslStatus });
            statusStrip1.Location = new Point(0, 461);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(929, 22);
            statusStrip1.TabIndex = 7;
            statusStrip1.Text = "statusStrip1";
            // 
            // tsslStatus
            // 
            tsslStatus.Name = "tsslStatus";
            tsslStatus.Size = new Size(32, 17);
            tsslStatus.Text = "就绪";
            // 
            // dgvData
            // 
            dgvData.AllowUserToAddRows = false;
            dgvData.AllowUserToDeleteRows = false;
            dgvData.AllowUserToResizeRows = false;
            dgvData.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvData.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column7, Column5, Column6 });
            dgvData.Location = new Point(13, 41);
            dgvData.Name = "dgvData";
            dgvData.ReadOnly = true;
            dgvData.RowTemplate.Height = 25;
            dgvData.Size = new Size(904, 417);
            dgvData.TabIndex = 8;
            // 
            // Column1
            // 
            Column1.DataPropertyName = "IdMsg";
            Column1.HeaderText = "消息ID";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            // 
            // Column2
            // 
            Column2.DataPropertyName = "To";
            Column2.HeaderText = "收信人";
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            // 
            // Column3
            // 
            Column3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Column3.DataPropertyName = "Msg";
            Column3.HeaderText = "消息内容";
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            // 
            // Column4
            // 
            Column4.DataPropertyName = "IsSend";
            Column4.HeaderText = "是否发送";
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            // 
            // Column7
            // 
            Column7.DataPropertyName = "Result";
            Column7.HeaderText = "发送结果";
            Column7.Name = "Column7";
            Column7.ReadOnly = true;
            // 
            // Column5
            // 
            Column5.DataPropertyName = "CreateAt";
            Column5.HeaderText = "创建时间";
            Column5.Name = "Column5";
            Column5.ReadOnly = true;
            // 
            // Column6
            // 
            Column6.DataPropertyName = "LastUpdateAt";
            Column6.HeaderText = "更新时间";
            Column6.Name = "Column6";
            Column6.ReadOnly = true;
            // 
            // PushLog
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(929, 483);
            Controls.Add(dgvData);
            Controls.Add(statusStrip1);
            Controls.Add(btnSearch);
            Controls.Add(dtpEnd);
            Controls.Add(label3);
            Controls.Add(dtpBegin);
            Controls.Add(label2);
            Controls.Add(tbFriend);
            Controls.Add(label1);
            Name = "PushLog";
            Text = "发送日志";
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox tbFriend;
        private Label label2;
        private DateTimePicker dtpBegin;
        private DateTimePicker dtpEnd;
        private Label label3;
        private Button btnSearch;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel tsslStatus;
        private DataGridView dgvData;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewCheckBoxColumn Column4;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
    }
}