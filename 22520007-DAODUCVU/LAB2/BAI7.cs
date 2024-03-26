using System;
using System.IO;
using System.Windows.Forms;

namespace LAB2
{
    public partial class BAI7 : Form
    {
        public BAI7()
        {
            InitializeComponent();
            InitializeTreeView();
        }

        private void InitializeTreeView()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                TreeNode driveNode = new TreeNode(drive.Name);
                driveNode.Tag = drive.RootDirectory;
                treeViewFiles.Nodes.Add(driveNode);
                LoadDirectories(drive.RootDirectory, driveNode);
            }
        }

        private void LoadDirectories(DirectoryInfo directory, TreeNode parentNode)
        {
            try
            {
                foreach (DirectoryInfo dir in directory.GetDirectories())
                {
                    TreeNode node = new TreeNode(dir.Name);
                    node.Tag = dir;
                    parentNode.Nodes.Add(node);
                    // Add a dummy node to the directory node
                    node.Nodes.Add("Expand");
                }
            }
            catch (UnauthorizedAccessException)
            {
                // Handle unauthorized access to directories
            }
        }

        private void LoadFiles(TreeNode directoryNode)
        {
            DirectoryInfo directory = (DirectoryInfo)directoryNode.Tag;
            try
            {
                foreach (FileInfo file in directory.GetFiles())
                {
                    TreeNode node = new TreeNode(file.Name);
                    node.Tag = file;
                    directoryNode.Nodes.Add(node);
                }
            }
            catch (UnauthorizedAccessException)
            {
                // Handle unauthorized access to files
            }
        }


        private void treeViewFiles_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ////Load files when a directory node is expanded
            //if (e.Node.Nodes.Count == 1 && e.Node.Nodes[0].Text == "Expand")
            //{
            //    e.Node.Nodes.Clear();
            //    LoadFiles(e.Node);
            //}

            if (e.Node.Text == "Expand")
            {
                TreeNode parentNode = e.Node.Parent;
                if(parentNode != null)
                {
                    parentNode.Nodes.Clear();
                    LoadFiles(parentNode);
                }
            }
        }

        private void treeViewFiles_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag is DirectoryInfo)
            {
                DirectoryInfo directory = (DirectoryInfo)e.Node.Tag;
                e.Node.Nodes.Clear();
                LoadDirectories(directory, e.Node);
                // Add the "Expand" node again
                e.Node.Nodes.Add("Expand");
            }

            if (e.Node.Tag is FileInfo)
            {
                FileInfo selectedFile = (FileInfo)e.Node.Tag;

                if (IsImageFile(selectedFile))
                {
                    // If the selected file is an image file, display it in the PictureBox
                    ShowImage(selectedFile.FullName);
                }
                else
                {
                    // If it's not an image file, attempt to read its content and display it in the RichTextBox
                    ShowTextContent(selectedFile.FullName);
                }
            }

        }
        private bool IsImageFile(FileInfo file)
        {
            // Check if the file extension indicates an image format
            string[] imageExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };
            string extension = file.Extension.ToLower();
            return Array.Exists(imageExtensions, ext => ext == extension);
        }

        private void ShowImage(string imagePath)
        {
            // Hide the RichTextBox and display the PictureBox with the image
            pictureBoxContent.Image = Image.FromFile(imagePath);
            pictureBoxContent.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxContent.Visible = true;
            richTextBoxContent.Visible = false;
        }

        private void ShowTextContent(string filePath)
        {
            // Attempt to read the content of the file and display it in the RichTextBox
            try
            {
                string content = File.ReadAllText(filePath);
                richTextBoxContent.Text = content;
            }
            catch (Exception ex)
            {
                // Handle any exceptions that might occur during file reading
                richTextBoxContent.Text = "Error: " + ex.Message;
            }

            // Hide the PictureBox and display the RichTextBox with the file content
            pictureBoxContent.Visible = false;
            richTextBoxContent.Visible = true;
        }

        private void richTextBoxContent_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
