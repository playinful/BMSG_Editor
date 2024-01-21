namespace BMSG_Editor
{
    partial class FindReplaceForm
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
            button_FindNext = new Button();
            button_Replace = new Button();
            button_ReplaceAll = new Button();
            button_Count = new Button();
            checkBox_MatchCase = new CheckBox();
            checkBox_Regex = new CheckBox();
            label1 = new Label();
            label2 = new Label();
            textBox_Find = new TextBox();
            textBox_Replace = new TextBox();
            button_Cancel = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel5 = new TableLayoutPanel();
            tableLayoutPanel4 = new TableLayoutPanel();
            tableLayoutPanel3 = new TableLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // button_FindNext
            // 
            button_FindNext.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button_FindNext.Location = new Point(3, 3);
            button_FindNext.Name = "button_FindNext";
            button_FindNext.Size = new Size(94, 25);
            button_FindNext.TabIndex = 0;
            button_FindNext.Text = "Find Next";
            button_FindNext.UseVisualStyleBackColor = true;
            button_FindNext.Click += button_FindNext_Click;
            // 
            // button_Replace
            // 
            button_Replace.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button_Replace.Location = new Point(3, 34);
            button_Replace.Name = "button_Replace";
            button_Replace.Size = new Size(94, 25);
            button_Replace.TabIndex = 1;
            button_Replace.Text = "Replace";
            button_Replace.UseVisualStyleBackColor = true;
            button_Replace.Click += button_Replace_Click;
            // 
            // button_ReplaceAll
            // 
            button_ReplaceAll.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button_ReplaceAll.Location = new Point(3, 65);
            button_ReplaceAll.Name = "button_ReplaceAll";
            button_ReplaceAll.Size = new Size(94, 25);
            button_ReplaceAll.TabIndex = 2;
            button_ReplaceAll.Text = "Replace All";
            button_ReplaceAll.UseVisualStyleBackColor = true;
            button_ReplaceAll.Click += button_ReplaceAll_Click;
            // 
            // button_Count
            // 
            button_Count.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button_Count.Location = new Point(3, 96);
            button_Count.Name = "button_Count";
            button_Count.Size = new Size(94, 25);
            button_Count.TabIndex = 3;
            button_Count.Text = "Count";
            button_Count.UseVisualStyleBackColor = true;
            button_Count.Click += button_Count_Click;
            // 
            // checkBox_MatchCase
            // 
            checkBox_MatchCase.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            checkBox_MatchCase.AutoSize = true;
            checkBox_MatchCase.Location = new Point(3, 15);
            checkBox_MatchCase.Name = "checkBox_MatchCase";
            checkBox_MatchCase.Size = new Size(86, 19);
            checkBox_MatchCase.TabIndex = 4;
            checkBox_MatchCase.Text = "Match case";
            checkBox_MatchCase.UseVisualStyleBackColor = true;
            // 
            // checkBox_Regex
            // 
            checkBox_Regex.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            checkBox_Regex.AutoSize = true;
            checkBox_Regex.Location = new Point(3, 40);
            checkBox_Regex.Name = "checkBox_Regex";
            checkBox_Regex.Size = new Size(130, 19);
            checkBox_Regex.TabIndex = 5;
            checkBox_Regex.Text = "Regular expressions";
            checkBox_Regex.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(18, 7);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 6;
            label1.Text = "Find what:";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(3, 38);
            label2.Name = "label2";
            label2.Size = new Size(77, 15);
            label2.TabIndex = 7;
            label2.Text = "Replace with:";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // textBox_Find
            // 
            textBox_Find.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox_Find.Location = new Point(86, 34);
            textBox_Find.Name = "textBox_Find";
            textBox_Find.Size = new Size(210, 23);
            textBox_Find.TabIndex = 8;
            // 
            // textBox_Replace
            // 
            textBox_Replace.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox_Replace.Location = new Point(86, 3);
            textBox_Replace.Name = "textBox_Replace";
            textBox_Replace.Size = new Size(210, 23);
            textBox_Replace.TabIndex = 9;
            // 
            // button_Cancel
            // 
            button_Cancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button_Cancel.Location = new Point(-55, 20);
            button_Cancel.Name = "button_Cancel";
            button_Cancel.Size = new Size(0, 0);
            button_Cancel.TabIndex = 10;
            button_Cancel.TabStop = false;
            button_Cancel.UseVisualStyleBackColor = true;
            button_Cancel.Click += button_Cancel_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(textBox_Replace, 1, 0);
            tableLayoutPanel1.Controls.Add(textBox_Find, 1, 1);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(299, 61);
            tableLayoutPanel1.TabIndex = 11;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tableLayoutPanel2.Controls.Add(tableLayoutPanel5, 0, 0);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 1, 0);
            tableLayoutPanel2.Location = new Point(9, 9);
            tableLayoutPanel2.Margin = new Padding(0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(399, 141);
            tableLayoutPanel2.TabIndex = 12;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel5.ColumnCount = 1;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.Controls.Add(tableLayoutPanel4, 0, 1);
            tableLayoutPanel5.Controls.Add(tableLayoutPanel1, 0, 0);
            tableLayoutPanel5.Location = new Point(0, 0);
            tableLayoutPanel5.Margin = new Padding(0);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 2;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.Size = new Size(299, 123);
            tableLayoutPanel5.TabIndex = 14;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Controls.Add(checkBox_Regex, 0, 1);
            tableLayoutPanel4.Controls.Add(checkBox_MatchCase, 0, 0);
            tableLayoutPanel4.Location = new Point(0, 61);
            tableLayoutPanel4.Margin = new Padding(0);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 2;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle());
            tableLayoutPanel4.Size = new Size(299, 62);
            tableLayoutPanel4.TabIndex = 12;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Controls.Add(button_FindNext, 0, 0);
            tableLayoutPanel3.Controls.Add(button_ReplaceAll, 0, 2);
            tableLayoutPanel3.Controls.Add(button_Replace, 0, 1);
            tableLayoutPanel3.Controls.Add(button_Count, 0, 3);
            tableLayoutPanel3.Location = new Point(299, 0);
            tableLayoutPanel3.Margin = new Padding(0);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 4;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 31F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 31F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 31F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 31F));
            tableLayoutPanel3.Size = new Size(100, 123);
            tableLayoutPanel3.TabIndex = 12;
            // 
            // FindReplaceForm
            // 
            AcceptButton = button_FindNext;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = button_Cancel;
            ClientSize = new Size(416, 141);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(button_Cancel);
            MaximizeBox = false;
            MaximumSize = new Size(32767, 180);
            MinimizeBox = false;
            MinimumSize = new Size(255, 180);
            Name = "FindReplaceForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            Text = "Find & Replace";
            Shown += FindReplaceForm_Shown;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button button_FindNext;
        private Button button_Replace;
        private Button button_ReplaceAll;
        private Button button_Count;
        private CheckBox checkBox_MatchCase;
        private CheckBox checkBox_Regex;
        private Label label1;
        private Label label2;
        private TextBox textBox_Find;
        private TextBox textBox_Replace;
        private Button button_Cancel;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel5;
        private TableLayoutPanel tableLayoutPanel4;
        private TableLayoutPanel tableLayoutPanel3;
    }
}