namespace LAB3
{
    partial class LAB3_GUI
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
            button6 = new Button();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button7 = new Button();
            button8 = new Button();
            SuspendLayout();
            // 
            // button6
            // 
            button6.Location = new Point(53, 25);
            button6.Name = "button6";
            button6.Size = new Size(131, 46);
            button6.TabIndex = 5;
            button6.Text = "BAI1";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button1
            // 
            button1.Location = new Point(201, 25);
            button1.Name = "button1";
            button1.Size = new Size(131, 46);
            button1.TabIndex = 6;
            button1.Text = "BAI2";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(354, 25);
            button2.Name = "button2";
            button2.Size = new Size(131, 46);
            button2.TabIndex = 7;
            button2.Text = "BAI3";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(53, 94);
            button3.Name = "button3";
            button3.Size = new Size(131, 46);
            button3.TabIndex = 8;
            button3.Text = "BAI4";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(201, 94);
            button4.Name = "button4";
            button4.Size = new Size(131, 46);
            button4.TabIndex = 9;
            button4.Text = "BAI5";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(354, 94);
            button5.Name = "button5";
            button5.Size = new Size(131, 46);
            button5.TabIndex = 10;
            button5.Text = "BAI6";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button7
            // 
            button7.Location = new Point(53, 173);
            button7.Name = "button7";
            button7.Size = new Size(131, 46);
            button7.TabIndex = 11;
            button7.Text = "Exit";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.Location = new Point(201, 173);
            button8.Name = "button8";
            button8.Size = new Size(284, 46);
            button8.TabIndex = 12;
            button8.Text = "Close All Active Forms";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // LAB3_GUI
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(543, 237);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(button6);
            Name = "LAB3_GUI";
            Text = "LAB3";
            ResumeLayout(false);
        }

        #endregion

        private Button button6;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button7;
        private Button button8;
    }
}