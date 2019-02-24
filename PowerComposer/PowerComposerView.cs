/*
MIT License

Copyright (c) 2019 takubokudori

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PowerComposer
{
    public partial class PowerComposerView : UserControl
    {
        private Dictionary<string, string> vars;

        public PowerComposerView()
        {
            InitializeComponent();
            OptionBox.SetItemChecked(0, true);
            OptionBox.SetItemChecked(1, true);
            vars = new Dictionary<string, string>();
        }

        private void PowerComposerView_Load(object sender, EventArgs e)
        {
        }

        private void PowerComposerView_Leave(object sender, EventArgs e)
        {
        }

        private void BodyTxt_TextChanged(object sender, EventArgs e)
        {
        }

        private void ExecBtn_Click(object sender, EventArgs e)
        {
            // Execute
            int t;
            if (TimesTxt.Text.Length == 0) t = 1;
            else if (!int.TryParse(TimesTxt.Text, out t))
            {
                MessageBox.Show(@"Input number in Times");
                return;
            }

            for (int i = 0; i < t; i++)
            {
                PowerComposer.Execute();
            }
        }

        private void VariableBox_SelectedValueChanged(object sender, EventArgs e)
        {
            ValuesLbl.Text = VariableBox.Text;
            ValuesTxt.Text = vars.ContainsKey(VariableBox.Text) ? vars[VariableBox.Text] : "";
        }

        private void AddNewVarBtn_Click(object sender, EventArgs e)
        {
            if (NewVarTxt.Text.Length == 0)
            {
                VariableBox.SelectedIndex = VariableBox.Items.Count - 1;
                return;
            }

            var reg = new Regex("^[a-zA-Z0-9]+$");
            if (!reg.IsMatch(NewVarTxt.Text))
            {
                MessageBox.Show(@"Variable name can include alphanumeric characters only.");
                return;
            }

            if (VariableBox.FindStringExact(NewVarTxt.Text) != -1)
            {
                MessageBox.Show($@"{NewVarTxt.Text} is already exists.");
                return;
            }

            VariableBox.Items.Add(NewVarTxt.Text);
            NewVarTxt.Text = "";
        }

        private void ValuesTxt_TextChanged(object sender, EventArgs e)
        {
            // Auto save
            SaveValues();
        }

        private void SaveValues()
        {
            vars[VariableBox.Text] = ValuesTxt.Text;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            SaveValues();
        }


        public Dictionary<string, string[]> GetDict()
        {
            Dictionary<string, string[]> ret = new Dictionary<string, string[]>();
            foreach (KeyValuePair<string, string> kvp in vars)
            {
                ret[kvp.Key] = kvp.Value.Split(new[] {"\r\n", "\n"}, StringSplitOptions.None);
            }

            return ret;
        }

        public bool IsErrorByUndefinedVar()
        {
            return OptionBox.GetItemChecked(0);
        }

        public bool IsFixContentLength()
        {
            return OptionBox.GetItemChecked(1);
        }

        public bool IsFollowRedirect()
        {
            return OptionBox.GetItemChecked(2);
        }

        private void VariableBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            tabControl1.SelectTab(ValsTab);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.LinkVisited = true;
            // Open in browser
            Process.Start(linkLabel1.Text);
        }

        private void NewVarTxt_Enter(object sender, EventArgs e)
        {
            if (ParentForm != null) ParentForm.AcceptButton = AddNewVarBtn;
        }

        private void NewVarTxt_Leave(object sender, EventArgs e)
        {
            if (ParentForm != null) ParentForm.AcceptButton = null;
        }

        private void TimesTxt_Enter(object sender, EventArgs e)
        {
            if (ParentForm != null) ParentForm.AcceptButton = ExecBtn;
        }

        private void TimesTxt_Leave(object sender, EventArgs e)
        {
            if (ParentForm != null) ParentForm.AcceptButton = null;
        }
    }
}