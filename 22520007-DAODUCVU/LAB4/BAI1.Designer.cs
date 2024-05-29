namespace LAB4
{
    partial class BAI1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            button1 = new Button();
            richTextBox1 = new RichTextBox();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(34, 24);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(324, 27);
            textBox1.TabIndex = 1;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button1.Location = new Point(377, 18);
            button1.Name = "button1";
            button1.Size = new Size(94, 38);
            button1.TabIndex = 2;
            button1.Text = "GET";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(34, 73);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(437, 206);
            richTextBox1.TabIndex = 3;
            richTextBox1.Text = "";
            // 
            // BAI1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(501, 291);
            Controls.Add(richTextBox1);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Name = "BAI1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button button1;
        private RichTextBox richTextBox1;
    }
}
