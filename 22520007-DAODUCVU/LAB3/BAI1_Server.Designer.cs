namespace LAB3
{
    partial class BAI1_Server
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
            portText = new TextBox();
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            ipText = new TextBox();
            button2 = new Button();
            listView1 = new ListView();
            SuspendLayout();
            // 
            // portText
            // 
            portText.Location = new Point(163, 26);
            portText.Name = "portText";
            portText.Size = new Size(158, 27);
            portText.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(399, 24);
            button1.Name = "button1";
            button1.Size = new Size(129, 62);
            button1.TabIndex = 2;
            button1.Text = "Listen";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F);
            label1.Location = new Point(45, 33);
            label1.Name = "label1";
            label1.Size = new Size(35, 20);
            label1.TabIndex = 1;
            label1.Text = "Port";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F);
            label2.Location = new Point(45, 107);
            label2.Name = "label2";
            label2.Size = new Size(137, 20);
            label2.TabIndex = 4;
            label2.Text = "Received Messages";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F);
            label3.Location = new Point(45, 66);
            label3.Name = "label3";
            label3.Size = new Size(112, 20);
            label3.TabIndex = 7;
            label3.Text = "IP Remote Host";
            // 
            // ipText
            // 
            ipText.Location = new Point(163, 59);
            ipText.Name = "ipText";
            ipText.Size = new Size(158, 27);
            ipText.TabIndex = 6;
            // 
            // button2
            // 
            button2.Location = new Point(45, 320);
            button2.Name = "button2";
            button2.Size = new Size(483, 33);
            button2.TabIndex = 8;
            button2.Text = "Stop listening and close form";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // listView1
            // 
            listView1.Location = new Point(45, 130);
            listView1.Name = "listView1";
            listView1.Size = new Size(483, 184);
            listView1.TabIndex = 9;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // BAI1_Server
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(570, 376);
            Controls.Add(listView1);
            Controls.Add(button2);
            Controls.Add(label3);
            Controls.Add(ipText);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(portText);
            Name = "BAI1_Server";
            Text = "BAI1_Server";
            Load += BAI1_Server_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox portText;
        private Button button1;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox ipText;
        private Button button2;
        private ListView listView1;
    }
}