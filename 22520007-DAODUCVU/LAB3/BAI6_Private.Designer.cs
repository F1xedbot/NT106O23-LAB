namespace LAB3
{
    partial class BAI6_Private
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
            privateMessageInput = new TextBox();
            attachBtn = new Button();
            sendBtn = new Button();
            attachmentLabel = new Label();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(12, 12);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(610, 264);
            listBox1.TabIndex = 0;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // privateMessageInput
            // 
            privateMessageInput.Location = new Point(12, 318);
            privateMessageInput.Name = "privateMessageInput";
            privateMessageInput.Size = new Size(431, 27);
            privateMessageInput.TabIndex = 1;
            // 
            // attachBtn
            // 
            attachBtn.Location = new Point(456, 318);
            attachBtn.Name = "attachBtn";
            attachBtn.Size = new Size(50, 29);
            attachBtn.TabIndex = 2;
            attachBtn.Text = "...";
            attachBtn.UseVisualStyleBackColor = true;
            attachBtn.Click += attachBtn_Click;
            // 
            // sendBtn
            // 
            sendBtn.Location = new Point(512, 318);
            sendBtn.Name = "sendBtn";
            sendBtn.Size = new Size(110, 29);
            sendBtn.TabIndex = 3;
            sendBtn.Text = "Send";
            sendBtn.UseVisualStyleBackColor = true;
            sendBtn.Click += sendBtn_Click;
            // 
            // attachmentLabel
            // 
            attachmentLabel.AutoSize = true;
            attachmentLabel.Location = new Point(12, 295);
            attachmentLabel.Name = "attachmentLabel";
            attachmentLabel.Size = new Size(103, 20);
            attachmentLabel.TabIndex = 4;
            attachmentLabel.Text = "Attached File: ";
            // 
            // BAI6_Private
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(634, 355);
            Controls.Add(attachmentLabel);
            Controls.Add(sendBtn);
            Controls.Add(attachBtn);
            Controls.Add(privateMessageInput);
            Controls.Add(listBox1);
            Name = "BAI6_Private";
            Text = "BAI6_Private";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBox1;
        private TextBox privateMessageInput;
        private Button attachBtn;
        private Button sendBtn;
        private Label attachmentLabel;
    }
}