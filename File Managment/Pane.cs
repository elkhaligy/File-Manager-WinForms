using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Managment
{

    internal class Pane
    {
        // Bundle of data that represents a pane in the form
        public ListBox ListBox { get; } // List box reference to the ui control
        public TextBox PathTextBox { get; } // Path text box reference to the ui control
        public string CurrentPath { get; set; } // Current path of the pane
        public string SelectedItem { get; set; } // Current selected item in the list box
        public int Depth { get; set; } // Current depth of the pane

        // Constructor that initializes the state of the pane
        public Pane(ListBox listBox, TextBox textBox)
        {
            ListBox         = listBox;  // Set the list box reference, this is called by outside world
            PathTextBox     = textBox;  // Set the path text box reference, this is called by outside world
            CurrentPath     = "";       // Initialize the current path to empty string as we're in root
            SelectedItem    = "";       // Initialize the selected item to empty string as nothing is selected
            Depth           = 0;        // Initialize the depth to 0 as we're in root
        }

        // Methods that operates on the bundled data (types), each method needs to look at the object state and see if it needs to operate on it or not
        public void LoadDrives()
        {
            /* This methods is called on the Pane type and it alter the
             * internal state of the Pane object and populates its listbox with the drives
             * it doesn't need to alter the depth or the selected item 
             * it only alters the listbox and pathtextbox and currentpath states
            */

            ListBox.Items.Clear();      // Clear the list box
            PathTextBox.Text    = "";   // Clear the path text box
            CurrentPath         = "";   // Clear the current path
        }


    }
}
