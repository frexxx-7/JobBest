namespace JobBest.Controls
{
    partial class ChatsControls
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatsControls));
            this.avatarPicture = new Guna.UI2.WinForms.Guna2PictureBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.dateLabel = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.lastMessagePanel = new Guna.UI2.WinForms.Guna2Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lastMessageContentLabel = new System.Windows.Forms.Label();
            this.lastMessageUserLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.avatarPicture)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            this.lastMessagePanel.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // avatarPicture
            // 
            this.avatarPicture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.avatarPicture.BackColor = System.Drawing.Color.Transparent;
            this.avatarPicture.BorderRadius = 33;
            this.avatarPicture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.avatarPicture.Image = ((System.Drawing.Image)(resources.GetObject("avatarPicture.Image")));
            this.avatarPicture.ImageRotate = 0F;
            this.avatarPicture.Location = new System.Drawing.Point(20, 16);
            this.avatarPicture.Margin = new System.Windows.Forms.Padding(4);
            this.avatarPicture.Name = "avatarPicture";
            this.avatarPicture.Size = new System.Drawing.Size(89, 82);
            this.avatarPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.avatarPicture.TabIndex = 7;
            this.avatarPicture.TabStop = false;
            this.avatarPicture.Click += new System.EventHandler(this.avatarPicture_Click);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(252)))), ((int)(((byte)(241)))));
            this.nameLabel.Location = new System.Drawing.Point(131, 30);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(66, 29);
            this.nameLabel.TabIndex = 8;
            this.nameLabel.Text = "Имя";
            this.nameLabel.Click += new System.EventHandler(this.nameLabel_Click);
            // 
            // dateLabel
            // 
            this.dateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateLabel.AutoSize = true;
            this.dateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(252)))), ((int)(((byte)(241)))));
            this.dateLabel.Location = new System.Drawing.Point(481, 12);
            this.dateLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(135, 20);
            this.dateLabel.TabIndex = 10;
            this.dateLabel.Text = "10:00 16.02.2023";
            this.dateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.dateLabel.Click += new System.EventHandler(this.label3_Click);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Panel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(252)))), ((int)(((byte)(241)))));
            this.guna2Panel1.BorderRadius = 20;
            this.guna2Panel1.BorderThickness = 2;
            this.guna2Panel1.Controls.Add(this.lastMessagePanel);
            this.guna2Panel1.Controls.Add(this.dateLabel);
            this.guna2Panel1.Controls.Add(this.nameLabel);
            this.guna2Panel1.Controls.Add(this.avatarPicture);
            this.guna2Panel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Margin = new System.Windows.Forms.Padding(4);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(668, 118);
            this.guna2Panel1.TabIndex = 11;
            this.guna2Panel1.Click += new System.EventHandler(this.guna2Panel1_Click);
            // 
            // lastMessagePanel
            // 
            this.lastMessagePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lastMessagePanel.Controls.Add(this.flowLayoutPanel1);
            this.lastMessagePanel.Controls.Add(this.lastMessageUserLabel);
            this.lastMessagePanel.Location = new System.Drawing.Point(129, 70);
            this.lastMessagePanel.Margin = new System.Windows.Forms.Padding(4);
            this.lastMessagePanel.Name = "lastMessagePanel";
            this.lastMessagePanel.Size = new System.Drawing.Size(519, 31);
            this.lastMessagePanel.TabIndex = 9;
            this.lastMessagePanel.Click += new System.EventHandler(this.lastMessagePanel_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.lastMessageContentLabel);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(74, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(445, 31);
            this.flowLayoutPanel1.TabIndex = 11;
            this.flowLayoutPanel1.Click += new System.EventHandler(this.flowLayoutPanel1_Click);
            // 
            // lastMessageContentLabel
            // 
            this.lastMessageContentLabel.AutoSize = true;
            this.lastMessageContentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lastMessageContentLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(162)))), ((int)(((byte)(158)))));
            this.lastMessageContentLabel.Location = new System.Drawing.Point(4, 0);
            this.lastMessageContentLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lastMessageContentLabel.MaximumSize = new System.Drawing.Size(267, 0);
            this.lastMessageContentLabel.Name = "lastMessageContentLabel";
            this.lastMessageContentLabel.Size = new System.Drawing.Size(166, 24);
            this.lastMessageContentLabel.TabIndex = 10;
            this.lastMessageContentLabel.Text = "Текст сообщения";
            this.lastMessageContentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lastMessageContentLabel.Click += new System.EventHandler(this.lastMessageContentLabel_Click);
            // 
            // lastMessageUserLabel
            // 
            this.lastMessageUserLabel.AutoSize = true;
            this.lastMessageUserLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.lastMessageUserLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lastMessageUserLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(252)))), ((int)(((byte)(241)))));
            this.lastMessageUserLabel.Location = new System.Drawing.Point(0, 0);
            this.lastMessageUserLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lastMessageUserLabel.Name = "lastMessageUserLabel";
            this.lastMessageUserLabel.Size = new System.Drawing.Size(74, 25);
            this.lastMessageUserLabel.TabIndex = 9;
            this.lastMessageUserLabel.Text = "Логин:";
            this.lastMessageUserLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lastMessageUserLabel.Click += new System.EventHandler(this.lastMessageUserLabel_Click);
            // 
            // ChatsControls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(12)))), ((int)(((byte)(16)))));
            this.Controls.Add(this.guna2Panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ChatsControls";
            this.Size = new System.Drawing.Size(668, 118);
            this.Load += new System.EventHandler(this.ChatsControls_Load);
            ((System.ComponentModel.ISupportInitialize)(this.avatarPicture)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.lastMessagePanel.ResumeLayout(false);
            this.lastMessagePanel.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2PictureBox avatarPicture;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label dateLabel;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel lastMessagePanel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lastMessageContentLabel;
        private System.Windows.Forms.Label lastMessageUserLabel;
    }
}
