using System;

namespace AssetManager
{
    partial class MainWindow
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.windowTabControls = new System.Windows.Forms.TabControl();
            this.tabMaterials = new System.Windows.Forms.TabPage();
            this.parameterSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.overwriteModeComboBox = new System.Windows.Forms.ComboBox();
            this.randomizerSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.randomizerChanceLabel = new System.Windows.Forms.Label();
            this.randomizerChanceTrackBar = new System.Windows.Forms.TrackBar();
            this.deviationSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.deviationSettingsParam3Label = new System.Windows.Forms.Label();
            this.randomizerOffsetNumeric3 = new System.Windows.Forms.NumericUpDown();
            this.deviationSettingsParam2Label = new System.Windows.Forms.Label();
            this.randomizerOffsetNumeric2 = new System.Windows.Forms.NumericUpDown();
            this.deviationSettingsParam1Label = new System.Windows.Forms.Label();
            this.randomizerOffsetNumeric = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.filterSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.proxyFilterButton = new System.Windows.Forms.Button();
            this.caseInsensitiveCheckBox = new System.Windows.Forms.CheckBox();
            this.excludedShadersButton = new System.Windows.Forms.Button();
            this.vpkDirectoryListing = new System.Windows.Forms.TreeView();
            this.label2 = new System.Windows.Forms.Label();
            this.miscellaneousSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.manageParametersButton = new System.Windows.Forms.Button();
            this.parametersLabel = new System.Windows.Forms.Label();
            this.materialParameterList = new System.Windows.Forms.CheckedListBox();
            this.tabTextures = new System.Windows.Forms.TabPage();
            this.tabModels = new System.Windows.Forms.TabPage();
            this.tabParticles = new System.Windows.Forms.TabPage();
            this.tabSounds = new System.Windows.Forms.TabPage();
            this.tabScripts = new System.Windows.Forms.TabPage();
            this.tabLocalization = new System.Windows.Forms.TabPage();
            this.tabExport = new System.Windows.Forms.TabPage();
            this.customFileCheckList = new System.Windows.Forms.CheckedListBox();
            this.customFilesCheckBox = new System.Windows.Forms.CheckBox();
            this.verboseModeCheckBox = new System.Windows.Forms.CheckBox();
            this.exportLocationValidLabel = new System.Windows.Forms.Label();
            this.gameLocationValidLabel = new System.Windows.Forms.Label();
            this.gameFileLocationButton = new System.Windows.Forms.Button();
            this.gameLocationText = new System.Windows.Forms.TextBox();
            this.exportLocationLabel = new System.Windows.Forms.Label();
            this.gameLocationLabel = new System.Windows.Forms.Label();
            this.startPackagingButton = new System.Windows.Forms.Button();
            this.progressBox = new System.Windows.Forms.TextBox();
            this.saveFileLocationButton = new System.Windows.Forms.Button();
            this.saveFileLocationText = new System.Windows.Forms.TextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.windowTabControls.SuspendLayout();
            this.tabMaterials.SuspendLayout();
            this.parameterSettingsGroupBox.SuspendLayout();
            this.randomizerSettingsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.randomizerChanceTrackBar)).BeginInit();
            this.deviationSettingsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.randomizerOffsetNumeric3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.randomizerOffsetNumeric2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.randomizerOffsetNumeric)).BeginInit();
            this.filterSettingsGroupBox.SuspendLayout();
            this.miscellaneousSettingsGroupBox.SuspendLayout();
            this.tabExport.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // windowTabControls
            // 
            this.windowTabControls.Controls.Add(this.tabMaterials);
            this.windowTabControls.Controls.Add(this.tabTextures);
            this.windowTabControls.Controls.Add(this.tabModels);
            this.windowTabControls.Controls.Add(this.tabParticles);
            this.windowTabControls.Controls.Add(this.tabSounds);
            this.windowTabControls.Controls.Add(this.tabScripts);
            this.windowTabControls.Controls.Add(this.tabLocalization);
            this.windowTabControls.Controls.Add(this.tabExport);
            this.windowTabControls.Location = new System.Drawing.Point(0, 0);
            this.windowTabControls.Name = "windowTabControls";
            this.windowTabControls.SelectedIndex = 0;
            this.windowTabControls.Size = new System.Drawing.Size(740, 561);
            this.windowTabControls.TabIndex = 0;
            this.windowTabControls.SelectedIndexChanged += new System.EventHandler(this.WindowTabControls_SelectedIndexChanged);
            // 
            // tabMaterials
            // 
            this.tabMaterials.Controls.Add(this.parameterSettingsGroupBox);
            this.tabMaterials.Controls.Add(this.manageParametersButton);
            this.tabMaterials.Controls.Add(this.parametersLabel);
            this.tabMaterials.Controls.Add(this.materialParameterList);
            this.tabMaterials.Location = new System.Drawing.Point(4, 22);
            this.tabMaterials.Name = "tabMaterials";
            this.tabMaterials.Padding = new System.Windows.Forms.Padding(3);
            this.tabMaterials.Size = new System.Drawing.Size(732, 535);
            this.tabMaterials.TabIndex = 0;
            this.tabMaterials.Text = "Materials";
            this.tabMaterials.UseVisualStyleBackColor = true;
            // 
            // parameterSettingsGroupBox
            // 
            this.parameterSettingsGroupBox.Controls.Add(this.overwriteModeComboBox);
            this.parameterSettingsGroupBox.Controls.Add(this.randomizerSettingsGroupBox);
            this.parameterSettingsGroupBox.Controls.Add(this.filterSettingsGroupBox);
            this.parameterSettingsGroupBox.Controls.Add(this.miscellaneousSettingsGroupBox);
            this.parameterSettingsGroupBox.Location = new System.Drawing.Point(175, 6);
            this.parameterSettingsGroupBox.Name = "parameterSettingsGroupBox";
            this.parameterSettingsGroupBox.Size = new System.Drawing.Size(546, 523);
            this.parameterSettingsGroupBox.TabIndex = 8;
            this.parameterSettingsGroupBox.TabStop = false;
            this.parameterSettingsGroupBox.Text = "Parameter Settings";
            this.parameterSettingsGroupBox.Visible = false;
            // 
            // overwriteModeComboBox
            // 
            this.overwriteModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.overwriteModeComboBox.FormattingEnabled = true;
            this.overwriteModeComboBox.Items.AddRange(new object[] {
            "ALWAYS write to file",
            "Overwrite if parameter is in file",
            "Write if parameter is not in file "});
            this.overwriteModeComboBox.Location = new System.Drawing.Point(302, 418);
            this.overwriteModeComboBox.Name = "overwriteModeComboBox";
            this.overwriteModeComboBox.Size = new System.Drawing.Size(229, 21);
            this.overwriteModeComboBox.TabIndex = 12;
            this.overwriteModeComboBox.SelectedIndexChanged += new System.EventHandler(this.OverwriteModeComboBox_SelectedIndexChanged);
            // 
            // randomizerSettingsGroupBox
            // 
            this.randomizerSettingsGroupBox.Controls.Add(this.randomizerChanceLabel);
            this.randomizerSettingsGroupBox.Controls.Add(this.randomizerChanceTrackBar);
            this.randomizerSettingsGroupBox.Controls.Add(this.deviationSettingsGroupBox);
            this.randomizerSettingsGroupBox.Controls.Add(this.label5);
            this.randomizerSettingsGroupBox.Location = new System.Drawing.Point(208, 19);
            this.randomizerSettingsGroupBox.Name = "randomizerSettingsGroupBox";
            this.randomizerSettingsGroupBox.Size = new System.Drawing.Size(332, 374);
            this.randomizerSettingsGroupBox.TabIndex = 11;
            this.randomizerSettingsGroupBox.TabStop = false;
            this.randomizerSettingsGroupBox.Text = "Randomizer Settings";
            // 
            // randomizerChanceLabel
            // 
            this.randomizerChanceLabel.AutoSize = true;
            this.randomizerChanceLabel.Location = new System.Drawing.Point(290, 36);
            this.randomizerChanceLabel.Name = "randomizerChanceLabel";
            this.randomizerChanceLabel.Size = new System.Drawing.Size(21, 13);
            this.randomizerChanceLabel.TabIndex = 7;
            this.randomizerChanceLabel.Text = "0%";
            this.randomizerChanceLabel.TextChanged += new System.EventHandler(this.RandomizerChanceLabel_TextChanged);
            // 
            // randomizerChanceTrackBar
            // 
            this.randomizerChanceTrackBar.AutoSize = false;
            this.randomizerChanceTrackBar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.randomizerChanceTrackBar.Location = new System.Drawing.Point(9, 32);
            this.randomizerChanceTrackBar.Maximum = 100;
            this.randomizerChanceTrackBar.Name = "randomizerChanceTrackBar";
            this.randomizerChanceTrackBar.Size = new System.Drawing.Size(276, 30);
            this.randomizerChanceTrackBar.TabIndex = 6;
            this.randomizerChanceTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.randomizerChanceTrackBar.Scroll += new System.EventHandler(this.RandomizerChanceTrackBar_Scroll);
            this.randomizerChanceTrackBar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.RandomizerScrollBarChanged);
            this.randomizerChanceTrackBar.MouseCaptureChanged += new System.EventHandler(this.RandomizerScrollBarChanged);
            // 
            // deviationSettingsGroupBox
            // 
            this.deviationSettingsGroupBox.Controls.Add(this.deviationSettingsParam3Label);
            this.deviationSettingsGroupBox.Controls.Add(this.randomizerOffsetNumeric3);
            this.deviationSettingsGroupBox.Controls.Add(this.deviationSettingsParam2Label);
            this.deviationSettingsGroupBox.Controls.Add(this.randomizerOffsetNumeric2);
            this.deviationSettingsGroupBox.Controls.Add(this.deviationSettingsParam1Label);
            this.deviationSettingsGroupBox.Controls.Add(this.randomizerOffsetNumeric);
            this.deviationSettingsGroupBox.Location = new System.Drawing.Point(10, 68);
            this.deviationSettingsGroupBox.Name = "deviationSettingsGroupBox";
            this.deviationSettingsGroupBox.Size = new System.Drawing.Size(313, 109);
            this.deviationSettingsGroupBox.TabIndex = 2;
            this.deviationSettingsGroupBox.TabStop = false;
            this.deviationSettingsGroupBox.Text = "Parameter Value Randomization Settings";
            // 
            // deviationSettingsParam3Label
            // 
            this.deviationSettingsParam3Label.AutoSize = true;
            this.deviationSettingsParam3Label.Location = new System.Drawing.Point(6, 72);
            this.deviationSettingsParam3Label.Name = "deviationSettingsParam3Label";
            this.deviationSettingsParam3Label.Size = new System.Drawing.Size(158, 13);
            this.deviationSettingsParam3Label.TabIndex = 5;
            this.deviationSettingsParam3Label.Text = "Parameter 3 Random Deviation:";
            this.toolTip1.SetToolTip(this.deviationSettingsParam3Label, "How much the parameter can deviate from its original value.");
            // 
            // randomizerOffsetNumeric3
            // 
            this.randomizerOffsetNumeric3.DecimalPlaces = 7;
            this.randomizerOffsetNumeric3.Location = new System.Drawing.Point(187, 70);
            this.randomizerOffsetNumeric3.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.randomizerOffsetNumeric3.Name = "randomizerOffsetNumeric3";
            this.randomizerOffsetNumeric3.Size = new System.Drawing.Size(120, 20);
            this.randomizerOffsetNumeric3.TabIndex = 4;
            this.randomizerOffsetNumeric3.ValueChanged += new System.EventHandler(this.RandomizerOffsetNumeric3_ValueChanged);
            // 
            // deviationSettingsParam2Label
            // 
            this.deviationSettingsParam2Label.AutoSize = true;
            this.deviationSettingsParam2Label.Location = new System.Drawing.Point(6, 49);
            this.deviationSettingsParam2Label.Name = "deviationSettingsParam2Label";
            this.deviationSettingsParam2Label.Size = new System.Drawing.Size(158, 13);
            this.deviationSettingsParam2Label.TabIndex = 3;
            this.deviationSettingsParam2Label.Text = "Parameter 2 Random Deviation:";
            this.toolTip1.SetToolTip(this.deviationSettingsParam2Label, "How much the parameter can deviate from its original value.");
            // 
            // randomizerOffsetNumeric2
            // 
            this.randomizerOffsetNumeric2.DecimalPlaces = 7;
            this.randomizerOffsetNumeric2.Location = new System.Drawing.Point(187, 47);
            this.randomizerOffsetNumeric2.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.randomizerOffsetNumeric2.Name = "randomizerOffsetNumeric2";
            this.randomizerOffsetNumeric2.Size = new System.Drawing.Size(120, 20);
            this.randomizerOffsetNumeric2.TabIndex = 2;
            this.randomizerOffsetNumeric2.ValueChanged += new System.EventHandler(this.RandomizerOffsetNumeric2_ValueChanged);
            // 
            // deviationSettingsParam1Label
            // 
            this.deviationSettingsParam1Label.AutoSize = true;
            this.deviationSettingsParam1Label.Location = new System.Drawing.Point(6, 26);
            this.deviationSettingsParam1Label.Name = "deviationSettingsParam1Label";
            this.deviationSettingsParam1Label.Size = new System.Drawing.Size(149, 13);
            this.deviationSettingsParam1Label.TabIndex = 1;
            this.deviationSettingsParam1Label.Text = "Parameter Random Deviation:";
            this.toolTip1.SetToolTip(this.deviationSettingsParam1Label, "How much the parameter can deviate from its original value.");
            // 
            // randomizerOffsetNumeric
            // 
            this.randomizerOffsetNumeric.DecimalPlaces = 7;
            this.randomizerOffsetNumeric.Location = new System.Drawing.Point(187, 24);
            this.randomizerOffsetNumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.randomizerOffsetNumeric.Name = "randomizerOffsetNumeric";
            this.randomizerOffsetNumeric.Size = new System.Drawing.Size(120, 20);
            this.randomizerOffsetNumeric.TabIndex = 0;
            this.randomizerOffsetNumeric.ValueChanged += new System.EventHandler(this.RandomizerOffsetNumeric_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(100, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Probability Of Appearance:";
            this.toolTip1.SetToolTip(this.label5, "The chance of this parameter being used in the selected files.");
            // 
            // filterSettingsGroupBox
            // 
            this.filterSettingsGroupBox.Controls.Add(this.proxyFilterButton);
            this.filterSettingsGroupBox.Controls.Add(this.caseInsensitiveCheckBox);
            this.filterSettingsGroupBox.Controls.Add(this.excludedShadersButton);
            this.filterSettingsGroupBox.Controls.Add(this.vpkDirectoryListing);
            this.filterSettingsGroupBox.Controls.Add(this.label2);
            this.filterSettingsGroupBox.Location = new System.Drawing.Point(6, 19);
            this.filterSettingsGroupBox.Name = "filterSettingsGroupBox";
            this.filterSettingsGroupBox.Size = new System.Drawing.Size(193, 496);
            this.filterSettingsGroupBox.TabIndex = 14;
            this.filterSettingsGroupBox.TabStop = false;
            this.filterSettingsGroupBox.Text = "Filter Settings";
            // 
            // proxyFilterButton
            // 
            this.proxyFilterButton.Location = new System.Drawing.Point(6, 445);
            this.proxyFilterButton.Name = "proxyFilterButton";
            this.proxyFilterButton.Size = new System.Drawing.Size(180, 23);
            this.proxyFilterButton.TabIndex = 13;
            this.proxyFilterButton.Text = "Proxy Filter...";
            this.toolTip1.SetToolTip(this.proxyFilterButton, "Allows for certain shaders to be excluded. This can help in material parameters w" +
        "here compatibility is an issue.");
            this.proxyFilterButton.UseVisualStyleBackColor = true;
            this.proxyFilterButton.Click += new System.EventHandler(this.ProxyFilterButton_Click);
            // 
            // caseInsensitiveCheckBox
            // 
            this.caseInsensitiveCheckBox.AutoSize = true;
            this.caseInsensitiveCheckBox.Checked = true;
            this.caseInsensitiveCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.caseInsensitiveCheckBox.Enabled = false;
            this.caseInsensitiveCheckBox.Location = new System.Drawing.Point(6, 393);
            this.caseInsensitiveCheckBox.Name = "caseInsensitiveCheckBox";
            this.caseInsensitiveCheckBox.Size = new System.Drawing.Size(184, 17);
            this.caseInsensitiveCheckBox.TabIndex = 12;
            this.caseInsensitiveCheckBox.Text = "Case-Insensitive (Recommended)";
            this.toolTip1.SetToolTip(this.caseInsensitiveCheckBox, "If checked, this parameter will replace parameters regardless of case matching.");
            this.caseInsensitiveCheckBox.UseVisualStyleBackColor = true;
            // 
            // excludedShadersButton
            // 
            this.excludedShadersButton.Location = new System.Drawing.Point(6, 416);
            this.excludedShadersButton.Name = "excludedShadersButton";
            this.excludedShadersButton.Size = new System.Drawing.Size(180, 23);
            this.excludedShadersButton.TabIndex = 11;
            this.excludedShadersButton.Text = "Shader Filter...";
            this.toolTip1.SetToolTip(this.excludedShadersButton, "Allows for certain shaders to be excluded. This can help in material parameters w" +
        "here compatibility is an issue.");
            this.excludedShadersButton.UseVisualStyleBackColor = true;
            this.excludedShadersButton.Click += new System.EventHandler(this.ExcludedShadersButton_Click);
            // 
            // vpkDirectoryListing
            // 
            this.vpkDirectoryListing.CheckBoxes = true;
            this.vpkDirectoryListing.Location = new System.Drawing.Point(6, 32);
            this.vpkDirectoryListing.Name = "vpkDirectoryListing";
            this.vpkDirectoryListing.Size = new System.Drawing.Size(181, 353);
            this.vpkDirectoryListing.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Files To Affect";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // miscellaneousSettingsGroupBox
            // 
            this.miscellaneousSettingsGroupBox.Controls.Add(this.label6);
            this.miscellaneousSettingsGroupBox.Location = new System.Drawing.Point(208, 399);
            this.miscellaneousSettingsGroupBox.Name = "miscellaneousSettingsGroupBox";
            this.miscellaneousSettingsGroupBox.Size = new System.Drawing.Size(332, 116);
            this.miscellaneousSettingsGroupBox.TabIndex = 15;
            this.miscellaneousSettingsGroupBox.TabStop = false;
            this.miscellaneousSettingsGroupBox.Text = "Miscellaneous Settings";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Overwrite Mode:";
            // 
            // manageParametersButton
            // 
            this.manageParametersButton.Location = new System.Drawing.Point(6, 507);
            this.manageParametersButton.Name = "manageParametersButton";
            this.manageParametersButton.Size = new System.Drawing.Size(163, 22);
            this.manageParametersButton.TabIndex = 5;
            this.manageParametersButton.Text = "Manage Parameters";
            this.toolTip1.SetToolTip(this.manageParametersButton, "Add, remove, and edit material parameters.");
            this.manageParametersButton.UseVisualStyleBackColor = true;
            this.manageParametersButton.Click += new System.EventHandler(this.ManageParameterButton_Click);
            // 
            // parametersLabel
            // 
            this.parametersLabel.AutoSize = true;
            this.parametersLabel.Location = new System.Drawing.Point(56, 0);
            this.parametersLabel.Name = "parametersLabel";
            this.parametersLabel.Size = new System.Drawing.Size(60, 13);
            this.parametersLabel.TabIndex = 1;
            this.parametersLabel.Text = "Parameters";
            this.parametersLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // materialParameterList
            // 
            this.materialParameterList.CheckOnClick = true;
            this.materialParameterList.FormattingEnabled = true;
            this.materialParameterList.HorizontalScrollbar = true;
            this.materialParameterList.Location = new System.Drawing.Point(6, 16);
            this.materialParameterList.Name = "materialParameterList";
            this.materialParameterList.Size = new System.Drawing.Size(163, 484);
            this.materialParameterList.TabIndex = 0;
            this.materialParameterList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MaterialParameterList_MouseClick);
            // 
            // tabTextures
            // 
            this.tabTextures.Location = new System.Drawing.Point(4, 22);
            this.tabTextures.Name = "tabTextures";
            this.tabTextures.Size = new System.Drawing.Size(732, 535);
            this.tabTextures.TabIndex = 7;
            this.tabTextures.Text = "Textures";
            this.tabTextures.UseVisualStyleBackColor = true;
            // 
            // tabModels
            // 
            this.tabModels.Location = new System.Drawing.Point(4, 22);
            this.tabModels.Name = "tabModels";
            this.tabModels.Size = new System.Drawing.Size(732, 535);
            this.tabModels.TabIndex = 3;
            this.tabModels.Text = "Models";
            this.tabModels.UseVisualStyleBackColor = true;
            // 
            // tabParticles
            // 
            this.tabParticles.Location = new System.Drawing.Point(4, 22);
            this.tabParticles.Name = "tabParticles";
            this.tabParticles.Size = new System.Drawing.Size(732, 535);
            this.tabParticles.TabIndex = 4;
            this.tabParticles.Text = "Particles";
            this.tabParticles.UseVisualStyleBackColor = true;
            // 
            // tabSounds
            // 
            this.tabSounds.Location = new System.Drawing.Point(4, 22);
            this.tabSounds.Name = "tabSounds";
            this.tabSounds.Padding = new System.Windows.Forms.Padding(3);
            this.tabSounds.Size = new System.Drawing.Size(732, 535);
            this.tabSounds.TabIndex = 1;
            this.tabSounds.Text = "Sounds";
            this.tabSounds.UseVisualStyleBackColor = true;
            // 
            // tabScripts
            // 
            this.tabScripts.Location = new System.Drawing.Point(4, 22);
            this.tabScripts.Name = "tabScripts";
            this.tabScripts.Size = new System.Drawing.Size(732, 535);
            this.tabScripts.TabIndex = 5;
            this.tabScripts.Text = "Scripts";
            this.tabScripts.UseVisualStyleBackColor = true;
            // 
            // tabLocalization
            // 
            this.tabLocalization.Location = new System.Drawing.Point(4, 22);
            this.tabLocalization.Name = "tabLocalization";
            this.tabLocalization.Size = new System.Drawing.Size(732, 535);
            this.tabLocalization.TabIndex = 6;
            this.tabLocalization.Text = "Localization";
            this.tabLocalization.UseVisualStyleBackColor = true;
            // 
            // tabExport
            // 
            this.tabExport.Controls.Add(this.customFileCheckList);
            this.tabExport.Controls.Add(this.customFilesCheckBox);
            this.tabExport.Controls.Add(this.verboseModeCheckBox);
            this.tabExport.Controls.Add(this.exportLocationValidLabel);
            this.tabExport.Controls.Add(this.gameLocationValidLabel);
            this.tabExport.Controls.Add(this.gameFileLocationButton);
            this.tabExport.Controls.Add(this.gameLocationText);
            this.tabExport.Controls.Add(this.exportLocationLabel);
            this.tabExport.Controls.Add(this.gameLocationLabel);
            this.tabExport.Controls.Add(this.startPackagingButton);
            this.tabExport.Controls.Add(this.progressBox);
            this.tabExport.Controls.Add(this.saveFileLocationButton);
            this.tabExport.Controls.Add(this.saveFileLocationText);
            this.tabExport.Location = new System.Drawing.Point(4, 22);
            this.tabExport.Name = "tabExport";
            this.tabExport.Size = new System.Drawing.Size(732, 535);
            this.tabExport.TabIndex = 2;
            this.tabExport.Text = "Export";
            this.tabExport.UseVisualStyleBackColor = true;
            // 
            // customFileCheckList
            // 
            this.customFileCheckList.CheckOnClick = true;
            this.customFileCheckList.Enabled = false;
            this.customFileCheckList.FormattingEnabled = true;
            this.customFileCheckList.Location = new System.Drawing.Point(463, 27);
            this.customFileCheckList.Name = "customFileCheckList";
            this.customFileCheckList.Size = new System.Drawing.Size(256, 214);
            this.customFileCheckList.TabIndex = 20;
            // 
            // customFilesCheckBox
            // 
            this.customFilesCheckBox.AutoSize = true;
            this.customFilesCheckBox.Location = new System.Drawing.Point(463, 4);
            this.customFilesCheckBox.Name = "customFilesCheckBox";
            this.customFilesCheckBox.Size = new System.Drawing.Size(168, 17);
            this.customFilesCheckBox.TabIndex = 19;
            this.customFilesCheckBox.Text = "Include Custom Files In Export";
            this.customFilesCheckBox.UseVisualStyleBackColor = true;
            this.customFilesCheckBox.CheckedChanged += new System.EventHandler(this.CustomFilesCheckBox_CheckedChanged);
            // 
            // verboseModeCheckBox
            // 
            this.verboseModeCheckBox.AutoSize = true;
            this.verboseModeCheckBox.Location = new System.Drawing.Point(306, 228);
            this.verboseModeCheckBox.Name = "verboseModeCheckBox";
            this.verboseModeCheckBox.Size = new System.Drawing.Size(95, 17);
            this.verboseModeCheckBox.TabIndex = 18;
            this.verboseModeCheckBox.Text = "Verbose Mode";
            this.verboseModeCheckBox.UseVisualStyleBackColor = true;
            // 
            // exportLocationValidLabel
            // 
            this.exportLocationValidLabel.AutoSize = true;
            this.exportLocationValidLabel.Location = new System.Drawing.Point(622, 276);
            this.exportLocationValidLabel.Name = "exportLocationValidLabel";
            this.exportLocationValidLabel.Size = new System.Drawing.Size(76, 13);
            this.exportLocationValidLabel.TabIndex = 17;
            this.exportLocationValidLabel.Text = "Location valid.";
            // 
            // gameLocationValidLabel
            // 
            this.gameLocationValidLabel.AutoSize = true;
            this.gameLocationValidLabel.Location = new System.Drawing.Point(622, 254);
            this.gameLocationValidLabel.Name = "gameLocationValidLabel";
            this.gameLocationValidLabel.Size = new System.Drawing.Size(97, 13);
            this.gameLocationValidLabel.TabIndex = 16;
            this.gameLocationValidLabel.Text = "gameinfo.txt found.";
            // 
            // gameFileLocationButton
            // 
            this.gameFileLocationButton.Location = new System.Drawing.Point(463, 251);
            this.gameFileLocationButton.Name = "gameFileLocationButton";
            this.gameFileLocationButton.Size = new System.Drawing.Size(158, 20);
            this.gameFileLocationButton.TabIndex = 15;
            this.gameFileLocationButton.Text = "Set Game Location...";
            this.gameFileLocationButton.UseVisualStyleBackColor = true;
            this.gameFileLocationButton.Click += new System.EventHandler(this.Button3_Click);
            // 
            // gameLocationText
            // 
            this.gameLocationText.Location = new System.Drawing.Point(91, 251);
            this.gameLocationText.Name = "gameLocationText";
            this.gameLocationText.Size = new System.Drawing.Size(366, 20);
            this.gameLocationText.TabIndex = 14;
            this.gameLocationText.LostFocus += new System.EventHandler(this.GameLocationText_LostFocus);
            // 
            // exportLocationLabel
            // 
            this.exportLocationLabel.AutoSize = true;
            this.exportLocationLabel.Location = new System.Drawing.Point(3, 276);
            this.exportLocationLabel.Name = "exportLocationLabel";
            this.exportLocationLabel.Size = new System.Drawing.Size(84, 13);
            this.exportLocationLabel.TabIndex = 13;
            this.exportLocationLabel.Text = "Export Location:";
            // 
            // gameLocationLabel
            // 
            this.gameLocationLabel.AutoSize = true;
            this.gameLocationLabel.Location = new System.Drawing.Point(3, 254);
            this.gameLocationLabel.Name = "gameLocationLabel";
            this.gameLocationLabel.Size = new System.Drawing.Size(82, 13);
            this.gameLocationLabel.TabIndex = 12;
            this.gameLocationLabel.Text = "Game Location:";
            this.toolTip1.SetToolTip(this.gameLocationLabel, "The location of hl2.exe for Team Fortress 2.");
            // 
            // startPackagingButton
            // 
            this.startPackagingButton.Location = new System.Drawing.Point(4, 299);
            this.startPackagingButton.Name = "startPackagingButton";
            this.startPackagingButton.Size = new System.Drawing.Size(725, 44);
            this.startPackagingButton.TabIndex = 11;
            this.startPackagingButton.Text = "Begin Packaging";
            this.startPackagingButton.UseVisualStyleBackColor = true;
            this.startPackagingButton.Click += new System.EventHandler(this.StartPackagingButton_Click);
            // 
            // progressBox
            // 
            this.progressBox.Location = new System.Drawing.Point(4, 349);
            this.progressBox.Multiline = true;
            this.progressBox.Name = "progressBox";
            this.progressBox.ReadOnly = true;
            this.progressBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.progressBox.Size = new System.Drawing.Size(725, 183);
            this.progressBox.TabIndex = 10;
            // 
            // saveFileLocationButton
            // 
            this.saveFileLocationButton.Location = new System.Drawing.Point(463, 273);
            this.saveFileLocationButton.Name = "saveFileLocationButton";
            this.saveFileLocationButton.Size = new System.Drawing.Size(158, 20);
            this.saveFileLocationButton.TabIndex = 9;
            this.saveFileLocationButton.Text = "Set VPK Export Location...";
            this.saveFileLocationButton.UseVisualStyleBackColor = true;
            this.saveFileLocationButton.Click += new System.EventHandler(this.SaveFileLocationButton_Click);
            // 
            // saveFileLocationText
            // 
            this.saveFileLocationText.Location = new System.Drawing.Point(91, 273);
            this.saveFileLocationText.Name = "saveFileLocationText";
            this.saveFileLocationText.Size = new System.Drawing.Size(366, 20);
            this.saveFileLocationText.TabIndex = 8;
            this.saveFileLocationText.Leave += new System.EventHandler(this.SaveFileLocationText_Leave);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "vpk";
            this.saveFileDialog1.Filter = "Valve Pak|*.vpk";
            this.saveFileDialog1.Title = "Please specify a location for the output VPK.";
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.SaveFileDialog1_FileOk);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 559);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(735, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(42, 17);
            this.toolStripStatusLabel1.Text = "Ready.";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Half Life 2 Executable|hl2.exe";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenFileDialog1_FileOk);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 581);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.windowTabControls);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Team Fortress 2 Mass Asset Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.windowTabControls.ResumeLayout(false);
            this.tabMaterials.ResumeLayout(false);
            this.tabMaterials.PerformLayout();
            this.parameterSettingsGroupBox.ResumeLayout(false);
            this.randomizerSettingsGroupBox.ResumeLayout(false);
            this.randomizerSettingsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.randomizerChanceTrackBar)).EndInit();
            this.deviationSettingsGroupBox.ResumeLayout(false);
            this.deviationSettingsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.randomizerOffsetNumeric3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.randomizerOffsetNumeric2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.randomizerOffsetNumeric)).EndInit();
            this.filterSettingsGroupBox.ResumeLayout(false);
            this.filterSettingsGroupBox.PerformLayout();
            this.miscellaneousSettingsGroupBox.ResumeLayout(false);
            this.miscellaneousSettingsGroupBox.PerformLayout();
            this.tabExport.ResumeLayout(false);
            this.tabExport.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl windowTabControls;
        private System.Windows.Forms.TabPage tabMaterials;
        private System.Windows.Forms.TabPage tabSounds;
        private System.Windows.Forms.CheckedListBox materialParameterList;
        private System.Windows.Forms.Label parametersLabel;
        private System.Windows.Forms.Button manageParametersButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.GroupBox parameterSettingsGroupBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TreeView vpkDirectoryListing;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TabPage tabExport;
        private System.Windows.Forms.Button startPackagingButton;
        private System.Windows.Forms.TextBox progressBox;
        private System.Windows.Forms.Button saveFileLocationButton;
        private System.Windows.Forms.TextBox saveFileLocationText;
        private System.Windows.Forms.Button gameFileLocationButton;
        private System.Windows.Forms.TextBox gameLocationText;
        private System.Windows.Forms.Label exportLocationLabel;
        private System.Windows.Forms.Label gameLocationLabel;
        private System.Windows.Forms.Label exportLocationValidLabel;
        private System.Windows.Forms.Label gameLocationValidLabel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox randomizerSettingsGroupBox;
        private System.Windows.Forms.GroupBox deviationSettingsGroupBox;
        private System.Windows.Forms.Label deviationSettingsParam1Label;
        private System.Windows.Forms.NumericUpDown randomizerOffsetNumeric;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label deviationSettingsParam3Label;
        private System.Windows.Forms.NumericUpDown randomizerOffsetNumeric3;
        private System.Windows.Forms.Label deviationSettingsParam2Label;
        private System.Windows.Forms.NumericUpDown randomizerOffsetNumeric2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox overwriteModeComboBox;
        private System.Windows.Forms.TabPage tabModels;
        private System.Windows.Forms.TabPage tabParticles;
        private System.Windows.Forms.TabPage tabScripts;
        private System.Windows.Forms.CheckBox verboseModeCheckBox;
        private System.Windows.Forms.GroupBox filterSettingsGroupBox;
        private System.Windows.Forms.Button excludedShadersButton;
        private System.Windows.Forms.GroupBox miscellaneousSettingsGroupBox;
        private System.Windows.Forms.CheckBox caseInsensitiveCheckBox;
        private System.Windows.Forms.TabPage tabTextures;
        private System.Windows.Forms.TabPage tabLocalization;
        private System.Windows.Forms.TrackBar randomizerChanceTrackBar;
        private System.Windows.Forms.Label randomizerChanceLabel;
        private System.Windows.Forms.CheckBox customFilesCheckBox;
        private System.Windows.Forms.CheckedListBox customFileCheckList;
        private System.Windows.Forms.Button proxyFilterButton;
    }
}

