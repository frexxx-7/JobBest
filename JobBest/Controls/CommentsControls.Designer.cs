namespace JobBest.Controls
{
    partial class CommentsControls
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommentsControls));
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.commentPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.commentsContentLabel = new System.Windows.Forms.Label();
            this.dateLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.avatarPicture = new Guna.UI2.WinForms.Guna2PictureBox();
            this.starPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.starIcon5 = new FontAwesome.Sharp.IconPictureBox();
            this.starIcon4 = new FontAwesome.Sharp.IconPictureBox();
            this.starIcon3 = new FontAwesome.Sharp.IconPictureBox();
            this.starIcon2 = new FontAwesome.Sharp.IconPictureBox();
            this.starIcon1 = new FontAwesome.Sharp.IconPictureBox();
            this.guna2Panel1.SuspendLayout();
            this.commentPanel.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.avatarPicture)).BeginInit();
            this.starPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.starIcon5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.starIcon4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.starIcon3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.starIcon2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.starIcon1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(252)))), ((int)(((byte)(241)))));
            this.guna2Panel1.BorderRadius = 20;
            this.guna2Panel1.BorderThickness = 2;
            this.guna2Panel1.Controls.Add(this.starPanel);
            this.guna2Panel1.Controls.Add(this.commentPanel);
            this.guna2Panel1.Controls.Add(this.dateLabel);
            this.guna2Panel1.Controls.Add(this.nameLabel);
            this.guna2Panel1.Controls.Add(this.avatarPicture);
            this.guna2Panel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Margin = new System.Windows.Forms.Padding(4);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1076, 169);
            this.guna2Panel1.TabIndex = 12;
            // 
            // commentPanel
            // 
            this.commentPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.commentPanel.Controls.Add(this.flowLayoutPanel1);
            this.commentPanel.Cursor = System.Windows.Forms.Cursors.Default;
            this.commentPanel.Location = new System.Drawing.Point(181, 83);
            this.commentPanel.Margin = new System.Windows.Forms.Padding(4);
            this.commentPanel.Name = "commentPanel";
            this.commentPanel.Size = new System.Drawing.Size(875, 69);
            this.commentPanel.TabIndex = 9;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.commentsContentLabel);
            this.flowLayoutPanel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(875, 69);
            this.flowLayoutPanel1.TabIndex = 11;
            // 
            // commentsContentLabel
            // 
            this.commentsContentLabel.AutoSize = true;
            this.commentsContentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.commentsContentLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(162)))), ((int)(((byte)(158)))));
            this.commentsContentLabel.Location = new System.Drawing.Point(4, 0);
            this.commentsContentLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.commentsContentLabel.MaximumSize = new System.Drawing.Size(267, 0);
            this.commentsContentLabel.Name = "commentsContentLabel";
            this.commentsContentLabel.Size = new System.Drawing.Size(166, 24);
            this.commentsContentLabel.TabIndex = 10;
            this.commentsContentLabel.Text = "Текст сообщения";
            this.commentsContentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dateLabel
            // 
            this.dateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateLabel.AutoSize = true;
            this.dateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(252)))), ((int)(((byte)(241)))));
            this.dateLabel.Location = new System.Drawing.Point(889, 12);
            this.dateLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(135, 20);
            this.dateLabel.TabIndex = 10;
            this.dateLabel.Text = "10:00 16.02.2023";
            this.dateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(252)))), ((int)(((byte)(241)))));
            this.nameLabel.Location = new System.Drawing.Point(176, 19);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(66, 29);
            this.nameLabel.TabIndex = 8;
            this.nameLabel.Text = "Имя";
            this.nameLabel.Click += new System.EventHandler(this.nameLabel_Click);
            // 
            // avatarPicture
            // 
            this.avatarPicture.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.avatarPicture.AutoRoundedCorners = true;
            this.avatarPicture.BackColor = System.Drawing.Color.Transparent;
            this.avatarPicture.BorderRadius = 65;
            this.avatarPicture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.avatarPicture.Image = ((System.Drawing.Image)(resources.GetObject("avatarPicture.Image")));
            this.avatarPicture.ImageRotate = 0F;
            this.avatarPicture.Location = new System.Drawing.Point(18, 19);
            this.avatarPicture.Margin = new System.Windows.Forms.Padding(4);
            this.avatarPicture.Name = "avatarPicture";
            this.avatarPicture.Size = new System.Drawing.Size(133, 133);
            this.avatarPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.avatarPicture.TabIndex = 7;
            this.avatarPicture.TabStop = false;
            this.avatarPicture.Click += new System.EventHandler(this.avatarPicture_Click);
            // 
            // starPanel
            // 
            this.starPanel.Controls.Add(this.starIcon5);
            this.starPanel.Controls.Add(this.starIcon4);
            this.starPanel.Controls.Add(this.starIcon3);
            this.starPanel.Controls.Add(this.starIcon2);
            this.starPanel.Controls.Add(this.starIcon1);
            this.starPanel.Location = new System.Drawing.Point(181, 50);
            this.starPanel.Name = "starPanel";
            this.starPanel.Size = new System.Drawing.Size(308, 32);
            this.starPanel.TabIndex = 15;
            // 
            // starIcon5
            // 
            this.starIcon5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(12)))), ((int)(((byte)(16)))));
            this.starIcon5.Cursor = System.Windows.Forms.Cursors.Default;
            this.starIcon5.Dock = System.Windows.Forms.DockStyle.Left;
            this.starIcon5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(252)))), ((int)(((byte)(241)))));
            this.starIcon5.IconChar = FontAwesome.Sharp.IconChar.Star;
            this.starIcon5.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(252)))), ((int)(((byte)(241)))));
            this.starIcon5.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.starIcon5.Location = new System.Drawing.Point(128, 0);
            this.starIcon5.Name = "starIcon5";
            this.starIcon5.Size = new System.Drawing.Size(32, 32);
            this.starIcon5.TabIndex = 4;
            this.starIcon5.TabStop = false;
            // 
            // starIcon4
            // 
            this.starIcon4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(12)))), ((int)(((byte)(16)))));
            this.starIcon4.Cursor = System.Windows.Forms.Cursors.Default;
            this.starIcon4.Dock = System.Windows.Forms.DockStyle.Left;
            this.starIcon4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(252)))), ((int)(((byte)(241)))));
            this.starIcon4.IconChar = FontAwesome.Sharp.IconChar.Star;
            this.starIcon4.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(252)))), ((int)(((byte)(241)))));
            this.starIcon4.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.starIcon4.Location = new System.Drawing.Point(96, 0);
            this.starIcon4.Name = "starIcon4";
            this.starIcon4.Size = new System.Drawing.Size(32, 32);
            this.starIcon4.TabIndex = 3;
            this.starIcon4.TabStop = false;
            // 
            // starIcon3
            // 
            this.starIcon3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(12)))), ((int)(((byte)(16)))));
            this.starIcon3.Cursor = System.Windows.Forms.Cursors.Default;
            this.starIcon3.Dock = System.Windows.Forms.DockStyle.Left;
            this.starIcon3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(252)))), ((int)(((byte)(241)))));
            this.starIcon3.IconChar = FontAwesome.Sharp.IconChar.Star;
            this.starIcon3.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(252)))), ((int)(((byte)(241)))));
            this.starIcon3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.starIcon3.Location = new System.Drawing.Point(64, 0);
            this.starIcon3.Name = "starIcon3";
            this.starIcon3.Size = new System.Drawing.Size(32, 32);
            this.starIcon3.TabIndex = 2;
            this.starIcon3.TabStop = false;
            // 
            // starIcon2
            // 
            this.starIcon2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(12)))), ((int)(((byte)(16)))));
            this.starIcon2.Cursor = System.Windows.Forms.Cursors.Default;
            this.starIcon2.Dock = System.Windows.Forms.DockStyle.Left;
            this.starIcon2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(252)))), ((int)(((byte)(241)))));
            this.starIcon2.IconChar = FontAwesome.Sharp.IconChar.Star;
            this.starIcon2.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(252)))), ((int)(((byte)(241)))));
            this.starIcon2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.starIcon2.Location = new System.Drawing.Point(32, 0);
            this.starIcon2.Name = "starIcon2";
            this.starIcon2.Size = new System.Drawing.Size(32, 32);
            this.starIcon2.TabIndex = 1;
            this.starIcon2.TabStop = false;
            this.starIcon2.Tag = "";
            // 
            // starIcon1
            // 
            this.starIcon1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(12)))), ((int)(((byte)(16)))));
            this.starIcon1.Cursor = System.Windows.Forms.Cursors.Default;
            this.starIcon1.Dock = System.Windows.Forms.DockStyle.Left;
            this.starIcon1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(252)))), ((int)(((byte)(241)))));
            this.starIcon1.IconChar = FontAwesome.Sharp.IconChar.Star;
            this.starIcon1.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(252)))), ((int)(((byte)(241)))));
            this.starIcon1.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.starIcon1.Location = new System.Drawing.Point(0, 0);
            this.starIcon1.Name = "starIcon1";
            this.starIcon1.Size = new System.Drawing.Size(32, 32);
            this.starIcon1.TabIndex = 0;
            this.starIcon1.TabStop = false;
            this.starIcon1.Tag = "";
            // 
            // CommentsControls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(12)))), ((int)(((byte)(16)))));
            this.Controls.Add(this.guna2Panel1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "CommentsControls";
            this.Size = new System.Drawing.Size(1076, 169);
            this.Load += new System.EventHandler(this.CommentsControls_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.commentPanel.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.avatarPicture)).EndInit();
            this.starPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.starIcon5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.starIcon4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.starIcon3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.starIcon2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.starIcon1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel commentPanel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label commentsContentLabel;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Label nameLabel;
        private Guna.UI2.WinForms.Guna2PictureBox avatarPicture;
        private Guna.UI2.WinForms.Guna2Panel starPanel;
        private FontAwesome.Sharp.IconPictureBox starIcon5;
        private FontAwesome.Sharp.IconPictureBox starIcon4;
        private FontAwesome.Sharp.IconPictureBox starIcon3;
        private FontAwesome.Sharp.IconPictureBox starIcon2;
        private FontAwesome.Sharp.IconPictureBox starIcon1;
    }
}
