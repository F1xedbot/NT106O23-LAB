namespace LAB3
{
    partial class BAI3_Server
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
            button1 = new Button();
            listBox1 = new ListBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(400, 23);
            button1.Name = "button1";
            button1.Size = new Size(131, 37);
            button1.TabIndex = 0;
            button1.Text = "Listen";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(23, 66);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(508, 324);
            listBox1.TabIndex = 1;
            // 
            // BAI3_Server
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(556, 414);
            Controls.Add(listBox1);
            Controls.Add(button1);
            Name = "BAI3_Server";
            Text = "BAI3_Server";
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private ListBox listBox1;
    }
}