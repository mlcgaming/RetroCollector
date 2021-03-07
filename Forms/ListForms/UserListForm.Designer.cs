namespace RetroCollector {
    partial class UserListForm {
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
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.listAllUsers = new System.Windows.Forms.ListBox();
            this.tboxSearchNames = new System.Windows.Forms.TextBox();
            this.lblSearchNames = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(109, 266);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 11;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(204, 266);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(15, 266);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 9;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            // 
            // listAllUsers
            // 
            this.listAllUsers.FormattingEnabled = true;
            this.listAllUsers.Location = new System.Drawing.Point(15, 48);
            this.listAllUsers.Name = "listAllUsers";
            this.listAllUsers.Size = new System.Drawing.Size(264, 212);
            this.listAllUsers.TabIndex = 8;
            // 
            // tboxSearchNames
            // 
            this.tboxSearchNames.Location = new System.Drawing.Point(98, 14);
            this.tboxSearchNames.Name = "tboxSearchNames";
            this.tboxSearchNames.Size = new System.Drawing.Size(181, 20);
            this.tboxSearchNames.TabIndex = 7;
            // 
            // lblSearchNames
            // 
            this.lblSearchNames.AutoSize = true;
            this.lblSearchNames.Location = new System.Drawing.Point(12, 17);
            this.lblSearchNames.Name = "lblSearchNames";
            this.lblSearchNames.Size = new System.Drawing.Size(80, 13);
            this.lblSearchNames.TabIndex = 6;
            this.lblSearchNames.Text = "Search Names:";
            // 
            // UserListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 302);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.listAllUsers);
            this.Controls.Add(this.tboxSearchNames);
            this.Controls.Add(this.lblSearchNames);
            this.Name = "UserListForm";
            this.Text = "UserListForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.ListBox listAllUsers;
        private System.Windows.Forms.TextBox tboxSearchNames;
        private System.Windows.Forms.Label lblSearchNames;
    }
}