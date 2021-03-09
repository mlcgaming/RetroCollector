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
            this.grpOptions = new System.Windows.Forms.GroupBox();
            this.cboxSalesRep = new System.Windows.Forms.ComboBox();
            this.lblSalesRep = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.grpOptions.SuspendLayout();
            this.SuspendLayout();
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
            // cboxSalesRep
            // 
            this.cboxSalesRep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxSalesRep.FormattingEnabled = true;
            this.cboxSalesRep.Location = new System.Drawing.Point(9, 37);
            this.cboxSalesRep.Name = "cboxSalesRep";
            this.cboxSalesRep.Size = new System.Drawing.Size(211, 21);
            this.cboxSalesRep.TabIndex = 3;
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
            this.btnClose.Location = new System.Drawing.Point(163, 100);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(12, 100);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 4;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            // 
            // SalesByRepOptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 136);
            this.Controls.Add(this.grpOptions);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRun);
            this.Name = "SalesByRepOptionsForm";
            this.Text = "Report Options";
            this.grpOptions.ResumeLayout(false);
            this.grpOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox grpOptions;
        private System.Windows.Forms.Label lblSalesRep;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.ComboBox cboxSalesRep;
    }
}