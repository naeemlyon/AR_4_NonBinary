namespace AR_4_NonBinary
{
    partial class frm_Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Main));
            this.btn_Discretize = new System.Windows.Forms.Button();
            this.txt_Display = new System.Windows.Forms.TextBox();
            this.btn_Write_FI = new System.Windows.Forms.Button();
            this.btn_Digitize_Text_Matrix = new System.Windows.Forms.Button();
            this.tbx_Threshold = new System.Windows.Forms.TextBox();
            this.cbo_Measure = new System.Windows.Forms.ComboBox();
            this.btn_Simplify_AR = new System.Windows.Forms.Button();
            this.btn_Simplify_FI = new System.Windows.Forms.Button();
            this.btn_Apply_Ordering = new System.Windows.Forms.Button();
            this.btn_GO = new System.Windows.Forms.Button();
            this.btn_Generate_FI = new System.Windows.Forms.Button();
            this.btn_Generate_AR = new System.Windows.Forms.Button();
            this.btn_Load_FI = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbx_FI_Threshold = new System.Windows.Forms.TextBox();
            this.btn_DataImport_at_FixedLength = new System.Windows.Forms.Button();
            this.btn_Combine_All_File = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Discretize
            // 
            this.btn_Discretize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Discretize.ForeColor = System.Drawing.Color.SteelBlue;
            this.btn_Discretize.Location = new System.Drawing.Point(20, 18);
            this.btn_Discretize.Name = "btn_Discretize";
            this.btn_Discretize.Size = new System.Drawing.Size(191, 34);
            this.btn_Discretize.TabIndex = 108;
            this.btn_Discretize.Text = "Discretize Continuous Feature";
            this.btn_Discretize.UseVisualStyleBackColor = true;
            this.btn_Discretize.Click += new System.EventHandler(this.btn_Discretize_Click);
            // 
            // txt_Display
            // 
            this.txt_Display.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Display.ForeColor = System.Drawing.Color.MediumBlue;
            this.txt_Display.Location = new System.Drawing.Point(4, 312);
            this.txt_Display.Multiline = true;
            this.txt_Display.Name = "txt_Display";
            this.txt_Display.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_Display.Size = new System.Drawing.Size(508, 48);
            this.txt_Display.TabIndex = 109;
            // 
            // btn_Write_FI
            // 
            this.btn_Write_FI.BackColor = System.Drawing.Color.SteelBlue;
            this.btn_Write_FI.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Write_FI.ForeColor = System.Drawing.Color.LawnGreen;
            this.btn_Write_FI.Location = new System.Drawing.Point(294, 112);
            this.btn_Write_FI.Name = "btn_Write_FI";
            this.btn_Write_FI.Size = new System.Drawing.Size(184, 34);
            this.btn_Write_FI.TabIndex = 112;
            this.btn_Write_FI.Text = "Write Frequent Items";
            this.btn_Write_FI.UseVisualStyleBackColor = false;
            this.btn_Write_FI.Click += new System.EventHandler(this.btn_Write_FI_Click);
            // 
            // btn_Digitize_Text_Matrix
            // 
            this.btn_Digitize_Text_Matrix.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Digitize_Text_Matrix.ForeColor = System.Drawing.Color.SteelBlue;
            this.btn_Digitize_Text_Matrix.Location = new System.Drawing.Point(293, 18);
            this.btn_Digitize_Text_Matrix.Name = "btn_Digitize_Text_Matrix";
            this.btn_Digitize_Text_Matrix.Size = new System.Drawing.Size(185, 34);
            this.btn_Digitize_Text_Matrix.TabIndex = 113;
            this.btn_Digitize_Text_Matrix.Text = "Digitize  Dataset";
            this.btn_Digitize_Text_Matrix.UseVisualStyleBackColor = true;
            this.btn_Digitize_Text_Matrix.Click += new System.EventHandler(this.btn_Digitize_Text_Matrix_Click);
            // 
            // tbx_Threshold
            // 
            this.tbx_Threshold.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_Threshold.Location = new System.Drawing.Point(141, 162);
            this.tbx_Threshold.Name = "tbx_Threshold";
            this.tbx_Threshold.Size = new System.Drawing.Size(70, 20);
            this.tbx_Threshold.TabIndex = 116;
            this.tbx_Threshold.Text = "0.0";
            // 
            // cbo_Measure
            // 
            this.cbo_Measure.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_Measure.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_Measure.ForeColor = System.Drawing.Color.IndianRed;
            this.cbo_Measure.FormattingEnabled = true;
            this.cbo_Measure.Items.AddRange(new object[] {
            "Support",
            "Confidence",
            "Conviction",
            "Leverage",
            "AllConfidence"});
            this.cbo_Measure.Location = new System.Drawing.Point(20, 161);
            this.cbo_Measure.Name = "cbo_Measure";
            this.cbo_Measure.Size = new System.Drawing.Size(96, 21);
            this.cbo_Measure.TabIndex = 117;
            // 
            // btn_Simplify_AR
            // 
            this.btn_Simplify_AR.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Simplify_AR.ForeColor = System.Drawing.Color.Red;
            this.btn_Simplify_AR.Location = new System.Drawing.Point(293, 214);
            this.btn_Simplify_AR.Name = "btn_Simplify_AR";
            this.btn_Simplify_AR.Size = new System.Drawing.Size(185, 34);
            this.btn_Simplify_AR.TabIndex = 118;
            this.btn_Simplify_AR.Text = "Simplify_AR";
            this.btn_Simplify_AR.UseVisualStyleBackColor = true;
            this.btn_Simplify_AR.Click += new System.EventHandler(this.btn_Simplify_AR_Click);
            // 
            // btn_Simplify_FI
            // 
            this.btn_Simplify_FI.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Simplify_FI.ForeColor = System.Drawing.Color.Red;
            this.btn_Simplify_FI.Location = new System.Drawing.Point(20, 216);
            this.btn_Simplify_FI.Name = "btn_Simplify_FI";
            this.btn_Simplify_FI.Size = new System.Drawing.Size(191, 32);
            this.btn_Simplify_FI.TabIndex = 119;
            this.btn_Simplify_FI.Text = "Simplify Freq. Items";
            this.btn_Simplify_FI.UseVisualStyleBackColor = true;
            this.btn_Simplify_FI.Click += new System.EventHandler(this.btn_Simplify_FI_Click);
            // 
            // btn_Apply_Ordering
            // 
            this.btn_Apply_Ordering.BackColor = System.Drawing.Color.Maroon;
            this.btn_Apply_Ordering.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Apply_Ordering.ForeColor = System.Drawing.Color.Yellow;
            this.btn_Apply_Ordering.Location = new System.Drawing.Point(20, 268);
            this.btn_Apply_Ordering.Name = "btn_Apply_Ordering";
            this.btn_Apply_Ordering.Size = new System.Drawing.Size(185, 38);
            this.btn_Apply_Ordering.TabIndex = 120;
            this.btn_Apply_Ordering.Text = "Apply Ordering Scheme";
            this.btn_Apply_Ordering.UseVisualStyleBackColor = false;
            this.btn_Apply_Ordering.Click += new System.EventHandler(this.btn_Apply_Ordering_Click);
            // 
            // btn_GO
            // 
            this.btn_GO.BackColor = System.Drawing.Color.Goldenrod;
            this.btn_GO.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_GO.ForeColor = System.Drawing.Color.MediumBlue;
            this.btn_GO.Location = new System.Drawing.Point(292, 267);
            this.btn_GO.Name = "btn_GO";
            this.btn_GO.Size = new System.Drawing.Size(185, 39);
            this.btn_GO.TabIndex = 121;
            this.btn_GO.Text = "GO";
            this.btn_GO.UseVisualStyleBackColor = false;
            this.btn_GO.Click += new System.EventHandler(this.btn_GO_Click);
            // 
            // btn_Generate_FI
            // 
            this.btn_Generate_FI.BackColor = System.Drawing.Color.SteelBlue;
            this.btn_Generate_FI.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Generate_FI.ForeColor = System.Drawing.Color.LawnGreen;
            this.btn_Generate_FI.Location = new System.Drawing.Point(20, 65);
            this.btn_Generate_FI.Name = "btn_Generate_FI";
            this.btn_Generate_FI.Size = new System.Drawing.Size(191, 32);
            this.btn_Generate_FI.TabIndex = 122;
            this.btn_Generate_FI.Text = "Generate FI";
            this.btn_Generate_FI.UseVisualStyleBackColor = false;
            this.btn_Generate_FI.Click += new System.EventHandler(this.btn_Generate_FI_Click);
            // 
            // btn_Generate_AR
            // 
            this.btn_Generate_AR.BackColor = System.Drawing.Color.Plum;
            this.btn_Generate_AR.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Generate_AR.ForeColor = System.Drawing.Color.Aqua;
            this.btn_Generate_AR.Location = new System.Drawing.Point(293, 164);
            this.btn_Generate_AR.Name = "btn_Generate_AR";
            this.btn_Generate_AR.Size = new System.Drawing.Size(184, 31);
            this.btn_Generate_AR.TabIndex = 123;
            this.btn_Generate_AR.Text = "Generate AR";
            this.btn_Generate_AR.UseVisualStyleBackColor = false;
            this.btn_Generate_AR.Click += new System.EventHandler(this.btn_Generate_AR_Click);
            // 
            // btn_Load_FI
            // 
            this.btn_Load_FI.BackColor = System.Drawing.Color.SteelBlue;
            this.btn_Load_FI.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Load_FI.ForeColor = System.Drawing.Color.LawnGreen;
            this.btn_Load_FI.Location = new System.Drawing.Point(292, 65);
            this.btn_Load_FI.Name = "btn_Load_FI";
            this.btn_Load_FI.Size = new System.Drawing.Size(185, 32);
            this.btn_Load_FI.TabIndex = 124;
            this.btn_Load_FI.Text = "Load FI";
            this.btn_Load_FI.UseVisualStyleBackColor = false;
            this.btn_Load_FI.Click += new System.EventHandler(this.btn_Load_FI_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 125;
            this.label1.Text = "FI Threshold";
            // 
            // tbx_FI_Threshold
            // 
            this.tbx_FI_Threshold.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_FI_Threshold.Location = new System.Drawing.Point(151, 103);
            this.tbx_FI_Threshold.Name = "tbx_FI_Threshold";
            this.tbx_FI_Threshold.Size = new System.Drawing.Size(54, 20);
            this.tbx_FI_Threshold.TabIndex = 126;
            this.tbx_FI_Threshold.Text = "5";
            // 
            // btn_DataImport_at_FixedLength
            // 
            this.btn_DataImport_at_FixedLength.Location = new System.Drawing.Point(298, 375);
            this.btn_DataImport_at_FixedLength.Name = "btn_DataImport_at_FixedLength";
            this.btn_DataImport_at_FixedLength.Size = new System.Drawing.Size(179, 36);
            this.btn_DataImport_at_FixedLength.TabIndex = 127;
            this.btn_DataImport_at_FixedLength.Text = "DataImport@FixedLength";
            this.btn_DataImport_at_FixedLength.UseVisualStyleBackColor = true;
            this.btn_DataImport_at_FixedLength.Click += new System.EventHandler(this.btn_DataImport_at_FixedLength_Click);
            // 
            // btn_Combine_All_File
            // 
            this.btn_Combine_All_File.Location = new System.Drawing.Point(20, 375);
            this.btn_Combine_All_File.Name = "btn_Combine_All_File";
            this.btn_Combine_All_File.Size = new System.Drawing.Size(185, 34);
            this.btn_Combine_All_File.TabIndex = 128;
            this.btn_Combine_All_File.Text = "Combine_All_File";
            this.btn_Combine_All_File.UseVisualStyleBackColor = true;
            this.btn_Combine_All_File.Click += new System.EventHandler(this.btn_Combine_All_File_Click);
            // 
            // frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 427);
            this.Controls.Add(this.btn_Combine_All_File);
            this.Controls.Add(this.btn_DataImport_at_FixedLength);
            this.Controls.Add(this.tbx_FI_Threshold);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Load_FI);
            this.Controls.Add(this.btn_Generate_AR);
            this.Controls.Add(this.btn_Generate_FI);
            this.Controls.Add(this.btn_GO);
            this.Controls.Add(this.btn_Apply_Ordering);
            this.Controls.Add(this.btn_Simplify_FI);
            this.Controls.Add(this.btn_Simplify_AR);
            this.Controls.Add(this.cbo_Measure);
            this.Controls.Add(this.tbx_Threshold);
            this.Controls.Add(this.btn_Digitize_Text_Matrix);
            this.Controls.Add(this.btn_Write_FI);
            this.Controls.Add(this.txt_Display);
            this.Controls.Add(this.btn_Discretize);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Association Rules for Naive Bayesian Belief Network";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Discretize;
        private System.Windows.Forms.TextBox txt_Display;
        private System.Windows.Forms.Button btn_Write_FI;
        private System.Windows.Forms.Button btn_Digitize_Text_Matrix;
        private System.Windows.Forms.TextBox tbx_Threshold;
        private System.Windows.Forms.ComboBox cbo_Measure;
        private System.Windows.Forms.Button btn_Simplify_AR;
        private System.Windows.Forms.Button btn_Simplify_FI;
        private System.Windows.Forms.Button btn_Apply_Ordering;
        private System.Windows.Forms.Button btn_GO;
        private System.Windows.Forms.Button btn_Generate_FI;
        private System.Windows.Forms.Button btn_Generate_AR;
        private System.Windows.Forms.Button btn_Load_FI;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbx_FI_Threshold;
        private System.Windows.Forms.Button btn_DataImport_at_FixedLength;
        private System.Windows.Forms.Button btn_Combine_All_File;
    }
}

