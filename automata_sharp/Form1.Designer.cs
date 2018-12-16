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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelGeneratedStoped = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonGeneratorImpact = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxStates = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxWord = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelShortestResetWord = new System.Windows.Forms.Label();
            this.labelQuickResetWord = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelGeneratorResetWord = new System.Windows.Forms.Label();
            this.numericUpDownAlphabet = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownStates = new System.Windows.Forms.NumericUpDown();
            this.dataGridViewGenerated = new System.Windows.Forms.DataGridView();
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.labelGenerateInfo2 = new System.Windows.Forms.Label();
            this.labelGenerateInfo1 = new System.Windows.Forms.Label();
            this.labelGeneratorInfo = new System.Windows.Forms.Label();
            this.tabPageOpen = new System.Windows.Forms.TabPage();
            this.panelGenerate = new System.Windows.Forms.Panel();
            this.tabControlMain.SuspendLayout();
            this.tabPageGenerate.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAlphabet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGenerated)).BeginInit();
            this.panelGenerate.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageGenerate);
            this.tabControlMain.Controls.Add(this.tabPageOpen);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Margin = new System.Windows.Forms.Padding(4);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(793, 682);
            this.tabControlMain.TabIndex = 0;
            // 
            // tabPageGenerate
            // 
            this.tabPageGenerate.Controls.Add(this.groupBox2);
            this.tabPageGenerate.Controls.Add(this.groupBox1);
            this.tabPageGenerate.Controls.Add(this.dataGridViewGenerated);
            this.tabPageGenerate.Controls.Add(this.panelGenerate);
            this.tabPageGenerate.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabPageGenerate.Location = new System.Drawing.Point(4, 28);
            this.tabPageGenerate.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageGenerate.Name = "tabPageGenerate";
            this.tabPageGenerate.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageGenerate.Size = new System.Drawing.Size(785, 650);
            this.tabPageGenerate.TabIndex = 0;
            this.tabPageGenerate.Text = "Generator";
            this.tabPageGenerate.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.labelGeneratedStoped);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.buttonGeneratorImpact);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.comboBoxStates);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBoxWord);
            this.groupBox2.Location = new System.Drawing.Point(455, 174);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(327, 473);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Impact by own word";
            // 
            // labelGeneratedStoped
            // 
            this.labelGeneratedStoped.AutoSize = true;
            this.labelGeneratedStoped.ForeColor = System.Drawing.Color.Red;
            this.labelGeneratedStoped.Location = new System.Drawing.Point(177, 169);
            this.labelGeneratedStoped.Name = "labelGeneratedStoped";
            this.labelGeneratedStoped.Size = new System.Drawing.Size(69, 19);
            this.labelGeneratedStoped.TabIndex = 13;
            this.labelGeneratedStoped.Text = "Unknown";
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
            // buttonGeneratorImpact
            // 
            this.buttonGeneratorImpact.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonGeneratorImpact.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonGeneratorImpact.Location = new System.Drawing.Point(10, 139);
            this.buttonGeneratorImpact.Name = "buttonGeneratorImpact";
            this.buttonGeneratorImpact.Size = new System.Drawing.Size(311, 27);
            this.buttonGeneratorImpact.TabIndex = 11;
            this.buttonGeneratorImpact.Text = "Impact";
            this.buttonGeneratorImpact.UseVisualStyleBackColor = false;
            this.buttonGeneratorImpact.Click += new System.EventHandler(this.buttonGeneratorImpact_Click);
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
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.labelShortestResetWord);
            this.groupBox1.Controls.Add(this.labelQuickResetWord);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.labelGeneratorResetWord);
            this.groupBox1.Location = new System.Drawing.Point(455, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(327, 161);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reset Word";
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
            // dataGridViewGenerated
            // 
            this.dataGridViewGenerated.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewGenerated.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGenerated.Location = new System.Drawing.Point(3, 147);
            this.dataGridViewGenerated.Name = "dataGridViewGenerated";
            this.dataGridViewGenerated.Size = new System.Drawing.Size(446, 500);
            this.dataGridViewGenerated.TabIndex = 6;
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonGenerate.Location = new System.Drawing.Point(3, 117);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(446, 27);
            this.buttonGenerate.TabIndex = 5;
            this.buttonGenerate.Text = "Generate";
            this.buttonGenerate.UseVisualStyleBackColor = false;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
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
            // labelGenerateInfo1
            // 
            this.labelGenerateInfo1.AutoSize = true;
            this.labelGenerateInfo1.Location = new System.Drawing.Point(8, 37);
            this.labelGenerateInfo1.Name = "labelGenerateInfo1";
            this.labelGenerateInfo1.Size = new System.Drawing.Size(49, 19);
            this.labelGenerateInfo1.TabIndex = 2;
            this.labelGenerateInfo1.Text = "States";
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
            // tabPageOpen
            // 
            this.tabPageOpen.Location = new System.Drawing.Point(4, 28);
            this.tabPageOpen.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageOpen.Name = "tabPageOpen";
            this.tabPageOpen.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageOpen.Size = new System.Drawing.Size(785, 650);
            this.tabPageOpen.TabIndex = 1;
            this.tabPageOpen.Text = "Open";
            this.tabPageOpen.UseVisualStyleBackColor = true;
            // 
            // panelGenerate
            // 
            this.panelGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelGenerate.Controls.Add(this.labelGeneratorInfo);
            this.panelGenerate.Controls.Add(this.labelGenerateInfo1);
            this.panelGenerate.Controls.Add(this.numericUpDownAlphabet);
            this.panelGenerate.Controls.Add(this.labelGenerateInfo2);
            this.panelGenerate.Controls.Add(this.numericUpDownStates);
            this.panelGenerate.Controls.Add(this.buttonGenerate);
            this.panelGenerate.Location = new System.Drawing.Point(0, 0);
            this.panelGenerate.Name = "panelGenerate";
            this.panelGenerate.Size = new System.Drawing.Size(449, 147);
            this.panelGenerate.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 682);
            this.Controls.Add(this.tabControlMain);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "DFA";
            this.tabControlMain.ResumeLayout(false);
            this.tabPageGenerate.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAlphabet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStates)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGenerated)).EndInit();
            this.panelGenerate.ResumeLayout(false);
            this.panelGenerate.PerformLayout();
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
        private System.Windows.Forms.DataGridView dataGridViewGenerated;
        private System.Windows.Forms.NumericUpDown numericUpDownAlphabet;
        private System.Windows.Forms.NumericUpDown numericUpDownStates;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelShortestResetWord;
        private System.Windows.Forms.Label labelQuickResetWord;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelGeneratorResetWord;
        private System.Windows.Forms.Label labelGeneratedStoped;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonGeneratorImpact;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxStates;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxWord;
        private System.Windows.Forms.Panel panelGenerate;
    }
}

