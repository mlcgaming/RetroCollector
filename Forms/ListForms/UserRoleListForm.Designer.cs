namespace RetroCollector {
    partial class UserRoleListForm {
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
            this.lblSearchNames = new System.Windows.Forms.Label();
            this.tboxSearchNames = new System.Windows.Forms.TextBox();
            this.listAllRoles = new System.Windows.Forms.ListBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblSearchNames
            // 
            this.lblSearchNames.AutoSize = true;
            this.lblSearchNames.Location = new System.Drawing.Point(12, 25);
            this.lblSearchNames.Name = "lblSearchNames";
            this.lblSearchNames.Size = new System.Drawing.Size(80, 13);
            this.lblSearchNames.TabIndex = 0;
            this.lblSearchNames.Text = "Search Names:";
            // 
            // tboxSearchNames
            // 
            this.tboxSearchNames.Location = new System.Drawing.Point(98, 22);
            this.tboxSearchNames.Name = "tboxSearchNames";
            this.tboxSearchNames.Size = new System.Drawing.Size(181, 20);
            this.tboxSearchNames.TabIndex = 1;
            // 
            // listAllRoles
            // 
            this.listAllRoles.FormattingEnabled = true;
            this.listAllRoles.Location = new System.Drawing.Point(15, 56);
            this.listAllRoles.Name = "listAllRoles";
            this.listAllRoles.Size = new System.Drawing.Size(264, 212);
            this.listAllRoles.TabIndex = 2;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(15, 274);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 3;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(204, 274);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(109, 274);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 5;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // UserRoleListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 308);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.listAllRoles);
            this.Controls.Add(this.tboxSearchNames);
            this.Controls.Add(this.lblSearchNames);
            this.Name = "UserRoleListForm";
            this.Text = "User Roles";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSearchNames;
        private System.Windows.Forms.TextBox tboxSearchNames;
        private System.Windows.Forms.ListBox listAllRoles;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
    }
}