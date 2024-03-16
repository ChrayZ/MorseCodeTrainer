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
            lblSymbolToTranslate = new System.Windows.Forms.Label();
            txtInput = new System.Windows.Forms.TextBox();
            lblHint = new System.Windows.Forms.Label();
            lblStreak = new System.Windows.Forms.Label();
            rbnLetterToMorse = new System.Windows.Forms.RadioButton();
            rbnMorseToLetter = new System.Windows.Forms.RadioButton();
            rbnMorseToLetterHearing = new System.Windows.Forms.RadioButton();
            rbnMorseToWordHearing = new System.Windows.Forms.RadioButton();
            nudMorsePitch = new System.Windows.Forms.NumericUpDown();
            nudMorseInterval = new System.Windows.Forms.NumericUpDown();
            lblMorseInterval = new System.Windows.Forms.Label();
            lblMorsePitch = new System.Windows.Forms.Label();
            rbnWordToMorse = new System.Windows.Forms.RadioButton();
            rbnMorseToWord = new System.Windows.Forms.RadioButton();
            cboLanguage = new System.Windows.Forms.ComboBox();
            lblLanguage = new System.Windows.Forms.Label();
            lblTranslation = new System.Windows.Forms.Label();
            chkShowMorseTranslation = new System.Windows.Forms.CheckBox();
            chkStrictMode = new System.Windows.Forms.CheckBox();
            lblMistakeReminder = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)nudMorsePitch).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMorseInterval).BeginInit();
            SuspendLayout();
            // 
            // lblSymbolToTranslate
            // 
            lblSymbolToTranslate.Anchor = System.Windows.Forms.AnchorStyles.None;
            lblSymbolToTranslate.AutoSize = true;
            lblSymbolToTranslate.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lblSymbolToTranslate.Location = new System.Drawing.Point(400, 50);
            lblSymbolToTranslate.Name = "lblSymbolToTranslate";
            lblSymbolToTranslate.Size = new System.Drawing.Size(366, 46);
            lblSymbolToTranslate.TabIndex = 0;
            lblSymbolToTranslate.Text = "SymbolToTranslate";
            lblSymbolToTranslate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtInput
            // 
            txtInput.Anchor = System.Windows.Forms.AnchorStyles.None;
            txtInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtInput.Location = new System.Drawing.Point(245, 199);
            txtInput.Name = "txtInput";
            txtInput.Size = new System.Drawing.Size(311, 53);
            txtInput.TabIndex = 1;
            txtInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblHint
            // 
            lblHint.Anchor = System.Windows.Forms.AnchorStyles.None;
            lblHint.AutoSize = true;
            lblHint.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lblHint.Location = new System.Drawing.Point(400, 306);
            lblHint.Name = "lblHint";
            lblHint.Size = new System.Drawing.Size(91, 46);
            lblHint.TabIndex = 2;
            lblHint.Text = "Hint";
            // 
            // lblStreak
            // 
            lblStreak.Anchor = System.Windows.Forms.AnchorStyles.None;
            lblStreak.AutoSize = true;
            lblStreak.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lblStreak.Location = new System.Drawing.Point(79, 199);
            lblStreak.Name = "lblStreak";
            lblStreak.Size = new System.Drawing.Size(93, 31);
            lblStreak.TabIndex = 3;
            lblStreak.Text = "Streak";
            lblStreak.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rbnLetterToMorse
            // 
            rbnLetterToMorse.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            rbnLetterToMorse.AutoSize = true;
            rbnLetterToMorse.Location = new System.Drawing.Point(12, 304);
            rbnLetterToMorse.Name = "rbnLetterToMorse";
            rbnLetterToMorse.Size = new System.Drawing.Size(105, 19);
            rbnLetterToMorse.TabIndex = 4;
            rbnLetterToMorse.TabStop = true;
            rbnLetterToMorse.Text = "Letter to Morse";
            rbnLetterToMorse.UseVisualStyleBackColor = true;
            // 
            // rbnMorseToLetter
            // 
            rbnMorseToLetter.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            rbnMorseToLetter.AutoSize = true;
            rbnMorseToLetter.Location = new System.Drawing.Point(12, 327);
            rbnMorseToLetter.Name = "rbnMorseToLetter";
            rbnMorseToLetter.Size = new System.Drawing.Size(105, 19);
            rbnMorseToLetter.TabIndex = 5;
            rbnMorseToLetter.TabStop = true;
            rbnMorseToLetter.Text = "Morse to Letter";
            rbnMorseToLetter.UseVisualStyleBackColor = true;
            // 
            // rbnMorseToLetterHearing
            // 
            rbnMorseToLetterHearing.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            rbnMorseToLetterHearing.AutoSize = true;
            rbnMorseToLetterHearing.Location = new System.Drawing.Point(12, 396);
            rbnMorseToLetterHearing.Name = "rbnMorseToLetterHearing";
            rbnMorseToLetterHearing.Size = new System.Drawing.Size(144, 19);
            rbnMorseToLetterHearing.TabIndex = 6;
            rbnMorseToLetterHearing.TabStop = true;
            rbnMorseToLetterHearing.Text = "Morse to Letter (listen)";
            rbnMorseToLetterHearing.UseVisualStyleBackColor = true;
            // 
            // rbnMorseToWordHearing
            // 
            rbnMorseToWordHearing.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            rbnMorseToWordHearing.AutoSize = true;
            rbnMorseToWordHearing.Location = new System.Drawing.Point(12, 419);
            rbnMorseToWordHearing.Name = "rbnMorseToWordHearing";
            rbnMorseToWordHearing.Size = new System.Drawing.Size(143, 19);
            rbnMorseToWordHearing.TabIndex = 7;
            rbnMorseToWordHearing.TabStop = true;
            rbnMorseToWordHearing.Text = "Morse to Word (listen)";
            rbnMorseToWordHearing.UseVisualStyleBackColor = true;
            // 
            // nudMorsePitch
            // 
            nudMorsePitch.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            nudMorsePitch.Location = new System.Drawing.Point(732, 421);
            nudMorsePitch.Maximum = new decimal(new int[] { 16000, 0, 0, 0 });
            nudMorsePitch.Minimum = new decimal(new int[] { 37, 0, 0, 0 });
            nudMorsePitch.Name = "nudMorsePitch";
            nudMorsePitch.Size = new System.Drawing.Size(56, 23);
            nudMorsePitch.TabIndex = 8;
            nudMorsePitch.Value = new decimal(new int[] { 800, 0, 0, 0 });
            // 
            // nudMorseInterval
            // 
            nudMorseInterval.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            nudMorseInterval.Location = new System.Drawing.Point(732, 395);
            nudMorseInterval.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            nudMorseInterval.Name = "nudMorseInterval";
            nudMorseInterval.Size = new System.Drawing.Size(56, 23);
            nudMorseInterval.TabIndex = 9;
            nudMorseInterval.Value = new decimal(new int[] { 150, 0, 0, 0 });
            // 
            // lblMorseInterval
            // 
            lblMorseInterval.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            lblMorseInterval.AutoSize = true;
            lblMorseInterval.Location = new System.Drawing.Point(642, 400);
            lblMorseInterval.Name = "lblMorseInterval";
            lblMorseInterval.Size = new System.Drawing.Size(84, 15);
            lblMorseInterval.TabIndex = 10;
            lblMorseInterval.Text = "Morse-Interval";
            // 
            // lblMorsePitch
            // 
            lblMorsePitch.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            lblMorsePitch.AutoSize = true;
            lblMorsePitch.Location = new System.Drawing.Point(654, 423);
            lblMorsePitch.Name = "lblMorsePitch";
            lblMorsePitch.Size = new System.Drawing.Size(72, 15);
            lblMorsePitch.TabIndex = 11;
            lblMorsePitch.Text = "Morse-Pitch";
            // 
            // rbnWordToMorse
            // 
            rbnWordToMorse.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            rbnWordToMorse.AutoSize = true;
            rbnWordToMorse.Location = new System.Drawing.Point(12, 350);
            rbnWordToMorse.Name = "rbnWordToMorse";
            rbnWordToMorse.Size = new System.Drawing.Size(104, 19);
            rbnWordToMorse.TabIndex = 12;
            rbnWordToMorse.TabStop = true;
            rbnWordToMorse.Text = "Word to Morse";
            rbnWordToMorse.UseVisualStyleBackColor = true;
            // 
            // rbnMorseToWord
            // 
            rbnMorseToWord.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            rbnMorseToWord.AutoSize = true;
            rbnMorseToWord.Location = new System.Drawing.Point(12, 373);
            rbnMorseToWord.Name = "rbnMorseToWord";
            rbnMorseToWord.Size = new System.Drawing.Size(104, 19);
            rbnMorseToWord.TabIndex = 13;
            rbnMorseToWord.TabStop = true;
            rbnMorseToWord.Text = "Morse to Word";
            rbnMorseToWord.UseVisualStyleBackColor = true;
            // 
            // cboLanguage
            // 
            cboLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboLanguage.FormattingEnabled = true;
            cboLanguage.Items.AddRange(new object[] { "DE", "EN" });
            cboLanguage.Location = new System.Drawing.Point(73, 5);
            cboLanguage.Name = "cboLanguage";
            cboLanguage.Size = new System.Drawing.Size(49, 23);
            cboLanguage.TabIndex = 14;
            // 
            // lblLanguage
            // 
            lblLanguage.AutoSize = true;
            lblLanguage.Location = new System.Drawing.Point(12, 8);
            lblLanguage.Name = "lblLanguage";
            lblLanguage.Size = new System.Drawing.Size(59, 15);
            lblLanguage.TabIndex = 15;
            lblLanguage.Text = "Language";
            // 
            // lblTranslation
            // 
            lblTranslation.Anchor = System.Windows.Forms.AnchorStyles.None;
            lblTranslation.AutoSize = true;
            lblTranslation.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lblTranslation.ForeColor = System.Drawing.SystemColors.ControlDark;
            lblTranslation.Location = new System.Drawing.Point(400, 161);
            lblTranslation.Name = "lblTranslation";
            lblTranslation.Size = new System.Drawing.Size(149, 31);
            lblTranslation.TabIndex = 16;
            lblTranslation.Text = "Translation";
            lblTranslation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkShowMorseTranslation
            // 
            chkShowMorseTranslation.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            chkShowMorseTranslation.AutoSize = true;
            chkShowMorseTranslation.Checked = true;
            chkShowMorseTranslation.CheckState = System.Windows.Forms.CheckState.Checked;
            chkShowMorseTranslation.Location = new System.Drawing.Point(673, 370);
            chkShowMorseTranslation.Name = "chkShowMorseTranslation";
            chkShowMorseTranslation.Size = new System.Drawing.Size(115, 19);
            chkShowMorseTranslation.TabIndex = 17;
            chkShowMorseTranslation.Text = "Show Translation";
            chkShowMorseTranslation.UseVisualStyleBackColor = true;
            // 
            // chkStrictMode
            // 
            chkStrictMode.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            chkStrictMode.AutoSize = true;
            chkStrictMode.Location = new System.Drawing.Point(701, 347);
            chkStrictMode.Name = "chkStrictMode";
            chkStrictMode.Size = new System.Drawing.Size(87, 19);
            chkStrictMode.TabIndex = 18;
            chkStrictMode.Text = "Strict Mode";
            chkStrictMode.UseVisualStyleBackColor = true;
            // 
            // lblMistakeReminder
            // 
            lblMistakeReminder.Anchor = System.Windows.Forms.AnchorStyles.None;
            lblMistakeReminder.AutoSize = true;
            lblMistakeReminder.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lblMistakeReminder.ForeColor = System.Drawing.SystemColors.ControlDark;
            lblMistakeReminder.Location = new System.Drawing.Point(563, 199);
            lblMistakeReminder.Name = "lblMistakeReminder";
            lblMistakeReminder.Size = new System.Drawing.Size(225, 31);
            lblMistakeReminder.TabIndex = 19;
            lblMistakeReminder.Text = "MistakeReminder";
            lblMistakeReminder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmMain
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(lblMistakeReminder);
            Controls.Add(chkStrictMode);
            Controls.Add(chkShowMorseTranslation);
            Controls.Add(lblTranslation);
            Controls.Add(lblLanguage);
            Controls.Add(cboLanguage);
            Controls.Add(rbnMorseToWord);
            Controls.Add(rbnWordToMorse);
            Controls.Add(lblMorsePitch);
            Controls.Add(lblMorseInterval);
            Controls.Add(nudMorseInterval);
            Controls.Add(nudMorsePitch);
            Controls.Add(rbnMorseToWordHearing);
            Controls.Add(rbnMorseToLetterHearing);
            Controls.Add(rbnMorseToLetter);
            Controls.Add(rbnLetterToMorse);
            Controls.Add(lblStreak);
            Controls.Add(lblHint);
            Controls.Add(txtInput);
            Controls.Add(lblSymbolToTranslate);
            MinimumSize = new System.Drawing.Size(816, 489);
            Name = "frmMain";
            ShowIcon = false;
            Load += frmMain_Load;
            ((System.ComponentModel.ISupportInitialize)nudMorsePitch).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMorseInterval).EndInit();
            ResumeLayout(false);
            PerformLayout();
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

