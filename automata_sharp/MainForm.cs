using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Windows.Forms.DataVisualization.Charting;

namespace automata_sharp
{
    public partial class MainForm : Form
    {
        const bool deactivate = false; // Во имя читабельности кода
        const bool activate = true;

        Automata automata = new Automata();
        DataTable dataTable = new DataTable();
        CancellationTokenSource ResetWordCancellation, ShortResetWordCancellation;
        IcdfaLogic CurrentIcdfaLogic;
        StringBuilder StringBuilder = new StringBuilder();

        public MainForm()
        {
            InitializeComponent();
            buttonResetWordCalculate.Enabled = false;
            buttonShortResetWordCalculate.Enabled = false;
            RightPanel(deactivate);
            numericUpDownTotalParts.Value =
                numericUpDownCalculateTo.Value = Environment.ProcessorCount;
        }
        
        /// <summary>
        /// Нажатие клавиши генерации нового автомата
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            RightPanel(deactivate);
            automata = Automata.Random(
                Convert.ToInt32(numericUpDownStates.Value),
                Convert.ToInt32(numericUpDownAlphabet.Value));

            dataTable = automata.OutputToDataTable();
            dataGridViewAutomata.DataSource = dataTable;
            RightPanel(activate);
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
            string letters = automata._letters;

            for (int i = 0; i < input.Count() && flag; ++i)
                if (!letters.Contains(input[i])) flag = false;

            if (!flag)
            {
                DialogResult dialog = MessageBox.Show("Invalid input word", "Input word", MessageBoxButtons.OK);
            }
            else
            {
                try
                {
                    labelStoped.Text = automata.Delta(Convert.ToInt32(comboBoxStates.Text), textBoxWord.Text).ToString();
                    labelStoped.ForeColor = Color.LimeGreen;
                }
                catch
                {
                    DialogResult dialog = MessageBox.Show("Invalid input state", "Input state", MessageBoxButtons.OK);
                }
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
                }
                //Если прилител OperationCanceledException  
                catch (OperationCanceledException)
                {
                    labelQuickResetWord.ForeColor = Color.Red;
                    labelQuickResetWord.Text = "Canceled";
                    
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
                    buttonResetWordCalculate.Visible = true;
                    buttonCancelResetWord.Visible = false;//Выключаем кнопку отмены 
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
            if (automata._states.Count > 10)
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
                    }
                    //Если прилител OperationCanceledException  
                    catch (OperationCanceledException)
                    {
                        labelShortestResetWord.ForeColor = Color.Red;
                        labelShortestResetWord.Text = "Canceled";
                        
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
                        buttonShortResetWordCalculate.Visible = true;
                        buttonCancelShortResetWord.Visible = false;//Выключаем кнопку отмены 
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
            RightPanel(deactivate);

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

            RightPanel(activate);
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
            saveFileDialog.AddExtension = true;
            saveFileDialog.DefaultExt = "automata";
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
            RightPanel(deactivate);

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = "automata";
            openFileDialog.AddExtension = true;
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
                dataGridViewAutomata.DataSource = dataTable;

                RightPanel(activate);
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
            try
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
            catch
            {
                DialogResult dialog = MessageBox.Show("Invalid input word", "Reset word", MessageBoxButtons.OK);
            }
        }

        private void buttonIcdfaGenerate_Click(object sender, EventArgs e)
        {
            int totalParts = Convert.ToInt32(numericUpDownTotalParts.Value),
              startPart = Convert.ToInt32(numericUpDownCalculateFrom.Value),
              endPart = Convert.ToInt32(numericUpDownCalculateTo.Value),
              countParts = endPart - startPart + 1;

            if (totalParts >= endPart && endPart >= startPart)
            {
                if (countParts > Environment.ProcessorCount)
                {
                    DialogResult dialog = MessageBox.Show($"Your count parts ({countParts}) is more then CPU threads ({Environment.ProcessorCount})\nAre you sure?", "Confirm", MessageBoxButtons.OKCancel);
                    if(dialog == DialogResult.OK)
                    {
                        //tabControlMain.Enabled = false;
                        progressBar1.Visible = true;
                        buttonIcdfaCancel.Visible = true;
                        progressBar1.Style = ProgressBarStyle.Marquee;

                        int n = Convert.ToInt32(numericUpDownN.Value),
                            k = Convert.ToInt32(numericUpDownK.Value);


                        GeneratorCreatePartLogic(n, k, totalParts, startPart, countParts);
                    }
                }
                else
                {
                    //tabControlMain.Enabled = false;
                    progressBar1.Visible = true;
                    buttonIcdfaCancel.Visible = true;
                    progressBar1.Style = ProgressBarStyle.Marquee;

                    int n = Convert.ToInt32(numericUpDownN.Value),
                        k = Convert.ToInt32(numericUpDownK.Value);


                    GeneratorCreatePartLogic(n, k, totalParts, startPart, countParts);
                }
            }
            else
            {
                DialogResult dialog = MessageBox.Show("Wrong input\nTotal >= CalcTo >= CalcFrom", "Input", MessageBoxButtons.OK);
            }
        }

        private async void GeneratorCreatePartLogic(int n, int k, int totalParts, int startPart, int countParts)
        {
            buttonIcdfaGenerate.Visible = false;

            CurrentIcdfaLogic = new IcdfaLogic(n, k, totalParts, startPart, countParts);

            updaterIcdfa.Enabled = true;//Запускаем таймер который подтягивает изменения в CurrentIcdfaLogic

            await CurrentIcdfaLogic.StartAsync();//Запускаем вычисления и ждем их завершения
            /* Вычисления закончены */

            updaterIcdfa.Enabled = false;//Отключаем таймер который подтягивает изменения в CurrentIcdfaLogic
            UpdateIcdfaOutput();//Обновляем вывод  

            //Восстанавливаем интерфейс
            buttonIcdfaGenerate.Visible = true;
            tabControlMain.Enabled = true;
            progressBar1.Visible = false;
            progressBar1.Value = 0;

            // Запись в файл
            var result = CurrentIcdfaLogic.GetTotalLenghts();
            var stream = new StreamWriter($"Prtcl{n}x{k}_pts{startPart}-{startPart + countParts - 1}of{totalParts}.txt");
            foreach (var record in result)
                stream.WriteLine(record);
            stream.Close();

            CurrentIcdfaLogic = null;//Сбрасываем CurrentIcdfaLogic
            if (checkBoxShutdown.Checked) Shutdown();
        }

        private void updaterIcdfa_Tick(object sender, EventArgs e)
        {
            //Если CurrentIcdfaLogic не задан
            if (CurrentIcdfaLogic == null)
            {
                updaterIcdfa.Enabled = false;//отключаем таймер
                return;
            }
            //Иначе обновляем вывод 
            UpdateIcdfaOutput();
        }

        /// <summary>
        /// Обновляет вывод связанный с Icdfa
        /// </summary>
        private void UpdateIcdfaOutput()
        {
            if (CurrentIcdfaLogic == null) throw new InvalidProgramException();

            StringBuilder.Clear();//Юзам StringBuilder для экономии памяти и времени cpu
            var array = CurrentIcdfaLogic.GetTotalLenghts();//Суммируем все части

            var deltaTime = DateTime.UtcNow - CurrentIcdfaLogic.LaunchTime;//Получаем время работы

            ulong? totalCount = IcdfaHelper.GetTotalCountNullable(CurrentIcdfaLogic.N, CurrentIcdfaLogic.K);

            StringBuilder.Append(GetDeltaTime(deltaTime));
            StringBuilder.Append("\n");

            if (totalCount.HasValue)
            {
                var totalParts = CurrentIcdfaLogic.TotalParts;
                var countParts = CurrentIcdfaLogic.CountParts;

                var totalPartCount = (ulong)Math.Round(totalCount.Value * (countParts / (double)totalParts));

                var currentCount = CurrentIcdfaLogic.GetCurrentCount();
                var progress = currentCount / (float)totalPartCount;

                progressBar1.Style = ProgressBarStyle.Blocks;
                progressBar1.Value = Convert.ToInt32(Math.Round(progress * 1000, 1));

                StringBuilder.Append(GetRemainedTime(deltaTime, totalPartCount, progress));
                StringBuilder.Append("\n");

                StringBuilder.Append(GetCurrentCountOfTotalCount(currentCount, totalPartCount, totalCount.Value));
                StringBuilder.Append("\n");

                StringBuilder.Append(GetProgress(progress));
                //StringBuilder.Append("\n");

                //StringBuilder.Append(GetTransactionPerSecond(deltaTime,currentCount));
                //StringBuilder.Append("\n");

                //StringBuilder.Append(GetGCCallsPerSecond(deltaTime, GC.CollectionCount(0), GC.CollectionCount(1), GC.CollectionCount(2)));
                //StringBuilder.Append("\n");
            }
            else
            {
                StringBuilder.Append("<Calculating additional information...>");
                StringBuilder.Append("\n");
            }
            chartICDFA.Series[0].Points.Clear();
            for (int i = 1; i < array.Length; i++)
            {
                //StringBuilder.Append("\n");
                //StringBuilder.Append(i.ToString("D2"));
                //StringBuilder.Append(" - ");
                //StringBuilder.Append(array[i].ToString());
                
                chartICDFA.Series[0].Points.Add(array[i], i);
            }

            chartICDFA.Update();
            chartICDFA.Series.Invalidate();

            richTextBoxIcdfaOutput.Text = StringBuilder.ToString();
        }

        string GetDeltaTime(TimeSpan deltaTime)
        {
            return "Time elapsed: " + deltaTime.ToString(@"dd\.hh\:mm\:ss");
        }

        string GetRemainedTime(TimeSpan deltaTime, ulong totalCount , float progress)
        {
            var remainedSeconds = deltaTime.TotalSeconds * (1.0 / progress);
            var remained = new TimeSpan(0, 0, (int)Math.Round(remainedSeconds)) - deltaTime;
            return "Estimated calculation time: " + remained.ToString(@"dd\.hh\:mm\:ss");
        }

        string GetProgress(float progress)
        {
            return "Progress: " + progress.ToString("P1");
        }


        string GetCurrentCountOfTotalCount(ulong currentCount, ulong totalPartCount, ulong totalCount)
        {
            return "Calculated: " + currentCount.ToString() + " / " + totalPartCount.ToString() + " of total " + totalCount + " ICDFAØ";
        }

        //TODO
        [Obsolete("Not corrected")]
        string GetTransactionPerSecond(TimeSpan deltaTime, int deltaCount)
        {
            return "debug Transactions per second: " + (deltaCount / deltaTime.TotalSeconds).ToString("N");
        }

        //TODO
        [Obsolete("Not corrected")]
        string GetGCCallsPerSecond(TimeSpan deltaTime, int gen0, int gen1, int gen2)
        {
            return "debug GC0 calls per second: " + (gen0 / deltaTime.TotalSeconds).ToString("N") +
                 "\nGC1 calls per second: " + (gen1 / deltaTime.TotalSeconds).ToString("N") +
                 "\nGC2 calls per second: " + (gen2 / deltaTime.TotalSeconds).ToString("N");
        }        

        private void buttonCancelResetWord_Click(object sender, EventArgs e)
        {
            ResetWordCancellation?.Cancel();
        }

        /// <summary>
        /// Переключение между вкладками
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControlMain.SelectedTab.Text)
            {
                case "Generator":
                    chartICDFA.Visible = false;
                    richTextBoxIcdfaOutput.Visible = false;
                    break;
                case "Constructor":
                    chartICDFA.Visible = false;
                    richTextBoxIcdfaOutput.Visible = false;
                    break;
                case "File":
                    chartICDFA.Visible = false;
                    richTextBoxIcdfaOutput.Visible = false;
                    break;
                case "Reset word experiment":
                    richTextBoxIcdfaOutput.Visible = true;
                    chartICDFA.Visible = true;
                    break;
                case "About":
                    chartICDFA.Visible = false;
                    richTextBoxIcdfaOutput.Visible = false;
                    break;
            }
        }

            private void checkBoxShutdown_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShutdown.Checked)
            {
                DialogResult dialogResult = MessageBox.Show("Your PC will automaticly shutdown after completing caluclation, are you sure?", "Confirm", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                    checkBoxShutdown.Checked = false;
            }
        }

        private void RightPanel(bool state)
        {
            // При любом изменении состояния сброс строк
            labelCheckResult.Text = String.Empty;

            labelQuickResetWord.ForeColor =
                labelShortestResetWord.ForeColor =
                labelStoped.ForeColor = Color.Red;

            labelQuickResetWord.Text =
                labelShortestResetWord.Text =
                labelStoped.Text = "Unknown";

            buttonResetWordCalculate.Enabled = state;
            buttonShortResetWordCalculate.Enabled = state;
            buttonImpact.Enabled = state;
            buttonCheck.Enabled = state;

            if (state)
            {
                List<int> states = automata._states;
                foreach (var i in states)
                    comboBoxStates.Items.Add(i);
            }
            else
            {
                comboBoxStates.Items.Clear();
                comboBoxStates.Text = string.Empty;
            }
        }

        private void buttonIcdfaCancel_Click(object sender, EventArgs e)
        {
            CurrentIcdfaLogic?.Cancel();
        }

        void Shutdown()
        {
            //System.Diagnostics.Process.Start("Shutdown", "-s -t 60");
            //DialogResult dialogResult = MessageBox.Show("Cancel shutdown?", "Shutdown", MessageBoxButtons.YesNo);
            //if (dialogResult == DialogResult.Yes) System.Diagnostics.Process.Start("Shutdown", "-a");
        }
    }

}
