namespace LAB4
{
    partial class BAI3
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
            textBox1 = new TextBox();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)webView21).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(43, 30);
            button1.Name = "button1";
            button1.Size = new Size(95, 37);
            button1.TabIndex = 0;
            button1.Text = "Load";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(144, 35);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(346, 27);
            textBox1.TabIndex = 1;
            // 
            // button2
            // 
            button2.Location = new Point(496, 30);
            button2.Name = "button2";
            button2.Size = new Size(95, 37);
            button2.TabIndex = 2;
            button2.Text = "Reload";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(299, 73);
            button3.Name = "button3";
            button3.Size = new Size(141, 37);
            button3.TabIndex = 3;
            button3.Text = "Download Files";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(446, 73);
            button4.Name = "button4";
            button4.Size = new Size(145, 37);
            button4.TabIndex = 4;
            button4.Text = "View Source";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // webView21
            // 
            webView21.AllowExternalDrop = true;
            webView21.CreationProperties = null;
            webView21.DefaultBackgroundColor = Color.White;
            webView21.Location = new Point(44, 129);
            webView21.Name = "webView21";
            webView21.Size = new Size(547, 288);
            webView21.TabIndex = 5;
            webView21.ZoomFactor = 1D;
            // 
            // BAI3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(636, 429);
            Controls.Add(webView21);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Name = "BAI3";
            Text = "BAI3";
            ((System.ComponentModel.ISupportInitialize)webView21).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox textBox1;
        private Button button2;
        private Button button3;
        private Button button4;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
    }
}