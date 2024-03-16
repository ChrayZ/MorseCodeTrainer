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
using System.Diagnostics.Eventing.Reader;
using System.Runtime.InteropServices;

namespace MorseCodeTrainer
{
    public partial class frmMain : Form
	{
		private List<Keys> _listOfValidKeys;
		private System.Windows.Forms.Timer _timer;
		private int __streak;
		private int _streakSave;
		private LearningMode _learningMode;
		private bool _hearing = false;
		private MorseProcessor _morseProcessor;
		private WordData _currentWord;
		private LetterData _currentLetter;
        private bool __cursorShown = true;

		private const int _morseInterval = 150;
        private const int _morsePitch = 800;

        private int _streak
		{
			get { return __streak; }
			set 
			{
				__streak = value;
				if (value != 0) _streakSave = value;
				lblStreak.Text = "Streak:" + Environment.NewLine + __streak;
			}
		}

		private bool _cursorShown
		{
			get
			{
				return __cursorShown;
			}
			set
			{
				if (value == __cursorShown)
				{
					return;
				}

				if (value)
				{
                    Cursor.Show();
				}
				else
				{
                    Cursor.Hide();
				}

				__cursorShown = value;
			}
		}

        public frmMain()
        {
            _morseProcessor = new MorseProcessor(_morseInterval, _morsePitch);
            _listOfValidKeys = new List<Keys>();
            _timer = new System.Windows.Forms.Timer { Interval = 1 };

            InitializeComponent();
            fillValidKeys();
        }

        private void frmMain_Load(object sender, EventArgs e)
		{
            txtInput.Text = "";
			lblSymbolToTranslate.Text = "";
            lblTranslation.Text = "";
            lblHint.Text = "";
            lblStreak.Text = "";
			lblMistakeReminder.Text = "";
			nudMorseInterval.Value = _morseInterval;
			nudMorsePitch.Value = _morsePitch;

			//Before setting event handlers so SelectedIndexChanged doesn't trigger
			cboLanguage.DataSource = GeneralTools.GetLanguages();
            cboLanguage.SelectedIndex = 0;

            Resize += frmMain_Resize;
            Click += frmMain_Click;
            txtInput.KeyDown += txtInput_KeyDown;
            txtInput.KeyUp += txtInput_KeyUp;
			txtInput.TextChanged += txtInput_TextChanged;
            lblStreak.Click += lblStreak_Click;
            rbnLetterToMorse.CheckedChanged += rbnSelectionChanged;
            rbnMorseToLetter.CheckedChanged += rbnSelectionChanged;
			rbnWordToMorse.CheckedChanged += rbnSelectionChanged;
            rbnMorseToWord.CheckedChanged += rbnSelectionChanged;
            rbnMorseToLetterHearing.CheckedChanged += rbnSelectionChanged;
            rbnMorseToWordHearing.CheckedChanged += rbnSelectionChanged;
			cboLanguage.SelectedIndexChanged += cboLanguage_SelectedIndexChanged;
			chkShowMorseTranslation.CheckedChanged += chkShowMorseTranslation_CheckedChanged;
			nudMorseInterval.ValueChanged += nudMorseSoundParameters_ValueChanged;
            nudMorsePitch.ValueChanged += nudMorseSoundParameters_ValueChanged;
            _timer.Tick += timer_Tick;
			FormClosing += (object Sender, FormClosingEventArgs E) => _morseProcessor.StopMorseSound();

			//Triggers SetNextSymbol intentionally, set the shown symbol to translate initially when starting up the application
            rbnLetterToMorse.Checked = true;
			_streak = 0;
            _timer.Start();

            frmMain_Resize(null, null);
        }

		/// <summary>
		/// Place all controls at their designated horizontal positions 
		/// Keeps vertical positions
		/// </summary>
		private void frmMain_Resize(object sender, EventArgs e)
		{
			//For some reason, Size.Width is 1936 when maximized, which shifts everything a little to the right
			//Compensate by subtracting 16 :)
			int formSize = Size.Width - 16;

            txtInput.Width = (int)(formSize * 0.4);

			txtInput.Left = (int)(formSize * 0.5 - txtInput.Size.Width / 2);
            lblSymbolToTranslate.Left = (int)(formSize * 0.5 - lblSymbolToTranslate.Size.Width / 2);
            lblTranslation.Left = (int)(formSize * 0.5 - lblTranslation.Size.Width / 2);
            lblHint.Left = (int)(formSize * 0.5 - lblHint.Size.Width / 2);
            lblStreak.Left = (int)(formSize * 0.15 - lblStreak.Size.Width / 2);
            lblMistakeReminder.Left = (int)(formSize * 0.85 - lblMistakeReminder.Size.Width / 2);
        }

        private void frmMain_Click(object sender, EventArgs e)
        {
			_cursorShown = true;
        }

        private void txtInput_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return) e.SuppressKeyPress = true;
        }

		private void txtInput_TextChanged(object sender, EventArgs e)
		{
            showInputMorseTranslation();
        }

		/// <summary>
		/// Show a temporary translation of the input text if translating from morse to text
		/// This is done because it can be very annoying not knowing what you did wrong when making a mistake in long words
		/// </summary>
        private void showInputMorseTranslation()
        {
            if (_learningMode != LearningMode.TextFirstWord || !chkShowMorseTranslation.Checked) return;
            if (txtInput.Text == "") { lblTranslation.Text = ""; return; }

            lblTranslation.Text = _morseProcessor.MorseToText(txtInput.Text.Trim());
            frmMain_Resize(null, null);
        }

		/// <summary>
		/// This function handles all user input regarding translation logic.
		/// It resets the input text if the input is not valid for the current relevant translation.
		/// It shows a hint if applicable or the result directly when pressing space
		/// </summary>
        private void txtInput_KeyUp(object sender, KeyEventArgs e)
		{
			if (!_listOfValidKeys.Contains(e.KeyCode)) { txtInput.Clear(); return; }

            string correctAnswer = "";
			string hint = "";
            switch (_learningMode)
            {
                case LearningMode.TextFirstLetter:
                    correctAnswer = _currentLetter.MorseCode;
					hint = _currentLetter.GoogleHint;
                    break;
                case LearningMode.TextFirstWord:
                    correctAnswer = _currentWord.MorseCode;
                    break;
                case LearningMode.MorseFirstLetter:
                    correctAnswer = _currentLetter.Character;
					if (_hearing) hint = "Listen..."; 
                    break;
                case LearningMode.MorseFirstWord:
                    correctAnswer = _currentWord.Word;
                    if (_hearing) hint = "Listen...";
                    break;
            }
			if (hint == "") hint = correctAnswer;

			_cursorShown = false;
			txtInput.Update();

			//Space is to show hints
			if (e.KeyCode == Keys.Space)
			{
				if (_learningMode == LearningMode.TextFirstWord) return;
				txtInput.Clear();
				if (lblHint.Text == "") {
					lblHint.Text = hint;
                    if (!_hearing) _streak = 0;
                } else {
					lblHint.Text = correctAnswer;
                    _streak = 0;
                }
				if (_hearing)
				{
                    _morseProcessor.SoundMorse(getCurrentMorseToSound());
				}
                frmMain_Resize(null, null);
            }
			//Determine whether the input text is correct after pressing enter
			//Don't require inputting space when you only have to input one letter since the input won't be more than one letter anyway and any input is the final answer
			else if (e.KeyCode == Keys.Return || _learningMode == LearningMode.MorseFirstLetter)
			{
				showResult(txtInput.Text.ToLower().Trim() == correctAnswer.ToLower().Trim());
			}
			//When Strict mode is enabled, don't let the user backspace and instead treat is as a wrong input
			else if (e.KeyCode == Keys.Back && chkStrictMode.Checked)
			{
				showResult(false);
            }
			else if ((_learningMode == LearningMode.TextFirstLetter || _learningMode == LearningMode.TextFirstWord)
				!= (e.KeyCode == Keys.OemMinus || e.KeyCode == Keys.OemPeriod || e.KeyCode == Keys.Back))
			{
				txtInput.Clear(); 
			}
			e.Handled = true;
			e.SuppressKeyPress = true;
		}

		
		/// <returns>The current symbol to translate (either the current letter or the current word)</returns>
		private string getCurrentMorseToSound()
		{
            string morse = "";
            switch (_learningMode)
            {
                case LearningMode.MorseFirstLetter:
                    morse = _currentLetter.MorseCode;
                    break;
                case LearningMode.MorseFirstWord:
                    morse = _currentWord.MorseCode;
                    break;
            };
			return morse;
        }

		/// <summary>
		/// Display whether the text input was correct, and show a new symbol if it was
		/// </summary>
		private void showResult(bool isCorrect)
		{
            if (isCorrect)
			{
                txtInput.BackColor = Color.Green;
                setNextSymbol();
                _streak++;
            }
			else
			{
                if (_learningMode == LearningMode.TextFirstWord)
                {
                    lblMistakeReminder.Text = "Your input was: " + Environment.NewLine + _morseProcessor.MorseToText(txtInput.Text.Trim());
                    frmMain_Resize(null, null);
                }

                _streak = 0;
                txtInput.BackColor = Color.Red;
                if (_hearing) _morseProcessor.SoundMorse(getCurrentMorseToSound());
            }
            txtInput.Clear();
        }

		/// <summary>
		/// This function sets the next symbol to translate, a symbol being the next word or letter
		/// </summary>
		private void setNextSymbol()
		{
            lblHint.Text = "";
            lblTranslation.Text = "";
            lblMistakeReminder.Text = "";

            switch (_learningMode)
			{
				case LearningMode.TextFirstLetter:
				case LearningMode.MorseFirstLetter:
					_currentLetter = _morseProcessor.GetRandomLetter();
                    break;
				case LearningMode.TextFirstWord:
				case LearningMode.MorseFirstWord:
					_currentWord = _morseProcessor.GetRandomWord(cboLanguage.Text);
                    break;
            }

            switch (_learningMode)
            {
                case LearningMode.TextFirstLetter:
					lblSymbolToTranslate.Text = _currentLetter.Character;
					break;
                case LearningMode.TextFirstWord:
					lblSymbolToTranslate.Text = _currentWord.Word;
					break;
                case LearningMode.MorseFirstLetter:
                    if (!_hearing) 
					{
						lblSymbolToTranslate.Text = _currentLetter.MorseCode; 
					} 
					else
					{
						lblSymbolToTranslate.Text = ""; _morseProcessor.SoundMorse(getCurrentMorseToSound());
					}
                    break;
                case LearningMode.MorseFirstWord:
                    if (!_hearing) 
					{
						lblSymbolToTranslate.Text = _currentWord.MorseCode;
					} 
					else 
					{
						lblSymbolToTranslate.Text = "";
						_morseProcessor.SoundMorse(getCurrentMorseToSound());
					}
                    break;
            }
            frmMain_Resize(null, null);
        }

		/// <summary>
		/// Fade txtInput back to its default color when its color is set to something else (like red or green after enter is pressed)
		/// </summary>
		private void timer_Tick(object sender, EventArgs e)
		{
			txtInput.BackColor = Color.FromArgb(Math.Min(txtInput.BackColor.R + 2, 255), Math.Min(txtInput.BackColor.G + 2, 255), Math.Min(txtInput.BackColor.B + 2, 255));
		}

		/// <summary>
		/// Reset the streak if you click on it (because sometimes you just misinput :^))
		/// </summary>
		private void lblStreak_Click(object sender, EventArgs e)
		{
			_streak = _streakSave;
			lblStreak.Text = "Streak:" + Environment.NewLine + _streak.ToString();
		}

        private void cboLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
			if (_learningMode == LearningMode.TextFirstWord || _learningMode == LearningMode.MorseFirstWord) setNextSymbol();
        }

		/// <summary>
		/// Ensure the translation is shown or hidden after the checkbox is clicked
		/// </summary>
		private void chkShowMorseTranslation_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox chkShowMorseTranslation = (CheckBox)sender;
			if (chkShowMorseTranslation.Checked)
			{
				showInputMorseTranslation();
			}
			else
			{
				lblTranslation.Text = "";
			}
		}

		/// <summary>
		/// Change the translation mode and show the next symbol to translate
		/// </summary>
        private void rbnSelectionChanged(object sender, EventArgs e)
        {
			_morseProcessor.StopMorseSound();
            RadioButton rbnSender = (RadioButton)sender;
            if (!rbnSender.Checked) return;
            if (rbnLetterToMorse.Checked) _learningMode = LearningMode.TextFirstLetter;
            if (rbnWordToMorse.Checked) _learningMode = LearningMode.TextFirstWord;
            if (rbnMorseToLetter.Checked || rbnMorseToLetterHearing.Checked) _learningMode = LearningMode.MorseFirstLetter;
            if (rbnMorseToWord.Checked || rbnMorseToWordHearing.Checked) _learningMode = LearningMode.MorseFirstWord;
            _hearing = rbnMorseToLetterHearing.Checked || rbnMorseToWordHearing.Checked;
            lblHint.Text = "";
			lblMistakeReminder.Text = "";
            setNextSymbol();
        }

		private void nudMorseSoundParameters_ValueChanged(object sender, EventArgs e)
		{
			_morseProcessor.MorseInterval = (int)nudMorseInterval.Value;
            _morseProcessor.MorsePitch = (int)nudMorsePitch.Value;
        }

        /// <summary>
        /// Fills the list of valid keys with all valid keys, those being Backspace, Enter, Space, a-z, dash and dot
        /// </summary>
        private void fillValidKeys()
		{
			foreach (Keys key in Enum.GetValues(typeof(Keys)))
			{
				int keyIndex = (int)key;
				if (keyIndex == 8 || keyIndex == 13 || keyIndex == 32 || (keyIndex >= 65 && keyIndex <= 90) || keyIndex == 189 || keyIndex == 190)
				{
					_listOfValidKeys.Add(key);
				}
			}
        }
    }

    public static class StringExtensions
	{
        public static string RemoveSpecialCharacters(this string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
				if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z'))
				{
					sb.Append(c);
				}
			}
            return sb.ToString();
        }
    }

    public enum LearningMode
	{
		TextFirstLetter,
        TextFirstWord,
        MorseFirstLetter,
        MorseFirstWord
	}
}