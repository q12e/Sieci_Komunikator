namespace DSIKKomunikator
{
    partial class Main_window
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_window));
            this.MsgBox = new System.Windows.Forms.TextBox();
            this.button_send = new System.Windows.Forms.Button();
            this.ChatBox = new System.Windows.Forms.TextBox();
            this.button_image = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // MsgBox
            // 
            this.MsgBox.Location = new System.Drawing.Point(12, 352);
            this.MsgBox.MaximumSize = new System.Drawing.Size(500, 50);
            this.MsgBox.MinimumSize = new System.Drawing.Size(400, 10);
            this.MsgBox.Name = "MsgBox";
            this.MsgBox.Size = new System.Drawing.Size(475, 20);
            this.MsgBox.TabIndex = 2;
            this.MsgBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MsgBox_KeyDown);
            // 
            // button_send
            // 
            this.button_send.Location = new System.Drawing.Point(523, 352);
            this.button_send.Name = "button_send";
            this.button_send.Size = new System.Drawing.Size(75, 23);
            this.button_send.TabIndex = 3;
            this.button_send.Text = "Wyślij";
            this.button_send.UseVisualStyleBackColor = true;
            this.button_send.Click += new System.EventHandler(this.button1_Click);
            // 
            // ChatBox
            // 
            this.ChatBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ChatBox.Location = new System.Drawing.Point(12, 12);
            this.ChatBox.MaximumSize = new System.Drawing.Size(586, 345);
            this.ChatBox.MinimumSize = new System.Drawing.Size(400, 300);
            this.ChatBox.Multiline = true;
            this.ChatBox.Name = "ChatBox";
            this.ChatBox.ReadOnly = true;
            this.ChatBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ChatBox.Size = new System.Drawing.Size(409, 323);
            this.ChatBox.TabIndex = 4;
            // 
            // button_image
            // 
            this.button_image.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.button_image.Image = ((System.Drawing.Image)(resources.GetObject("button_image.Image")));
            this.button_image.Location = new System.Drawing.Point(494, 352);
            this.button_image.Name = "button_image";
            this.button_image.Size = new System.Drawing.Size(23, 23);
            this.button_image.TabIndex = 5;
            this.button_image.UseVisualStyleBackColor = true;
            this.button_image.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(427, 26);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(171, 174);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox.TabIndex = 8;
            this.pictureBox.TabStop = false;
            // 
            // Main_window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(610, 398);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.button_image);
            this.Controls.Add(this.ChatBox);
            this.Controls.Add(this.button_send);
            this.Controls.Add(this.MsgBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main_window";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Komunikator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_send;
        private System.Windows.Forms.TextBox ChatBox;
        private System.Windows.Forms.TextBox MsgBox;
        private System.Windows.Forms.Button button_image;
        private System.Windows.Forms.PictureBox pictureBox;
    }
}