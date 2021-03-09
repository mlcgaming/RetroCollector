namespace RetroCollector {
    partial class ReportForm {
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
            this.lblReportTitle = new System.Windows.Forms.Label();
            this.lblReportDate = new System.Windows.Forms.Label();
            this.dgvReportItems = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportItems)).BeginInit();
            this.SuspendLayout();
            // 
            // lblReportTitle
            // 
            this.lblReportTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblReportTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReportTitle.Location = new System.Drawing.Point(0, 0);
            this.lblReportTitle.Name = "lblReportTitle";
            this.lblReportTitle.Size = new System.Drawing.Size(539, 23);
            this.lblReportTitle.TabIndex = 0;
            this.lblReportTitle.Text = "REPORT TITLE";
            this.lblReportTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblReportDate
            // 
            this.lblReportDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblReportDate.Location = new System.Drawing.Point(0, 23);
            this.lblReportDate.Name = "lblReportDate";
            this.lblReportDate.Size = new System.Drawing.Size(539, 13);
            this.lblReportDate.TabIndex = 1;
            this.lblReportDate.Text = "REPORT DATE";
            this.lblReportDate.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dgvReportItems
            // 
            this.dgvReportItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReportItems.Location = new System.Drawing.Point(12, 55);
            this.dgvReportItems.Name = "dgvReportItems";
            this.dgvReportItems.Size = new System.Drawing.Size(515, 232);
            this.dgvReportItems.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(452, 293);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 324);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvReportItems);
            this.Controls.Add(this.lblReportDate);
            this.Controls.Add(this.lblReportTitle);
            this.Name = "ReportForm";
            this.Text = "Report Results";
            ((System.ComponentModel.ISupportInitialize)(this.dgvReportItems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblReportTitle;
        private System.Windows.Forms.Label lblReportDate;
        private System.Windows.Forms.DataGridView dgvReportItems;
        private System.Windows.Forms.Button btnClose;
    }
}