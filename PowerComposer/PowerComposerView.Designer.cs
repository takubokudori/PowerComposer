using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PowerComposer
{
    partial class PowerComposerView
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.TitleLbl = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.OptionTab = new System.Windows.Forms.TabPage();
            this.OptionBox = new System.Windows.Forms.CheckedListBox();
            this.VarsTab = new System.Windows.Forms.TabPage();
            this.ImportBtn = new System.Windows.Forms.Button();
            this.ExportBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.AddNewVarBtn = new System.Windows.Forms.Button();
            this.NewVarTxt = new System.Windows.Forms.TextBox();
            this.ValuesTxt = new System.Windows.Forms.TextBox();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.VariableBox = new System.Windows.Forms.ListBox();
            this.BuilderTab = new System.Windows.Forms.TabPage();
            this.ExecBtn = new System.Windows.Forms.Button();
            this.TimesTxt = new System.Windows.Forms.TextBox();
            this.TimesLbl = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.URITxt = new System.Windows.Forms.TextBox();
            this.BodyTxt = new System.Windows.Forms.TextBox();
            this.MethodTxt = new System.Windows.Forms.ComboBox();
            this.HeaderTxt = new System.Windows.Forms.TextBox();
            this.VersionTxt = new System.Windows.Forms.ComboBox();
            this.IncludeBtn = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.OptionTab.SuspendLayout();
            this.VarsTab.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.BuilderTab.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitleLbl
            // 
            this.TitleLbl.AutoSize = true;
            this.TitleLbl.Location = new System.Drawing.Point(22, 11);
            this.TitleLbl.Name = "TitleLbl";
            this.TitleLbl.Size = new System.Drawing.Size(174, 24);
            this.TitleLbl.TabIndex = 0;
            this.TitleLbl.Text = "PowerComposer";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(378, 11);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(511, 24);
            this.linkLabel1.TabIndex = 11;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "https://github.com/takubokudori/PowerComposer";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.InitialDirectory = "%userprofile%";
            this.openFileDialog1.Title = "Import Variables";
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.Description = "Hello";
            // 
            // OptionTab
            // 
            this.OptionTab.Controls.Add(this.OptionBox);
            this.OptionTab.Location = new System.Drawing.Point(8, 39);
            this.OptionTab.Name = "OptionTab";
            this.OptionTab.Size = new System.Drawing.Size(1055, 444);
            this.OptionTab.TabIndex = 2;
            this.OptionTab.Text = "Option";
            this.OptionTab.UseVisualStyleBackColor = true;
            // 
            // OptionBox
            // 
            this.OptionBox.CheckOnClick = true;
            this.OptionBox.FormattingEnabled = true;
            this.OptionBox.Items.AddRange(new object[] {
            "Error by undefined variable",
            "Fix Content-Length header",
            "Follow Redirects",
            "Automatically Authenticate",
            "Inspect Session"});
            this.OptionBox.Location = new System.Drawing.Point(3, 41);
            this.OptionBox.Name = "OptionBox";
            this.OptionBox.Size = new System.Drawing.Size(297, 238);
            this.OptionBox.TabIndex = 0;
            // 
            // VarsTab
            // 
            this.VarsTab.BackColor = System.Drawing.Color.Silver;
            this.VarsTab.Controls.Add(this.tableLayoutPanel2);
            this.VarsTab.Controls.Add(this.ExportBtn);
            this.VarsTab.Controls.Add(this.ImportBtn);
            this.VarsTab.Location = new System.Drawing.Point(8, 39);
            this.VarsTab.Name = "VarsTab";
            this.VarsTab.Padding = new System.Windows.Forms.Padding(3);
            this.VarsTab.Size = new System.Drawing.Size(1055, 444);
            this.VarsTab.TabIndex = 0;
            this.VarsTab.Text = "Variables";
            // 
            // ImportBtn
            // 
            this.ImportBtn.Location = new System.Drawing.Point(667, 96);
            this.ImportBtn.Name = "ImportBtn";
            this.ImportBtn.Size = new System.Drawing.Size(100, 40);
            this.ImportBtn.TabIndex = 12;
            this.ImportBtn.Text = "Import";
            this.ImportBtn.UseVisualStyleBackColor = true;
            this.ImportBtn.Click += new System.EventHandler(this.ImportBtn_Click);
            // 
            // ExportBtn
            // 
            this.ExportBtn.Location = new System.Drawing.Point(667, 202);
            this.ExportBtn.Name = "ExportBtn";
            this.ExportBtn.Size = new System.Drawing.Size(100, 40);
            this.ExportBtn.TabIndex = 13;
            this.ExportBtn.Text = "Export";
            this.ExportBtn.UseVisualStyleBackColor = true;
            this.ExportBtn.Click += new System.EventHandler(this.ExportBtn_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.VariableBox, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.SaveBtn, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.ValuesTxt, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.NewVarTxt, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.AddNewVarBtn, 1, 2);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(15, 21);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(631, 317);
            this.tableLayoutPanel2.TabIndex = 14;
            // 
            // AddNewVarBtn
            // 
            this.AddNewVarBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddNewVarBtn.Location = new System.Drawing.Point(268, 279);
            this.AddNewVarBtn.Name = "AddNewVarBtn";
            this.AddNewVarBtn.Size = new System.Drawing.Size(94, 35);
            this.AddNewVarBtn.TabIndex = 11;
            this.AddNewVarBtn.Text = "Add";
            this.AddNewVarBtn.UseVisualStyleBackColor = true;
            this.AddNewVarBtn.Click += new System.EventHandler(this.AddNewVarBtn_Click);
            // 
            // NewVarTxt
            // 
            this.NewVarTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NewVarTxt.Location = new System.Drawing.Point(3, 279);
            this.NewVarTxt.MaxLength = 32;
            this.NewVarTxt.Name = "NewVarTxt";
            this.NewVarTxt.Size = new System.Drawing.Size(259, 31);
            this.NewVarTxt.TabIndex = 10;
            this.NewVarTxt.Enter += new System.EventHandler(this.NewVarTxt_Enter);
            this.NewVarTxt.Leave += new System.EventHandler(this.NewVarTxt_Leave);
            // 
            // ValuesTxt
            // 
            this.ValuesTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ValuesTxt.Location = new System.Drawing.Point(368, 3);
            this.ValuesTxt.MaxLength = 0;
            this.ValuesTxt.Multiline = true;
            this.ValuesTxt.Name = "ValuesTxt";
            this.ValuesTxt.ReadOnly = true;
            this.tableLayoutPanel2.SetRowSpan(this.ValuesTxt, 2);
            this.ValuesTxt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ValuesTxt.Size = new System.Drawing.Size(260, 270);
            this.ValuesTxt.TabIndex = 3;
            this.ValuesTxt.TextChanged += new System.EventHandler(this.ValuesTxt_TextChanged);
            // 
            // SaveBtn
            // 
            this.SaveBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SaveBtn.Location = new System.Drawing.Point(426, 280);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(143, 32);
            this.SaveBtn.TabIndex = 5;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // VariableBox
            // 
            this.VariableBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VariableBox.FormattingEnabled = true;
            this.VariableBox.ItemHeight = 24;
            this.VariableBox.Location = new System.Drawing.Point(3, 3);
            this.VariableBox.Name = "VariableBox";
            this.tableLayoutPanel2.SetRowSpan(this.VariableBox, 2);
            this.VariableBox.ScrollAlwaysVisible = true;
            this.VariableBox.Size = new System.Drawing.Size(259, 268);
            this.VariableBox.TabIndex = 9;
            this.VariableBox.SelectedIndexChanged += new System.EventHandler(this.VariableBox_SelectedIndexChanged);
            this.VariableBox.SelectedValueChanged += new System.EventHandler(this.VariableBox_SelectedValueChanged);
            // 
            // BuilderTab
            // 
            this.BuilderTab.Controls.Add(this.tableLayoutPanel1);
            this.BuilderTab.Controls.Add(this.TimesLbl);
            this.BuilderTab.Controls.Add(this.TimesTxt);
            this.BuilderTab.Controls.Add(this.ExecBtn);
            this.BuilderTab.Location = new System.Drawing.Point(8, 39);
            this.BuilderTab.Name = "BuilderTab";
            this.BuilderTab.Size = new System.Drawing.Size(1055, 444);
            this.BuilderTab.TabIndex = 3;
            this.BuilderTab.Text = "Builder";
            this.BuilderTab.UseVisualStyleBackColor = true;
            // 
            // ExecBtn
            // 
            this.ExecBtn.Location = new System.Drawing.Point(869, 22);
            this.ExecBtn.Name = "ExecBtn";
            this.ExecBtn.Size = new System.Drawing.Size(165, 96);
            this.ExecBtn.TabIndex = 1;
            this.ExecBtn.Text = "Execute";
            this.ExecBtn.UseVisualStyleBackColor = true;
            this.ExecBtn.Click += new System.EventHandler(this.ExecBtn_Click);
            // 
            // TimesTxt
            // 
            this.TimesTxt.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.TimesTxt.Location = new System.Drawing.Point(834, 142);
            this.TimesTxt.MaxLength = 32;
            this.TimesTxt.Name = "TimesTxt";
            this.TimesTxt.Size = new System.Drawing.Size(100, 31);
            this.TimesTxt.TabIndex = 12;
            this.TimesTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TimesTxt.Enter += new System.EventHandler(this.TimesTxt_Enter);
            this.TimesTxt.Leave += new System.EventHandler(this.TimesTxt_Leave);
            // 
            // TimesLbl
            // 
            this.TimesLbl.AutoSize = true;
            this.TimesLbl.Location = new System.Drawing.Point(940, 149);
            this.TimesLbl.Name = "TimesLbl";
            this.TimesLbl.Size = new System.Drawing.Size(64, 24);
            this.TimesLbl.TabIndex = 13;
            this.TimesLbl.Text = "times";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel1.Controls.Add(this.IncludeBtn, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.VersionTxt, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.HeaderTxt, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.MethodTxt, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.BodyTxt, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.URITxt, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(27, 19);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(636, 394);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 40);
            this.label1.TabIndex = 16;
            this.label1.Text = "Request Body:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // URITxt
            // 
            this.URITxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.URITxt.Location = new System.Drawing.Point(203, 3);
            this.URITxt.MaxLength = 1024;
            this.URITxt.Name = "URITxt";
            this.URITxt.Size = new System.Drawing.Size(270, 31);
            this.URITxt.TabIndex = 2;
            this.URITxt.Text = "http://example.com/";
            this.URITxt.Enter += new System.EventHandler(this.URITxt_Enter);
            // 
            // BodyTxt
            // 
            this.BodyTxt.AcceptsTab = true;
            this.BodyTxt.AllowDrop = true;
            this.BodyTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.BodyTxt, 3);
            this.BodyTxt.Location = new System.Drawing.Point(3, 177);
            this.BodyTxt.MaxLength = 0;
            this.BodyTxt.Multiline = true;
            this.BodyTxt.Name = "BodyTxt";
            this.BodyTxt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.BodyTxt.Size = new System.Drawing.Size(630, 214);
            this.BodyTxt.TabIndex = 4;
            this.BodyTxt.WordWrap = false;
            this.BodyTxt.TextChanged += new System.EventHandler(this.BodyTxt_TextChanged);
            this.BodyTxt.Enter += new System.EventHandler(this.BodyTxt_Enter);
            // 
            // MethodTxt
            // 
            this.MethodTxt.Dock = System.Windows.Forms.DockStyle.Left;
            this.MethodTxt.DropDownWidth = 80;
            this.MethodTxt.FormattingEnabled = true;
            this.MethodTxt.Items.AddRange(new object[] {
            "GET",
            "POST",
            "PUT",
            "HEAD",
            "TRACE",
            "DELETE",
            "SEARCH",
            "CONNECT",
            "PROPFIND",
            "PROPPATCH",
            "PATCH",
            "MKCOL",
            "COPY",
            "MOVE",
            "LOCK",
            "UNLOCK",
            "OPTIONS"});
            this.MethodTxt.Location = new System.Drawing.Point(3, 3);
            this.MethodTxt.Name = "MethodTxt";
            this.MethodTxt.Size = new System.Drawing.Size(180, 32);
            this.MethodTxt.TabIndex = 7;
            this.MethodTxt.Text = "GET";
            // 
            // HeaderTxt
            // 
            this.HeaderTxt.AcceptsTab = true;
            this.HeaderTxt.AllowDrop = true;
            this.HeaderTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.HeaderTxt, 3);
            this.HeaderTxt.Location = new System.Drawing.Point(3, 43);
            this.HeaderTxt.MaxLength = 0;
            this.HeaderTxt.Multiline = true;
            this.HeaderTxt.Name = "HeaderTxt";
            this.HeaderTxt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.HeaderTxt.Size = new System.Drawing.Size(630, 88);
            this.HeaderTxt.TabIndex = 3;
            this.HeaderTxt.Text = "User-Agent: Fiddler";
            this.HeaderTxt.WordWrap = false;
            this.HeaderTxt.Enter += new System.EventHandler(this.HeaderTxt_Enter);
            // 
            // VersionTxt
            // 
            this.VersionTxt.Dock = System.Windows.Forms.DockStyle.Right;
            this.VersionTxt.FormattingEnabled = true;
            this.VersionTxt.Items.AddRange(new object[] {
            "HTTP/2.0",
            "HTTP/1.2",
            "HTTP/1.1",
            "HTTP/1.0",
            "HTTP/0.9"});
            this.VersionTxt.Location = new System.Drawing.Point(493, 3);
            this.VersionTxt.Name = "VersionTxt";
            this.VersionTxt.Size = new System.Drawing.Size(140, 32);
            this.VersionTxt.TabIndex = 8;
            this.VersionTxt.Text = "HTTP/1.1";
            // 
            // IncludeBtn
            // 
            this.IncludeBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IncludeBtn.Location = new System.Drawing.Point(479, 137);
            this.IncludeBtn.Name = "IncludeBtn";
            this.IncludeBtn.Size = new System.Drawing.Size(154, 34);
            this.IncludeBtn.TabIndex = 15;
            this.IncludeBtn.TabStop = false;
            this.IncludeBtn.Text = "Include file";
            this.IncludeBtn.UseVisualStyleBackColor = true;
            this.IncludeBtn.Click += new System.EventHandler(this.IncludeBtn_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.BuilderTab);
            this.tabControl1.Controls.Add(this.VarsTab);
            this.tabControl1.Controls.Add(this.OptionTab);
            this.tabControl1.Location = new System.Drawing.Point(3, 50);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1071, 491);
            this.tabControl1.TabIndex = 10;
            // 
            // PowerComposerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.TitleLbl);
            this.Name = "PowerComposerView";
            this.Size = new System.Drawing.Size(1090, 563);
            this.Load += new System.EventHandler(this.PowerComposerView_Load);
            this.Leave += new System.EventHandler(this.PowerComposerView_Leave);
            this.OptionTab.ResumeLayout(false);
            this.VarsTab.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.BuilderTab.ResumeLayout(false);
            this.BuilderTab.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Label TitleLbl;
        private LinkLabel linkLabel1;
        private OpenFileDialog openFileDialog1;
        private FolderBrowserDialog folderBrowserDialog1;
        private TabPage OptionTab;
        public CheckedListBox OptionBox;
        public TabPage VarsTab;
        private TableLayoutPanel tableLayoutPanel2;
        public ListBox VariableBox;
        private Button SaveBtn;
        public TextBox ValuesTxt;
        private TextBox NewVarTxt;
        private Button AddNewVarBtn;
        private Button ExportBtn;
        private Button ImportBtn;
        private TabPage BuilderTab;
        private TableLayoutPanel tableLayoutPanel1;
        private Button IncludeBtn;
        public ComboBox VersionTxt;
        public TextBox HeaderTxt;
        public ComboBox MethodTxt;
        public TextBox BodyTxt;
        public TextBox URITxt;
        private Label label1;
        private Label TimesLbl;
        public TextBox TimesTxt;
        public Button ExecBtn;
        private TabControl tabControl1;
    }
}
