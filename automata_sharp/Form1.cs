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

        public Form1()
        {
            InitializeComponent();
        }

        private async void buttonGenerate_Click(object sender, EventArgs e)
        {
            automata = Automata.Random(
                Convert.ToInt32(numericUpDownStates.Value),
                Convert.ToInt32(numericUpDownAlphabet.Value));

            List<int> states = automata.GetStates();
            foreach(var i in states)
                comboBoxStates.Items.Add(i);

            dataGridViewGenerated.DataSource =automata.OutputToDataTable();
            for(int i = 1; i < dataGridViewGenerated.Columns.Count; ++i)
                dataGridViewGenerated.Columns[i].Width = 70;

            var state = buttonGenerate.Enabled;//Сохраняем состояние 
            buttonGenerate.Enabled = false;//Выключаем кнопку что бы не было проблем 

            labelQuickResetWord.Text = await Task.Run(() => automata.FindResetWord());
            labelQuickResetWord.ForeColor = Color.LimeGreen;

            labelShortestResetWord.Text = await Task.Run(() => automata.FindShortestResetWord());
            labelShortestResetWord.ForeColor = Color.LimeGreen;

            buttonGenerate.Enabled |= state;//Востонавливаем состояние 
        }

        private void buttonGeneratorImpact_Click(object sender, EventArgs e)
        {
            labelGeneratedStoped.Text = automata.Delta(Convert.ToInt32(comboBoxStates.SelectedItem.ToString()), textBoxWord.Text).ToString();
            labelGeneratedStoped.ForeColor = Color.LimeGreen;
        }
    }
}
