using System.IO;

namespace File_Managment
{
    public partial class Form1 : Form
    {
        /* Notes */
        // My Form1 custom datatype has fields of different types too
        // It also has behavior that operates on these fields
        // A user-defined datatype like Form1 encapsulates data and behavior
        // It is a way to organize data and the behavior on it, more like a built-in data structure and type
        // Datatype is the memory layout of the data and the operations that can be performed on it

        // Directory -> Folder
        // File -> File

        private string? lastAccessedPane;
        private string? selectedItemLeft;
        private string? selectedItemRight;

        private string? currentLeftPath;
        private string? currentRightPath;
        private int leftDepth;
        private int rightDepth;


        public Form1()
        {
            InitializeComponent();
            Text = "File Manager";
            lastAccessedPane = "left";
            currentLeftPath = "";
            currentRightPath = "";
            selectedItemLeft = null;
            selectedItemRight = null;
            leftDepth = 0;
            rightDepth = 0;

            // Load drives to left and right list boxes
            LoadDrives(leftListBox);
            LoadDrives(rightListBox);
        }


        private void LoadDrives(ListBox pane)
        {

            pane.Items.Clear();
            var pathBox = pane == leftListBox ? leftPathTextBox : rightPathTextBox;
            pathBox.Text = "";
            if (pathBox == leftPathTextBox)
                leftDepth = 0;
            else
                rightDepth = 0;
            // We will use DriveInfo class to get all drives
            DriveInfo[] drives = DriveInfo.GetDrives();

            // Add drivers names to the pane
            foreach (var drive in drives)
            {
                //MessageBox.Show(drive.Name);
                pane.Items.Add(drive.Name);
            }
            UpdateMoveButtonsState();

        }

        public void LoadDirectoryContents(ListBox pane, string path)
        {
            /* 
                Takes a path to a file or folder
                If the path is a file, show a message box
                If the path is a folder, populate the pane with the contents of the folder
                Add the path to the path box
             */

            selectedItemLeft = null;
            selectedItemRight = null;

            pane.Items.Clear();
            pane.Items.Add(".");
            pane.Items.Add("..");

            // Search for all folders inside a path
            var directories = Directory.GetDirectories(path);
            foreach (var directory in directories)
            {
                pane.Items.Add(Path.GetFileName(directory));
            }

            // Search for all files inside a path
            var files = Directory.GetFiles(path);
            foreach (var file in files)
            {
                pane.Items.Add(Path.GetFileName(file));
            }
            UpdateMoveButtonsState();
        }
        private void HandleDoubleClickListBox(Object sender, EventArgs e)
        {


            /* 
             * Extract the selected item that was double clicked on
               Extract the path of the selected item from the path box and from the name of the selected item
               Call the function that populates the panes with the contents of the selected item
               (LoadDirectoryContents)
             */
            ListBox? listBox = sender as ListBox;
            selectedItemLeft = null;
            selectedItemRight = null;
            if (listBox.SelectedItem == null)
            {
                MessageBox.Show("nothing selected");
                return;
            }

            string path;
            string selectedItemName = listBox.SelectedItem.ToString();

            // When I press a double click on a drive or folder or file
            // the currentPath that is tracked must be updated
            // for example if I double click on C:\ then the currentPath will be C:\
            // and because it is a string represnation "C:\\" or @"C:\"

            if (selectedItemName == ".")
            {
                backButton_Click(sender, e);
                return;
            }
            else if (selectedItemName == "..")
            {
                var pane = lastAccessedPane == "left" ? leftListBox : rightListBox;
                LoadDrives(pane);
                return;
            }
            // I double tabbed on the left box
            if (listBox.Name == "leftListBox")
            {
                lastAccessedPane = "left";

                if (leftPathTextBox.Text.Length > 0 && !leftPathTextBox.Text.EndsWith("\\"))
                    currentLeftPath = leftPathTextBox.Text + "\\" + selectedItemName;
                else
                    currentLeftPath = leftPathTextBox.Text + selectedItemName;

                leftPathTextBox.Text = currentLeftPath;
                path = currentLeftPath;
                if (File.Exists(path))
                {
                    MessageBox.Show("This is a file");
                    path = Directory.GetParent(path).FullName;
                    currentLeftPath = path;
                    leftPathTextBox.Text = path;

                    return;
                }
                leftDepth += 1;
            }
            else
            {
                lastAccessedPane = "right";


                if (rightPathTextBox.Text.Length > 0 && !rightPathTextBox.Text.EndsWith("\\"))
                    currentRightPath = rightPathTextBox.Text + "\\" + selectedItemName;
                else
                    currentRightPath = rightPathTextBox.Text + selectedItemName;

                rightPathTextBox.Text = currentRightPath;
                path = currentRightPath;
                if (File.Exists(path))
                {
                    MessageBox.Show("This is a file");
                    path = Directory.GetParent(path).FullName;
                    currentRightPath = path;
                    rightPathTextBox.Text = currentRightPath;

                    return;
                }
                rightDepth += 1;
            }
            LoadDirectoryContents(pane: listBox, path: path);
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            /*
             * Check the last accessed pane
             * If you can go back in the last accessed pane path then go back
             * 
             */

            ListBox pane = lastAccessedPane == "left" ? leftListBox : rightListBox;
            TextBox pathBox = lastAccessedPane == "left" ? leftPathTextBox : rightPathTextBox;
            if (pathBox.Text == "")
                return;
            DirectoryInfo parent = Directory.GetParent(pathBox.Text);

            selectedItemLeft = null;
            selectedItemRight = null;
            if (lastAccessedPane == "left")
            {

                if (leftDepth == 1)
                {
                    LoadDrives(pane);
                    pathBox.Text = "";
                    currentLeftPath = "";
                    leftDepth = 0;
                    UpdateMoveButtonsState();
                    return;
                }
                leftDepth -= 1;
                currentLeftPath = parent.FullName;
            }
            else
            {

                if (rightDepth == 1)
                {
                    LoadDrives(pane);
                    pathBox.Text = "";
                    rightDepth = 0;
                    currentRightPath = "";
                    UpdateMoveButtonsState();
                    return;
                }
                rightDepth -= 1;
                currentRightPath = parent.FullName;

            }
            LoadDirectoryContents(pane, parent.FullName);
            pathBox.Text = parent.FullName;
        }

        private void copyButton_Click(object sender, EventArgs e)
        {
            if (selectedItemLeft == null && selectedItemRight == null)
            {
                MessageBox.Show("Nothing selected");
                return;
            }
            if (currentLeftPath.Length == 0 || currentRightPath.Length == 0)
            {
                MessageBox.Show("Cannot copy from or to a drive");
                return;
            }

            if (lastAccessedPane == "left")
            {
                string sourcePath = currentLeftPath + "\\" + selectedItemLeft;
                string destinationPath = currentRightPath + "\\" + selectedItemLeft;
                if (File.Exists(sourcePath))
                {
                    File.Copy(sourcePath, destinationPath, true);
                }
                else
                {
                    CopyDirectory(sourcePath, destinationPath);
                }
                MessageBox.Show("Copied Successfully");
                LoadDirectoryContents(rightListBox, currentRightPath);
            }
            else
            {
                string sourcePath = currentRightPath + "\\" + selectedItemRight;
                string destinationPath = currentLeftPath + "\\" + selectedItemRight;
                if (File.Exists(sourcePath))
                {
                    File.Copy(sourcePath, destinationPath, true);
                }
                else
                {
                    CopyDirectory(sourcePath, destinationPath);
                }
                CopyDirectory(sourcePath, destinationPath);
                MessageBox.Show("Copied Successfully");
                LoadDirectoryContents(leftListBox, currentLeftPath);
            }
        }



        private void CopyDirectory(string sourceDir, string destinationDir)
        {
            if (!Directory.Exists(destinationDir))
            {
                Directory.CreateDirectory(destinationDir);
            }

            foreach (string file in Directory.GetFiles(sourceDir))
            {
                // file only = the full path of the file
                // Path.GetFileName(file) = the name of the file with its extention only
                string destFile = Path.Combine(destinationDir, Path.GetFileName(file));
                File.Copy(file, destFile, true);
            }

            foreach (string subDir in Directory.GetDirectories(sourceDir))
            {
                string newDestinationDir = Path.Combine(destinationDir, Path.GetFileName(subDir));
                CopyDirectory(subDir, newDestinationDir); // Recursive call
            }

        }


        private void HandleSingleClick(object sender, EventArgs e)
        {
            ListBox? listBox = sender as ListBox;
            if (listBox.Name == "leftListBox")
            {
                lastAccessedPane = "left";
                if (listBox.SelectedItem != null)
                    selectedItemLeft = listBox.SelectedItem.ToString();
                else
                    selectedItemLeft = null;
            }
            else
            {
                lastAccessedPane = "right";
                if (listBox.SelectedItem != null)
                    selectedItemRight = listBox.SelectedItem.ToString();
                else
                    selectedItemRight = null;
            }
            UpdateMoveButtonsState();
        }

        private void UpdateMoveButtonsState()
        {
            if (selectedItemLeft == null && selectedItemRight == null || (leftPathTextBox.Text.Length == 0 || rightPathTextBox.Text.Length == 0))
            {
                moveLeftButton.Enabled = false;
                moveRightButton.Enabled = false;
            }
            else
            {
                moveLeftButton.Enabled = true;
                moveRightButton.Enabled = true;
            }
        }

        private void moveRightButton_Click(object sender, EventArgs e)
        {
            if (lastAccessedPane == "right")
                return;
            string sourcePath = currentLeftPath + "\\" + selectedItemLeft;
            string destinationPath = currentRightPath + "\\" + selectedItemLeft;
            if (File.Exists(sourcePath))
            {
                File.Move(sourcePath, destinationPath);
            }
            else
            {
                Directory.Move(sourcePath, destinationPath);
            }
            LoadDirectoryContents(leftListBox, currentLeftPath);
            LoadDirectoryContents(rightListBox, currentRightPath);

        }

        private void moveLeftButton_Click(object sender, EventArgs e)
        {
            if (lastAccessedPane == "left")
                return;
            string sourcePath = currentRightPath + "\\" + selectedItemRight;
            string destinationPath = currentLeftPath + "\\" + selectedItemRight;
            if (File.Exists(sourcePath))
            {
                File.Move(sourcePath, destinationPath);
            }
            else
            {
                Directory.Move(sourcePath, destinationPath);
            }
            LoadDirectoryContents(leftListBox, currentLeftPath);
            LoadDirectoryContents(rightListBox, currentRightPath);
        }
    }
}
