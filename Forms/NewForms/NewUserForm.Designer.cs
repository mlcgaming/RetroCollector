namespace RetroCollector {
    partial class NewUserForm {
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
            this.lblUserId = new System.Windows.Forms.Label();
            this.tboxUserId = new System.Windows.Forms.TextBox();
            this.lblUserFirstName = new System.Windows.Forms.Label();
            this.tboxUserFirstName = new System.Windows.Forms.TextBox();
            this.tboxUserLastName = new System.Windows.Forms.TextBox();
            this.lblUserLastName = new System.Windows.Forms.Label();
            this.lblUserLoginName = new System.Windows.Forms.Label();
            this.tboxUserLoginName = new System.Windows.Forms.TextBox();
            this.tboxUserPassword = new System.Windows.Forms.TextBox();
            this.lblUserPassword = new System.Windows.Forms.Label();
            this.lblUserRole = new System.Windows.Forms.Label();
            this.cboxUserRoles = new System.Windows.Forms.ComboBox();
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
            this.grpModifyInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUserId
            // 
            this.lblUserId.AutoSize = true;
            this.lblUserId.Location = new System.Drawing.Point(78, 17);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(21, 13);
            this.lblUserId.TabIndex = 0;
            this.lblUserId.Text = "ID:";
            // 
            // tboxUserId
            // 
            this.tboxUserId.Location = new System.Drawing.Point(105, 14);
            this.tboxUserId.Name = "tboxUserId";
            this.tboxUserId.ReadOnly = true;
            this.tboxUserId.Size = new System.Drawing.Size(38, 20);
            this.tboxUserId.TabIndex = 1;
            // 
            // lblUserFirstName
            // 
            this.lblUserFirstName.AutoSize = true;
            this.lblUserFirstName.Location = new System.Drawing.Point(12, 54);
            this.lblUserFirstName.Name = "lblUserFirstName";
            this.lblUserFirstName.Size = new System.Drawing.Size(60, 13);
            this.lblUserFirstName.TabIndex = 2;
            this.lblUserFirstName.Text = "First Name:";
            // 
            // tboxUserFirstName
            // 
            this.tboxUserFirstName.Location = new System.Drawing.Point(78, 51);
            this.tboxUserFirstName.Name = "tboxUserFirstName";
            this.tboxUserFirstName.Size = new System.Drawing.Size(153, 20);
            this.tboxUserFirstName.TabIndex = 3;
            // 
            // tboxUserLastName
            // 
            this.tboxUserLastName.Location = new System.Drawing.Point(78, 77);
            this.tboxUserLastName.Name = "tboxUserLastName";
            this.tboxUserLastName.Size = new System.Drawing.Size(153, 20);
            this.tboxUserLastName.TabIndex = 5;
            // 
            // lblUserLastName
            // 
            this.lblUserLastName.AutoSize = true;
            this.lblUserLastName.Location = new System.Drawing.Point(12, 80);
            this.lblUserLastName.Name = "lblUserLastName";
            this.lblUserLastName.Size = new System.Drawing.Size(61, 13);
            this.lblUserLastName.TabIndex = 4;
            this.lblUserLastName.Text = "Last Name:";
            // 
            // lblUserLoginName
            // 
            this.lblUserLoginName.AutoSize = true;
            this.lblUserLoginName.Location = new System.Drawing.Point(12, 129);
            this.lblUserLoginName.Name = "lblUserLoginName";
            this.lblUserLoginName.Size = new System.Drawing.Size(58, 13);
            this.lblUserLoginName.TabIndex = 6;
            this.lblUserLoginName.Text = "Username:";
            // 
            // tboxUserLoginName
            // 
            this.tboxUserLoginName.Location = new System.Drawing.Point(78, 126);
            this.tboxUserLoginName.Name = "tboxUserLoginName";
            this.tboxUserLoginName.Size = new System.Drawing.Size(153, 20);
            this.tboxUserLoginName.TabIndex = 7;
            // 
            // tboxUserPassword
            // 
            this.tboxUserPassword.Location = new System.Drawing.Point(78, 152);
            this.tboxUserPassword.Name = "tboxUserPassword";
            this.tboxUserPassword.PasswordChar = '*';
            this.tboxUserPassword.Size = new System.Drawing.Size(153, 20);
            this.tboxUserPassword.TabIndex = 9;
            // 
            // lblUserPassword
            // 
            this.lblUserPassword.AutoSize = true;
            this.lblUserPassword.Location = new System.Drawing.Point(12, 155);
            this.lblUserPassword.Name = "lblUserPassword";
            this.lblUserPassword.Size = new System.Drawing.Size(56, 13);
            this.lblUserPassword.TabIndex = 8;
            this.lblUserPassword.Text = "Password:";
            // 
            // lblUserRole
            // 
            this.lblUserRole.AutoSize = true;
            this.lblUserRole.Location = new System.Drawing.Point(12, 181);
            this.lblUserRole.Name = "lblUserRole";
            this.lblUserRole.Size = new System.Drawing.Size(57, 13);
            this.lblUserRole.TabIndex = 10;
            this.lblUserRole.Text = "User Role:";
            // 
            // cboxUserRoles
            // 
            this.cboxUserRoles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxUserRoles.FormattingEnabled = true;
            this.cboxUserRoles.Location = new System.Drawing.Point(78, 178);
            this.cboxUserRoles.Name = "cboxUserRoles";
            this.cboxUserRoles.Size = new System.Drawing.Size(153, 21);
            this.cboxUserRoles.TabIndex = 11;
            // 
            // btnFormCancel
            // 
            this.btnFormCancel.Location = new System.Drawing.Point(148, 320);
            this.btnFormCancel.Name = "btnFormCancel";
            this.btnFormCancel.Size = new System.Drawing.Size(75, 23);
            this.btnFormCancel.TabIndex = 21;
            this.btnFormCancel.Text = "Cancel";
            this.btnFormCancel.UseVisualStyleBackColor = true;
            // 
            // btnFormSave
            // 
            this.btnFormSave.Location = new System.Drawing.Point(21, 320);
            this.btnFormSave.Name = "btnFormSave";
            this.btnFormSave.Size = new System.Drawing.Size(75, 23);
            this.btnFormSave.TabIndex = 20;
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
            this.grpModifyInfo.Location = new System.Drawing.Point(21, 214);
            this.grpModifyInfo.Name = "grpModifyInfo";
            this.grpModifyInfo.Size = new System.Drawing.Size(202, 100);
            this.grpModifyInfo.TabIndex = 19;
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
            // NewUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 352);
            this.Controls.Add(this.btnFormCancel);
            this.Controls.Add(this.btnFormSave);
            this.Controls.Add(this.grpModifyInfo);
            this.Controls.Add(this.cboxUserRoles);
            this.Controls.Add(this.lblUserRole);
            this.Controls.Add(this.tboxUserPassword);
            this.Controls.Add(this.lblUserPassword);
            this.Controls.Add(this.tboxUserLoginName);
            this.Controls.Add(this.lblUserLoginName);
            this.Controls.Add(this.tboxUserLastName);
            this.Controls.Add(this.lblUserLastName);
            this.Controls.Add(this.tboxUserFirstName);
            this.Controls.Add(this.lblUserFirstName);
            this.Controls.Add(this.tboxUserId);
            this.Controls.Add(this.lblUserId);
            this.Name = "NewUserForm";
            this.Text = "New User";
            this.grpModifyInfo.ResumeLayout(false);
            this.grpModifyInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUserId;
        private System.Windows.Forms.TextBox tboxUserId;
        private System.Windows.Forms.Label lblUserFirstName;
        private System.Windows.Forms.TextBox tboxUserFirstName;
        private System.Windows.Forms.TextBox tboxUserLastName;
        private System.Windows.Forms.Label lblUserLastName;
        private System.Windows.Forms.Label lblUserLoginName;
        private System.Windows.Forms.TextBox tboxUserLoginName;
        private System.Windows.Forms.TextBox tboxUserPassword;
        private System.Windows.Forms.Label lblUserPassword;
        private System.Windows.Forms.Label lblUserRole;
        private System.Windows.Forms.ComboBox cboxUserRoles;
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