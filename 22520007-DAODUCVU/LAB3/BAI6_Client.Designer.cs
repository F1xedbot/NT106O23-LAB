namespace LAB3
{
    partial class BAI6_Client
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
            listBox1 = new ListBox();
            label1 = new Label();
            nameInput = new TextBox();
            connectBtn = new Button();
            messageInput = new TextBox();
            sendBtn = new Button();
            label2 = new Label();
            listBox2 = new ListBox();
            label3 = new Label();
            disconnectBtn = new Button();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(12, 12);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(548, 284);
            listBox1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 309);
            label1.Name = "label1";
            label1.Size = new Size(79, 20);
            label1.TabIndex = 1;
            label1.Text = "Your name";
            // 
            // nameInput
            // 
            nameInput.Location = new Point(23, 332);
            nameInput.Name = "nameInput";
            nameInput.Size = new Size(175, 27);
            nameInput.TabIndex = 2;
            // 
            // connectBtn
            // 
            connectBtn.Location = new Point(204, 332);
            connectBtn.Name = "connectBtn";
            connectBtn.Size = new Size(110, 29);
            connectBtn.TabIndex = 3;
            connectBtn.Text = "Connect";
            connectBtn.UseVisualStyleBackColor = true;
            connectBtn.Click += button1_Click;
            // 
            // messageInput
            // 
            messageInput.Location = new Point(23, 396);
            messageInput.Name = "messageInput";
            messageInput.Size = new Size(421, 27);
            messageInput.TabIndex = 4;
            // 
            // sendBtn
            // 
            sendBtn.Location = new Point(450, 396);
            sendBtn.Name = "sendBtn";
            sendBtn.Size = new Size(110, 29);
            sendBtn.TabIndex = 5;
            sendBtn.Text = "Send";
            sendBtn.UseVisualStyleBackColor = true;
            sendBtn.Click += sendBtn_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 374);
            label2.Name = "label2";
            label2.Size = new Size(67, 20);
            label2.TabIndex = 6;
            label2.Text = "Message";
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.Location = new Point(583, 41);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(133, 384);
            listBox2.TabIndex = 7;
            listBox2.SelectedIndexChanged += listBox2_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(583, 12);
            label3.Name = "label3";
            label3.Size = new Size(85, 20);
            label3.TabIndex = 8;
            label3.Text = "Participants";
            // 
            // disconnectBtn
            // 
            disconnectBtn.Enabled = false;
            disconnectBtn.Location = new Point(320, 332);
            disconnectBtn.Name = "disconnectBtn";
            disconnectBtn.Size = new Size(110, 29);
            disconnectBtn.TabIndex = 9;
            disconnectBtn.Text = "Disconnect";
            disconnectBtn.UseVisualStyleBackColor = true;
            disconnectBtn.Click += disconnectBtn_Click;
            // 
            // BAI6_Client
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(731, 440);
            Controls.Add(disconnectBtn);
            Controls.Add(label3);
            Controls.Add(listBox2);
            Controls.Add(label2);
            Controls.Add(sendBtn);
            Controls.Add(messageInput);
            Controls.Add(connectBtn);
            Controls.Add(nameInput);
            Controls.Add(label1);
            Controls.Add(listBox1);
            Name = "BAI6_Client";
            Text = "BAI6_Client";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBox1;
        private Label label1;
        private TextBox nameInput;
        private Button connectBtn;
        private TextBox messageInput;
        private Button sendBtn;
        private Label label2;
        private ListBox listBox2;
        private Label label3;
        private Button disconnectBtn;
    }
}