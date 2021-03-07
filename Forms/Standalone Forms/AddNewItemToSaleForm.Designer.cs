namespace RetroCollector {
    partial class AddNewItemToSaleForm {
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
            this.lblProductName = new System.Windows.Forms.Label();
            this.tboxProductName = new System.Windows.Forms.TextBox();
            this.lblProductQuantity = new System.Windows.Forms.Label();
            this.numProductQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblProductTotal = new System.Windows.Forms.Label();
            this.tboxProductTotal = new System.Windows.Forms.TextBox();
            this.btnSaveLineItem = new System.Windows.Forms.Button();
            this.btnCancelItem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numProductQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new System.Drawing.Point(12, 17);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(47, 13);
            this.lblProductName.TabIndex = 0;
            this.lblProductName.Text = "Product:";
            // 
            // tboxProductName
            // 
            this.tboxProductName.Location = new System.Drawing.Point(65, 14);
            this.tboxProductName.Name = "tboxProductName";
            this.tboxProductName.Size = new System.Drawing.Size(196, 20);
            this.tboxProductName.TabIndex = 1;
            // 
            // lblProductQuantity
            // 
            this.lblProductQuantity.AutoSize = true;
            this.lblProductQuantity.Location = new System.Drawing.Point(12, 43);
            this.lblProductQuantity.Name = "lblProductQuantity";
            this.lblProductQuantity.Size = new System.Drawing.Size(49, 13);
            this.lblProductQuantity.TabIndex = 2;
            this.lblProductQuantity.Text = "Quantity:";
            // 
            // numProductQuantity
            // 
            this.numProductQuantity.Location = new System.Drawing.Point(65, 41);
            this.numProductQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numProductQuantity.Name = "numProductQuantity";
            this.numProductQuantity.Size = new System.Drawing.Size(49, 20);
            this.numProductQuantity.TabIndex = 4;
            this.numProductQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblProductTotal
            // 
            this.lblProductTotal.AutoSize = true;
            this.lblProductTotal.Location = new System.Drawing.Point(147, 43);
            this.lblProductTotal.Name = "lblProductTotal";
            this.lblProductTotal.Size = new System.Drawing.Size(34, 13);
            this.lblProductTotal.TabIndex = 5;
            this.lblProductTotal.Text = "Total:";
            // 
            // tboxProductTotal
            // 
            this.tboxProductTotal.Location = new System.Drawing.Point(187, 40);
            this.tboxProductTotal.Name = "tboxProductTotal";
            this.tboxProductTotal.ReadOnly = true;
            this.tboxProductTotal.Size = new System.Drawing.Size(74, 20);
            this.tboxProductTotal.TabIndex = 6;
            // 
            // btnSaveLineItem
            // 
            this.btnSaveLineItem.Location = new System.Drawing.Point(15, 78);
            this.btnSaveLineItem.Name = "btnSaveLineItem";
            this.btnSaveLineItem.Size = new System.Drawing.Size(75, 23);
            this.btnSaveLineItem.TabIndex = 7;
            this.btnSaveLineItem.Text = "OK";
            this.btnSaveLineItem.UseVisualStyleBackColor = true;
            // 
            // btnCancelItem
            // 
            this.btnCancelItem.Location = new System.Drawing.Point(186, 78);
            this.btnCancelItem.Name = "btnCancelItem";
            this.btnCancelItem.Size = new System.Drawing.Size(75, 23);
            this.btnCancelItem.TabIndex = 8;
            this.btnCancelItem.Text = "Cancel";
            this.btnCancelItem.UseVisualStyleBackColor = true;
            // 
            // AddNewItemToSaleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 113);
            this.Controls.Add(this.btnCancelItem);
            this.Controls.Add(this.btnSaveLineItem);
            this.Controls.Add(this.tboxProductTotal);
            this.Controls.Add(this.lblProductTotal);
            this.Controls.Add(this.numProductQuantity);
            this.Controls.Add(this.lblProductQuantity);
            this.Controls.Add(this.tboxProductName);
            this.Controls.Add(this.lblProductName);
            this.Name = "AddNewItemToSaleForm";
            this.Text = "Add Line Item";
            ((System.ComponentModel.ISupportInitialize)(this.numProductQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.TextBox tboxProductName;
        private System.Windows.Forms.Label lblProductQuantity;
        private System.Windows.Forms.NumericUpDown numProductQuantity;
        private System.Windows.Forms.Label lblProductTotal;
        private System.Windows.Forms.TextBox tboxProductTotal;
        private System.Windows.Forms.Button btnSaveLineItem;
        private System.Windows.Forms.Button btnCancelItem;
    }
}