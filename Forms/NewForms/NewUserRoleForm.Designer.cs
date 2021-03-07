namespace RetroCollector {
    partial class NewUserRoleForm {
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
            this.lblUserRoleId = new System.Windows.Forms.Label();
            this.tboxUserRoleId = new System.Windows.Forms.TextBox();
            this.lblUserRoleName = new System.Windows.Forms.Label();
            this.tboxUserRoleName = new System.Windows.Forms.TextBox();
            this.tboxUserRoleDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpUserRolePermissions = new System.Windows.Forms.GroupBox();
            this.checkAllowCreateProducts = new System.Windows.Forms.CheckBox();
            this.checkAllowEditProducts = new System.Windows.Forms.CheckBox();
            this.checkAllowDeleteProducts = new System.Windows.Forms.CheckBox();
            this.checkAllowDeleteUsers = new System.Windows.Forms.CheckBox();
            this.checkAllowEditUsers = new System.Windows.Forms.CheckBox();
            this.checkAllowCreateUsers = new System.Windows.Forms.CheckBox();
            this.checkAllowAdminOptions = new System.Windows.Forms.CheckBox();
            this.checkAllowDeleteRoles = new System.Windows.Forms.CheckBox();
            this.checkAllowProcessSales = new System.Windows.Forms.CheckBox();
            this.checkAllowEditRoles = new System.Windows.Forms.CheckBox();
            this.checkAllowReporting = new System.Windows.Forms.CheckBox();
            this.checkAllowCreateRoles = new System.Windows.Forms.CheckBox();
            this.btnFormCancel = new System.Windows.Forms.Button();
            this.btnFormSave = new System.Windows.Forms.Button();
            this.grpModifyInfo = new System.Windows.Forms.GroupBox();
            this.lblLastUpdatedByValue = new System.Windows.Forms.Label();
            this.lblDateLastUpdatedValue = new System.Windows.Forms.Label();
            this.lblDateCreatedValue = new System.Windows.Forms.Label();
            this.lblCreatedByValue = new System.Windows.Forms.Label();
            this.lblDateLastUpdated = new System.Windows.Forms.Label();
            this.lblLastUpdatedBy = new System.Windows.Forms.Label();
            this.lblDateCreated = new System.Windows.Forms.Label();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.grpUserRolePermissions.SuspendLayout();
            this.grpModifyInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUserRoleId
            // 
            this.lblUserRoleId.AutoSize = true;
            this.lblUserRoleId.Location = new System.Drawing.Point(12, 25);
            this.lblUserRoleId.Name = "lblUserRoleId";
            this.lblUserRoleId.Size = new System.Drawing.Size(21, 13);
            this.lblUserRoleId.TabIndex = 0;
            this.lblUserRoleId.Text = "ID:";
            // 
            // tboxUserRoleId
            // 
            this.tboxUserRoleId.Location = new System.Drawing.Point(39, 22);
            this.tboxUserRoleId.Name = "tboxUserRoleId";
            this.tboxUserRoleId.ReadOnly = true;
            this.tboxUserRoleId.Size = new System.Drawing.Size(37, 20);
            this.tboxUserRoleId.TabIndex = 1;
            // 
            // lblUserRoleName
            // 
            this.lblUserRoleName.AutoSize = true;
            this.lblUserRoleName.Location = new System.Drawing.Point(91, 25);
            this.lblUserRoleName.Name = "lblUserRoleName";
            this.lblUserRoleName.Size = new System.Drawing.Size(38, 13);
            this.lblUserRoleName.TabIndex = 2;
            this.lblUserRoleName.Text = "Name:";
            // 
            // tboxUserRoleName
            // 
            this.tboxUserRoleName.Location = new System.Drawing.Point(135, 22);
            this.tboxUserRoleName.Name = "tboxUserRoleName";
            this.tboxUserRoleName.Size = new System.Drawing.Size(129, 20);
            this.tboxUserRoleName.TabIndex = 3;
            // 
            // tboxUserRoleDescription
            // 
            this.tboxUserRoleDescription.Location = new System.Drawing.Point(81, 50);
            this.tboxUserRoleDescription.Name = "tboxUserRoleDescription";
            this.tboxUserRoleDescription.Size = new System.Drawing.Size(183, 20);
            this.tboxUserRoleDescription.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Description:";
            // 
            // grpUserRolePermissions
            // 
            this.grpUserRolePermissions.Controls.Add(this.checkAllowAdminOptions);
            this.grpUserRolePermissions.Controls.Add(this.checkAllowDeleteRoles);
            this.grpUserRolePermissions.Controls.Add(this.checkAllowProcessSales);
            this.grpUserRolePermissions.Controls.Add(this.checkAllowEditRoles);
            this.grpUserRolePermissions.Controls.Add(this.checkAllowReporting);
            this.grpUserRolePermissions.Controls.Add(this.checkAllowCreateRoles);
            this.grpUserRolePermissions.Controls.Add(this.checkAllowDeleteUsers);
            this.grpUserRolePermissions.Controls.Add(this.checkAllowDeleteProducts);
            this.grpUserRolePermissions.Controls.Add(this.checkAllowEditUsers);
            this.grpUserRolePermissions.Controls.Add(this.checkAllowEditProducts);
            this.grpUserRolePermissions.Controls.Add(this.checkAllowCreateUsers);
            this.grpUserRolePermissions.Controls.Add(this.checkAllowCreateProducts);
            this.grpUserRolePermissions.Location = new System.Drawing.Point(15, 76);
            this.grpUserRolePermissions.Name = "grpUserRolePermissions";
            this.grpUserRolePermissions.Size = new System.Drawing.Size(249, 166);
            this.grpUserRolePermissions.TabIndex = 6;
            this.grpUserRolePermissions.TabStop = false;
            this.grpUserRolePermissions.Text = "Permissions";
            // 
            // checkAllowCreateProducts
            // 
            this.checkAllowCreateProducts.AutoSize = true;
            this.checkAllowCreateProducts.Location = new System.Drawing.Point(14, 23);
            this.checkAllowCreateProducts.Name = "checkAllowCreateProducts";
            this.checkAllowCreateProducts.Size = new System.Drawing.Size(102, 17);
            this.checkAllowCreateProducts.TabIndex = 0;
            this.checkAllowCreateProducts.Text = "Create Products";
            this.checkAllowCreateProducts.UseVisualStyleBackColor = true;
            // 
            // checkAllowEditProducts
            // 
            this.checkAllowEditProducts.AutoSize = true;
            this.checkAllowEditProducts.Location = new System.Drawing.Point(14, 46);
            this.checkAllowEditProducts.Name = "checkAllowEditProducts";
            this.checkAllowEditProducts.Size = new System.Drawing.Size(89, 17);
            this.checkAllowEditProducts.TabIndex = 1;
            this.checkAllowEditProducts.Text = "Edit Products";
            this.checkAllowEditProducts.UseVisualStyleBackColor = true;
            // 
            // checkAllowDeleteProducts
            // 
            this.checkAllowDeleteProducts.AutoSize = true;
            this.checkAllowDeleteProducts.Location = new System.Drawing.Point(14, 69);
            this.checkAllowDeleteProducts.Name = "checkAllowDeleteProducts";
            this.checkAllowDeleteProducts.Size = new System.Drawing.Size(102, 17);
            this.checkAllowDeleteProducts.TabIndex = 2;
            this.checkAllowDeleteProducts.Text = "Delete Products";
            this.checkAllowDeleteProducts.UseVisualStyleBackColor = true;
            // 
            // checkAllowDeleteUsers
            // 
            this.checkAllowDeleteUsers.AutoSize = true;
            this.checkAllowDeleteUsers.Location = new System.Drawing.Point(14, 138);
            this.checkAllowDeleteUsers.Name = "checkAllowDeleteUsers";
            this.checkAllowDeleteUsers.Size = new System.Drawing.Size(87, 17);
            this.checkAllowDeleteUsers.TabIndex = 9;
            this.checkAllowDeleteUsers.Text = "Delete Users";
            this.checkAllowDeleteUsers.UseVisualStyleBackColor = true;
            // 
            // checkAllowEditUsers
            // 
            this.checkAllowEditUsers.AutoSize = true;
            this.checkAllowEditUsers.Location = new System.Drawing.Point(14, 115);
            this.checkAllowEditUsers.Name = "checkAllowEditUsers";
            this.checkAllowEditUsers.Size = new System.Drawing.Size(74, 17);
            this.checkAllowEditUsers.TabIndex = 8;
            this.checkAllowEditUsers.Text = "Edit Users";
            this.checkAllowEditUsers.UseVisualStyleBackColor = true;
            // 
            // checkAllowCreateUsers
            // 
            this.checkAllowCreateUsers.AutoSize = true;
            this.checkAllowCreateUsers.Location = new System.Drawing.Point(14, 92);
            this.checkAllowCreateUsers.Name = "checkAllowCreateUsers";
            this.checkAllowCreateUsers.Size = new System.Drawing.Size(87, 17);
            this.checkAllowCreateUsers.TabIndex = 7;
            this.checkAllowCreateUsers.Text = "Create Users";
            this.checkAllowCreateUsers.UseVisualStyleBackColor = true;
            // 
            // checkAllowAdminOptions
            // 
            this.checkAllowAdminOptions.AutoSize = true;
            this.checkAllowAdminOptions.Location = new System.Drawing.Point(141, 138);
            this.checkAllowAdminOptions.Name = "checkAllowAdminOptions";
            this.checkAllowAdminOptions.Size = new System.Drawing.Size(88, 17);
            this.checkAllowAdminOptions.TabIndex = 15;
            this.checkAllowAdminOptions.Text = "Global Admin";
            this.checkAllowAdminOptions.UseVisualStyleBackColor = true;
            // 
            // checkAllowDeleteRoles
            // 
            this.checkAllowDeleteRoles.AutoSize = true;
            this.checkAllowDeleteRoles.Location = new System.Drawing.Point(141, 69);
            this.checkAllowDeleteRoles.Name = "checkAllowDeleteRoles";
            this.checkAllowDeleteRoles.Size = new System.Drawing.Size(87, 17);
            this.checkAllowDeleteRoles.TabIndex = 12;
            this.checkAllowDeleteRoles.Text = "Delete Roles";
            this.checkAllowDeleteRoles.UseVisualStyleBackColor = true;
            // 
            // checkAllowProcessSales
            // 
            this.checkAllowProcessSales.AutoSize = true;
            this.checkAllowProcessSales.Location = new System.Drawing.Point(141, 115);
            this.checkAllowProcessSales.Name = "checkAllowProcessSales";
            this.checkAllowProcessSales.Size = new System.Drawing.Size(93, 17);
            this.checkAllowProcessSales.TabIndex = 14;
            this.checkAllowProcessSales.Text = "Process Sales";
            this.checkAllowProcessSales.UseVisualStyleBackColor = true;
            // 
            // checkAllowEditRoles
            // 
            this.checkAllowEditRoles.AutoSize = true;
            this.checkAllowEditRoles.Location = new System.Drawing.Point(141, 46);
            this.checkAllowEditRoles.Name = "checkAllowEditRoles";
            this.checkAllowEditRoles.Size = new System.Drawing.Size(74, 17);
            this.checkAllowEditRoles.TabIndex = 11;
            this.checkAllowEditRoles.Text = "Edit Roles";
            this.checkAllowEditRoles.UseVisualStyleBackColor = true;
            // 
            // checkAllowReporting
            // 
            this.checkAllowReporting.AutoSize = true;
            this.checkAllowReporting.Location = new System.Drawing.Point(141, 92);
            this.checkAllowReporting.Name = "checkAllowReporting";
            this.checkAllowReporting.Size = new System.Drawing.Size(100, 17);
            this.checkAllowReporting.TabIndex = 13;
            this.checkAllowReporting.Text = "Allow Reporting";
            this.checkAllowReporting.UseVisualStyleBackColor = true;
            // 
            // checkAllowCreateRoles
            // 
            this.checkAllowCreateRoles.AutoSize = true;
            this.checkAllowCreateRoles.Location = new System.Drawing.Point(141, 23);
            this.checkAllowCreateRoles.Name = "checkAllowCreateRoles";
            this.checkAllowCreateRoles.Size = new System.Drawing.Size(87, 17);
            this.checkAllowCreateRoles.TabIndex = 10;
            this.checkAllowCreateRoles.Text = "Create Roles";
            this.checkAllowCreateRoles.UseVisualStyleBackColor = true;
            // 
            // btnFormCancel
            // 
            this.btnFormCancel.Location = new System.Drawing.Point(166, 354);
            this.btnFormCancel.Name = "btnFormCancel";
            this.btnFormCancel.Size = new System.Drawing.Size(75, 23);
            this.btnFormCancel.TabIndex = 44;
            this.btnFormCancel.Text = "Cancel";
            this.btnFormCancel.UseVisualStyleBackColor = true;
            // 
            // btnFormSave
            // 
            this.btnFormSave.Location = new System.Drawing.Point(39, 354);
            this.btnFormSave.Name = "btnFormSave";
            this.btnFormSave.Size = new System.Drawing.Size(75, 23);
            this.btnFormSave.TabIndex = 43;
            this.btnFormSave.Text = "Save";
            this.btnFormSave.UseVisualStyleBackColor = true;
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
            this.grpModifyInfo.Location = new System.Drawing.Point(39, 248);
            this.grpModifyInfo.Name = "grpModifyInfo";
            this.grpModifyInfo.Size = new System.Drawing.Size(202, 100);
            this.grpModifyInfo.TabIndex = 42;
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
            // NewUserRoleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 389);
            this.Controls.Add(this.btnFormCancel);
            this.Controls.Add(this.btnFormSave);
            this.Controls.Add(this.grpModifyInfo);
            this.Controls.Add(this.grpUserRolePermissions);
            this.Controls.Add(this.tboxUserRoleDescription);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tboxUserRoleName);
            this.Controls.Add(this.lblUserRoleName);
            this.Controls.Add(this.tboxUserRoleId);
            this.Controls.Add(this.lblUserRoleId);
            this.Name = "NewUserRoleForm";
            this.Text = "New User Role";
            this.grpUserRolePermissions.ResumeLayout(false);
            this.grpUserRolePermissions.PerformLayout();
            this.grpModifyInfo.ResumeLayout(false);
            this.grpModifyInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUserRoleId;
        private System.Windows.Forms.TextBox tboxUserRoleId;
        private System.Windows.Forms.Label lblUserRoleName;
        private System.Windows.Forms.TextBox tboxUserRoleName;
        private System.Windows.Forms.TextBox tboxUserRoleDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpUserRolePermissions;
        private System.Windows.Forms.CheckBox checkAllowAdminOptions;
        private System.Windows.Forms.CheckBox checkAllowDeleteRoles;
        private System.Windows.Forms.CheckBox checkAllowProcessSales;
        private System.Windows.Forms.CheckBox checkAllowEditRoles;
        private System.Windows.Forms.CheckBox checkAllowReporting;
        private System.Windows.Forms.CheckBox checkAllowCreateRoles;
        private System.Windows.Forms.CheckBox checkAllowDeleteUsers;
        private System.Windows.Forms.CheckBox checkAllowDeleteProducts;
        private System.Windows.Forms.CheckBox checkAllowEditUsers;
        private System.Windows.Forms.CheckBox checkAllowEditProducts;
        private System.Windows.Forms.CheckBox checkAllowCreateUsers;
        private System.Windows.Forms.CheckBox checkAllowCreateProducts;
        private System.Windows.Forms.Button btnFormCancel;
        private System.Windows.Forms.Button btnFormSave;
        private System.Windows.Forms.GroupBox grpModifyInfo;
        private System.Windows.Forms.Label lblLastUpdatedByValue;
        private System.Windows.Forms.Label lblDateLastUpdatedValue;
        private System.Windows.Forms.Label lblDateCreatedValue;
        private System.Windows.Forms.Label lblCreatedByValue;
        private System.Windows.Forms.Label lblDateLastUpdated;
        private System.Windows.Forms.Label lblLastUpdatedBy;
        private System.Windows.Forms.Label lblDateCreated;
        private System.Windows.Forms.Label lblCreatedBy;
    }
}