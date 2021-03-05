
namespace RetroCollector {
    partial class DBSetupForm {
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
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.lblServerName = new System.Windows.Forms.Label();
            this.tboxServerName = new System.Windows.Forms.TextBox();
            this.lblServerPort = new System.Windows.Forms.Label();
            this.tboxPort = new System.Windows.Forms.TextBox();
            this.tboxDatabase = new System.Windows.Forms.TextBox();
            this.lblDatabase = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.tboxUsername = new System.Windows.Forms.TextBox();
            this.tboxPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.btnSaveDBDetails = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormTitle.Location = new System.Drawing.Point(26, 9);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(306, 24);
            this.lblFormTitle.TabIndex = 0;
            this.lblFormTitle.Text = "Database Connection Configuration";
            // 
            // lblServerName
            // 
            this.lblServerName.AutoSize = true;
            this.lblServerName.Location = new System.Drawing.Point(12, 106);
            this.lblServerName.Name = "lblServerName";
            this.lblServerName.Size = new System.Drawing.Size(82, 13);
            this.lblServerName.TabIndex = 1;
            this.lblServerName.Text = "Server Address:";
            // 
            // tboxServerName
            // 
            this.tboxServerName.Location = new System.Drawing.Point(100, 103);
            this.tboxServerName.Name = "tboxServerName";
            this.tboxServerName.Size = new System.Drawing.Size(244, 20);
            this.tboxServerName.TabIndex = 2;
            // 
            // lblServerPort
            // 
            this.lblServerPort.AutoSize = true;
            this.lblServerPort.Location = new System.Drawing.Point(27, 152);
            this.lblServerPort.Name = "lblServerPort";
            this.lblServerPort.Size = new System.Drawing.Size(29, 13);
            this.lblServerPort.TabIndex = 3;
            this.lblServerPort.Text = "Port:";
            // 
            // tboxPort
            // 
            this.tboxPort.Location = new System.Drawing.Point(62, 149);
            this.tboxPort.Name = "tboxPort";
            this.tboxPort.Size = new System.Drawing.Size(56, 20);
            this.tboxPort.TabIndex = 4;
            // 
            // tboxDatabase
            // 
            this.tboxDatabase.Location = new System.Drawing.Point(211, 149);
            this.tboxDatabase.Name = "tboxDatabase";
            this.tboxDatabase.ReadOnly = true;
            this.tboxDatabase.Size = new System.Drawing.Size(133, 20);
            this.tboxDatabase.TabIndex = 5;
            this.tboxDatabase.Text = "retrocollector";
            // 
            // lblDatabase
            // 
            this.lblDatabase.AutoSize = true;
            this.lblDatabase.Location = new System.Drawing.Point(149, 152);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(56, 13);
            this.lblDatabase.TabIndex = 6;
            this.lblDatabase.Text = "Database:";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(12, 191);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(90, 13);
            this.lblUsername.TabIndex = 7;
            this.lblUsername.Text = "MySql Username:";
            // 
            // tboxUsername
            // 
            this.tboxUsername.Location = new System.Drawing.Point(108, 188);
            this.tboxUsername.Name = "tboxUsername";
            this.tboxUsername.Size = new System.Drawing.Size(236, 20);
            this.tboxUsername.TabIndex = 8;
            // 
            // tboxPassword
            // 
            this.tboxPassword.Location = new System.Drawing.Point(108, 219);
            this.tboxPassword.Name = "tboxPassword";
            this.tboxPassword.PasswordChar = '*';
            this.tboxPassword.Size = new System.Drawing.Size(236, 20);
            this.tboxPassword.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 222);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "MySql Password:";
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Location = new System.Drawing.Point(15, 289);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(75, 23);
            this.btnTestConnection.TabIndex = 11;
            this.btnTestConnection.Text = "Test";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            // 
            // btnSaveDBDetails
            // 
            this.btnSaveDBDetails.Location = new System.Drawing.Point(269, 289);
            this.btnSaveDBDetails.Name = "btnSaveDBDetails";
            this.btnSaveDBDetails.Size = new System.Drawing.Size(75, 23);
            this.btnSaveDBDetails.TabIndex = 12;
            this.btnSaveDBDetails.Text = "Save";
            this.btnSaveDBDetails.UseVisualStyleBackColor = true;
            // 
            // DBSetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 332);
            this.Controls.Add(this.btnSaveDBDetails);
            this.Controls.Add(this.btnTestConnection);
            this.Controls.Add(this.tboxPassword);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tboxUsername);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblDatabase);
            this.Controls.Add(this.tboxDatabase);
            this.Controls.Add(this.tboxPort);
            this.Controls.Add(this.lblServerPort);
            this.Controls.Add(this.tboxServerName);
            this.Controls.Add(this.lblServerName);
            this.Controls.Add(this.lblFormTitle);
            this.Name = "DBSetupForm";
            this.Text = "Database Setup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.Label lblServerName;
        private System.Windows.Forms.TextBox tboxServerName;
        private System.Windows.Forms.Label lblServerPort;
        private System.Windows.Forms.TextBox tboxPort;
        private System.Windows.Forms.TextBox tboxDatabase;
        private System.Windows.Forms.Label lblDatabase;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox tboxUsername;
        private System.Windows.Forms.TextBox tboxPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTestConnection;
        private System.Windows.Forms.Button btnSaveDBDetails;
    }
}