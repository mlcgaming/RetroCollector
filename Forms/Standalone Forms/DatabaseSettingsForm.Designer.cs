namespace RetroCollector {
    partial class DatabaseSettingsForm {
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
            this.btnSaveDBDetails = new System.Windows.Forms.Button();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.tboxPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tboxUsername = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblDatabase = new System.Windows.Forms.Label();
            this.tboxDatabase = new System.Windows.Forms.TextBox();
            this.tboxPort = new System.Windows.Forms.TextBox();
            this.lblServerPort = new System.Windows.Forms.Label();
            this.tboxServerName = new System.Windows.Forms.TextBox();
            this.lblServerName = new System.Windows.Forms.Label();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.grpInitialieDatabase = new System.Windows.Forms.GroupBox();
            this.btnDBReinitialize = new System.Windows.Forms.Button();
            this.grpInitialieDatabase.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSaveDBDetails
            // 
            this.btnSaveDBDetails.Location = new System.Drawing.Point(270, 292);
            this.btnSaveDBDetails.Name = "btnSaveDBDetails";
            this.btnSaveDBDetails.Size = new System.Drawing.Size(75, 23);
            this.btnSaveDBDetails.TabIndex = 25;
            this.btnSaveDBDetails.Text = "Save";
            this.btnSaveDBDetails.UseVisualStyleBackColor = true;
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Location = new System.Drawing.Point(246, 263);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(99, 23);
            this.btnTestConnection.TabIndex = 24;
            this.btnTestConnection.Text = "Test Connection";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            // 
            // tboxPassword
            // 
            this.tboxPassword.Location = new System.Drawing.Point(109, 179);
            this.tboxPassword.Name = "tboxPassword";
            this.tboxPassword.PasswordChar = '*';
            this.tboxPassword.Size = new System.Drawing.Size(236, 20);
            this.tboxPassword.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 182);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "MySql Password:";
            // 
            // tboxUsername
            // 
            this.tboxUsername.Location = new System.Drawing.Point(109, 148);
            this.tboxUsername.Name = "tboxUsername";
            this.tboxUsername.Size = new System.Drawing.Size(236, 20);
            this.tboxUsername.TabIndex = 21;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(13, 151);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(90, 13);
            this.lblUsername.TabIndex = 20;
            this.lblUsername.Text = "MySql Username:";
            // 
            // lblDatabase
            // 
            this.lblDatabase.AutoSize = true;
            this.lblDatabase.Location = new System.Drawing.Point(150, 118);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(56, 13);
            this.lblDatabase.TabIndex = 19;
            this.lblDatabase.Text = "Database:";
            // 
            // tboxDatabase
            // 
            this.tboxDatabase.Location = new System.Drawing.Point(212, 115);
            this.tboxDatabase.Name = "tboxDatabase";
            this.tboxDatabase.Size = new System.Drawing.Size(133, 20);
            this.tboxDatabase.TabIndex = 18;
            this.tboxDatabase.Text = "retrocollector";
            // 
            // tboxPort
            // 
            this.tboxPort.Location = new System.Drawing.Point(48, 115);
            this.tboxPort.Name = "tboxPort";
            this.tboxPort.Size = new System.Drawing.Size(56, 20);
            this.tboxPort.TabIndex = 17;
            // 
            // lblServerPort
            // 
            this.lblServerPort.AutoSize = true;
            this.lblServerPort.Location = new System.Drawing.Point(13, 118);
            this.lblServerPort.Name = "lblServerPort";
            this.lblServerPort.Size = new System.Drawing.Size(29, 13);
            this.lblServerPort.TabIndex = 16;
            this.lblServerPort.Text = "Port:";
            // 
            // tboxServerName
            // 
            this.tboxServerName.Location = new System.Drawing.Point(101, 83);
            this.tboxServerName.Name = "tboxServerName";
            this.tboxServerName.Size = new System.Drawing.Size(244, 20);
            this.tboxServerName.TabIndex = 15;
            // 
            // lblServerName
            // 
            this.lblServerName.AutoSize = true;
            this.lblServerName.Location = new System.Drawing.Point(13, 86);
            this.lblServerName.Name = "lblServerName";
            this.lblServerName.Size = new System.Drawing.Size(82, 13);
            this.lblServerName.TabIndex = 14;
            this.lblServerName.Text = "Server Address:";
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormTitle.Location = new System.Drawing.Point(27, 9);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(306, 24);
            this.lblFormTitle.TabIndex = 13;
            this.lblFormTitle.Text = "Database Connection Configuration";
            // 
            // grpInitialieDatabase
            // 
            this.grpInitialieDatabase.Controls.Add(this.btnDBReinitialize);
            this.grpInitialieDatabase.Location = new System.Drawing.Point(16, 248);
            this.grpInitialieDatabase.Name = "grpInitialieDatabase";
            this.grpInitialieDatabase.Size = new System.Drawing.Size(127, 67);
            this.grpInitialieDatabase.TabIndex = 26;
            this.grpInitialieDatabase.TabStop = false;
            this.grpInitialieDatabase.Text = "Re-Initialize Database";
            // 
            // btnDBReinitialize
            // 
            this.btnDBReinitialize.ForeColor = System.Drawing.Color.Red;
            this.btnDBReinitialize.Location = new System.Drawing.Point(24, 25);
            this.btnDBReinitialize.Name = "btnDBReinitialize";
            this.btnDBReinitialize.Size = new System.Drawing.Size(75, 23);
            this.btnDBReinitialize.TabIndex = 0;
            this.btnDBReinitialize.Text = "INITIALIZE";
            this.btnDBReinitialize.UseVisualStyleBackColor = true;
            // 
            // DatabaseSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 327);
            this.Controls.Add(this.grpInitialieDatabase);
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
            this.Name = "DatabaseSettingsForm";
            this.Text = "Database Settings";
            this.grpInitialieDatabase.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSaveDBDetails;
        private System.Windows.Forms.Button btnTestConnection;
        private System.Windows.Forms.TextBox tboxPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tboxUsername;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblDatabase;
        private System.Windows.Forms.TextBox tboxDatabase;
        private System.Windows.Forms.TextBox tboxPort;
        private System.Windows.Forms.Label lblServerPort;
        private System.Windows.Forms.TextBox tboxServerName;
        private System.Windows.Forms.Label lblServerName;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.GroupBox grpInitialieDatabase;
        private System.Windows.Forms.Button btnDBReinitialize;
    }
}