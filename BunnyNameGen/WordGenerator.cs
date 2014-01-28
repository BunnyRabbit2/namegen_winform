using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BunnyNameGen
{
    class WordGenerator
    {
        private Random rand;
        private Dictionary<string, Dictionary<string, List<string>>> datasetPairs;

        public WordGenerator()
        {
            rand = new Random();
        }

        public string GenerateWord(Dataset datasetIn, int minLength, int maxLength)
        {
            datasetPairs = datasetIn.GetPairs();
            string name = datasetIn.GetName();

            string newWord;

            int FPsize = datasetPairs["first_pairs"].Count;
            newWord = datasetPairs["first_pairs"].Keys.ElementAt<string>(rand.Next(FPsize));

            bool wordComplete = false;
            int wordLength = rand.Next(minLength, maxLength);
            while (!wordComplete)
            {
                int size = datasetPairs["normal_pairs"][newWord.Substring(newWord.Length - 2)].Count;
                string nextChar = datasetPairs["normal_pairs"][newWord.Substring(newWord.Length - 2)].ElementAt<string>(rand.Next(size));

                newWord = newWord + nextChar;
                if (newWord.Length == wordLength)
                    wordComplete = true;

                if (nextChar == " ")
                {
                    if (newWord.Length > minLength + 1)
                        wordComplete = true;
                    else
                        return "";
                }

                if (wordComplete)
                    if (rand.Next(1, 3) == 3)
                        if (rand.Next(1, 2) == 1)
                            newWord = addPrefix(newWord);
                        else
                            newWord = addSuffix(newWord);
            }

            return newWord;
        }

        private string addPrefix(string wordIn)
        {
            bool chopToFit = false;
            int prefixSize = datasetPairs["fixes"]["prefixes"].Count;
            string prefix = datasetPairs["fixes"]["prefixes"].ElementAt<string>(rand.Next(prefixSize));
            string wordOut = "";

            if (Regex.Match(prefix, "[aeiouy]$").Success)
                chopToFit = true;

            if (Regex.Match(wordIn, "^[aeiouy]").Success && chopToFit)
                wordOut = prefix + wordIn.Substring(1);
            else
                wordOut = prefix + wordIn;

            return wordOut;
        }

        private string addSuffix(string wordIn)
        {
            bool chopToFit = false;
            int suffixSize = datasetPairs["fixes"]["suffixes"].Count;
            string suffix = datasetPairs["fixes"]["suffixes"].ElementAt<string>(rand.Next(suffixSize));
            string wordOut = "";

            if (Regex.Match(suffix, "^[aeiouy]").Success)
                chopToFit = true;

            if (Regex.Match(wordIn, "[aeiouy]$").Success && chopToFit)
                wordOut = suffix + wordIn.Substring(0, wordIn.Length - 1);
            else
                wordOut = suffix + wordIn;

            return wordOut;
        }
    }
}
