namespace LAB3
{
    partial class BAI1_Client
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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            richTextBox1 = new RichTextBox();
            label3 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(25, 50);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(247, 27);
            textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(314, 50);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(123, 27);
            textBox2.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 21);
            label1.Name = "label1";
            label1.Size = new Size(112, 20);
            label1.TabIndex = 2;
            label1.Text = "IP Remote Host";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(314, 21);
            label2.Name = "label2";
            label2.Size = new Size(35, 20);
            label2.TabIndex = 3;
            label2.Text = "Port";
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(25, 111);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(412, 103);
            richTextBox1.TabIndex = 4;
            richTextBox1.Text = "";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 88);
            label3.Name = "label3";
            label3.Size = new Size(67, 20);
            label3.TabIndex = 5;
            label3.Text = "Message";
            // 
            // button1
            // 
            button1.Location = new Point(25, 221);
            button1.Name = "button1";
            button1.Size = new Size(112, 36);
            button1.TabIndex = 6;
            button1.Text = "Send";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // BAI1_Client
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(471, 269);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(richTextBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Name = "BAI1_Client";
            Text = "BAI1_Client";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private Label label1;
        private Label label2;
        private RichTextBox richTextBox1;
        private Label label3;
        private Button button1;
    }
}