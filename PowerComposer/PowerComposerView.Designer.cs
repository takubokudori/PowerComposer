﻿namespace PowerComposer
{
    partial class PowerComposerView
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.ExecBtn = new System.Windows.Forms.Button();
            this.URITxt = new System.Windows.Forms.TextBox();
            this.HeaderTxt = new System.Windows.Forms.TextBox();
            this.BodyTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.MethodTxt = new System.Windows.Forms.ComboBox();
            this.VersionTxt = new System.Windows.Forms.ComboBox();
            this.ValuesTxt = new System.Windows.Forms.TextBox();
            this.VariableBox = new System.Windows.Forms.ListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.VarsTab = new System.Windows.Forms.TabPage();
            this.ValsTab = new System.Windows.Forms.TabPage();
            this.ValuesLbl = new System.Windows.Forms.Label();
            this.NewVarTxt = new System.Windows.Forms.TextBox();
            this.AddNewVarBtn = new System.Windows.Forms.Button();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.VarsTab.SuspendLayout();
            this.ValsTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitleLbl
            // 
            this.TitleLbl.AutoSize = true;
            this.TitleLbl.Location = new System.Drawing.Point(22, 23);
            this.TitleLbl.Name = "TitleLbl";
            this.TitleLbl.Size = new System.Drawing.Size(174, 24);
            this.TitleLbl.TabIndex = 0;
            this.TitleLbl.Text = "PowerComposer";
            // 
            // ExecBtn
            // 
            this.ExecBtn.Location = new System.Drawing.Point(634, 23);
            this.ExecBtn.Name = "ExecBtn";
            this.ExecBtn.Size = new System.Drawing.Size(165, 96);
            this.ExecBtn.TabIndex = 1;
            this.ExecBtn.Text = "Execute";
            this.ExecBtn.UseVisualStyleBackColor = true;
            this.ExecBtn.Click += new System.EventHandler(this.ExecBtn_Click);
            // 
            // URITxt
            // 
            this.URITxt.Location = new System.Drawing.Point(212, 72);
            this.URITxt.MaxLength = 1024;
            this.URITxt.Name = "URITxt";
            this.URITxt.Size = new System.Drawing.Size(252, 31);
            this.URITxt.TabIndex = 2;
            // 
            // HeaderTxt
            // 
            this.HeaderTxt.Location = new System.Drawing.Point(26, 122);
            this.HeaderTxt.MaxLength = 10240;
            this.HeaderTxt.Multiline = true;
            this.HeaderTxt.Name = "HeaderTxt";
            this.HeaderTxt.Size = new System.Drawing.Size(584, 215);
            this.HeaderTxt.TabIndex = 3;
            // 
            // BodyTxt
            // 
            this.BodyTxt.Location = new System.Drawing.Point(26, 361);
            this.BodyTxt.MaxLength = 10240;
            this.BodyTxt.Multiline = true;
            this.BodyTxt.Name = "BodyTxt";
            this.BodyTxt.Size = new System.Drawing.Size(584, 383);
            this.BodyTxt.TabIndex = 4;
            this.BodyTxt.TextChanged += new System.EventHandler(this.BodyTxt_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 762);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(511, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "https://github.com/takubokudori/PowerComposer";
            // 
            // MethodTxt
            // 
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
            this.MethodTxt.Location = new System.Drawing.Point(26, 71);
            this.MethodTxt.Name = "MethodTxt";
            this.MethodTxt.Size = new System.Drawing.Size(180, 32);
            this.MethodTxt.TabIndex = 7;
            this.MethodTxt.Text = "GET";
            // 
            // VersionTxt
            // 
            this.VersionTxt.FormattingEnabled = true;
            this.VersionTxt.Items.AddRange(new object[] {
            "HTTP/2.0",
            "HTTP/1.2",
            "HTTP/1.1",
            "HTTP/1.0",
            "HTTP/0.9"});
            this.VersionTxt.Location = new System.Drawing.Point(470, 71);
            this.VersionTxt.Name = "VersionTxt";
            this.VersionTxt.Size = new System.Drawing.Size(140, 32);
            this.VersionTxt.TabIndex = 8;
            this.VersionTxt.Text = "HTTP/1.1";
            // 
            // ValuesTxt
            // 
            this.ValuesTxt.Location = new System.Drawing.Point(21, 41);
            this.ValuesTxt.MaxLength = 10240;
            this.ValuesTxt.Multiline = true;
            this.ValuesTxt.Name = "ValuesTxt";
            this.ValuesTxt.Size = new System.Drawing.Size(259, 381);
            this.ValuesTxt.TabIndex = 3;
            this.ValuesTxt.TextChanged += new System.EventHandler(this.ValuesTxt_TextChanged);
            // 
            // VariableBox
            // 
            this.VariableBox.FormattingEnabled = true;
            this.VariableBox.ItemHeight = 24;
            this.VariableBox.Items.AddRange(new object[] {
            "test",
            "hello",
            "directory",
            "numeral",
            "alphabet",
            "ALPHABET"});
            this.VariableBox.Location = new System.Drawing.Point(6, 6);
            this.VariableBox.Name = "VariableBox";
            this.VariableBox.Size = new System.Drawing.Size(179, 412);
            this.VariableBox.TabIndex = 9;
            this.VariableBox.SelectedValueChanged += new System.EventHandler(this.VariableBox_SelectedValueChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.VarsTab);
            this.tabControl1.Controls.Add(this.ValsTab);
            this.tabControl1.Location = new System.Drawing.Point(634, 231);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(319, 513);
            this.tabControl1.TabIndex = 10;
            // 
            // VarsTab
            // 
            this.VarsTab.BackColor = System.Drawing.Color.Silver;
            this.VarsTab.Controls.Add(this.AddNewVarBtn);
            this.VarsTab.Controls.Add(this.NewVarTxt);
            this.VarsTab.Controls.Add(this.VariableBox);
            this.VarsTab.Location = new System.Drawing.Point(8, 39);
            this.VarsTab.Name = "VarsTab";
            this.VarsTab.Padding = new System.Windows.Forms.Padding(3);
            this.VarsTab.Size = new System.Drawing.Size(303, 466);
            this.VarsTab.TabIndex = 0;
            this.VarsTab.Text = "Variables";
            // 
            // ValsTab
            // 
            this.ValsTab.BackColor = System.Drawing.Color.Silver;
            this.ValsTab.Controls.Add(this.SaveBtn);
            this.ValsTab.Controls.Add(this.ValuesLbl);
            this.ValsTab.Controls.Add(this.ValuesTxt);
            this.ValsTab.Location = new System.Drawing.Point(8, 39);
            this.ValsTab.Name = "ValsTab";
            this.ValsTab.Padding = new System.Windows.Forms.Padding(3);
            this.ValsTab.Size = new System.Drawing.Size(303, 466);
            this.ValsTab.TabIndex = 1;
            this.ValsTab.Text = "Values";
            // 
            // ValuesLbl
            // 
            this.ValuesLbl.AutoSize = true;
            this.ValuesLbl.Location = new System.Drawing.Point(112, 3);
            this.ValuesLbl.Name = "ValuesLbl";
            this.ValuesLbl.Size = new System.Drawing.Size(49, 24);
            this.ValuesLbl.TabIndex = 4;
            this.ValuesLbl.Text = "test";
            // 
            // NewVarTxt
            // 
            this.NewVarTxt.Location = new System.Drawing.Point(7, 425);
            this.NewVarTxt.Name = "NewVarTxt";
            this.NewVarTxt.Size = new System.Drawing.Size(178, 31);
            this.NewVarTxt.TabIndex = 10;
            // 
            // AddNewVarBtn
            // 
            this.AddNewVarBtn.Location = new System.Drawing.Point(191, 425);
            this.AddNewVarBtn.Name = "AddNewVarBtn";
            this.AddNewVarBtn.Size = new System.Drawing.Size(82, 31);
            this.AddNewVarBtn.TabIndex = 11;
            this.AddNewVarBtn.Text = "Add";
            this.AddNewVarBtn.UseVisualStyleBackColor = true;
            this.AddNewVarBtn.Click += new System.EventHandler(this.AddNewVarBtn_Click);
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(75, 428);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(143, 32);
            this.SaveBtn.TabIndex = 5;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // PowerComposerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.VersionTxt);
            this.Controls.Add(this.MethodTxt);
            this.Controls.Add(this.HeaderTxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BodyTxt);
            this.Controls.Add(this.URITxt);
            this.Controls.Add(this.ExecBtn);
            this.Controls.Add(this.TitleLbl);
            this.Name = "PowerComposerView";
            this.Size = new System.Drawing.Size(1103, 799);
            this.Load += new System.EventHandler(this.PowerComposerView_Load);
            this.Leave += new System.EventHandler(this.PowerComposerView_Leave);
            this.tabControl1.ResumeLayout(false);
            this.VarsTab.ResumeLayout(false);
            this.VarsTab.PerformLayout();
            this.ValsTab.ResumeLayout(false);
            this.ValsTab.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label TitleLbl;
        public System.Windows.Forms.Button ExecBtn;
        public System.Windows.Forms.TextBox URITxt;
        public System.Windows.Forms.TextBox HeaderTxt;
        public System.Windows.Forms.TextBox BodyTxt;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox MethodTxt;
        public System.Windows.Forms.ComboBox VersionTxt;
        public System.Windows.Forms.TextBox ValuesTxt;
        public System.Windows.Forms.ListBox VariableBox;
        private System.Windows.Forms.TabControl tabControl1;
        public System.Windows.Forms.TabPage VarsTab;
        public System.Windows.Forms.TabPage ValsTab;
        private System.Windows.Forms.Label ValuesLbl;
        private System.Windows.Forms.Button AddNewVarBtn;
        private System.Windows.Forms.TextBox NewVarTxt;
        private System.Windows.Forms.Button SaveBtn;
    }
}