namespace LAB2
{
    partial class BAI5
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
            button1 = new Button();
            button2 = new Button();
            progressBar1 = new ProgressBar();
            richTextBox1 = new RichTextBox();
            button3 = new Button();
            button4 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(42, 24);
            button1.Name = "button1";
            button1.Size = new Size(254, 49);
            button1.TabIndex = 0;
            button1.Text = "Load cinema stats file";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(42, 79);
            button2.Name = "button2";
            button2.Size = new Size(254, 49);
            button2.TabIndex = 1;
            button2.Text = "Extract calculated stats";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(42, 143);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(254, 29);
            progressBar1.TabIndex = 2;
            progressBar1.Click += progressBar1_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(378, 24);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(393, 263);
            richTextBox1.TabIndex = 3;
            richTextBox1.Text = "";
            // 
            // button3
            // 
            button3.Location = new Point(184, 241);
            button3.Name = "button3";
            button3.Size = new Size(112, 46);
            button3.TabIndex = 4;
            button3.Text = "Switch View";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(42, 241);
            button4.Name = "button4";
            button4.Size = new Size(112, 46);
            button4.TabIndex = 5;
            button4.Text = "Exit";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // BAI5
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(795, 310);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(richTextBox1);
            Controls.Add(progressBar1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "BAI5";
            Text = "BAI5";
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
        private ProgressBar progressBar1;
        private RichTextBox richTextBox1;
        private Button button3;
        private Button button4;
    }
}