using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MorseCodeTrainer
{
    internal class MorseProcessor
    {
        private List<LetterData> _listOfLetters;
        private Thread _beepThread;
        private Random _random;
        private Dictionary<string, string[]> _words;
        private EventHandler _stopMorseSoundEvent;

        public int MorseInterval;
        public int MorsePitch;

        public MorseProcessor(int morseInterval, int morsePitch)
        {
            MorseInterval = morseInterval;
            MorsePitch = morsePitch;

            _listOfLetters = new List<LetterData>();
            _words = new Dictionary<string, string[]>();
            _random = new Random((int)(DateTime.Now.Ticks % int.MaxValue));

            FillLetters();
            FillWords();
        }

        public LetterData GetRandomLetter()
        {
            return _listOfLetters[_random.Next(_listOfLetters.Count)];
        }

        public WordData GetRandomWord(string language)
        {
            string word = _words[language][_random.Next(_words[language].Length)];
            return new WordData(word, TextToMorse(word));
        }

        //Translates some text into its morse representation
        public string TextToMorse(string text)
        {
            string morseString = "";
            foreach (char c in text)
            {
                LetterData letter = _listOfLetters.Where(x => x.Character.ToLower() == c.ToString().ToLower()).First();
                morseString += letter.MorseCode + " ";
            }
            return morseString.Trim();
        }

        //Parses some morse code back into its text form
        public string MorseToText(string morse)
        {
            string[] morseCharacters = morse.Split(' ');
            string resultWord = "";
            foreach (string morseCharacter in morseCharacters)
            {
                LetterData letter = _listOfLetters.Find(x => x.MorseCode == morseCharacter);
                resultWord += letter is null ? "?" : letter.Character.ToLower();
            }
            return resultWord;
        }

        /// <summary>
        /// Makes sounds for a given morse text's dashes and dots according to standard morse rules
        /// One interval of sound for a dot, three intervals of sound for a dash, three intervals of quiet for a new letter
        /// It WOULD be seven intervals for a new word, but this function does not do words yet
        /// </summary>
        public void SoundMorse(string morse)
        {
            _beepThread?.Interrupt();

            Func<string, int, int, int> soundMorseLambda = (string morseString, int morseInterval, int morsePitch) =>
            {
                try
                {
                    foreach (char morseSign in morseString)
                    {
                        if (morseSign == '-') Console.Beep(morsePitch, morseInterval * 3);
                        if (morseSign == '.') Console.Beep(morsePitch, morseInterval);
                        if (morseSign == ' ') System.Threading.Thread.Sleep(morseInterval);
                        System.Threading.Thread.Sleep(morseInterval);
                    }
                    return 0;
                }
                catch { return 1; }
            };
            _beepThread = new Thread(() => soundMorseLambda(morse, MorseInterval, MorsePitch));

             _stopMorseSoundEvent += (object sender, EventArgs e) => _beepThread.Interrupt();
            _beepThread.Start();
        }

        public void StopMorseSound()
        {
            if (_stopMorseSoundEvent != null) _stopMorseSoundEvent(null, null);
        }

        private void FillWords()
        {
            foreach (string language in GeneralTools.GetLanguages())
            {
                string[] languageWords = File.ReadAllText("Words" + language + ".txt").Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                _words.Add(language, languageWords);
            }
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
    }

    public class LetterData
    {
        public string Character;
        public string MorseCode;
        public string GoogleHint;

        public LetterData(string character, string morseCode, string googleHint)
        {
            Character = character;
            MorseCode = morseCode;
            GoogleHint = googleHint;
        }
    }

    public class WordData
    {
        public string Word;
        public string MorseCode;

        public WordData(string word, string morseCode)
        {
            Word = word;
            MorseCode = morseCode;
        }
    }
}
