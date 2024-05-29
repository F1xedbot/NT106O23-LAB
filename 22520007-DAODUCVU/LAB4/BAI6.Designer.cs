namespace LAB4
{
    partial class BAI6
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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label2 = new Label();
            label3 = new Label();
            textBox3 = new TextBox();
            button1 = new Button();
            richTextBox1 = new RichTextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(34, 28);
            label1.Name = "label1";
            label1.Size = new Size(35, 20);
            label1.TabIndex = 0;
            label1.Text = "URL";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(146, 21);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(332, 27);
            textBox1.TabIndex = 1;
            textBox1.Text = "https://nt106.uitiot.vn/api/v1/user/me";
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(146, 66);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(218, 27);
            textBox2.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(34, 73);
            label2.Name = "label2";
            label2.Size = new Size(77, 20);
            label2.TabIndex = 2;
            label2.Text = "tokenType";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(34, 116);
            label3.Name = "label3";
            label3.Size = new Size(90, 20);
            label3.TabIndex = 4;
            label3.Text = "accessToken";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(146, 109);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(218, 27);
            textBox3.TabIndex = 5;
            // 
            // button1
            // 
            button1.Location = new Point(384, 64);
            button1.Name = "button1";
            button1.Size = new Size(94, 75);
            button1.TabIndex = 6;
            button1.Text = "GET";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(34, 166);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(444, 207);
            richTextBox1.TabIndex = 7;
            richTextBox1.Text = "";
            // 
            // BAI6
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(514, 385);
            Controls.Add(richTextBox1);
            Controls.Add(button1);
            Controls.Add(textBox3);
            Controls.Add(label3);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "BAI6";
            Text = "BAI6";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label2;
        private Label label3;
        private TextBox textBox3;
        private Button button1;
        private RichTextBox richTextBox1;
    }
}