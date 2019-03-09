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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PowerComposerView));
            this.TitleLbl = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.OptionTab = new System.Windows.Forms.TabPage();
            this.HostChk = new System.Windows.Forms.CheckBox();
            this.FollowRedirectsTxt = new System.Windows.Forms.TextBox();
            this.FRTimesLbl = new System.Windows.Forms.Label();
            this.InspectChk = new System.Windows.Forms.CheckBox();
            this.AutoAuthChk = new System.Windows.Forms.CheckBox();
            this.FixLengthChk = new System.Windows.Forms.CheckBox();
            this.ErrorUndefinedChk = new System.Windows.Forms.CheckBox();
            this.VarsTab = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.ExportBtn = new System.Windows.Forms.Button();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.ImportBtn = new System.Windows.Forms.Button();
            this.NewVarTxt = new System.Windows.Forms.TextBox();
            this.AddNewVarBtn = new System.Windows.Forms.Button();
            this.VariableBox = new System.Windows.Forms.ListBox();
            this.ValuesTxt = new System.Windows.Forms.TextBox();
            this.BuilderTab = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.IncludeBtn = new System.Windows.Forms.Button();
            this.TimesLbl = new System.Windows.Forms.Label();
            this.VersionTxt = new System.Windows.Forms.ComboBox();
            this.TimesTxt = new System.Windows.Forms.TextBox();
            this.HeaderTxt = new System.Windows.Forms.TextBox();
            this.ExecBtn = new System.Windows.Forms.Button();
            this.MethodTxt = new System.Windows.Forms.ComboBox();
            this.BodyTxt = new System.Windows.Forms.TextBox();
            this.URITxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BuilderTipsLbl = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
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
            this.OptionTab.Controls.Add(this.HostChk);
            this.OptionTab.Controls.Add(this.FollowRedirectsTxt);
            this.OptionTab.Controls.Add(this.FRTimesLbl);
            this.OptionTab.Controls.Add(this.InspectChk);
            this.OptionTab.Controls.Add(this.AutoAuthChk);
            this.OptionTab.Controls.Add(this.FixLengthChk);
            this.OptionTab.Controls.Add(this.ErrorUndefinedChk);
            this.OptionTab.Location = new System.Drawing.Point(8, 39);
            this.OptionTab.Name = "OptionTab";
            this.OptionTab.Size = new System.Drawing.Size(1055, 444);
            this.OptionTab.TabIndex = 2;
            this.OptionTab.Text = "Option";
            this.OptionTab.UseVisualStyleBackColor = true;
            // 
            // HostChk
            // 
            this.HostChk.AutoSize = true;
            this.HostChk.Checked = true;
            this.HostChk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.HostChk.Location = new System.Drawing.Point(15, 166);
            this.HostChk.Name = "HostChk";
            this.HostChk.Size = new System.Drawing.Size(296, 28);
            this.HostChk.TabIndex = 7;
            this.HostChk.Text = "Fix Host header with URL";
            this.HostChk.UseVisualStyleBackColor = true;
            // 
            // FollowRedirectsTxt
            // 
            this.FollowRedirectsTxt.Location = new System.Drawing.Point(384, 29);
            this.FollowRedirectsTxt.MaxLength = 10;
            this.FollowRedirectsTxt.Name = "FollowRedirectsTxt";
            this.FollowRedirectsTxt.Size = new System.Drawing.Size(72, 31);
            this.FollowRedirectsTxt.TabIndex = 6;
            this.FollowRedirectsTxt.Text = "10";
            // 
            // FRTimesLbl
            // 
            this.FRTimesLbl.AutoSize = true;
            this.FRTimesLbl.Location = new System.Drawing.Point(462, 36);
            this.FRTimesLbl.Name = "FRTimesLbl";
            this.FRTimesLbl.Size = new System.Drawing.Size(283, 24);
            this.FRTimesLbl.TabIndex = 5;
            this.FRTimesLbl.Text = "Follow Redirects max times";
            this.FRTimesLbl.Click += new System.EventHandler(this.FRTimesLbl_Click);
            // 
            // InspectChk
            // 
            this.InspectChk.AutoSize = true;
            this.InspectChk.Location = new System.Drawing.Point(15, 131);
            this.InspectChk.Name = "InspectChk";
            this.InspectChk.Size = new System.Drawing.Size(199, 28);
            this.InspectChk.TabIndex = 4;
            this.InspectChk.Text = "Inspect Session";
            this.InspectChk.UseVisualStyleBackColor = true;
            // 
            // AutoAuthChk
            // 
            this.AutoAuthChk.AutoSize = true;
            this.AutoAuthChk.Location = new System.Drawing.Point(15, 97);
            this.AutoAuthChk.Name = "AutoAuthChk";
            this.AutoAuthChk.Size = new System.Drawing.Size(309, 28);
            this.AutoAuthChk.TabIndex = 3;
            this.AutoAuthChk.Text = "Automatically Authenticate";
            this.AutoAuthChk.UseVisualStyleBackColor = true;
            // 
            // FixLengthChk
            // 
            this.FixLengthChk.AutoSize = true;
            this.FixLengthChk.Checked = true;
            this.FixLengthChk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.FixLengthChk.Location = new System.Drawing.Point(15, 63);
            this.FixLengthChk.Name = "FixLengthChk";
            this.FixLengthChk.Size = new System.Drawing.Size(312, 28);
            this.FixLengthChk.TabIndex = 2;
            this.FixLengthChk.Text = "Fix Content-Length header";
            this.FixLengthChk.UseVisualStyleBackColor = true;
            // 
            // ErrorUndefinedChk
            // 
            this.ErrorUndefinedChk.AutoSize = true;
            this.ErrorUndefinedChk.Checked = true;
            this.ErrorUndefinedChk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ErrorUndefinedChk.Location = new System.Drawing.Point(15, 29);
            this.ErrorUndefinedChk.Name = "ErrorUndefinedChk";
            this.ErrorUndefinedChk.Size = new System.Drawing.Size(307, 28);
            this.ErrorUndefinedChk.TabIndex = 1;
            this.ErrorUndefinedChk.Text = "Error by undefined variable";
            this.ErrorUndefinedChk.UseVisualStyleBackColor = true;
            // 
            // VarsTab
            // 
            this.VarsTab.BackColor = System.Drawing.Color.Silver;
            this.VarsTab.Controls.Add(this.tableLayoutPanel2);
            this.VarsTab.Location = new System.Drawing.Point(8, 39);
            this.VarsTab.Name = "VarsTab";
            this.VarsTab.Padding = new System.Windows.Forms.Padding(3);
            this.VarsTab.Size = new System.Drawing.Size(1055, 444);
            this.VarsTab.TabIndex = 0;
            this.VarsTab.Text = "Variables";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.ExportBtn, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.SaveBtn, 2, 4);
            this.tableLayoutPanel2.Controls.Add(this.ImportBtn, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.NewVarTxt, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.AddNewVarBtn, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.VariableBox, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.ValuesTxt, 2, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(15, 21);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(631, 317);
            this.tableLayoutPanel2.TabIndex = 14;
            // 
            // ExportBtn
            // 
            this.ExportBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ExportBtn.Location = new System.Drawing.Point(248, 43);
            this.ExportBtn.Name = "ExportBtn";
            this.ExportBtn.Size = new System.Drawing.Size(134, 34);
            this.ExportBtn.TabIndex = 13;
            this.ExportBtn.Text = "Export";
            this.ExportBtn.UseVisualStyleBackColor = true;
            this.ExportBtn.Click += new System.EventHandler(this.ExportBtn_Click);
            // 
            // SaveBtn
            // 
            this.SaveBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SaveBtn.Location = new System.Drawing.Point(436, 280);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(143, 32);
            this.SaveBtn.TabIndex = 5;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // ImportBtn
            // 
            this.ImportBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ImportBtn.Location = new System.Drawing.Point(248, 3);
            this.ImportBtn.Name = "ImportBtn";
            this.ImportBtn.Size = new System.Drawing.Size(134, 34);
            this.ImportBtn.TabIndex = 12;
            this.ImportBtn.Text = "Import";
            this.ImportBtn.UseVisualStyleBackColor = true;
            this.ImportBtn.Click += new System.EventHandler(this.ImportBtn_Click);
            // 
            // NewVarTxt
            // 
            this.NewVarTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NewVarTxt.Location = new System.Drawing.Point(3, 279);
            this.NewVarTxt.MaxLength = 32;
            this.NewVarTxt.Name = "NewVarTxt";
            this.NewVarTxt.Size = new System.Drawing.Size(239, 31);
            this.NewVarTxt.TabIndex = 10;
            this.NewVarTxt.Enter += new System.EventHandler(this.NewVarTxt_Enter);
            this.NewVarTxt.Leave += new System.EventHandler(this.NewVarTxt_Leave);
            // 
            // AddNewVarBtn
            // 
            this.AddNewVarBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddNewVarBtn.Location = new System.Drawing.Point(248, 279);
            this.AddNewVarBtn.Name = "AddNewVarBtn";
            this.AddNewVarBtn.Size = new System.Drawing.Size(134, 35);
            this.AddNewVarBtn.TabIndex = 11;
            this.AddNewVarBtn.Text = "Add";
            this.AddNewVarBtn.UseVisualStyleBackColor = true;
            this.AddNewVarBtn.Click += new System.EventHandler(this.AddNewVarBtn_Click);
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
            this.tableLayoutPanel2.SetRowSpan(this.VariableBox, 4);
            this.VariableBox.ScrollAlwaysVisible = true;
            this.VariableBox.Size = new System.Drawing.Size(239, 268);
            this.VariableBox.TabIndex = 9;
            this.VariableBox.SelectedIndexChanged += new System.EventHandler(this.VariableBox_SelectedIndexChanged);
            this.VariableBox.SelectedValueChanged += new System.EventHandler(this.VariableBox_SelectedValueChanged);
            // 
            // ValuesTxt
            // 
            this.ValuesTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ValuesTxt.Location = new System.Drawing.Point(388, 3);
            this.ValuesTxt.MaxLength = 0;
            this.ValuesTxt.Multiline = true;
            this.ValuesTxt.Name = "ValuesTxt";
            this.ValuesTxt.ReadOnly = true;
            this.tableLayoutPanel2.SetRowSpan(this.ValuesTxt, 4);
            this.ValuesTxt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ValuesTxt.Size = new System.Drawing.Size(240, 270);
            this.ValuesTxt.TabIndex = 3;
            this.ValuesTxt.TextChanged += new System.EventHandler(this.ValuesTxt_TextChanged);
            // 
            // BuilderTab
            // 
            this.BuilderTab.Controls.Add(this.tableLayoutPanel1);
            this.BuilderTab.Location = new System.Drawing.Point(8, 39);
            this.BuilderTab.Name = "BuilderTab";
            this.BuilderTab.Size = new System.Drawing.Size(1055, 444);
            this.BuilderTab.TabIndex = 3;
            this.BuilderTab.Text = "Builder";
            this.BuilderTab.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.Controls.Add(this.IncludeBtn, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.VersionTxt, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.HeaderTxt, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.MethodTxt, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.BodyTxt, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.URITxt, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.TimesTxt, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.TimesLbl, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.BuilderTipsLbl, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.ExecBtn, 3, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1049, 438);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // IncludeBtn
            // 
            this.IncludeBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IncludeBtn.Location = new System.Drawing.Point(692, 150);
            this.IncludeBtn.Name = "IncludeBtn";
            this.IncludeBtn.Size = new System.Drawing.Size(154, 34);
            this.IncludeBtn.TabIndex = 15;
            this.IncludeBtn.TabStop = false;
            this.IncludeBtn.Text = "Include file";
            this.IncludeBtn.UseVisualStyleBackColor = true;
            this.IncludeBtn.Click += new System.EventHandler(this.IncludeBtn_Click);
            // 
            // TimesLbl
            // 
            this.TimesLbl.AutoSize = true;
            this.TimesLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TimesLbl.Location = new System.Drawing.Point(972, 147);
            this.TimesLbl.Name = "TimesLbl";
            this.TimesLbl.Size = new System.Drawing.Size(74, 40);
            this.TimesLbl.TabIndex = 13;
            this.TimesLbl.Text = "times";
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
            this.VersionTxt.Location = new System.Drawing.Point(706, 3);
            this.VersionTxt.Name = "VersionTxt";
            this.VersionTxt.Size = new System.Drawing.Size(140, 32);
            this.VersionTxt.TabIndex = 8;
            this.VersionTxt.Text = "HTTP/1.1";
            // 
            // TimesTxt
            // 
            this.TimesTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TimesTxt.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.TimesTxt.Location = new System.Drawing.Point(852, 150);
            this.TimesTxt.MaxLength = 11;
            this.TimesTxt.Name = "TimesTxt";
            this.TimesTxt.Size = new System.Drawing.Size(114, 31);
            this.TimesTxt.TabIndex = 12;
            this.TimesTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TimesTxt.Enter += new System.EventHandler(this.TimesTxt_Enter);
            this.TimesTxt.Leave += new System.EventHandler(this.TimesTxt_Leave);
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
            this.HeaderTxt.Size = new System.Drawing.Size(843, 101);
            this.HeaderTxt.TabIndex = 3;
            this.HeaderTxt.Text = "User-Agent: Fiddler";
            this.HeaderTxt.WordWrap = false;
            this.HeaderTxt.Enter += new System.EventHandler(this.HeaderTxt_Enter);
            // 
            // ExecBtn
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.ExecBtn, 2);
            this.ExecBtn.Location = new System.Drawing.Point(852, 43);
            this.ExecBtn.Name = "ExecBtn";
            this.ExecBtn.Size = new System.Drawing.Size(184, 96);
            this.ExecBtn.TabIndex = 1;
            this.ExecBtn.Text = "Execute";
            this.ExecBtn.UseVisualStyleBackColor = true;
            this.ExecBtn.Click += new System.EventHandler(this.ExecBtn_Click);
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
            // BodyTxt
            // 
            this.BodyTxt.AcceptsTab = true;
            this.BodyTxt.AllowDrop = true;
            this.BodyTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.BodyTxt, 3);
            this.BodyTxt.Location = new System.Drawing.Point(3, 190);
            this.BodyTxt.MaxLength = 0;
            this.BodyTxt.Multiline = true;
            this.BodyTxt.Name = "BodyTxt";
            this.BodyTxt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.BodyTxt.Size = new System.Drawing.Size(843, 245);
            this.BodyTxt.TabIndex = 4;
            this.BodyTxt.WordWrap = false;
            this.BodyTxt.TextChanged += new System.EventHandler(this.BodyTxt_TextChanged);
            this.BodyTxt.Enter += new System.EventHandler(this.BodyTxt_Enter);
            // 
            // URITxt
            // 
            this.URITxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.URITxt.Location = new System.Drawing.Point(203, 3);
            this.URITxt.MaxLength = 1024;
            this.URITxt.Name = "URITxt";
            this.URITxt.Size = new System.Drawing.Size(483, 31);
            this.URITxt.TabIndex = 2;
            this.URITxt.Text = "http://example.com/";
            this.URITxt.Enter += new System.EventHandler(this.URITxt_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 40);
            this.label1.TabIndex = 16;
            this.label1.Text = "Request Body:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BuilderTipsLbl
            // 
            this.BuilderTipsLbl.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.BuilderTipsLbl, 2);
            this.BuilderTipsLbl.Location = new System.Drawing.Point(852, 187);
            this.BuilderTipsLbl.Name = "BuilderTipsLbl";
            this.BuilderTipsLbl.Size = new System.Drawing.Size(193, 251);
            this.BuilderTipsLbl.TabIndex = 17;
            this.BuilderTipsLbl.Text = resources.GetString("BuilderTipsLbl.Text");
            this.BuilderTipsLbl.Click += new System.EventHandler(this.BuilderTipsLbl_Click);
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
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "zip";
            this.saveFileDialog1.FileName = "vars.zip";
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
            this.OptionTab.PerformLayout();
            this.VarsTab.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.BuilderTab.ResumeLayout(false);
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
        private Label BuilderTipsLbl;
        private TextBox FollowRedirectsTxt;
        private Label FRTimesLbl;
        private CheckBox InspectChk;
        private CheckBox AutoAuthChk;
        private CheckBox FixLengthChk;
        private CheckBox ErrorUndefinedChk;
        private CheckBox HostChk;
        private SaveFileDialog saveFileDialog1;
        private ColorDialog colorDialog1;
    }
}
