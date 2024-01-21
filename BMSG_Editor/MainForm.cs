using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace BMSG_Editor
{
    public partial class MainForm : Form
    {
        public MainForm()
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
        public int SelectedIndex => listBox1.SelectedIndex;
        private int LastSelectedIndex = -1;
        public bool LastActionWasReplace { get; set; } = false;

        private void UpdateWindow()
        {
            Text = "BMSG Editor";
            listBox1.Items.Clear();

            if (CurrentFile is null)
            {
                textBox_String.Enabled = false;
                textBox_Title.Enabled = false;
                listBox1.Enabled = false;
                saveToolStripMenuItem.Enabled = false;
                saveAsToolStripMenuItem.Enabled = false;
                closeToolStripMenuItem.Enabled = false;
                //findToolStripMenuItem.Enabled = false;
                textBox_String.Text = "";
                textBox_Title.Text = "";
                return;
            }
            else
            {
                textBox_String.Enabled = true;
                textBox_Title.Enabled = true;
                listBox1.Enabled = true;
                saveToolStripMenuItem.Enabled = true;
                saveAsToolStripMenuItem.Enabled = true;
                closeToolStripMenuItem.Enabled = true;
                findToolStripMenuItem.Enabled = true;
            }

            Text += " - " + Path.GetFileName(CurrentFile.Path);
            textBox_Title.Text = CurrentFile.Title;

            foreach ((string key, string _) in CurrentFile.Contents)
            {
                listBox1.Items.Add(key);
            }
        }
        private void PushChanges()
        {
            CurrentFile.Contents[LastSelectedIndex] = new(CurrentFile.Contents[LastSelectedIndex].Item1, textBox_String.Text);
        }
        public void ChangeKey(string newKey)
        {
            CurrentFile.Contents[SelectedIndex] = new(newKey, CurrentFile.Contents[SelectedIndex].Item2);
            CurrentFile.Modified = true;
            listBox1.Items[listBox1.SelectedIndex] = newKey;
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

            //UpdateWindow();
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

        public bool FindNext(string find, bool matchCase, bool regex)
        {
            LastActionWasReplace = false;
            if (FindCount(find, matchCase, regex) <= 0) return false;

            int startIndex = textBox_String.SelectionStart + textBox_String.SelectionLength;
            if (startIndex < 0) startIndex = 0;

            bool loop2 = false;
            for (int i = SelectedIndex; true; i++)
            {
                if (i >= CurrentFile.Contents.Count)
                {
                    i = 0;
                    loop2 = true;
                }
                if (loop2 && i >= SelectedIndex)
                    return false;

                string entry = CurrentFile.Contents[i].Item2;
                if (startIndex >= entry.Length)
                {
                    startIndex = 0;
                    continue;
                }

                if (regex)
                {
                    Match match = new Regex(find, matchCase ? RegexOptions.None : RegexOptions.IgnoreCase).Match(entry, startIndex);
                    if (match is not null && match.Success)
                    {
                        listBox1.SelectedIndex = i;
                        textBox_String.Focus();
                        textBox_String.SelectionStart = match.Index;
                        textBox_String.SelectionLength = match.Length;
                        return true;
                    }
                }
                else
                {
                    int index = entry.IndexOf(find, startIndex, matchCase ? StringComparison.InvariantCulture : StringComparison.CurrentCultureIgnoreCase);
                    if (index > -1)
                    {
                        listBox1.SelectedIndex = i;
                        textBox_String.Focus();
                        textBox_String.SelectionStart = index;
                        textBox_String.SelectionLength = find.Length;
                        return true;
                    }
                }

                startIndex = 0;
            }

            return false;
        }
        public bool Replace(string find, string replace, bool matchCase, bool regex)
        {
            if (FindCount(find, matchCase, regex) <= 0) return LastActionWasReplace = false;

            int startIndex = textBox_String.SelectionStart;
            if (LastActionWasReplace)
                startIndex += textBox_String.SelectionLength;
            if (startIndex < 0) 
               startIndex = 0;

            bool loop2 = false;
            for (int i = SelectedIndex; true; i++)
            {
                if (i >= CurrentFile.Contents.Count)
                {
                    i = 0;
                    loop2 = true;
                }
                if (loop2 && i >= SelectedIndex)
                    return LastActionWasReplace = false;

                string entry = CurrentFile.Contents[i].Item2;
                if (regex)
                {
                    Regex pattern = new(find, matchCase ? RegexOptions.None : RegexOptions.IgnoreCase);
                    Match match = pattern.Match(entry, startIndex);
                    if (match is not null && match.Success)
                    {
                        string replacement = pattern.Replace(entry, replace, 1, startIndex);
                        CurrentFile.Contents[i] = new
                        (
                            CurrentFile.Contents[SelectedIndex].Item1,
                            replacement
                        );

                        if (listBox1.SelectedIndex == i)
                            textBox_String.Text = replacement;
                        else
                            listBox1.SelectedIndex = i;
                        textBox_String.Focus();
                        textBox_String.SelectionStart = match.Index;
                        textBox_String.SelectionLength = replacement.Length - (entry.Length - (match.Index + match.Length)) - match.Index;
                        CurrentFile.Modified = true;
                        LastActionWasReplace = true;
                        return true;
                    }
                }
                else
                {
                    int index = entry.IndexOf(find, startIndex, matchCase ? StringComparison.InvariantCulture : StringComparison.CurrentCultureIgnoreCase);
                    if (index > -1)
                    {
                        string pre = entry.Substring(0, index);
                        string post = entry.Substring(index + replace.Length);
                        string replacement = pre + replace + post;
                        CurrentFile.Contents[i] = new
                        (
                            CurrentFile.Contents[SelectedIndex].Item1,
                            replacement
                        );

                        if (listBox1.SelectedIndex == i)
                            textBox_String.Text = replacement;
                        else
                            listBox1.SelectedIndex = i;
                        textBox_String.Focus();
                        textBox_String.SelectionStart = index;
                        textBox_String.SelectionLength = replace.Length;
                        CurrentFile.Modified = true;
                        LastActionWasReplace = true;
                        return true;
                    }
                }

                startIndex = 0;
            }

            return LastActionWasReplace = false;
        }
        public int ReplaceAll(string find, string replace, bool matchCase, bool regex)
        {
            LastActionWasReplace = false;
            int count = FindCount(find, matchCase, regex);
            if (count > 0)
                CurrentFile.Modified = true;
            else return count;

            for (int i = 0; i < CurrentFile.Contents.Count; i++)
            {
                string entry = CurrentFile.Contents[i].Item2;
                if (regex)
                {
                    CurrentFile.Contents[i] = new
                    (
                        CurrentFile.Contents[i].Item1,
                        new Regex(find, matchCase ? RegexOptions.None : RegexOptions.IgnoreCase).Replace(entry, replace)
                    );
                }
                else
                {
                    CurrentFile.Contents[i] = new
                    (
                        CurrentFile.Contents[i].Item1,
                        entry.Replace(find, replace, matchCase ? StringComparison.InvariantCulture : StringComparison.InvariantCultureIgnoreCase)
                    );
                }
            }
            textBox_String.Text = CurrentFile.Contents[SelectedIndex].Item2;

            return count;
        }
        public int FindCount(string find, bool matchCase, bool regex)
        {
            if (find is null || find == "")
                return 0;

            int count = 0;

            foreach ((string _, string entry) in CurrentFile.Contents)
            {
                if (regex)
                {
                    Regex pattern = new(find, matchCase ? RegexOptions.None : RegexOptions.IgnoreCase);
                    count += pattern.Matches(entry).Count;
                }
                else
                {
                    int startIndex = 0;
                    while (true)
                    {
                        int index = entry.IndexOf(find, startIndex, matchCase ? StringComparison.InvariantCulture : StringComparison.InvariantCultureIgnoreCase);
                        if (index > -1)
                        {
                            count++;
                            startIndex = index + 1;
                        }
                        else break;
                    }
                }
            }

            return count;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !CloseFile();
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

            if (listBox1.SelectedIndex < 0)
                listBox1.SelectedIndex = LastSelectedIndex;

            textBox_String.Text = CurrentFile.Contents[listBox1.SelectedIndex].Item2;

            LastSelectedIndex = listBox1.SelectedIndex;
        }
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (CurrentFile is null || CurrentFile.Contents is null || CurrentFile.Contents.Count <= 0)
                return;

            RenameForm.Create(this);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            LastActionWasReplace = false;
            if (CurrentFile is null || CurrentFile.Contents is null || CurrentFile.Contents.Count <= 0)
                return;

            if (textBox_String.Text != CurrentFile.Contents[listBox1.SelectedIndex].Item2)
                CurrentFile.Modified = true;
        }
        private void textBox_String_Leave(object sender, EventArgs e)
        {
            LastActionWasReplace = false;
        }
        private void textBox_String_Validated(object sender, EventArgs e)
        {
            LastActionWasReplace = false;
        }

        private void textBox_Title_TextChanged(object sender, EventArgs e)
        {
            if (CurrentFile is null || CurrentFile.Contents is null || CurrentFile.Contents.Count <= 0)
                return;

            if (CurrentFile.Title == textBox_Title.Text)
                return;

            CurrentFile.Title = textBox_Title.Text;
            CurrentFile.Modified = true;
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindReplaceForm.Create(this);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Created by playinful in 2024\nhttps://github.com/playinful", "About BMSG Editor");
        }
    }
}