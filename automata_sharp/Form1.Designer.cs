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
            this.groupBox2.SuspendLayout();
            this.groupBoxResetWord.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAutomata)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            resources.ApplyResources(this.tabControlMain, "tabControlMain");
            this.tabControlMain.Controls.Add(this.tabPageGenerate);
            this.tabControlMain.Controls.Add(this.tabPageCreate);
            this.tabControlMain.Controls.Add(this.tabPageOpen);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
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
            1,
            0,
            0,
            0});
            this.numericUpDownAlphabet.Name = "numericUpDownAlphabet";
            this.numericUpDownAlphabet.Value = new decimal(new int[] {
            1,
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
            1,
            0,
            0,
            0});
            this.numericUpDownStates.Name = "numericUpDownStates";
            this.numericUpDownStates.Value = new decimal(new int[] {
            1,
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
            // tabPageCreate
            // 
            this.tabPageCreate.Controls.Add(this.panel2);
            resources.ApplyResources(this.tabPageCreate, "tabPageCreate");
            this.tabPageCreate.Name = "tabPageCreate";
            this.tabPageCreate.UseVisualStyleBackColor = true;
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
            1,
            0,
            0,
            0});
            this.numericUpDownCreateAlphabet.Name = "numericUpDownCreateAlphabet";
            this.numericUpDownCreateAlphabet.Value = new decimal(new int[] {
            1,
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
            1,
            0,
            0,
            0});
            this.numericUpDownCreateStates.Name = "numericUpDownCreateStates";
            this.numericUpDownCreateStates.Value = new decimal(new int[] {
            1,
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
            // tabPageOpen
            // 
            this.tabPageOpen.Controls.Add(this.pictureBox2);
            this.tabPageOpen.Controls.Add(this.pictureBox1);
            this.tabPageOpen.Controls.Add(this.labelOpenSaveText);
            this.tabPageOpen.Controls.Add(this.buttonSave);
            this.tabPageOpen.Controls.Add(this.buttonOpen);
            resources.ApplyResources(this.tabPageOpen, "tabPageOpen");
            this.tabPageOpen.Name = "tabPageOpen";
            this.tabPageOpen.UseVisualStyleBackColor = true;
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
            this.groupBox2.Controls.Add(this.buttonCreateConfirm);
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
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridViewAutomata);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.groupBoxResetWord);
            this.Name = "Form1";
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
    }
}

