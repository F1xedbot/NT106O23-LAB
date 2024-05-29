namespace LAB4
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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            flowLayoutPanel1 = new FlowLayoutPanel();
            tabPage2 = new TabPage();
            flowLayoutPanel2 = new FlowLayoutPanel();
            label1 = new Label();
            addDishBtn = new Button();
            randDishBtn = new Button();
            label2 = new Label();
            comboBoxPageNum = new ComboBox();
            comboBoxPageSize = new ComboBox();
            label3 = new Label();
            labelStatus = new Label();
            logoutLabel = new Label();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(12, 76);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(571, 393);
            tabControl1.TabIndex = 0;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(flowLayoutPanel1);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(4);
            tabPage1.Size = new Size(563, 360);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "All";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Location = new Point(7, 7);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(549, 346);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(flowLayoutPanel2);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(563, 360);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Tôi đóng góp";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Location = new Point(6, 6);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(551, 348);
            flowLayoutPanel2.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label1.ForeColor = Color.IndianRed;
            label1.Location = new Point(16, 27);
            label1.Name = "label1";
            label1.Size = new Size(184, 30);
            label1.TabIndex = 1;
            label1.Text = "HÔM NAY ĂN GÌ";
            // 
            // addDishBtn
            // 
            addDishBtn.BackColor = Color.FromArgb(255, 224, 192);
            addDishBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            addDishBtn.Location = new Point(442, 40);
            addDishBtn.Name = "addDishBtn";
            addDishBtn.Size = new Size(134, 44);
            addDishBtn.TabIndex = 3;
            addDishBtn.Text = "Thêm món ăn";
            addDishBtn.UseVisualStyleBackColor = false;
            addDishBtn.Click += addDishBtn_Click;
            // 
            // randDishBtn
            // 
            randDishBtn.BackColor = Color.FromArgb(255, 192, 128);
            randDishBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            randDishBtn.Location = new Point(302, 40);
            randDishBtn.Name = "randDishBtn";
            randDishBtn.Size = new Size(134, 44);
            randDishBtn.TabIndex = 4;
            randDishBtn.Text = "Ăn gì giờ ?";
            randDishBtn.UseVisualStyleBackColor = false;
            randDishBtn.Click += randDishBtn_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(346, 474);
            label2.Name = "label2";
            label2.Size = new Size(41, 20);
            label2.TabIndex = 5;
            label2.Text = "Page";
            // 
            // comboBoxPageNum
            // 
            comboBoxPageNum.FormattingEnabled = true;
            comboBoxPageNum.Location = new Point(392, 471);
            comboBoxPageNum.Name = "comboBoxPageNum";
            comboBoxPageNum.Size = new Size(52, 28);
            comboBoxPageNum.TabIndex = 6;
            comboBoxPageNum.SelectedIndexChanged += comboBoxPageNum_SelectedIndexChanged;
            // 
            // comboBoxPageSize
            // 
            comboBoxPageSize.FormattingEnabled = true;
            comboBoxPageSize.Location = new Point(527, 471);
            comboBoxPageSize.Name = "comboBoxPageSize";
            comboBoxPageSize.Size = new Size(52, 28);
            comboBoxPageSize.TabIndex = 8;
            comboBoxPageSize.SelectedIndexChanged += comboBoxPageSize_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(452, 474);
            label3.Name = "label3";
            label3.Size = new Size(70, 20);
            label3.TabIndex = 7;
            label3.Text = "Page size";
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.ForeColor = Color.Green;
            labelStatus.Location = new Point(16, 499);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(121, 20);
            labelStatus.TabIndex = 9;
            labelStatus.Text = "Welcome, DucVu";
            // 
            // logoutLabel
            // 
            logoutLabel.AllowDrop = true;
            logoutLabel.AutoSize = true;
            logoutLabel.ForeColor = Color.Blue;
            logoutLabel.Location = new Point(138, 499);
            logoutLabel.Name = "logoutLabel";
            logoutLabel.Size = new Size(56, 20);
            logoutLabel.TabIndex = 10;
            logoutLabel.Text = "Logout";
            logoutLabel.Click += logoutLabel_Click;
            // 
            // BAI7
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(595, 534);
            Controls.Add(logoutLabel);
            Controls.Add(labelStatus);
            Controls.Add(comboBoxPageSize);
            Controls.Add(label3);
            Controls.Add(comboBoxPageNum);
            Controls.Add(label2);
            Controls.Add(randDishBtn);
            Controls.Add(addDishBtn);
            Controls.Add(label1);
            Controls.Add(tabControl1);
            Name = "BAI7";
            Text = "BAI7";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Label label1;
        private Button addDishBtn;
        private Button randDishBtn;
        private Label label2;
        private ComboBox comboBoxPageNum;
        private ComboBox comboBoxPageSize;
        private Label label3;
        private Label labelStatus;
        private Label logoutLabel;
        private FlowLayoutPanel flowLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel2;
    }
}