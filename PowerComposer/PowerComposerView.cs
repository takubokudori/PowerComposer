﻿/*
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
using System.IO.Compression;
using System.Text;
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
            using (ZipArchive za = ZipFile.Open(path, ZipArchiveMode.Update))
            {
                foreach (KeyValuePair<string, string> kvp in vars)
                {
                    ZipArchiveEntry entry = za.CreateEntry(kvp.Key + ".txt");
                    using (StreamWriter s = new StreamWriter(entry.Open(), Encoding.UTF8))
                    {
                        s.Write(kvp.Value);
                    }
                }
            }
        }

        private void ImportVars(string path)
        {
            if (File.Exists(path))
            {
                using (ZipArchive za = ZipFile.OpenRead(path))
                {
                    foreach (var e in za.Entries)
                    {
                        string f = e.Name;
                        int fnameext = f.LastIndexOf('.');
                        if (fnameext == -1) fnameext = 0;
                        string s = f.Substring(0, fnameext); // test.txt -> test

                        if (s.Length > 0 && IsValidVarName(s))
                        {
                            bool sure = true;
                            if (vars.ContainsKey(s)) // Warning
                            {
                                var x = MessageBox.Show(
                                    s + @" is already exists." + Environment.NewLine +
                                    @"Do you want to overwrite this anyway?",
                                    @"Warning", MessageBoxButtons.YesNo);
                                sure = x == DialogResult.Yes;
                            }

                            if (sure)
                            {
                                using (StreamReader sr = new StreamReader(e.Open(), Encoding.UTF8))
                                {
                                    //すべて読み込む
                                    vars[s] = sr.ReadToEnd();
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show(@"Invalid variable name found:" + s);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show(path + @" is not exists.");
            }
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
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ImportVars(openFileDialog1.FileName);
                RefreshVars();
                MessageBox.Show(@"Imported successfully.");
            }
        }

        private void ExportBtn_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ExportVars(saveFileDialog1.FileName);
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