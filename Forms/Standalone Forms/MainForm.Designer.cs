
namespace RetroCollector {
    partial class MainForm {
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
            this.grpProducts = new System.Windows.Forms.GroupBox();
            this.cboxProductType = new System.Windows.Forms.ComboBox();
            this.btnProductEdit = new System.Windows.Forms.Button();
            this.btnProductAdd = new System.Windows.Forms.Button();
            this.btnProductDelete = new System.Windows.Forms.Button();
            this.listProducts = new System.Windows.Forms.ListBox();
            this.lblSearchItems = new System.Windows.Forms.Label();
            this.tboxSearchItems = new System.Windows.Forms.TextBox();
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.programSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesByDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesByRepToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productsByCompanyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grpStats = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tboxTotalInventoryValue = new System.Windows.Forms.TextBox();
            this.lblTotalInventoryValue = new System.Windows.Forms.Label();
            this.tboxTotalPeripheralValue = new System.Windows.Forms.TextBox();
            this.tboxTotalMerchValue = new System.Windows.Forms.TextBox();
            this.lblTotalMerchValue = new System.Windows.Forms.Label();
            this.lblTotalPeripheralValue = new System.Windows.Forms.Label();
            this.tboxTotalGameValue = new System.Windows.Forms.TextBox();
            this.tboxTotalConsoleValue = new System.Windows.Forms.TextBox();
            this.lblConsoleValue = new System.Windows.Forms.Label();
            this.lblGamesTotal = new System.Windows.Forms.Label();
            this.grpControls = new System.Windows.Forms.GroupBox();
            this.btnControlSales = new System.Windows.Forms.Button();
            this.btnControlConsoles = new System.Windows.Forms.Button();
            this.btnControlCompanies = new System.Windows.Forms.Button();
            this.btnControlCustomers = new System.Windows.Forms.Button();
            this.btnControlUser = new System.Windows.Forms.Button();
            this.btnControlProduct = new System.Windows.Forms.Button();
            this.grpProducts.SuspendLayout();
            this.menuMain.SuspendLayout();
            this.grpStats.SuspendLayout();
            this.grpControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpProducts
            // 
            this.grpProducts.Controls.Add(this.cboxProductType);
            this.grpProducts.Controls.Add(this.btnProductEdit);
            this.grpProducts.Controls.Add(this.btnProductAdd);
            this.grpProducts.Controls.Add(this.btnProductDelete);
            this.grpProducts.Controls.Add(this.listProducts);
            this.grpProducts.Controls.Add(this.lblSearchItems);
            this.grpProducts.Controls.Add(this.tboxSearchItems);
            this.grpProducts.Location = new System.Drawing.Point(12, 34);
            this.grpProducts.Name = "grpProducts";
            this.grpProducts.Size = new System.Drawing.Size(321, 331);
            this.grpProducts.TabIndex = 0;
            this.grpProducts.TabStop = false;
            // 
            // cboxProductType
            // 
            this.cboxProductType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxProductType.FormattingEnabled = true;
            this.cboxProductType.Location = new System.Drawing.Point(6, 0);
            this.cboxProductType.Name = "cboxProductType";
            this.cboxProductType.Size = new System.Drawing.Size(121, 21);
            this.cboxProductType.TabIndex = 6;
            // 
            // btnProductEdit
            // 
            this.btnProductEdit.Location = new System.Drawing.Point(128, 302);
            this.btnProductEdit.Name = "btnProductEdit";
            this.btnProductEdit.Size = new System.Drawing.Size(75, 23);
            this.btnProductEdit.TabIndex = 5;
            this.btnProductEdit.Text = "Edit";
            this.btnProductEdit.UseVisualStyleBackColor = true;
            // 
            // btnProductAdd
            // 
            this.btnProductAdd.Location = new System.Drawing.Point(6, 302);
            this.btnProductAdd.Name = "btnProductAdd";
            this.btnProductAdd.Size = new System.Drawing.Size(75, 23);
            this.btnProductAdd.TabIndex = 4;
            this.btnProductAdd.Text = "New";
            this.btnProductAdd.UseVisualStyleBackColor = true;
            // 
            // btnProductDelete
            // 
            this.btnProductDelete.Location = new System.Drawing.Point(240, 302);
            this.btnProductDelete.Name = "btnProductDelete";
            this.btnProductDelete.Size = new System.Drawing.Size(75, 23);
            this.btnProductDelete.TabIndex = 3;
            this.btnProductDelete.Text = "Delete";
            this.btnProductDelete.UseVisualStyleBackColor = true;
            // 
            // listProducts
            // 
            this.listProducts.FormattingEnabled = true;
            this.listProducts.Location = new System.Drawing.Point(6, 45);
            this.listProducts.Name = "listProducts";
            this.listProducts.Size = new System.Drawing.Size(309, 251);
            this.listProducts.TabIndex = 2;
            // 
            // lblSearchItems
            // 
            this.lblSearchItems.AutoSize = true;
            this.lblSearchItems.Location = new System.Drawing.Point(112, 22);
            this.lblSearchItems.Name = "lblSearchItems";
            this.lblSearchItems.Size = new System.Drawing.Size(44, 13);
            this.lblSearchItems.TabIndex = 1;
            this.lblSearchItems.Text = "Search:";
            // 
            // tboxSearchItems
            // 
            this.tboxSearchItems.Location = new System.Drawing.Point(162, 19);
            this.tboxSearchItems.Name = "tboxSearchItems";
            this.tboxSearchItems.Size = new System.Drawing.Size(153, 20);
            this.tboxSearchItems.TabIndex = 0;
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminToolStripMenuItem,
            this.reportingToolStripMenuItem});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(582, 24);
            this.menuMain.TabIndex = 1;
            this.menuMain.Text = "menuStrip1";
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.databaseSettingsToolStripMenuItem,
            this.programSettingsToolStripMenuItem});
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.adminToolStripMenuItem.Text = "Admin";
            // 
            // databaseSettingsToolStripMenuItem
            // 
            this.databaseSettingsToolStripMenuItem.Name = "databaseSettingsToolStripMenuItem";
            this.databaseSettingsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.databaseSettingsToolStripMenuItem.Text = "Database Settings";
            // 
            // programSettingsToolStripMenuItem
            // 
            this.programSettingsToolStripMenuItem.Name = "programSettingsToolStripMenuItem";
            this.programSettingsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.programSettingsToolStripMenuItem.Text = "Program Settings";
            // 
            // reportingToolStripMenuItem
            // 
            this.reportingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salesByDateToolStripMenuItem,
            this.salesByRepToolStripMenuItem,
            this.productsByCompanyToolStripMenuItem});
            this.reportingToolStripMenuItem.Name = "reportingToolStripMenuItem";
            this.reportingToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.reportingToolStripMenuItem.Text = "Reporting";
            // 
            // salesByDateToolStripMenuItem
            // 
            this.salesByDateToolStripMenuItem.Name = "salesByDateToolStripMenuItem";
            this.salesByDateToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.salesByDateToolStripMenuItem.Text = "Sales By Date";
            // 
            // salesByRepToolStripMenuItem
            // 
            this.salesByRepToolStripMenuItem.Name = "salesByRepToolStripMenuItem";
            this.salesByRepToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.salesByRepToolStripMenuItem.Text = "Sales By Rep";
            // 
            // productsByCompanyToolStripMenuItem
            // 
            this.productsByCompanyToolStripMenuItem.Name = "productsByCompanyToolStripMenuItem";
            this.productsByCompanyToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.productsByCompanyToolStripMenuItem.Text = "Products by Company";
            // 
            // grpStats
            // 
            this.grpStats.Controls.Add(this.label1);
            this.grpStats.Controls.Add(this.tboxTotalInventoryValue);
            this.grpStats.Controls.Add(this.lblTotalInventoryValue);
            this.grpStats.Controls.Add(this.tboxTotalPeripheralValue);
            this.grpStats.Controls.Add(this.tboxTotalMerchValue);
            this.grpStats.Controls.Add(this.lblTotalMerchValue);
            this.grpStats.Controls.Add(this.lblTotalPeripheralValue);
            this.grpStats.Controls.Add(this.tboxTotalGameValue);
            this.grpStats.Controls.Add(this.tboxTotalConsoleValue);
            this.grpStats.Controls.Add(this.lblConsoleValue);
            this.grpStats.Controls.Add(this.lblGamesTotal);
            this.grpStats.Location = new System.Drawing.Point(339, 34);
            this.grpStats.Name = "grpStats";
            this.grpStats.Size = new System.Drawing.Size(227, 220);
            this.grpStats.TabIndex = 2;
            this.grpStats.TabStop = false;
            this.grpStats.Text = "Inventory Information";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 26);
            this.label1.TabIndex = 10;
            this.label1.Text = "Value refers to net profit on\r\nproducts (Price - Cost)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tboxTotalInventoryValue
            // 
            this.tboxTotalInventoryValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxTotalInventoryValue.Location = new System.Drawing.Point(128, 185);
            this.tboxTotalInventoryValue.Name = "tboxTotalInventoryValue";
            this.tboxTotalInventoryValue.ReadOnly = true;
            this.tboxTotalInventoryValue.Size = new System.Drawing.Size(89, 20);
            this.tboxTotalInventoryValue.TabIndex = 9;
            // 
            // lblTotalInventoryValue
            // 
            this.lblTotalInventoryValue.AutoSize = true;
            this.lblTotalInventoryValue.Location = new System.Drawing.Point(6, 188);
            this.lblTotalInventoryValue.Name = "lblTotalInventoryValue";
            this.lblTotalInventoryValue.Size = new System.Drawing.Size(103, 13);
            this.lblTotalInventoryValue.TabIndex = 8;
            this.lblTotalInventoryValue.Text = "Total Value (Merch):";
            // 
            // tboxTotalPeripheralValue
            // 
            this.tboxTotalPeripheralValue.Location = new System.Drawing.Point(128, 127);
            this.tboxTotalPeripheralValue.Name = "tboxTotalPeripheralValue";
            this.tboxTotalPeripheralValue.ReadOnly = true;
            this.tboxTotalPeripheralValue.Size = new System.Drawing.Size(89, 20);
            this.tboxTotalPeripheralValue.TabIndex = 7;
            // 
            // tboxTotalMerchValue
            // 
            this.tboxTotalMerchValue.Location = new System.Drawing.Point(128, 156);
            this.tboxTotalMerchValue.Name = "tboxTotalMerchValue";
            this.tboxTotalMerchValue.ReadOnly = true;
            this.tboxTotalMerchValue.Size = new System.Drawing.Size(89, 20);
            this.tboxTotalMerchValue.TabIndex = 6;
            // 
            // lblTotalMerchValue
            // 
            this.lblTotalMerchValue.AutoSize = true;
            this.lblTotalMerchValue.Location = new System.Drawing.Point(6, 159);
            this.lblTotalMerchValue.Name = "lblTotalMerchValue";
            this.lblTotalMerchValue.Size = new System.Drawing.Size(103, 13);
            this.lblTotalMerchValue.TabIndex = 5;
            this.lblTotalMerchValue.Text = "Total Value (Merch):";
            // 
            // lblTotalPeripheralValue
            // 
            this.lblTotalPeripheralValue.AutoSize = true;
            this.lblTotalPeripheralValue.Location = new System.Drawing.Point(6, 130);
            this.lblTotalPeripheralValue.Name = "lblTotalPeripheralValue";
            this.lblTotalPeripheralValue.Size = new System.Drawing.Size(120, 13);
            this.lblTotalPeripheralValue.TabIndex = 4;
            this.lblTotalPeripheralValue.Text = "Total Value (Peripheral):";
            // 
            // tboxTotalGameValue
            // 
            this.tboxTotalGameValue.Location = new System.Drawing.Point(128, 69);
            this.tboxTotalGameValue.Name = "tboxTotalGameValue";
            this.tboxTotalGameValue.ReadOnly = true;
            this.tboxTotalGameValue.Size = new System.Drawing.Size(89, 20);
            this.tboxTotalGameValue.TabIndex = 3;
            // 
            // tboxTotalConsoleValue
            // 
            this.tboxTotalConsoleValue.Location = new System.Drawing.Point(128, 98);
            this.tboxTotalConsoleValue.Name = "tboxTotalConsoleValue";
            this.tboxTotalConsoleValue.ReadOnly = true;
            this.tboxTotalConsoleValue.Size = new System.Drawing.Size(89, 20);
            this.tboxTotalConsoleValue.TabIndex = 2;
            // 
            // lblConsoleValue
            // 
            this.lblConsoleValue.AutoSize = true;
            this.lblConsoleValue.Location = new System.Drawing.Point(6, 101);
            this.lblConsoleValue.Name = "lblConsoleValue";
            this.lblConsoleValue.Size = new System.Drawing.Size(116, 13);
            this.lblConsoleValue.TabIndex = 1;
            this.lblConsoleValue.Text = "Total Value (Consoles):";
            // 
            // lblGamesTotal
            // 
            this.lblGamesTotal.AutoSize = true;
            this.lblGamesTotal.Location = new System.Drawing.Point(6, 72);
            this.lblGamesTotal.Name = "lblGamesTotal";
            this.lblGamesTotal.Size = new System.Drawing.Size(106, 13);
            this.lblGamesTotal.TabIndex = 0;
            this.lblGamesTotal.Text = "Total Value (Games):";
            // 
            // grpControls
            // 
            this.grpControls.Controls.Add(this.btnControlSales);
            this.grpControls.Controls.Add(this.btnControlConsoles);
            this.grpControls.Controls.Add(this.btnControlCompanies);
            this.grpControls.Controls.Add(this.btnControlCustomers);
            this.grpControls.Controls.Add(this.btnControlUser);
            this.grpControls.Controls.Add(this.btnControlProduct);
            this.grpControls.Location = new System.Drawing.Point(339, 259);
            this.grpControls.Name = "grpControls";
            this.grpControls.Size = new System.Drawing.Size(227, 106);
            this.grpControls.TabIndex = 3;
            this.grpControls.TabStop = false;
            this.grpControls.Text = "Controls";
            // 
            // btnControlSales
            // 
            this.btnControlSales.Location = new System.Drawing.Point(142, 77);
            this.btnControlSales.Name = "btnControlSales";
            this.btnControlSales.Size = new System.Drawing.Size(75, 23);
            this.btnControlSales.TabIndex = 5;
            this.btnControlSales.Text = "Sales";
            this.btnControlSales.UseVisualStyleBackColor = true;
            // 
            // btnControlConsoles
            // 
            this.btnControlConsoles.Location = new System.Drawing.Point(142, 48);
            this.btnControlConsoles.Name = "btnControlConsoles";
            this.btnControlConsoles.Size = new System.Drawing.Size(75, 23);
            this.btnControlConsoles.TabIndex = 4;
            this.btnControlConsoles.Text = "Consoles";
            this.btnControlConsoles.UseVisualStyleBackColor = true;
            // 
            // btnControlCompanies
            // 
            this.btnControlCompanies.Location = new System.Drawing.Point(142, 19);
            this.btnControlCompanies.Name = "btnControlCompanies";
            this.btnControlCompanies.Size = new System.Drawing.Size(75, 23);
            this.btnControlCompanies.TabIndex = 3;
            this.btnControlCompanies.Text = "Companies";
            this.btnControlCompanies.UseVisualStyleBackColor = true;
            // 
            // btnControlCustomers
            // 
            this.btnControlCustomers.Location = new System.Drawing.Point(9, 77);
            this.btnControlCustomers.Name = "btnControlCustomers";
            this.btnControlCustomers.Size = new System.Drawing.Size(75, 23);
            this.btnControlCustomers.TabIndex = 2;
            this.btnControlCustomers.Text = "Customers";
            this.btnControlCustomers.UseVisualStyleBackColor = true;
            // 
            // btnControlUser
            // 
            this.btnControlUser.Location = new System.Drawing.Point(9, 48);
            this.btnControlUser.Name = "btnControlUser";
            this.btnControlUser.Size = new System.Drawing.Size(75, 23);
            this.btnControlUser.TabIndex = 1;
            this.btnControlUser.Text = "Users";
            this.btnControlUser.UseVisualStyleBackColor = true;
            // 
            // btnControlProduct
            // 
            this.btnControlProduct.Location = new System.Drawing.Point(9, 19);
            this.btnControlProduct.Name = "btnControlProduct";
            this.btnControlProduct.Size = new System.Drawing.Size(75, 23);
            this.btnControlProduct.TabIndex = 0;
            this.btnControlProduct.Text = "Products";
            this.btnControlProduct.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 375);
            this.Controls.Add(this.grpControls);
            this.Controls.Add(this.grpStats);
            this.Controls.Add(this.grpProducts);
            this.Controls.Add(this.menuMain);
            this.MainMenuStrip = this.menuMain;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.grpProducts.ResumeLayout(false);
            this.grpProducts.PerformLayout();
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.grpStats.ResumeLayout(false);
            this.grpStats.PerformLayout();
            this.grpControls.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpProducts;
        private System.Windows.Forms.Button btnProductEdit;
        private System.Windows.Forms.Button btnProductAdd;
        private System.Windows.Forms.Button btnProductDelete;
        private System.Windows.Forms.ListBox listProducts;
        private System.Windows.Forms.Label lblSearchItems;
        private System.Windows.Forms.TextBox tboxSearchItems;
        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem databaseSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem programSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesByDateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesByRepToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productsByCompanyToolStripMenuItem;
        private System.Windows.Forms.GroupBox grpStats;
        private System.Windows.Forms.ComboBox cboxProductType;
        private System.Windows.Forms.TextBox tboxTotalInventoryValue;
        private System.Windows.Forms.Label lblTotalInventoryValue;
        private System.Windows.Forms.TextBox tboxTotalPeripheralValue;
        private System.Windows.Forms.TextBox tboxTotalMerchValue;
        private System.Windows.Forms.Label lblTotalMerchValue;
        private System.Windows.Forms.Label lblTotalPeripheralValue;
        private System.Windows.Forms.TextBox tboxTotalGameValue;
        private System.Windows.Forms.TextBox tboxTotalConsoleValue;
        private System.Windows.Forms.Label lblConsoleValue;
        private System.Windows.Forms.Label lblGamesTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpControls;
        private System.Windows.Forms.Button btnControlSales;
        private System.Windows.Forms.Button btnControlConsoles;
        private System.Windows.Forms.Button btnControlCompanies;
        private System.Windows.Forms.Button btnControlCustomers;
        private System.Windows.Forms.Button btnControlUser;
        private System.Windows.Forms.Button btnControlProduct;
    }
}

