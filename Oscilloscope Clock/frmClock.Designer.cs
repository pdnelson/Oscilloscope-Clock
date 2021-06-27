namespace Oscilloscope_Clock
{
    partial class frmClock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClock));
            this.lblInstructions = new System.Windows.Forms.Label();
            this.grpSettings = new System.Windows.Forms.GroupBox();
            this.lblError = new System.Windows.Forms.Label();
            this.cboFontSize = new System.Windows.Forms.ComboBox();
            this.lblFontSize = new System.Windows.Forms.Label();
            this.cboTimeConvention = new System.Windows.Forms.ComboBox();
            this.lblConvention = new System.Windows.Forms.Label();
            this.cboCharSpacing = new System.Windows.Forms.ComboBox();
            this.lblCharSpacing = new System.Windows.Forms.Label();
            this.grpSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblInstructions
            // 
            this.lblInstructions.AutoSize = true;
            this.lblInstructions.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstructions.Location = new System.Drawing.Point(12, 14);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(383, 121);
            this.lblInstructions.TabIndex = 0;
            this.lblInstructions.Text = resources.GetString("lblInstructions.Text");
            // 
            // grpSettings
            // 
            this.grpSettings.Controls.Add(this.lblError);
            this.grpSettings.Controls.Add(this.cboFontSize);
            this.grpSettings.Controls.Add(this.lblFontSize);
            this.grpSettings.Controls.Add(this.cboTimeConvention);
            this.grpSettings.Controls.Add(this.lblConvention);
            this.grpSettings.Controls.Add(this.cboCharSpacing);
            this.grpSettings.Controls.Add(this.lblCharSpacing);
            this.grpSettings.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpSettings.ForeColor = System.Drawing.Color.White;
            this.grpSettings.Location = new System.Drawing.Point(14, 153);
            this.grpSettings.Name = "grpSettings";
            this.grpSettings.Size = new System.Drawing.Size(381, 111);
            this.grpSettings.TabIndex = 1;
            this.grpSettings.TabStop = false;
            this.grpSettings.Text = "Settings";
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(6, 82);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 11);
            this.lblError.TabIndex = 6;
            // 
            // cboFontSize
            // 
            this.cboFontSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFontSize.FormattingEnabled = true;
            this.cboFontSize.Location = new System.Drawing.Point(139, 15);
            this.cboFontSize.Name = "cboFontSize";
            this.cboFontSize.Size = new System.Drawing.Size(46, 19);
            this.cboFontSize.TabIndex = 5;
            this.cboFontSize.SelectedIndexChanged += new System.EventHandler(this.cboFontSize_SelectedIndexChanged);
            // 
            // lblFontSize
            // 
            this.lblFontSize.AutoSize = true;
            this.lblFontSize.Location = new System.Drawing.Point(62, 18);
            this.lblFontSize.Name = "lblFontSize";
            this.lblFontSize.Size = new System.Drawing.Size(152, 11);
            this.lblFontSize.TabIndex = 4;
            this.lblFontSize.Text = "Font Size:        pt.";
            // 
            // cboTimeConvention
            // 
            this.cboTimeConvention.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTimeConvention.Enabled = false;
            this.cboTimeConvention.FormattingEnabled = true;
            this.cboTimeConvention.Items.AddRange(new object[] {
            "12-hour",
            "24-hour"});
            this.cboTimeConvention.Location = new System.Drawing.Point(139, 59);
            this.cboTimeConvention.Name = "cboTimeConvention";
            this.cboTimeConvention.Size = new System.Drawing.Size(75, 19);
            this.cboTimeConvention.TabIndex = 3;
            // 
            // lblConvention
            // 
            this.lblConvention.AutoSize = true;
            this.lblConvention.Location = new System.Drawing.Point(54, 62);
            this.lblConvention.Name = "lblConvention";
            this.lblConvention.Size = new System.Drawing.Size(82, 11);
            this.lblConvention.TabIndex = 2;
            this.lblConvention.Text = "Convention:";
            // 
            // cboCharSpacing
            // 
            this.cboCharSpacing.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCharSpacing.FormattingEnabled = true;
            this.cboCharSpacing.Location = new System.Drawing.Point(139, 37);
            this.cboCharSpacing.Name = "cboCharSpacing";
            this.cboCharSpacing.Size = new System.Drawing.Size(46, 19);
            this.cboCharSpacing.TabIndex = 1;
            this.cboCharSpacing.SelectedIndexChanged += new System.EventHandler(this.cboCharSpacing_SelectedIndexChanged);
            // 
            // lblCharSpacing
            // 
            this.lblCharSpacing.AutoSize = true;
            this.lblCharSpacing.Location = new System.Drawing.Point(6, 40);
            this.lblCharSpacing.Name = "lblCharSpacing";
            this.lblCharSpacing.Size = new System.Drawing.Size(208, 11);
            this.lblCharSpacing.TabIndex = 0;
            this.lblCharSpacing.Text = "Character Spacing:        pt.";
            // 
            // frmClock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(410, 281);
            this.Controls.Add(this.grpSettings);
            this.Controls.Add(this.lblInstructions);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmClock";
            this.Text = "Digital Oscilloscope Clock";
            this.Load += new System.EventHandler(this.frmClock_Load);
            this.grpSettings.ResumeLayout(false);
            this.grpSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInstructions;
        private System.Windows.Forms.GroupBox grpSettings;
        private System.Windows.Forms.ComboBox cboCharSpacing;
        private System.Windows.Forms.Label lblCharSpacing;
        private System.Windows.Forms.ComboBox cboTimeConvention;
        private System.Windows.Forms.Label lblConvention;
        private System.Windows.Forms.ComboBox cboFontSize;
        private System.Windows.Forms.Label lblFontSize;
        private System.Windows.Forms.Label lblError;
    }
}

