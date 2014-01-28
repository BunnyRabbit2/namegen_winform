using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;

namespace BunnyNameGen
{
    class Dataset
    {
        Random rand;

        private string name;
        private List<string> datasetWords;
        private Dictionary<string, Dictionary<string, List<string>>> dataPairs;

        public Dataset()
        {
            dataPairs = new Dictionary<string, Dictionary<string, List<string>>>();
            dataPairs.Add("first_pairs", new Dictionary<string, List<string>>());
            dataPairs.Add("normal_pairs", new Dictionary<string, List<string>>());
            dataPairs.Add("fixes", new Dictionary<string, List<string>>());

            datasetWords = new List<string>();

            rand = new Random();
        }

        public bool loadDatasetTxt(string nameIn)
        {
            name = nameIn;
            string datasetName = name + ".txt";

            if (File.Exists(datasetName))
            {
                string line;
                // Don't know if it's right to use that encoding on every file but I don't really give a shit
                StreamReader datasetFile = new StreamReader(datasetName, Encoding.GetEncoding(1252));

                while ((line = datasetFile.ReadLine()) != null)
                {
                    string[] lineWords = line.Split(' ');

                    foreach (string w in lineWords)
                    {
                        if (w != "")
                            datasetWords.Add(w);
                    }
                }

                datasetFile.Close();

                createPairs();
            }
            else
            {
                return false;
            }

            return true;
        }

        public bool loadDatasetXML(string nameIn)
        {
            name = nameIn;
            string datasetName = "XMLDatasets/" + name + ".xml";
            List<string> fileWords = new List<string>();

            if (File.Exists(datasetName))
            {
                XDocument doc = XDocument.Load(datasetName);

                var words = doc.Descendants("Word");

                foreach (var word in words)
                {
                    datasetWords.Add(word.Value);
                }

                createPairs();
            }
            else
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Will make all pairs from the list of words in the dataset
        /// </summary>
        private void createPairs()
        {
            foreach (string w in datasetWords)
            {
                string w2;

                if (w == "") continue;
                if (w.Length == 1) continue;
                if (w.Length == 2)
                {
                    w2 = (w + " ").ToLower();
                    if (!dataPairs["first_pairs"].ContainsKey(w2.Substring(0, 2)))
                    {
                        dataPairs["first_pairs"].Add(w2.Substring(0, 2), new List<string>());
                        dataPairs["first_pairs"][w2.Substring(0, 2)].Add(w2.Substring(2, 1));
                    }
                    else
                    {
                        if (!dataPairs["first_pairs"][w2.Substring(0, 2)].Contains(w2.Substring(2, 1)))
                        {
                            dataPairs["first_pairs"][w2.Substring(0, 2)].Add(w2.Substring(2, 1));
                        }
                    }
                }

                w2 = (w + " ").ToLower();

                string pairing;
                pairing = w2.Substring(0, 3);
                if (!dataPairs["first_pairs"].ContainsKey(pairing.Substring(0, 2)))
                {
                    dataPairs["first_pairs"].Add(pairing.Substring(0, 2), new List<string>());
                    dataPairs["first_pairs"][pairing.Substring(0, 2)].Add(pairing.Substring(2, 1));
                }
                else
                {
                    if (!dataPairs["first_pairs"][pairing.Substring(0, 2)].Contains(pairing.Substring(2, 1)))
                    {
                        dataPairs["first_pairs"][pairing.Substring(0, 2)].Add(pairing.Substring(2, 1));
                    }
                }


                for (int i = 0; i < w2.Length - 2; i++)
                {
                    pairing = w2.Substring(i, 3);
                    if (!dataPairs["normal_pairs"].ContainsKey(pairing.Substring(0, 2)))
                    {
                        dataPairs["normal_pairs"].Add(pairing.Substring(0, 2), new List<string>());
                        dataPairs["normal_pairs"][pairing.Substring(0, 2)].Add(pairing.Substring(2, 1));
                    }
                    else
                    {
                        if (!dataPairs["normal_pairs"][pairing.Substring(0, 2)].Contains(pairing.Substring(2, 1)))
                        {
                            dataPairs["normal_pairs"][pairing.Substring(0, 2)].Add(pairing.Substring(2, 1));
                        }
                    }
                }
            }

            // create affixes
            dataPairs["fixes"].Add("prefixes", new List<string>());
            dataPairs["fixes"].Add("suffixes", new List<string>());
            int limit = datasetWords.Count / 10;
            int found = 0;
            int fixLength = rand.Next(3) + 2;

            while (found < limit)
            {
                string fix;
                bool prefix = false;
                string word = datasetWords.ElementAt<string>(rand.Next(dataPairs.Count));

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
                        dataPairs["fixes"]["prefixes"].Add(fix);
                    else
                        dataPairs["fixes"]["suffixes"].Add(fix);
                }
            }
        }

        public string GetName()
        {
            return name;
        }

        public string GetWord(int wordI)
        {
            return datasetWords[wordI];
        }

        public int GetWordCount()
        {
            return datasetWords.Count;
        }

        public Dictionary<string, Dictionary<string, List<string>>> GetPairs()
        {
            return dataPairs;
        }
    }
}
