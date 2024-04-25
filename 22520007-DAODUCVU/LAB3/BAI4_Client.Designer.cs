namespace LAB3
{
    partial class BAI4_Client
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
            comboBoxTheaters = new ComboBox();
            comboBoxFilms = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            listView1 = new ListView();
            label3 = new Label();
            payoutOutput = new TextBox();
            button1 = new Button();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            seatOutput = new TextBox();
            theaterOutput = new TextBox();
            filmOutput = new TextBox();
            SuspendLayout();
            // 
            // comboBoxTheaters
            // 
            comboBoxTheaters.FormattingEnabled = true;
            comboBoxTheaters.Location = new Point(47, 41);
            comboBoxTheaters.Name = "comboBoxTheaters";
            comboBoxTheaters.Size = new Size(174, 28);
            comboBoxTheaters.TabIndex = 0;
            comboBoxTheaters.SelectedIndexChanged += comboBoxTheaters_SelectedIndexChanged;
            // 
            // comboBoxFilms
            // 
            comboBoxFilms.FormattingEnabled = true;
            comboBoxFilms.Location = new Point(284, 41);
            comboBoxFilms.Name = "comboBoxFilms";
            comboBoxFilms.Size = new Size(174, 28);
            comboBoxFilms.TabIndex = 1;
            comboBoxFilms.SelectedIndexChanged += comboBoxFilms_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(47, 18);
            label1.Name = "label1";
            label1.Size = new Size(90, 20);
            label1.TabIndex = 2;
            label1.Text = "Phòng chiếu";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(284, 18);
            label2.Name = "label2";
            label2.Size = new Size(42, 20);
            label2.TabIndex = 3;
            label2.Text = "Phim";
            // 
            // listView1
            // 
            listView1.Location = new Point(47, 92);
            listView1.Name = "listView1";
            listView1.Size = new Size(411, 206);
            listView1.TabIndex = 4;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.ItemCheck += listView1_ItemCheck;
            listView1.ItemChecked += listView1_ItemChecked;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(47, 425);
            label3.Name = "label3";
            label3.Size = new Size(87, 20);
            label3.TabIndex = 5;
            label3.Text = "Tổng giá vé";
            // 
            // payoutOutput
            // 
            payoutOutput.Location = new Point(148, 418);
            payoutOutput.Name = "payoutOutput";
            payoutOutput.ReadOnly = true;
            payoutOutput.Size = new Size(125, 27);
            payoutOutput.TabIndex = 6;
            // 
            // button1
            // 
            button1.Location = new Point(320, 319);
            button1.Name = "button1";
            button1.Size = new Size(138, 60);
            button1.TabIndex = 7;
            button1.Text = "Đặt vé";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(47, 392);
            label4.Name = "label4";
            label4.Size = new Size(69, 20);
            label4.TabIndex = 8;
            label4.Text = "Ghế ngồi";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(47, 359);
            label5.Name = "label5";
            label5.Size = new Size(90, 20);
            label5.TabIndex = 9;
            label5.Text = "Phòng chiếu";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(47, 326);
            label6.Name = "label6";
            label6.Size = new Size(42, 20);
            label6.TabIndex = 10;
            label6.Text = "Phim";
            // 
            // seatOutput
            // 
            seatOutput.Location = new Point(148, 385);
            seatOutput.Name = "seatOutput";
            seatOutput.ReadOnly = true;
            seatOutput.Size = new Size(125, 27);
            seatOutput.TabIndex = 11;
            // 
            // theaterOutput
            // 
            theaterOutput.Location = new Point(148, 352);
            theaterOutput.Name = "theaterOutput";
            theaterOutput.ReadOnly = true;
            theaterOutput.Size = new Size(125, 27);
            theaterOutput.TabIndex = 12;
            // 
            // filmOutput
            // 
            filmOutput.Location = new Point(148, 319);
            filmOutput.Name = "filmOutput";
            filmOutput.ReadOnly = true;
            filmOutput.Size = new Size(125, 27);
            filmOutput.TabIndex = 13;
            // 
            // BAI4_Client
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(506, 470);
            Controls.Add(filmOutput);
            Controls.Add(theaterOutput);
            Controls.Add(seatOutput);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(button1);
            Controls.Add(payoutOutput);
            Controls.Add(label3);
            Controls.Add(listView1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBoxFilms);
            Controls.Add(comboBoxTheaters);
            Name = "BAI4_Client";
            Text = "BAI4_Client";
            Load += BAI4_Client_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxTheaters;
        private ComboBox comboBoxFilms;
        private Label label1;
        private Label label2;
        private ListView listView1;
        private Label label3;
        private TextBox payoutOutput;
        private Button button1;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox seatOutput;
        private TextBox theaterOutput;
        private TextBox filmOutput;
    }
}