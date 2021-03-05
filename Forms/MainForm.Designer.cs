
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
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.programSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesByDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesByRepToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productsByCompanyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventoryReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewProductToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editExistingProductToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editExistingUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.addNewUserRoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editExistingUserRoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewCurrentSalesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editExistingTransactionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblProductSearch = new System.Windows.Forms.Label();
            this.listAllProducts = new System.Windows.Forms.ListBox();
            this.btnProductDelete = new System.Windows.Forms.Button();
            this.btnProductAdd = new System.Windows.Forms.Button();
            this.btnProductEdit = new System.Windows.Forms.Button();
            this.grpProcessSale = new System.Windows.Forms.GroupBox();
            this.grpProducts.SuspendLayout();
            this.menuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpProducts
            // 
            this.grpProducts.Controls.Add(this.btnProductEdit);
            this.grpProducts.Controls.Add(this.btnProductAdd);
            this.grpProducts.Controls.Add(this.btnProductDelete);
            this.grpProducts.Controls.Add(this.listAllProducts);
            this.grpProducts.Controls.Add(this.lblProductSearch);
            this.grpProducts.Controls.Add(this.textBox1);
            this.grpProducts.Location = new System.Drawing.Point(287, 36);
            this.grpProducts.Name = "grpProducts";
            this.grpProducts.Size = new System.Drawing.Size(321, 331);
            this.grpProducts.TabIndex = 0;
            this.grpProducts.TabStop = false;
            this.grpProducts.Text = "Global Product List";
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataToolStripMenuItem,
            this.adminToolStripMenuItem,
            this.reportingToolStripMenuItem});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(620, 24);
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
            // reportingToolStripMenuItem
            // 
            this.reportingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salesByDateToolStripMenuItem,
            this.salesByRepToolStripMenuItem,
            this.productsByCompanyToolStripMenuItem,
            this.inventoryReportToolStripMenuItem});
            this.reportingToolStripMenuItem.Name = "reportingToolStripMenuItem";
            this.reportingToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.reportingToolStripMenuItem.Text = "Reporting";
            // 
            // dataToolStripMenuItem
            // 
            this.dataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productToolStripMenuItem,
            this.userToolStripMenuItem,
            this.salesToolStripMenuItem});
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.dataToolStripMenuItem.Text = "Data";
            // 
            // productToolStripMenuItem
            // 
            this.productToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewProductToolStripMenuItem,
            this.editExistingProductToolStripMenuItem});
            this.productToolStripMenuItem.Name = "productToolStripMenuItem";
            this.productToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.productToolStripMenuItem.Text = "Product";
            // 
            // userToolStripMenuItem
            // 
            this.userToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewUserToolStripMenuItem,
            this.editExistingUserToolStripMenuItem,
            this.toolStripSeparator1,
            this.addNewUserRoleToolStripMenuItem,
            this.editExistingUserRoleToolStripMenuItem});
            this.userToolStripMenuItem.Name = "userToolStripMenuItem";
            this.userToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.userToolStripMenuItem.Text = "User";
            // 
            // salesToolStripMenuItem
            // 
            this.salesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewCurrentSalesToolStripMenuItem,
            this.editExistingTransactionToolStripMenuItem});
            this.salesToolStripMenuItem.Name = "salesToolStripMenuItem";
            this.salesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.salesToolStripMenuItem.Text = "Sales";
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
            // inventoryReportToolStripMenuItem
            // 
            this.inventoryReportToolStripMenuItem.Name = "inventoryReportToolStripMenuItem";
            this.inventoryReportToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.inventoryReportToolStripMenuItem.Text = "Inventory Report";
            // 
            // addNewProductToolStripMenuItem
            // 
            this.addNewProductToolStripMenuItem.Name = "addNewProductToolStripMenuItem";
            this.addNewProductToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.addNewProductToolStripMenuItem.Text = "Add New Product";
            // 
            // editExistingProductToolStripMenuItem
            // 
            this.editExistingProductToolStripMenuItem.Name = "editExistingProductToolStripMenuItem";
            this.editExistingProductToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.editExistingProductToolStripMenuItem.Text = "Edit Existing Product";
            // 
            // addNewUserToolStripMenuItem
            // 
            this.addNewUserToolStripMenuItem.Name = "addNewUserToolStripMenuItem";
            this.addNewUserToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.addNewUserToolStripMenuItem.Text = "Add New User";
            // 
            // editExistingUserToolStripMenuItem
            // 
            this.editExistingUserToolStripMenuItem.Name = "editExistingUserToolStripMenuItem";
            this.editExistingUserToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.editExistingUserToolStripMenuItem.Text = "Edit Existing User";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(187, 6);
            // 
            // addNewUserRoleToolStripMenuItem
            // 
            this.addNewUserRoleToolStripMenuItem.Name = "addNewUserRoleToolStripMenuItem";
            this.addNewUserRoleToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.addNewUserRoleToolStripMenuItem.Text = "Add New User Role";
            // 
            // editExistingUserRoleToolStripMenuItem
            // 
            this.editExistingUserRoleToolStripMenuItem.Name = "editExistingUserRoleToolStripMenuItem";
            this.editExistingUserRoleToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.editExistingUserRoleToolStripMenuItem.Text = "Edit Existing User Role";
            // 
            // viewCurrentSalesToolStripMenuItem
            // 
            this.viewCurrentSalesToolStripMenuItem.Name = "viewCurrentSalesToolStripMenuItem";
            this.viewCurrentSalesToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.viewCurrentSalesToolStripMenuItem.Text = "View Current Sales";
            // 
            // editExistingTransactionToolStripMenuItem
            // 
            this.editExistingTransactionToolStripMenuItem.Name = "editExistingTransactionToolStripMenuItem";
            this.editExistingTransactionToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.editExistingTransactionToolStripMenuItem.Text = "Edit Existing Transaction";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(162, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(153, 20);
            this.textBox1.TabIndex = 0;
            // 
            // lblProductSearch
            // 
            this.lblProductSearch.AutoSize = true;
            this.lblProductSearch.Location = new System.Drawing.Point(112, 22);
            this.lblProductSearch.Name = "lblProductSearch";
            this.lblProductSearch.Size = new System.Drawing.Size(44, 13);
            this.lblProductSearch.TabIndex = 1;
            this.lblProductSearch.Text = "Search:";
            // 
            // listAllProducts
            // 
            this.listAllProducts.FormattingEnabled = true;
            this.listAllProducts.Location = new System.Drawing.Point(6, 45);
            this.listAllProducts.Name = "listAllProducts";
            this.listAllProducts.Size = new System.Drawing.Size(309, 251);
            this.listAllProducts.TabIndex = 2;
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
            // btnProductAdd
            // 
            this.btnProductAdd.Location = new System.Drawing.Point(6, 302);
            this.btnProductAdd.Name = "btnProductAdd";
            this.btnProductAdd.Size = new System.Drawing.Size(75, 23);
            this.btnProductAdd.TabIndex = 4;
            this.btnProductAdd.Text = "New..";
            this.btnProductAdd.UseVisualStyleBackColor = true;
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
            // grpProcessSale
            // 
            this.grpProcessSale.Location = new System.Drawing.Point(12, 36);
            this.grpProcessSale.Name = "grpProcessSale";
            this.grpProcessSale.Size = new System.Drawing.Size(269, 329);
            this.grpProcessSale.TabIndex = 2;
            this.grpProcessSale.TabStop = false;
            this.grpProcessSale.Text = "Sale";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 377);
            this.Controls.Add(this.grpProcessSale);
            this.Controls.Add(this.grpProducts);
            this.Controls.Add(this.menuMain);
            this.MainMenuStrip = this.menuMain;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.grpProducts.ResumeLayout(false);
            this.grpProducts.PerformLayout();
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpProducts;
        private System.Windows.Forms.Button btnProductEdit;
        private System.Windows.Forms.Button btnProductAdd;
        private System.Windows.Forms.Button btnProductDelete;
        private System.Windows.Forms.ListBox listAllProducts;
        private System.Windows.Forms.Label lblProductSearch;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem dataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewProductToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editExistingProductToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editExistingUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem addNewUserRoleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editExistingUserRoleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewCurrentSalesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editExistingTransactionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem databaseSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem programSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesByDateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesByRepToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productsByCompanyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inventoryReportToolStripMenuItem;
        private System.Windows.Forms.GroupBox grpProcessSale;
    }
}

