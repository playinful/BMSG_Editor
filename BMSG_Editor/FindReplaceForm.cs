using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMSG_Editor
{
    public partial class FindReplaceForm : Form
    {
        public FindReplaceForm()
        {
            InitializeComponent();
        }

        public static void Create(MainForm parent)
        {
            FindReplaceForm form = new();
            parent.AddOwnedForm(form);
            form.xParent = parent;
            form.Show();
        }

        public MainForm xParent { get; set; }

        private void FindReplaceForm_Shown(object sender, EventArgs e)
        {
            textBox_Find.Focus();
        }

        private void button_FindNext_Click(object sender, EventArgs e)
        {
            if (!xParent.FindNext(textBox_Find.Text, checkBox_MatchCase.Checked, checkBox_Regex.Checked))
            {
                MessageBox.Show($"Could not find any occurences of '{textBox_Find.Text}'.", "Find", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void button_Replace_Click(object sender, EventArgs e)
        {
            if (!xParent.Replace(textBox_Find.Text, textBox_Replace.Text, checkBox_MatchCase.Checked, checkBox_Regex.Checked))
            {
                MessageBox.Show($"Could not find any occurences of '{textBox_Find.Text}'.", "Find", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void button_ReplaceAll_Click(object sender, EventArgs e)
        {
            int count = xParent.FindCount(textBox_Find.Text, checkBox_MatchCase.Checked, checkBox_Regex.Checked);
            if (count > 0)
            {
                string instance = count == 1 ? "instance" : "instances";
                DialogResult result = MessageBox.Show($"Are you sure you would like to replace {count} {instance} of '{textBox_Find.Text}'?", "Confirm Replace", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                    return;
            }
            else
            {
                MessageBox.Show($"Found 0 matches for '{textBox_Find.Text}'.");
                return;
            }
            xParent.ReplaceAll(textBox_Find.Text, textBox_Replace.Text, checkBox_MatchCase.Checked, checkBox_Regex.Checked);
        }
        private void button_Count_Click(object sender, EventArgs e)
        {
            xParent.LastActionWasReplace = false;
            int count = xParent.FindCount(textBox_Find.Text, checkBox_MatchCase.Checked, checkBox_Regex.Checked);
            string instance = count == 1 ? "match" : "matches";
            MessageBox.Show($"Found {count} {instance} for '{textBox_Find.Text}'.", "Count");
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
