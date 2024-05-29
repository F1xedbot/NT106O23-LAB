namespace LAB4
{
    partial class BAI7_Pick
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            labelName = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            labelContrib = new Label();
            labelAddress = new Label();
            labelPrice = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(154, 144);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelName.ForeColor = Color.Coral;
            labelName.Location = new Point(174, 15);
            labelName.Name = "labelName";
            labelName.Size = new Size(124, 28);
            labelName.TabIndex = 1;
            labelName.Text = "Bún Bò Huế";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(175, 52);
            label2.Name = "label2";
            label2.Size = new Size(34, 20);
            label2.TabIndex = 2;
            label2.Text = "Giá:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(175, 80);
            label3.Name = "label3";
            label3.Size = new Size(58, 20);
            label3.TabIndex = 3;
            label3.Text = "Địa chỉ:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(175, 108);
            label4.Name = "label4";
            label4.Size = new Size(80, 20);
            label4.TabIndex = 4;
            label4.Text = "Đóng góp:";
            label4.Click += label4_Click;
            // 
            // labelContrib
            // 
            labelContrib.AutoSize = true;
            labelContrib.ForeColor = Color.ForestGreen;
            labelContrib.Location = new Point(264, 108);
            labelContrib.Name = "labelContrib";
            labelContrib.Size = new Size(50, 20);
            labelContrib.TabIndex = 5;
            labelContrib.Text = "baonv";
            // 
            // labelAddress
            // 
            labelAddress.AutoSize = true;
            labelAddress.Location = new Point(264, 80);
            labelAddress.Name = "labelAddress";
            labelAddress.Size = new Size(115, 20);
            labelAddress.TabIndex = 6;
            labelAddress.Text = "345 - ABC - DEF";
            // 
            // labelPrice
            // 
            labelPrice.AutoSize = true;
            labelPrice.Location = new Point(265, 52);
            labelPrice.Name = "labelPrice";
            labelPrice.Size = new Size(49, 20);
            labelPrice.TabIndex = 7;
            labelPrice.Text = "32000";
            // 
            // BAI7_Pick
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(labelPrice);
            Controls.Add(labelAddress);
            Controls.Add(labelContrib);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(labelName);
            Controls.Add(pictureBox1);
            Name = "BAI7_Pick";
            Size = new Size(563, 150);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label labelName;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label labelContrib;
        private Label labelAddress;
        private Label labelPrice;
    }
}
