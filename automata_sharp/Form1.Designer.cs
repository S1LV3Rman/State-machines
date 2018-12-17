namespace automata_sharp
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageGenerate = new System.Windows.Forms.TabPage();
            this.panelGenerate = new System.Windows.Forms.Panel();
            this.labelGeneratorInfo = new System.Windows.Forms.Label();
            this.labelGenerateInfo1 = new System.Windows.Forms.Label();
            this.numericUpDownAlphabet = new System.Windows.Forms.NumericUpDown();
            this.labelGenerateInfo2 = new System.Windows.Forms.Label();
            this.numericUpDownStates = new System.Windows.Forms.NumericUpDown();
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.tabPageOpen = new System.Windows.Forms.TabPage();
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
            this.buttonShortResetWordCalculate = new System.Windows.Forms.Button();
            this.buttonResetWordCalculate = new System.Windows.Forms.Button();
            this.labelShortestResetWord = new System.Windows.Forms.Label();
            this.labelQuickResetWord = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelGeneratorResetWord = new System.Windows.Forms.Label();
            this.dataGridViewAutomata = new System.Windows.Forms.DataGridView();
            this.tabPageCreate = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDownCreateAlphabet = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.numericUpDownCreateStates = new System.Windows.Forms.NumericUpDown();
            this.buttonCreateTable = new System.Windows.Forms.Button();
            this.buttonCreateConfirm = new System.Windows.Forms.Button();
            this.tabControlMain.SuspendLayout();
            this.tabPageGenerate.SuspendLayout();
            this.panelGenerate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAlphabet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStates)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBoxResetWord.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAutomata)).BeginInit();
            this.tabPageCreate.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCreateAlphabet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCreateStates)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageGenerate);
            this.tabControlMain.Controls.Add(this.tabPageCreate);
            this.tabControlMain.Controls.Add(this.tabPageOpen);
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Margin = new System.Windows.Forms.Padding(4);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(451, 210);
            this.tabControlMain.TabIndex = 0;
            // 
            // tabPageGenerate
            // 
            this.tabPageGenerate.Controls.Add(this.panelGenerate);
            this.tabPageGenerate.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabPageGenerate.Location = new System.Drawing.Point(4, 28);
            this.tabPageGenerate.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageGenerate.Name = "tabPageGenerate";
            this.tabPageGenerate.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageGenerate.Size = new System.Drawing.Size(443, 178);
            this.tabPageGenerate.TabIndex = 0;
            this.tabPageGenerate.Text = "Generator";
            this.tabPageGenerate.UseVisualStyleBackColor = true;
            // 
            // panelGenerate
            // 
            this.panelGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelGenerate.Controls.Add(this.labelGeneratorInfo);
            this.panelGenerate.Controls.Add(this.labelGenerateInfo1);
            this.panelGenerate.Controls.Add(this.numericUpDownAlphabet);
            this.panelGenerate.Controls.Add(this.labelGenerateInfo2);
            this.panelGenerate.Controls.Add(this.numericUpDownStates);
            this.panelGenerate.Controls.Add(this.buttonGenerate);
            this.panelGenerate.Location = new System.Drawing.Point(0, 0);
            this.panelGenerate.Name = "panelGenerate";
            this.panelGenerate.Size = new System.Drawing.Size(443, 178);
            this.panelGenerate.TabIndex = 11;
            // 
            // labelGeneratorInfo
            // 
            this.labelGeneratorInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelGeneratorInfo.AutoSize = true;
            this.labelGeneratorInfo.Location = new System.Drawing.Point(8, 7);
            this.labelGeneratorInfo.Name = "labelGeneratorInfo";
            this.labelGeneratorInfo.Size = new System.Drawing.Size(428, 19);
            this.labelGeneratorInfo.TabIndex = 0;
            this.labelGeneratorInfo.Text = "Type number of states and size of alpabet, then push \"Generate\"";
            // 
            // labelGenerateInfo1
            // 
            this.labelGenerateInfo1.AutoSize = true;
            this.labelGenerateInfo1.Location = new System.Drawing.Point(8, 37);
            this.labelGenerateInfo1.Name = "labelGenerateInfo1";
            this.labelGenerateInfo1.Size = new System.Drawing.Size(49, 19);
            this.labelGenerateInfo1.TabIndex = 2;
            this.labelGenerateInfo1.Text = "States";
            // 
            // numericUpDownAlphabet
            // 
            this.numericUpDownAlphabet.Location = new System.Drawing.Point(111, 77);
            this.numericUpDownAlphabet.Maximum = new decimal(new int[] {
            26,
            0,
            0,
            0});
            this.numericUpDownAlphabet.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownAlphabet.Name = "numericUpDownAlphabet";
            this.numericUpDownAlphabet.Size = new System.Drawing.Size(120, 27);
            this.numericUpDownAlphabet.TabIndex = 8;
            this.numericUpDownAlphabet.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelGenerateInfo2
            // 
            this.labelGenerateInfo2.AutoSize = true;
            this.labelGenerateInfo2.Location = new System.Drawing.Point(8, 79);
            this.labelGenerateInfo2.Name = "labelGenerateInfo2";
            this.labelGenerateInfo2.Size = new System.Drawing.Size(67, 19);
            this.labelGenerateInfo2.TabIndex = 3;
            this.labelGenerateInfo2.Text = "Alphabet";
            // 
            // numericUpDownStates
            // 
            this.numericUpDownStates.Location = new System.Drawing.Point(111, 35);
            this.numericUpDownStates.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownStates.Name = "numericUpDownStates";
            this.numericUpDownStates.Size = new System.Drawing.Size(120, 27);
            this.numericUpDownStates.TabIndex = 7;
            this.numericUpDownStates.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGenerate.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonGenerate.Location = new System.Drawing.Point(7, 117);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(433, 27);
            this.buttonGenerate.TabIndex = 5;
            this.buttonGenerate.Text = "Generate";
            this.buttonGenerate.UseVisualStyleBackColor = false;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
            // 
            // tabPageOpen
            // 
            this.tabPageOpen.Location = new System.Drawing.Point(4, 28);
            this.tabPageOpen.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageOpen.Name = "tabPageOpen";
            this.tabPageOpen.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageOpen.Size = new System.Drawing.Size(443, 178);
            this.tabPageOpen.TabIndex = 1;
            this.tabPageOpen.Text = "Open";
            this.tabPageOpen.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.labelStoped);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.buttonImpact);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.comboBoxStates);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBoxWord);
            this.groupBox2.Location = new System.Drawing.Point(459, 217);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(327, 441);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Impact by own word";
            // 
            // labelStoped
            // 
            this.labelStoped.AutoSize = true;
            this.labelStoped.ForeColor = System.Drawing.Color.Red;
            this.labelStoped.Location = new System.Drawing.Point(177, 169);
            this.labelStoped.Name = "labelStoped";
            this.labelStoped.Size = new System.Drawing.Size(69, 19);
            this.labelStoped.TabIndex = 13;
            this.labelStoped.Text = "Unknown";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(160, 19);
            this.label5.TabIndex = 12;
            this.label5.Text = "Automata is stopped at";
            // 
            // buttonImpact
            // 
            this.buttonImpact.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonImpact.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonImpact.Location = new System.Drawing.Point(10, 139);
            this.buttonImpact.Name = "buttonImpact";
            this.buttonImpact.Size = new System.Drawing.Size(311, 27);
            this.buttonImpact.TabIndex = 11;
            this.buttonImpact.Text = "Impact";
            this.buttonImpact.UseVisualStyleBackColor = false;
            this.buttonImpact.Click += new System.EventHandler(this.buttonGeneratorImpact_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 19);
            this.label4.TabIndex = 4;
            this.label4.Text = "Word:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "State:";
            // 
            // comboBoxStates
            // 
            this.comboBoxStates.FormattingEnabled = true;
            this.comboBoxStates.Location = new System.Drawing.Point(63, 53);
            this.comboBoxStates.Name = "comboBoxStates";
            this.comboBoxStates.Size = new System.Drawing.Size(257, 27);
            this.comboBoxStates.TabIndex = 2;
            this.comboBoxStates.SelectedIndexChanged += new System.EventHandler(this.comboBoxStates_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(314, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Select start state, type word and push \"Impact\"";
            // 
            // textBoxWord
            // 
            this.textBoxWord.Location = new System.Drawing.Point(64, 93);
            this.textBoxWord.Name = "textBoxWord";
            this.textBoxWord.Size = new System.Drawing.Size(257, 27);
            this.textBoxWord.TabIndex = 0;
            // 
            // groupBoxResetWord
            // 
            this.groupBoxResetWord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxResetWord.Controls.Add(this.buttonShortResetWordCalculate);
            this.groupBoxResetWord.Controls.Add(this.buttonResetWordCalculate);
            this.groupBoxResetWord.Controls.Add(this.labelShortestResetWord);
            this.groupBoxResetWord.Controls.Add(this.labelQuickResetWord);
            this.groupBoxResetWord.Controls.Add(this.label1);
            this.groupBoxResetWord.Controls.Add(this.labelGeneratorResetWord);
            this.groupBoxResetWord.Location = new System.Drawing.Point(459, 28);
            this.groupBoxResetWord.Name = "groupBoxResetWord";
            this.groupBoxResetWord.Size = new System.Drawing.Size(327, 182);
            this.groupBoxResetWord.TabIndex = 9;
            this.groupBoxResetWord.TabStop = false;
            this.groupBoxResetWord.Text = "Reset Word";
            // 
            // buttonShortResetWordCalculate
            // 
            this.buttonShortResetWordCalculate.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonShortResetWordCalculate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonShortResetWordCalculate.Location = new System.Drawing.Point(6, 148);
            this.buttonShortResetWordCalculate.Name = "buttonShortResetWordCalculate";
            this.buttonShortResetWordCalculate.Size = new System.Drawing.Size(311, 27);
            this.buttonShortResetWordCalculate.TabIndex = 15;
            this.buttonShortResetWordCalculate.Text = "Calculate (not recomended)";
            this.buttonShortResetWordCalculate.UseVisualStyleBackColor = false;
            this.buttonShortResetWordCalculate.Click += new System.EventHandler(this.buttonShortResetWordCalculate_Click);
            // 
            // buttonResetWordCalculate
            // 
            this.buttonResetWordCalculate.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonResetWordCalculate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonResetWordCalculate.ForeColor = System.Drawing.Color.Red;
            this.buttonResetWordCalculate.Location = new System.Drawing.Point(6, 77);
            this.buttonResetWordCalculate.Name = "buttonResetWordCalculate";
            this.buttonResetWordCalculate.Size = new System.Drawing.Size(311, 27);
            this.buttonResetWordCalculate.TabIndex = 14;
            this.buttonResetWordCalculate.Text = "NOT WORKING, PUSH ANOTHER BUTTON";
            this.buttonResetWordCalculate.UseVisualStyleBackColor = false;
            this.buttonResetWordCalculate.Click += new System.EventHandler(this.buttonResetWordCalculate_Click);
            // 
            // labelShortestResetWord
            // 
            this.labelShortestResetWord.AutoSize = true;
            this.labelShortestResetWord.ForeColor = System.Drawing.Color.Red;
            this.labelShortestResetWord.Location = new System.Drawing.Point(11, 126);
            this.labelShortestResetWord.Name = "labelShortestResetWord";
            this.labelShortestResetWord.Size = new System.Drawing.Size(69, 19);
            this.labelShortestResetWord.TabIndex = 3;
            this.labelShortestResetWord.Text = "Unknown";
            // 
            // labelQuickResetWord
            // 
            this.labelQuickResetWord.AutoSize = true;
            this.labelQuickResetWord.ForeColor = System.Drawing.Color.Red;
            this.labelQuickResetWord.Location = new System.Drawing.Point(11, 52);
            this.labelQuickResetWord.Name = "labelQuickResetWord";
            this.labelQuickResetWord.Size = new System.Drawing.Size(69, 19);
            this.labelQuickResetWord.TabIndex = 2;
            this.labelQuickResetWord.Text = "Unknown";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Most quickly found reset word is";
            // 
            // labelGeneratorResetWord
            // 
            this.labelGeneratorResetWord.AutoSize = true;
            this.labelGeneratorResetWord.Location = new System.Drawing.Point(7, 107);
            this.labelGeneratorResetWord.Name = "labelGeneratorResetWord";
            this.labelGeneratorResetWord.Size = new System.Drawing.Size(150, 19);
            this.labelGeneratorResetWord.TabIndex = 0;
            this.labelGeneratorResetWord.Text = "Shortest reset word is";
            // 
            // dataGridViewAutomata
            // 
            this.dataGridViewAutomata.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewAutomata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAutomata.Location = new System.Drawing.Point(7, 217);
            this.dataGridViewAutomata.Name = "dataGridViewAutomata";
            this.dataGridViewAutomata.ReadOnly = true;
            this.dataGridViewAutomata.Size = new System.Drawing.Size(444, 441);
            this.dataGridViewAutomata.TabIndex = 6;
            // 
            // tabPageCreate
            // 
            this.tabPageCreate.Controls.Add(this.panel2);
            this.tabPageCreate.Location = new System.Drawing.Point(4, 28);
            this.tabPageCreate.Name = "tabPageCreate";
            this.tabPageCreate.Size = new System.Drawing.Size(443, 178);
            this.tabPageCreate.TabIndex = 2;
            this.tabPageCreate.Text = "Create";
            this.tabPageCreate.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.buttonCreateConfirm);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.numericUpDownCreateAlphabet);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.numericUpDownCreateStates);
            this.panel2.Controls.Add(this.buttonCreateTable);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(443, 178);
            this.panel2.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(247, 19);
            this.label6.TabIndex = 0;
            this.label6.Text = "Select size, then push \"Create Table\"";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 19);
            this.label7.TabIndex = 2;
            this.label7.Text = "States";
            // 
            // numericUpDownCreateAlphabet
            // 
            this.numericUpDownCreateAlphabet.Location = new System.Drawing.Point(111, 77);
            this.numericUpDownCreateAlphabet.Maximum = new decimal(new int[] {
            26,
            0,
            0,
            0});
            this.numericUpDownCreateAlphabet.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownCreateAlphabet.Name = "numericUpDownCreateAlphabet";
            this.numericUpDownCreateAlphabet.Size = new System.Drawing.Size(120, 27);
            this.numericUpDownCreateAlphabet.TabIndex = 8;
            this.numericUpDownCreateAlphabet.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 19);
            this.label8.TabIndex = 3;
            this.label8.Text = "Alphabet";
            // 
            // numericUpDownCreateStates
            // 
            this.numericUpDownCreateStates.Location = new System.Drawing.Point(111, 35);
            this.numericUpDownCreateStates.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownCreateStates.Name = "numericUpDownCreateStates";
            this.numericUpDownCreateStates.Size = new System.Drawing.Size(120, 27);
            this.numericUpDownCreateStates.TabIndex = 7;
            this.numericUpDownCreateStates.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // buttonCreateTable
            // 
            this.buttonCreateTable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCreateTable.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonCreateTable.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonCreateTable.Location = new System.Drawing.Point(7, 117);
            this.buttonCreateTable.Name = "buttonCreateTable";
            this.buttonCreateTable.Size = new System.Drawing.Size(433, 27);
            this.buttonCreateTable.TabIndex = 5;
            this.buttonCreateTable.Text = "Create Table";
            this.buttonCreateTable.UseVisualStyleBackColor = false;
            this.buttonCreateTable.Click += new System.EventHandler(this.buttonCreateTable_Click);
            // 
            // buttonCreateConfirm
            // 
            this.buttonCreateConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCreateConfirm.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonCreateConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonCreateConfirm.Location = new System.Drawing.Point(7, 117);
            this.buttonCreateConfirm.Name = "buttonCreateConfirm";
            this.buttonCreateConfirm.Size = new System.Drawing.Size(433, 27);
            this.buttonCreateConfirm.TabIndex = 9;
            this.buttonCreateConfirm.Text = "Confirm";
            this.buttonCreateConfirm.UseVisualStyleBackColor = false;
            this.buttonCreateConfirm.Visible = false;
            this.buttonCreateConfirm.Click += new System.EventHandler(this.buttonCreateConfirm_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 670);
            this.Controls.Add(this.dataGridViewAutomata);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.groupBoxResetWord);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "DFA";
            this.tabControlMain.ResumeLayout(false);
            this.tabPageGenerate.ResumeLayout(false);
            this.panelGenerate.ResumeLayout(false);
            this.panelGenerate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAlphabet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStates)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBoxResetWord.ResumeLayout(false);
            this.groupBoxResetWord.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAutomata)).EndInit();
            this.tabPageCreate.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCreateAlphabet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCreateStates)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageGenerate;
        private System.Windows.Forms.TabPage tabPageOpen;
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
        private System.Windows.Forms.TabPage tabPageCreate;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDownCreateAlphabet;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericUpDownCreateStates;
        private System.Windows.Forms.Button buttonCreateTable;
        private System.Windows.Forms.Button buttonCreateConfirm;
    }
}

