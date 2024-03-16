namespace MorseCodeTrainer
{
    partial class frmMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblSymbolToTranslate = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.lblHint = new System.Windows.Forms.Label();
            this.lblStreak = new System.Windows.Forms.Label();
            this.rbnLetterToMorse = new System.Windows.Forms.RadioButton();
            this.rbnMorseToLetter = new System.Windows.Forms.RadioButton();
            this.rbnMorseToLetterHearing = new System.Windows.Forms.RadioButton();
            this.rbnMorseToWordHearing = new System.Windows.Forms.RadioButton();
            this.nudMorsePitch = new System.Windows.Forms.NumericUpDown();
            this.nudMorseInterval = new System.Windows.Forms.NumericUpDown();
            this.lblMorseInterval = new System.Windows.Forms.Label();
            this.lblMorsePitch = new System.Windows.Forms.Label();
            this.rbnWordToMorse = new System.Windows.Forms.RadioButton();
            this.rbnMorseToWord = new System.Windows.Forms.RadioButton();
            this.cboLanguage = new System.Windows.Forms.ComboBox();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.lblTranslation = new System.Windows.Forms.Label();
            this.chkShowMorseTranslation = new System.Windows.Forms.CheckBox();
            this.chkStrictMode = new System.Windows.Forms.CheckBox();
            this.lblMistakeReminder = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudMorsePitch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMorseInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSymbolToTranslate
            // 
            this.lblSymbolToTranslate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSymbolToTranslate.AutoSize = true;
            this.lblSymbolToTranslate.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSymbolToTranslate.Location = new System.Drawing.Point(400, 50);
            this.lblSymbolToTranslate.Name = "lblSymbolToTranslate";
            this.lblSymbolToTranslate.Size = new System.Drawing.Size(366, 46);
            this.lblSymbolToTranslate.TabIndex = 0;
            this.lblSymbolToTranslate.Text = "SymbolToTranslate";
            this.lblSymbolToTranslate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtInput
            // 
            this.txtInput.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInput.Location = new System.Drawing.Point(245, 199);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(311, 53);
            this.txtInput.TabIndex = 1;
            this.txtInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblHint
            // 
            this.lblHint.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblHint.AutoSize = true;
            this.lblHint.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHint.Location = new System.Drawing.Point(400, 306);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(91, 46);
            this.lblHint.TabIndex = 2;
            this.lblHint.Text = "Hint";
            // 
            // lblStreak
            // 
            this.lblStreak.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblStreak.AutoSize = true;
            this.lblStreak.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStreak.Location = new System.Drawing.Point(79, 199);
            this.lblStreak.Name = "lblStreak";
            this.lblStreak.Size = new System.Drawing.Size(93, 31);
            this.lblStreak.TabIndex = 3;
            this.lblStreak.Text = "Streak";
            this.lblStreak.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rbnLetterToMorse
            // 
            this.rbnLetterToMorse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rbnLetterToMorse.AutoSize = true;
            this.rbnLetterToMorse.Location = new System.Drawing.Point(12, 306);
            this.rbnLetterToMorse.Name = "rbnLetterToMorse";
            this.rbnLetterToMorse.Size = new System.Drawing.Size(96, 17);
            this.rbnLetterToMorse.TabIndex = 4;
            this.rbnLetterToMorse.TabStop = true;
            this.rbnLetterToMorse.Text = "Letter to Morse";
            this.rbnLetterToMorse.UseVisualStyleBackColor = true;
            // 
            // rbnMorseToLetter
            // 
            this.rbnMorseToLetter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rbnMorseToLetter.AutoSize = true;
            this.rbnMorseToLetter.Location = new System.Drawing.Point(12, 329);
            this.rbnMorseToLetter.Name = "rbnMorseToLetter";
            this.rbnMorseToLetter.Size = new System.Drawing.Size(96, 17);
            this.rbnMorseToLetter.TabIndex = 5;
            this.rbnMorseToLetter.TabStop = true;
            this.rbnMorseToLetter.Text = "Morse to Letter";
            this.rbnMorseToLetter.UseVisualStyleBackColor = true;
            // 
            // rbnMorseToLetterHearing
            // 
            this.rbnMorseToLetterHearing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rbnMorseToLetterHearing.AutoSize = true;
            this.rbnMorseToLetterHearing.Location = new System.Drawing.Point(12, 398);
            this.rbnMorseToLetterHearing.Name = "rbnMorseToLetterHearing";
            this.rbnMorseToLetterHearing.Size = new System.Drawing.Size(129, 17);
            this.rbnMorseToLetterHearing.TabIndex = 6;
            this.rbnMorseToLetterHearing.TabStop = true;
            this.rbnMorseToLetterHearing.Text = "Morse to Letter (listen)";
            this.rbnMorseToLetterHearing.UseVisualStyleBackColor = true;
            // 
            // rbnMorseToWordHearing
            // 
            this.rbnMorseToWordHearing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rbnMorseToWordHearing.AutoSize = true;
            this.rbnMorseToWordHearing.Location = new System.Drawing.Point(12, 421);
            this.rbnMorseToWordHearing.Name = "rbnMorseToWordHearing";
            this.rbnMorseToWordHearing.Size = new System.Drawing.Size(128, 17);
            this.rbnMorseToWordHearing.TabIndex = 7;
            this.rbnMorseToWordHearing.TabStop = true;
            this.rbnMorseToWordHearing.Text = "Morse to Word (listen)";
            this.rbnMorseToWordHearing.UseVisualStyleBackColor = true;
            // 
            // nudMorsePitch
            // 
            this.nudMorsePitch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nudMorsePitch.Location = new System.Drawing.Point(732, 421);
            this.nudMorsePitch.Maximum = new decimal(new int[] {
            16000,
            0,
            0,
            0});
            this.nudMorsePitch.Minimum = new decimal(new int[] {
            37,
            0,
            0,
            0});
            this.nudMorsePitch.Name = "nudMorsePitch";
            this.nudMorsePitch.Size = new System.Drawing.Size(56, 20);
            this.nudMorsePitch.TabIndex = 8;
            this.nudMorsePitch.Value = new decimal(new int[] {
            800,
            0,
            0,
            0});
            // 
            // nudMorseInterval
            // 
            this.nudMorseInterval.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nudMorseInterval.Location = new System.Drawing.Point(732, 395);
            this.nudMorseInterval.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudMorseInterval.Name = "nudMorseInterval";
            this.nudMorseInterval.Size = new System.Drawing.Size(56, 20);
            this.nudMorseInterval.TabIndex = 9;
            this.nudMorseInterval.Value = new decimal(new int[] {
            150,
            0,
            0,
            0});
            // 
            // lblMorseInterval
            // 
            this.lblMorseInterval.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMorseInterval.AutoSize = true;
            this.lblMorseInterval.Location = new System.Drawing.Point(652, 397);
            this.lblMorseInterval.Name = "lblMorseInterval";
            this.lblMorseInterval.Size = new System.Drawing.Size(74, 13);
            this.lblMorseInterval.TabIndex = 10;
            this.lblMorseInterval.Text = "Morse-Interval";
            // 
            // lblMorsePitch
            // 
            this.lblMorsePitch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMorsePitch.AutoSize = true;
            this.lblMorsePitch.Location = new System.Drawing.Point(663, 423);
            this.lblMorsePitch.Name = "lblMorsePitch";
            this.lblMorsePitch.Size = new System.Drawing.Size(63, 13);
            this.lblMorsePitch.TabIndex = 11;
            this.lblMorsePitch.Text = "Morse-Pitch";
            // 
            // rbnWordToMorse
            // 
            this.rbnWordToMorse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rbnWordToMorse.AutoSize = true;
            this.rbnWordToMorse.Location = new System.Drawing.Point(12, 352);
            this.rbnWordToMorse.Name = "rbnWordToMorse";
            this.rbnWordToMorse.Size = new System.Drawing.Size(95, 17);
            this.rbnWordToMorse.TabIndex = 12;
            this.rbnWordToMorse.TabStop = true;
            this.rbnWordToMorse.Text = "Word to Morse";
            this.rbnWordToMorse.UseVisualStyleBackColor = true;
            // 
            // rbnMorseToWord
            // 
            this.rbnMorseToWord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rbnMorseToWord.AutoSize = true;
            this.rbnMorseToWord.Location = new System.Drawing.Point(12, 375);
            this.rbnMorseToWord.Name = "rbnMorseToWord";
            this.rbnMorseToWord.Size = new System.Drawing.Size(95, 17);
            this.rbnMorseToWord.TabIndex = 13;
            this.rbnMorseToWord.TabStop = true;
            this.rbnMorseToWord.Text = "Morse to Word";
            this.rbnMorseToWord.UseVisualStyleBackColor = true;
            // 
            // cboLanguage
            // 
            this.cboLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLanguage.FormattingEnabled = true;
            this.cboLanguage.Items.AddRange(new object[] {
            "DE",
            "EN"});
            this.cboLanguage.Location = new System.Drawing.Point(73, 5);
            this.cboLanguage.Name = "cboLanguage";
            this.cboLanguage.Size = new System.Drawing.Size(49, 21);
            this.cboLanguage.TabIndex = 14;
            // 
            // lblLanguage
            // 
            this.lblLanguage.AutoSize = true;
            this.lblLanguage.Location = new System.Drawing.Point(12, 8);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(55, 13);
            this.lblLanguage.TabIndex = 15;
            this.lblLanguage.Text = "Language";
            // 
            // lblTranslation
            // 
            this.lblTranslation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTranslation.AutoSize = true;
            this.lblTranslation.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTranslation.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblTranslation.Location = new System.Drawing.Point(400, 161);
            this.lblTranslation.Name = "lblTranslation";
            this.lblTranslation.Size = new System.Drawing.Size(149, 31);
            this.lblTranslation.TabIndex = 16;
            this.lblTranslation.Text = "Translation";
            this.lblTranslation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkShowMorseTranslation
            // 
            this.chkShowMorseTranslation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkShowMorseTranslation.AutoSize = true;
            this.chkShowMorseTranslation.Checked = true;
            this.chkShowMorseTranslation.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowMorseTranslation.Location = new System.Drawing.Point(680, 372);
            this.chkShowMorseTranslation.Name = "chkShowMorseTranslation";
            this.chkShowMorseTranslation.Size = new System.Drawing.Size(108, 17);
            this.chkShowMorseTranslation.TabIndex = 17;
            this.chkShowMorseTranslation.Text = "Show Translation";
            this.chkShowMorseTranslation.UseVisualStyleBackColor = true;
            // 
            // chkStrictMode
            // 
            this.chkStrictMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkStrictMode.AutoSize = true;
            this.chkStrictMode.Location = new System.Drawing.Point(708, 349);
            this.chkStrictMode.Name = "chkStrictMode";
            this.chkStrictMode.Size = new System.Drawing.Size(80, 17);
            this.chkStrictMode.TabIndex = 18;
            this.chkStrictMode.Text = "Strict Mode";
            this.chkStrictMode.UseVisualStyleBackColor = true;
            // 
            // lblMistakeReminder
            // 
            this.lblMistakeReminder.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMistakeReminder.AutoSize = true;
            this.lblMistakeReminder.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMistakeReminder.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblMistakeReminder.Location = new System.Drawing.Point(563, 199);
            this.lblMistakeReminder.Name = "lblMistakeReminder";
            this.lblMistakeReminder.Size = new System.Drawing.Size(225, 31);
            this.lblMistakeReminder.TabIndex = 19;
            this.lblMistakeReminder.Text = "MistakeReminder";
            this.lblMistakeReminder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblMistakeReminder);
            this.Controls.Add(this.chkStrictMode);
            this.Controls.Add(this.chkShowMorseTranslation);
            this.Controls.Add(this.lblTranslation);
            this.Controls.Add(this.lblLanguage);
            this.Controls.Add(this.cboLanguage);
            this.Controls.Add(this.rbnMorseToWord);
            this.Controls.Add(this.rbnWordToMorse);
            this.Controls.Add(this.lblMorsePitch);
            this.Controls.Add(this.lblMorseInterval);
            this.Controls.Add(this.nudMorseInterval);
            this.Controls.Add(this.nudMorsePitch);
            this.Controls.Add(this.rbnMorseToWordHearing);
            this.Controls.Add(this.rbnMorseToLetterHearing);
            this.Controls.Add(this.rbnMorseToLetter);
            this.Controls.Add(this.rbnLetterToMorse);
            this.Controls.Add(this.lblStreak);
            this.Controls.Add(this.lblHint);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.lblSymbolToTranslate);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "frmMain";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudMorsePitch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMorseInterval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSymbolToTranslate;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.Label lblStreak;
        private System.Windows.Forms.RadioButton rbnLetterToMorse;
        private System.Windows.Forms.RadioButton rbnMorseToLetter;
        private System.Windows.Forms.RadioButton rbnMorseToLetterHearing;
        private System.Windows.Forms.RadioButton rbnMorseToWordHearing;
        private System.Windows.Forms.NumericUpDown nudMorsePitch;
        private System.Windows.Forms.NumericUpDown nudMorseInterval;
        private System.Windows.Forms.Label lblMorseInterval;
        private System.Windows.Forms.Label lblMorsePitch;
        private System.Windows.Forms.RadioButton rbnWordToMorse;
        private System.Windows.Forms.RadioButton rbnMorseToWord;
        private System.Windows.Forms.ComboBox cboLanguage;
        private System.Windows.Forms.Label lblLanguage;
        private System.Windows.Forms.Label lblTranslation;
        private System.Windows.Forms.CheckBox chkShowMorseTranslation;
        private System.Windows.Forms.CheckBox chkStrictMode;
        private System.Windows.Forms.Label lblMistakeReminder;
    }
}

