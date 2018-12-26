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
using System.Threading;
using System.Collections;

namespace automata_sharp
{
    public partial class Form1 : Form
    {
        Automata automata = new Automata();
        DataTable dataTable = new DataTable();
        CancellationTokenSource ResetWordCancellation, ShortResetWordCancellation;
        IcdfaLogic CurrentIcdfaLogic;
        StringBuilder StringBuilder = new StringBuilder();

        public Form1()
        {
            InitializeComponent();
            buttonResetWordCalculate.Enabled = false;
            buttonShortResetWordCalculate.Enabled = false;
            ResetUI();
        }

        /// <summary>
        /// Сброс интерфейса в холодное
        /// </summary>
        private void ResetUI()
        {
            // Отключение кнопок
            buttonResetWordCalculate.Visible = true;
            buttonShortResetWordCalculate.Visible = true;
            buttonImpact.Enabled = false;
            labelCheckResult.Text = String.Empty;
            buttonCheck.Enabled = false;

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

        private void ActivateUI()
        {
            dataGridViewAutomata.ReadOnly = true;
            buttonResetWordCalculate.Enabled = true;
            buttonShortResetWordCalculate.Enabled = true;
            buttonImpact.Enabled = true;
            buttonCheck.Enabled = true;

            List<int> states = automata.GetStates();
            foreach (var i in states)
                comboBoxStates.Items.Add(i);

            dataGridViewAutomata.DataSource = dataTable;
        }

        /// <summary>
        /// Нажатие клавиши генерации нового автомата
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            // Сброс интерфейса, т.к. создается новый автомат
            ResetUI();

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
            bool flag = true;

            string input = textBoxWord.Text;
            string letters = automata.GetLetters();

            for (int i = 0; i < input.Count() && flag; ++i)
                if (!letters.Contains(input[i])) flag = false;

            if (!flag)
            {
                DialogResult dialog = MessageBox.Show("Wrong input word!", "Input word", MessageBoxButtons.OK);
            }
            else
            {
                labelStoped.Text = automata.Delta(Convert.ToInt32(comboBoxStates.SelectedItem.ToString()), textBoxWord.Text).ToString();
                labelStoped.ForeColor = Color.LimeGreen;
            }
        }

        /// <summary>
        /// Быстрый поиск любого слова
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void buttonResetWordCalculate_Click(object sender, EventArgs e)
        {

            //Используем токен только в теле using, в конце у этого токена будет вызвано 
            using (ResetWordCancellation = new CancellationTokenSource())
            {
                buttonCancelResetWord.Visible = true;
                buttonResetWordCalculate.Visible = false;
                try
                {
                    //Ждем OperationCanceledException у таски
                    labelQuickResetWord.Text = await automata.FindResetWord(ResetWordCancellation);
                    //если его нет, то обрабатываем соответствущим образом 
                    if (string.Empty.Equals(labelQuickResetWord.Text))
                    {
                        labelQuickResetWord.ForeColor = Color.Orange;
                        labelQuickResetWord.Text = "Reset word is not exists";
                    }
                    else
                    {
                        if (automata.Verificate(labelQuickResetWord.Text))
                        {
                            labelQuickResetWord.ForeColor = Color.LimeGreen;
                            labelQuickResetWord.Text += $" (reset to {automata.Delta(0, labelQuickResetWord.Text)})";
                        }
                        else
                        {
                            labelQuickResetWord.ForeColor = Color.Purple;
                            labelQuickResetWord.Text = "Algorythm returned wrong answer";
                        }
                    }
                    buttonCancelResetWord.Visible = false;
                }
                //Если прилител OperationCanceledException  
                catch (OperationCanceledException)
                {
                    labelQuickResetWord.ForeColor = Color.Red;
                    labelQuickResetWord.Text = "Canceled";
                    buttonResetWordCalculate.Visible = true;
                    buttonCancelResetWord.Visible = false;//Выключаем кнопку отмены 
                }
                //Если прилитело что-то, чего мы не ожидали, пробрасываем исключение наверх
                catch
                {
                    throw;
                }
                finally
                {
                    //В любом случае нам нужно
                    ResetWordCancellation = null;//убрать токен
                }
            }
        }

        /// <summary>
        /// Поиск кратчайшего слова
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void buttonShortResetWordCalculate_Click(object sender, EventArgs e)
        {
            bool flag = true;
            if (automata.GetStates().Count > 10)
            {
                flag = false;
                DialogResult caution = MessageBox.Show("This may take a long time, are you sure?", "Confirm", MessageBoxButtons.YesNo);
                flag = caution == DialogResult.Yes;
            }
            if (flag)
            {
                buttonShortResetWordCalculate.Visible = false;
                buttonCancelShortResetWord.Visible = true;
                using (ShortResetWordCancellation = new CancellationTokenSource())
                {
                    try
                    {
                        //Ждем OperationCanceledException у таски
                        buttonCancelShortResetWord.Enabled = true;
                        labelShortestResetWord.Text = await automata.FindShortestResetWord(ShortResetWordCancellation);
                        //если его нет, то обрабатываем соответствущим образом 
                        buttonCancelShortResetWord.Enabled = false;
                        if (labelShortestResetWord.Text == String.Empty)
                        {
                            labelShortestResetWord.ForeColor = Color.Orange;
                            labelShortestResetWord.Text = "Reset word is not exists";
                        }
                        else
                        if (automata.Verificate(labelShortestResetWord.Text))
                        {
                            labelShortestResetWord.ForeColor = Color.LimeGreen;
                            labelShortestResetWord.Text += $" (reset to {automata.Delta(0, labelShortestResetWord.Text)})";
                        }
                        else
                        {
                            labelShortestResetWord.ForeColor = Color.Purple;
                            labelShortestResetWord.Text = "Algorythm returned wrong answer";
                        }
                        buttonCancelShortResetWord.Visible = false;
                    }
                    //Если прилител OperationCanceledException  
                    catch (OperationCanceledException)
                    {
                        labelShortestResetWord.ForeColor = Color.Red;
                        labelShortestResetWord.Text = "Canceled";
                        buttonShortResetWordCalculate.Visible = true;
                        buttonCancelShortResetWord.Visible = false;//Выключаем кнопку отмены 
                    }
                    //Если прилитело что-то, чего мы не ожидали, пробрасываем исключение наверх
                    catch
                    {
                        throw;
                    }
                    finally
                    {
                        //В любом случае нам нужно
                        ShortResetWordCancellation = null;//убрать токен
                    }
                }
            }
        }

        /// <summary>
        /// Создание таблицы для заполнения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCreateTable_Click(object sender, EventArgs e)
        {
            ResetUI();

            tabControlMain.Enabled = false;

            dataTable = new DataTable();
            dataTable.Columns.Add("State");

            for (int j = 0, m = Convert.ToInt32(numericUpDownCreateAlphabet.Value); j < m; ++j)
                dataTable.Columns.Add($"by {Convert.ToChar('a' + j)}");

            for (int i = 0, n = Convert.ToInt32(numericUpDownCreateStates.Value); i < n; ++i)
                dataTable.Rows.Add(i);

            for (int i = 0, n = Convert.ToInt32(numericUpDownCreateStates.Value); i < n; ++i)
                for (int j = 1, m = Convert.ToInt32(numericUpDownCreateAlphabet.Value); j <= m; ++j)
                    dataTable.Rows[i][j] = 0;

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
            tabControlMain.Enabled = true;
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
            ResetUI();

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

        private void labelQuickResetWord_DoubleClick(object sender, EventArgs e)
        {
            Clipboard.SetText(labelQuickResetWord.Text);
            DialogResult dialog = MessageBox.Show("Copied to clipboard", "Reset word", MessageBoxButtons.OK);
        }

        private void labelShortestResetWord_DoubleClick(object sender, EventArgs e)
        {
            Clipboard.SetText(labelShortestResetWord.Text);
            DialogResult dialog = MessageBox.Show("Copied to clipboard", "Reset word", MessageBoxButtons.OK);
        }

        private void buttonCancelShortResetWord_Click(object sender, EventArgs e)
        {
            ShortResetWordCancellation?.Cancel();
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            if (automata.Verificate(textBoxCheck.Text))
            {
                labelCheckResult.ForeColor = Color.LimeGreen;
                labelCheckResult.Text = "Word IS the reset";
            }
            else
            {
                labelCheckResult.ForeColor = Color.Red;
                labelCheckResult.Text = "Word NOT the reset";
            }
        }

        private void buttonIcdfaGenerate_Click(object sender, EventArgs e)
        {


            int n = Convert.ToInt32(numericUpDownN.Value),
                k = Convert.ToInt32(numericUpDownK.Value);
            List<int> lengths = new List<int>();
            int parts = Convert.ToInt32(numericUpDownParts.Value),
                part = Convert.ToInt32(numericUpDownPart.Value);



            //lengths = await Task.Run(() => IcdfaGeneratorCreatePart(n, k, part, parts));

            GeneratorCreatePartLogic(n, k, part, parts);

            //string path = $"Prtcl{n}x{k}_pt{part}of{parts}.txt";

            //StreamWriter stream = new StreamWriter(path);

            //foreach (var t in lengths)
            //    stream.WriteLine(t);

            //stream.Close();


        }

        private List<int> IcdfaGeneratorCreatePart(int n, int k, int part, int parts)
        {
            List<int> lengths = new List<int>();

            int nm = n - 1;
            int km = k - 1;
            int nmm = n - 2;

            Generator temp = new Generator(n, k);
            int count_all = 0;
            while (!temp.IsLastFlags)
            {
                while (!temp.IsLastSequences)
                {
                    count_all++;
                    temp.NextICDFA(nm, km);
                }
                temp.NextFlags(nmm);
            }

            Generator generator = new Generator(n, k);
            int count = 0;

            for (int j = 0, t = (n - 1) * (n - 1) + 1; j < t; ++j)
                lengths.Add(0);

            int i = 1;
            while (!generator.IsLastFlags && i != part)
            {
                while (!generator.IsLastSequences && i != part)
                {
                    i++;
                    generator.NextICDFA(nm, km);
                }
                generator.NextFlags(nmm);
            }

            i = 1;
            while (!generator.IsLastFlags)
            {
                while (!generator.IsLastSequences)
                {
                    count++;
                    if (i == part)
                        lengths[generator.getWordLength()]++;
                    if (i == parts)
                        i = 0;
                    generator.NextICDFA(nm, km);
                    i++;
                }
                generator.NextFlags(nmm);
            }
            return lengths;
        }

        private async void GeneratorCreatePartLogic(int n, int k, int part, int parts)
        {
            buttonIcdfaGenerate.Visible = false;
            labelIcdfaStatus.ForeColor = Color.DarkBlue;
            labelIcdfaStatus.Text = $"Generating result for {n}x{k}, part {part} of {parts}";

            CurrentIcdfaLogic = new IcdfaLogic();


            updaterIcdfa.Enabled = true;
            await CurrentIcdfaLogic.StartAsync();
            updaterIcdfa.Enabled = false;
            UpdateIcdfaOutput();
            CurrentIcdfaLogic = null;

            buttonIcdfaGenerate.Visible = true;
            labelIcdfaStatus.Text = string.Empty;
        }

        private void updaterIcdfa_Tick(object sender, EventArgs e)
        {
            if (CurrentIcdfaLogic == null)
            {
                updaterIcdfa.Enabled = false;
                return;
            }
            UpdateIcdfaOutput();
        }

        private void UpdateIcdfaOutput()
        {
            if (CurrentIcdfaLogic == null) throw new InvalidProgramException();

            StringBuilder.Clear();
            var array = CurrentIcdfaLogic.GetTotalLenghts();
            StringBuilder.Append("Прошло времени: " + (DateTime.UtcNow - CurrentIcdfaLogic.LaunchTime).ToString(@"dd\.hh\:mm\:ss"));
            foreach (var e in array)
            {
                StringBuilder.Append("\n");
                StringBuilder.Append(e.ToString());
            }

            richTextBoxIcdfaOutput.Text = StringBuilder.ToString();
        }

        private void buttonCancelResetWord_Click(object sender, EventArgs e)
        {
            ResetWordCancellation?.Cancel();
        }
    }
}
