namespace WinFormsApp1
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
            label1 = new Label();
            label2 = new Label();
            inputbox_1 = new TextBox();
            inputbox_2 = new TextBox();
            label3 = new Label();
            result_box = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F);
            label1.Location = new Point(55, 41);
            label1.Name = "label1";
            label1.Size = new Size(81, 25);
            label1.TabIndex = 0;
            label1.Text = "Số thứ 1";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F);
            label2.Location = new Point(55, 83);
            label2.Name = "label2";
            label2.Size = new Size(81, 25);
            label2.TabIndex = 1;
            label2.Text = "Số thứ 2";
            // 
            // inputbox_1
            // 
            inputbox_1.Location = new Point(153, 41);
            inputbox_1.Name = "inputbox_1";
            inputbox_1.Size = new Size(193, 27);
            inputbox_1.TabIndex = 2;
            inputbox_1.TextChanged += inputbox_1_TextChanged;
            // 
            // inputbox_2
            // 
            inputbox_2.Location = new Point(153, 83);
            inputbox_2.Name = "inputbox_2";
            inputbox_2.Size = new Size(193, 27);
            inputbox_2.TabIndex = 3;
            inputbox_2.TextChanged += inputbox_2_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F);
            label3.Location = new Point(55, 125);
            label3.Name = "label3";
            label3.Size = new Size(76, 25);
            label3.TabIndex = 4;
            label3.Text = "Kết quả";
            // 
            // result_box
            // 
            result_box.Enabled = false;
            result_box.Location = new Point(153, 123);
            result_box.Name = "result_box";
            result_box.Size = new Size(193, 27);
            result_box.TabIndex = 5;
            result_box.TextChanged += result_box_TextChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(456, 211);
            Controls.Add(result_box);
            Controls.Add(label3);
            Controls.Add(inputbox_2);
            Controls.Add(inputbox_1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "BAI1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox inputbox_1;
        private TextBox inputbox_2;
        private Label label3;
        private TextBox result_box;
    }
}
