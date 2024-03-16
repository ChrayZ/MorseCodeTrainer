using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorseCodeTrainer
{
    static public class GeneralTools
    {
        /// <summary>
        /// All files containing the words for a language in this application are to be input in the format "Words" + languageCode + ".txt"
        /// This function returns all files in that format
        /// </summary>
        public static string[] GetLanguages()
        {
            List<string> languages = new List<string>();
            foreach (string file in Directory.GetFiles(Directory.GetCurrentDirectory()))
            {
                string fileName = Path.GetFileName(file);
                if (fileName.StartsWith("Words"))
                {
                    languages.Add(fileName.Substring(5, 2));
                }
            }
            return languages.ToArray();
        }
    }
}
