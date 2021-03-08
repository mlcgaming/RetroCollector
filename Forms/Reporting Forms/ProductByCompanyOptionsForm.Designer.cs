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
            this.btnClose = new System.Windows.Forms.Button();
            this.grpReport = new System.Windows.Forms.GroupBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.lblReportDeveloper = new System.Windows.Forms.Label();
            this.cboxDevelopers = new System.Windows.Forms.ComboBox();
            this.listReportedItems = new System.Windows.Forms.ListBox();
            this.grpOptions.SuspendLayout();
            this.grpReport.SuspendLayout();
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
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(12, 234);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // grpReport
            // 
            this.grpReport.Controls.Add(this.listReportedItems);
            this.grpReport.Location = new System.Drawing.Point(214, 12);
            this.grpReport.Name = "grpReport";
            this.grpReport.Size = new System.Drawing.Size(305, 242);
            this.grpReport.TabIndex = 2;
            this.grpReport.TabStop = false;
            this.grpReport.Text = "Report";
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(12, 205);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 3;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
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
            // cboxDevelopers
            // 
            this.cboxDevelopers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxDevelopers.FormattingEnabled = true;
            this.cboxDevelopers.Location = new System.Drawing.Point(9, 40);
            this.cboxDevelopers.Name = "cboxDevelopers";
            this.cboxDevelopers.Size = new System.Drawing.Size(181, 21);
            this.cboxDevelopers.TabIndex = 1;
            // 
            // listReportedItems
            // 
            this.listReportedItems.FormattingEnabled = true;
            this.listReportedItems.Location = new System.Drawing.Point(16, 24);
            this.listReportedItems.Name = "listReportedItems";
            this.listReportedItems.Size = new System.Drawing.Size(273, 199);
            this.listReportedItems.TabIndex = 0;
            // 
            // ProductByCompanyOptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 266);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.grpReport);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.grpOptions);
            this.Name = "ProductByCompanyOptionsForm";
            this.Text = "Options";
            this.grpOptions.ResumeLayout(false);
            this.grpOptions.PerformLayout();
            this.grpReport.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpOptions;
        private System.Windows.Forms.ComboBox cboxDevelopers;
        private System.Windows.Forms.Label lblReportDeveloper;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox grpReport;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.ListBox listReportedItems;
    }
}