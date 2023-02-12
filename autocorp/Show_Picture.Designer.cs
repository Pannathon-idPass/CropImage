namespace autocorp
{
    partial class Show_Picture
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
            this.picturebox_1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_1)).BeginInit();
            this.SuspendLayout();
            // 
            // picturebox_1
            // 
            this.picturebox_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picturebox_1.Location = new System.Drawing.Point(0, 0);
            this.picturebox_1.Name = "picturebox_1";
            this.picturebox_1.Size = new System.Drawing.Size(530, 403);
            this.picturebox_1.TabIndex = 0;
            this.picturebox_1.TabStop = false;
            // 
            // Show_Picture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 403);
            this.Controls.Add(this.picturebox_1);
            this.Name = "Show_Picture";
            this.Text = "Show_Picture";
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picturebox_1;
    }
}