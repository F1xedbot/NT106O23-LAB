namespace LAB4
{
    partial class BAI7_Add
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
            addImgUrl = new TextBox();
            addPrice = new TextBox();
            addAddress = new TextBox();
            label8 = new Label();
            addName = new TextBox();
            label9 = new Label();
            label11 = new Label();
            label10 = new Label();
            addDesc = new RichTextBox();
            label2 = new Label();
            addBtn = new Button();
            addClear = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label1.ForeColor = Color.IndianRed;
            label1.Location = new Point(138, 23);
            label1.Name = "label1";
            label1.Size = new Size(154, 30);
            label1.TabIndex = 3;
            label1.Text = "Thêm món ăn";
            // 
            // addImgUrl
            // 
            addImgUrl.Location = new Point(138, 185);
            addImgUrl.Name = "addImgUrl";
            addImgUrl.Size = new Size(253, 27);
            addImgUrl.TabIndex = 16;
            // 
            // addPrice
            // 
            addPrice.Location = new Point(138, 119);
            addPrice.Name = "addPrice";
            addPrice.Size = new Size(253, 27);
            addPrice.TabIndex = 14;
            // 
            // addAddress
            // 
            addAddress.Location = new Point(138, 152);
            addAddress.Name = "addAddress";
            addAddress.Size = new Size(253, 27);
            addAddress.TabIndex = 15;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(35, 192);
            label8.Name = "label8";
            label8.Size = new Size(68, 20);
            label8.TabIndex = 12;
            label8.Text = "Hình ảnh";
            // 
            // addName
            // 
            addName.Location = new Point(138, 86);
            addName.Name = "addName";
            addName.Size = new Size(253, 27);
            addName.TabIndex = 13;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(35, 159);
            label9.Name = "label9";
            label9.Size = new Size(55, 20);
            label9.TabIndex = 10;
            label9.Text = "Địa chỉ";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(35, 93);
            label11.Name = "label11";
            label11.Size = new Size(86, 20);
            label11.TabIndex = 9;
            label11.Text = "Tên món ăn";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(35, 126);
            label10.Name = "label10";
            label10.Size = new Size(31, 20);
            label10.TabIndex = 11;
            label10.Text = "Giá";
            // 
            // addDesc
            // 
            addDesc.Location = new Point(138, 218);
            addDesc.Name = "addDesc";
            addDesc.Size = new Size(253, 169);
            addDesc.TabIndex = 17;
            addDesc.Text = "";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(35, 221);
            label2.Name = "label2";
            label2.Size = new Size(48, 20);
            label2.TabIndex = 18;
            label2.Text = "Mô tả";
            // 
            // addBtn
            // 
            addBtn.Location = new Point(297, 397);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(94, 29);
            addBtn.TabIndex = 20;
            addBtn.Text = "Thêm";
            addBtn.UseVisualStyleBackColor = true;
            addBtn.Click += addBtn_Click;
            // 
            // addClear
            // 
            addClear.Location = new Point(197, 397);
            addClear.Name = "addClear";
            addClear.Size = new Size(94, 29);
            addClear.TabIndex = 19;
            addClear.Text = "Clear";
            addClear.UseVisualStyleBackColor = true;
            // 
            // BAI7_Add
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(430, 438);
            Controls.Add(addBtn);
            Controls.Add(addClear);
            Controls.Add(label2);
            Controls.Add(addDesc);
            Controls.Add(addImgUrl);
            Controls.Add(addPrice);
            Controls.Add(addAddress);
            Controls.Add(label8);
            Controls.Add(addName);
            Controls.Add(label9);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label1);
            Name = "BAI7_Add";
            Text = "BAI7_Add";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox addImgUrl;
        private TextBox addPrice;
        private TextBox addAddress;
        private Label label8;
        private TextBox addName;
        private Label label9;
        private Label label11;
        private Label label10;
        private RichTextBox addDesc;
        private Label label2;
        private Button addBtn;
        private Button addClear;
    }
}