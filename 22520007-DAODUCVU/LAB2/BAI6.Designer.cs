namespace LAB2
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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            label2 = new Label();
            dishInput = new TextBox();
            contribInput = new TextBox();
            addBtn = new Button();
            listView1 = new ListView();
            imageList1 = new ImageList(components);
            imageList2 = new ImageList(components);
            imageList3 = new ImageList(components);
            pickBtn = new Button();
            label5 = new Label();
            openFileDialog1 = new OpenFileDialog();
            openFileDialog2 = new OpenFileDialog();
            openFileDialog3 = new OpenFileDialog();
            fileSystemWatcher1 = new FileSystemWatcher();
            chooseImgBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 20);
            label1.Name = "label1";
            label1.Size = new Size(59, 20);
            label1.TabIndex = 0;
            label1.Text = "Món ăn";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 84);
            label2.Name = "label2";
            label2.Size = new Size(121, 20);
            label2.TabIndex = 1;
            label2.Text = "Người đóng góp";
            // 
            // dishInput
            // 
            dishInput.Location = new Point(21, 43);
            dishInput.Name = "dishInput";
            dishInput.Size = new Size(183, 27);
            dishInput.TabIndex = 2;
            // 
            // contribInput
            // 
            contribInput.Location = new Point(21, 107);
            contribInput.Name = "contribInput";
            contribInput.Size = new Size(183, 27);
            contribInput.TabIndex = 3;
            // 
            // addBtn
            // 
            addBtn.Location = new Point(21, 221);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(102, 38);
            addBtn.TabIndex = 4;
            addBtn.Text = "Add";
            addBtn.UseVisualStyleBackColor = true;
            addBtn.Click += button1_Click;
            // 
            // listView1
            // 
            listView1.Location = new Point(247, 43);
            listView1.Name = "listView1";
            listView1.Size = new Size(340, 327);
            listView1.TabIndex = 6;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageSize = new Size(16, 16);
            imageList1.TransparentColor = Color.Transparent;
            // 
            // imageList2
            // 
            imageList2.ColorDepth = ColorDepth.Depth32Bit;
            imageList2.ImageSize = new Size(16, 16);
            imageList2.TransparentColor = Color.Transparent;
            // 
            // imageList3
            // 
            imageList3.ColorDepth = ColorDepth.Depth32Bit;
            imageList3.ImageSize = new Size(16, 16);
            imageList3.TransparentColor = Color.Transparent;
            // 
            // pickBtn
            // 
            pickBtn.BackColor = Color.IndianRed;
            pickBtn.ForeColor = Color.FromArgb(128, 255, 255);
            pickBtn.Location = new Point(21, 290);
            pickBtn.Name = "pickBtn";
            pickBtn.Size = new Size(102, 80);
            pickBtn.TabIndex = 12;
            pickBtn.Text = "Pick me a dish !";
            pickBtn.UseVisualStyleBackColor = false;
            pickBtn.Click += button2_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(21, 147);
            label5.Name = "label5";
            label5.Size = new Size(51, 20);
            label5.TabIndex = 13;
            label5.Text = "Image";
            label5.Click += label5_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileDialog2
            // 
            openFileDialog2.FileName = "openFileDialog2";
            // 
            // openFileDialog3
            // 
            openFileDialog3.FileName = "openFileDialog3";
            // 
            // fileSystemWatcher1
            // 
            fileSystemWatcher1.EnableRaisingEvents = true;
            fileSystemWatcher1.SynchronizingObject = this;
            // 
            // chooseImgBtn
            // 
            chooseImgBtn.Location = new Point(21, 170);
            chooseImgBtn.Name = "chooseImgBtn";
            chooseImgBtn.Size = new Size(183, 33);
            chooseImgBtn.TabIndex = 14;
            chooseImgBtn.Text = "Choose Image";
            chooseImgBtn.UseVisualStyleBackColor = true;
            chooseImgBtn.Click += button1_Click_1;
            // 
            // BAI6
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(610, 390);
            Controls.Add(chooseImgBtn);
            Controls.Add(label5);
            Controls.Add(pickBtn);
            Controls.Add(listView1);
            Controls.Add(addBtn);
            Controls.Add(contribInput);
            Controls.Add(dishInput);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "BAI6";
            Text = "BAI6";
            Load += BAI6_Load;
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox dishInput;
        private TextBox contribInput;
        private Button addBtn;
        private ListView listView1;
        private ImageList imageList1;
        private ImageList imageList2;
        private ImageList imageList3;
        private Button pickBtn;
        private Label label5;
        private OpenFileDialog openFileDialog1;
        private OpenFileDialog openFileDialog2;
        private OpenFileDialog openFileDialog3;
        private FileSystemWatcher fileSystemWatcher1;
        private Button chooseImgBtn;
    }
}