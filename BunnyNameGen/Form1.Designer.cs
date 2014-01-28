namespace BunnyNameGen
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SC_Container1 = new System.Windows.Forms.SplitContainer();
            this.BT_GenerateData = new System.Windows.Forms.Button();
            this.CB_Datasets = new System.Windows.Forms.ComboBox();
            this.LB_DatasetChoice = new System.Windows.Forms.Label();
            this.SC_Container2 = new System.Windows.Forms.SplitContainer();
            this.CheckProperNames = new System.Windows.Forms.CheckBox();
            this.NUD_NumberOfNames = new System.Windows.Forms.NumericUpDown();
            this.NUD_NamesToGenerate = new System.Windows.Forms.NumericUpDown();
            this.NUD_MaxWordLength = new System.Windows.Forms.NumericUpDown();
            this.NUD_MinWordLength = new System.Windows.Forms.NumericUpDown();
            this.LB_NumberOfNames = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TB_Output = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.SSLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.FD_OpenDataset = new System.Windows.Forms.OpenFileDialog();
            this.datasetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadDatasetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outputDatasetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.SC_Container1)).BeginInit();
            this.SC_Container1.Panel1.SuspendLayout();
            this.SC_Container1.Panel2.SuspendLayout();
            this.SC_Container1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SC_Container2)).BeginInit();
            this.SC_Container2.Panel1.SuspendLayout();
            this.SC_Container2.Panel2.SuspendLayout();
            this.SC_Container2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_NumberOfNames)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_NamesToGenerate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_MaxWordLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_MinWordLength)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SC_Container1
            // 
            this.SC_Container1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SC_Container1.Location = new System.Drawing.Point(0, 24);
            this.SC_Container1.Name = "SC_Container1";
            this.SC_Container1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SC_Container1.Panel1
            // 
            this.SC_Container1.Panel1.Controls.Add(this.BT_GenerateData);
            this.SC_Container1.Panel1.Controls.Add(this.CB_Datasets);
            this.SC_Container1.Panel1.Controls.Add(this.LB_DatasetChoice);
            // 
            // SC_Container1.Panel2
            // 
            this.SC_Container1.Panel2.Controls.Add(this.SC_Container2);
            this.SC_Container1.Size = new System.Drawing.Size(484, 316);
            this.SC_Container1.SplitterDistance = 37;
            this.SC_Container1.TabIndex = 0;
            // 
            // BT_GenerateData
            // 
            this.BT_GenerateData.Location = new System.Drawing.Point(377, 8);
            this.BT_GenerateData.Name = "BT_GenerateData";
            this.BT_GenerateData.Size = new System.Drawing.Size(95, 23);
            this.BT_GenerateData.TabIndex = 2;
            this.BT_GenerateData.Text = "Generate Data";
            this.BT_GenerateData.UseVisualStyleBackColor = true;
            this.BT_GenerateData.Click += new System.EventHandler(this.BT_GenerateData_Click);
            // 
            // CB_Datasets
            // 
            this.CB_Datasets.FormattingEnabled = true;
            this.CB_Datasets.Location = new System.Drawing.Point(111, 10);
            this.CB_Datasets.Name = "CB_Datasets";
            this.CB_Datasets.Size = new System.Drawing.Size(260, 21);
            this.CB_Datasets.TabIndex = 1;
            // 
            // LB_DatasetChoice
            // 
            this.LB_DatasetChoice.AutoSize = true;
            this.LB_DatasetChoice.Location = new System.Drawing.Point(13, 13);
            this.LB_DatasetChoice.Name = "LB_DatasetChoice";
            this.LB_DatasetChoice.Size = new System.Drawing.Size(92, 13);
            this.LB_DatasetChoice.TabIndex = 0;
            this.LB_DatasetChoice.Text = "Choose a Dataset";
            // 
            // SC_Container2
            // 
            this.SC_Container2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SC_Container2.Location = new System.Drawing.Point(0, 0);
            this.SC_Container2.Name = "SC_Container2";
            // 
            // SC_Container2.Panel1
            // 
            this.SC_Container2.Panel1.Controls.Add(this.CheckProperNames);
            this.SC_Container2.Panel1.Controls.Add(this.NUD_NumberOfNames);
            this.SC_Container2.Panel1.Controls.Add(this.NUD_NamesToGenerate);
            this.SC_Container2.Panel1.Controls.Add(this.NUD_MaxWordLength);
            this.SC_Container2.Panel1.Controls.Add(this.NUD_MinWordLength);
            this.SC_Container2.Panel1.Controls.Add(this.LB_NumberOfNames);
            this.SC_Container2.Panel1.Controls.Add(this.label4);
            this.SC_Container2.Panel1.Controls.Add(this.label3);
            this.SC_Container2.Panel1.Controls.Add(this.label2);
            this.SC_Container2.Panel1.Controls.Add(this.label1);
            // 
            // SC_Container2.Panel2
            // 
            this.SC_Container2.Panel2.Controls.Add(this.TB_Output);
            this.SC_Container2.Size = new System.Drawing.Size(484, 275);
            this.SC_Container2.SplitterDistance = 211;
            this.SC_Container2.TabIndex = 0;
            // 
            // CheckProperNames
            // 
            this.CheckProperNames.AutoSize = true;
            this.CheckProperNames.Location = new System.Drawing.Point(146, 110);
            this.CheckProperNames.Name = "CheckProperNames";
            this.CheckProperNames.Size = new System.Drawing.Size(15, 14);
            this.CheckProperNames.TabIndex = 2;
            this.CheckProperNames.UseVisualStyleBackColor = true;
            this.CheckProperNames.CheckedChanged += new System.EventHandler(this.CheckProperNames_CheckedChanged);
            // 
            // NUD_NumberOfNames
            // 
            this.NUD_NumberOfNames.Location = new System.Drawing.Point(146, 130);
            this.NUD_NumberOfNames.Name = "NUD_NumberOfNames";
            this.NUD_NumberOfNames.Size = new System.Drawing.Size(52, 20);
            this.NUD_NumberOfNames.TabIndex = 1;
            this.NUD_NumberOfNames.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // NUD_NamesToGenerate
            // 
            this.NUD_NamesToGenerate.Location = new System.Drawing.Point(146, 62);
            this.NUD_NamesToGenerate.Name = "NUD_NamesToGenerate";
            this.NUD_NamesToGenerate.Size = new System.Drawing.Size(52, 20);
            this.NUD_NamesToGenerate.TabIndex = 1;
            this.NUD_NamesToGenerate.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // NUD_MaxWordLength
            // 
            this.NUD_MaxWordLength.Location = new System.Drawing.Point(146, 36);
            this.NUD_MaxWordLength.Name = "NUD_MaxWordLength";
            this.NUD_MaxWordLength.Size = new System.Drawing.Size(52, 20);
            this.NUD_MaxWordLength.TabIndex = 1;
            this.NUD_MaxWordLength.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // NUD_MinWordLength
            // 
            this.NUD_MinWordLength.Location = new System.Drawing.Point(146, 10);
            this.NUD_MinWordLength.Name = "NUD_MinWordLength";
            this.NUD_MinWordLength.Size = new System.Drawing.Size(52, 20);
            this.NUD_MinWordLength.TabIndex = 1;
            this.NUD_MinWordLength.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // LB_NumberOfNames
            // 
            this.LB_NumberOfNames.AutoSize = true;
            this.LB_NumberOfNames.Location = new System.Drawing.Point(13, 132);
            this.LB_NumberOfNames.Name = "LB_NumberOfNames";
            this.LB_NumberOfNames.Size = new System.Drawing.Size(92, 13);
            this.LB_NumberOfNames.TabIndex = 0;
            this.LB_NumberOfNames.Text = "Number of Names";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Generate Proper Names?";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Number to Generate";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Max. Word Length";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Min. Word Length";
            // 
            // TB_Output
            // 
            this.TB_Output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TB_Output.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_Output.Location = new System.Drawing.Point(0, 0);
            this.TB_Output.Multiline = true;
            this.TB_Output.Name = "TB_Output";
            this.TB_Output.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TB_Output.Size = new System.Drawing.Size(269, 275);
            this.TB_Output.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.datasetToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(484, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SSLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 340);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(484, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // SSLabel1
            // 
            this.SSLabel1.Name = "SSLabel1";
            this.SSLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // datasetToolStripMenuItem
            // 
            this.datasetToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadDatasetsToolStripMenuItem,
            this.outputDatasetToolStripMenuItem});
            this.datasetToolStripMenuItem.Name = "datasetToolStripMenuItem";
            this.datasetToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.datasetToolStripMenuItem.Text = "Dataset";
            // 
            // loadDatasetsToolStripMenuItem
            // 
            this.loadDatasetsToolStripMenuItem.Name = "loadDatasetsToolStripMenuItem";
            this.loadDatasetsToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.loadDatasetsToolStripMenuItem.Text = "Load Dataset";
            // 
            // outputDatasetToolStripMenuItem
            // 
            this.outputDatasetToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toTextToolStripMenuItem,
            this.toXMLToolStripMenuItem});
            this.outputDatasetToolStripMenuItem.Name = "outputDatasetToolStripMenuItem";
            this.outputDatasetToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.outputDatasetToolStripMenuItem.Text = "Output Dataset";
            // 
            // toTextToolStripMenuItem
            // 
            this.toTextToolStripMenuItem.Name = "toTextToolStripMenuItem";
            this.toTextToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.toTextToolStripMenuItem.Text = "To Text";
            this.toTextToolStripMenuItem.Click += new System.EventHandler(this.toTextToolStripMenuItem_Click);
            // 
            // toXMLToolStripMenuItem
            // 
            this.toXMLToolStripMenuItem.Name = "toXMLToolStripMenuItem";
            this.toXMLToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.toXMLToolStripMenuItem.Text = "To XML";
            this.toXMLToolStripMenuItem.Click += new System.EventHandler(this.toXMLToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 362);
            this.Controls.Add(this.SC_Container1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Bunny\'s Name Generator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.SC_Container1.Panel1.ResumeLayout(false);
            this.SC_Container1.Panel1.PerformLayout();
            this.SC_Container1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SC_Container1)).EndInit();
            this.SC_Container1.ResumeLayout(false);
            this.SC_Container2.Panel1.ResumeLayout(false);
            this.SC_Container2.Panel1.PerformLayout();
            this.SC_Container2.Panel2.ResumeLayout(false);
            this.SC_Container2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SC_Container2)).EndInit();
            this.SC_Container2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NUD_NumberOfNames)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_NamesToGenerate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_MaxWordLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_MinWordLength)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer SC_Container1;
        private System.Windows.Forms.SplitContainer SC_Container2;
        private System.Windows.Forms.CheckBox CheckProperNames;
        private System.Windows.Forms.NumericUpDown NUD_NumberOfNames;
        private System.Windows.Forms.NumericUpDown NUD_NamesToGenerate;
        private System.Windows.Forms.NumericUpDown NUD_MaxWordLength;
        private System.Windows.Forms.NumericUpDown NUD_MinWordLength;
        private System.Windows.Forms.Label LB_NumberOfNames;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BT_GenerateData;
        private System.Windows.Forms.ComboBox CB_Datasets;
        private System.Windows.Forms.Label LB_DatasetChoice;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel SSLabel1;
        private System.Windows.Forms.TextBox TB_Output;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog FD_OpenDataset;
        private System.Windows.Forms.ToolStripMenuItem datasetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadDatasetsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem outputDatasetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toXMLToolStripMenuItem;
    }
}

