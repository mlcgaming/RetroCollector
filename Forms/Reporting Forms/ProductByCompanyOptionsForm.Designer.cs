namespace RetroCollector {
    partial class ProductByCompanyOptionsForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.grpOptions = new System.Windows.Forms.GroupBox();
            this.cboxDevelopers = new System.Windows.Forms.ComboBox();
            this.lblReportDeveloper = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.grpOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpOptions
            // 
            this.grpOptions.Controls.Add(this.cboxDevelopers);
            this.grpOptions.Controls.Add(this.lblReportDeveloper);
            this.grpOptions.Location = new System.Drawing.Point(12, 12);
            this.grpOptions.Name = "grpOptions";
            this.grpOptions.Size = new System.Drawing.Size(196, 85);
            this.grpOptions.TabIndex = 0;
            this.grpOptions.TabStop = false;
            this.grpOptions.Text = "Options";
            // 
            // cboxDevelopers
            // 
            this.cboxDevelopers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxDevelopers.FormattingEnabled = true;
            this.cboxDevelopers.Location = new System.Drawing.Point(9, 40);
            this.cboxDevelopers.Name = "cboxDevelopers";
            this.cboxDevelopers.Size = new System.Drawing.Size(181, 21);
            this.cboxDevelopers.TabIndex = 1;
            // 
            // lblReportDeveloper
            // 
            this.lblReportDeveloper.AutoSize = true;
            this.lblReportDeveloper.Location = new System.Drawing.Point(6, 24);
            this.lblReportDeveloper.Name = "lblReportDeveloper";
            this.lblReportDeveloper.Size = new System.Drawing.Size(59, 13);
            this.lblReportDeveloper.TabIndex = 0;
            this.lblReportDeveloper.Text = "Developer:";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(133, 103);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(12, 103);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 3;
            this.btnRun.Text = "Generate";
            this.btnRun.UseVisualStyleBackColor = true;
            // 
            // ProductByCompanyOptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(218, 140);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.grpOptions);
            this.Name = "ProductByCompanyOptionsForm";
            this.Text = "Report Options";
            this.grpOptions.ResumeLayout(false);
            this.grpOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpOptions;
        private System.Windows.Forms.ComboBox cboxDevelopers;
        private System.Windows.Forms.Label lblReportDeveloper;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRun;
    }
}