﻿namespace automata_sharp
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageGenerate = new System.Windows.Forms.TabPage();
            this.panelGenerate = new System.Windows.Forms.Panel();
            this.labelGeneratorInfo = new System.Windows.Forms.Label();
            this.labelGenerateInfo1 = new System.Windows.Forms.Label();
            this.numericUpDownAlphabet = new System.Windows.Forms.NumericUpDown();
            this.labelGenerateInfo2 = new System.Windows.Forms.Label();
            this.numericUpDownStates = new System.Windows.Forms.NumericUpDown();
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.tabPageConstructor = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelCreateInfo = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDownCreateAlphabet = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.numericUpDownCreateStates = new System.Windows.Forms.NumericUpDown();
            this.buttonCreateTable = new System.Windows.Forms.Button();
            this.tabPageFile = new System.Windows.Forms.TabPage();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelOpenSaveText = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.tabIcdfa = new System.Windows.Forms.TabPage();
            this.buttonDrawResults = new System.Windows.Forms.Button();
            this.buttonCompileResults = new System.Windows.Forms.Button();
            this.buttonIcdfaCancel = new System.Windows.Forms.Button();
            this.checkBoxShutdown = new System.Windows.Forms.CheckBox();
            this.label20 = new System.Windows.Forms.Label();
            this.numericUpDownCalculateTo = new System.Windows.Forms.NumericUpDown();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.numericUpDownK = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownN = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownTotalParts = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownCalculateFrom = new System.Windows.Forms.NumericUpDown();
            this.buttonIcdfaGenerate = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.tabPageAbout = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.buttonCreateConfirm = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelStoped = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonImpact = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxStates = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxWord = new System.Windows.Forms.TextBox();
            this.groupBoxResetWord = new System.Windows.Forms.GroupBox();
            this.buttonCancelShortResetWord = new System.Windows.Forms.Button();
            this.buttonCancelResetWord = new System.Windows.Forms.Button();
            this.buttonShortResetWordCalculate = new System.Windows.Forms.Button();
            this.buttonResetWordCalculate = new System.Windows.Forms.Button();
            this.labelShortestResetWord = new System.Windows.Forms.Label();
            this.labelQuickResetWord = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelGeneratorResetWord = new System.Windows.Forms.Label();
            this.dataGridViewAutomata = new System.Windows.Forms.DataGridView();
            this.groupBoxWordCheck = new System.Windows.Forms.GroupBox();
            this.labelCheckResult = new System.Windows.Forms.Label();
            this.buttonCheck = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.textBoxCheck = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.richTextBoxIcdfaOutput = new System.Windows.Forms.RichTextBox();
            this.updaterIcdfa = new System.Windows.Forms.Timer(this.components);
            this.chartICDFA = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabControlMain.SuspendLayout();
            this.tabPageGenerate.SuspendLayout();
            this.panelGenerate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAlphabet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStates)).BeginInit();
            this.tabPageConstructor.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCreateAlphabet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCreateStates)).BeginInit();
            this.tabPageFile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabIcdfa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCalculateTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTotalParts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCalculateFrom)).BeginInit();
            this.tabPageAbout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBoxResetWord.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAutomata)).BeginInit();
            this.groupBoxWordCheck.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartICDFA)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            resources.ApplyResources(this.tabControlMain, "tabControlMain");
            this.tabControlMain.Controls.Add(this.tabPageGenerate);
            this.tabControlMain.Controls.Add(this.tabPageConstructor);
            this.tabControlMain.Controls.Add(this.tabPageFile);
            this.tabControlMain.Controls.Add(this.tabIcdfa);
            this.tabControlMain.Controls.Add(this.tabPageAbout);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.SelectedIndexChanged += new System.EventHandler(this.tabControlMain_SelectedIndexChanged);
            // 
            // tabPageGenerate
            // 
            this.tabPageGenerate.Controls.Add(this.panelGenerate);
            resources.ApplyResources(this.tabPageGenerate, "tabPageGenerate");
            this.tabPageGenerate.Name = "tabPageGenerate";
            this.tabPageGenerate.UseVisualStyleBackColor = true;
            // 
            // panelGenerate
            // 
            resources.ApplyResources(this.panelGenerate, "panelGenerate");
            this.panelGenerate.Controls.Add(this.labelGeneratorInfo);
            this.panelGenerate.Controls.Add(this.labelGenerateInfo1);
            this.panelGenerate.Controls.Add(this.numericUpDownAlphabet);
            this.panelGenerate.Controls.Add(this.labelGenerateInfo2);
            this.panelGenerate.Controls.Add(this.numericUpDownStates);
            this.panelGenerate.Controls.Add(this.buttonGenerate);
            this.panelGenerate.Name = "panelGenerate";
            // 
            // labelGeneratorInfo
            // 
            resources.ApplyResources(this.labelGeneratorInfo, "labelGeneratorInfo");
            this.labelGeneratorInfo.Name = "labelGeneratorInfo";
            // 
            // labelGenerateInfo1
            // 
            resources.ApplyResources(this.labelGenerateInfo1, "labelGenerateInfo1");
            this.labelGenerateInfo1.Name = "labelGenerateInfo1";
            // 
            // numericUpDownAlphabet
            // 
            resources.ApplyResources(this.numericUpDownAlphabet, "numericUpDownAlphabet");
            this.numericUpDownAlphabet.Maximum = new decimal(new int[] {
            26,
            0,
            0,
            0});
            this.numericUpDownAlphabet.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownAlphabet.Name = "numericUpDownAlphabet";
            this.numericUpDownAlphabet.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // labelGenerateInfo2
            // 
            resources.ApplyResources(this.labelGenerateInfo2, "labelGenerateInfo2");
            this.labelGenerateInfo2.Name = "labelGenerateInfo2";
            // 
            // numericUpDownStates
            // 
            resources.ApplyResources(this.numericUpDownStates, "numericUpDownStates");
            this.numericUpDownStates.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownStates.Name = "numericUpDownStates";
            this.numericUpDownStates.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // buttonGenerate
            // 
            resources.ApplyResources(this.buttonGenerate, "buttonGenerate");
            this.buttonGenerate.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.UseVisualStyleBackColor = false;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
            // 
            // tabPageConstructor
            // 
            this.tabPageConstructor.Controls.Add(this.panel2);
            resources.ApplyResources(this.tabPageConstructor, "tabPageConstructor");
            this.tabPageConstructor.Name = "tabPageConstructor";
            this.tabPageConstructor.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Controls.Add(this.labelCreateInfo);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.numericUpDownCreateAlphabet);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.numericUpDownCreateStates);
            this.panel2.Controls.Add(this.buttonCreateTable);
            this.panel2.Name = "panel2";
            // 
            // labelCreateInfo
            // 
            resources.ApplyResources(this.labelCreateInfo, "labelCreateInfo");
            this.labelCreateInfo.Name = "labelCreateInfo";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // numericUpDownCreateAlphabet
            // 
            resources.ApplyResources(this.numericUpDownCreateAlphabet, "numericUpDownCreateAlphabet");
            this.numericUpDownCreateAlphabet.Maximum = new decimal(new int[] {
            26,
            0,
            0,
            0});
            this.numericUpDownCreateAlphabet.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownCreateAlphabet.Name = "numericUpDownCreateAlphabet";
            this.numericUpDownCreateAlphabet.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // numericUpDownCreateStates
            // 
            resources.ApplyResources(this.numericUpDownCreateStates, "numericUpDownCreateStates");
            this.numericUpDownCreateStates.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownCreateStates.Name = "numericUpDownCreateStates";
            this.numericUpDownCreateStates.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // buttonCreateTable
            // 
            resources.ApplyResources(this.buttonCreateTable, "buttonCreateTable");
            this.buttonCreateTable.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonCreateTable.Name = "buttonCreateTable";
            this.buttonCreateTable.UseVisualStyleBackColor = false;
            this.buttonCreateTable.Click += new System.EventHandler(this.buttonCreateTable_Click);
            // 
            // tabPageFile
            // 
            this.tabPageFile.Controls.Add(this.pictureBox2);
            this.tabPageFile.Controls.Add(this.pictureBox1);
            this.tabPageFile.Controls.Add(this.labelOpenSaveText);
            this.tabPageFile.Controls.Add(this.buttonSave);
            this.tabPageFile.Controls.Add(this.buttonOpen);
            resources.ApplyResources(this.tabPageFile, "tabPageFile");
            this.tabPageFile.Name = "tabPageFile";
            this.tabPageFile.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::automata_sharp.Properties.Resources.save;
            resources.ApplyResources(this.pictureBox2, "pictureBox2");
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::automata_sharp.Properties.Resources.open;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // labelOpenSaveText
            // 
            resources.ApplyResources(this.labelOpenSaveText, "labelOpenSaveText");
            this.labelOpenSaveText.Name = "labelOpenSaveText";
            // 
            // buttonSave
            // 
            resources.ApplyResources(this.buttonSave, "buttonSave");
            this.buttonSave.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonOpen
            // 
            resources.ApplyResources(this.buttonOpen, "buttonOpen");
            this.buttonOpen.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.UseVisualStyleBackColor = false;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // tabIcdfa
            // 
            this.tabIcdfa.Controls.Add(this.buttonDrawResults);
            this.tabIcdfa.Controls.Add(this.buttonCompileResults);
            this.tabIcdfa.Controls.Add(this.buttonIcdfaCancel);
            this.tabIcdfa.Controls.Add(this.checkBoxShutdown);
            this.tabIcdfa.Controls.Add(this.label20);
            this.tabIcdfa.Controls.Add(this.numericUpDownCalculateTo);
            this.tabIcdfa.Controls.Add(this.label19);
            this.tabIcdfa.Controls.Add(this.label18);
            this.tabIcdfa.Controls.Add(this.label15);
            this.tabIcdfa.Controls.Add(this.label16);
            this.tabIcdfa.Controls.Add(this.label17);
            this.tabIcdfa.Controls.Add(this.numericUpDownK);
            this.tabIcdfa.Controls.Add(this.numericUpDownN);
            this.tabIcdfa.Controls.Add(this.numericUpDownTotalParts);
            this.tabIcdfa.Controls.Add(this.numericUpDownCalculateFrom);
            this.tabIcdfa.Controls.Add(this.buttonIcdfaGenerate);
            this.tabIcdfa.Controls.Add(this.progressBar1);
            resources.ApplyResources(this.tabIcdfa, "tabIcdfa");
            this.tabIcdfa.Name = "tabIcdfa";
            this.tabIcdfa.UseVisualStyleBackColor = true;
            // 
            // buttonDrawResults
            // 
            this.buttonDrawResults.BackColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(this.buttonDrawResults, "buttonDrawResults");
            this.buttonDrawResults.Name = "buttonDrawResults";
            this.buttonDrawResults.UseVisualStyleBackColor = false;
            this.buttonDrawResults.Click += new System.EventHandler(this.buttonDrawResults_Click);
            // 
            // buttonCompileResults
            // 
            this.buttonCompileResults.BackColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(this.buttonCompileResults, "buttonCompileResults");
            this.buttonCompileResults.Name = "buttonCompileResults";
            this.buttonCompileResults.UseVisualStyleBackColor = false;
            this.buttonCompileResults.Click += new System.EventHandler(this.buttonCompileResults_Click);
            this.buttonCompileResults.MouseLeave += new System.EventHandler(this.buttonCompileResults_MouseLeave);
            this.buttonCompileResults.MouseMove += new System.Windows.Forms.MouseEventHandler(this.buttonCompileResults_MouseMove);
            // 
            // buttonIcdfaCancel
            // 
            resources.ApplyResources(this.buttonIcdfaCancel, "buttonIcdfaCancel");
            this.buttonIcdfaCancel.BackColor = System.Drawing.Color.LightCoral;
            this.buttonIcdfaCancel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonIcdfaCancel.Name = "buttonIcdfaCancel";
            this.buttonIcdfaCancel.UseVisualStyleBackColor = false;
            this.buttonIcdfaCancel.Click += new System.EventHandler(this.buttonIcdfaCancel_Click);
            // 
            // checkBoxShutdown
            // 
            resources.ApplyResources(this.checkBoxShutdown, "checkBoxShutdown");
            this.checkBoxShutdown.Name = "checkBoxShutdown";
            this.checkBoxShutdown.UseVisualStyleBackColor = true;
            this.checkBoxShutdown.CheckedChanged += new System.EventHandler(this.checkBoxShutdown_CheckedChanged);
            // 
            // label20
            // 
            resources.ApplyResources(this.label20, "label20");
            this.label20.Name = "label20";
            // 
            // numericUpDownCalculateTo
            // 
            resources.ApplyResources(this.numericUpDownCalculateTo, "numericUpDownCalculateTo");
            this.numericUpDownCalculateTo.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownCalculateTo.Name = "numericUpDownCalculateTo";
            this.numericUpDownCalculateTo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label19
            // 
            resources.ApplyResources(this.label19, "label19");
            this.label19.Name = "label19";
            // 
            // label18
            // 
            resources.ApplyResources(this.label18, "label18");
            this.label18.Name = "label18";
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.Name = "label16";
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.Name = "label17";
            // 
            // numericUpDownK
            // 
            resources.ApplyResources(this.numericUpDownK, "numericUpDownK");
            this.numericUpDownK.Maximum = new decimal(new int[] {
            26,
            0,
            0,
            0});
            this.numericUpDownK.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownK.Name = "numericUpDownK";
            this.numericUpDownK.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // numericUpDownN
            // 
            resources.ApplyResources(this.numericUpDownN, "numericUpDownN");
            this.numericUpDownN.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.numericUpDownN.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownN.Name = "numericUpDownN";
            this.numericUpDownN.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // numericUpDownTotalParts
            // 
            resources.ApplyResources(this.numericUpDownTotalParts, "numericUpDownTotalParts");
            this.numericUpDownTotalParts.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownTotalParts.Name = "numericUpDownTotalParts";
            this.numericUpDownTotalParts.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDownCalculateFrom
            // 
            resources.ApplyResources(this.numericUpDownCalculateFrom, "numericUpDownCalculateFrom");
            this.numericUpDownCalculateFrom.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownCalculateFrom.Name = "numericUpDownCalculateFrom";
            this.numericUpDownCalculateFrom.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // buttonIcdfaGenerate
            // 
            resources.ApplyResources(this.buttonIcdfaGenerate, "buttonIcdfaGenerate");
            this.buttonIcdfaGenerate.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonIcdfaGenerate.Name = "buttonIcdfaGenerate";
            this.buttonIcdfaGenerate.UseVisualStyleBackColor = false;
            this.buttonIcdfaGenerate.Click += new System.EventHandler(this.buttonIcdfaGenerate_Click);
            // 
            // progressBar1
            // 
            resources.ApplyResources(this.progressBar1, "progressBar1");
            this.progressBar1.Maximum = 1000;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Step = 1;
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            // 
            // tabPageAbout
            // 
            this.tabPageAbout.Controls.Add(this.label9);
            this.tabPageAbout.Controls.Add(this.label13);
            this.tabPageAbout.Controls.Add(this.label11);
            this.tabPageAbout.Controls.Add(this.label10);
            this.tabPageAbout.Controls.Add(this.label6);
            this.tabPageAbout.Controls.Add(this.pictureBox3);
            resources.ApplyResources(this.tabPageAbout, "tabPageAbout");
            this.tabPageAbout.Name = "tabPageAbout";
            this.tabPageAbout.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::automata_sharp.Properties.Resources.Automaton;
            resources.ApplyResources(this.pictureBox3, "pictureBox3");
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.TabStop = false;
            // 
            // buttonCreateConfirm
            // 
            resources.ApplyResources(this.buttonCreateConfirm, "buttonCreateConfirm");
            this.buttonCreateConfirm.BackColor = System.Drawing.Color.PaleTurquoise;
            this.buttonCreateConfirm.Name = "buttonCreateConfirm";
            this.buttonCreateConfirm.UseVisualStyleBackColor = false;
            this.buttonCreateConfirm.Click += new System.EventHandler(this.buttonCreateConfirm_Click);
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.labelStoped);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.buttonImpact);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.comboBoxStates);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBoxWord);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // labelStoped
            // 
            resources.ApplyResources(this.labelStoped, "labelStoped");
            this.labelStoped.ForeColor = System.Drawing.Color.Red;
            this.labelStoped.Name = "labelStoped";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // buttonImpact
            // 
            this.buttonImpact.BackColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(this.buttonImpact, "buttonImpact");
            this.buttonImpact.Name = "buttonImpact";
            this.buttonImpact.UseVisualStyleBackColor = false;
            this.buttonImpact.Click += new System.EventHandler(this.buttonGeneratorImpact_Click);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // comboBoxStates
            // 
            this.comboBoxStates.FormattingEnabled = true;
            resources.ApplyResources(this.comboBoxStates, "comboBoxStates");
            this.comboBoxStates.Name = "comboBoxStates";
            this.comboBoxStates.SelectedIndexChanged += new System.EventHandler(this.comboBoxStates_SelectedIndexChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // textBoxWord
            // 
            resources.ApplyResources(this.textBoxWord, "textBoxWord");
            this.textBoxWord.Name = "textBoxWord";
            // 
            // groupBoxResetWord
            // 
            resources.ApplyResources(this.groupBoxResetWord, "groupBoxResetWord");
            this.groupBoxResetWord.Controls.Add(this.buttonCancelShortResetWord);
            this.groupBoxResetWord.Controls.Add(this.buttonCancelResetWord);
            this.groupBoxResetWord.Controls.Add(this.buttonShortResetWordCalculate);
            this.groupBoxResetWord.Controls.Add(this.buttonResetWordCalculate);
            this.groupBoxResetWord.Controls.Add(this.labelShortestResetWord);
            this.groupBoxResetWord.Controls.Add(this.labelQuickResetWord);
            this.groupBoxResetWord.Controls.Add(this.label1);
            this.groupBoxResetWord.Controls.Add(this.labelGeneratorResetWord);
            this.groupBoxResetWord.Name = "groupBoxResetWord";
            this.groupBoxResetWord.TabStop = false;
            // 
            // buttonCancelShortResetWord
            // 
            this.buttonCancelShortResetWord.BackColor = System.Drawing.Color.LightCoral;
            resources.ApplyResources(this.buttonCancelShortResetWord, "buttonCancelShortResetWord");
            this.buttonCancelShortResetWord.Name = "buttonCancelShortResetWord";
            this.buttonCancelShortResetWord.UseVisualStyleBackColor = false;
            this.buttonCancelShortResetWord.Click += new System.EventHandler(this.buttonCancelShortResetWord_Click);
            // 
            // buttonCancelResetWord
            // 
            this.buttonCancelResetWord.BackColor = System.Drawing.Color.LightCoral;
            resources.ApplyResources(this.buttonCancelResetWord, "buttonCancelResetWord");
            this.buttonCancelResetWord.Name = "buttonCancelResetWord";
            this.buttonCancelResetWord.UseVisualStyleBackColor = false;
            this.buttonCancelResetWord.Click += new System.EventHandler(this.buttonCancelResetWord_Click);
            // 
            // buttonShortResetWordCalculate
            // 
            this.buttonShortResetWordCalculate.BackColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(this.buttonShortResetWordCalculate, "buttonShortResetWordCalculate");
            this.buttonShortResetWordCalculate.Name = "buttonShortResetWordCalculate";
            this.buttonShortResetWordCalculate.UseVisualStyleBackColor = false;
            this.buttonShortResetWordCalculate.Click += new System.EventHandler(this.buttonShortResetWordCalculate_Click);
            // 
            // buttonResetWordCalculate
            // 
            this.buttonResetWordCalculate.BackColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(this.buttonResetWordCalculate, "buttonResetWordCalculate");
            this.buttonResetWordCalculate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonResetWordCalculate.Name = "buttonResetWordCalculate";
            this.buttonResetWordCalculate.UseVisualStyleBackColor = false;
            this.buttonResetWordCalculate.Click += new System.EventHandler(this.buttonResetWordCalculate_Click);
            // 
            // labelShortestResetWord
            // 
            resources.ApplyResources(this.labelShortestResetWord, "labelShortestResetWord");
            this.labelShortestResetWord.ForeColor = System.Drawing.Color.Red;
            this.labelShortestResetWord.Name = "labelShortestResetWord";
            this.labelShortestResetWord.DoubleClick += new System.EventHandler(this.labelShortestResetWord_DoubleClick);
            // 
            // labelQuickResetWord
            // 
            resources.ApplyResources(this.labelQuickResetWord, "labelQuickResetWord");
            this.labelQuickResetWord.ForeColor = System.Drawing.Color.Red;
            this.labelQuickResetWord.Name = "labelQuickResetWord";
            this.labelQuickResetWord.DoubleClick += new System.EventHandler(this.labelQuickResetWord_DoubleClick);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // labelGeneratorResetWord
            // 
            resources.ApplyResources(this.labelGeneratorResetWord, "labelGeneratorResetWord");
            this.labelGeneratorResetWord.Name = "labelGeneratorResetWord";
            // 
            // dataGridViewAutomata
            // 
            this.dataGridViewAutomata.AllowUserToAddRows = false;
            this.dataGridViewAutomata.AllowUserToDeleteRows = false;
            resources.ApplyResources(this.dataGridViewAutomata, "dataGridViewAutomata");
            this.dataGridViewAutomata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAutomata.Name = "dataGridViewAutomata";
            this.dataGridViewAutomata.ReadOnly = true;
            // 
            // groupBoxWordCheck
            // 
            resources.ApplyResources(this.groupBoxWordCheck, "groupBoxWordCheck");
            this.groupBoxWordCheck.Controls.Add(this.labelCheckResult);
            this.groupBoxWordCheck.Controls.Add(this.buttonCreateConfirm);
            this.groupBoxWordCheck.Controls.Add(this.buttonCheck);
            this.groupBoxWordCheck.Controls.Add(this.label14);
            this.groupBoxWordCheck.Controls.Add(this.textBoxCheck);
            this.groupBoxWordCheck.Controls.Add(this.label12);
            this.groupBoxWordCheck.Name = "groupBoxWordCheck";
            this.groupBoxWordCheck.TabStop = false;
            // 
            // labelCheckResult
            // 
            resources.ApplyResources(this.labelCheckResult, "labelCheckResult");
            this.labelCheckResult.Name = "labelCheckResult";
            // 
            // buttonCheck
            // 
            this.buttonCheck.BackColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(this.buttonCheck, "buttonCheck");
            this.buttonCheck.Name = "buttonCheck";
            this.buttonCheck.UseVisualStyleBackColor = false;
            this.buttonCheck.Click += new System.EventHandler(this.buttonCheck_Click);
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // textBoxCheck
            // 
            resources.ApplyResources(this.textBoxCheck, "textBoxCheck");
            this.textBoxCheck.Name = "textBoxCheck";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // richTextBoxIcdfaOutput
            // 
            resources.ApplyResources(this.richTextBoxIcdfaOutput, "richTextBoxIcdfaOutput");
            this.richTextBoxIcdfaOutput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxIcdfaOutput.Name = "richTextBoxIcdfaOutput";
            this.richTextBoxIcdfaOutput.ReadOnly = true;
            // 
            // updaterIcdfa
            // 
            this.updaterIcdfa.Tick += new System.EventHandler(this.updaterIcdfa_Tick);
            // 
            // chartICDFA
            // 
            resources.ApplyResources(this.chartICDFA, "chartICDFA");
            this.chartICDFA.BackColor = System.Drawing.SystemColors.Control;
            chartArea1.AlignmentOrientation = System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal;
            chartArea1.Area3DStyle.Enable3D = true;
            chartArea1.Area3DStyle.WallWidth = 0;
            chartArea1.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.Name = "ChartArea1";
            chartArea1.ShadowOffset = 10;
            this.chartICDFA.ChartAreas.Add(chartArea1);
            this.chartICDFA.IsSoftShadows = false;
            this.chartICDFA.Name = "chartICDFA";
            this.chartICDFA.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.EarthTones;
            series1.ChartArea = "ChartArea1";
            series1.CustomProperties = "CollectedColor=White";
            series1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            series1.IsValueShownAsLabel = true;
            series1.IsVisibleInLegend = false;
            series1.IsXValueIndexed = true;
            series1.LabelBackColor = System.Drawing.SystemColors.Control;
            series1.LabelBorderColor = System.Drawing.Color.Black;
            series1.LabelFormat = "{0}";
            series1.Legend = "Legend1";
            series1.MarkerBorderColor = System.Drawing.Color.White;
            series1.MarkerColor = System.Drawing.Color.Silver;
            series1.MarkerStep = 2;
            series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Star10;
            series1.Name = "Series3";
            series1.SmartLabelStyle.AllowOutsidePlotArea = System.Windows.Forms.DataVisualization.Charting.LabelOutsidePlotAreaStyle.Yes;
            series1.SmartLabelStyle.CalloutBackColor = System.Drawing.Color.Black;
            series1.SmartLabelStyle.CalloutLineAnchorCapStyle = System.Windows.Forms.DataVisualization.Charting.LineAnchorCapStyle.Diamond;
            series1.SmartLabelStyle.CalloutLineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDot;
            series1.SmartLabelStyle.CalloutLineWidth = 2;
            series1.SmartLabelStyle.CalloutStyle = System.Windows.Forms.DataVisualization.Charting.LabelCalloutStyle.None;
            series1.SmartLabelStyle.IsMarkerOverlappingAllowed = true;
            series1.SmartLabelStyle.MinMovingDistance = 2D;
            this.chartICDFA.Series.Add(series1);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chartICDFA);
            this.Controls.Add(this.richTextBoxIcdfaOutput);
            this.Controls.Add(this.groupBoxWordCheck);
            this.Controls.Add(this.dataGridViewAutomata);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.groupBoxResetWord);
            this.Name = "MainForm";
            this.tabControlMain.ResumeLayout(false);
            this.tabPageGenerate.ResumeLayout(false);
            this.panelGenerate.ResumeLayout(false);
            this.panelGenerate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAlphabet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStates)).EndInit();
            this.tabPageConstructor.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCreateAlphabet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCreateStates)).EndInit();
            this.tabPageFile.ResumeLayout(false);
            this.tabPageFile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabIcdfa.ResumeLayout(false);
            this.tabIcdfa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCalculateTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTotalParts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCalculateFrom)).EndInit();
            this.tabPageAbout.ResumeLayout(false);
            this.tabPageAbout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBoxResetWord.ResumeLayout(false);
            this.groupBoxResetWord.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAutomata)).EndInit();
            this.groupBoxWordCheck.ResumeLayout(false);
            this.groupBoxWordCheck.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartICDFA)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageGenerate;
        private System.Windows.Forms.TabPage tabPageFile;
        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.Label labelGenerateInfo2;
        private System.Windows.Forms.Label labelGenerateInfo1;
        private System.Windows.Forms.Label labelGeneratorInfo;
        private System.Windows.Forms.DataGridView dataGridViewAutomata;
        private System.Windows.Forms.NumericUpDown numericUpDownAlphabet;
        private System.Windows.Forms.NumericUpDown numericUpDownStates;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBoxResetWord;
        private System.Windows.Forms.Label labelShortestResetWord;
        private System.Windows.Forms.Label labelQuickResetWord;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelGeneratorResetWord;
        private System.Windows.Forms.Label labelStoped;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonImpact;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxStates;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxWord;
        private System.Windows.Forms.Panel panelGenerate;
        private System.Windows.Forms.Button buttonShortResetWordCalculate;
        private System.Windows.Forms.Button buttonResetWordCalculate;
        private System.Windows.Forms.TabPage tabPageConstructor;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelCreateInfo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDownCreateAlphabet;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericUpDownCreateStates;
        private System.Windows.Forms.Button buttonCreateTable;
        private System.Windows.Forms.Button buttonCreateConfirm;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label labelOpenSaveText;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;

        private System.Windows.Forms.Button buttonCancelResetWord;
        private System.Windows.Forms.Button buttonCancelShortResetWord;

        private System.Windows.Forms.TabPage tabPageAbout;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBoxWordCheck;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label labelCheckResult;
        private System.Windows.Forms.Button buttonCheck;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBoxCheck;
        private System.Windows.Forms.TabPage tabIcdfa;
        private System.Windows.Forms.Button buttonIcdfaGenerate;
        private System.Windows.Forms.NumericUpDown numericUpDownTotalParts;
        private System.Windows.Forms.NumericUpDown numericUpDownCalculateFrom;
        private System.Windows.Forms.NumericUpDown numericUpDownK;
        private System.Windows.Forms.NumericUpDown numericUpDownN;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.RichTextBox richTextBoxIcdfaOutput;
        private System.Windows.Forms.Timer updaterIcdfa;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.NumericUpDown numericUpDownCalculateTo;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.CheckBox checkBoxShutdown;
        private System.Windows.Forms.Button buttonIcdfaCancel;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartICDFA;
        private System.Windows.Forms.Button buttonDrawResults;
        private System.Windows.Forms.Button buttonCompileResults;
    }
}

