
namespace RetroCollector {
    partial class CustomReportForm {
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
            this.grpReportSales = new System.Windows.Forms.GroupBox();
            this.grpReportProducts = new System.Windows.Forms.GroupBox();
            this.checkIncludeSales = new System.Windows.Forms.CheckBox();
            this.checkIncludeProducts = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.grpCustomers = new System.Windows.Forms.GroupBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.grpCompany = new System.Windows.Forms.GroupBox();
            this.grpReportSales.SuspendLayout();
            this.grpReportProducts.SuspendLayout();
            this.grpCustomers.SuspendLayout();
            this.grpCompany.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpReportSales
            // 
            this.grpReportSales.Controls.Add(this.checkIncludeSales);
            this.grpReportSales.Location = new System.Drawing.Point(12, 12);
            this.grpReportSales.Name = "grpReportSales";
            this.grpReportSales.Size = new System.Drawing.Size(255, 161);
            this.grpReportSales.TabIndex = 0;
            this.grpReportSales.TabStop = false;
            this.grpReportSales.Text = "Sales";
            // 
            // grpReportProducts
            // 
            this.grpReportProducts.Controls.Add(this.checkIncludeProducts);
            this.grpReportProducts.Location = new System.Drawing.Point(12, 179);
            this.grpReportProducts.Name = "grpReportProducts";
            this.grpReportProducts.Size = new System.Drawing.Size(255, 161);
            this.grpReportProducts.TabIndex = 1;
            this.grpReportProducts.TabStop = false;
            this.grpReportProducts.Text = "Products";
            // 
            // checkIncludeSales
            // 
            this.checkIncludeSales.AutoSize = true;
            this.checkIncludeSales.Location = new System.Drawing.Point(41, 0);
            this.checkIncludeSales.Name = "checkIncludeSales";
            this.checkIncludeSales.Size = new System.Drawing.Size(15, 14);
            this.checkIncludeSales.TabIndex = 0;
            this.checkIncludeSales.UseVisualStyleBackColor = true;
            // 
            // checkIncludeProducts
            // 
            this.checkIncludeProducts.AutoSize = true;
            this.checkIncludeProducts.Location = new System.Drawing.Point(55, 0);
            this.checkIncludeProducts.Name = "checkIncludeProducts";
            this.checkIncludeProducts.Size = new System.Drawing.Size(15, 14);
            this.checkIncludeProducts.TabIndex = 1;
            this.checkIncludeProducts.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(63, 0);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // grpCustomers
            // 
            this.grpCustomers.Controls.Add(this.checkBox1);
            this.grpCustomers.Location = new System.Drawing.Point(273, 12);
            this.grpCustomers.Name = "grpCustomers";
            this.grpCustomers.Size = new System.Drawing.Size(255, 161);
            this.grpCustomers.TabIndex = 2;
            this.grpCustomers.TabStop = false;
            this.grpCustomers.Text = "Customers";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(65, 0);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(15, 14);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // grpCompany
            // 
            this.grpCompany.Controls.Add(this.checkBox2);
            this.grpCompany.Location = new System.Drawing.Point(273, 179);
            this.grpCompany.Name = "grpCompany";
            this.grpCompany.Size = new System.Drawing.Size(255, 161);
            this.grpCompany.TabIndex = 3;
            this.grpCompany.TabStop = false;
            this.grpCompany.Text = "Companies";
            // 
            // CustomReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 352);
            this.Controls.Add(this.grpCompany);
            this.Controls.Add(this.grpCustomers);
            this.Controls.Add(this.grpReportProducts);
            this.Controls.Add(this.grpReportSales);
            this.Name = "CustomReportForm";
            this.Text = "Custom Report";
            this.grpReportSales.ResumeLayout(false);
            this.grpReportSales.PerformLayout();
            this.grpReportProducts.ResumeLayout(false);
            this.grpReportProducts.PerformLayout();
            this.grpCustomers.ResumeLayout(false);
            this.grpCustomers.PerformLayout();
            this.grpCompany.ResumeLayout(false);
            this.grpCompany.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpReportSales;
        private System.Windows.Forms.GroupBox grpReportProducts;
        private System.Windows.Forms.CheckBox checkIncludeSales;
        private System.Windows.Forms.CheckBox checkIncludeProducts;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox grpCustomers;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.GroupBox grpCompany;
    }
}