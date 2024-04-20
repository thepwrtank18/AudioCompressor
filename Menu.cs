using System.Diagnostics;
// ReSharper disable LocalizableElement
// ReSharper disable IdentifierTypo
// ReSharper disable StringLiteralTypo
// ReSharper disable CommentTypo
// ReSharper disable InconsistentNaming

namespace AudioCompressor;

public partial class Menu : Form
{
    private readonly List<string> Files = [];

    private readonly List<string> AcceptedFileTypes = ["*.mp3", "*.wav", "*.aiff", "*.aif", "*.flac", "*.aac", "*.ogg", "*.wma", "*.m4a", "*.alac", "*.opus"];

    // This software uses libraries from the FFmpeg project under the LGPLv2.1
    // MLA citation - FFmpeg, 5 Apr. 2024, ffmpeg.org.
    private readonly Process FFmpeg = new()
    {
        StartInfo = new ProcessStartInfo
        {
            FileName = "ffmpeg.exe",
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            CreateNoWindow = true
        }
    };

    public Menu()
    {
        InitializeComponent();
    }

    private void DisplayFileSize()
    {
        FileSizeLabel.Text = $"Maximum file size: {MaxFileSize.Value} MB";
        if (MaxFileSize.Value == 0)
        {
            FileSizeLabel.Text += " (Invalid)";
        }
        CheckStart();
    }

    // The visible list (built-in the ListBox control) is different from the internal file list (the Files variable).
    // The internal file list contains the file path. For the visible list, only the file name is displayed.
    private void UpdateVisibleList()
    {
        FileQueue.Items.Clear();
        foreach (string file in Files)
        {
            FileQueue.Items.Add(Path.GetFileName(file));
        }
    }

    private void CheckStart()
    {
        if (Files.Count > 0 && MaxFileSize.Value > 0)
        {
            StartQueue.Enabled = true;
        }
        else
        {
            StartQueue.Enabled = false;
        }
    }

    private void Menu_Load(object sender, EventArgs e)
    {
        DisplayFileSize();
    }

    private void MaxFileSize_Scroll(object sender, EventArgs e)
    {
        DisplayFileSize();
    }

    private void ManualSelectFiles_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        ManualSelectFileDialog();
    }

    private void FileQueue_DragEnter(object sender, DragEventArgs e)
    {
        // boilerplate code to check if the dragged data is a file
        if (e.Data != null && e.Data.GetDataPresent(DataFormats.FileDrop))
        {
            e.Effect = DragDropEffects.Copy;
        }
        else
        {
            e.Effect = DragDropEffects.None;
        }
    }

    private void ManualSelectFileDialog()
    {
        OpenFileDialog ofd = new()
        {
            Multiselect = true
        };
        string filter = string.Join(";", AcceptedFileTypes);
        ofd.Filter = $"Audio files|{filter}";

        if (ofd.ShowDialog() == DialogResult.OK)
        {
            foreach (string file in ofd.FileNames)
            {
                if (Files.Contains(file)) continue;
                Files.Add(file);
            }
        }

        UpdateVisibleList();
        CheckStart();
    }

    private void FileQueue_DragDrop(object sender, DragEventArgs e)
    {
        if (e.Data?.GetData(DataFormats.FileDrop) is string[] files)
        {
            foreach (string file in files)
            {
                if (Files.Contains(file)) continue;
                string ext = Path.GetExtension(file).ToLower();
                if (AcceptedFileTypes.Contains("*" + ext))
                {
                    Files.Add(file);
                }
            }
        }

        UpdateVisibleList();
        CheckStart();
    }

    private async void StartQueue_Click(object sender, EventArgs e)
    {
        OutputTextBox.Text += "Starting queue...\n\n";

        // Disable all the UI elements while the queue is running
        StartQueue.Enabled = false;
        FileSizeLabel.Enabled = false;
        MaxFileSize.Enabled = false;
        RemoveMetadata.Enabled = false;
        label1.Enabled = false;
        ManualSelectFiles.Enabled = false;
        QualityLevelLabel.Enabled = true;
        FileQualityLevel.Enabled = true;
        CompletionProgressBar.Enabled = true;
        OverallProgressLabel.Enabled = true;

        if (Files.Count == 1)
        {
            OutputTextBox.Text += "Single file, can't determine overall progress\n";
            CompletionProgressBar.Style = ProgressBarStyle.Marquee;
        }
        else
        {
            OutputTextBox.Text += "Multiple files, can determine overall progress\n";
            CompletionProgressBar.Style = ProgressBarStyle.Continuous;
            CompletionProgressBar.Maximum = Files.Count;
        }

        foreach (string file in Files)
        {
            OutputTextBox.Text += $"Starting compression on {Path.GetFileName(file)}\n";
            try
            {
                await CompressFile(file, MaxFileSize.Value);
            }
            catch (Exception ex)
            {
                string error = $"An error occurred while compressing {file}:\n\n{ex.Message}";
                OutputTextBox.Text += error + "\n";
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        OutputTextBox.Text += "All files have been compressed successfully\n\n";
        MessageBox.Show("All files have been compressed successfully.\nYou can find the new files the same place the input files were.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

        // Re-enable all the UI elements
        StartQueue.Enabled = true;
        FileSizeLabel.Enabled = true;
        MaxFileSize.Enabled = true;
        RemoveMetadata.Enabled = true;
        label1.Enabled = true;
        ManualSelectFiles.Enabled = true;
        QualityLevelLabel.Enabled = false;
        FileQualityLevel.Enabled = false;
        CompletionProgressBar.Enabled = false;
        OverallProgressLabel.Enabled = false;
        CompletionProgressBar.Style = ProgressBarStyle.Continuous;
        CompletionProgressBar.Value = 0;
        FileQualityLevel.Value = 0;
        Files.Clear();
        UpdateVisibleList();
        CheckStart();
    }

    private async Task CompressFile(string file, int fileSize, bool updateInterface = true, int kbps = 320)
    {
        var kbps1 = kbps;
        Invoke(() =>
        {
            FileQualityLevel.Value = kbps1;
            OutputTextBox.Text += $"Compressing {Path.GetFileName(file)} to {kbps1} kbps...\n";
        });

        string outputFile = Path.ChangeExtension(file, null) + $"-bitrate_{kbps}.mp3";
        string additionalArgs = RemoveMetadata.Checked ? "-map 0:a -map_metadata -1" : "";
        FFmpeg.StartInfo.Arguments = $"-i \"{file}\" -hide_banner {additionalArgs} -c:a libmp3lame -b:a {kbps}k \"{outputFile}\" -y";
        FFmpeg.Start();
        await FFmpeg.WaitForExitAsync();

        if (FFmpeg.ExitCode != 0)
        {
            throw new Exception(await FFmpeg.StandardError.ReadToEndAsync());
        }

        if (!File.Exists(outputFile))
        {
            throw new Exception(await FFmpeg.StandardError.ReadToEndAsync());
        }

        if (new FileInfo(outputFile).Length > fileSize * 1000 * 1000)
        {
            Invoke(() =>
            {
                OutputTextBox.Text += "File size too large, retrying with lower quality...\n";
            });
            File.Delete(outputFile);
            kbps -= 32;
            await CompressFile(file, fileSize, false, kbps);
        }

        if (updateInterface)
        {
            Invoke(() =>
            {
                CompletionProgressBar.Value++;
                OutputTextBox.Text += $"Finished compressing {Path.GetFileName(file)}\n";
            });
        }
    }

    // Makes the text box scroll to the bottom when new text is added
    private void OutputTextBox_TextChanged(object sender, EventArgs e)
    {
        OutputTextBox.SelectionStart = OutputTextBox.Text.Length;
        OutputTextBox.ScrollToCaret();
    }
}