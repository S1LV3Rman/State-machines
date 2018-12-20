using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace automata_sharp
{
    public partial class Form1 : Form
    {
        Automata automata = new Automata();
        DataTable dataTable = new DataTable();


        public Form1()
        {
            InitializeComponent();
            resetUI();
        }

        /// <summary>
        /// Сброс интерфейса в холодное
        /// </summary>
        private void resetUI()
        {
            // Отключение кнопок
            buttonResetWordCalculate.Enabled = false;
            buttonShortResetWordCalculate.Enabled = false;
            buttonImpact.Enabled = false;
            
            // Очистка выпадающего списка
            if (comboBoxStates.Items.Count != 0)
                comboBoxStates.Items.Clear();

            // Сброс значений текстовых полей синх. слов
            labelQuickResetWord.ForeColor = 
                labelShortestResetWord.ForeColor = 
                labelStoped.ForeColor = Color.Red;

            labelQuickResetWord.Text = 
                labelShortestResetWord.Text = 
                labelStoped.Text = "Unknown";
        }

        /// <summary>
        /// Нажатие клавиши генерации нового автомата
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            // Сброс интерфейса, т.к. создается новый автомат
            resetUI();

            // Генерация
            automata = Automata.Random(
                Convert.ToInt32(numericUpDownStates.Value),
                Convert.ToInt32(numericUpDownAlphabet.Value));

            dataTable = automata.OutputToDataTable();
            ActivateUI();
        }

        /// <summary>
        /// Воздействие слова на автомат
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonGeneratorImpact_Click(object sender, EventArgs e)
        {
            labelStoped.Text = automata.Delta(Convert.ToInt32(comboBoxStates.SelectedItem.ToString()), textBoxWord.Text).ToString();
            labelStoped.ForeColor = Color.LimeGreen;
        }

        /// <summary>
        /// Быстрый поиск любого слова
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void buttonResetWordCalculate_Click(object sender, EventArgs e)
        {
            buttonResetWordCalculate.Enabled = false;
            labelQuickResetWord.Text = await Task.Run(() => automata.FindResetWord());
            if (labelQuickResetWord.Text == String.Empty)
            {
                labelQuickResetWord.ForeColor = Color.Orange;
                labelQuickResetWord.Text = "Reset word is not exists";
            }
            else
            {
                labelQuickResetWord.ForeColor = Color.LimeGreen;
                labelQuickResetWord.Text += $" (reset to {automata.Delta(0, labelQuickResetWord.Text)})";
            }
        }

        /// <summary>
        /// Поиск кратчайшего слова
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void buttonShortResetWordCalculate_Click(object sender, EventArgs e)
        {
            buttonShortResetWordCalculate.Enabled = false;
            labelShortestResetWord.Text = await Task.Run(() => automata.FindShortestResetWord());
            if (labelShortestResetWord.Text == String.Empty)
            {
                labelShortestResetWord.ForeColor = Color.Orange;
                labelShortestResetWord.Text = "Reset word is not exists";
            }
            else
            {
                labelShortestResetWord.ForeColor = Color.LimeGreen;
                labelShortestResetWord.Text += $" (reset to {automata.Delta(0, labelShortestResetWord.Text)})";
            }
        }

        /// <summary>
        /// Создание таблицы для заполнения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCreateTable_Click(object sender, EventArgs e)
        {
            resetUI();
            dataTable = new DataTable();
            dataTable.Columns.Add("State");

            for (int j = 0, m = Convert.ToInt32(numericUpDownCreateAlphabet.Value); j < m; ++j)
                dataTable.Columns.Add($"by {Convert.ToChar('a' + j)}");

            for (int i = 0, n = Convert.ToInt32(numericUpDownCreateStates.Value); i < n; ++i)
                dataTable.Rows.Add(i);

            dataGridViewAutomata.DataSource = dataTable;
            dataGridViewAutomata.ReadOnly = false;

            labelCreateInfo.Text = "Put all data into table, then push \"Confirm\"";
            buttonCreateTable.Visible = false;
            buttonCreateConfirm.Visible = true;
        }

        /// <summary>
        /// Подтверждение заполнения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCreateConfirm_Click(object sender, EventArgs e)
        {
            automata = new Automata(dataTable);
            buttonCreateTable.Visible = true;
            buttonCreateConfirm.Visible = false;
            labelCreateInfo.Text = "Select size, then push \"Create Table\"";

            ActivateUI();
        }

        /// <summary>
        /// Выбор нового стартового состояния
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxStates_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelStoped.Text = "Unknown";
            labelStoped.ForeColor = Color.Red;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                StreamWriter stream = new StreamWriter(saveFileDialog.OpenFile());

                dataTable = automata.OutputToDataTable();

                int states = dataTable.Rows.Count;
                int letters = dataTable.Columns.Count - 1;

                stream.WriteLine(states);
                stream.WriteLine(letters);

                for (int i = 0; i < states; ++i)
                    for (int j = 0; j < letters; ++j)
                    {
                        stream.Write(dataTable.Rows[i][j + 1]);
                        if (j + 1 == letters)
                            stream.Write(';');
                        else
                            stream.Write(',');
                    }

                stream.Close();
            }
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            resetUI();

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {

                StreamReader stream = new StreamReader(openFileDialog.OpenFile());
                var rawInput = stream.ReadToEnd();
                stream.Close();

                var lines = rawInput.Split('\n');

                int states = Convert.ToInt32(lines[0]);
                int alphabet = Convert.ToInt32(lines[1]);

                dataTable = new DataTable();

                dataTable.Columns.Add("State");
                for (int i = 0; i < alphabet; ++i)
                    dataTable.Columns.Add($"by {Convert.ToChar('a' + i)}");
                for (int i = 0; i < states; ++i)
                    dataTable.Rows.Add();

                var rows = lines[2].Split(';'); // Разбиваем таблицу на строки
                for (int i = 0; i < states; ++i)
                {
                    var temp = rows[i].Split(',');// И на отдельные клетки текущей строки
                    dataTable.Rows[i][0] = i;
                    for (int j = 1; j <= alphabet; ++j)
                        dataTable.Rows[i][j] = temp[j - 1];
                }

                automata = new Automata(dataTable);

                ActivateUI();
            }
        }

        private void ActivateUI()
        {
            dataGridViewAutomata.ReadOnly = true;
            buttonResetWordCalculate.Enabled = true;
            buttonShortResetWordCalculate.Enabled = true;
            buttonImpact.Enabled = true;

            List<int> states = automata.GetStates();
            foreach (var i in states)
                comboBoxStates.Items.Add(i);

            dataGridViewAutomata.DataSource = dataTable;
        }

        private void labelQuickResetWord_DoubleClick(object sender, EventArgs e)
        {
            Clipboard.SetText(labelQuickResetWord.Text);
        }

        private void labelShortestResetWord_DoubleClick(object sender, EventArgs e)
        {
            Clipboard.SetText(labelShortestResetWord.Text);
        }
    }
}
