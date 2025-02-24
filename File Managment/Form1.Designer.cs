namespace File_Managment
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            leftPathTextBox = new TextBox();
            rightPathTextBox = new TextBox();
            moveRightButton = new Button();
            moveLeftButton = new Button();
            copyButton = new Button();
            deleteButton = new Button();
            backButton = new Button();
            leftListBox = new ListBox();
            rightListBox = new ListBox();
            SuspendLayout();
            // 
            // leftPathTextBox
            // 
            leftPathTextBox.Location = new Point(47, 44);
            leftPathTextBox.Margin = new Padding(2, 2, 2, 2);
            leftPathTextBox.Name = "leftPathTextBox";
            leftPathTextBox.ReadOnly = true;
            leftPathTextBox.Size = new Size(185, 23);
            leftPathTextBox.TabIndex = 0;
            // 
            // rightPathTextBox
            // 
            rightPathTextBox.Location = new Point(332, 44);
            rightPathTextBox.Margin = new Padding(2, 2, 2, 2);
            rightPathTextBox.Name = "rightPathTextBox";
            rightPathTextBox.ReadOnly = true;
            rightPathTextBox.Size = new Size(185, 23);
            rightPathTextBox.TabIndex = 1;
            // 
            // moveRightButton
            // 
            moveRightButton.Location = new Point(263, 118);
            moveRightButton.Margin = new Padding(2, 2, 2, 2);
            moveRightButton.Name = "moveRightButton";
            moveRightButton.Size = new Size(34, 20);
            moveRightButton.TabIndex = 4;
            moveRightButton.Text = ">";
            moveRightButton.UseVisualStyleBackColor = true;
            moveRightButton.Click += moveRightButton_Click;
            // 
            // moveLeftButton
            // 
            moveLeftButton.Location = new Point(263, 149);
            moveLeftButton.Margin = new Padding(2, 2, 2, 2);
            moveLeftButton.Name = "moveLeftButton";
            moveLeftButton.Size = new Size(34, 20);
            moveLeftButton.TabIndex = 5;
            moveLeftButton.Text = "<";
            moveLeftButton.UseVisualStyleBackColor = true;
            moveLeftButton.Click += moveLeftButton_Click;
            // 
            // copyButton
            // 
            copyButton.Location = new Point(47, 235);
            copyButton.Margin = new Padding(2, 2, 2, 2);
            copyButton.Name = "copyButton";
            copyButton.Size = new Size(78, 20);
            copyButton.TabIndex = 6;
            copyButton.Text = "Copy";
            copyButton.UseVisualStyleBackColor = true;
            copyButton.Click += copyButton_Click;
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(244, 235);
            deleteButton.Margin = new Padding(2, 2, 2, 2);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(78, 20);
            deleteButton.TabIndex = 7;
            deleteButton.Text = "Delete";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click;
            // 
            // backButton
            // 
            backButton.Location = new Point(438, 235);
            backButton.Margin = new Padding(2, 2, 2, 2);
            backButton.Name = "backButton";
            backButton.Size = new Size(78, 20);
            backButton.TabIndex = 8;
            backButton.Text = "Back";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // leftListBox
            // 
            leftListBox.FormattingEnabled = true;
            leftListBox.ItemHeight = 15;
            leftListBox.Location = new Point(47, 82);
            leftListBox.Margin = new Padding(2, 2, 2, 2);
            leftListBox.Name = "leftListBox";
            leftListBox.Size = new Size(185, 139);
            leftListBox.TabIndex = 9;
            leftListBox.Click += HandleSingleClick;
            leftListBox.DoubleClick += HandleDoubleClickListBox;
            // 
            // rightListBox
            // 
            rightListBox.FormattingEnabled = true;
            rightListBox.ItemHeight = 15;
            rightListBox.Location = new Point(332, 82);
            rightListBox.Margin = new Padding(2, 2, 2, 2);
            rightListBox.Name = "rightListBox";
            rightListBox.Size = new Size(185, 139);
            rightListBox.TabIndex = 10;
            rightListBox.Click += HandleSingleClick;
            rightListBox.DoubleClick += HandleDoubleClickListBox;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 270);
            Controls.Add(rightListBox);
            Controls.Add(leftListBox);
            Controls.Add(backButton);
            Controls.Add(deleteButton);
            Controls.Add(copyButton);
            Controls.Add(moveLeftButton);
            Controls.Add(moveRightButton);
            Controls.Add(rightPathTextBox);
            Controls.Add(leftPathTextBox);
            Margin = new Padding(2, 2, 2, 2);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox leftPathTextBox;
        private TextBox rightPathTextBox;
        private Button moveRightButton;
        private Button moveLeftButton;
        private Button copyButton;
        private Button deleteButton;
        private Button backButton;
        private ListBox leftListBox;
        private ListBox rightListBox;
    }
}
