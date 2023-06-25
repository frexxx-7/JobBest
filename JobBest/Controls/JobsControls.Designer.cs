namespace JobBest.Controls
{
    partial class JobsControls
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.numberResponsesPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.ResponsesLabel = new System.Windows.Forms.Label();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.bodyLabel = new System.Windows.Forms.Label();
            this.headLabel = new System.Windows.Forms.Label();
            this.coverPicture = new Guna.UI2.WinForms.Guna2PictureBox();
            this.budgetLabel = new System.Windows.Forms.Label();
            this.dateLabel = new System.Windows.Forms.Label();
            this.guna2Panel1.SuspendLayout();
            this.numberResponsesPanel.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.coverPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(252)))), ((int)(((byte)(241)))));
            this.guna2Panel1.BorderRadius = 20;
            this.guna2Panel1.BorderThickness = 2;
            this.guna2Panel1.Controls.Add(this.numberResponsesPanel);
            this.guna2Panel1.Controls.Add(this.guna2Panel2);
            this.guna2Panel1.Controls.Add(this.coverPicture);
            this.guna2Panel1.Controls.Add(this.budgetLabel);
            this.guna2Panel1.Controls.Add(this.dateLabel);
            this.guna2Panel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Margin = new System.Windows.Forms.Padding(0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(766, 168);
            this.guna2Panel1.TabIndex = 0;
            this.guna2Panel1.Click += new System.EventHandler(this.guna2Panel1_Click);
            this.guna2Panel1.MouseLeave += new System.EventHandler(this.guna2Panel1_MouseLeave);
            this.guna2Panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.guna2Panel1_MouseMove);
            // 
            // numberResponsesPanel
            // 
            this.numberResponsesPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numberResponsesPanel.Controls.Add(this.ResponsesLabel);
            this.numberResponsesPanel.Location = new System.Drawing.Point(627, 80);
            this.numberResponsesPanel.Name = "numberResponsesPanel";
            this.numberResponsesPanel.Size = new System.Drawing.Size(124, 29);
            this.numberResponsesPanel.TabIndex = 5;
            // 
            // ResponsesLabel
            // 
            this.ResponsesLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ResponsesLabel.AutoSize = true;
            this.ResponsesLabel.BackColor = System.Drawing.Color.Transparent;
            this.ResponsesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ResponsesLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(252)))), ((int)(((byte)(241)))));
            this.ResponsesLabel.Location = new System.Drawing.Point(1, 6);
            this.ResponsesLabel.Name = "ResponsesLabel";
            this.ResponsesLabel.Size = new System.Drawing.Size(81, 18);
            this.ResponsesLabel.TabIndex = 4;
            this.ResponsesLabel.Text = "Откликов:";
            this.ResponsesLabel.Click += new System.EventHandler(this.ResponsesLabel_Click);
            this.ResponsesLabel.MouseLeave += new System.EventHandler(this.ResponsesLabel_MouseLeave);
            this.ResponsesLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ResponsesLabel_MouseMove);
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Panel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel2.Controls.Add(this.flowLayoutPanel1);
            this.guna2Panel2.Controls.Add(this.headLabel);
            this.guna2Panel2.Location = new System.Drawing.Point(109, 22);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(440, 131);
            this.guna2Panel2.TabIndex = 4;
            this.guna2Panel2.Click += new System.EventHandler(this.guna2Panel2_Click);
            this.guna2Panel2.MouseLeave += new System.EventHandler(this.guna2Panel2_MouseLeave);
            this.guna2Panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.guna2Panel2_MouseMove);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.bodyLabel);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(16, 43);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(424, 88);
            this.flowLayoutPanel1.TabIndex = 2;
            this.flowLayoutPanel1.Click += new System.EventHandler(this.flowLayoutPanel1_Click);
            this.flowLayoutPanel1.MouseLeave += new System.EventHandler(this.flowLayoutPanel1_MouseLeave);
            this.flowLayoutPanel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.flowLayoutPanel1_MouseMove);
            // 
            // bodyLabel
            // 
            this.bodyLabel.AutoSize = true;
            this.bodyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bodyLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(252)))), ((int)(((byte)(241)))));
            this.bodyLabel.Location = new System.Drawing.Point(3, 0);
            this.bodyLabel.Name = "bodyLabel";
            this.bodyLabel.Size = new System.Drawing.Size(41, 17);
            this.bodyLabel.TabIndex = 1;
            this.bodyLabel.Text = "Тело";
            this.bodyLabel.Click += new System.EventHandler(this.bodyLabel_Click);
            this.bodyLabel.MouseLeave += new System.EventHandler(this.bodyLabel_MouseLeave);
            this.bodyLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.bodyLabel_MouseMove);
            // 
            // headLabel
            // 
            this.headLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.headLabel.AutoSize = true;
            this.headLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.headLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(252)))), ((int)(((byte)(241)))));
            this.headLabel.Location = new System.Drawing.Point(11, 9);
            this.headLabel.Name = "headLabel";
            this.headLabel.Size = new System.Drawing.Size(108, 25);
            this.headLabel.TabIndex = 0;
            this.headLabel.Text = "Заголовок";
            this.headLabel.Click += new System.EventHandler(this.headLabel_Click);
            this.headLabel.MouseLeave += new System.EventHandler(this.headLabel_MouseLeave);
            this.headLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.headLabel_MouseMove);
            // 
            // coverPicture
            // 
            this.coverPicture.ImageRotate = 0F;
            this.coverPicture.Location = new System.Drawing.Point(18, 22);
            this.coverPicture.Name = "coverPicture";
            this.coverPicture.Size = new System.Drawing.Size(87, 87);
            this.coverPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.coverPicture.TabIndex = 2;
            this.coverPicture.TabStop = false;
            this.coverPicture.Click += new System.EventHandler(this.coverPicture_Click);
            this.coverPicture.MouseLeave += new System.EventHandler(this.coverPicture_MouseLeave);
            this.coverPicture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.coverPicture_MouseMove);
            // 
            // budgetLabel
            // 
            this.budgetLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.budgetLabel.AutoSize = true;
            this.budgetLabel.BackColor = System.Drawing.Color.Transparent;
            this.budgetLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.budgetLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(252)))), ((int)(((byte)(241)))));
            this.budgetLabel.Location = new System.Drawing.Point(659, 22);
            this.budgetLabel.Name = "budgetLabel";
            this.budgetLabel.Size = new System.Drawing.Size(64, 18);
            this.budgetLabel.TabIndex = 3;
            this.budgetLabel.Text = "Бюджет";
            this.budgetLabel.Click += new System.EventHandler(this.budgetLabel_Click);
            this.budgetLabel.MouseLeave += new System.EventHandler(this.budgetLabel_MouseLeave);
            this.budgetLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.budgetLabel_MouseMove);
            // 
            // dateLabel
            // 
            this.dateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dateLabel.AutoSize = true;
            this.dateLabel.BackColor = System.Drawing.Color.Transparent;
            this.dateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(252)))), ((int)(((byte)(241)))));
            this.dateLabel.Location = new System.Drawing.Point(668, 144);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(42, 17);
            this.dateLabel.TabIndex = 2;
            this.dateLabel.Text = "Дата";
            this.dateLabel.Click += new System.EventHandler(this.dateLabel_Click);
            this.dateLabel.MouseLeave += new System.EventHandler(this.dateLabel_MouseLeave);
            this.dateLabel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dateLabel_MouseMove);
            // 
            // JobsControls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(12)))), ((int)(((byte)(16)))));
            this.Controls.Add(this.guna2Panel1);
            this.Name = "JobsControls";
            this.Size = new System.Drawing.Size(766, 168);
            this.Load += new System.EventHandler(this.JobsControls_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.numberResponsesPanel.ResumeLayout(false);
            this.numberResponsesPanel.PerformLayout();
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.coverPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Label bodyLabel;
        private System.Windows.Forms.Label headLabel;
        private System.Windows.Forms.Label budgetLabel;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Guna.UI2.WinForms.Guna2PictureBox coverPicture;
        private Guna.UI2.WinForms.Guna2Panel numberResponsesPanel;
        private System.Windows.Forms.Label ResponsesLabel;
    }
}
