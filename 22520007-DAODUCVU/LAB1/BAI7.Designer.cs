namespace WinFormsApp1
{
    partial class BAI7
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
            label3 = new Label();
            textBox3 = new TextBox();
            label4 = new Label();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            label5 = new Label();
            label6 = new Label();
            textBox6 = new TextBox();
            label7 = new Label();
            textBox7 = new TextBox();
            button1 = new Button();
            textBox8 = new TextBox();
            label8 = new Label();
            label9 = new Label();
            textBox9 = new TextBox();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(215, 40);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(517, 27);
            textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(215, 131);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(517, 27);
            textBox2.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 43);
            label1.Name = "label1";
            label1.Size = new Size(176, 20);
            label1.TabIndex = 0;
            label1.Text = "Danh sách điểm sinh viên";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(33, 138);
            label2.Name = "label2";
            label2.Size = new Size(105, 20);
            label2.TabIndex = 3;
            label2.Text = "Điểm các môn";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(33, 187);
            label3.Name = "label3";
            label3.Size = new Size(117, 20);
            label3.TabIndex = 5;
            label3.Text = "Điểm trung bình";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(175, 180);
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(92, 27);
            textBox3.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(298, 187);
            label4.Name = "label4";
            label4.Size = new Size(106, 20);
            label4.TabIndex = 7;
            label4.Text = "Điểm cao nhất";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(426, 180);
            textBox4.Name = "textBox4";
            textBox4.ReadOnly = true;
            textBox4.Size = new Size(92, 27);
            textBox4.TabIndex = 8;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(690, 180);
            textBox5.Name = "textBox5";
            textBox5.ReadOnly = true;
            textBox5.Size = new Size(92, 27);
            textBox5.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(562, 187);
            label5.Name = "label5";
            label5.Size = new Size(112, 20);
            label5.TabIndex = 9;
            label5.Text = "Điểm thấp nhất";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(33, 242);
            label6.Name = "label6";
            label6.Size = new Size(89, 20);
            label6.TabIndex = 12;
            label6.Text = "Số môn đậu";
            // 
            // textBox6
            // 
            textBox6.Location = new Point(175, 235);
            textBox6.Name = "textBox6";
            textBox6.ReadOnly = true;
            textBox6.Size = new Size(92, 27);
            textBox6.TabIndex = 11;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(298, 242);
            label7.Name = "label7";
            label7.Size = new Size(83, 20);
            label7.TabIndex = 14;
            label7.Text = "Số môn rớt";
            // 
            // textBox7
            // 
            textBox7.Location = new Point(426, 235);
            textBox7.Name = "textBox7";
            textBox7.ReadOnly = true;
            textBox7.Size = new Size(92, 27);
            textBox7.TabIndex = 13;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button1.Location = new Point(759, 40);
            button1.Name = "button1";
            button1.Size = new Size(110, 70);
            button1.TabIndex = 15;
            button1.Text = "Xuất kết quả";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox8
            // 
            textBox8.Location = new Point(690, 235);
            textBox8.Name = "textBox8";
            textBox8.ReadOnly = true;
            textBox8.Size = new Size(92, 27);
            textBox8.TabIndex = 17;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label8.Location = new Point(562, 242);
            label8.Name = "label8";
            label8.Size = new Size(65, 20);
            label8.TabIndex = 16;
            label8.Text = "Xếp loại";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label9.Location = new Point(33, 95);
            label9.Name = "label9";
            label9.Size = new Size(100, 20);
            label9.TabIndex = 19;
            label9.Text = "Tên sinh viên";
            // 
            // textBox9
            // 
            textBox9.Location = new Point(215, 88);
            textBox9.Name = "textBox9";
            textBox9.ReadOnly = true;
            textBox9.Size = new Size(303, 27);
            textBox9.TabIndex = 18;
            // 
            // BAI7
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(893, 334);
            Controls.Add(label9);
            Controls.Add(textBox9);
            Controls.Add(textBox8);
            Controls.Add(label8);
            Controls.Add(button1);
            Controls.Add(label7);
            Controls.Add(textBox7);
            Controls.Add(label6);
            Controls.Add(textBox6);
            Controls.Add(textBox5);
            Controls.Add(label5);
            Controls.Add(textBox4);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(textBox3);
            Controls.Add(label2);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "BAI7";
            Text = "BAI7";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBox3;
        private Label label4;
        private TextBox textBox4;
        private TextBox textBox5;
        private Label label5;
        private Label label6;
        private TextBox textBox6;
        private Label label7;
        private TextBox textBox7;
        private Button button1;
        private TextBox textBox8;
        private Label label8;
        private Label label9;
        private TextBox textBox9;
    }
}