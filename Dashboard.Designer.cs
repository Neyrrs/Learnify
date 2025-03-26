namespace Leaernify
{
    partial class Dashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.sideBar = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnRequest = new System.Windows.Forms.Button();
            this.btnHistory = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.mainLayout = new System.Windows.Forms.Panel();
            this.sideBar.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sideBar
            // 
            resources.ApplyResources(this.sideBar, "sideBar");
            this.sideBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(139)))), ((int)(((byte)(193)))));
            this.sideBar.Controls.Add(this.label1);
            this.sideBar.Controls.Add(this.txtUsername);
            this.sideBar.Controls.Add(this.panel1);
            this.sideBar.Controls.Add(this.btnHistory);
            this.sideBar.Controls.Add(this.button2);
            this.sideBar.Name = "sideBar";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Name = "label1";
            // 
            // txtUsername
            // 
            resources.ApplyResources(this.txtUsername, "txtUsername");
            this.txtUsername.ForeColor = System.Drawing.Color.White;
            this.txtUsername.Name = "txtUsername";
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.btnHome);
            this.panel1.Controls.Add(this.btnRequest);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel1.Name = "panel1";
            // 
            // btnHome
            // 
            resources.ApplyResources(this.btnHome, "btnHome");
            this.btnHome.BackColor = System.Drawing.Color.Transparent;
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(149)))), ((int)(((byte)(189)))));
            this.btnHome.ForeColor = System.Drawing.Color.White;
            this.btnHome.Name = "btnHome";
            this.btnHome.UseCompatibleTextRendering = true;
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnRequest
            // 
            resources.ApplyResources(this.btnRequest, "btnRequest");
            this.btnRequest.BackColor = System.Drawing.Color.Transparent;
            this.btnRequest.FlatAppearance.BorderSize = 0;
            this.btnRequest.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(149)))), ((int)(((byte)(189)))));
            this.btnRequest.ForeColor = System.Drawing.Color.White;
            this.btnRequest.Name = "btnRequest";
            this.btnRequest.UseVisualStyleBackColor = false;
            this.btnRequest.Click += new System.EventHandler(this.btnRequest_Click);
            // 
            // btnHistory
            // 
            resources.ApplyResources(this.btnHistory, "btnHistory");
            this.btnHistory.BackColor = System.Drawing.Color.Transparent;
            this.btnHistory.FlatAppearance.BorderSize = 0;
            this.btnHistory.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(149)))), ((int)(((byte)(189)))));
            this.btnHistory.ForeColor = System.Drawing.Color.White;
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(149)))), ((int)(((byte)(189)))));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // mainLayout
            // 
            resources.ApplyResources(this.mainLayout, "mainLayout");
            this.mainLayout.BackColor = System.Drawing.Color.White;
            this.mainLayout.Name = "mainLayout";
            // 
            // Dashboard
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sideBar);
            this.Controls.Add(this.mainLayout);
            this.Name = "Dashboard";
            this.ShowIcon = false;
            this.sideBar.ResumeLayout(false);
            this.sideBar.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel sideBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txtUsername;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnRequest;
        private System.Windows.Forms.Button btnHistory;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel mainLayout;
    }
}