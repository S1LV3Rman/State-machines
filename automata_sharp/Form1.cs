using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace automata_sharp
{
    public partial class Form1 : Form
    {
        public Automata automata = new Automata();
        DataTable createDataTable = new DataTable();

        private void resetUI()
        {
            buttonResetWordCalculate.Enabled = false;
            buttonShortResetWordCalculate.Enabled = false;
            buttonImpact.Enabled = false;

            if (comboBoxStates.Items.Count != 0)
                comboBoxStates.Items.Clear();

            labelQuickResetWord.ForeColor = 
                labelShortestResetWord.ForeColor = 
                labelStoped.ForeColor = Color.Red;

            labelQuickResetWord.Text = 
                labelShortestResetWord.Text = 
                labelStoped.Text = "Unknown";
        }

        public Form1()
        {
            InitializeComponent();
            resetUI();
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            resetUI();
            automata = Automata.Random(
                Convert.ToInt32(numericUpDownStates.Value),
                Convert.ToInt32(numericUpDownAlphabet.Value));

            List<int> states = automata.GetStates();
            foreach(var i in states)
                comboBoxStates.Items.Add(i);

            buttonResetWordCalculate.Enabled = true;
            buttonShortResetWordCalculate.Enabled = true;
            buttonImpact.Enabled = true;

            dataGridViewAutomata.DataSource = automata.OutputToDataTable();
            for(int i = 1; i < dataGridViewAutomata.Columns.Count; ++i)
                dataGridViewAutomata.Columns[i].Width = 70;
        }

        private void buttonGeneratorImpact_Click(object sender, EventArgs e)
        {
            labelStoped.Text = automata.Delta(Convert.ToInt32(comboBoxStates.SelectedItem.ToString()), textBoxWord.Text).ToString();
            labelStoped.ForeColor = Color.LimeGreen;
        }

        private async void buttonResetWordCalculate_Click(object sender, EventArgs e)
        {
            buttonResetWordCalculate.Enabled = false;
            labelQuickResetWord.Text = await Task.Run(() => automata.FindResetWord());
            labelQuickResetWord.ForeColor = Color.LimeGreen;
            labelQuickResetWord.Text += $" (reset to {automata.Delta(0, labelQuickResetWord.Text)})";
        }

        private async void buttonShortResetWordCalculate_Click(object sender, EventArgs e)
        {
            buttonShortResetWordCalculate.Enabled = false;
            labelShortestResetWord.Text = await Task.Run(() => automata.FindShortestResetWord());
            labelShortestResetWord.ForeColor = Color.LimeGreen;
            labelShortestResetWord.Text += $" (reset to {automata.Delta(0, labelShortestResetWord.Text)})";
        }

        private void buttonCreateTable_Click(object sender, EventArgs e)
        {
            resetUI();
            createDataTable.Columns.Add("State");

            for (int j = 0, m = Convert.ToInt32(numericUpDownCreateAlphabet.Value); j < m; ++j)
                createDataTable.Columns.Add($"by {Convert.ToChar('a' + j)}");

            for (int i = 0, n = Convert.ToInt32(numericUpDownCreateStates.Value); i < n; ++i)
                createDataTable.Rows.Add(i);

            dataGridViewAutomata.DataSource = createDataTable;
            dataGridViewAutomata.ReadOnly = false;

            label6.Text = "Put all data into table, then push \"Confirm\"";
            buttonCreateTable.Visible = false;
            buttonCreateConfirm.Visible = true;
        }

        private void buttonCreateConfirm_Click(object sender, EventArgs e)
        {
            automata = new Automata(createDataTable);
            buttonCreateTable.Visible = true;
            buttonCreateConfirm.Visible = false;
            label6.Text = "Select size, then push \"Create Table\"";
            dataGridViewAutomata.ReadOnly = true;
            buttonResetWordCalculate.Enabled = true;
            buttonShortResetWordCalculate.Enabled = true;
            buttonImpact.Enabled = true;

            List<int> states = automata.GetStates();
            foreach (var i in states)
                comboBoxStates.Items.Add(i);

            dataGridViewAutomata.DataSource = automata.OutputToDataTable();
        }

        private void comboBoxStates_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelStoped.Text = "Unknown";
            labelStoped.ForeColor = Color.Red;
        }
    }
}
