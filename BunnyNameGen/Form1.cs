using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BunnyNameGen
{
    public partial class Form1 : Form
    {
        List<string> datasetNames;
        // Gotta be honest and say I have no idea what I was doing with this.
        // It certainly looks interesting though and seems to do the job
        Dictionary<string, Dictionary<string, Dictionary<string, List<string>>>> datasets;
        Random rand;

        const string DefaultDatasetsFile = "Datasets/DatasetNames.txt";

        public Form1()
        {
            InitializeComponent();

            datasetNames = new List<string>();
            datasets = new Dictionary<string, Dictionary<string, Dictionary<string, List<string>>>>();
            rand = new Random();

            loadAllDatasets();
        }

        private void loadAllDatasets()
        {
            if(File.Exists(DefaultDatasetsFile))
            {
                string line;
                StreamReader datasetsFile = new StreamReader(DefaultDatasetsFile);
                while ((line = datasetsFile.ReadLine()) != null)
                {
                    datasetNames.Add(line);
                }
                datasetsFile.Close();
            }
            else
            {
                SSLabel1.Text = "ERROR: COULD NOT FIND " + DefaultDatasetsFile + ". NO DATASETS LOADED";
            }

            foreach (string s in datasetNames)
            {
                loadDataset(s);
            }

            CB_Datasets.DataSource = datasetNames;
        }

        private void loadDataset(string datasetName)
        {
            Dictionary<string, Dictionary<string, List<string>>> newDataset = new Dictionary<string, Dictionary<string, List<string>>>();
            newDataset.Add("first_pairs", new Dictionary<string, List<string>>());
            newDataset.Add("normal_pairs", new Dictionary<string, List<string>>());
            newDataset.Add("fixes", new Dictionary<string, List<string>>());

            List<string> fileWords = new List<string>();

            if (File.Exists("Datasets/" + datasetName + ".txt"))
            {
                string line;
                StreamReader datasetFile = new StreamReader("Datasets/" + datasetName + ".txt");

                while ((line = datasetFile.ReadLine()) != null)
                {
                    string[] lineWords = line.Split(' ');

                    foreach (string w in lineWords)
                    {
                        fileWords.Add(w);
                    }
                }

                datasetFile.Close();
            }
            else
            {
                SSLabel1.Text = "ERROR: COULD NOT FIND " + datasetName + " FILE. NOT LOADED";
            }

            // Load all pairs
            foreach (string w in fileWords)
            {
                string w2;

                if (w == "") continue;
                if (w.Length == 1) continue;
                if (w.Length == 2)
                {
                    w2 = (w + " ").ToLower();
                    if (!newDataset["first_pairs"].ContainsKey(w2.Substring(0, 2)))
                    {
                        newDataset["first_pairs"].Add(w2.Substring(0, 2), new List<string>());
                        newDataset["first_pairs"][w2.Substring(0, 2)].Add(w2.Substring(2, 1));
                    }
                    else
                    {
                        if (!newDataset["first_pairs"][w2.Substring(0, 2)].Contains(w2.Substring(2, 1)))
                        {
                            newDataset["first_pairs"][w2.Substring(0, 2)].Add(w2.Substring(2, 1));
                        }
                    }
                }

                w2 = (w + " ").ToLower();

                string pairing;
                pairing = w2.Substring(0, 3);
                if (!newDataset["first_pairs"].ContainsKey(pairing.Substring(0, 2)))
                {
                    newDataset["first_pairs"].Add(pairing.Substring(0, 2), new List<string>());
                    newDataset["first_pairs"][pairing.Substring(0, 2)].Add(pairing.Substring(2, 1));
                }
                else
                {
                    if (!newDataset["first_pairs"][pairing.Substring(0, 2)].Contains(pairing.Substring(2, 1)))
                    {
                        newDataset["first_pairs"][pairing.Substring(0, 2)].Add(pairing.Substring(2, 1));
                    }
                }


                for (int i = 0; i < w2.Length - 2; i++)
                {
                    pairing = w2.Substring(i, 3);
                    if (!newDataset["normal_pairs"].ContainsKey(pairing.Substring(0, 2)))
                    {
                        newDataset["normal_pairs"].Add(pairing.Substring(0, 2), new List<string>());
                        newDataset["normal_pairs"][pairing.Substring(0, 2)].Add(pairing.Substring(2, 1));
                    }
                    else
                    {
                        if (!newDataset["normal_pairs"][pairing.Substring(0, 2)].Contains(pairing.Substring(2, 1)))
                        {
                            newDataset["normal_pairs"][pairing.Substring(0, 2)].Add(pairing.Substring(2, 1));
                        }
                    }
                }
            }

            // create affixes
            newDataset["fixes"].Add("prefixes", new List<string>());
            newDataset["fixes"].Add("suffixes", new List<string>());
            int limit = fileWords.Count / 10;
            int found = 0;
            int fixLength = rand.Next(3) + 2;

            while (found < limit)
            {
                string fix;
                bool prefix = false;
                string word = fileWords.ElementAt<string>(rand.Next(fileWords.Count));

                if (fixLength > word.Length)
                    continue;

                if (rand.Next(1, 3) == 3)
                {
                    fix = word.Substring(0, fixLength);
                    prefix = true;
                }
                else
                {
                    fix = word.Substring(word.Length - fixLength);
                }

                if (Regex.Match(fix, "[aeiouy]").Success)
                {
                    found++;
                    if (prefix)
                        newDataset["fixes"]["prefixes"].Add(fix);
                    else
                        newDataset["fixes"]["suffixes"].Add(fix);
                }
            }

            datasets.Add(datasetName, newDataset);
        }

        private void BT_GenerateData_Click(object sender, EventArgs e)
        {
            string textBoxText = "";

            if (CheckProperNames.Checked)
            {
                for (int i = 0; i < NUD_NumberOfNames.Value; i++)
                {
                    string newName = "";
                    for (int i2 = 0; i2 < NUD_NumberOfNames.Value; i2++)
                    {
                        string newWord = generateWord();

                        if (newWord.Length >= NUD_MinWordLength.Value && newWord.Length <= NUD_MaxWordLength.Value)
                            newName = newName + " " + newWord;
                        else
                            i2--;
                    }
                    textBoxText += CultureInfo.CurrentCulture.TextInfo.ToTitleCase(newName.Substring(1).ToLower()) + Environment.NewLine;
                }
            }
            else
            {
                for (int i = 0; i < NUD_NumberOfNames.Value; i++)
                {
                    string newWord = generateWord();

                    if (newWord.Length >= NUD_MinWordLength.Value && newWord.Length <= NUD_MaxWordLength.Value)
                        textBoxText += CultureInfo.CurrentCulture.TextInfo.ToTitleCase(newWord.ToLower()) + Environment.NewLine;
                    else
                        i--;
                }
            }
                        
            TB_GeneratedNames.Text = textBoxText;
        }

        private string generateWord()
        {
            string newWord;

            int FPsize = datasets[datasetNames[CB_Datasets.SelectedIndex]]["first_pairs"].Count;
            newWord = datasets[datasetNames[CB_Datasets.SelectedIndex]]["first_pairs"].Keys.ElementAt<string>(rand.Next(FPsize));

            bool wordComplete = false;
            int wordLength = rand.Next((int)NUD_MinWordLength.Value, (int)NUD_MaxWordLength.Value);
            while (!wordComplete)
            {
                int size = datasets[datasetNames[CB_Datasets.SelectedIndex]]["normal_pairs"][newWord.Substring(newWord.Length - 2)].Count;
                string nextChar = datasets[datasetNames[CB_Datasets.SelectedIndex]]["normal_pairs"][newWord.Substring(newWord.Length - 2)].ElementAt<string>(rand.Next(size));

                newWord = newWord + nextChar;
                if (newWord.Length == wordLength)
                    wordComplete = true;

                if (nextChar == " ")
                {
                    if (newWord.Length > NUD_MinWordLength.Value + 1)
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
            int prefixSize = datasets[datasetNames[CB_Datasets.SelectedIndex]]["fixes"]["prefixes"].Count;
            string prefix = datasets[datasetNames[CB_Datasets.SelectedIndex]]["fixes"]["prefixes"].ElementAt<string>(rand.Next(prefixSize));
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
            int suffixSize = datasets[datasetNames[CB_Datasets.SelectedIndex]]["fixes"]["suffixes"].Count;
            string suffix = datasets[datasetNames[CB_Datasets.SelectedIndex]]["fixes"]["suffixes"].ElementAt<string>(rand.Next(suffixSize));
            string wordOut = "";

            if (Regex.Match(suffix, "^[aeiouy]").Success)
                chopToFit = true;

            if (Regex.Match(wordIn, "[aeiouy]$").Success && chopToFit)
                wordOut = suffix + wordIn.Substring(0, wordIn.Length - 1);
            else
                wordOut = suffix + wordIn;

            return wordOut;
        }

        private void CheckProperNames_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckProperNames.Checked)
            {
                LB_NumberOfNames.Enabled = true;
                NUD_NumberOfNames.Enabled = true;
            }
            else
            {
                LB_NumberOfNames.Enabled = false;
                NUD_NumberOfNames.Enabled = false;
            }
        }
    }
}
