using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace BMSG_Editor
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            UpdateWindow();
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 1)
            {
                OpenFile(args[1]);
            }
        }

        public MessageFile CurrentFile { get; private set; } = null;
        private int LastSelectedIndex = -1;

        private void UpdateWindow()
        {
            Text = "BMSG Editor";
            listBox1.Items.Clear();

            if (CurrentFile is null)
            {
                textBox1.Enabled = false;
                listBox1.Enabled = false;
                saveToolStripMenuItem.Enabled = false;
                saveAsToolStripMenuItem.Enabled = false;
                closeToolStripMenuItem.Enabled = false;
                textBox1.Text = "";
                label1.Text = "";
                return;
            }
            else
            {
                textBox1.Enabled = true;
                listBox1.Enabled = true;
                saveToolStripMenuItem.Enabled = true;
                saveAsToolStripMenuItem.Enabled = true;
                closeToolStripMenuItem.Enabled = true;
            }

            Text += " - " + Path.GetFileName(CurrentFile.Path);
            label1.Text = CurrentFile.Title;

            foreach ((string key, string _) in CurrentFile.Contents)
            {
                listBox1.Items.Add(key);
            }
        }
        private void PushChanges()
        {
            CurrentFile.Contents[LastSelectedIndex] = new(CurrentFile.Contents[LastSelectedIndex].Item1, textBox1.Text);
        }

        private void OpenFile(string path)
        {
            CloseFile();

            MessageFile newFile;
            try
            {
                newFile = MessageFileLoader.Open(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to open file.\n{ex}", "Error opening file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CurrentFile = newFile;
            UpdateWindow();

            LastSelectedIndex = -1;
            if (CurrentFile.Contents.Count > 0)
                listBox1.SelectedIndex = 0;
        }
        private void SaveFile(string filename = null)
        {
            if (CurrentFile is null)
                return;

            PushChanges();

            if (filename is null)
                filename = CurrentFile.Path;

            CurrentFile.Save(filename);

            UpdateWindow();
        }
        private bool CloseFile()
        {
            if (CurrentFile is null)
                return true;

            if (CurrentFile.Modified)
            {
                DialogResult result = MessageBox.Show($"{Path.GetFileName(CurrentFile.Path)} has unsaved changes.\nWould you like to save?", "Unsaved Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);

                if (result == DialogResult.Cancel)
                    return false;

                if (result == DialogResult.Yes)
                {
                    SaveFile();
                }
            }

            CurrentFile = null;
            UpdateWindow();
            return true;
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new();
            fileDialog.Filter = "BMSG files (*.bmsg)|*.bmsg|All files (*.*)|*.*";

            if (fileDialog.ShowDialog() != DialogResult.OK)
                return;

            OpenFile(fileDialog.FileName);
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentFile is not null)
                SaveFile();
        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentFile is null)
                return;

            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "BMSG files (*.bmsg)|*.bmsg|All files (*.*)|*.*";

            if (fileDialog.ShowDialog() == DialogResult.OK)
                SaveFile(fileDialog.FileName);
        }
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseFile();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CloseFile())
                Close();
        }

        private void MainWindow_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }
        private void MainWindow_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] filenames = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (filenames.Length > 0)
                    OpenFile(filenames[0]);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CurrentFile is null || CurrentFile.Contents is null || CurrentFile.Contents.Count <= listBox1.SelectedIndex)
                return;

            if (LastSelectedIndex >= 0)
                PushChanges();

            textBox1.Text = CurrentFile.Contents[listBox1.SelectedIndex].Item2;

            LastSelectedIndex = listBox1.SelectedIndex;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (CurrentFile is null || CurrentFile.Contents is null || CurrentFile.Contents.Count <= 0)
                return;

            if (textBox1.Text != CurrentFile.Contents[listBox1.SelectedIndex].Item2)
                CurrentFile.Modified = true;
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            return;

            /*if (CurrentFile is null || CurrentFile.Contents is null || CurrentFile.Contents.Count <= 0)
                return;

            RenameItemWindow itemChanger = new RenameItemWindow();
            itemChanger.SetTextBoxText(CurrentFile.Contents[listBox1.SelectedIndex].Item1);

            AddOwnedForm(itemChanger);
            itemChanger.ShowDialog();*/
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Created by playinful in 2024\nhttps://github.com/playinful", "About BMSG Editor");
        }
    }
}