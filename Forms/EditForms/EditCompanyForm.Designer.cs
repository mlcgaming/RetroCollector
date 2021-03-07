namespace RetroCollector {
    partial class EditCompanyForm {
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
            this.tboxCompanyName = new System.Windows.Forms.TextBox();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.tboxCompanyId = new System.Windows.Forms.TextBox();
            this.lblCompanyId = new System.Windows.Forms.Label();
            this.grpModifyInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFormCancel
            // 
            this.btnFormCancel.Location = new System.Drawing.Point(141, 179);
            this.btnFormCancel.Name = "btnFormCancel";
            this.btnFormCancel.Size = new System.Drawing.Size(75, 23);
            this.btnFormCancel.TabIndex = 20;
            this.btnFormCancel.Text = "Cancel";
            this.btnFormCancel.UseVisualStyleBackColor = true;
            // 
            // btnFormSave
            // 
            this.btnFormSave.Location = new System.Drawing.Point(14, 179);
            this.btnFormSave.Name = "btnFormSave";
            this.btnFormSave.Size = new System.Drawing.Size(75, 23);
            this.btnFormSave.TabIndex = 19;
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
            this.grpModifyInfo.Location = new System.Drawing.Point(14, 73);
            this.grpModifyInfo.Name = "grpModifyInfo";
            this.grpModifyInfo.Size = new System.Drawing.Size(202, 100);
            this.grpModifyInfo.TabIndex = 18;
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
            // tboxCompanyName
            // 
            this.tboxCompanyName.Location = new System.Drawing.Point(55, 47);
            this.tboxCompanyName.Name = "tboxCompanyName";
            this.tboxCompanyName.Size = new System.Drawing.Size(161, 20);
            this.tboxCompanyName.TabIndex = 17;
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Location = new System.Drawing.Point(11, 50);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(38, 13);
            this.lblCompanyName.TabIndex = 16;
            this.lblCompanyName.Text = "Name:";
            // 
            // tboxCompanyId
            // 
            this.tboxCompanyId.Location = new System.Drawing.Point(101, 12);
            this.tboxCompanyId.Name = "tboxCompanyId";
            this.tboxCompanyId.ReadOnly = true;
            this.tboxCompanyId.Size = new System.Drawing.Size(40, 20);
            this.tboxCompanyId.TabIndex = 15;
            // 
            // lblCompanyId
            // 
            this.lblCompanyId.AutoSize = true;
            this.lblCompanyId.Location = new System.Drawing.Point(74, 15);
            this.lblCompanyId.Name = "lblCompanyId";
            this.lblCompanyId.Size = new System.Drawing.Size(21, 13);
            this.lblCompanyId.TabIndex = 14;
            this.lblCompanyId.Text = "ID:";
            // 
            // EditCompanyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(228, 215);
            this.Controls.Add(this.btnFormCancel);
            this.Controls.Add(this.btnFormSave);
            this.Controls.Add(this.grpModifyInfo);
            this.Controls.Add(this.tboxCompanyName);
            this.Controls.Add(this.lblCompanyName);
            this.Controls.Add(this.tboxCompanyId);
            this.Controls.Add(this.lblCompanyId);
            this.Name = "EditCompanyForm";
            this.Text = "Edit Company";
            this.grpModifyInfo.ResumeLayout(false);
            this.grpModifyInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
        private System.Windows.Forms.TextBox tboxCompanyName;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.TextBox tboxCompanyId;
        private System.Windows.Forms.Label lblCompanyId;
    }
}