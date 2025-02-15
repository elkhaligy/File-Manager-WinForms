using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace File_Managment
{

    internal class Pane
    {
        // Bundle of data that represents a pane in the form
        public ListBox ListBox { get; }             // List box reference to the ui control
        public TextBox PathTextBox { get; }         // Path text box reference to the ui control
        public string CurrentPath { get; set; }     // Current path of the pane
        public string SelectedItem { get; set; }    // Current selected item in the list box

        public static string lastAccessedPane;

        //public int Depth { get; set; }              // Current depth of the pane

        // Constructor that initializes the state of the pane
        public Pane(ListBox listBox, TextBox textBox)
        {
            ListBox         = listBox;  // Set the list box reference, this is called by outside world
            PathTextBox     = textBox;  // Set the path text box reference, this is called by outside world
            CurrentPath     = "";       // Initialize the current path to empty string as we're in root
            SelectedItem    = "";       // Initialize the selected item to empty string as nothing is selected
        }

        // Static constructor
        static Pane()
        {
            lastAccessedPane = "left";
        }

        // Methods that operates on the bundled data (types), each method needs to look at the object state and see if it needs to operate on it or not
        // Methods can call outside world objects (bundles) to get the data it needs to operate on its own bundled data state
        public void LoadDrives()
        {
            /* 
             * This method is called on the Pane type and it alters the
             * internal state of the Pane object and populates its listbox with the drives
             * it doesn't need to alter the depth or the selected item 
             * it only alters the listbox and pathtextbox and currentpath states
            */

            ListBox.Items.Clear();      // Clear the list box
            PathTextBox.Text    = "";   // Clear the path text box
            CurrentPath         = "";   // Clear the current path
            //Depth               = 0;    // Reset the depth
            // Method logic

            /*
             * Add the . and .. items to the list box
            */
            ListBox.Items.Add(".");
            ListBox.Items.Add("..");

            /* 
             * Get the drives in the system and populate the list box with them
             * and set the path text box to the current path
            */
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                ListBox.Items.Add(drive);
            }
        }

        // Method can take parameters from the outside world to operate on its own bundle state
        // Always think What, do not think How
        // To use any API, you need to know what it does and what it needs to operate and what is returns
        // Methods can have their own local types too
        public void LoadDirectory(string path)
        {
            /*
             * This method is called on the Pane type and it alters the
             * internal state of the Pane bundle and populates its listbox with the directories
             * This method is called by the outside world
             * this API input is path which is a string type
             * this API alters these states: ListBox, PathTextBox, CurrentPath, Depth
             * path needs to be a valid directory path and not a file path
             * path validation is done by this method
            */
            string[] directories;
            try
            {
                directories = Directory.GetDirectories(path);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show($"Unauthorized Access Exception at path {path}!");
                return;
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show($"Directory Not Found Exception at path {path}!");
                return;
            }
            catch (IOException)
            {
                MessageBox.Show($"IO Exception at path {path} this is a file and not a directory!");
                return;
            }
            catch (ArgumentException)
            {
                // Empty Path
                LoadDrives();
                //MessageBox.Show($"Argument Exception, the path passed is empty!");
                return;
            }
            ListBox.Items.Clear();
            PathTextBox.Text = path;
            CurrentPath = path;

            // Method logic
            /*
             * Add the . and .. items to the list box
            */
            ListBox.Items.Add(".");
            ListBox.Items.Add("..");

            /*
             * Get the directories in the path and populate the list box with them
            */

            foreach (string directory in directories)
            {
                ListBox.Items.Add(Path.GetFileName(directory));
            }

            /*
             * Get the files in the path and populate the list box with them
            */
            foreach (string file in Directory.GetFiles(path))
            {
                ListBox.Items.Add(Path.GetFileName(file));
            }
        }

        // Methods of the same bundle can also call methods of the same bundle
        public void GoBack()
        {
            /*
             * This method is called on the Pane bundle 
             * What does it do? it goes back to the parent directory
             * It alters the following states: ListBox, PathTextBox, CurrentPath, Depth
             * It doesn't take anything from the outside world, it only operates on its own bundle state
             */
            if (CurrentPath == "")
            {
                MessageBox.Show("Cannot go back from root!");
            }
            else
            {
                // Method Logic
                // Get the parent directory of the current path

                DirectoryInfo parent = Directory.GetParent(CurrentPath);
                if (parent == null) // Root directory
                {
                    LoadDrives();
                }
                else
                {
                    LoadDirectory(parent.FullName);
                }
            }
        }
    }
}
