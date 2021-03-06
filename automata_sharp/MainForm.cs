﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Media;

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
        SoundPlayer CompleteSoundPlayer;
        Shutdown shutdown = new Shutdown();

        public MainForm()
        {
            InitializeComponent();
            buttonResetWordCalculate.Enabled = false;
            buttonShortResetWordCalculate.Enabled = false;
            RightPanel(deactivate);
            numericUpDownTotalParts.Value =
                numericUpDownCalculateTo.Value = Environment.ProcessorCount;
            CompleteSoundPlayer = new SoundPlayer(Properties.Resources.CompleteSound);
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

            dataGridViewAutomata.Columns[0].ReadOnly = true;
                        
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
            if (dataGridAutomataVerificate())
            {
                dataGridViewAutomata.ReadOnly = true;

                tabControlMain.Enabled = true;
                automata = new Automata(dataTable);
                buttonCreateTable.Visible = true;
                buttonCreateConfirm.Visible = false;
                labelCreateInfo.Text = "Select size, then push \"Create Table\"";

                RightPanel(activate);
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Wrong input", "Input", MessageBoxButtons.OK);
            }
        }

        private bool dataGridAutomataVerificate()
        {
            // Проверка, нет ли ячеек со значением большим максимального
            for (int i = 0, n = Convert.ToInt32(numericUpDownCreateStates.Value); i < n; ++i)
                for (int j = 1, m = Convert.ToInt32(numericUpDownCreateAlphabet.Value); j <= m; ++j)
                    if (Convert.ToInt32(dataGridViewAutomata[j, i].Value.ToString()) >= n) return false;
            return true;
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
                    labelCheckResult.Text = "Word is NOT the reset";
                }
            }
            catch
            {
                DialogResult dialog = MessageBox.Show("Invalid input word", "Reset word", MessageBoxButtons.OK);
            }
        }

        private void buttonIcdfaGenerate_Click(object sender, EventArgs e)
        {
            buttonIcdfaCancel.Visible = true;

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

            if (textBoxCheck.Text == "meow")
                CompleteSoundPlayer.Play();
            else
                SystemSounds.Asterisk.Play();

            updaterIcdfa.Enabled = false;//Отключаем таймер который подтягивает изменения в CurrentIcdfaLogic
            UpdateIcdfaOutput();//Обновляем вывод  
            
            //Восстанавливаем интерфейс
            buttonIcdfaGenerate.Visible = true;
            tabControlMain.Enabled = true;
            progressBar1.Visible = false;
            progressBar1.Value = 0;
            buttonIcdfaCancel.Visible = false;

            if (!CurrentIcdfaLogic.CancellationTokenSource.IsCancellationRequested)
            {
                // Запись в файл
                SaveIcdfaPart();
                if (checkBoxShutdown.Checked) shutdown.halt(false, false);
            }

            CurrentIcdfaLogic = null;//Сбрасываем CurrentIcdfaLogic
        }

        private void SaveIcdfaPart()
        {
            var icdfa = CurrentIcdfaLogic;
            if (icdfa == null) throw new NullReferenceException(nameof(CurrentIcdfaLogic));

            if (!Directory.Exists("icdfa parts"))
                Directory.CreateDirectory("icdfa parts");

            if(!Directory.Exists($"icdfa parts/Prtcl{icdfa.N}x{icdfa.K}"))
                Directory.CreateDirectory($"icdfa parts/Prtcl{icdfa.N}x{icdfa.K}");

            var result = CurrentIcdfaLogic.GetTotalLenghts();
            //TODO "Remove Prtcl{icdfa.N}x{icdfa.K}"
            var stream = new StreamWriter(new FileStream($"icdfa parts/Prtcl{icdfa.N}x{icdfa.K}/Prtcl{icdfa.N}x{icdfa.K}_pts{icdfa.StartPart}-{icdfa.StartPart + icdfa.CountParts - 1}of{icdfa.TotalParts}.txt", FileMode.Create));
            foreach (var record in result)
                stream.WriteLine(record);
            stream.Close();
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
            if (chartICDFA.Series[0].Points.Count >= 25)
                chartICDFA.Series[0].Points[chartICDFA.Series[0].Points.Count - 2].LabelBackColor = Color.LimeGreen;
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

        /// <summary>
        /// Собирает все файлы протоколов воедино
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCompileResults_Click(object sender, EventArgs e)
        {
            int states = Convert.ToInt32(numericUpDownN.Value);
            int alphabet = Convert.ToInt32(numericUpDownK.Value);
            int parts = Convert.ToInt32(numericUpDownTotalParts.Value);

            var lengths = new ulong[(states - 1) * (states - 1) + 1];

            int currentPart = 1;

            try
            {
                var dir = new DirectoryInfo($@"icdfa parts/Prtcl{states}x{alphabet}");

                if (!dir.Exists)
                    throw new DirectoryNotFoundException(); // Если директория не существует

                while (currentPart < parts)
                {
                    var file = dir.GetFiles($"Prtcl{states}x{alphabet}_pts{currentPart}-*of{parts}.txt");

                    if (file.Length == 0)
                        throw new FileNotFoundException(); // Если файлы не удалось получить по маске

                    StreamReader stream = new StreamReader(file[0].FullName);
                    for (int i = 0; i < lengths.Length; ++i)
                        lengths[i] += Convert.ToUInt64(stream.ReadLine());
                    currentPart = Convert.ToInt32(getBetween(file[0].Name, "-", "of")) + 1;
                }

                StreamWriter writer = new StreamWriter($"icdfa parts/Prtcl{states}x{alphabet}/Prtcl{states}x{alphabet}.txt");
                for (int i = 0; i < lengths.Length; ++i)
                    writer.WriteLine(lengths[i]);

                writer.Close();
            }
            catch (FileNotFoundException)
            {
                DialogResult dialogResult = MessageBox.Show($"Missing part {currentPart}", "Error", MessageBoxButtons.OK);
            }
            catch (DirectoryNotFoundException)
            {
                DialogResult dialogResult = MessageBox.Show($"Folder \"Prtcl{states}x{alphabet}\" not exists", "Error", MessageBoxButtons.OK);
            }
            catch
            {
                DialogResult dialogResult = MessageBox.Show($"Something went wrong!", "Error", MessageBoxButtons.OK);
            }
        }

        public static string getBetween(string strSource, string strStart, string strEnd)
        {
            int Start, End;
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }
            else
            {
                return "";
            }
        }

        private void buttonDrawResults_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                if (open.ShowDialog() == DialogResult.OK)
                {
                    StreamReader stream = new StreamReader(open.OpenFile());
                    var rawData = stream.ReadToEnd();
                    var data = rawData.Split('\n');

                    var lengths = new ulong[data.Count() - 1];

                    for (int i = 0; i < lengths.Length; ++i)
                        lengths[i] = Convert.ToUInt64(data[i]);

                    chartICDFA.Visible = true;

                    chartICDFA.Series[0].Points.Clear();

                    for (int i = 1; i < lengths.Length; ++i)
                        chartICDFA.Series[0].Points.Add(lengths[i], i);

                    if (chartICDFA.Series[0].Points.Count >= 25)
                        chartICDFA.Series[0].Points[chartICDFA.Series[0].Points.Count - 2].LabelBackColor = Color.LimeGreen;
                }
            }
            catch
            {
                DialogResult dialogResult = MessageBox.Show("Something went wrong!", "Error", MessageBoxButtons.OK);
            }
        }

        private void buttonCompileResults_MouseMove(object sender, MouseEventArgs e)
        {
            buttonCompileResults.BackColor = Color.Orange;
            numericUpDownN.BackColor = Color.Orange;
            numericUpDownK.BackColor = Color.Orange;
            numericUpDownTotalParts.BackColor = Color.Orange;
        }

        private void buttonCompileResults_MouseLeave(object sender, EventArgs e)
        {
            var tempColor = numericUpDownCalculateFrom.BackColor;
            
            numericUpDownN.BackColor = tempColor;
            numericUpDownK.BackColor = tempColor;
            numericUpDownTotalParts.BackColor = tempColor;

            tempColor = buttonGenerate.BackColor;

            buttonCompileResults.BackColor = tempColor;
        }

        private void buttonIcdfaCancel_Click(object sender, EventArgs e)
        {
            CurrentIcdfaLogic?.Cancel();
        }   
    }
}
