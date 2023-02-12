namespace autocorp
{
    partial class Form1
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.open_folder = new System.Windows.Forms.Button();
            this.label_index = new System.Windows.Forms.Label();
            this.lable_maxlist = new System.Windows.Forms.Label();
            this.btn_crop_image = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(214, 40);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(186, 394);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // open_folder
            // 
            this.open_folder.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.open_folder.Location = new System.Drawing.Point(12, 12);
            this.open_folder.Name = "open_folder";
            this.open_folder.Size = new System.Drawing.Size(196, 49);
            this.open_folder.TabIndex = 1;
            this.open_folder.Text = "เลือกโฟร์เดอร์รูป";
            this.open_folder.UseVisualStyleBackColor = true;
            this.open_folder.Click += new System.EventHandler(this.open_folder_image);
            // 
            // label_index
            // 
            this.label_index.AutoSize = true;
            this.label_index.Location = new System.Drawing.Point(214, 12);
            this.label_index.Name = "label_index";
            this.label_index.Size = new System.Drawing.Size(32, 13);
            this.label_index.TabIndex = 2;
            this.label_index.Text = "index";
            // 
            // lable_maxlist
            // 
            this.lable_maxlist.AutoSize = true;
            this.lable_maxlist.Location = new System.Drawing.Point(365, 12);
            this.lable_maxlist.Name = "lable_maxlist";
            this.lable_maxlist.Size = new System.Drawing.Size(38, 13);
            this.lable_maxlist.TabIndex = 3;
            this.lable_maxlist.Text = "maxlist";
            // 
            // btn_crop_image
            // 
            this.btn_crop_image.Location = new System.Drawing.Point(12, 381);
            this.btn_crop_image.Name = "btn_crop_image";
            this.btn_crop_image.Size = new System.Drawing.Size(196, 53);
            this.btn_crop_image.TabIndex = 4;
            this.btn_crop_image.Text = "CropImage";
            this.btn_crop_image.UseVisualStyleBackColor = true;
            this.btn_crop_image.Click += new System.EventHandler(this.btn_crop_image_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 446);
            this.Controls.Add(this.btn_crop_image);
            this.Controls.Add(this.lable_maxlist);
            this.Controls.Add(this.label_index);
            this.Controls.Add(this.open_folder);
            this.Controls.Add(this.listBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button open_folder;
        private System.Windows.Forms.Label label_index;
        private System.Windows.Forms.Label lable_maxlist;
        private System.Windows.Forms.Button btn_crop_image;
    }
}

