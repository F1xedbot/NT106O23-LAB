namespace LAB2
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
            richTextBox1 = new RichTextBox();
            button1 = new Button();
            label1 = new Label();
            file_name = new TextBox();
            label2 = new Label();
            file_size = new TextBox();
            file_line_count = new TextBox();
            label3 = new Label();
            file_url = new TextBox();
            label4 = new Label();
            file_char_count = new TextBox();
            label5 = new Label();
            file_word_count = new TextBox();
            label6 = new Label();
            button2 = new Button();
            SuspendLayout();
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = Color.FromArgb(64, 64, 64);
            richTextBox1.ForeColor = Color.Blue;
            richTextBox1.Location = new Point(335, 27);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(354, 344);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            richTextBox1.TextChanged += richTextBox1_TextChanged;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button1.Location = new Point(15, 26);
            button1.Name = "button1";
            button1.Size = new Size(294, 29);
            button1.TabIndex = 1;
            button1.Text = "Read from File";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.ForeColor = Color.Blue;
            label1.Location = new Point(12, 88);
            label1.Name = "label1";
            label1.Size = new Size(76, 20);
            label1.TabIndex = 2;
            label1.Text = "File name";
            // 
            // file_name
            // 
            file_name.Location = new Point(149, 81);
            file_name.Name = "file_name";
            file_name.Size = new Size(160, 27);
            file_name.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.ForeColor = Color.Blue;
            label2.Location = new Point(12, 127);
            label2.Name = "label2";
            label2.Size = new Size(36, 20);
            label2.TabIndex = 4;
            label2.Text = "Size";
            // 
            // file_size
            // 
            file_size.Location = new Point(149, 120);
            file_size.Name = "file_size";
            file_size.Size = new Size(160, 27);
            file_size.TabIndex = 5;
            // 
            // file_line_count
            // 
            file_line_count.Location = new Point(149, 202);
            file_line_count.Name = "file_line_count";
            file_line_count.Size = new Size(160, 27);
            file_line_count.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.ForeColor = Color.Blue;
            label3.Location = new Point(12, 209);
            label3.Name = "label3";
            label3.Size = new Size(82, 20);
            label3.TabIndex = 8;
            label3.Text = "Line count";
            // 
            // file_url
            // 
            file_url.Location = new Point(149, 163);
            file_url.Name = "file_url";
            file_url.Size = new Size(160, 27);
            file_url.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.ForeColor = Color.Blue;
            label4.Location = new Point(12, 170);
            label4.Name = "label4";
            label4.Size = new Size(38, 20);
            label4.TabIndex = 6;
            label4.Text = "URL";
            // 
            // file_char_count
            // 
            file_char_count.Location = new Point(149, 283);
            file_char_count.Name = "file_char_count";
            file_char_count.Size = new Size(160, 27);
            file_char_count.TabIndex = 13;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.ForeColor = Color.Blue;
            label5.Location = new Point(12, 290);
            label5.Name = "label5";
            label5.Size = new Size(127, 20);
            label5.TabIndex = 12;
            label5.Text = "Characters count";
            // 
            // file_word_count
            // 
            file_word_count.Location = new Point(149, 244);
            file_word_count.Name = "file_word_count";
            file_word_count.Size = new Size(160, 27);
            file_word_count.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label6.ForeColor = Color.Blue;
            label6.Location = new Point(12, 251);
            label6.Name = "label6";
            label6.Size = new Size(99, 20);
            label6.TabIndex = 10;
            label6.Text = "Words count";
            // 
            // button2
            // 
            button2.BackColor = Color.Lime;
            button2.ForeColor = Color.Black;
            button2.Location = new Point(15, 329);
            button2.Name = "button2";
            button2.Size = new Size(294, 42);
            button2.TabIndex = 14;
            button2.Text = "Exit";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // BAI2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(715, 397);
            Controls.Add(button2);
            Controls.Add(file_char_count);
            Controls.Add(label5);
            Controls.Add(file_word_count);
            Controls.Add(label6);
            Controls.Add(file_line_count);
            Controls.Add(label3);
            Controls.Add(file_url);
            Controls.Add(label4);
            Controls.Add(file_size);
            Controls.Add(label2);
            Controls.Add(file_name);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(richTextBox1);
            ForeColor = Color.Blue;
            Name = "BAI2";
            Text = "BAI2";
            Load += BAI2_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox richTextBox1;
        private Button button1;
        private Label label1;
        private TextBox file_name;
        private Label label2;
        private TextBox file_size;
        private TextBox file_line_count;
        private Label label3;
        private TextBox file_url;
        private Label label4;
        private TextBox file_char_count;
        private Label label5;
        private TextBox file_word_count;
        private Label label6;
        private Button button2;
    }
}