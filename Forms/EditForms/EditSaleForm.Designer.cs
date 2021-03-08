namespace RetroCollector {
    partial class EditSaleForm {
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
            this.btnAddNewCustomer = new System.Windows.Forms.Button();
            this.cboxSalesCustomers = new System.Windows.Forms.ComboBox();
            this.lblSalesCustomer = new System.Windows.Forms.Label();
            this.lblSalesRep = new System.Windows.Forms.Label();
            this.grpSalePayment = new System.Windows.Forms.GroupBox();
            this.btnSaleCancel = new System.Windows.Forms.Button();
            this.btnSaleProcess = new System.Windows.Forms.Button();
            this.tboxSalesChangeDue = new System.Windows.Forms.TextBox();
            this.lblSalesChangeDue = new System.Windows.Forms.Label();
            this.tboxSalesTenderedAmount = new System.Windows.Forms.TextBox();
            this.lblSalesTenderedAmount = new System.Windows.Forms.Label();
            this.grpSaleTotals = new System.Windows.Forms.GroupBox();
            this.lblSalesTotal = new System.Windows.Forms.Label();
            this.tboxSalesTotal = new System.Windows.Forms.TextBox();
            this.lblSalesTax = new System.Windows.Forms.Label();
            this.tboxTaxTotal = new System.Windows.Forms.TextBox();
            this.lblSaleSubtotal = new System.Windows.Forms.Label();
            this.tboxSaleSubtotal = new System.Windows.Forms.TextBox();
            this.tboxSaleDescription = new System.Windows.Forms.TextBox();
            this.lblSaleDescription = new System.Windows.Forms.Label();
            this.grpAllProducts = new System.Windows.Forms.GroupBox();
            this.tboxProductSearch = new System.Windows.Forms.TextBox();
            this.lblProductSearch = new System.Windows.Forms.Label();
            this.btnAddProductToItems = new System.Windows.Forms.Button();
            this.listAllProducts = new System.Windows.Forms.ListBox();
            this.grpSaleItems = new System.Windows.Forms.GroupBox();
            this.btnRemoveSaleItem = new System.Windows.Forms.Button();
            this.listAllSaleItems = new System.Windows.Forms.ListBox();
            this.tboxSaleDate = new System.Windows.Forms.TextBox();
            this.lblSaleDate = new System.Windows.Forms.Label();
            this.tboxSaleId = new System.Windows.Forms.TextBox();
            this.lblSaleId = new System.Windows.Forms.Label();
            this.grpModifyInfo = new System.Windows.Forms.GroupBox();
            this.lblLastUpdatedByValue = new System.Windows.Forms.Label();
            this.lblDateLastUpdatedValue = new System.Windows.Forms.Label();
            this.lblDateCreatedValue = new System.Windows.Forms.Label();
            this.lblCreatedByValue = new System.Windows.Forms.Label();
            this.lblDateLastUpdated = new System.Windows.Forms.Label();
            this.lblLastUpdatedBy = new System.Windows.Forms.Label();
            this.lblDateCreated = new System.Windows.Forms.Label();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.tboxSalesRep = new System.Windows.Forms.TextBox();
            this.grpSalePayment.SuspendLayout();
            this.grpSaleTotals.SuspendLayout();
            this.grpAllProducts.SuspendLayout();
            this.grpSaleItems.SuspendLayout();
            this.grpModifyInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddNewCustomer
            // 
            this.btnAddNewCustomer.Location = new System.Drawing.Point(298, 57);
            this.btnAddNewCustomer.Name = "btnAddNewCustomer";
            this.btnAddNewCustomer.Size = new System.Drawing.Size(75, 23);
            this.btnAddNewCustomer.TabIndex = 29;
            this.btnAddNewCustomer.Text = "Add New";
            this.btnAddNewCustomer.UseVisualStyleBackColor = true;
            // 
            // cboxSalesCustomers
            // 
            this.cboxSalesCustomers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxSalesCustomers.FormattingEnabled = true;
            this.cboxSalesCustomers.Location = new System.Drawing.Point(144, 59);
            this.cboxSalesCustomers.Name = "cboxSalesCustomers";
            this.cboxSalesCustomers.Size = new System.Drawing.Size(148, 21);
            this.cboxSalesCustomers.TabIndex = 28;
            // 
            // lblSalesCustomer
            // 
            this.lblSalesCustomer.AutoSize = true;
            this.lblSalesCustomer.Location = new System.Drawing.Point(84, 62);
            this.lblSalesCustomer.Name = "lblSalesCustomer";
            this.lblSalesCustomer.Size = new System.Drawing.Size(54, 13);
            this.lblSalesCustomer.TabIndex = 27;
            this.lblSalesCustomer.Text = "Customer:";
            // 
            // lblSalesRep
            // 
            this.lblSalesRep.AutoSize = true;
            this.lblSalesRep.Location = new System.Drawing.Point(252, 9);
            this.lblSalesRep.Name = "lblSalesRep";
            this.lblSalesRep.Size = new System.Drawing.Size(59, 13);
            this.lblSalesRep.TabIndex = 25;
            this.lblSalesRep.Text = "Sales Rep:";
            // 
            // grpSalePayment
            // 
            this.grpSalePayment.Controls.Add(this.tboxSalesChangeDue);
            this.grpSalePayment.Controls.Add(this.lblSalesChangeDue);
            this.grpSalePayment.Controls.Add(this.tboxSalesTenderedAmount);
            this.grpSalePayment.Controls.Add(this.lblSalesTenderedAmount);
            this.grpSalePayment.Location = new System.Drawing.Point(246, 341);
            this.grpSalePayment.Name = "grpSalePayment";
            this.grpSalePayment.Size = new System.Drawing.Size(200, 72);
            this.grpSalePayment.TabIndex = 24;
            this.grpSalePayment.TabStop = false;
            this.grpSalePayment.Text = "Payment";
            // 
            // btnSaleCancel
            // 
            this.btnSaleCancel.Location = new System.Drawing.Point(270, 524);
            this.btnSaleCancel.Name = "btnSaleCancel";
            this.btnSaleCancel.Size = new System.Drawing.Size(77, 23);
            this.btnSaleCancel.TabIndex = 5;
            this.btnSaleCancel.Text = "Cancel";
            this.btnSaleCancel.UseVisualStyleBackColor = true;
            // 
            // btnSaleProcess
            // 
            this.btnSaleProcess.Location = new System.Drawing.Point(359, 524);
            this.btnSaleProcess.Name = "btnSaleProcess";
            this.btnSaleProcess.Size = new System.Drawing.Size(87, 23);
            this.btnSaleProcess.TabIndex = 4;
            this.btnSaleProcess.Text = "Save Changes";
            this.btnSaleProcess.UseVisualStyleBackColor = true;
            // 
            // tboxSalesChangeDue
            // 
            this.tboxSalesChangeDue.Location = new System.Drawing.Point(107, 42);
            this.tboxSalesChangeDue.Name = "tboxSalesChangeDue";
            this.tboxSalesChangeDue.ReadOnly = true;
            this.tboxSalesChangeDue.Size = new System.Drawing.Size(87, 20);
            this.tboxSalesChangeDue.TabIndex = 3;
            // 
            // lblSalesChangeDue
            // 
            this.lblSalesChangeDue.AutoSize = true;
            this.lblSalesChangeDue.Location = new System.Drawing.Point(6, 45);
            this.lblSalesChangeDue.Name = "lblSalesChangeDue";
            this.lblSalesChangeDue.Size = new System.Drawing.Size(78, 13);
            this.lblSalesChangeDue.TabIndex = 2;
            this.lblSalesChangeDue.Text = "Change Given:";
            // 
            // tboxSalesTenderedAmount
            // 
            this.tboxSalesTenderedAmount.Location = new System.Drawing.Point(107, 16);
            this.tboxSalesTenderedAmount.Name = "tboxSalesTenderedAmount";
            this.tboxSalesTenderedAmount.ReadOnly = true;
            this.tboxSalesTenderedAmount.Size = new System.Drawing.Size(87, 20);
            this.tboxSalesTenderedAmount.TabIndex = 1;
            // 
            // lblSalesTenderedAmount
            // 
            this.lblSalesTenderedAmount.AutoSize = true;
            this.lblSalesTenderedAmount.Location = new System.Drawing.Point(6, 19);
            this.lblSalesTenderedAmount.Name = "lblSalesTenderedAmount";
            this.lblSalesTenderedAmount.Size = new System.Drawing.Size(95, 13);
            this.lblSalesTenderedAmount.TabIndex = 0;
            this.lblSalesTenderedAmount.Text = "Amount Tendered:";
            // 
            // grpSaleTotals
            // 
            this.grpSaleTotals.Controls.Add(this.lblSalesTotal);
            this.grpSaleTotals.Controls.Add(this.tboxSalesTotal);
            this.grpSaleTotals.Controls.Add(this.lblSalesTax);
            this.grpSaleTotals.Controls.Add(this.tboxTaxTotal);
            this.grpSaleTotals.Controls.Add(this.lblSaleSubtotal);
            this.grpSaleTotals.Controls.Add(this.tboxSaleSubtotal);
            this.grpSaleTotals.Location = new System.Drawing.Point(15, 338);
            this.grpSaleTotals.Name = "grpSaleTotals";
            this.grpSaleTotals.Size = new System.Drawing.Size(200, 103);
            this.grpSaleTotals.TabIndex = 23;
            this.grpSaleTotals.TabStop = false;
            this.grpSaleTotals.Text = "Totals";
            // 
            // lblSalesTotal
            // 
            this.lblSalesTotal.AutoSize = true;
            this.lblSalesTotal.Location = new System.Drawing.Point(6, 74);
            this.lblSalesTotal.Name = "lblSalesTotal";
            this.lblSalesTotal.Size = new System.Drawing.Size(61, 13);
            this.lblSalesTotal.TabIndex = 5;
            this.lblSalesTotal.Text = "Total Price:";
            // 
            // tboxSalesTotal
            // 
            this.tboxSalesTotal.Location = new System.Drawing.Point(124, 71);
            this.tboxSalesTotal.Name = "tboxSalesTotal";
            this.tboxSalesTotal.ReadOnly = true;
            this.tboxSalesTotal.Size = new System.Drawing.Size(70, 20);
            this.tboxSalesTotal.TabIndex = 4;
            // 
            // lblSalesTax
            // 
            this.lblSalesTax.AutoSize = true;
            this.lblSalesTax.Location = new System.Drawing.Point(6, 48);
            this.lblSalesTax.Name = "lblSalesTax";
            this.lblSalesTax.Size = new System.Drawing.Size(55, 13);
            this.lblSalesTax.TabIndex = 3;
            this.lblSalesTax.Text = "Tax Total:";
            // 
            // tboxTaxTotal
            // 
            this.tboxTaxTotal.Location = new System.Drawing.Point(124, 45);
            this.tboxTaxTotal.Name = "tboxTaxTotal";
            this.tboxTaxTotal.ReadOnly = true;
            this.tboxTaxTotal.Size = new System.Drawing.Size(70, 20);
            this.tboxTaxTotal.TabIndex = 2;
            // 
            // lblSaleSubtotal
            // 
            this.lblSaleSubtotal.AutoSize = true;
            this.lblSaleSubtotal.Location = new System.Drawing.Point(6, 22);
            this.lblSaleSubtotal.Name = "lblSaleSubtotal";
            this.lblSaleSubtotal.Size = new System.Drawing.Size(53, 13);
            this.lblSaleSubtotal.TabIndex = 1;
            this.lblSaleSubtotal.Text = "SubTotal:";
            // 
            // tboxSaleSubtotal
            // 
            this.tboxSaleSubtotal.Location = new System.Drawing.Point(124, 19);
            this.tboxSaleSubtotal.Name = "tboxSaleSubtotal";
            this.tboxSaleSubtotal.ReadOnly = true;
            this.tboxSaleSubtotal.Size = new System.Drawing.Size(70, 20);
            this.tboxSaleSubtotal.TabIndex = 0;
            // 
            // tboxSaleDescription
            // 
            this.tboxSaleDescription.Location = new System.Drawing.Point(87, 32);
            this.tboxSaleDescription.Name = "tboxSaleDescription";
            this.tboxSaleDescription.Size = new System.Drawing.Size(353, 20);
            this.tboxSaleDescription.TabIndex = 22;
            // 
            // lblSaleDescription
            // 
            this.lblSaleDescription.AutoSize = true;
            this.lblSaleDescription.Location = new System.Drawing.Point(12, 35);
            this.lblSaleDescription.Name = "lblSaleDescription";
            this.lblSaleDescription.Size = new System.Drawing.Size(62, 13);
            this.lblSaleDescription.TabIndex = 21;
            this.lblSaleDescription.Text = "Sale Notes:";
            // 
            // grpAllProducts
            // 
            this.grpAllProducts.Controls.Add(this.tboxProductSearch);
            this.grpAllProducts.Controls.Add(this.lblProductSearch);
            this.grpAllProducts.Controls.Add(this.btnAddProductToItems);
            this.grpAllProducts.Controls.Add(this.listAllProducts);
            this.grpAllProducts.Location = new System.Drawing.Point(201, 90);
            this.grpAllProducts.Name = "grpAllProducts";
            this.grpAllProducts.Size = new System.Drawing.Size(245, 242);
            this.grpAllProducts.TabIndex = 20;
            this.grpAllProducts.TabStop = false;
            this.grpAllProducts.Text = "Products";
            // 
            // tboxProductSearch
            // 
            this.tboxProductSearch.Location = new System.Drawing.Point(86, 212);
            this.tboxProductSearch.Name = "tboxProductSearch";
            this.tboxProductSearch.Size = new System.Drawing.Size(153, 20);
            this.tboxProductSearch.TabIndex = 3;
            // 
            // lblProductSearch
            // 
            this.lblProductSearch.AutoSize = true;
            this.lblProductSearch.Location = new System.Drawing.Point(38, 216);
            this.lblProductSearch.Name = "lblProductSearch";
            this.lblProductSearch.Size = new System.Drawing.Size(44, 13);
            this.lblProductSearch.TabIndex = 2;
            this.lblProductSearch.Text = "Search:";
            // 
            // btnAddProductToItems
            // 
            this.btnAddProductToItems.Location = new System.Drawing.Point(6, 84);
            this.btnAddProductToItems.Name = "btnAddProductToItems";
            this.btnAddProductToItems.Size = new System.Drawing.Size(29, 58);
            this.btnAddProductToItems.TabIndex = 1;
            this.btnAddProductToItems.Text = "←";
            this.btnAddProductToItems.UseVisualStyleBackColor = true;
            // 
            // listAllProducts
            // 
            this.listAllProducts.FormattingEnabled = true;
            this.listAllProducts.Location = new System.Drawing.Point(41, 19);
            this.listAllProducts.Name = "listAllProducts";
            this.listAllProducts.Size = new System.Drawing.Size(198, 186);
            this.listAllProducts.TabIndex = 0;
            // 
            // grpSaleItems
            // 
            this.grpSaleItems.Controls.Add(this.btnRemoveSaleItem);
            this.grpSaleItems.Controls.Add(this.listAllSaleItems);
            this.grpSaleItems.Location = new System.Drawing.Point(15, 90);
            this.grpSaleItems.Name = "grpSaleItems";
            this.grpSaleItems.Size = new System.Drawing.Size(180, 242);
            this.grpSaleItems.TabIndex = 19;
            this.grpSaleItems.TabStop = false;
            this.grpSaleItems.Text = "Line Items";
            // 
            // btnRemoveSaleItem
            // 
            this.btnRemoveSaleItem.Location = new System.Drawing.Point(99, 211);
            this.btnRemoveSaleItem.Name = "btnRemoveSaleItem";
            this.btnRemoveSaleItem.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveSaleItem.TabIndex = 1;
            this.btnRemoveSaleItem.Text = "Remove";
            this.btnRemoveSaleItem.UseVisualStyleBackColor = true;
            // 
            // listAllSaleItems
            // 
            this.listAllSaleItems.FormattingEnabled = true;
            this.listAllSaleItems.Location = new System.Drawing.Point(6, 19);
            this.listAllSaleItems.Name = "listAllSaleItems";
            this.listAllSaleItems.Size = new System.Drawing.Size(168, 186);
            this.listAllSaleItems.TabIndex = 0;
            // 
            // tboxSaleDate
            // 
            this.tboxSaleDate.Location = new System.Drawing.Point(163, 6);
            this.tboxSaleDate.Name = "tboxSaleDate";
            this.tboxSaleDate.ReadOnly = true;
            this.tboxSaleDate.Size = new System.Drawing.Size(77, 20);
            this.tboxSaleDate.TabIndex = 18;
            // 
            // lblSaleDate
            // 
            this.lblSaleDate.AutoSize = true;
            this.lblSaleDate.Location = new System.Drawing.Point(88, 9);
            this.lblSaleDate.Name = "lblSaleDate";
            this.lblSaleDate.Size = new System.Drawing.Size(69, 13);
            this.lblSaleDate.TabIndex = 17;
            this.lblSaleDate.Text = "Date of Sale:";
            // 
            // tboxSaleId
            // 
            this.tboxSaleId.Location = new System.Drawing.Point(39, 6);
            this.tboxSaleId.Name = "tboxSaleId";
            this.tboxSaleId.ReadOnly = true;
            this.tboxSaleId.Size = new System.Drawing.Size(43, 20);
            this.tboxSaleId.TabIndex = 16;
            // 
            // lblSaleId
            // 
            this.lblSaleId.AutoSize = true;
            this.lblSaleId.Location = new System.Drawing.Point(12, 9);
            this.lblSaleId.Name = "lblSaleId";
            this.lblSaleId.Size = new System.Drawing.Size(21, 13);
            this.lblSaleId.TabIndex = 15;
            this.lblSaleId.Text = "ID:";
            // 
            // grpModifyInfo
            // 
            this.grpModifyInfo.Controls.Add(this.lblLastUpdatedByValue);
            this.grpModifyInfo.Controls.Add(this.lblDateLastUpdatedValue);
            this.grpModifyInfo.Controls.Add(this.lblDateCreatedValue);
            this.grpModifyInfo.Controls.Add(this.lblCreatedByValue);
            this.grpModifyInfo.Controls.Add(this.lblDateLastUpdated);
            this.grpModifyInfo.Controls.Add(this.lblLastUpdatedBy);
            this.grpModifyInfo.Controls.Add(this.lblDateCreated);
            this.grpModifyInfo.Controls.Add(this.lblCreatedBy);
            this.grpModifyInfo.Location = new System.Drawing.Point(15, 447);
            this.grpModifyInfo.Name = "grpModifyInfo";
            this.grpModifyInfo.Size = new System.Drawing.Size(202, 100);
            this.grpModifyInfo.TabIndex = 31;
            this.grpModifyInfo.TabStop = false;
            // 
            // lblLastUpdatedByValue
            // 
            this.lblLastUpdatedByValue.AutoSize = true;
            this.lblLastUpdatedByValue.Location = new System.Drawing.Point(101, 58);
            this.lblLastUpdatedByValue.Name = "lblLastUpdatedByValue";
            this.lblLastUpdatedByValue.Size = new System.Drawing.Size(37, 13);
            this.lblLastUpdatedByValue.TabIndex = 7;
            this.lblLastUpdatedByValue.Text = "USER";
            // 
            // lblDateLastUpdatedValue
            // 
            this.lblDateLastUpdatedValue.AutoSize = true;
            this.lblDateLastUpdatedValue.Location = new System.Drawing.Point(112, 79);
            this.lblDateLastUpdatedValue.Name = "lblDateLastUpdatedValue";
            this.lblDateLastUpdatedValue.Size = new System.Drawing.Size(65, 13);
            this.lblDateLastUpdatedValue.TabIndex = 6;
            this.lblDateLastUpdatedValue.Text = "12/31/2021";
            // 
            // lblDateCreatedValue
            // 
            this.lblDateCreatedValue.AutoSize = true;
            this.lblDateCreatedValue.Location = new System.Drawing.Point(85, 37);
            this.lblDateCreatedValue.Name = "lblDateCreatedValue";
            this.lblDateCreatedValue.Size = new System.Drawing.Size(65, 13);
            this.lblDateCreatedValue.TabIndex = 5;
            this.lblDateCreatedValue.Text = "12/31/2021";
            // 
            // lblCreatedByValue
            // 
            this.lblCreatedByValue.AutoSize = true;
            this.lblCreatedByValue.Location = new System.Drawing.Point(71, 16);
            this.lblCreatedByValue.Name = "lblCreatedByValue";
            this.lblCreatedByValue.Size = new System.Drawing.Size(37, 13);
            this.lblCreatedByValue.TabIndex = 4;
            this.lblCreatedByValue.Text = "USER";
            // 
            // lblDateLastUpdated
            // 
            this.lblDateLastUpdated.AutoSize = true;
            this.lblDateLastUpdated.Location = new System.Drawing.Point(6, 79);
            this.lblDateLastUpdated.Name = "lblDateLastUpdated";
            this.lblDateLastUpdated.Size = new System.Drawing.Size(100, 13);
            this.lblDateLastUpdated.TabIndex = 3;
            this.lblDateLastUpdated.Text = "Date Last Updated:";
            // 
            // lblLastUpdatedBy
            // 
            this.lblLastUpdatedBy.AutoSize = true;
            this.lblLastUpdatedBy.Location = new System.Drawing.Point(6, 58);
            this.lblLastUpdatedBy.Name = "lblLastUpdatedBy";
            this.lblLastUpdatedBy.Size = new System.Drawing.Size(89, 13);
            this.lblLastUpdatedBy.TabIndex = 2;
            this.lblLastUpdatedBy.Text = "Last Updated By:";
            // 
            // lblDateCreated
            // 
            this.lblDateCreated.AutoSize = true;
            this.lblDateCreated.Location = new System.Drawing.Point(6, 37);
            this.lblDateCreated.Name = "lblDateCreated";
            this.lblDateCreated.Size = new System.Drawing.Size(73, 13);
            this.lblDateCreated.TabIndex = 1;
            this.lblDateCreated.Text = "Date Created:";
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Location = new System.Drawing.Point(6, 16);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(62, 13);
            this.lblCreatedBy.TabIndex = 0;
            this.lblCreatedBy.Text = "Created By:";
            // 
            // tboxSalesRep
            // 
            this.tboxSalesRep.Location = new System.Drawing.Point(317, 6);
            this.tboxSalesRep.Name = "tboxSalesRep";
            this.tboxSalesRep.ReadOnly = true;
            this.tboxSalesRep.Size = new System.Drawing.Size(123, 20);
            this.tboxSalesRep.TabIndex = 32;
            // 
            // EditSaleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 556);
            this.Controls.Add(this.btnSaleCancel);
            this.Controls.Add(this.tboxSalesRep);
            this.Controls.Add(this.btnSaleProcess);
            this.Controls.Add(this.grpModifyInfo);
            this.Controls.Add(this.btnAddNewCustomer);
            this.Controls.Add(this.cboxSalesCustomers);
            this.Controls.Add(this.lblSalesCustomer);
            this.Controls.Add(this.lblSalesRep);
            this.Controls.Add(this.grpSalePayment);
            this.Controls.Add(this.grpSaleTotals);
            this.Controls.Add(this.tboxSaleDescription);
            this.Controls.Add(this.lblSaleDescription);
            this.Controls.Add(this.grpAllProducts);
            this.Controls.Add(this.grpSaleItems);
            this.Controls.Add(this.tboxSaleDate);
            this.Controls.Add(this.lblSaleDate);
            this.Controls.Add(this.tboxSaleId);
            this.Controls.Add(this.lblSaleId);
            this.Name = "EditSaleForm";
            this.Text = "Edit Sale";
            this.grpSalePayment.ResumeLayout(false);
            this.grpSalePayment.PerformLayout();
            this.grpSaleTotals.ResumeLayout(false);
            this.grpSaleTotals.PerformLayout();
            this.grpAllProducts.ResumeLayout(false);
            this.grpAllProducts.PerformLayout();
            this.grpSaleItems.ResumeLayout(false);
            this.grpModifyInfo.ResumeLayout(false);
            this.grpModifyInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddNewCustomer;
        private System.Windows.Forms.ComboBox cboxSalesCustomers;
        private System.Windows.Forms.Label lblSalesCustomer;
        private System.Windows.Forms.Label lblSalesRep;
        private System.Windows.Forms.GroupBox grpSalePayment;
        private System.Windows.Forms.Button btnSaleCancel;
        private System.Windows.Forms.Button btnSaleProcess;
        private System.Windows.Forms.TextBox tboxSalesChangeDue;
        private System.Windows.Forms.Label lblSalesChangeDue;
        private System.Windows.Forms.TextBox tboxSalesTenderedAmount;
        private System.Windows.Forms.Label lblSalesTenderedAmount;
        private System.Windows.Forms.GroupBox grpSaleTotals;
        private System.Windows.Forms.Label lblSalesTotal;
        private System.Windows.Forms.TextBox tboxSalesTotal;
        private System.Windows.Forms.Label lblSalesTax;
        private System.Windows.Forms.TextBox tboxTaxTotal;
        private System.Windows.Forms.Label lblSaleSubtotal;
        private System.Windows.Forms.TextBox tboxSaleSubtotal;
        private System.Windows.Forms.TextBox tboxSaleDescription;
        private System.Windows.Forms.Label lblSaleDescription;
        private System.Windows.Forms.GroupBox grpAllProducts;
        private System.Windows.Forms.TextBox tboxProductSearch;
        private System.Windows.Forms.Label lblProductSearch;
        private System.Windows.Forms.Button btnAddProductToItems;
        private System.Windows.Forms.ListBox listAllProducts;
        private System.Windows.Forms.GroupBox grpSaleItems;
        private System.Windows.Forms.Button btnRemoveSaleItem;
        private System.Windows.Forms.ListBox listAllSaleItems;
        private System.Windows.Forms.TextBox tboxSaleDate;
        private System.Windows.Forms.Label lblSaleDate;
        private System.Windows.Forms.TextBox tboxSaleId;
        private System.Windows.Forms.Label lblSaleId;
        private System.Windows.Forms.GroupBox grpModifyInfo;
        private System.Windows.Forms.Label lblLastUpdatedByValue;
        private System.Windows.Forms.Label lblDateLastUpdatedValue;
        private System.Windows.Forms.Label lblDateCreatedValue;
        private System.Windows.Forms.Label lblCreatedByValue;
        private System.Windows.Forms.Label lblDateLastUpdated;
        private System.Windows.Forms.Label lblLastUpdatedBy;
        private System.Windows.Forms.Label lblDateCreated;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.TextBox tboxSalesRep;
    }
}