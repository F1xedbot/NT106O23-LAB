namespace LAB3
{
    partial class BAI5_Client
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
            listView1 = new ListView();
            contribInput = new TextBox();
            label1 = new Label();
            dishInput = new TextBox();
            label2 = new Label();
            chooseImgBtn = new Button();
            label5 = new Label();
            addBtn = new Button();
            pickBtn = new Button();
            connectBtn = new Button();
            pickGlobalBtn = new Button();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Location = new Point(261, 12);
            listView1.Name = "listView1";
            listView1.Size = new Size(340, 390);
            listView1.TabIndex = 7;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // contribInput
            // 
            contribInput.Location = new Point(12, 39);
            contribInput.Name = "contribInput";
            contribInput.Size = new Size(183, 27);
            contribInput.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 133);
            label1.Name = "label1";
            label1.Size = new Size(59, 20);
            label1.TabIndex = 8;
            label1.Text = "Món ăn";
            // 
            // dishInput
            // 
            dishInput.Location = new Point(12, 156);
            dishInput.Name = "dishInput";
            dishInput.Size = new Size(183, 27);
            dishInput.TabIndex = 11;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 16);
            label2.Name = "label2";
            label2.Size = new Size(75, 20);
            label2.TabIndex = 10;
            label2.Text = "Username";
            // 
            // chooseImgBtn
            // 
            chooseImgBtn.Location = new Point(12, 223);
            chooseImgBtn.Name = "chooseImgBtn";
            chooseImgBtn.Size = new Size(183, 33);
            chooseImgBtn.TabIndex = 16;
            chooseImgBtn.Text = "Choose Image";
            chooseImgBtn.UseVisualStyleBackColor = true;
            chooseImgBtn.Click += chooseImgBtn_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 200);
            label5.Name = "label5";
            label5.Size = new Size(51, 20);
            label5.TabIndex = 15;
            label5.Text = "Image";
            // 
            // addBtn
            // 
            addBtn.Location = new Point(12, 262);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(102, 38);
            addBtn.TabIndex = 17;
            addBtn.Text = "Add";
            addBtn.UseVisualStyleBackColor = true;
            addBtn.Click += addBtn_Click;
            // 
            // pickBtn
            // 
            pickBtn.BackColor = Color.IndianRed;
            pickBtn.ForeColor = Color.FromArgb(128, 255, 255);
            pickBtn.Location = new Point(12, 339);
            pickBtn.Name = "pickBtn";
            pickBtn.Size = new Size(102, 60);
            pickBtn.TabIndex = 18;
            pickBtn.Text = "Pick a dish (local)";
            pickBtn.UseVisualStyleBackColor = false;
            pickBtn.Click += pickBtn_Click;
            // 
            // connectBtn
            // 
            connectBtn.Location = new Point(12, 72);
            connectBtn.Name = "connectBtn";
            connectBtn.Size = new Size(102, 38);
            connectBtn.TabIndex = 19;
            connectBtn.Text = "Connect";
            connectBtn.UseVisualStyleBackColor = true;
            connectBtn.Click += button1_Click;
            // 
            // pickGlobalBtn
            // 
            pickGlobalBtn.BackColor = Color.Indigo;
            pickGlobalBtn.ForeColor = Color.FromArgb(128, 255, 255);
            pickGlobalBtn.Location = new Point(120, 339);
            pickGlobalBtn.Name = "pickGlobalBtn";
            pickGlobalBtn.Size = new Size(102, 60);
            pickGlobalBtn.TabIndex = 20;
            pickGlobalBtn.Text = "Pick a dish (global)";
            pickGlobalBtn.UseVisualStyleBackColor = false;
            pickGlobalBtn.Click += button1_Click_1;
            // 
            // BAI5_Client
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(613, 411);
            Controls.Add(pickGlobalBtn);
            Controls.Add(connectBtn);
            Controls.Add(pickBtn);
            Controls.Add(addBtn);
            Controls.Add(chooseImgBtn);
            Controls.Add(label5);
            Controls.Add(dishInput);
            Controls.Add(label2);
            Controls.Add(contribInput);
            Controls.Add(label1);
            Controls.Add(listView1);
            Name = "BAI5_Client";
            Text = "BAI5";
            Load += BAI5_Client_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView listView1;
        private TextBox contribInput;
        private Label label1;
        private TextBox dishInput;
        private Label label2;
        private Button chooseImgBtn;
        private Label label5;
        private Button addBtn;
        private Button pickBtn;
        private Button connectBtn;
        private Button pickGlobalBtn;
    }
}