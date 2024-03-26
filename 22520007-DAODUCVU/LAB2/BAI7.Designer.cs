namespace LAB2
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
            components = new System.ComponentModel.Container();
            imageList1 = new ImageList(components);
            treeViewFiles = new TreeView();
            richTextBoxContent = new RichTextBox();
            pictureBoxContent = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxContent).BeginInit();
            SuspendLayout();
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageSize = new Size(16, 16);
            imageList1.TransparentColor = Color.Transparent;
            // 
            // treeViewFiles
            // 
            treeViewFiles.Location = new Point(12, 12);
            treeViewFiles.Name = "treeViewFiles";
            treeViewFiles.Size = new Size(261, 533);
            treeViewFiles.TabIndex = 0;
            treeViewFiles.AfterSelect += treeViewFiles_AfterSelect;
            treeViewFiles.NodeMouseDoubleClick += treeViewFiles_NodeMouseDoubleClick;
            // 
            // richTextBoxContent
            // 
            richTextBoxContent.Location = new Point(286, 12);
            richTextBoxContent.Name = "richTextBoxContent";
            richTextBoxContent.Size = new Size(657, 532);
            richTextBoxContent.TabIndex = 1;
            richTextBoxContent.Text = "";
            richTextBoxContent.TextChanged += richTextBoxContent_TextChanged;
            // 
            // pictureBoxContent
            // 
            pictureBoxContent.Location = new Point(286, 12);
            pictureBoxContent.Name = "pictureBoxContent";
            pictureBoxContent.Size = new Size(657, 533);
            pictureBoxContent.TabIndex = 2;
            pictureBoxContent.TabStop = false;
            // 
            // BAI7
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(955, 557);
            Controls.Add(pictureBoxContent);
            Controls.Add(richTextBoxContent);
            Controls.Add(treeViewFiles);
            Name = "BAI7";
            Text = "BAI7";
            ((System.ComponentModel.ISupportInitialize)pictureBoxContent).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ImageList imageList1;
        private TreeView treeViewFiles;
        private RichTextBox richTextBoxContent;
        private PictureBox pictureBoxContent;
    }
}