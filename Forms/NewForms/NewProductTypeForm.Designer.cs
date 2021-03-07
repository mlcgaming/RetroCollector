namespace RetroCollector {
    partial class NewProductTypeForm {
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
            this.lblTypeId = new System.Windows.Forms.Label();
            this.tboxTypeId = new System.Windows.Forms.TextBox();
            this.lblTypeName = new System.Windows.Forms.Label();
            this.tboxTypeName = new System.Windows.Forms.TextBox();
            this.grpModifyInfo = new System.Windows.Forms.GroupBox();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.lblDateCreated = new System.Windows.Forms.Label();
            this.lblDateLastUpdated = new System.Windows.Forms.Label();
            this.lblLastUpdatedBy = new System.Windows.Forms.Label();
            this.lblCreatedByValue = new System.Windows.Forms.Label();
            this.lblDateCreatedValue = new System.Windows.Forms.Label();
            this.lblDateLastUpdatedValue = new System.Windows.Forms.Label();
            this.lblLastUpdatedByValue = new System.Windows.Forms.Label();
            this.btnFormSave = new System.Windows.Forms.Button();
            this.btnFormCancel = new System.Windows.Forms.Button();
            this.grpModifyInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTypeId
            // 
            this.lblTypeId.AutoSize = true;
            this.lblTypeId.Location = new System.Drawing.Point(75, 28);
            this.lblTypeId.Name = "lblTypeId";
            this.lblTypeId.Size = new System.Drawing.Size(21, 13);
            this.lblTypeId.TabIndex = 0;
            this.lblTypeId.Text = "ID:";
            // 
            // tboxTypeId
            // 
            this.tboxTypeId.Location = new System.Drawing.Point(102, 25);
            this.tboxTypeId.Name = "tboxTypeId";
            this.tboxTypeId.ReadOnly = true;
            this.tboxTypeId.Size = new System.Drawing.Size(40, 20);
            this.tboxTypeId.TabIndex = 1;
            // 
            // lblTypeName
            // 
            this.lblTypeName.AutoSize = true;
            this.lblTypeName.Location = new System.Drawing.Point(12, 63);
            this.lblTypeName.Name = "lblTypeName";
            this.lblTypeName.Size = new System.Drawing.Size(38, 13);
            this.lblTypeName.TabIndex = 2;
            this.lblTypeName.Text = "Name:";
            // 
            // tboxTypeName
            // 
            this.tboxTypeName.Location = new System.Drawing.Point(56, 60);
            this.tboxTypeName.Name = "tboxTypeName";
            this.tboxTypeName.Size = new System.Drawing.Size(161, 20);
            this.tboxTypeName.TabIndex = 3;
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
            this.grpModifyInfo.Location = new System.Drawing.Point(15, 86);
            this.grpModifyInfo.Name = "grpModifyInfo";
            this.grpModifyInfo.Size = new System.Drawing.Size(202, 100);
            this.grpModifyInfo.TabIndex = 4;
            this.grpModifyInfo.TabStop = false;
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
            // lblDateCreated
            // 
            this.lblDateCreated.AutoSize = true;
            this.lblDateCreated.Location = new System.Drawing.Point(6, 37);
            this.lblDateCreated.Name = "lblDateCreated";
            this.lblDateCreated.Size = new System.Drawing.Size(73, 13);
            this.lblDateCreated.TabIndex = 1;
            this.lblDateCreated.Text = "Date Created:";
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
            // lblCreatedByValue
            // 
            this.lblCreatedByValue.AutoSize = true;
            this.lblCreatedByValue.Location = new System.Drawing.Point(71, 16);
            this.lblCreatedByValue.Name = "lblCreatedByValue";
            this.lblCreatedByValue.Size = new System.Drawing.Size(37, 13);
            this.lblCreatedByValue.TabIndex = 4;
            this.lblCreatedByValue.Text = "USER";
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
            // lblDateLastUpdatedValue
            // 
            this.lblDateLastUpdatedValue.AutoSize = true;
            this.lblDateLastUpdatedValue.Location = new System.Drawing.Point(112, 79);
            this.lblDateLastUpdatedValue.Name = "lblDateLastUpdatedValue";
            this.lblDateLastUpdatedValue.Size = new System.Drawing.Size(65, 13);
            this.lblDateLastUpdatedValue.TabIndex = 6;
            this.lblDateLastUpdatedValue.Text = "12/31/2021";
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
            // btnFormSave
            // 
            this.btnFormSave.Location = new System.Drawing.Point(15, 192);
            this.btnFormSave.Name = "btnFormSave";
            this.btnFormSave.Size = new System.Drawing.Size(75, 23);
            this.btnFormSave.TabIndex = 5;
            this.btnFormSave.Text = "Save";
            this.btnFormSave.UseVisualStyleBackColor = true;
            // 
            // btnFormCancel
            // 
            this.btnFormCancel.Location = new System.Drawing.Point(142, 192);
            this.btnFormCancel.Name = "btnFormCancel";
            this.btnFormCancel.Size = new System.Drawing.Size(75, 23);
            this.btnFormCancel.TabIndex = 6;
            this.btnFormCancel.Text = "Cancel";
            this.btnFormCancel.UseVisualStyleBackColor = true;
            // 
            // NewProductTypeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(233, 227);
            this.Controls.Add(this.btnFormCancel);
            this.Controls.Add(this.btnFormSave);
            this.Controls.Add(this.grpModifyInfo);
            this.Controls.Add(this.tboxTypeName);
            this.Controls.Add(this.lblTypeName);
            this.Controls.Add(this.tboxTypeId);
            this.Controls.Add(this.lblTypeId);
            this.Name = "NewProductTypeForm";
            this.Text = "New Product Type";
            this.grpModifyInfo.ResumeLayout(false);
            this.grpModifyInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTypeId;
        private System.Windows.Forms.TextBox tboxTypeId;
        private System.Windows.Forms.Label lblTypeName;
        private System.Windows.Forms.TextBox tboxTypeName;
        private System.Windows.Forms.GroupBox grpModifyInfo;
        private System.Windows.Forms.Label lblLastUpdatedByValue;
        private System.Windows.Forms.Label lblDateLastUpdatedValue;
        private System.Windows.Forms.Label lblDateCreatedValue;
        private System.Windows.Forms.Label lblCreatedByValue;
        private System.Windows.Forms.Label lblDateLastUpdated;
        private System.Windows.Forms.Label lblLastUpdatedBy;
        private System.Windows.Forms.Label lblDateCreated;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Button btnFormSave;
        private System.Windows.Forms.Button btnFormCancel;
    }
}