namespace RetroCollector {
    partial class EditConsoleForm {
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
            this.lblConsoleDeveloper = new System.Windows.Forms.Label();
            this.cboxConsoleDevelopers = new System.Windows.Forms.ComboBox();
            this.btnFormCancel = new System.Windows.Forms.Button();
            this.btnFormSave = new System.Windows.Forms.Button();
            this.tboxConsoleName = new System.Windows.Forms.TextBox();
            this.lblConsoleName = new System.Windows.Forms.Label();
            this.tboxConsoleId = new System.Windows.Forms.TextBox();
            this.lblConsoleId = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblConsoleDeveloper
            // 
            this.lblConsoleDeveloper.AutoSize = true;
            this.lblConsoleDeveloper.Location = new System.Drawing.Point(14, 70);
            this.lblConsoleDeveloper.Name = "lblConsoleDeveloper";
            this.lblConsoleDeveloper.Size = new System.Drawing.Size(59, 13);
            this.lblConsoleDeveloper.TabIndex = 30;
            this.lblConsoleDeveloper.Text = "Developer:";
            // 
            // cboxConsoleDevelopers
            // 
            this.cboxConsoleDevelopers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxConsoleDevelopers.FormattingEnabled = true;
            this.cboxConsoleDevelopers.Location = new System.Drawing.Point(80, 67);
            this.cboxConsoleDevelopers.Name = "cboxConsoleDevelopers";
            this.cboxConsoleDevelopers.Size = new System.Drawing.Size(139, 21);
            this.cboxConsoleDevelopers.TabIndex = 29;
            // 
            // btnFormCancel
            // 
            this.btnFormCancel.Location = new System.Drawing.Point(144, 107);
            this.btnFormCancel.Name = "btnFormCancel";
            this.btnFormCancel.Size = new System.Drawing.Size(75, 23);
            this.btnFormCancel.TabIndex = 28;
            this.btnFormCancel.Text = "Cancel";
            this.btnFormCancel.UseVisualStyleBackColor = true;
            // 
            // btnFormSave
            // 
            this.btnFormSave.Location = new System.Drawing.Point(17, 107);
            this.btnFormSave.Name = "btnFormSave";
            this.btnFormSave.Size = new System.Drawing.Size(75, 23);
            this.btnFormSave.TabIndex = 27;
            this.btnFormSave.Text = "Save";
            this.btnFormSave.UseVisualStyleBackColor = true;
            // 
            // tboxConsoleName
            // 
            this.tboxConsoleName.Location = new System.Drawing.Point(58, 41);
            this.tboxConsoleName.Name = "tboxConsoleName";
            this.tboxConsoleName.Size = new System.Drawing.Size(161, 20);
            this.tboxConsoleName.TabIndex = 26;
            // 
            // lblConsoleName
            // 
            this.lblConsoleName.AutoSize = true;
            this.lblConsoleName.Location = new System.Drawing.Point(14, 44);
            this.lblConsoleName.Name = "lblConsoleName";
            this.lblConsoleName.Size = new System.Drawing.Size(38, 13);
            this.lblConsoleName.TabIndex = 25;
            this.lblConsoleName.Text = "Name:";
            // 
            // tboxConsoleId
            // 
            this.tboxConsoleId.Location = new System.Drawing.Point(104, 6);
            this.tboxConsoleId.Name = "tboxConsoleId";
            this.tboxConsoleId.ReadOnly = true;
            this.tboxConsoleId.Size = new System.Drawing.Size(40, 20);
            this.tboxConsoleId.TabIndex = 24;
            // 
            // lblConsoleId
            // 
            this.lblConsoleId.AutoSize = true;
            this.lblConsoleId.Location = new System.Drawing.Point(77, 9);
            this.lblConsoleId.Name = "lblConsoleId";
            this.lblConsoleId.Size = new System.Drawing.Size(21, 13);
            this.lblConsoleId.TabIndex = 23;
            this.lblConsoleId.Text = "ID:";
            // 
            // EditConsoleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 145);
            this.Controls.Add(this.lblConsoleDeveloper);
            this.Controls.Add(this.cboxConsoleDevelopers);
            this.Controls.Add(this.btnFormCancel);
            this.Controls.Add(this.btnFormSave);
            this.Controls.Add(this.tboxConsoleName);
            this.Controls.Add(this.lblConsoleName);
            this.Controls.Add(this.tboxConsoleId);
            this.Controls.Add(this.lblConsoleId);
            this.Name = "EditConsoleForm";
            this.Text = "Edit Console";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblConsoleDeveloper;
        private System.Windows.Forms.ComboBox cboxConsoleDevelopers;
        private System.Windows.Forms.Button btnFormCancel;
        private System.Windows.Forms.Button btnFormSave;
        private System.Windows.Forms.TextBox tboxConsoleName;
        private System.Windows.Forms.Label lblConsoleName;
        private System.Windows.Forms.TextBox tboxConsoleId;
        private System.Windows.Forms.Label lblConsoleId;
    }
}