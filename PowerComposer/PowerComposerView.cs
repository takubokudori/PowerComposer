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
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Fiddler;

namespace PowerComposer
{
    public partial class PowerComposerView : UserControl
    {
        private Dictionary<string, string> vars;
        private static readonly Regex VarNameRegex = new Regex("^[a-zA-Z0-9]+$");
        private TextBox _prevTxt;

        public PowerComposerView()
        {
            _prevTxt = BodyTxt;
            InitializeComponent();
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
            ValuesTxt.Text = vars.ContainsKey(VariableBox.Text) ? vars[VariableBox.Text] : "";
        }

        private static bool IsValidVarName(string s)
        {
            return VarNameRegex.IsMatch(s);
        }

        private void AddNewVarBtn_Click(object sender, EventArgs e)
        {
            if (NewVarTxt.Text.Length == 0)
            {
                VariableBox.SelectedIndex = VariableBox.Items.Count - 1;
                return;
            }

            if (!IsValidVarName(NewVarTxt.Text))
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
            VariableBox.TopIndex = VariableBox.Items.Count - 1;
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

        public bool IsErrorByUndefinedVar
        {
            get => ErrorUndefinedChk.Checked;
            set => ErrorUndefinedChk.Checked = value;
        }

        public bool IsFixContentLength
        {
            get => ErrorUndefinedChk.Checked;
            set => ErrorUndefinedChk.Checked = value;
        }

        public int MaxFollowRedirect
        {
            get
            {
                if (int.TryParse(FollowRedirectsTxt.Text, out var res) && res >= 0)
                {
                    return res;
                }

                return -1;
            }
            set => FollowRedirectsTxt.Text = value.ToString();
        }

        public bool IsAutoAuth
        {
            get => AutoAuthChk.Checked;
            set => AutoAuthChk.Checked = value;
        }

        public bool IsInspectSession
        {
            get => InspectChk.Checked;
            set => InspectChk.Checked = value;
        }

        public bool IsFixHostHeader
        {
            get => HostChk.Checked;
            set => HostChk.Checked = value;
        }

        private void VariableBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValuesTxt.ReadOnly = (VariableBox.SelectedIndex == -1);
            if (!ValuesTxt.ReadOnly) ValuesTxt.Focus();
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


        private void CreateDirectoryIfNotExists(string path)
        {
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
        }

        private void ExportVars(string path)
        {
            CreateDirectoryIfNotExists(path); // mkdir
            if (path[path.Length - 1] != Path.DirectorySeparatorChar) path += Path.DirectorySeparatorChar;
            foreach (KeyValuePair<string, string> kvp in vars)
            {
                // Write File.
                var sm = File.CreateText(path + kvp.Key + ".txt");
                sm.Write(kvp.Value);
                sm.Close();
            }
        }

        private void ImportVars(string path)
        {
            foreach (var f in Directory.GetFiles(path, "*.txt"))
            {
                var sm = File.OpenText(f);
                int fnamehead = f.LastIndexOf(Path.DirectorySeparatorChar); // C:\xxx\yyy\test.txt -> test.txt
                if (fnamehead == -1) fnamehead = 0;
                string s = f.Substring(fnamehead + 1, f.Length - fnamehead - 5); // test.txt -> test
                if (s.Length > 0 && IsValidVarName(s))
                {
                    bool sure = true;
                    if (vars.ContainsKey(s))
                    {
                        var x = MessageBox.Show(
                            s + @" is already exists." + Environment.NewLine + @"Do you want to overwrite this anyway?",
                            @"Warning", MessageBoxButtons.YesNo);
                        sure = x == DialogResult.Yes;
                    }

                    if (sure) vars[s] = sm.ReadToEnd();
                }
                else
                {
                    MessageBox.Show(@"Invalid variable name found:" + s);
                }
            }

            RefreshVars();
        }

        private void RefreshVars()
        {
            foreach (KeyValuePair<string, string> kvp in vars)
            {
                if (!VariableBox.Items.Contains(kvp.Key))
                {
                    VariableBox.Items.Add(kvp.Key);
                }
            }

            VariableBox.TopIndex = VariableBox.Items.Count - 1;
        }

        private void ImportBtn_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                ImportVars(folderBrowserDialog1.SelectedPath);
                MessageBox.Show(@" Imported successfully.");
            }
        }

        private void ExportBtn_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                ExportVars(folderBrowserDialog1.SelectedPath);
                MessageBox.Show(@"Exported successfully.");
            }
        }

        private void IncludeBtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string str1 = _prevTxt.Text.Substring(0, _prevTxt.SelectionStart);
                string str2 = _prevTxt.Text.Substring(_prevTxt.SelectionStart);
                _prevTxt.Text = str1
                                + @"!{" + openFileDialog1.FileName + @"}"
                                + str2;
            }
        }

        private void HeaderTxt_Enter(object sender, EventArgs e)
        {
            _prevTxt = HeaderTxt;
        }

        private void BodyTxt_Enter(object sender, EventArgs e)
        {
            _prevTxt = BodyTxt;
        }

        private void URITxt_Enter(object sender, EventArgs e)
        {
            _prevTxt = URITxt;
        }

        private void BuilderTipsLbl_Click(object sender, EventArgs e)
        {
            MessageBox.Show(BuilderTipsLbl.Text);
        }

        private void FRTimesLbl_Click(object sender, EventArgs e)
        {
            FollowRedirectsTxt.Focus();
        }
    }
}