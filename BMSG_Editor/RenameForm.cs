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
    public partial class RenameForm : Form
    {
        public RenameForm()
        {
            InitializeComponent();
        }

        public static RenameForm Create(MainForm parent)
        {
            RenameForm form = new RenameForm();
            parent.AddOwnedForm(form);
            form.xParent = parent;
            form.textBox1.Text = parent.CurrentFile.Contents[parent.SelectedIndex].Item1;
            form.ShowDialog();
            //form.textBox1.Focus();
            //form.ActiveControl = form.textBox1;
            return form;
        }

        public MainForm xParent { get; set; }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            xParent?.ChangeKey(textBox1.Text);
            Close();
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RenameForm_Shown(object sender, EventArgs e)
        {
            textBox1.Focus();
        }
    }
}
