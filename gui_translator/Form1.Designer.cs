namespace gui_translator
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
            this.lang_2_box = new System.Windows.Forms.TextBox();
            this.lang_1_box = new System.Windows.Forms.TextBox();
            this.lang_1_name_label = new System.Windows.Forms.Label();
            this.lang_2_name_label = new System.Windows.Forms.Label();
            this.import_csv_button = new System.Windows.Forms.Button();
            this.import_ftl_button = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // lang_2_box
            // 
            this.lang_2_box.Location = new System.Drawing.Point(425, 88);
            this.lang_2_box.Multiline = true;
            this.lang_2_box.Name = "lang_2_box";
            this.lang_2_box.Size = new System.Drawing.Size(363, 350);
            this.lang_2_box.TabIndex = 0;
            this.lang_2_box.TextChanged += new System.EventHandler(this.lang_2_box_TextChanged_1);
            // 
            // lang_1_box
            // 
            this.lang_1_box.Location = new System.Drawing.Point(12, 88);
            this.lang_1_box.Multiline = true;
            this.lang_1_box.Name = "lang_1_box";
            this.lang_1_box.Size = new System.Drawing.Size(363, 350);
            this.lang_1_box.TabIndex = 1;
            this.lang_1_box.TextChanged += new System.EventHandler(this.lang_1_box_TextChanged);
            // 
            // lang_1_name_label
            // 
            this.lang_1_name_label.AutoSize = true;
            this.lang_1_name_label.Location = new System.Drawing.Point(12, 65);
            this.lang_1_name_label.Name = "lang_1_name_label";
            this.lang_1_name_label.Size = new System.Drawing.Size(59, 20);
            this.lang_1_name_label.TabIndex = 2;
            this.lang_1_name_label.Text = "english";
            // 
            // lang_2_name_label
            // 
            this.lang_2_name_label.AutoSize = true;
            this.lang_2_name_label.Location = new System.Drawing.Point(421, 65);
            this.lang_2_name_label.Name = "lang_2_name_label";
            this.lang_2_name_label.Size = new System.Drawing.Size(86, 20);
            this.lang_2_name_label.TabIndex = 3;
            this.lang_2_name_label.Text = "not english";
            // 
            // import_csv_button
            // 
            this.import_csv_button.Location = new System.Drawing.Point(12, 12);
            this.import_csv_button.Name = "import_csv_button";
            this.import_csv_button.Size = new System.Drawing.Size(75, 34);
            this.import_csv_button.TabIndex = 4;
            this.import_csv_button.Text = "CSV";
            this.import_csv_button.UseVisualStyleBackColor = true;
            this.import_csv_button.Click += new System.EventHandler(this.import_csv_button_Click);
            // 
            // import_ftl_button
            // 
            this.import_ftl_button.Location = new System.Drawing.Point(93, 12);
            this.import_ftl_button.Name = "import_ftl_button";
            this.import_ftl_button.Size = new System.Drawing.Size(75, 34);
            this.import_ftl_button.TabIndex = 5;
            this.import_ftl_button.Text = "FTL";
            this.import_ftl_button.UseVisualStyleBackColor = true;
            this.import_ftl_button.Click += new System.EventHandler(this.import_ftl_button_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.import_ftl_button);
            this.Controls.Add(this.import_csv_button);
            this.Controls.Add(this.lang_2_name_label);
            this.Controls.Add(this.lang_1_name_label);
            this.Controls.Add(this.lang_1_box);
            this.Controls.Add(this.lang_2_box);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox lang_2_box;
        private System.Windows.Forms.TextBox lang_1_box;
        private System.Windows.Forms.Label lang_1_name_label;
        private System.Windows.Forms.Label lang_2_name_label;
        private System.Windows.Forms.Button import_csv_button;
        private System.Windows.Forms.Button import_ftl_button;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

