namespace UI
{
    partial class MainView
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
            this.grpBrowser = new System.Windows.Forms.GroupBox();
            this.grpNewOrder = new System.Windows.Forms.GroupBox();
            this.grpPreview = new System.Windows.Forms.GroupBox();
            this.lstNewOrder = new System.Windows.Forms.ListBox();
            this.lblNewOrderDirectoryPath = new System.Windows.Forms.Label();
            this.butChangeNewOrderDirectory = new System.Windows.Forms.Button();
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.lstDirectoryFiles = new System.Windows.Forms.ListBox();
            this.lblDirectoryPath = new System.Windows.Forms.Label();
            this.lblDirectoryPathValue = new System.Windows.Forms.Label();
            this.butChangeDirectory = new System.Windows.Forms.Button();
            this.butAddSelectedFiles = new System.Windows.Forms.Button();
            this.butRemoveSelectedFiles = new System.Windows.Forms.Button();
            this.lblNewOrderDirectoryPathValue = new System.Windows.Forms.Label();
            this.butNewOrderUp = new System.Windows.Forms.Button();
            this.butNewOrderDown = new System.Windows.Forms.Button();
            this.butBeginSort = new System.Windows.Forms.Button();
            this.grpBrowser.SuspendLayout();
            this.grpNewOrder.SuspendLayout();
            this.grpPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // grpBrowser
            // 
            this.grpBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grpBrowser.Controls.Add(this.butAddSelectedFiles);
            this.grpBrowser.Controls.Add(this.butChangeDirectory);
            this.grpBrowser.Controls.Add(this.lblDirectoryPathValue);
            this.grpBrowser.Controls.Add(this.lblDirectoryPath);
            this.grpBrowser.Controls.Add(this.lstDirectoryFiles);
            this.grpBrowser.Location = new System.Drawing.Point(6, 8);
            this.grpBrowser.Name = "grpBrowser";
            this.grpBrowser.Size = new System.Drawing.Size(368, 715);
            this.grpBrowser.TabIndex = 0;
            this.grpBrowser.TabStop = false;
            this.grpBrowser.Text = "Browse for files";
            // 
            // grpNewOrder
            // 
            this.grpNewOrder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpNewOrder.Controls.Add(this.butBeginSort);
            this.grpNewOrder.Controls.Add(this.butNewOrderDown);
            this.grpNewOrder.Controls.Add(this.butNewOrderUp);
            this.grpNewOrder.Controls.Add(this.lblNewOrderDirectoryPathValue);
            this.grpNewOrder.Controls.Add(this.butRemoveSelectedFiles);
            this.grpNewOrder.Controls.Add(this.butChangeNewOrderDirectory);
            this.grpNewOrder.Controls.Add(this.lblNewOrderDirectoryPath);
            this.grpNewOrder.Controls.Add(this.lstNewOrder);
            this.grpNewOrder.Location = new System.Drawing.Point(380, 335);
            this.grpNewOrder.Name = "grpNewOrder";
            this.grpNewOrder.Size = new System.Drawing.Size(616, 388);
            this.grpNewOrder.TabIndex = 1;
            this.grpNewOrder.TabStop = false;
            this.grpNewOrder.Text = "New order";
            // 
            // grpPreview
            // 
            this.grpPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpPreview.Controls.Add(this.picPreview);
            this.grpPreview.Location = new System.Drawing.Point(380, 8);
            this.grpPreview.Name = "grpPreview";
            this.grpPreview.Size = new System.Drawing.Size(616, 321);
            this.grpPreview.TabIndex = 2;
            this.grpPreview.TabStop = false;
            this.grpPreview.Text = "Preview (photos only)";
            // 
            // lstNewOrder
            // 
            this.lstNewOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstNewOrder.FormattingEnabled = true;
            this.lstNewOrder.Location = new System.Drawing.Point(17, 58);
            this.lstNewOrder.Name = "lstNewOrder";
            this.lstNewOrder.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstNewOrder.Size = new System.Drawing.Size(524, 277);
            this.lstNewOrder.TabIndex = 0;
            this.lstNewOrder.SelectedIndexChanged += new System.EventHandler(this.lstNewOrder_SelectedIndexChanged);
            // 
            // lblNewOrderDirectoryPath
            // 
            this.lblNewOrderDirectoryPath.AutoSize = true;
            this.lblNewOrderDirectoryPath.Location = new System.Drawing.Point(14, 28);
            this.lblNewOrderDirectoryPath.Name = "lblNewOrderDirectoryPath";
            this.lblNewOrderDirectoryPath.Size = new System.Drawing.Size(76, 13);
            this.lblNewOrderDirectoryPath.TabIndex = 1;
            this.lblNewOrderDirectoryPath.Text = "Directory path:";
            // 
            // butChangeNewOrderDirectory
            // 
            this.butChangeNewOrderDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butChangeNewOrderDirectory.Location = new System.Drawing.Point(565, 25);
            this.butChangeNewOrderDirectory.Name = "butChangeNewOrderDirectory";
            this.butChangeNewOrderDirectory.Size = new System.Drawing.Size(32, 20);
            this.butChangeNewOrderDirectory.TabIndex = 3;
            this.butChangeNewOrderDirectory.Text = "...";
            this.butChangeNewOrderDirectory.UseVisualStyleBackColor = true;
            this.butChangeNewOrderDirectory.Click += new System.EventHandler(this.butChangeNewOrderDirectory_Click);
            // 
            // picPreview
            // 
            this.picPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picPreview.BackColor = System.Drawing.Color.Black;
            this.picPreview.Location = new System.Drawing.Point(17, 27);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(580, 274);
            this.picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPreview.TabIndex = 0;
            this.picPreview.TabStop = false;
            // 
            // lstDirectoryFiles
            // 
            this.lstDirectoryFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstDirectoryFiles.FormattingEnabled = true;
            this.lstDirectoryFiles.Location = new System.Drawing.Point(12, 85);
            this.lstDirectoryFiles.Name = "lstDirectoryFiles";
            this.lstDirectoryFiles.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstDirectoryFiles.Size = new System.Drawing.Size(340, 576);
            this.lstDirectoryFiles.TabIndex = 1;
            this.lstDirectoryFiles.SelectedIndexChanged += new System.EventHandler(this.lstDirectoryFiles_SelectedIndexChanged);
            // 
            // lblDirectoryPath
            // 
            this.lblDirectoryPath.AutoSize = true;
            this.lblDirectoryPath.Location = new System.Drawing.Point(8, 30);
            this.lblDirectoryPath.Name = "lblDirectoryPath";
            this.lblDirectoryPath.Size = new System.Drawing.Size(76, 13);
            this.lblDirectoryPath.TabIndex = 3;
            this.lblDirectoryPath.Text = "Directory path:";
            // 
            // lblDirectoryPathValue
            // 
            this.lblDirectoryPathValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblDirectoryPathValue.Location = new System.Drawing.Point(90, 30);
            this.lblDirectoryPathValue.Name = "lblDirectoryPathValue";
            this.lblDirectoryPathValue.Size = new System.Drawing.Size(224, 52);
            this.lblDirectoryPathValue.TabIndex = 4;
            this.lblDirectoryPathValue.Text = "No directory selected";
            // 
            // butChangeDirectory
            // 
            this.butChangeDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butChangeDirectory.Location = new System.Drawing.Point(320, 30);
            this.butChangeDirectory.Name = "butChangeDirectory";
            this.butChangeDirectory.Size = new System.Drawing.Size(32, 20);
            this.butChangeDirectory.TabIndex = 5;
            this.butChangeDirectory.Text = "...";
            this.butChangeDirectory.UseVisualStyleBackColor = true;
            this.butChangeDirectory.Click += new System.EventHandler(this.butChangeDirectory_Click);
            // 
            // butAddSelectedFiles
            // 
            this.butAddSelectedFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butAddSelectedFiles.Location = new System.Drawing.Point(11, 669);
            this.butAddSelectedFiles.Name = "butAddSelectedFiles";
            this.butAddSelectedFiles.Size = new System.Drawing.Size(341, 34);
            this.butAddSelectedFiles.TabIndex = 6;
            this.butAddSelectedFiles.Text = "Add selected files";
            this.butAddSelectedFiles.UseVisualStyleBackColor = true;
            this.butAddSelectedFiles.Click += new System.EventHandler(this.butAddSelectedFiles_Click);
            // 
            // butRemoveSelectedFiles
            // 
            this.butRemoveSelectedFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.butRemoveSelectedFiles.Location = new System.Drawing.Point(17, 342);
            this.butRemoveSelectedFiles.Name = "butRemoveSelectedFiles";
            this.butRemoveSelectedFiles.Size = new System.Drawing.Size(282, 34);
            this.butRemoveSelectedFiles.TabIndex = 7;
            this.butRemoveSelectedFiles.Text = "Remove selected files";
            this.butRemoveSelectedFiles.UseVisualStyleBackColor = true;
            this.butRemoveSelectedFiles.Click += new System.EventHandler(this.butRemoveSelectedFiles_Click);
            // 
            // lblNewOrderDirectoryPathValue
            // 
            this.lblNewOrderDirectoryPathValue.AutoSize = true;
            this.lblNewOrderDirectoryPathValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblNewOrderDirectoryPathValue.Location = new System.Drawing.Point(96, 28);
            this.lblNewOrderDirectoryPathValue.Name = "lblNewOrderDirectoryPathValue";
            this.lblNewOrderDirectoryPathValue.Size = new System.Drawing.Size(128, 13);
            this.lblNewOrderDirectoryPathValue.TabIndex = 8;
            this.lblNewOrderDirectoryPathValue.Text = "No directory selected";
            // 
            // butNewOrderUp
            // 
            this.butNewOrderUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butNewOrderUp.Location = new System.Drawing.Point(556, 58);
            this.butNewOrderUp.Name = "butNewOrderUp";
            this.butNewOrderUp.Size = new System.Drawing.Size(41, 38);
            this.butNewOrderUp.TabIndex = 9;
            this.butNewOrderUp.Text = "▲";
            this.butNewOrderUp.UseVisualStyleBackColor = true;
            this.butNewOrderUp.Click += new System.EventHandler(this.butNewOrderUp_Click);
            // 
            // butNewOrderDown
            // 
            this.butNewOrderDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butNewOrderDown.Location = new System.Drawing.Point(556, 296);
            this.butNewOrderDown.Name = "butNewOrderDown";
            this.butNewOrderDown.Size = new System.Drawing.Size(41, 38);
            this.butNewOrderDown.TabIndex = 10;
            this.butNewOrderDown.Text = "▼";
            this.butNewOrderDown.UseVisualStyleBackColor = true;
            this.butNewOrderDown.Click += new System.EventHandler(this.butNewOrderDown_Click);
            // 
            // butBeginSort
            // 
            this.butBeginSort.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.butBeginSort.Location = new System.Drawing.Point(326, 342);
            this.butBeginSort.Name = "butBeginSort";
            this.butBeginSort.Size = new System.Drawing.Size(271, 34);
            this.butBeginSort.TabIndex = 11;
            this.butBeginSort.Text = "Begin!";
            this.butBeginSort.UseVisualStyleBackColor = true;
            this.butBeginSort.Click += new System.EventHandler(this.butBeginSort_Click);
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.grpPreview);
            this.Controls.Add(this.grpNewOrder);
            this.Controls.Add(this.grpBrowser);
            this.Name = "MainView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChronoSort";
            this.grpBrowser.ResumeLayout(false);
            this.grpBrowser.PerformLayout();
            this.grpNewOrder.ResumeLayout(false);
            this.grpNewOrder.PerformLayout();
            this.grpPreview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBrowser;
        private System.Windows.Forms.GroupBox grpNewOrder;
        private System.Windows.Forms.GroupBox grpPreview;
        private System.Windows.Forms.Button butChangeNewOrderDirectory;
        private System.Windows.Forms.Label lblNewOrderDirectoryPath;
        private System.Windows.Forms.Button butChangeDirectory;
        private System.Windows.Forms.Label lblDirectoryPathValue;
        private System.Windows.Forms.Label lblDirectoryPath;
        private System.Windows.Forms.Button butAddSelectedFiles;
        private System.Windows.Forms.Button butRemoveSelectedFiles;
        private System.Windows.Forms.Button butNewOrderDown;
        private System.Windows.Forms.Button butNewOrderUp;
        public System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.Button butBeginSort;
        public System.Windows.Forms.ListBox lstNewOrder;
        public System.Windows.Forms.ListBox lstDirectoryFiles;
        public System.Windows.Forms.Label lblNewOrderDirectoryPathValue;
    }
}

