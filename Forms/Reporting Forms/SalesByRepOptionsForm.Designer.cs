namespace RetroCollector {
    partial class SalesByRepOptionsForm {
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
            this.grpBreakdown = new System.Windows.Forms.GroupBox();
            this.lblTotalProfit = new System.Windows.Forms.Label();
            this.lblTotalNumberSales = new System.Windows.Forms.Label();
            this.grpItems = new System.Windows.Forms.GroupBox();
            this.listAllItems = new System.Windows.Forms.ListBox();
            this.grpOptions = new System.Windows.Forms.GroupBox();
            this.lblSalesRep = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.cboxSalesRep = new System.Windows.Forms.ComboBox();
            this.grpBreakdown.SuspendLayout();
            this.grpItems.SuspendLayout();
            this.grpOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBreakdown
            // 
            this.grpBreakdown.Controls.Add(this.lblTotalProfit);
            this.grpBreakdown.Controls.Add(this.lblTotalNumberSales);
            this.grpBreakdown.Location = new System.Drawing.Point(568, 12);
            this.grpBreakdown.Name = "grpBreakdown";
            this.grpBreakdown.Size = new System.Drawing.Size(193, 106);
            this.grpBreakdown.TabIndex = 7;
            this.grpBreakdown.TabStop = false;
            this.grpBreakdown.Text = "Breakdown";
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
            // lblTotalNumberSales
            // 
            this.lblTotalNumberSales.AutoSize = true;
            this.lblTotalNumberSales.Location = new System.Drawing.Point(6, 37);
            this.lblTotalNumberSales.Name = "lblTotalNumberSales";
            this.lblTotalNumberSales.Size = new System.Drawing.Size(115, 13);
            this.lblTotalNumberSales.TabIndex = 0;
            this.lblTotalNumberSales.Text = "Total Number of Sales:";
            // 
            // grpItems
            // 
            this.grpItems.Controls.Add(this.listAllItems);
            this.grpItems.Location = new System.Drawing.Point(244, 12);
            this.grpItems.Name = "grpItems";
            this.grpItems.Size = new System.Drawing.Size(318, 275);
            this.grpItems.TabIndex = 8;
            this.grpItems.TabStop = false;
            this.grpItems.Text = "Items";
            // 
            // listAllItems
            // 
            this.listAllItems.FormattingEnabled = true;
            this.listAllItems.Location = new System.Drawing.Point(6, 19);
            this.listAllItems.Name = "listAllItems";
            this.listAllItems.Size = new System.Drawing.Size(301, 251);
            this.listAllItems.TabIndex = 0;
            // 
            // grpOptions
            // 
            this.grpOptions.Controls.Add(this.cboxSalesRep);
            this.grpOptions.Controls.Add(this.lblSalesRep);
            this.grpOptions.Location = new System.Drawing.Point(12, 12);
            this.grpOptions.Name = "grpOptions";
            this.grpOptions.Size = new System.Drawing.Size(226, 82);
            this.grpOptions.TabIndex = 6;
            this.grpOptions.TabStop = false;
            this.grpOptions.Text = "Options";
            // 
            // lblSalesRep
            // 
            this.lblSalesRep.AutoSize = true;
            this.lblSalesRep.Location = new System.Drawing.Point(6, 21);
            this.lblSalesRep.Name = "lblSalesRep";
            this.lblSalesRep.Size = new System.Drawing.Size(59, 13);
            this.lblSalesRep.TabIndex = 2;
            this.lblSalesRep.Text = "Sales Rep:";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(12, 259);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(12, 230);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 4;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            // 
            // cboxSalesRep
            // 
            this.cboxSalesRep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxSalesRep.FormattingEnabled = true;
            this.cboxSalesRep.Location = new System.Drawing.Point(9, 37);
            this.cboxSalesRep.Name = "cboxSalesRep";
            this.cboxSalesRep.Size = new System.Drawing.Size(211, 21);
            this.cboxSalesRep.TabIndex = 3;
            // 
            // SalesByRepOptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 298);
            this.Controls.Add(this.grpBreakdown);
            this.Controls.Add(this.grpItems);
            this.Controls.Add(this.grpOptions);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRun);
            this.Name = "SalesByRepOptionsForm";
            this.Text = "SalesByRepOptionsForm";
            this.grpBreakdown.ResumeLayout(false);
            this.grpBreakdown.PerformLayout();
            this.grpItems.ResumeLayout(false);
            this.grpOptions.ResumeLayout(false);
            this.grpOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBreakdown;
        private System.Windows.Forms.Label lblTotalProfit;
        private System.Windows.Forms.Label lblTotalNumberSales;
        private System.Windows.Forms.GroupBox grpItems;
        private System.Windows.Forms.ListBox listAllItems;
        private System.Windows.Forms.GroupBox grpOptions;
        private System.Windows.Forms.Label lblSalesRep;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.ComboBox cboxSalesRep;
    }
}