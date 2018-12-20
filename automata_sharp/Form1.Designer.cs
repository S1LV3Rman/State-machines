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
            this.tabPageCreate = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelCreateInfo = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDownCreateAlphabet = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.numericUpDownCreateStates = new System.Windows.Forms.NumericUpDown();
            this.buttonCreateTable = new System.Windows.Forms.Button();
            this.tabPageOpen = new System.Windows.Forms.TabPage();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelOpenSaveText = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonOpen = new System.Windows.Forms.Button();

            this.tabPageAbout = new System.Windows.Forms.TabPage();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
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
            this.buttonShortResetWordCalculate = new System.Windows.Forms.Button();
            this.buttonResetWordCalculate = new System.Windows.Forms.Button();
            this.labelShortestResetWord = new System.Windows.Forms.Label();
            this.labelQuickResetWord = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelGeneratorResetWord = new System.Windows.Forms.Label();
            this.dataGridViewAutomata = new System.Windows.Forms.DataGridView();
            this.buttonCancelResetWord = new System.Windows.Forms.Button();
            this.buttonCancelShortResetWord = new System.Windows.Forms.Button();
            this.tabControlMain.SuspendLayout();
            this.tabPageGenerate.SuspendLayout();
            this.panelGenerate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAlphabet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStates)).BeginInit();
            this.tabPageCreate.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCreateAlphabet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCreateStates)).BeginInit();
            this.tabPageOpen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPageAbout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBoxResetWord.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAutomata)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlMain.Controls.Add(this.tabPageGenerate);
            this.tabControlMain.Controls.Add(this.tabPageCreate);
            this.tabControlMain.Controls.Add(this.tabPageOpen);
            this.tabControlMain.Controls.Add(this.tabPageAbout);
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
            this.tabPageGenerate.Font = new System.Drawing.Font("Calibri", 12F);
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
            this.labelGeneratorInfo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelGeneratorInfo.Location = new System.Drawing.Point(8, 7);
            this.labelGeneratorInfo.Name = "labelGeneratorInfo";
            this.labelGeneratorInfo.Size = new System.Drawing.Size(428, 19);
            this.labelGeneratorInfo.TabIndex = 0;
            this.labelGeneratorInfo.Text = "Type number of states and size of alpabet, then push \"Generate\"";
            // 
            // labelGenerateInfo1
            // 
            this.labelGenerateInfo1.AutoSize = true;
            this.labelGenerateInfo1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
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
            this.labelGenerateInfo2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
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
            this.buttonGenerate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonGenerate.Location = new System.Drawing.Point(7, 117);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(433, 27);
            this.buttonGenerate.TabIndex = 5;
            this.buttonGenerate.Text = "Generate";
            this.buttonGenerate.UseVisualStyleBackColor = false;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
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
            this.panel2.Controls.Add(this.labelCreateInfo);
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
            // labelCreateInfo
            // 
            this.labelCreateInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCreateInfo.AutoSize = true;
            this.labelCreateInfo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelCreateInfo.Location = new System.Drawing.Point(8, 7);
            this.labelCreateInfo.Name = "labelCreateInfo";
            this.labelCreateInfo.Size = new System.Drawing.Size(247, 19);
            this.labelCreateInfo.TabIndex = 0;
            this.labelCreateInfo.Text = "Select size, then push \"Create Table\"";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
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
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
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
            this.buttonCreateTable.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonCreateTable.Location = new System.Drawing.Point(7, 117);
            this.buttonCreateTable.Name = "buttonCreateTable";
            this.buttonCreateTable.Size = new System.Drawing.Size(433, 27);
            this.buttonCreateTable.TabIndex = 5;
            this.buttonCreateTable.Text = "Create Table";
            this.buttonCreateTable.UseVisualStyleBackColor = false;
            this.buttonCreateTable.Click += new System.EventHandler(this.buttonCreateTable_Click);
            // 
            // tabPageOpen
            // 
            this.tabPageOpen.Controls.Add(this.pictureBox2);
            this.tabPageOpen.Controls.Add(this.pictureBox1);
            this.tabPageOpen.Controls.Add(this.labelOpenSaveText);
            this.tabPageOpen.Controls.Add(this.buttonSave);
            this.tabPageOpen.Controls.Add(this.buttonOpen);
            this.tabPageOpen.Location = new System.Drawing.Point(4, 28);
            this.tabPageOpen.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageOpen.Name = "tabPageOpen";
            this.tabPageOpen.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageOpen.Size = new System.Drawing.Size(443, 178);
            this.tabPageOpen.TabIndex = 1;
            this.tabPageOpen.Text = "From File";
            this.tabPageOpen.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::automata_sharp.Properties.Resources.save;
            this.pictureBox2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox2.InitialImage = null;
            this.pictureBox2.Location = new System.Drawing.Point(8, 126);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(38, 27);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::automata_sharp.Properties.Resources.open;
            this.pictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(8, 77);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(38, 27);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // labelOpenSaveText
            // 
            this.labelOpenSaveText.AutoSize = true;
            this.labelOpenSaveText.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelOpenSaveText.Location = new System.Drawing.Point(8, 7);
            this.labelOpenSaveText.Name = "labelOpenSaveText";
            this.labelOpenSaveText.Size = new System.Drawing.Size(245, 19);
            this.labelOpenSaveText.TabIndex = 2;
            this.labelOpenSaveText.Text = "Save your automata or open existing";
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonSave.Location = new System.Drawing.Point(52, 126);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(384, 27);
            this.buttonSave.TabIndex = 1;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonOpen
            // 
            this.buttonOpen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOpen.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOpen.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonOpen.Location = new System.Drawing.Point(52, 77);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(384, 27);
            this.buttonOpen.TabIndex = 0;
            this.buttonOpen.Text = "Open";
            this.buttonOpen.UseVisualStyleBackColor = false;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 

            // buttonCreateConfirm
            // 
            resources.ApplyResources(this.buttonCreateConfirm, "buttonCreateConfirm");
            this.buttonCreateConfirm.BackColor = System.Drawing.Color.PaleTurquoise;
            this.buttonCreateConfirm.Name = "buttonCreateConfirm";
            this.buttonCreateConfirm.UseVisualStyleBackColor = false;

            // tabPageAbout
            // 
            this.tabPageAbout.Controls.Add(this.label11);
            this.tabPageAbout.Controls.Add(this.label10);
            this.tabPageAbout.Controls.Add(this.label9);
            this.tabPageAbout.Controls.Add(this.label6);
            this.tabPageAbout.Controls.Add(this.pictureBox3);
            this.tabPageAbout.Location = new System.Drawing.Point(4, 28);
            this.tabPageAbout.Name = "tabPageAbout";
            this.tabPageAbout.Size = new System.Drawing.Size(443, 178);
            this.tabPageAbout.TabIndex = 3;
            this.tabPageAbout.Text = "About";
            this.tabPageAbout.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 8F);
            this.label11.Location = new System.Drawing.Point(8, 162);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(99, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = "SPb ETU, 2018-2019";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 10F);
            this.label10.Location = new System.Drawing.Point(8, 144);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(430, 17);
            this.label10.TabIndex = 3;
            this.label10.Text = "Made for alternative exam \"Mathematical Logic and Theory of Algorithms\"";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 10F);
            this.label9.Location = new System.Drawing.Point(99, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(303, 119);
            this.label9.TabIndex = 2;
            this.label9.Text = resources.GetString("label9.Text");
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 12F);
            this.label6.Location = new System.Drawing.Point(98, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 19);
            this.label6.TabIndex = 1;
            this.label6.Text = "Authors:";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::automata_sharp.Properties.Resources.Automaton;
            this.pictureBox3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox3.Location = new System.Drawing.Point(3, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(89, 101);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // buttonCreateConfirm
            // 
            this.buttonCreateConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCreateConfirm.BackColor = System.Drawing.Color.PaleTurquoise;
            this.buttonCreateConfirm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonCreateConfirm.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonCreateConfirm.Location = new System.Drawing.Point(10, 280);
            this.buttonCreateConfirm.Name = "buttonCreateConfirm";
            this.buttonCreateConfirm.Size = new System.Drawing.Size(311, 27);
            this.buttonCreateConfirm.TabIndex = 9;
            this.buttonCreateConfirm.Text = "Confirm";
            this.buttonCreateConfirm.UseVisualStyleBackColor = false;
            this.buttonCreateConfirm.Visible = false;

            this.buttonCreateConfirm.Click += new System.EventHandler(this.buttonCreateConfirm_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.buttonCreateConfirm);
            this.groupBox2.Controls.Add(this.labelStoped);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.buttonImpact);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.comboBoxStates);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBoxWord);
            this.groupBox2.Location = new System.Drawing.Point(457, 217);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(327, 313);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Impact by own word";
            // 
            // labelStoped
            // 
            this.labelStoped.AutoSize = true;
            this.labelStoped.ForeColor = System.Drawing.Color.Red;
            this.labelStoped.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelStoped.Location = new System.Drawing.Point(191, 169);
            this.labelStoped.Name = "labelStoped";
            this.labelStoped.Size = new System.Drawing.Size(69, 19);
            this.labelStoped.TabIndex = 13;
            this.labelStoped.Text = "Unknown";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(11, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(185, 19);
            this.label5.TabIndex = 12;
            this.label5.Text = "Automata\'s current state is";
            // 
            // buttonImpact
            // 
            this.buttonImpact.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonImpact.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonImpact.ImeMode = System.Windows.Forms.ImeMode.NoControl;
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
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(11, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 19);
            this.label4.TabIndex = 4;
            this.label4.Text = "Word:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
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
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
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

            resources.ApplyResources(this.groupBoxResetWord, "groupBoxResetWord");
            this.groupBoxResetWord.Controls.Add(this.buttonCancelShortResetWord);
            this.groupBoxResetWord.Controls.Add(this.buttonCancelResetWord);

            this.groupBoxResetWord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));

            this.groupBoxResetWord.Controls.Add(this.buttonShortResetWordCalculate);
            this.groupBoxResetWord.Controls.Add(this.buttonResetWordCalculate);
            this.groupBoxResetWord.Controls.Add(this.labelShortestResetWord);
            this.groupBoxResetWord.Controls.Add(this.labelQuickResetWord);
            this.groupBoxResetWord.Controls.Add(this.label1);
            this.groupBoxResetWord.Controls.Add(this.labelGeneratorResetWord);
            this.groupBoxResetWord.Location = new System.Drawing.Point(457, 28);
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
            this.buttonShortResetWordCalculate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonShortResetWordCalculate.Location = new System.Drawing.Point(6, 148);
            this.buttonShortResetWordCalculate.Name = "buttonShortResetWordCalculate";
            this.buttonShortResetWordCalculate.Size = new System.Drawing.Size(311, 27);
            this.buttonShortResetWordCalculate.TabIndex = 15;
            this.buttonShortResetWordCalculate.Text = "Calculate";
            this.buttonShortResetWordCalculate.UseVisualStyleBackColor = false;
            this.buttonShortResetWordCalculate.Click += new System.EventHandler(this.buttonShortResetWordCalculate_Click);
            // 
            // buttonResetWordCalculate
            // 
            this.buttonResetWordCalculate.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonResetWordCalculate.Enabled = false;
            this.buttonResetWordCalculate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonResetWordCalculate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonResetWordCalculate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonResetWordCalculate.Location = new System.Drawing.Point(6, 77);
            this.buttonResetWordCalculate.Name = "buttonResetWordCalculate";
            this.buttonResetWordCalculate.Size = new System.Drawing.Size(311, 27);
            this.buttonResetWordCalculate.TabIndex = 14;
            this.buttonResetWordCalculate.Text = "Calculate";
            this.buttonResetWordCalculate.UseVisualStyleBackColor = false;
            this.buttonResetWordCalculate.Click += new System.EventHandler(this.buttonResetWordCalculate_Click);
            // 
            // labelShortestResetWord
            // 
            this.labelShortestResetWord.AutoSize = true;
            this.labelShortestResetWord.ForeColor = System.Drawing.Color.Red;
            this.labelShortestResetWord.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelShortestResetWord.Location = new System.Drawing.Point(7, 126);
            this.labelShortestResetWord.Name = "labelShortestResetWord";
            this.labelShortestResetWord.Size = new System.Drawing.Size(69, 19);
            this.labelShortestResetWord.TabIndex = 3;
            this.labelShortestResetWord.Text = "Unknown";
            this.labelShortestResetWord.DoubleClick += new System.EventHandler(this.labelShortestResetWord_DoubleClick);
            // 
            // labelQuickResetWord
            // 
            this.labelQuickResetWord.AutoSize = true;
            this.labelQuickResetWord.ForeColor = System.Drawing.Color.Red;
            this.labelQuickResetWord.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelQuickResetWord.Location = new System.Drawing.Point(7, 52);
            this.labelQuickResetWord.Name = "labelQuickResetWord";
            this.labelQuickResetWord.Size = new System.Drawing.Size(69, 19);
            this.labelQuickResetWord.TabIndex = 2;
            this.labelQuickResetWord.Text = "Unknown";
            this.labelQuickResetWord.DoubleClick += new System.EventHandler(this.labelQuickResetWord_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(7, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Most quickly found reset word is";
            // 
            // labelGeneratorResetWord
            // 
            this.labelGeneratorResetWord.AutoSize = true;
            this.labelGeneratorResetWord.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelGeneratorResetWord.Location = new System.Drawing.Point(7, 107);
            this.labelGeneratorResetWord.Name = "labelGeneratorResetWord";
            this.labelGeneratorResetWord.Size = new System.Drawing.Size(150, 19);
            this.labelGeneratorResetWord.TabIndex = 0;
            this.labelGeneratorResetWord.Text = "Shortest reset word is";
            // 
            // dataGridViewAutomata
            // 
            this.dataGridViewAutomata.AllowUserToAddRows = false;
            this.dataGridViewAutomata.AllowUserToDeleteRows = false;
            this.dataGridViewAutomata.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewAutomata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAutomata.Location = new System.Drawing.Point(7, 217);
            this.dataGridViewAutomata.Name = "dataGridViewAutomata";
            this.dataGridViewAutomata.ReadOnly = true;
            this.dataGridViewAutomata.Size = new System.Drawing.Size(442, 313);
            this.dataGridViewAutomata.TabIndex = 6;
            // 
            // buttonCancelResetWord
            // 
            this.buttonCancelResetWord.BackColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(this.buttonCancelResetWord, "buttonCancelResetWord");
            this.buttonCancelResetWord.Name = "buttonCancelResetWord";
            this.buttonCancelResetWord.UseVisualStyleBackColor = false;
            this.buttonCancelResetWord.Click += new System.EventHandler(this.buttonCancelResetWord_Click);
            // 
            // buttonCancelShortResetWord
            // 
            this.buttonCancelShortResetWord.BackColor = System.Drawing.SystemColors.ControlLight;
            resources.ApplyResources(this.buttonCancelShortResetWord, "buttonCancelShortResetWord");
            this.buttonCancelShortResetWord.Name = "buttonCancelShortResetWord";
            this.buttonCancelShortResetWord.UseVisualStyleBackColor = false;
            this.buttonCancelShortResetWord.Click += new System.EventHandler(this.buttonCancelShortResetWord_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 542);
            this.Controls.Add(this.dataGridViewAutomata);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.groupBoxResetWord);
            this.Font = new System.Drawing.Font("Calibri", 12F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Automs | Synchronizable Deterministic Finite Automata";
            this.tabControlMain.ResumeLayout(false);
            this.tabPageGenerate.ResumeLayout(false);
            this.panelGenerate.ResumeLayout(false);
            this.panelGenerate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAlphabet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStates)).EndInit();
            this.tabPageCreate.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCreateAlphabet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCreateStates)).EndInit();
            this.tabPageOpen.ResumeLayout(false);
            this.tabPageOpen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPageAbout.ResumeLayout(false);
            this.tabPageAbout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBoxResetWord.ResumeLayout(false);
            this.groupBoxResetWord.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAutomata)).EndInit();
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
    }
}

