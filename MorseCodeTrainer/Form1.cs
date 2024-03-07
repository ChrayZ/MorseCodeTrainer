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

namespace MorseCodeTrainer
{
	public partial class MainForm : Form
	{
		private List<LetterData> _listOfLetters;
		private List<Keys> _listOfValidKeys;
		private Random _random;
		private System.Windows.Forms.Timer _timer;
		private int __streak;
		private int _streakSave;
		private string[] _words;
		private LearningMode _learningMode;
		private bool _hearing = false;
		private WordData _currentWord;
		private LetterData _currentLetter;
		private Thread beepThread;
        private bool __cursorShown = true;

		private int _streak
		{
			get { return __streak; }
			set 
			{
				__streak = value;
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
					System.Windows.Forms.Cursor.Show();
				}
				else
				{
					System.Windows.Forms.Cursor.Hide();
				}

				__cursorShown = value;
			}
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			txtInput.Left = (ClientSize.Width - txtInput.Size.Width) / 2;
			lblStreak.Left = ClientSize.Width / 4 - txtInput.Size.Width;
			_words = File.ReadAllText("words.txt").Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            Click += MainForm_Click;
            txtInput.KeyDown += txtInput_KeyDown;
			txtInput.KeyUp += txtInput_KeyUp;
            lblStreak.Click += lblStreak_Click;
			rbnLetterToMorse.CheckedChanged += rbnSelectionChanged;
            rbnMorseToLetter.CheckedChanged += rbnSelectionChanged;
            rbnMorseToLetterHearing.CheckedChanged += rbnSelectionChanged;
            rbnMorseToWordHearing.CheckedChanged += rbnSelectionChanged;
			_timer.Tick += timer_Tick;
			rbnLetterToMorse.Checked = true;
        }

		public MainForm()
		{
			_listOfLetters = new List<LetterData>();
            _listOfValidKeys = new List<Keys>();
            _random = new Random((int)(DateTime.Now.Ticks % int.MaxValue));
			_timer = new System.Windows.Forms.Timer { Interval = 1 };
			_timer.Start();


            InitializeComponent();
			FillLetters();
			FillValidKeys();
		}

        private void MainForm_Click(object sender, EventArgs e)
        {
			_cursorShown = true;
        }

        private void rbnSelectionChanged(object sender, EventArgs e)
        {
            RadioButton rbnSender = (RadioButton)sender;
            if (!rbnSender.Checked) return;
            if (rbnLetterToMorse.Checked) _learningMode = LearningMode.TextFirstLetter;
            if (rbnMorseToLetter.Checked || rbnMorseToLetterHearing.Checked) _learningMode = LearningMode.MorseFirstLetter;
            if (rbnMorseToWordHearing.Checked) _learningMode = LearningMode.MorseFirstWord;
            _hearing = rbnMorseToLetterHearing.Checked || rbnMorseToWordHearing.Checked;
            SetNextSymbol();
        }

        private void txtInput_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return) e.SuppressKeyPress = true;
		}

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
					hint = "Listen...";
                    break;
                case LearningMode.MorseFirstWord:
                    correctAnswer = _currentWord.Word;
					hint = "Listen...";
                    break;
            }
			if (hint == "") hint = correctAnswer;

			_cursorShown = false;
			txtInput.Update();

			if (e.KeyCode == Keys.Space)
			{
				txtInput.Clear();
				if (lblHint.Text == "") {
					lblHint.Text = hint;
                    if (!_hearing) _streak = 0;
                } else {
					lblHint.Text = correctAnswer;
                    _streak = 0;
                }
				if (_hearing) SoundMorse();
                lblHint.Left = (ClientSize.Width - lblHint.Size.Width) / 2;
			}
			else if (e.KeyCode == Keys.Return || _learningMode == LearningMode.MorseFirstLetter)
			{
				lblHint.Text = "";
				if (txtInput.Text.ToLower() == correctAnswer.ToLower())
				{
					txtInput.BackColor = Color.Green;
					SetNextSymbol();
					_streak++;
				}
				else
				{
					_streak = 0;
					txtInput.BackColor = Color.Red;
					if (_hearing) SoundMorse();
                }
				txtInput.Text = "";
			}
			else if ((_learningMode == LearningMode.TextFirstLetter || _learningMode == LearningMode.TextFirstWord)
				!= (e.KeyCode == Keys.OemMinus || e.KeyCode == Keys.OemPeriod || e.KeyCode == Keys.Back))
			{
				txtInput.Clear();
			}
			e.Handled = true;
			e.SuppressKeyPress = true;
		}

		private void SetNextSymbol()
		{
			switch (_learningMode)
			{
				case LearningMode.TextFirstLetter:
				case LearningMode.MorseFirstLetter:
                    _currentLetter = _listOfLetters[_random.Next(_listOfLetters.Count)];;
                    break;
				case LearningMode.TextFirstWord:
				case LearningMode.MorseFirstWord:
					string word = _words[_random.Next(_words.Length)];
					_currentWord = new WordData(word, WordToMorse(word.RemoveSpecialCharacters()));
					break;
            }

            switch (_learningMode)
            {
                case LearningMode.TextFirstLetter:
                case LearningMode.TextFirstWord:
					lblNextLetter.Text = _currentLetter.Character;
					break;
                case LearningMode.MorseFirstLetter:
                    if (!_hearing) { lblNextLetter.Text = _currentLetter.MorseCode; } else { lblNextLetter.Text = ""; SoundMorse(); }
                    break;
                case LearningMode.MorseFirstWord:
                    if (!_hearing) { lblNextLetter.Text = _currentWord.MorseCode; } else { lblNextLetter.Text = ""; SoundMorse(); }
                    break;
            }
            lblNextLetter.Left = (ClientSize.Width - lblNextLetter.Size.Width) / 2;
        }

		private void timer_Tick(object sender, EventArgs e)
		{
			txtInput.BackColor = Color.FromArgb(Math.Min(txtInput.BackColor.R + 2, 255), Math.Min(txtInput.BackColor.G + 2, 255), Math.Min(txtInput.BackColor.B + 2, 255));
		}

		private void lblStreak_Click(object sender, EventArgs e)
		{
			_streak = _streakSave;
			lblStreak.Text = "Streak:" + Environment.NewLine + _streak.ToString();
		}

		private void FillLetters()
		{
			_listOfLetters.Add(new LetterData("A", ".-", "Archery"));
			_listOfLetters.Add(new LetterData("B", "-...", "Banjo"));
			_listOfLetters.Add(new LetterData("C", "-.-.", "Candy"));
			_listOfLetters.Add(new LetterData("D", "-..", "Dog"));
			_listOfLetters.Add(new LetterData("E", ".", "Eye"));
			_listOfLetters.Add(new LetterData("F", "..-.", "Firetruck"));
			_listOfLetters.Add(new LetterData("G", "--.", "Giraffe"));
			_listOfLetters.Add(new LetterData("H", "....", "Hippo"));
			_listOfLetters.Add(new LetterData("I", "..", "Insect"));
			_listOfLetters.Add(new LetterData("J", ".---", "Jet"));
			_listOfLetters.Add(new LetterData("K", "-.-", "Kite"));
			_listOfLetters.Add(new LetterData("L", ".-..", "Lab"));
			_listOfLetters.Add(new LetterData("M", "--", "Mustache"));
			_listOfLetters.Add(new LetterData("N", "-.", "Net"));
			_listOfLetters.Add(new LetterData("O", "---", "Orchestra"));
			_listOfLetters.Add(new LetterData("P", ".--.", "Paddles"));
			_listOfLetters.Add(new LetterData("Q", "--.-", "Quarterback"));
			_listOfLetters.Add(new LetterData("R", ".-.", "Robot"));
			_listOfLetters.Add(new LetterData("S", "...", "Submarine"));
			_listOfLetters.Add(new LetterData("T", "-", "Tape"));
			_listOfLetters.Add(new LetterData("U", "..-", "Unicorn"));
			_listOfLetters.Add(new LetterData("V", "...-", "Vacuum"));
			_listOfLetters.Add(new LetterData("W", ".--", "Wand"));
			_listOfLetters.Add(new LetterData("X", "-..-", "X-Ray"));
			_listOfLetters.Add(new LetterData("Y", "-.--", "Yard"));
			_listOfLetters.Add(new LetterData("Z", "--..", "Zebra"));
		}

		private void FillValidKeys()
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

		private string WordToMorse(string word)
		{
			string morseString = "";
			foreach (char c in word)
			{
				LetterData letter = _listOfLetters.Where(x => x.Character.ToLower() == c.ToString().ToLower()).First();
				morseString += letter.MorseCode + " ";
			}
			return morseString.Trim();
		}

		private void SoundMorse()
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
            }

            beepThread?.Abort();

			Func<string, int, int, int> soundMorseLambda = (string pMorse, int pMorseInterval, int pMorsePitch) =>
			{
                foreach (char morseSign in pMorse)
                {
                    if (morseSign == '-') Console.Beep(pMorsePitch, pMorseInterval * 3);
                    if (morseSign == '.') Console.Beep(pMorsePitch, pMorseInterval);
                    if (morseSign == ' ') System.Threading.Thread.Sleep(pMorseInterval);
                    System.Threading.Thread.Sleep(pMorseInterval);
                }
                return 1;
            };
            beepThread = new Thread(() => soundMorseLambda(morse, (int)nudMorseInterval.Value, (int)nudMorsePitch.Value));
			
            FormClosing += (object sender, FormClosingEventArgs e) => beepThread.Abort();
            beepThread.Start();
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

    public class LetterData
	{
		public string Character;
		public string MorseCode;
		public string GoogleHint;

		public LetterData(string pCharacter, string pInMorseCode, string pGoogleHint)
		{
			Character = pCharacter;
			MorseCode = pInMorseCode;
			GoogleHint = pGoogleHint;
		}
	}

    public class WordData
    {
        public string Word;
        public string MorseCode;

        public WordData(string pWord, string pMorse)
        {
            Word = pWord;
			MorseCode = pMorse;
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