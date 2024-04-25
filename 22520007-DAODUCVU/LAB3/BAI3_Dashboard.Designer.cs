namespace LAB3
{
    partial class BAI3_Dashboard
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
            button2 = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // button2
            // 
            button2.Location = new Point(77, 21);
            button2.Name = "button2";
            button2.Size = new Size(303, 35);
            button2.TabIndex = 2;
            button2.Text = "Open TCP Server";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(77, 72);
            button1.Name = "button1";
            button1.Size = new Size(303, 35);
            button1.TabIndex = 3;
            button1.Text = "Open new TCP Client";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // BAI3_Dashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(464, 127);
            Controls.Add(button1);
            Controls.Add(button2);
            Name = "BAI3_Dashboard";
            Text = "BAI3_Dashboard";
            ResumeLayout(false);
        }

        #endregion

        private Button button2;
        private Button button1;
    }
}