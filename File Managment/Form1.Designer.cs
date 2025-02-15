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
            leftPathTextBox.Location = new Point(67, 74);
            leftPathTextBox.Name = "leftPathTextBox";
            leftPathTextBox.ReadOnly = true;
            leftPathTextBox.Size = new Size(263, 31);
            leftPathTextBox.TabIndex = 0;
            // 
            // rightPathTextBox
            // 
            rightPathTextBox.Location = new Point(474, 74);
            rightPathTextBox.Name = "rightPathTextBox";
            rightPathTextBox.ReadOnly = true;
            rightPathTextBox.Size = new Size(263, 31);
            rightPathTextBox.TabIndex = 1;
            // 
            // moveRightButton
            // 
            moveRightButton.Location = new Point(376, 196);
            moveRightButton.Name = "moveRightButton";
            moveRightButton.Size = new Size(48, 34);
            moveRightButton.TabIndex = 4;
            moveRightButton.Text = ">";
            moveRightButton.UseVisualStyleBackColor = true;
            moveRightButton.Click += moveRightButton_Click;
            // 
            // moveLeftButton
            // 
            moveLeftButton.Location = new Point(376, 248);
            moveLeftButton.Name = "moveLeftButton";
            moveLeftButton.Size = new Size(48, 34);
            moveLeftButton.TabIndex = 5;
            moveLeftButton.Text = "<";
            moveLeftButton.UseVisualStyleBackColor = true;
            moveLeftButton.Click += moveLeftButton_Click;
            // 
            // copyButton
            // 
            copyButton.Location = new Point(67, 392);
            copyButton.Name = "copyButton";
            copyButton.Size = new Size(112, 34);
            copyButton.TabIndex = 6;
            copyButton.Text = "Copy";
            copyButton.UseVisualStyleBackColor = true;
            copyButton.Click += copyButton_Click;
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(348, 392);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(112, 34);
            deleteButton.TabIndex = 7;
            deleteButton.Text = "Delete";
            deleteButton.UseVisualStyleBackColor = true;
            // 
            // backButton
            // 
            backButton.Location = new Point(625, 392);
            backButton.Name = "backButton";
            backButton.Size = new Size(112, 34);
            backButton.TabIndex = 8;
            backButton.Text = "Back";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // leftListBox
            // 
            leftListBox.FormattingEnabled = true;
            leftListBox.ItemHeight = 25;
            leftListBox.Location = new Point(67, 136);
            leftListBox.Name = "leftListBox";
            leftListBox.Size = new Size(263, 229);
            leftListBox.TabIndex = 9;
            leftListBox.Click += HandleSingleClick;
            leftListBox.DoubleClick += HandleDoubleClickListBox;
            // 
            // rightListBox
            // 
            rightListBox.FormattingEnabled = true;
            rightListBox.ItemHeight = 25;
            rightListBox.Location = new Point(474, 136);
            rightListBox.Name = "rightListBox";
            rightListBox.Size = new Size(263, 229);
            rightListBox.TabIndex = 10;
            rightListBox.Click += HandleSingleClick;
            rightListBox.DoubleClick += HandleDoubleClickListBox;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(rightListBox);
            Controls.Add(leftListBox);
            Controls.Add(backButton);
            Controls.Add(deleteButton);
            Controls.Add(copyButton);
            Controls.Add(moveLeftButton);
            Controls.Add(moveRightButton);
            Controls.Add(rightPathTextBox);
            Controls.Add(leftPathTextBox);
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
