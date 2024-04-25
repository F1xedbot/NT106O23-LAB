namespace LAB3
{
    partial class BAI3_Client
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
            richTextBox1 = new RichTextBox();
            disconnectBtn = new Button();
            sendBtn = new Button();
            connectBtn = new Button();
            SuspendLayout();
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(12, 28);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(383, 168);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            // 
            // disconnectBtn
            // 
            disconnectBtn.Enabled = false;
            disconnectBtn.Location = new Point(414, 151);
            disconnectBtn.Name = "disconnectBtn";
            disconnectBtn.Size = new Size(131, 45);
            disconnectBtn.TabIndex = 3;
            disconnectBtn.Text = "Disconnect";
            disconnectBtn.UseVisualStyleBackColor = true;
            disconnectBtn.Click += disconnectBtn_Click;
            // 
            // sendBtn
            // 
            sendBtn.Enabled = false;
            sendBtn.Location = new Point(414, 90);
            sendBtn.Name = "sendBtn";
            sendBtn.Size = new Size(131, 45);
            sendBtn.TabIndex = 4;
            sendBtn.Text = "Send";
            sendBtn.UseVisualStyleBackColor = true;
            sendBtn.Click += sendBtn_Click;
            // 
            // connectBtn
            // 
            connectBtn.Location = new Point(414, 28);
            connectBtn.Name = "connectBtn";
            connectBtn.Size = new Size(131, 45);
            connectBtn.TabIndex = 5;
            connectBtn.Text = "Connect";
            connectBtn.UseVisualStyleBackColor = true;
            connectBtn.Click += connectBtn_Click;
            // 
            // BAI3_Client
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(557, 213);
            Controls.Add(connectBtn);
            Controls.Add(sendBtn);
            Controls.Add(disconnectBtn);
            Controls.Add(richTextBox1);
            Name = "BAI3_Client";
            Text = "BAI3_Client";
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox richTextBox1;
        private Button disconnectBtn;
        private Button sendBtn;
        private Button connectBtn;
    }
}