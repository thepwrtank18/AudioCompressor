namespace AudioCompressor
{
    partial class Menu
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
            FileQueue = new ListBox();
            label1 = new Label();
            ManualSelectFiles = new LinkLabel();
            StartQueue = new Button();
            FileSizeLabel = new Label();
            MaxFileSize = new TrackBar();
            RemoveMetadata = new CheckBox();
            CompletionProgressBar = new ProgressBar();
            OverallProgressLabel = new Label();
            QualityLevelLabel = new Label();
            FileQualityLevel = new ProgressBar();
            OutputTextBox = new RichTextBox();
            ((System.ComponentModel.ISupportInitialize)MaxFileSize).BeginInit();
            SuspendLayout();
            // 
            // FileQueue
            // 
            FileQueue.AllowDrop = true;
            FileQueue.FormattingEnabled = true;
            FileQueue.ItemHeight = 15;
            FileQueue.Location = new Point(12, 12);
            FileQueue.Name = "FileQueue";
            FileQueue.SelectionMode = SelectionMode.None;
            FileQueue.Size = new Size(300, 379);
            FileQueue.TabIndex = 0;
            FileQueue.DragDrop += FileQueue_DragDrop;
            FileQueue.DragEnter += FileQueue_DragEnter;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Location = new Point(12, 417);
            label1.Margin = new Padding(3, 0, 0, 0);
            label1.Name = "label1";
            label1.Size = new Size(186, 15);
            label1.TabIndex = 1;
            label1.Text = "Drag and drop files into the list, or";
            // 
            // ManualSelectFiles
            // 
            ManualSelectFiles.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ManualSelectFiles.AutoSize = true;
            ManualSelectFiles.Location = new Point(195, 417);
            ManualSelectFiles.Margin = new Padding(0, 0, 3, 0);
            ManualSelectFiles.Name = "ManualSelectFiles";
            ManualSelectFiles.Size = new Size(61, 15);
            ManualSelectFiles.TabIndex = 2;
            ManualSelectFiles.TabStop = true;
            ManualSelectFiles.Text = "select files";
            ManualSelectFiles.LinkClicked += ManualSelectFiles_LinkClicked;
            // 
            // StartQueue
            // 
            StartQueue.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            StartQueue.Location = new Point(537, 409);
            StartQueue.Name = "StartQueue";
            StartQueue.Size = new Size(75, 23);
            StartQueue.TabIndex = 3;
            StartQueue.Text = "Start";
            StartQueue.UseVisualStyleBackColor = true;
            StartQueue.Click += StartQueue_Click;
            // 
            // FileSizeLabel
            // 
            FileSizeLabel.AutoSize = true;
            FileSizeLabel.Location = new Point(318, 12);
            FileSizeLabel.Name = "FileSizeLabel";
            FileSizeLabel.Size = new Size(143, 15);
            FileSizeLabel.TabIndex = 4;
            FileSizeLabel.Text = "Maximum file size: XX MB";
            // 
            // MaxFileSize
            // 
            MaxFileSize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            MaxFileSize.Location = new Point(319, 30);
            MaxFileSize.Maximum = 50;
            MaxFileSize.Name = "MaxFileSize";
            MaxFileSize.Size = new Size(293, 45);
            MaxFileSize.TabIndex = 5;
            MaxFileSize.TickFrequency = 5;
            MaxFileSize.Value = 5;
            MaxFileSize.Scroll += MaxFileSize_Scroll;
            // 
            // RemoveMetadata
            // 
            RemoveMetadata.AutoSize = true;
            RemoveMetadata.Checked = true;
            RemoveMetadata.CheckState = CheckState.Checked;
            RemoveMetadata.Location = new Point(318, 81);
            RemoveMetadata.Name = "RemoveMetadata";
            RemoveMetadata.Size = new Size(249, 19);
            RemoveMetadata.TabIndex = 6;
            RemoveMetadata.Text = "Remove metadata from files (ex: cover art)";
            RemoveMetadata.UseVisualStyleBackColor = true;
            // 
            // CompletionProgressBar
            // 
            CompletionProgressBar.Enabled = false;
            CompletionProgressBar.Location = new Point(317, 368);
            CompletionProgressBar.Name = "CompletionProgressBar";
            CompletionProgressBar.Size = new Size(294, 23);
            CompletionProgressBar.TabIndex = 8;
            // 
            // OverallProgressLabel
            // 
            OverallProgressLabel.AutoSize = true;
            OverallProgressLabel.Enabled = false;
            OverallProgressLabel.Location = new Point(318, 350);
            OverallProgressLabel.Name = "OverallProgressLabel";
            OverallProgressLabel.Size = new Size(95, 15);
            OverallProgressLabel.TabIndex = 9;
            OverallProgressLabel.Text = "Overall progress:";
            // 
            // QualityLevelLabel
            // 
            QualityLevelLabel.AutoSize = true;
            QualityLevelLabel.Enabled = false;
            QualityLevelLabel.Location = new Point(317, 297);
            QualityLevelLabel.Name = "QualityLevelLabel";
            QualityLevelLabel.Size = new Size(209, 15);
            QualityLevelLabel.TabIndex = 12;
            QualityLevelLabel.Text = "File quality level (to the right is better):";
            // 
            // FileQualityLevel
            // 
            FileQualityLevel.Location = new Point(317, 315);
            FileQualityLevel.Maximum = 320;
            FileQualityLevel.Name = "FileQualityLevel";
            FileQualityLevel.Size = new Size(293, 23);
            FileQualityLevel.TabIndex = 13;
            // 
            // OutputTextBox
            // 
            OutputTextBox.BackColor = SystemColors.WindowText;
            OutputTextBox.BorderStyle = BorderStyle.None;
            OutputTextBox.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            OutputTextBox.ForeColor = SystemColors.Window;
            OutputTextBox.Location = new Point(319, 106);
            OutputTextBox.Name = "OutputTextBox";
            OutputTextBox.ReadOnly = true;
            OutputTextBox.Size = new Size(291, 188);
            OutputTextBox.TabIndex = 14;
            OutputTextBox.Text = "";
            OutputTextBox.TextChanged += OutputTextBox_TextChanged;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(624, 441);
            Controls.Add(OutputTextBox);
            Controls.Add(FileQualityLevel);
            Controls.Add(QualityLevelLabel);
            Controls.Add(OverallProgressLabel);
            Controls.Add(CompletionProgressBar);
            Controls.Add(RemoveMetadata);
            Controls.Add(MaxFileSize);
            Controls.Add(FileSizeLabel);
            Controls.Add(StartQueue);
            Controls.Add(ManualSelectFiles);
            Controls.Add(label1);
            Controls.Add(FileQueue);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Menu";
            Text = "Audio Compressor";
            Load += Menu_Load;
            ((System.ComponentModel.ISupportInitialize)MaxFileSize).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox FileQueue;
        private Label label1;
        private LinkLabel ManualSelectFiles;
        private Button StartQueue;
        private Label FileSizeLabel;
        private TrackBar MaxFileSize;
        private CheckBox RemoveMetadata;
        private ProgressBar CompletionProgressBar;
        private Label OverallProgressLabel;
        private Label QualityLevelLabel;
        private ProgressBar FileQualityLevel;
        private RichTextBox OutputTextBox;
    }
}