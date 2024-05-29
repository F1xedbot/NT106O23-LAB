namespace LAB4
{
    partial class BAI2
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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            richTextBox1 = new RichTextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(430, 12);
            button1.Name = "button1";
            button1.Size = new Size(94, 34);
            button1.TabIndex = 0;
            button1.Text = "Load";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(430, 55);
            button2.Name = "button2";
            button2.Size = new Size(94, 34);
            button2.TabIndex = 1;
            button2.Text = "Download";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(47, 19);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(364, 27);
            textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(47, 59);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(364, 27);
            textBox2.TabIndex = 3;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(47, 115);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(477, 221);
            richTextBox1.TabIndex = 4;
            richTextBox1.Text = "";
            // 
            // BAI2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(565, 348);
            Controls.Add(richTextBox1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "BAI2";
            Text = "BAI2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private TextBox textBox1;
        private TextBox textBox2;
        private RichTextBox richTextBox1;
    }
}