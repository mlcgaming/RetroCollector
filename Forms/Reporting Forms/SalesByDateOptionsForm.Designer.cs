namespace RetroCollector {
    partial class SalesByDateOptionsForm {
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
            this.btnRun = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.grpOptions = new System.Windows.Forms.GroupBox();
            this.grpItems = new System.Windows.Forms.GroupBox();
            this.grpBreakdown = new System.Windows.Forms.GroupBox();
            this.listAllItems = new System.Windows.Forms.ListBox();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.lblToDate = new System.Windows.Forms.Label();
            this.lblTotalNumberSales = new System.Windows.Forms.Label();
            this.lblTotalProfit = new System.Windows.Forms.Label();
            this.grpOptions.SuspendLayout();
            this.grpItems.SuspendLayout();
            this.grpBreakdown.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(12, 230);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 0;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(12, 259);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // grpOptions
            // 
            this.grpOptions.Controls.Add(this.lblToDate);
            this.grpOptions.Controls.Add(this.lblFromDate);
            this.grpOptions.Controls.Add(this.dtpToDate);
            this.grpOptions.Controls.Add(this.dtpFromDate);
            this.grpOptions.Location = new System.Drawing.Point(12, 12);
            this.grpOptions.Name = "grpOptions";
            this.grpOptions.Size = new System.Drawing.Size(226, 126);
            this.grpOptions.TabIndex = 2;
            this.grpOptions.TabStop = false;
            this.grpOptions.Text = "Options";
            // 
            // grpItems
            // 
            this.grpItems.Controls.Add(this.listAllItems);
            this.grpItems.Location = new System.Drawing.Point(244, 12);
            this.grpItems.Name = "grpItems";
            this.grpItems.Size = new System.Drawing.Size(318, 275);
            this.grpItems.TabIndex = 3;
            this.grpItems.TabStop = false;
            this.grpItems.Text = "Items";
            // 
            // grpBreakdown
            // 
            this.grpBreakdown.Controls.Add(this.lblTotalProfit);
            this.grpBreakdown.Controls.Add(this.lblTotalNumberSales);
            this.grpBreakdown.Location = new System.Drawing.Point(568, 12);
            this.grpBreakdown.Name = "grpBreakdown";
            this.grpBreakdown.Size = new System.Drawing.Size(193, 106);
            this.grpBreakdown.TabIndex = 3;
            this.grpBreakdown.TabStop = false;
            this.grpBreakdown.Text = "Breakdown";
            // 
            // listAllItems
            // 
            this.listAllItems.FormattingEnabled = true;
            this.listAllItems.Location = new System.Drawing.Point(6, 19);
            this.listAllItems.Name = "listAllItems";
            this.listAllItems.Size = new System.Drawing.Size(301, 251);
            this.listAllItems.TabIndex = 0;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Location = new System.Drawing.Point(6, 37);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(200, 20);
            this.dtpFromDate.TabIndex = 0;
            // 
            // dtpToDate
            // 
            this.dtpToDate.Location = new System.Drawing.Point(6, 86);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(200, 20);
            this.dtpToDate.TabIndex = 1;
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Location = new System.Drawing.Point(6, 21);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(33, 13);
            this.lblFromDate.TabIndex = 2;
            this.lblFromDate.Text = "From:";
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Location = new System.Drawing.Point(6, 70);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(23, 13);
            this.lblToDate.TabIndex = 3;
            this.lblToDate.Text = "To:";
            // 
            // lblTotalNumberSales
            // 
            this.lblTotalNumberSales.AutoSize = true;
            this.lblTotalNumberSales.Location = new System.Drawing.Point(6, 37);
            this.lblTotalNumberSales.Name = "lblTotalNumberSales";
            this.lblTotalNumberSales.Size = new System.Drawing.Size(115, 13);
            this.lblTotalNumberSales.TabIndex = 0;
            this.lblTotalNumberSales.Text = "Total Number of Sales:";
            // 
            // lblTotalProfit
            // 
            this.lblTotalProfit.AutoSize = true;
            this.lblTotalProfit.Location = new System.Drawing.Point(6, 58);
            this.lblTotalProfit.Name = "lblTotalProfit";
            this.lblTotalProfit.Size = new System.Drawing.Size(91, 13);
            this.lblTotalProfit.TabIndex = 1;
            this.lblTotalProfit.Text = "Total Profit Made:";
            // 
            // SalesByDateOptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 293);
            this.Controls.Add(this.grpBreakdown);
            this.Controls.Add(this.grpItems);
            this.Controls.Add(this.grpOptions);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRun);
            this.Name = "SalesByDateOptionsForm";
            this.Text = "Report Options";
            this.grpOptions.ResumeLayout(false);
            this.grpOptions.PerformLayout();
            this.grpItems.ResumeLayout(false);
            this.grpBreakdown.ResumeLayout(false);
            this.grpBreakdown.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox grpOptions;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.GroupBox grpItems;
        private System.Windows.Forms.ListBox listAllItems;
        private System.Windows.Forms.GroupBox grpBreakdown;
        private System.Windows.Forms.Label lblTotalProfit;
        private System.Windows.Forms.Label lblTotalNumberSales;
    }
}