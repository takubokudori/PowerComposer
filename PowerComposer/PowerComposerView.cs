using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerComposer
{
    public partial class PowerComposerView : UserControl
    {
        private Dictionary<string, string> vars;

        public PowerComposerView()
        {
            vars = new Dictionary<string, string>();
            InitializeComponent();
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
            PowerComposer.Execute();
        }

        private void VariableBox_SelectedValueChanged(object sender, EventArgs e)
        {
            ValuesLbl.Text = VariableBox.Text;
            if (vars.ContainsKey(VariableBox.Text))
            {
                ValuesTxt.Text = vars[VariableBox.Text];
            }
            else ValuesTxt.Text = "";
        }

        private void AddNewVarBtn_Click(object sender, EventArgs e)
        {
            if (VariableBox.FindStringExact(NewVarTxt.Text) != -1)
            {
                MessageBox.Show($@"{NewVarTxt.Text} is already exists.");
                return;
            }

            VariableBox.Items.Add(NewVarTxt.Text);
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

        private void VariableBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            tabControl1.SelectTab(ValsTab);

        }

    }
}