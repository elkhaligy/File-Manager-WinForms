using System.IO;

namespace File_Managment
{
    public partial class Form1 : Form
    {

        // Class form1 bundles two panes together
        private Pane leftPane;
        private Pane rightPane;

        public Form1()
        {
            InitializeComponent();
            Text = "Dual-Pane File Manager";

            leftPane = new Pane(leftListBox, leftPathTextBox);
            rightPane = new Pane(rightListBox, rightPathTextBox);
            leftPane.LoadDrives();
            rightPane.LoadDrives();
        }

        // Methods that expose this class to the GUI world
        private void moveLeftButton_Click(object sender, EventArgs e) { }
        private void moveRightButton_Click(object sender, EventArgs e) { }
        private void HandleSingleClick(object sender, EventArgs e)
        {
            ListBox listBox = sender as ListBox;
            Pane clickedPane = listBox == leftListBox ? leftPane : rightPane;
            Pane.lastAccessedPane = clickedPane == leftPane ? "left" : "right";
            if (listBox.SelectedItem != null)
                clickedPane.SelectedItem = listBox.SelectedItem.ToString();

        }

        private void copyButton_Click(object sender, EventArgs e)
        {
            // Copy needs a source path and a destination path
            // It needs to check if the source path is a file or a folder
            // destination is always a folder
            Pane paneToCopyFrom = Pane.lastAccessedPane == "left" ? leftPane : rightPane;
            Pane paneToCopyTo = paneToCopyFrom == leftPane ? rightPane : leftPane;

            if (paneToCopyFrom.SelectedItem == "")
            {
                MessageBox.Show("Please select a directory or a file first!");
            }
            else if (paneToCopyFrom.CurrentPath == "")
            {
                MessageBox.Show("You can't copy a drive!");
            }
            else if (paneToCopyTo.CurrentPath == "")
            {
                MessageBox.Show("You can't copy to root!");
            }
            else
            {

                string sourcePath = paneToCopyFrom.CurrentPath;
                string destinationPath = paneToCopyTo.CurrentPath;

                sourcePath = Path.Combine(sourcePath, paneToCopyFrom.SelectedItem);
                destinationPath = Path.Combine(destinationPath, paneToCopyFrom.SelectedItem);

                Utility.Copy(sourcePath, destinationPath);

                paneToCopyFrom.LoadDirectory(paneToCopyFrom.CurrentPath);
                paneToCopyTo.LoadDirectory(paneToCopyTo.CurrentPath);
                MessageBox.Show("Copy completed");
            }

        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Pane clickedPane = Pane.lastAccessedPane == "left" ? leftPane : rightPane;
            clickedPane.GoBack();
        }

        private void HandleDoubleClickListBox(Object sender, EventArgs e)
        {
            /*
             * This method is called by the outside world when a double click is detected on a list box
             * It needs to construct the path of the selected item and call the LoadDirectory method of the bundled Pane
             * It needs to check for the selected item if it is . or ..
             * It doesn't care if the path is a file or a folder, validation is handled by the Pane
             */
            ListBox listBox = sender as ListBox;                                // Cast the sender to a ListBox
            Pane clickedPane = listBox == leftListBox ? leftPane : rightPane;   // Get the Pane bundle that corresponds to the ListBox
            Pane.lastAccessedPane = clickedPane == leftPane ? "left" : "right"; // Set the last accessed pane to the current pane

            // Check if the double click is on a file or a folder
            if (listBox.SelectedItem == null)
            {
                MessageBox.Show("nothing selected");
            }
            else if (listBox.SelectedItem.ToString() == ".")
            {
                // Go back one level
                clickedPane.GoBack();
            }
            else if (listBox.SelectedItem.ToString() == "..")
            {
                // Load drives
                clickedPane.LoadDrives();
            }
            else
            {
                string selectedItemPath = Path.Combine(clickedPane.CurrentPath, listBox.SelectedItem.ToString());
                clickedPane.LoadDirectory(selectedItemPath);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            Pane activePane = Pane.lastAccessedPane == "left" ? leftPane : rightPane;

            if (string.IsNullOrEmpty(activePane.SelectedItem))
            {
                MessageBox.Show("Please select a file or folder first!");
                return;
            }

            string fullPath = Path.Combine(activePane.CurrentPath, activePane.SelectedItem);
            Utility.Delete(fullPath);

            activePane.LoadDirectory(activePane.CurrentPath);
        }
    }
}
