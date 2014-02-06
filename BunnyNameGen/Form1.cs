using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;

namespace BunnyNameGen
{
    public partial class Form1 : Form
    {
        PrivateFontCollection fonts;

        BindingSource datasetNameBinding;
        BindingList<string> datasetNames;
        Dictionary<string, Dataset> datasets;

        WordGenerator wordGen;

        Random rand;

        Logger logFile;

        const string DefaultDatasetsFile = "Datasets/DatasetNames.txt";

        public Form1()
        {
            InitializeComponent();

            logFile = new Logger();

            wordGen = new WordGenerator();

            datasetNames = new BindingList<string>();
            datasetNameBinding = new BindingSource();
            datasetNameBinding.DataSource = datasetNames;
            CB_Datasets.DataSource = datasetNameBinding;

            datasets = new Dictionary<string, Dataset>();

            rand = new Random();

            loadDefaultDatasets();

            fonts = new PrivateFontCollection();
            fonts.AddFontFile("OpenSans-Regular.ttf");
            TB_Output.Font = new Font(fonts.Families[0], 11, FontStyle.Regular);

            FD_OpenDataset.InitialDirectory = Application.StartupPath;

            logFile.LogInfo("Started BunnyNameGen Version " + Assembly.GetExecutingAssembly().GetName().Version.ToString());
        }

        private void loadDefaultDatasets()
        {
            if (Directory.Exists("XMLDatasets"))
            {
                string[] XmlFiles = Directory.GetFiles("XMLDatasets", "*.xml");
                foreach( string file in XmlFiles )
                {
                    if(loadDataset(file))
                        datasetNames.Add(Path.GetFileNameWithoutExtension(file));
                }
            }
            else
            {
                SSLabel1.Text = "INFO: No XMLDatasets folder. No datasets loaded";
                logFile.LogInfo("No XMLDatasets folder. No datasets loaded");
            }

            if (Directory.Exists("Datasets"))
            {
                string[] XmlFiles = Directory.GetFiles("Datasets", "*.txt");
                foreach (string file in XmlFiles)
                {
                    if (loadDataset(file))
                        datasetNames.Add(Path.GetFileNameWithoutExtension(file));
                }
            }
            else
            {
                SSLabel1.Text = "INFO: No Datasets folder. No datasets loaded";
                logFile.LogInfo("No Datasets folder. No datasets loaded");
            }
        }

        private bool loadDataset(string datasetName)
        {
            if (datasetNames.Contains(Path.GetFileNameWithoutExtension(datasetName)))
            {
                SSLabel1.Text = "ERROR: " + datasetName + " ALREADY LOADED. FILE NOT LOADED";
                logFile.LogError(datasetName + " ALREADY LOADED. FILE NOT LOADED");

                return false;
            }

            Dataset newDataset = new Dataset();

            bool loadFailed = true;

            if (Path.GetExtension(datasetName) == ".xml")
            {
                if (newDataset.loadDatasetXML(datasetName))
                {
                    datasets.Add(Path.GetFileNameWithoutExtension(datasetName), newDataset);
                    loadFailed = false;
                }
            }
            else if (Path.GetExtension(datasetName) == ".txt")
            {
                if (newDataset.loadDatasetTxt(datasetName))
                {
                    datasets.Add(Path.GetFileNameWithoutExtension(datasetName), newDataset);
                    loadFailed = false;
                }
            }
            else
            {
                SSLabel1.Text = "ERROR: " + datasetName + " HAS INCORRECT EXTENSION. FILE NOT LOADED";
                logFile.LogError(datasetName + " HAS INCORRECT EXTENSION. FILE NOT LOADED");

                return false;
            }

            if (loadFailed)
            {
                SSLabel1.Text = "ERROR: COULD NOT FIND " + datasetName + " FILE. NOT LOADED";
                logFile.LogError("COULD NOT FIND " + datasetName + " FILE. NOT LOADED");

                return false;
            }

            return true;
        }

        private void BT_GenerateData_Click(object sender, EventArgs e)
        {
            string textBoxText = "";

            if (CheckProperNames.Checked)
            {
                for (int i = 0; i < NUD_NamesToGenerate.Value; i++)
                {
                    string newName = "";
                    for (int i2 = 0; i2 < NUD_NumberOfNames.Value; i2++)
                    {
                        string newWord = wordGen.GenerateWord(datasets[datasetNames[CB_Datasets.SelectedIndex]], (int)NUD_MinWordLength.Value, (int)NUD_MaxWordLength.Value);

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
                for (int i = 0; i < NUD_NamesToGenerate.Value; i++)
                {
                    string newWord = wordGen.GenerateWord(datasets[datasetNames[CB_Datasets.SelectedIndex]], (int)NUD_MinWordLength.Value, (int)NUD_MaxWordLength.Value);

                    if (newWord.Length >= NUD_MinWordLength.Value && newWord.Length <= NUD_MaxWordLength.Value)
                        textBoxText += CultureInfo.CurrentCulture.TextInfo.ToTitleCase(newWord.ToLower()) + Environment.NewLine;
                    else
                        i--;
                }
            }
              
            TB_Output.Text = textBoxText;
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

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loadDatasetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FD_OpenDataset.Filter = "Text files (*.txt)|*.txt|XML Files (*.xml)|*.xml";
            FD_OpenDataset.ShowDialog();

            if(loadDataset(FD_OpenDataset.FileName))
                datasetNames.Add(System.IO.Path.GetFileNameWithoutExtension(FD_OpenDataset.FileName));
        }

        private void toTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(!Directory.Exists("Output"))
                Directory.CreateDirectory("Output");

            string datasetName = datasetNames[CB_Datasets.SelectedIndex];

            StreamWriter datasetOut = new StreamWriter("Output\\" + datasetName + ".txt");

            // Path.combine doesn't work for some reason :( Need to fix
            // StreamWriter datasetOut = new StreamWriter(Path.Combine("Output\\", datasetName, ".txt"));

            if (datasetOut != null)
            {
                for (int i = 0; i < datasets[datasetName].GetWordCount(); i += 10)
                {
                    string line = "";
                    for (int i2 = 0; i2 < 10; i2++)
                    {
                        if (i + i2 >= datasets[datasetName].GetWordCount())
                            break;

                        line += datasets[datasetName].GetWord(i + i2) + " ";
                    }
                    datasetOut.WriteLine(line);
                }

                datasetOut.Close();
            }
            else
            {
                logFile.LogError("Failed to create StreamWriter for " + datasetName + ". No output made");
            }
        }

        private void toXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(!Directory.Exists("Output"))
                Directory.CreateDirectory("Output");

            string datasetName = datasetNames[CB_Datasets.SelectedIndex];

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            XmlWriter datasetOut = XmlWriter.Create("Output\\" + datasetName + ".xml", settings);

            if (datasetOut != null)
            {
                datasetOut.WriteStartDocument();
                datasetOut.WriteStartElement("DatasetWords");

                for(int i = 0; i < datasets[datasetName].GetWordCount(); i++)
                {
                    datasetOut.WriteElementString("Word", datasets[datasetName].GetWord(i));
                }

                datasetOut.WriteEndElement();
                datasetOut.WriteEndDocument();

                datasetOut.Close();
            }
            else
            {
                logFile.LogError("Failed to create XmlWriter for " + datasetName + ". No output made");
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Version Number: " + Assembly.GetExecutingAssembly().GetName().Version.ToString(), "BunnyNameGen",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
        }
    }
}
