namespace LAB4
{
    partial class BAI7_Login
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
            label1 = new Label();
            logPassword = new TextBox();
            logUsername = new TextBox();
            label3 = new Label();
            label2 = new Label();
            logBtn = new Button();
            label4 = new Label();
            labelSignup = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label1.ForeColor = Color.IndianRed;
            label1.Location = new Point(120, 18);
            label1.Name = "label1";
            label1.Size = new Size(184, 30);
            label1.TabIndex = 3;
            label1.Text = "HÔM NAY ĂN GÌ";
            // 
            // logPassword
            // 
            logPassword.Location = new Point(139, 100);
            logPassword.Name = "logPassword";
            logPassword.Size = new Size(165, 27);
            logPassword.TabIndex = 7;
            // 
            // logUsername
            // 
            logUsername.Location = new Point(139, 67);
            logUsername.Name = "logUsername";
            logUsername.Size = new Size(165, 27);
            logUsername.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(36, 105);
            label3.Name = "label3";
            label3.Size = new Size(70, 20);
            label3.TabIndex = 5;
            label3.Text = "Password";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(36, 70);
            label2.Name = "label2";
            label2.Size = new Size(75, 20);
            label2.TabIndex = 4;
            label2.Text = "Username";
            // 
            // logBtn
            // 
            logBtn.Location = new Point(310, 67);
            logBtn.Name = "logBtn";
            logBtn.Size = new Size(94, 60);
            logBtn.TabIndex = 8;
            logBtn.Text = "Login";
            logBtn.UseVisualStyleBackColor = true;
            logBtn.Click += logBtn_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(102, 147);
            label4.Name = "label4";
            label4.Size = new Size(187, 20);
            label4.TabIndex = 9;
            label4.Text = "Don't have an account yet?";
            // 
            // labelSignup
            // 
            labelSignup.AutoSize = true;
            labelSignup.ForeColor = Color.RoyalBlue;
            labelSignup.Location = new Point(295, 147);
            labelSignup.Name = "labelSignup";
            labelSignup.Size = new Size(59, 20);
            labelSignup.TabIndex = 10;
            labelSignup.Text = "Sign up";
            labelSignup.Click += labelSignup_Click;
            // 
            // BAI7_Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(430, 187);
            Controls.Add(labelSignup);
            Controls.Add(label4);
            Controls.Add(logBtn);
            Controls.Add(logPassword);
            Controls.Add(logUsername);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "BAI7_Login";
            Text = "BAI7_Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox logPassword;
        private TextBox logUsername;
        private Label label3;
        private Label label2;
        private Button logBtn;
        private Label label4;
        private Label labelSignup;
    }
}