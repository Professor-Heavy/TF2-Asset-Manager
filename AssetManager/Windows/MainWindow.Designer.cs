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
            System.Windows.Forms.TabPage tabMaterialModification;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.materialSettingsResizePanel = new System.Windows.Forms.Panel();
            this.materialParametersLabel = new System.Windows.Forms.Label();
            this.materialParameterList = new System.Windows.Forms.CheckedListBox();
            this.manageMaterialParametersButton = new System.Windows.Forms.Button();
            this.materialParameterSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.overwriteModeComboBox = new System.Windows.Forms.ComboBox();
            this.materialRandomizerSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.materialSeedSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.materialSeedSettingsOffsetNumeric = new System.Windows.Forms.NumericUpDown();
            this.materialSeedSettingsOffsetLabel = new System.Windows.Forms.Label();
            this.materialSeedSettingsRandomizerNumeric = new System.Windows.Forms.NumericUpDown();
            this.materialSeedSettingsRandomizerLabel = new System.Windows.Forms.Label();
            this.materialRandomizerChanceLabel = new System.Windows.Forms.Label();
            this.materialRandomizerChanceTrackBar = new System.Windows.Forms.TrackBar();
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
            this.windowTabControls = new System.Windows.Forms.TabControl();
            this.tabMaterials = new System.Windows.Forms.TabPage();
            this.materialTabControls = new System.Windows.Forms.TabControl();
            this.tabMaterialCorruption = new System.Windows.Forms.TabPage();
            this.corruptionSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.corruptionOffsetGroupBox = new System.Windows.Forms.GroupBox();
            this.materialCorruptionOffsetSeedNumeric = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.corruptionOffsetSettingsButton = new System.Windows.Forms.Button();
            this.corruptionOffsetChanceLabel = new System.Windows.Forms.Label();
            this.corruptionOffsetFilterButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.corruptionOffsetTrackBar = new System.Windows.Forms.TrackBar();
            this.corruptionOffsetCheckBox = new System.Windows.Forms.CheckBox();
            this.corruptionSwapSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.materialCorruptionSwapSeedNumeric = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.corruptionSwapChanceLabel = new System.Windows.Forms.Label();
            this.corruptionSwapFilterButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.corruptionSwapTrackBar = new System.Windows.Forms.TrackBar();
            this.corruptionSwapEnableCheckBox = new System.Windows.Forms.CheckBox();
            this.materialCorruptionEnableCheckBox = new System.Windows.Forms.CheckBox();
            this.tabTextures = new System.Windows.Forms.TabPage();
            this.textureTabControls = new System.Windows.Forms.TabControl();
            this.tabTextureModification = new System.Windows.Forms.TabPage();
            this.textureSettingsResizeLabel = new System.Windows.Forms.Panel();
            this.textureParametersLabel = new System.Windows.Forms.Label();
            this.checkedListBox2 = new System.Windows.Forms.CheckedListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tabTextureCorruption = new System.Windows.Forms.TabPage();
            this.tabTextureAddition = new System.Windows.Forms.TabPage();
            this.tabModels = new System.Windows.Forms.TabPage();
            this.tabParticles = new System.Windows.Forms.TabPage();
            this.tabSounds = new System.Windows.Forms.TabPage();
            this.soundsTabControls = new System.Windows.Forms.TabControl();
            this.tabSoundModification = new System.Windows.Forms.TabPage();
            this.soundSettingsResizePanel = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.soundParameterList = new System.Windows.Forms.CheckedListBox();
            this.manageSoundParametersButton = new System.Windows.Forms.Button();
            this.tabSoundCorruption = new System.Windows.Forms.TabPage();
            this.tabSoundAddition = new System.Windows.Forms.TabPage();
            this.soundFileRemoveButton = new System.Windows.Forms.Button();
            this.soundFileAddButton = new System.Windows.Forms.Button();
            this.soundFileListingDataGridView = new System.Windows.Forms.DataGridView();
            this.Key = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FullLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PreviewButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tabScripts = new System.Windows.Forms.TabPage();
            this.tabLocalization = new System.Windows.Forms.TabPage();
            this.localisationTabControls = new System.Windows.Forms.TabControl();
            this.tabLocalisationModification = new System.Windows.Forms.TabPage();
            this.localisationParameterSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.localisationLetterCountMaxLabel = new System.Windows.Forms.Label();
            this.localisationLetterCountMaxNumeric = new System.Windows.Forms.NumericUpDown();
            this.localisationLetterCountMinLabel = new System.Windows.Forms.Label();
            this.localisationLetterCountMinNumeric = new System.Windows.Forms.NumericUpDown();
            this.localisationLetterCountCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.localisationRandomizerIndividualChanceLabel = new System.Windows.Forms.Label();
            this.localisationRandomizerIndividualChanceTrackBar = new System.Windows.Forms.TrackBar();
            this.label7 = new System.Windows.Forms.Label();
            this.localisationRandomizerChanceLabel = new System.Windows.Forms.Label();
            this.localisationRandomizerChanceTrackBar = new System.Windows.Forms.TrackBar();
            this.label10 = new System.Windows.Forms.Label();
            this.localisationSettingsResizePanel = new System.Windows.Forms.Panel();
            this.localisationParametersLabel = new System.Windows.Forms.Label();
            this.localisationParameterList = new System.Windows.Forms.CheckedListBox();
            this.manageLocalisationParametersButton = new System.Windows.Forms.Button();
            this.tabLocalisationCorruption = new System.Windows.Forms.TabPage();
            this.localisationCorruptionSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.localisationCorruptionScrambleSettingsButton = new System.Windows.Forms.Button();
            this.localisationCorruptionScrambleChanceLabel = new System.Windows.Forms.Label();
            this.localisationCorruptionScrambleFilterButton = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.localisationCorruptionScrambleTrackBar = new System.Windows.Forms.TrackBar();
            this.localisationCorruptionScrambleEnableCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.localisationCorruptionIndividualOffsetLabel = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.localisationCorruptionIndividualOffsetTrackBar = new System.Windows.Forms.TrackBar();
            this.localisationCorruptionOffsetSettingsButton = new System.Windows.Forms.Button();
            this.localisationCorruptionOffsetChanceLabel = new System.Windows.Forms.Label();
            this.localisationCorruptionOffsetFilterButton = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.localisationCorruptionOffsetTrackBar = new System.Windows.Forms.TrackBar();
            this.localisationCorruptionOffsetEnableCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.localisationCorruptionLanguageSettingsButton = new System.Windows.Forms.Button();
            this.localisationCorruptionLanguageChanceLabel = new System.Windows.Forms.Label();
            this.localisationCorruptionLanguageFilterButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.localisationCorruptionLanguageTrackBar = new System.Windows.Forms.TrackBar();
            this.localisationCorruptionLanguageEnableCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.localisationCorruptionSwapChanceLabel = new System.Windows.Forms.Label();
            this.localisationCorruptionSwapFilterButton = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.localisationCorruptionSwapTrackBar = new System.Windows.Forms.TrackBar();
            this.localisationCorruptionSwapEnableCheckBox = new System.Windows.Forms.CheckBox();
            this.localisationCorruptionEnableCheckBox = new System.Windows.Forms.CheckBox();
            this.tabExport = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.parametersForExportList = new System.Windows.Forms.ListBox();
            this.customFileCheckList = new System.Windows.Forms.CheckedListBox();
            this.customFilesCheckBox = new System.Windows.Forms.CheckBox();
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
            this.tabConfiguration = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.enableAutosaveCheckBox = new System.Windows.Forms.CheckBox();
            this.label18 = new System.Windows.Forms.Label();
            this.autosaveIntervalNumeric = new System.Windows.Forms.NumericUpDown();
            this.exportParametersButton = new System.Windows.Forms.Button();
            this.importParametersButton = new System.Windows.Forms.Button();
            this.launchGameArgumentsTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.disableNotificationsCheckBox = new System.Windows.Forms.CheckBox();
            this.launchGameCheckBox = new System.Windows.Forms.CheckBox();
            this.muteCheckBox = new System.Windows.Forms.CheckBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.executableOpenFileDialogue = new System.Windows.Forms.OpenFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.importOpenFileDialogue = new System.Windows.Forms.OpenFileDialog();
            this.soundOpenFileDialogue = new System.Windows.Forms.OpenFileDialog();
            this.localisationSeedSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.localisationSeedSettingsIndividualNumeric = new System.Windows.Forms.NumericUpDown();
            this.localisationSeedSettingsRandomizerNumeric = new System.Windows.Forms.NumericUpDown();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.localisationCorruptionScrambleSeedNumeric = new System.Windows.Forms.NumericUpDown();
            this.label21 = new System.Windows.Forms.Label();
            this.localisationCorruptionOffsetSeedNumeric = new System.Windows.Forms.NumericUpDown();
            this.label23 = new System.Windows.Forms.Label();
            this.localisationCorruptionLanguageSeedNumeric = new System.Windows.Forms.NumericUpDown();
            this.label24 = new System.Windows.Forms.Label();
            this.localisationCorruptionSwapSeedNumeric = new System.Windows.Forms.NumericUpDown();
            this.label25 = new System.Windows.Forms.Label();
            tabMaterialModification = new System.Windows.Forms.TabPage();
            tabMaterialModification.SuspendLayout();
            this.materialSettingsResizePanel.SuspendLayout();
            this.materialParameterSettingsGroupBox.SuspendLayout();
            this.materialRandomizerSettingsGroupBox.SuspendLayout();
            this.materialSeedSettingsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.materialSeedSettingsOffsetNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialSeedSettingsRandomizerNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialRandomizerChanceTrackBar)).BeginInit();
            this.deviationSettingsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.randomizerOffsetNumeric3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.randomizerOffsetNumeric2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.randomizerOffsetNumeric)).BeginInit();
            this.filterSettingsGroupBox.SuspendLayout();
            this.miscellaneousSettingsGroupBox.SuspendLayout();
            this.windowTabControls.SuspendLayout();
            this.tabMaterials.SuspendLayout();
            this.materialTabControls.SuspendLayout();
            this.tabMaterialCorruption.SuspendLayout();
            this.corruptionSettingsGroupBox.SuspendLayout();
            this.corruptionOffsetGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.materialCorruptionOffsetSeedNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.corruptionOffsetTrackBar)).BeginInit();
            this.corruptionSwapSettingsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.materialCorruptionSwapSeedNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.corruptionSwapTrackBar)).BeginInit();
            this.tabTextures.SuspendLayout();
            this.textureTabControls.SuspendLayout();
            this.tabTextureModification.SuspendLayout();
            this.textureSettingsResizeLabel.SuspendLayout();
            this.tabSounds.SuspendLayout();
            this.soundsTabControls.SuspendLayout();
            this.tabSoundModification.SuspendLayout();
            this.soundSettingsResizePanel.SuspendLayout();
            this.tabSoundAddition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.soundFileListingDataGridView)).BeginInit();
            this.tabLocalization.SuspendLayout();
            this.localisationTabControls.SuspendLayout();
            this.tabLocalisationModification.SuspendLayout();
            this.localisationParameterSettingsGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.localisationLetterCountMaxNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.localisationLetterCountMinNumeric)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.localisationRandomizerIndividualChanceTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.localisationRandomizerChanceTrackBar)).BeginInit();
            this.localisationSettingsResizePanel.SuspendLayout();
            this.tabLocalisationCorruption.SuspendLayout();
            this.localisationCorruptionSettingsGroupBox.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.localisationCorruptionScrambleTrackBar)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.localisationCorruptionIndividualOffsetTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.localisationCorruptionOffsetTrackBar)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.localisationCorruptionLanguageTrackBar)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.localisationCorruptionSwapTrackBar)).BeginInit();
            this.tabExport.SuspendLayout();
            this.tabConfiguration.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.autosaveIntervalNumeric)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.localisationSeedSettingsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.localisationSeedSettingsIndividualNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.localisationSeedSettingsRandomizerNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.localisationCorruptionScrambleSeedNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.localisationCorruptionOffsetSeedNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.localisationCorruptionLanguageSeedNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.localisationCorruptionSwapSeedNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // tabMaterialModification
            // 
            tabMaterialModification.Controls.Add(this.materialSettingsResizePanel);
            tabMaterialModification.Controls.Add(this.materialParameterSettingsGroupBox);
            tabMaterialModification.Location = new System.Drawing.Point(4, 22);
            tabMaterialModification.Name = "tabMaterialModification";
            tabMaterialModification.Padding = new System.Windows.Forms.Padding(3);
            tabMaterialModification.Size = new System.Drawing.Size(734, 589);
            tabMaterialModification.TabIndex = 0;
            tabMaterialModification.Text = "Modification";
            tabMaterialModification.UseVisualStyleBackColor = true;
            // 
            // materialSettingsResizePanel
            // 
            this.materialSettingsResizePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialSettingsResizePanel.Controls.Add(this.materialParametersLabel);
            this.materialSettingsResizePanel.Controls.Add(this.materialParameterList);
            this.materialSettingsResizePanel.Controls.Add(this.manageMaterialParametersButton);
            this.materialSettingsResizePanel.Location = new System.Drawing.Point(6, 0);
            this.materialSettingsResizePanel.Name = "materialSettingsResizePanel";
            this.materialSettingsResizePanel.Size = new System.Drawing.Size(163, 589);
            this.materialSettingsResizePanel.TabIndex = 0;
            // 
            // materialParametersLabel
            // 
            this.materialParametersLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialParametersLabel.AutoSize = true;
            this.materialParametersLabel.Location = new System.Drawing.Point(49, 3);
            this.materialParametersLabel.Name = "materialParametersLabel";
            this.materialParametersLabel.Size = new System.Drawing.Size(60, 13);
            this.materialParametersLabel.TabIndex = 1;
            this.materialParametersLabel.Text = "Parameters";
            this.materialParametersLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // materialParameterList
            // 
            this.materialParameterList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialParameterList.FormattingEnabled = true;
            this.materialParameterList.HorizontalScrollbar = true;
            this.materialParameterList.IntegralHeight = false;
            this.materialParameterList.Location = new System.Drawing.Point(3, 19);
            this.materialParameterList.Name = "materialParameterList";
            this.materialParameterList.Size = new System.Drawing.Size(157, 539);
            this.materialParameterList.TabIndex = 0;
            this.materialParameterList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MaterialParameterList_MouseClick);
            this.materialParameterList.SelectedIndexChanged += new System.EventHandler(this.materialParameterList_SelectedIndexChanged);
            this.materialParameterList.Enter += new System.EventHandler(this.materialParameterList_Enter);
            // 
            // manageMaterialParametersButton
            // 
            this.manageMaterialParametersButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.manageMaterialParametersButton.Location = new System.Drawing.Point(3, 563);
            this.manageMaterialParametersButton.Name = "manageMaterialParametersButton";
            this.manageMaterialParametersButton.Size = new System.Drawing.Size(157, 23);
            this.manageMaterialParametersButton.TabIndex = 2;
            this.manageMaterialParametersButton.Text = "Manage Parameters";
            this.toolTip1.SetToolTip(this.manageMaterialParametersButton, "Add, remove, and edit material parameters.");
            this.manageMaterialParametersButton.UseVisualStyleBackColor = true;
            this.manageMaterialParametersButton.Click += new System.EventHandler(this.ManageParameterButton_Click);
            // 
            // materialParameterSettingsGroupBox
            // 
            this.materialParameterSettingsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialParameterSettingsGroupBox.Controls.Add(this.overwriteModeComboBox);
            this.materialParameterSettingsGroupBox.Controls.Add(this.materialRandomizerSettingsGroupBox);
            this.materialParameterSettingsGroupBox.Controls.Add(this.filterSettingsGroupBox);
            this.materialParameterSettingsGroupBox.Controls.Add(this.miscellaneousSettingsGroupBox);
            this.materialParameterSettingsGroupBox.Location = new System.Drawing.Point(175, 6);
            this.materialParameterSettingsGroupBox.Name = "materialParameterSettingsGroupBox";
            this.materialParameterSettingsGroupBox.Size = new System.Drawing.Size(550, 580);
            this.materialParameterSettingsGroupBox.TabIndex = 1;
            this.materialParameterSettingsGroupBox.TabStop = false;
            this.materialParameterSettingsGroupBox.Text = "Parameter Settings";
            this.materialParameterSettingsGroupBox.Visible = false;
            // 
            // overwriteModeComboBox
            // 
            this.overwriteModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.overwriteModeComboBox.FormattingEnabled = true;
            this.overwriteModeComboBox.Items.AddRange(new object[] {
            "Always write parameter to file",
            "Only write if parameter already exists in file",
            "Only write if parameter is not in file"});
            this.overwriteModeComboBox.Location = new System.Drawing.Point(302, 418);
            this.overwriteModeComboBox.Name = "overwriteModeComboBox";
            this.overwriteModeComboBox.Size = new System.Drawing.Size(229, 21);
            this.overwriteModeComboBox.TabIndex = 12;
            this.toolTip1.SetToolTip(this.overwriteModeComboBox, "Set how this parameter will affect material files that already have relevant para" +
        "meters.");
            this.overwriteModeComboBox.SelectedIndexChanged += new System.EventHandler(this.OverwriteModeComboBox_SelectedIndexChanged);
            // 
            // materialRandomizerSettingsGroupBox
            // 
            this.materialRandomizerSettingsGroupBox.Controls.Add(this.materialSeedSettingsGroupBox);
            this.materialRandomizerSettingsGroupBox.Controls.Add(this.materialRandomizerChanceLabel);
            this.materialRandomizerSettingsGroupBox.Controls.Add(this.materialRandomizerChanceTrackBar);
            this.materialRandomizerSettingsGroupBox.Controls.Add(this.deviationSettingsGroupBox);
            this.materialRandomizerSettingsGroupBox.Controls.Add(this.label5);
            this.materialRandomizerSettingsGroupBox.Location = new System.Drawing.Point(208, 19);
            this.materialRandomizerSettingsGroupBox.Name = "materialRandomizerSettingsGroupBox";
            this.materialRandomizerSettingsGroupBox.Size = new System.Drawing.Size(332, 374);
            this.materialRandomizerSettingsGroupBox.TabIndex = 2;
            this.materialRandomizerSettingsGroupBox.TabStop = false;
            this.materialRandomizerSettingsGroupBox.Text = "Randomizer Settings";
            // 
            // materialSeedSettingsGroupBox
            // 
            this.materialSeedSettingsGroupBox.Controls.Add(this.materialSeedSettingsOffsetNumeric);
            this.materialSeedSettingsGroupBox.Controls.Add(this.materialSeedSettingsOffsetLabel);
            this.materialSeedSettingsGroupBox.Controls.Add(this.materialSeedSettingsRandomizerNumeric);
            this.materialSeedSettingsGroupBox.Controls.Add(this.materialSeedSettingsRandomizerLabel);
            this.materialSeedSettingsGroupBox.Location = new System.Drawing.Point(9, 172);
            this.materialSeedSettingsGroupBox.Name = "materialSeedSettingsGroupBox";
            this.materialSeedSettingsGroupBox.Size = new System.Drawing.Size(313, 77);
            this.materialSeedSettingsGroupBox.TabIndex = 8;
            this.materialSeedSettingsGroupBox.TabStop = false;
            this.materialSeedSettingsGroupBox.Text = "Seed Settings (-1 for no seed)";
            // 
            // materialSeedSettingsOffsetNumeric
            // 
            this.materialSeedSettingsOffsetNumeric.Location = new System.Drawing.Point(187, 45);
            this.materialSeedSettingsOffsetNumeric.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.materialSeedSettingsOffsetNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.materialSeedSettingsOffsetNumeric.Name = "materialSeedSettingsOffsetNumeric";
            this.materialSeedSettingsOffsetNumeric.Size = new System.Drawing.Size(120, 20);
            this.materialSeedSettingsOffsetNumeric.TabIndex = 3;
            this.materialSeedSettingsOffsetNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.materialSeedSettingsOffsetNumeric.ValueChanged += new System.EventHandler(this.materialSeedSettingsOffsetNumeric_ValueChanged);
            // 
            // materialSeedSettingsOffsetLabel
            // 
            this.materialSeedSettingsOffsetLabel.AutoSize = true;
            this.materialSeedSettingsOffsetLabel.Location = new System.Drawing.Point(8, 47);
            this.materialSeedSettingsOffsetLabel.Name = "materialSeedSettingsOffsetLabel";
            this.materialSeedSettingsOffsetLabel.Size = new System.Drawing.Size(131, 13);
            this.materialSeedSettingsOffsetLabel.TabIndex = 2;
            this.materialSeedSettingsOffsetLabel.Text = "Parameter Deviation Seed";
            // 
            // materialSeedSettingsRandomizerNumeric
            // 
            this.materialSeedSettingsRandomizerNumeric.Location = new System.Drawing.Point(187, 23);
            this.materialSeedSettingsRandomizerNumeric.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.materialSeedSettingsRandomizerNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.materialSeedSettingsRandomizerNumeric.Name = "materialSeedSettingsRandomizerNumeric";
            this.materialSeedSettingsRandomizerNumeric.Size = new System.Drawing.Size(120, 20);
            this.materialSeedSettingsRandomizerNumeric.TabIndex = 1;
            this.materialSeedSettingsRandomizerNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.materialSeedSettingsRandomizerNumeric.ValueChanged += new System.EventHandler(this.materialSeedSettingsRandomizerNumeric_ValueChanged);
            // 
            // materialSeedSettingsRandomizerLabel
            // 
            this.materialSeedSettingsRandomizerLabel.AutoSize = true;
            this.materialSeedSettingsRandomizerLabel.Location = new System.Drawing.Point(8, 25);
            this.materialSeedSettingsRandomizerLabel.Name = "materialSeedSettingsRandomizerLabel";
            this.materialSeedSettingsRandomizerLabel.Size = new System.Drawing.Size(156, 13);
            this.materialSeedSettingsRandomizerLabel.TabIndex = 0;
            this.materialSeedSettingsRandomizerLabel.Text = "Probability of Appearance Seed";
            // 
            // materialRandomizerChanceLabel
            // 
            this.materialRandomizerChanceLabel.AutoSize = true;
            this.materialRandomizerChanceLabel.Location = new System.Drawing.Point(290, 36);
            this.materialRandomizerChanceLabel.Name = "materialRandomizerChanceLabel";
            this.materialRandomizerChanceLabel.Size = new System.Drawing.Size(21, 13);
            this.materialRandomizerChanceLabel.TabIndex = 7;
            this.materialRandomizerChanceLabel.Text = "0%";
            this.materialRandomizerChanceLabel.TextChanged += new System.EventHandler(this.MaterialRandomizerChanceLabel_TextChanged);
            // 
            // materialRandomizerChanceTrackBar
            // 
            this.materialRandomizerChanceTrackBar.AutoSize = false;
            this.materialRandomizerChanceTrackBar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.materialRandomizerChanceTrackBar.Location = new System.Drawing.Point(9, 32);
            this.materialRandomizerChanceTrackBar.Maximum = 100;
            this.materialRandomizerChanceTrackBar.Name = "materialRandomizerChanceTrackBar";
            this.materialRandomizerChanceTrackBar.Size = new System.Drawing.Size(276, 30);
            this.materialRandomizerChanceTrackBar.TabIndex = 0;
            this.materialRandomizerChanceTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.toolTip1.SetToolTip(this.materialRandomizerChanceTrackBar, "Affects the chance that this parameter has to appear in outputs.");
            this.materialRandomizerChanceTrackBar.Scroll += new System.EventHandler(this.MaterialRandomizerChanceTrackBar_Scroll);
            this.materialRandomizerChanceTrackBar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.RandomizerScrollBarChanged);
            this.materialRandomizerChanceTrackBar.MouseCaptureChanged += new System.EventHandler(this.MaterialRandomizerScrollBarChanged);
            // 
            // deviationSettingsGroupBox
            // 
            this.deviationSettingsGroupBox.Controls.Add(this.deviationSettingsParam3Label);
            this.deviationSettingsGroupBox.Controls.Add(this.randomizerOffsetNumeric3);
            this.deviationSettingsGroupBox.Controls.Add(this.deviationSettingsParam2Label);
            this.deviationSettingsGroupBox.Controls.Add(this.randomizerOffsetNumeric2);
            this.deviationSettingsGroupBox.Controls.Add(this.deviationSettingsParam1Label);
            this.deviationSettingsGroupBox.Controls.Add(this.randomizerOffsetNumeric);
            this.deviationSettingsGroupBox.Location = new System.Drawing.Point(9, 68);
            this.deviationSettingsGroupBox.Name = "deviationSettingsGroupBox";
            this.deviationSettingsGroupBox.Size = new System.Drawing.Size(313, 98);
            this.deviationSettingsGroupBox.TabIndex = 1;
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
            this.randomizerOffsetNumeric3.TabIndex = 2;
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
            this.randomizerOffsetNumeric2.TabIndex = 1;
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
            this.filterSettingsGroupBox.Size = new System.Drawing.Size(193, 551);
            this.filterSettingsGroupBox.TabIndex = 1;
            this.filterSettingsGroupBox.TabStop = false;
            this.filterSettingsGroupBox.Text = "Filter Settings";
            // 
            // proxyFilterButton
            // 
            this.proxyFilterButton.Location = new System.Drawing.Point(6, 445);
            this.proxyFilterButton.Name = "proxyFilterButton";
            this.proxyFilterButton.Size = new System.Drawing.Size(180, 23);
            this.proxyFilterButton.TabIndex = 3;
            this.proxyFilterButton.Text = "Proxy Filter...";
            this.toolTip1.SetToolTip(this.proxyFilterButton, "Control if this parameter is affected by pre-existing proxies in files.");
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
            this.caseInsensitiveCheckBox.TabIndex = 1;
            this.caseInsensitiveCheckBox.Text = "Case-Insensitive (Recommended)";
            this.toolTip1.SetToolTip(this.caseInsensitiveCheckBox, "If checked, this parameter will replace parameters regardless of case matching.");
            this.caseInsensitiveCheckBox.UseVisualStyleBackColor = true;
            // 
            // excludedShadersButton
            // 
            this.excludedShadersButton.Location = new System.Drawing.Point(6, 416);
            this.excludedShadersButton.Name = "excludedShadersButton";
            this.excludedShadersButton.Size = new System.Drawing.Size(180, 23);
            this.excludedShadersButton.TabIndex = 2;
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
            this.vpkDirectoryListing.TabIndex = 0;
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
            this.miscellaneousSettingsGroupBox.Size = new System.Drawing.Size(332, 171);
            this.miscellaneousSettingsGroupBox.TabIndex = 3;
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
            this.windowTabControls.Controls.Add(this.tabConfiguration);
            this.windowTabControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.windowTabControls.Location = new System.Drawing.Point(0, 0);
            this.windowTabControls.Name = "windowTabControls";
            this.windowTabControls.SelectedIndex = 0;
            this.windowTabControls.Size = new System.Drawing.Size(752, 662);
            this.windowTabControls.TabIndex = 0;
            this.windowTabControls.SelectedIndexChanged += new System.EventHandler(this.WindowTabControls_SelectedIndexChanged);
            // 
            // tabMaterials
            // 
            this.tabMaterials.Controls.Add(this.materialTabControls);
            this.tabMaterials.Location = new System.Drawing.Point(4, 22);
            this.tabMaterials.Name = "tabMaterials";
            this.tabMaterials.Padding = new System.Windows.Forms.Padding(3);
            this.tabMaterials.Size = new System.Drawing.Size(744, 636);
            this.tabMaterials.TabIndex = 0;
            this.tabMaterials.Text = "Materials";
            this.toolTip1.SetToolTip(this.tabMaterials, "Modify material parameters.");
            this.tabMaterials.UseVisualStyleBackColor = true;
            // 
            // materialTabControls
            // 
            this.materialTabControls.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialTabControls.Controls.Add(tabMaterialModification);
            this.materialTabControls.Controls.Add(this.tabMaterialCorruption);
            this.materialTabControls.Location = new System.Drawing.Point(0, 0);
            this.materialTabControls.Name = "materialTabControls";
            this.materialTabControls.SelectedIndex = 0;
            this.materialTabControls.Size = new System.Drawing.Size(742, 615);
            this.materialTabControls.TabIndex = 1;
            this.materialTabControls.SelectedIndexChanged += new System.EventHandler(this.materialTabControls_SelectedIndexChanged);
            // 
            // tabMaterialCorruption
            // 
            this.tabMaterialCorruption.Controls.Add(this.corruptionSettingsGroupBox);
            this.tabMaterialCorruption.Controls.Add(this.materialCorruptionEnableCheckBox);
            this.tabMaterialCorruption.Location = new System.Drawing.Point(4, 22);
            this.tabMaterialCorruption.Name = "tabMaterialCorruption";
            this.tabMaterialCorruption.Padding = new System.Windows.Forms.Padding(3);
            this.tabMaterialCorruption.Size = new System.Drawing.Size(734, 589);
            this.tabMaterialCorruption.TabIndex = 1;
            this.tabMaterialCorruption.Text = "Corruption";
            this.tabMaterialCorruption.UseVisualStyleBackColor = true;
            // 
            // corruptionSettingsGroupBox
            // 
            this.corruptionSettingsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.corruptionSettingsGroupBox.Controls.Add(this.corruptionOffsetGroupBox);
            this.corruptionSettingsGroupBox.Controls.Add(this.corruptionSwapSettingsGroupBox);
            this.corruptionSettingsGroupBox.Enabled = false;
            this.corruptionSettingsGroupBox.Location = new System.Drawing.Point(8, 26);
            this.corruptionSettingsGroupBox.Name = "corruptionSettingsGroupBox";
            this.corruptionSettingsGroupBox.Size = new System.Drawing.Size(717, 556);
            this.corruptionSettingsGroupBox.TabIndex = 1;
            this.corruptionSettingsGroupBox.TabStop = false;
            this.corruptionSettingsGroupBox.Text = "Corruption Settings";
            // 
            // corruptionOffsetGroupBox
            // 
            this.corruptionOffsetGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.corruptionOffsetGroupBox.Controls.Add(this.materialCorruptionOffsetSeedNumeric);
            this.corruptionOffsetGroupBox.Controls.Add(this.label14);
            this.corruptionOffsetGroupBox.Controls.Add(this.corruptionOffsetSettingsButton);
            this.corruptionOffsetGroupBox.Controls.Add(this.corruptionOffsetChanceLabel);
            this.corruptionOffsetGroupBox.Controls.Add(this.corruptionOffsetFilterButton);
            this.corruptionOffsetGroupBox.Controls.Add(this.label4);
            this.corruptionOffsetGroupBox.Controls.Add(this.corruptionOffsetTrackBar);
            this.corruptionOffsetGroupBox.Controls.Add(this.corruptionOffsetCheckBox);
            this.corruptionOffsetGroupBox.Location = new System.Drawing.Point(6, 125);
            this.corruptionOffsetGroupBox.Name = "corruptionOffsetGroupBox";
            this.corruptionOffsetGroupBox.Size = new System.Drawing.Size(705, 100);
            this.corruptionOffsetGroupBox.TabIndex = 2;
            this.corruptionOffsetGroupBox.TabStop = false;
            this.corruptionOffsetGroupBox.Text = "Random Number Offset";
            // 
            // materialCorruptionOffsetSeedNumeric
            // 
            this.materialCorruptionOffsetSeedNumeric.Location = new System.Drawing.Point(542, 74);
            this.materialCorruptionOffsetSeedNumeric.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.materialCorruptionOffsetSeedNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.materialCorruptionOffsetSeedNumeric.Name = "materialCorruptionOffsetSeedNumeric";
            this.materialCorruptionOffsetSeedNumeric.Size = new System.Drawing.Size(120, 20);
            this.materialCorruptionOffsetSeedNumeric.TabIndex = 14;
            this.materialCorruptionOffsetSeedNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.materialCorruptionOffsetSeedNumeric.ValueChanged += new System.EventHandler(this.materialCorruptionOffsetSeedNumeric_ValueChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(387, 76);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(149, 13);
            this.label14.TabIndex = 13;
            this.label14.Text = "Probability of Corruption Seed:";
            // 
            // corruptionOffsetSettingsButton
            // 
            this.corruptionOffsetSettingsButton.Location = new System.Drawing.Point(6, 66);
            this.corruptionOffsetSettingsButton.Name = "corruptionOffsetSettingsButton";
            this.corruptionOffsetSettingsButton.Size = new System.Drawing.Size(249, 25);
            this.corruptionOffsetSettingsButton.TabIndex = 11;
            this.corruptionOffsetSettingsButton.Text = "Offset Settings...";
            this.corruptionOffsetSettingsButton.UseVisualStyleBackColor = true;
            this.corruptionOffsetSettingsButton.Click += new System.EventHandler(this.CorruptionOffsetSettingsButton_Click);
            // 
            // corruptionOffsetChanceLabel
            // 
            this.corruptionOffsetChanceLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.corruptionOffsetChanceLabel.AutoSize = true;
            this.corruptionOffsetChanceLabel.Location = new System.Drawing.Point(668, 35);
            this.corruptionOffsetChanceLabel.Name = "corruptionOffsetChanceLabel";
            this.corruptionOffsetChanceLabel.Size = new System.Drawing.Size(33, 13);
            this.corruptionOffsetChanceLabel.TabIndex = 10;
            this.corruptionOffsetChanceLabel.Text = "100%";
            this.corruptionOffsetChanceLabel.TextChanged += new System.EventHandler(this.corruptionOffsetChanceLabel_TextChanged);
            // 
            // corruptionOffsetFilterButton
            // 
            this.corruptionOffsetFilterButton.Location = new System.Drawing.Point(6, 35);
            this.corruptionOffsetFilterButton.Name = "corruptionOffsetFilterButton";
            this.corruptionOffsetFilterButton.Size = new System.Drawing.Size(249, 25);
            this.corruptionOffsetFilterButton.TabIndex = 1;
            this.corruptionOffsetFilterButton.Text = "Filter Options...";
            this.corruptionOffsetFilterButton.UseVisualStyleBackColor = true;
            this.corruptionOffsetFilterButton.Click += new System.EventHandler(this.CorruptionOffsetFilterButton_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(467, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Probability of Corruption:";
            // 
            // corruptionOffsetTrackBar
            // 
            this.corruptionOffsetTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.corruptionOffsetTrackBar.AutoSize = false;
            this.corruptionOffsetTrackBar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.corruptionOffsetTrackBar.Location = new System.Drawing.Point(386, 32);
            this.corruptionOffsetTrackBar.Maximum = 100;
            this.corruptionOffsetTrackBar.Name = "corruptionOffsetTrackBar";
            this.corruptionOffsetTrackBar.Size = new System.Drawing.Size(276, 30);
            this.corruptionOffsetTrackBar.TabIndex = 3;
            this.corruptionOffsetTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.toolTip1.SetToolTip(this.corruptionOffsetTrackBar, "Affects the chance that parameters will be offset by a random value.");
            this.corruptionOffsetTrackBar.Value = 100;
            this.corruptionOffsetTrackBar.Scroll += new System.EventHandler(this.CorruptionOffsetTrackBar_Scroll);
            // 
            // corruptionOffsetCheckBox
            // 
            this.corruptionOffsetCheckBox.AutoSize = true;
            this.corruptionOffsetCheckBox.Checked = true;
            this.corruptionOffsetCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.corruptionOffsetCheckBox.Location = new System.Drawing.Point(6, 19);
            this.corruptionOffsetCheckBox.Name = "corruptionOffsetCheckBox";
            this.corruptionOffsetCheckBox.Size = new System.Drawing.Size(195, 17);
            this.corruptionOffsetCheckBox.TabIndex = 0;
            this.corruptionOffsetCheckBox.Text = "Offset Numerical Values in Materials";
            this.toolTip1.SetToolTip(this.corruptionOffsetCheckBox, "When enabled, corruption will change the values of numbers by a specific offset.");
            this.corruptionOffsetCheckBox.UseVisualStyleBackColor = true;
            this.corruptionOffsetCheckBox.CheckedChanged += new System.EventHandler(this.CorruptionOffsetCheckBox_CheckedChanged);
            // 
            // corruptionSwapSettingsGroupBox
            // 
            this.corruptionSwapSettingsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.corruptionSwapSettingsGroupBox.Controls.Add(this.materialCorruptionSwapSeedNumeric);
            this.corruptionSwapSettingsGroupBox.Controls.Add(this.label12);
            this.corruptionSwapSettingsGroupBox.Controls.Add(this.corruptionSwapChanceLabel);
            this.corruptionSwapSettingsGroupBox.Controls.Add(this.corruptionSwapFilterButton);
            this.corruptionSwapSettingsGroupBox.Controls.Add(this.label1);
            this.corruptionSwapSettingsGroupBox.Controls.Add(this.corruptionSwapTrackBar);
            this.corruptionSwapSettingsGroupBox.Controls.Add(this.corruptionSwapEnableCheckBox);
            this.corruptionSwapSettingsGroupBox.Location = new System.Drawing.Point(6, 19);
            this.corruptionSwapSettingsGroupBox.Name = "corruptionSwapSettingsGroupBox";
            this.corruptionSwapSettingsGroupBox.Size = new System.Drawing.Size(705, 100);
            this.corruptionSwapSettingsGroupBox.TabIndex = 0;
            this.corruptionSwapSettingsGroupBox.TabStop = false;
            this.corruptionSwapSettingsGroupBox.Text = "Swap Parameters";
            // 
            // materialCorruptionSwapSeedNumeric
            // 
            this.materialCorruptionSwapSeedNumeric.Location = new System.Drawing.Point(542, 74);
            this.materialCorruptionSwapSeedNumeric.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.materialCorruptionSwapSeedNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.materialCorruptionSwapSeedNumeric.Name = "materialCorruptionSwapSeedNumeric";
            this.materialCorruptionSwapSeedNumeric.Size = new System.Drawing.Size(120, 20);
            this.materialCorruptionSwapSeedNumeric.TabIndex = 12;
            this.materialCorruptionSwapSeedNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.materialCorruptionSwapSeedNumeric.ValueChanged += new System.EventHandler(this.materialCorruptionSwapSeedNumeric_ValueChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(387, 76);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(149, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "Probability of Corruption Seed:";
            // 
            // corruptionSwapChanceLabel
            // 
            this.corruptionSwapChanceLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.corruptionSwapChanceLabel.AutoSize = true;
            this.corruptionSwapChanceLabel.Location = new System.Drawing.Point(668, 35);
            this.corruptionSwapChanceLabel.Name = "corruptionSwapChanceLabel";
            this.corruptionSwapChanceLabel.Size = new System.Drawing.Size(33, 13);
            this.corruptionSwapChanceLabel.TabIndex = 10;
            this.corruptionSwapChanceLabel.Text = "100%";
            this.corruptionSwapChanceLabel.TextChanged += new System.EventHandler(this.CorruptionSwapChanceLabel_TextChanged);
            // 
            // corruptionSwapFilterButton
            // 
            this.corruptionSwapFilterButton.Location = new System.Drawing.Point(6, 35);
            this.corruptionSwapFilterButton.Name = "corruptionSwapFilterButton";
            this.corruptionSwapFilterButton.Size = new System.Drawing.Size(249, 25);
            this.corruptionSwapFilterButton.TabIndex = 1;
            this.corruptionSwapFilterButton.Text = "Filter Options...";
            this.corruptionSwapFilterButton.UseVisualStyleBackColor = true;
            this.corruptionSwapFilterButton.Click += new System.EventHandler(this.CorruptionSwapFilterButton_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(465, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Probability of Corruption:";
            // 
            // corruptionSwapTrackBar
            // 
            this.corruptionSwapTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.corruptionSwapTrackBar.AutoSize = false;
            this.corruptionSwapTrackBar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.corruptionSwapTrackBar.Location = new System.Drawing.Point(386, 32);
            this.corruptionSwapTrackBar.Maximum = 100;
            this.corruptionSwapTrackBar.Name = "corruptionSwapTrackBar";
            this.corruptionSwapTrackBar.Size = new System.Drawing.Size(276, 30);
            this.corruptionSwapTrackBar.TabIndex = 2;
            this.corruptionSwapTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.toolTip1.SetToolTip(this.corruptionSwapTrackBar, "Affects the chance that parameters will be swapped.");
            this.corruptionSwapTrackBar.Value = 100;
            this.corruptionSwapTrackBar.Scroll += new System.EventHandler(this.CorruptionSwapTrackBar_Scroll);
            // 
            // corruptionSwapEnableCheckBox
            // 
            this.corruptionSwapEnableCheckBox.AutoSize = true;
            this.corruptionSwapEnableCheckBox.Checked = true;
            this.corruptionSwapEnableCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.corruptionSwapEnableCheckBox.Location = new System.Drawing.Point(6, 19);
            this.corruptionSwapEnableCheckBox.Name = "corruptionSwapEnableCheckBox";
            this.corruptionSwapEnableCheckBox.Size = new System.Drawing.Size(249, 17);
            this.corruptionSwapEnableCheckBox.TabIndex = 0;
            this.corruptionSwapEnableCheckBox.Text = "Swap Specific Parameters With Other Materials";
            this.toolTip1.SetToolTip(this.corruptionSwapEnableCheckBox, "When enabled, corruption will swap material parameters with others.");
            this.corruptionSwapEnableCheckBox.UseVisualStyleBackColor = true;
            this.corruptionSwapEnableCheckBox.CheckedChanged += new System.EventHandler(this.CorruptionSwapEnableCheckBox_CheckedChanged);
            // 
            // materialCorruptionEnableCheckBox
            // 
            this.materialCorruptionEnableCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.materialCorruptionEnableCheckBox.AutoSize = true;
            this.materialCorruptionEnableCheckBox.Location = new System.Drawing.Point(311, 6);
            this.materialCorruptionEnableCheckBox.Name = "materialCorruptionEnableCheckBox";
            this.materialCorruptionEnableCheckBox.Size = new System.Drawing.Size(110, 17);
            this.materialCorruptionEnableCheckBox.TabIndex = 0;
            this.materialCorruptionEnableCheckBox.Text = "Enable Corruption";
            this.materialCorruptionEnableCheckBox.UseVisualStyleBackColor = true;
            this.materialCorruptionEnableCheckBox.CheckedChanged += new System.EventHandler(this.MaterialCorruptionEnableCheckBox_CheckedChanged);
            this.materialCorruptionEnableCheckBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.materialCorruptionEnableCheckBox_KeyDown);
            this.materialCorruptionEnableCheckBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MaterialCorruptionEnableCheckBox_MouseUp);
            // 
            // tabTextures
            // 
            this.tabTextures.Controls.Add(this.textureTabControls);
            this.tabTextures.Location = new System.Drawing.Point(4, 22);
            this.tabTextures.Name = "tabTextures";
            this.tabTextures.Padding = new System.Windows.Forms.Padding(3);
            this.tabTextures.Size = new System.Drawing.Size(744, 636);
            this.tabTextures.TabIndex = 7;
            this.tabTextures.Text = "Textures";
            this.tabTextures.UseVisualStyleBackColor = true;
            // 
            // textureTabControls
            // 
            this.textureTabControls.Controls.Add(this.tabTextureModification);
            this.textureTabControls.Controls.Add(this.tabTextureCorruption);
            this.textureTabControls.Controls.Add(this.tabTextureAddition);
            this.textureTabControls.Location = new System.Drawing.Point(0, 0);
            this.textureTabControls.Name = "textureTabControls";
            this.textureTabControls.SelectedIndex = 0;
            this.textureTabControls.Size = new System.Drawing.Size(742, 615);
            this.textureTabControls.TabIndex = 1;
            // 
            // tabTextureModification
            // 
            this.tabTextureModification.Controls.Add(this.textureSettingsResizeLabel);
            this.tabTextureModification.Location = new System.Drawing.Point(4, 22);
            this.tabTextureModification.Name = "tabTextureModification";
            this.tabTextureModification.Padding = new System.Windows.Forms.Padding(3);
            this.tabTextureModification.Size = new System.Drawing.Size(734, 589);
            this.tabTextureModification.TabIndex = 0;
            this.tabTextureModification.Text = "Modification";
            this.tabTextureModification.UseVisualStyleBackColor = true;
            // 
            // textureSettingsResizeLabel
            // 
            this.textureSettingsResizeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textureSettingsResizeLabel.Controls.Add(this.textureParametersLabel);
            this.textureSettingsResizeLabel.Controls.Add(this.checkedListBox2);
            this.textureSettingsResizeLabel.Controls.Add(this.button1);
            this.textureSettingsResizeLabel.Location = new System.Drawing.Point(6, 0);
            this.textureSettingsResizeLabel.Name = "textureSettingsResizeLabel";
            this.textureSettingsResizeLabel.Size = new System.Drawing.Size(163, 589);
            this.textureSettingsResizeLabel.TabIndex = 10;
            // 
            // textureParametersLabel
            // 
            this.textureParametersLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textureParametersLabel.AutoSize = true;
            this.textureParametersLabel.Location = new System.Drawing.Point(49, 3);
            this.textureParametersLabel.Name = "textureParametersLabel";
            this.textureParametersLabel.Size = new System.Drawing.Size(60, 13);
            this.textureParametersLabel.TabIndex = 1;
            this.textureParametersLabel.Text = "Parameters";
            this.textureParametersLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkedListBox2
            // 
            this.checkedListBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedListBox2.CheckOnClick = true;
            this.checkedListBox2.FormattingEnabled = true;
            this.checkedListBox2.HorizontalScrollbar = true;
            this.checkedListBox2.IntegralHeight = false;
            this.checkedListBox2.Location = new System.Drawing.Point(3, 19);
            this.checkedListBox2.Name = "checkedListBox2";
            this.checkedListBox2.Size = new System.Drawing.Size(157, 539);
            this.checkedListBox2.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(3, 563);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(157, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Manage Parameters";
            this.toolTip1.SetToolTip(this.button1, "Add, remove, and edit localisation parameters.");
            this.button1.UseVisualStyleBackColor = true;
            // 
            // tabTextureCorruption
            // 
            this.tabTextureCorruption.Location = new System.Drawing.Point(4, 22);
            this.tabTextureCorruption.Name = "tabTextureCorruption";
            this.tabTextureCorruption.Padding = new System.Windows.Forms.Padding(3);
            this.tabTextureCorruption.Size = new System.Drawing.Size(734, 589);
            this.tabTextureCorruption.TabIndex = 1;
            this.tabTextureCorruption.Text = "Corruption";
            this.tabTextureCorruption.UseVisualStyleBackColor = true;
            // 
            // tabTextureAddition
            // 
            this.tabTextureAddition.Location = new System.Drawing.Point(4, 22);
            this.tabTextureAddition.Name = "tabTextureAddition";
            this.tabTextureAddition.Size = new System.Drawing.Size(734, 589);
            this.tabTextureAddition.TabIndex = 2;
            this.tabTextureAddition.Text = "Add Textures";
            this.tabTextureAddition.ToolTipText = "Add textures to the custom mod. This can be used if you want to replace materials" +
    " with your own textures without overwriting existing textures.";
            this.tabTextureAddition.UseVisualStyleBackColor = true;
            // 
            // tabModels
            // 
            this.tabModels.Location = new System.Drawing.Point(4, 22);
            this.tabModels.Name = "tabModels";
            this.tabModels.Size = new System.Drawing.Size(744, 636);
            this.tabModels.TabIndex = 3;
            this.tabModels.Text = "Models";
            this.tabModels.UseVisualStyleBackColor = true;
            // 
            // tabParticles
            // 
            this.tabParticles.Location = new System.Drawing.Point(4, 22);
            this.tabParticles.Name = "tabParticles";
            this.tabParticles.Size = new System.Drawing.Size(744, 636);
            this.tabParticles.TabIndex = 4;
            this.tabParticles.Text = "Particles";
            this.tabParticles.UseVisualStyleBackColor = true;
            // 
            // tabSounds
            // 
            this.tabSounds.Controls.Add(this.soundsTabControls);
            this.tabSounds.Location = new System.Drawing.Point(4, 22);
            this.tabSounds.Name = "tabSounds";
            this.tabSounds.Padding = new System.Windows.Forms.Padding(3);
            this.tabSounds.Size = new System.Drawing.Size(744, 636);
            this.tabSounds.TabIndex = 1;
            this.tabSounds.Text = "Sounds";
            this.tabSounds.UseVisualStyleBackColor = true;
            // 
            // soundsTabControls
            // 
            this.soundsTabControls.Controls.Add(this.tabSoundModification);
            this.soundsTabControls.Controls.Add(this.tabSoundCorruption);
            this.soundsTabControls.Controls.Add(this.tabSoundAddition);
            this.soundsTabControls.Location = new System.Drawing.Point(0, 0);
            this.soundsTabControls.Name = "soundsTabControls";
            this.soundsTabControls.SelectedIndex = 0;
            this.soundsTabControls.Size = new System.Drawing.Size(742, 615);
            this.soundsTabControls.TabIndex = 2;
            // 
            // tabSoundModification
            // 
            this.tabSoundModification.Controls.Add(this.soundSettingsResizePanel);
            this.tabSoundModification.Location = new System.Drawing.Point(4, 22);
            this.tabSoundModification.Name = "tabSoundModification";
            this.tabSoundModification.Padding = new System.Windows.Forms.Padding(3);
            this.tabSoundModification.Size = new System.Drawing.Size(734, 589);
            this.tabSoundModification.TabIndex = 0;
            this.tabSoundModification.Text = "Modification";
            this.tabSoundModification.UseVisualStyleBackColor = true;
            // 
            // soundSettingsResizePanel
            // 
            this.soundSettingsResizePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.soundSettingsResizePanel.Controls.Add(this.label17);
            this.soundSettingsResizePanel.Controls.Add(this.soundParameterList);
            this.soundSettingsResizePanel.Controls.Add(this.manageSoundParametersButton);
            this.soundSettingsResizePanel.Location = new System.Drawing.Point(6, 0);
            this.soundSettingsResizePanel.Name = "soundSettingsResizePanel";
            this.soundSettingsResizePanel.Size = new System.Drawing.Size(163, 589);
            this.soundSettingsResizePanel.TabIndex = 10;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(49, 3);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(60, 13);
            this.label17.TabIndex = 1;
            this.label17.Text = "Parameters";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // soundParameterList
            // 
            this.soundParameterList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.soundParameterList.CheckOnClick = true;
            this.soundParameterList.FormattingEnabled = true;
            this.soundParameterList.HorizontalScrollbar = true;
            this.soundParameterList.IntegralHeight = false;
            this.soundParameterList.Location = new System.Drawing.Point(3, 19);
            this.soundParameterList.Name = "soundParameterList";
            this.soundParameterList.Size = new System.Drawing.Size(157, 538);
            this.soundParameterList.TabIndex = 0;
            // 
            // manageSoundParametersButton
            // 
            this.manageSoundParametersButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.manageSoundParametersButton.Location = new System.Drawing.Point(3, 563);
            this.manageSoundParametersButton.Name = "manageSoundParametersButton";
            this.manageSoundParametersButton.Size = new System.Drawing.Size(157, 23);
            this.manageSoundParametersButton.TabIndex = 5;
            this.manageSoundParametersButton.Text = "Manage Parameters";
            this.toolTip1.SetToolTip(this.manageSoundParametersButton, "Add, remove, and edit localisation parameters.");
            this.manageSoundParametersButton.UseVisualStyleBackColor = true;
            this.manageSoundParametersButton.Click += new System.EventHandler(this.manageSoundParametersButton_Click);
            // 
            // tabSoundCorruption
            // 
            this.tabSoundCorruption.Location = new System.Drawing.Point(4, 22);
            this.tabSoundCorruption.Name = "tabSoundCorruption";
            this.tabSoundCorruption.Padding = new System.Windows.Forms.Padding(3);
            this.tabSoundCorruption.Size = new System.Drawing.Size(734, 589);
            this.tabSoundCorruption.TabIndex = 1;
            this.tabSoundCorruption.Text = "Corruption";
            this.tabSoundCorruption.UseVisualStyleBackColor = true;
            // 
            // tabSoundAddition
            // 
            this.tabSoundAddition.Controls.Add(this.soundFileRemoveButton);
            this.tabSoundAddition.Controls.Add(this.soundFileAddButton);
            this.tabSoundAddition.Controls.Add(this.soundFileListingDataGridView);
            this.tabSoundAddition.Location = new System.Drawing.Point(4, 22);
            this.tabSoundAddition.Name = "tabSoundAddition";
            this.tabSoundAddition.Size = new System.Drawing.Size(734, 589);
            this.tabSoundAddition.TabIndex = 2;
            this.tabSoundAddition.Text = "Add Sounds";
            this.tabSoundAddition.ToolTipText = "Add textures to the custom mod. This can be used if you want to replace materials" +
    " with your own textures without overwriting existing textures.";
            this.tabSoundAddition.UseVisualStyleBackColor = true;
            // 
            // soundFileRemoveButton
            // 
            this.soundFileRemoveButton.Location = new System.Drawing.Point(368, 562);
            this.soundFileRemoveButton.Name = "soundFileRemoveButton";
            this.soundFileRemoveButton.Size = new System.Drawing.Size(363, 23);
            this.soundFileRemoveButton.TabIndex = 39;
            this.soundFileRemoveButton.Text = "Remove File";
            this.soundFileRemoveButton.UseVisualStyleBackColor = true;
            // 
            // soundFileAddButton
            // 
            this.soundFileAddButton.Location = new System.Drawing.Point(4, 562);
            this.soundFileAddButton.Name = "soundFileAddButton";
            this.soundFileAddButton.Size = new System.Drawing.Size(358, 23);
            this.soundFileAddButton.TabIndex = 38;
            this.soundFileAddButton.Text = "Add File";
            this.soundFileAddButton.UseVisualStyleBackColor = true;
            this.soundFileAddButton.Click += new System.EventHandler(this.soundFileAddButton_Click);
            // 
            // soundFileListingDataGridView
            // 
            this.soundFileListingDataGridView.AllowDrop = true;
            this.soundFileListingDataGridView.AllowUserToAddRows = false;
            this.soundFileListingDataGridView.AllowUserToDeleteRows = false;
            this.soundFileListingDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.soundFileListingDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.soundFileListingDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Key,
            this.FullLocation,
            this.PreviewButton});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.soundFileListingDataGridView.DefaultCellStyle = dataGridViewCellStyle9;
            this.soundFileListingDataGridView.Location = new System.Drawing.Point(2, 3);
            this.soundFileListingDataGridView.Name = "soundFileListingDataGridView";
            this.soundFileListingDataGridView.ReadOnly = true;
            this.soundFileListingDataGridView.RowHeadersVisible = false;
            this.soundFileListingDataGridView.Size = new System.Drawing.Size(727, 553);
            this.soundFileListingDataGridView.TabIndex = 37;
            this.soundFileListingDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.soundFileListingDataGridView_CellContentClick);
            this.soundFileListingDataGridView.DragDrop += new System.Windows.Forms.DragEventHandler(this.soundFileListingDataGridView_DragDrop);
            this.soundFileListingDataGridView.DragEnter += new System.Windows.Forms.DragEventHandler(this.soundFileListingDataGridView_DragEnter);
            // 
            // Key
            // 
            this.Key.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Key.HeaderText = "Sound Filename";
            this.Key.Name = "Key";
            this.Key.ReadOnly = true;
            // 
            // FullLocation
            // 
            this.FullLocation.HeaderText = "File Location";
            this.FullLocation.Name = "FullLocation";
            this.FullLocation.ReadOnly = true;
            this.FullLocation.Width = 400;
            // 
            // PreviewButton
            // 
            this.PreviewButton.HeaderText = "Preview";
            this.PreviewButton.Name = "PreviewButton";
            this.PreviewButton.ReadOnly = true;
            this.PreviewButton.Text = "Play Sound";
            this.PreviewButton.Width = 170;
            // 
            // tabScripts
            // 
            this.tabScripts.Location = new System.Drawing.Point(4, 22);
            this.tabScripts.Name = "tabScripts";
            this.tabScripts.Size = new System.Drawing.Size(744, 636);
            this.tabScripts.TabIndex = 5;
            this.tabScripts.Text = "Scripts";
            this.tabScripts.UseVisualStyleBackColor = true;
            // 
            // tabLocalization
            // 
            this.tabLocalization.Controls.Add(this.localisationTabControls);
            this.tabLocalization.Location = new System.Drawing.Point(4, 22);
            this.tabLocalization.Name = "tabLocalization";
            this.tabLocalization.Size = new System.Drawing.Size(744, 636);
            this.tabLocalization.TabIndex = 6;
            this.tabLocalization.Text = "Localization";
            this.tabLocalization.UseVisualStyleBackColor = true;
            // 
            // localisationTabControls
            // 
            this.localisationTabControls.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.localisationTabControls.Controls.Add(this.tabLocalisationModification);
            this.localisationTabControls.Controls.Add(this.tabLocalisationCorruption);
            this.localisationTabControls.Location = new System.Drawing.Point(0, 0);
            this.localisationTabControls.Name = "localisationTabControls";
            this.localisationTabControls.SelectedIndex = 0;
            this.localisationTabControls.Size = new System.Drawing.Size(742, 615);
            this.localisationTabControls.TabIndex = 0;
            // 
            // tabLocalisationModification
            // 
            this.tabLocalisationModification.Controls.Add(this.localisationParameterSettingsGroupBox);
            this.tabLocalisationModification.Controls.Add(this.localisationSettingsResizePanel);
            this.tabLocalisationModification.Location = new System.Drawing.Point(4, 22);
            this.tabLocalisationModification.Name = "tabLocalisationModification";
            this.tabLocalisationModification.Padding = new System.Windows.Forms.Padding(3);
            this.tabLocalisationModification.Size = new System.Drawing.Size(734, 589);
            this.tabLocalisationModification.TabIndex = 0;
            this.tabLocalisationModification.Text = "Modification";
            this.tabLocalisationModification.UseVisualStyleBackColor = true;
            // 
            // localisationParameterSettingsGroupBox
            // 
            this.localisationParameterSettingsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.localisationParameterSettingsGroupBox.Controls.Add(this.localisationSeedSettingsGroupBox);
            this.localisationParameterSettingsGroupBox.Controls.Add(this.groupBox1);
            this.localisationParameterSettingsGroupBox.Controls.Add(this.groupBox2);
            this.localisationParameterSettingsGroupBox.Location = new System.Drawing.Point(175, 6);
            this.localisationParameterSettingsGroupBox.Name = "localisationParameterSettingsGroupBox";
            this.localisationParameterSettingsGroupBox.Size = new System.Drawing.Size(550, 580);
            this.localisationParameterSettingsGroupBox.TabIndex = 1;
            this.localisationParameterSettingsGroupBox.TabStop = false;
            this.localisationParameterSettingsGroupBox.Text = "Parameter Settings";
            this.localisationParameterSettingsGroupBox.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.localisationLetterCountMaxLabel);
            this.groupBox1.Controls.Add(this.localisationLetterCountMaxNumeric);
            this.groupBox1.Controls.Add(this.localisationLetterCountMinLabel);
            this.groupBox1.Controls.Add(this.localisationLetterCountMinNumeric);
            this.groupBox1.Controls.Add(this.localisationLetterCountCheckBox);
            this.groupBox1.Location = new System.Drawing.Point(6, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(207, 114);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Character Range Limit Settings";
            // 
            // localisationLetterCountMaxLabel
            // 
            this.localisationLetterCountMaxLabel.AutoSize = true;
            this.localisationLetterCountMaxLabel.Location = new System.Drawing.Point(3, 78);
            this.localisationLetterCountMaxLabel.Name = "localisationLetterCountMaxLabel";
            this.localisationLetterCountMaxLabel.Size = new System.Drawing.Size(124, 13);
            this.localisationLetterCountMaxLabel.TabIndex = 11;
            this.localisationLetterCountMaxLabel.Text = "Maximum Character Limit";
            // 
            // localisationLetterCountMaxNumeric
            // 
            this.localisationLetterCountMaxNumeric.Location = new System.Drawing.Point(141, 76);
            this.localisationLetterCountMaxNumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.localisationLetterCountMaxNumeric.Name = "localisationLetterCountMaxNumeric";
            this.localisationLetterCountMaxNumeric.Size = new System.Drawing.Size(58, 20);
            this.localisationLetterCountMaxNumeric.TabIndex = 2;
            this.localisationLetterCountMaxNumeric.ValueChanged += new System.EventHandler(this.LocalisationLetterCountMaxNumeric_ValueChanged);
            // 
            // localisationLetterCountMinLabel
            // 
            this.localisationLetterCountMinLabel.AutoSize = true;
            this.localisationLetterCountMinLabel.Location = new System.Drawing.Point(3, 55);
            this.localisationLetterCountMinLabel.Name = "localisationLetterCountMinLabel";
            this.localisationLetterCountMinLabel.Size = new System.Drawing.Size(121, 13);
            this.localisationLetterCountMinLabel.TabIndex = 9;
            this.localisationLetterCountMinLabel.Text = "Minimum Character Limit";
            // 
            // localisationLetterCountMinNumeric
            // 
            this.localisationLetterCountMinNumeric.Location = new System.Drawing.Point(141, 53);
            this.localisationLetterCountMinNumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.localisationLetterCountMinNumeric.Name = "localisationLetterCountMinNumeric";
            this.localisationLetterCountMinNumeric.Size = new System.Drawing.Size(58, 20);
            this.localisationLetterCountMinNumeric.TabIndex = 1;
            this.localisationLetterCountMinNumeric.ValueChanged += new System.EventHandler(this.LocalisationLetterCountMinNumeric_ValueChanged);
            // 
            // localisationLetterCountCheckBox
            // 
            this.localisationLetterCountCheckBox.AutoSize = true;
            this.localisationLetterCountCheckBox.Location = new System.Drawing.Point(6, 16);
            this.localisationLetterCountCheckBox.Name = "localisationLetterCountCheckBox";
            this.localisationLetterCountCheckBox.Size = new System.Drawing.Size(173, 30);
            this.localisationLetterCountCheckBox.TabIndex = 0;
            this.localisationLetterCountCheckBox.Text = "Limit Affected Entries Based on\r\nCharacter Count";
            this.toolTip1.SetToolTip(this.localisationLetterCountCheckBox, "If checked, localisation entries will only be changed if the amount of characters" +
        " in an entry is within the specified range.");
            this.localisationLetterCountCheckBox.UseVisualStyleBackColor = true;
            this.localisationLetterCountCheckBox.CheckedChanged += new System.EventHandler(this.LocalisationLetterCountCheckBox_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.localisationRandomizerIndividualChanceLabel);
            this.groupBox2.Controls.Add(this.localisationRandomizerIndividualChanceTrackBar);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.localisationRandomizerChanceLabel);
            this.groupBox2.Controls.Add(this.localisationRandomizerChanceTrackBar);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Location = new System.Drawing.Point(219, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(321, 114);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Randomizer Settings";
            // 
            // localisationRandomizerIndividualChanceLabel
            // 
            this.localisationRandomizerIndividualChanceLabel.AutoSize = true;
            this.localisationRandomizerIndividualChanceLabel.Location = new System.Drawing.Point(290, 82);
            this.localisationRandomizerIndividualChanceLabel.Name = "localisationRandomizerIndividualChanceLabel";
            this.localisationRandomizerIndividualChanceLabel.Size = new System.Drawing.Size(21, 13);
            this.localisationRandomizerIndividualChanceLabel.TabIndex = 10;
            this.localisationRandomizerIndividualChanceLabel.Text = "0%";
            this.localisationRandomizerIndividualChanceLabel.TextChanged += new System.EventHandler(this.LocalisationRandomizerIndividualChanceLabel_TextChanged);
            // 
            // localisationRandomizerIndividualChanceTrackBar
            // 
            this.localisationRandomizerIndividualChanceTrackBar.AutoSize = false;
            this.localisationRandomizerIndividualChanceTrackBar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.localisationRandomizerIndividualChanceTrackBar.Location = new System.Drawing.Point(9, 78);
            this.localisationRandomizerIndividualChanceTrackBar.Maximum = 100;
            this.localisationRandomizerIndividualChanceTrackBar.Name = "localisationRandomizerIndividualChanceTrackBar";
            this.localisationRandomizerIndividualChanceTrackBar.Size = new System.Drawing.Size(276, 30);
            this.localisationRandomizerIndividualChanceTrackBar.TabIndex = 1;
            this.localisationRandomizerIndividualChanceTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.toolTip1.SetToolTip(this.localisationRandomizerIndividualChanceTrackBar, "Affects the chance that this parameter will appear per individual match.");
            this.localisationRandomizerIndividualChanceTrackBar.Scroll += new System.EventHandler(this.LocalisationRandomizerIndividualChanceTrackBar_Scroll);
            this.localisationRandomizerIndividualChanceTrackBar.MouseCaptureChanged += new System.EventHandler(this.LocalisationRandomizerIndividualChanceTrackBar_MouseCaptureChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(249, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Probability Of Appearance (per Individual Matches):";
            this.toolTip1.SetToolTip(this.label7, resources.GetString("label7.ToolTip"));
            // 
            // localisationRandomizerChanceLabel
            // 
            this.localisationRandomizerChanceLabel.AutoSize = true;
            this.localisationRandomizerChanceLabel.Location = new System.Drawing.Point(290, 36);
            this.localisationRandomizerChanceLabel.Name = "localisationRandomizerChanceLabel";
            this.localisationRandomizerChanceLabel.Size = new System.Drawing.Size(21, 13);
            this.localisationRandomizerChanceLabel.TabIndex = 7;
            this.localisationRandomizerChanceLabel.Text = "0%";
            this.localisationRandomizerChanceLabel.TextChanged += new System.EventHandler(this.LocalisationRandomizerChanceLabel_TextChanged);
            // 
            // localisationRandomizerChanceTrackBar
            // 
            this.localisationRandomizerChanceTrackBar.AutoSize = false;
            this.localisationRandomizerChanceTrackBar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.localisationRandomizerChanceTrackBar.Location = new System.Drawing.Point(9, 32);
            this.localisationRandomizerChanceTrackBar.Maximum = 100;
            this.localisationRandomizerChanceTrackBar.Name = "localisationRandomizerChanceTrackBar";
            this.localisationRandomizerChanceTrackBar.Size = new System.Drawing.Size(276, 30);
            this.localisationRandomizerChanceTrackBar.TabIndex = 0;
            this.localisationRandomizerChanceTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.toolTip1.SetToolTip(this.localisationRandomizerChanceTrackBar, "Affects the chance that this parameter will appear per localisation token.");
            this.localisationRandomizerChanceTrackBar.Scroll += new System.EventHandler(this.LocalisationRandomizerChanceTrackBar_Scroll);
            this.localisationRandomizerChanceTrackBar.MouseCaptureChanged += new System.EventHandler(this.LocalisationRandomizerChanceTrackBar_MouseCaptureChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(25, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(250, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Probability Of Appearance (per Localisation Token):";
            this.toolTip1.SetToolTip(this.label10, "The chance that this parameter will affect a localisation token.\r\nIf this probabi" +
        "lity fails, the token will not be selected at all.\r\n");
            // 
            // localisationSettingsResizePanel
            // 
            this.localisationSettingsResizePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.localisationSettingsResizePanel.Controls.Add(this.localisationParametersLabel);
            this.localisationSettingsResizePanel.Controls.Add(this.localisationParameterList);
            this.localisationSettingsResizePanel.Controls.Add(this.manageLocalisationParametersButton);
            this.localisationSettingsResizePanel.Location = new System.Drawing.Point(6, 0);
            this.localisationSettingsResizePanel.Name = "localisationSettingsResizePanel";
            this.localisationSettingsResizePanel.Size = new System.Drawing.Size(163, 589);
            this.localisationSettingsResizePanel.TabIndex = 0;
            // 
            // localisationParametersLabel
            // 
            this.localisationParametersLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.localisationParametersLabel.AutoSize = true;
            this.localisationParametersLabel.Location = new System.Drawing.Point(49, 3);
            this.localisationParametersLabel.Name = "localisationParametersLabel";
            this.localisationParametersLabel.Size = new System.Drawing.Size(60, 13);
            this.localisationParametersLabel.TabIndex = 1;
            this.localisationParametersLabel.Text = "Parameters";
            this.localisationParametersLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // localisationParameterList
            // 
            this.localisationParameterList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.localisationParameterList.CheckOnClick = true;
            this.localisationParameterList.FormattingEnabled = true;
            this.localisationParameterList.HorizontalScrollbar = true;
            this.localisationParameterList.IntegralHeight = false;
            this.localisationParameterList.Location = new System.Drawing.Point(3, 19);
            this.localisationParameterList.Name = "localisationParameterList";
            this.localisationParameterList.Size = new System.Drawing.Size(157, 539);
            this.localisationParameterList.TabIndex = 0;
            this.localisationParameterList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LocalisationParameterList_MouseClick);
            // 
            // manageLocalisationParametersButton
            // 
            this.manageLocalisationParametersButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.manageLocalisationParametersButton.Location = new System.Drawing.Point(3, 563);
            this.manageLocalisationParametersButton.Name = "manageLocalisationParametersButton";
            this.manageLocalisationParametersButton.Size = new System.Drawing.Size(157, 23);
            this.manageLocalisationParametersButton.TabIndex = 1;
            this.manageLocalisationParametersButton.Text = "Manage Parameters";
            this.toolTip1.SetToolTip(this.manageLocalisationParametersButton, "Add, remove, and edit localisation parameters.");
            this.manageLocalisationParametersButton.UseVisualStyleBackColor = true;
            this.manageLocalisationParametersButton.Click += new System.EventHandler(this.ManageLocalisationParametersButton_Click);
            // 
            // tabLocalisationCorruption
            // 
            this.tabLocalisationCorruption.Controls.Add(this.localisationCorruptionSettingsGroupBox);
            this.tabLocalisationCorruption.Controls.Add(this.localisationCorruptionEnableCheckBox);
            this.tabLocalisationCorruption.Location = new System.Drawing.Point(4, 22);
            this.tabLocalisationCorruption.Name = "tabLocalisationCorruption";
            this.tabLocalisationCorruption.Padding = new System.Windows.Forms.Padding(3);
            this.tabLocalisationCorruption.Size = new System.Drawing.Size(734, 589);
            this.tabLocalisationCorruption.TabIndex = 1;
            this.tabLocalisationCorruption.Text = "Corruption";
            this.tabLocalisationCorruption.UseVisualStyleBackColor = true;
            // 
            // localisationCorruptionSettingsGroupBox
            // 
            this.localisationCorruptionSettingsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.localisationCorruptionSettingsGroupBox.Controls.Add(this.groupBox6);
            this.localisationCorruptionSettingsGroupBox.Controls.Add(this.groupBox5);
            this.localisationCorruptionSettingsGroupBox.Controls.Add(this.groupBox3);
            this.localisationCorruptionSettingsGroupBox.Controls.Add(this.groupBox4);
            this.localisationCorruptionSettingsGroupBox.Enabled = false;
            this.localisationCorruptionSettingsGroupBox.Location = new System.Drawing.Point(8, 26);
            this.localisationCorruptionSettingsGroupBox.Name = "localisationCorruptionSettingsGroupBox";
            this.localisationCorruptionSettingsGroupBox.Size = new System.Drawing.Size(717, 556);
            this.localisationCorruptionSettingsGroupBox.TabIndex = 1;
            this.localisationCorruptionSettingsGroupBox.TabStop = false;
            this.localisationCorruptionSettingsGroupBox.Text = "Corruption Settings";
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.localisationCorruptionScrambleSeedNumeric);
            this.groupBox6.Controls.Add(this.label21);
            this.groupBox6.Controls.Add(this.localisationCorruptionScrambleSettingsButton);
            this.groupBox6.Controls.Add(this.localisationCorruptionScrambleChanceLabel);
            this.groupBox6.Controls.Add(this.localisationCorruptionScrambleFilterButton);
            this.groupBox6.Controls.Add(this.label15);
            this.groupBox6.Controls.Add(this.localisationCorruptionScrambleTrackBar);
            this.groupBox6.Controls.Add(this.localisationCorruptionScrambleEnableCheckBox);
            this.groupBox6.Location = new System.Drawing.Point(12, 374);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(705, 98);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Scramble Text";
            this.groupBox6.Visible = false;
            // 
            // localisationCorruptionScrambleSettingsButton
            // 
            this.localisationCorruptionScrambleSettingsButton.Location = new System.Drawing.Point(6, 68);
            this.localisationCorruptionScrambleSettingsButton.Name = "localisationCorruptionScrambleSettingsButton";
            this.localisationCorruptionScrambleSettingsButton.Size = new System.Drawing.Size(249, 25);
            this.localisationCorruptionScrambleSettingsButton.TabIndex = 2;
            this.localisationCorruptionScrambleSettingsButton.Text = "Scramble Settings...";
            this.localisationCorruptionScrambleSettingsButton.UseVisualStyleBackColor = true;
            // 
            // localisationCorruptionScrambleChanceLabel
            // 
            this.localisationCorruptionScrambleChanceLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.localisationCorruptionScrambleChanceLabel.AutoSize = true;
            this.localisationCorruptionScrambleChanceLabel.Location = new System.Drawing.Point(668, 35);
            this.localisationCorruptionScrambleChanceLabel.Name = "localisationCorruptionScrambleChanceLabel";
            this.localisationCorruptionScrambleChanceLabel.Size = new System.Drawing.Size(33, 13);
            this.localisationCorruptionScrambleChanceLabel.TabIndex = 10;
            this.localisationCorruptionScrambleChanceLabel.Text = "100%";
            this.localisationCorruptionScrambleChanceLabel.TextChanged += new System.EventHandler(this.localisationCorruptionScrambleChanceLabel_TextChanged);
            // 
            // localisationCorruptionScrambleFilterButton
            // 
            this.localisationCorruptionScrambleFilterButton.Enabled = false;
            this.localisationCorruptionScrambleFilterButton.Location = new System.Drawing.Point(6, 37);
            this.localisationCorruptionScrambleFilterButton.Name = "localisationCorruptionScrambleFilterButton";
            this.localisationCorruptionScrambleFilterButton.Size = new System.Drawing.Size(249, 25);
            this.localisationCorruptionScrambleFilterButton.TabIndex = 1;
            this.localisationCorruptionScrambleFilterButton.Text = "Filter Options...";
            this.localisationCorruptionScrambleFilterButton.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(465, 16);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(121, 13);
            this.label15.TabIndex = 8;
            this.label15.Text = "Probability of Corruption:";
            // 
            // localisationCorruptionScrambleTrackBar
            // 
            this.localisationCorruptionScrambleTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.localisationCorruptionScrambleTrackBar.AutoSize = false;
            this.localisationCorruptionScrambleTrackBar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.localisationCorruptionScrambleTrackBar.Location = new System.Drawing.Point(386, 32);
            this.localisationCorruptionScrambleTrackBar.Maximum = 100;
            this.localisationCorruptionScrambleTrackBar.Name = "localisationCorruptionScrambleTrackBar";
            this.localisationCorruptionScrambleTrackBar.Size = new System.Drawing.Size(276, 30);
            this.localisationCorruptionScrambleTrackBar.TabIndex = 3;
            this.localisationCorruptionScrambleTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.toolTip1.SetToolTip(this.localisationCorruptionScrambleTrackBar, "Affects the chance that text will be scrambled.\r\n");
            this.localisationCorruptionScrambleTrackBar.Value = 100;
            // 
            // localisationCorruptionScrambleEnableCheckBox
            // 
            this.localisationCorruptionScrambleEnableCheckBox.AutoSize = true;
            this.localisationCorruptionScrambleEnableCheckBox.Checked = true;
            this.localisationCorruptionScrambleEnableCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.localisationCorruptionScrambleEnableCheckBox.Location = new System.Drawing.Point(6, 19);
            this.localisationCorruptionScrambleEnableCheckBox.Name = "localisationCorruptionScrambleEnableCheckBox";
            this.localisationCorruptionScrambleEnableCheckBox.Size = new System.Drawing.Size(180, 17);
            this.localisationCorruptionScrambleEnableCheckBox.TabIndex = 0;
            this.localisationCorruptionScrambleEnableCheckBox.Text = "Scramble Localisation Entry Text";
            this.toolTip1.SetToolTip(this.localisationCorruptionScrambleEnableCheckBox, "When enabled, corruption will swap material parameters with others.");
            this.localisationCorruptionScrambleEnableCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.localisationCorruptionOffsetSeedNumeric);
            this.groupBox5.Controls.Add(this.label23);
            this.groupBox5.Controls.Add(this.localisationCorruptionIndividualOffsetLabel);
            this.groupBox5.Controls.Add(this.label16);
            this.groupBox5.Controls.Add(this.localisationCorruptionIndividualOffsetTrackBar);
            this.groupBox5.Controls.Add(this.localisationCorruptionOffsetSettingsButton);
            this.groupBox5.Controls.Add(this.localisationCorruptionOffsetChanceLabel);
            this.groupBox5.Controls.Add(this.localisationCorruptionOffsetFilterButton);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.localisationCorruptionOffsetTrackBar);
            this.groupBox5.Controls.Add(this.localisationCorruptionOffsetEnableCheckBox);
            this.groupBox5.Location = new System.Drawing.Point(6, 232);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(705, 136);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "ASCII Offset";
            // 
            // localisationCorruptionIndividualOffsetLabel
            // 
            this.localisationCorruptionIndividualOffsetLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.localisationCorruptionIndividualOffsetLabel.AutoSize = true;
            this.localisationCorruptionIndividualOffsetLabel.Location = new System.Drawing.Point(668, 80);
            this.localisationCorruptionIndividualOffsetLabel.Name = "localisationCorruptionIndividualOffsetLabel";
            this.localisationCorruptionIndividualOffsetLabel.Size = new System.Drawing.Size(33, 13);
            this.localisationCorruptionIndividualOffsetLabel.TabIndex = 13;
            this.localisationCorruptionIndividualOffsetLabel.Text = "100%";
            this.localisationCorruptionIndividualOffsetLabel.Visible = false;
            this.localisationCorruptionIndividualOffsetLabel.TextChanged += new System.EventHandler(this.localisationCorruptionIndividualOffsetLabel_TextChanged);
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(409, 61);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(237, 13);
            this.label16.TabIndex = 12;
            this.label16.Text = "Probability of Corruption (per Individual Matches):";
            this.label16.Visible = false;
            // 
            // localisationCorruptionIndividualOffsetTrackBar
            // 
            this.localisationCorruptionIndividualOffsetTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.localisationCorruptionIndividualOffsetTrackBar.AutoSize = false;
            this.localisationCorruptionIndividualOffsetTrackBar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.localisationCorruptionIndividualOffsetTrackBar.Location = new System.Drawing.Point(386, 77);
            this.localisationCorruptionIndividualOffsetTrackBar.Maximum = 100;
            this.localisationCorruptionIndividualOffsetTrackBar.Name = "localisationCorruptionIndividualOffsetTrackBar";
            this.localisationCorruptionIndividualOffsetTrackBar.Size = new System.Drawing.Size(276, 30);
            this.localisationCorruptionIndividualOffsetTrackBar.TabIndex = 11;
            this.localisationCorruptionIndividualOffsetTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.toolTip1.SetToolTip(this.localisationCorruptionIndividualOffsetTrackBar, "Affects the chance that a filter match can be selected for the ASCII Offset corru" +
        "ption.\r\n");
            this.localisationCorruptionIndividualOffsetTrackBar.Value = 100;
            this.localisationCorruptionIndividualOffsetTrackBar.Visible = false;
            // 
            // localisationCorruptionOffsetSettingsButton
            // 
            this.localisationCorruptionOffsetSettingsButton.Location = new System.Drawing.Point(6, 67);
            this.localisationCorruptionOffsetSettingsButton.Name = "localisationCorruptionOffsetSettingsButton";
            this.localisationCorruptionOffsetSettingsButton.Size = new System.Drawing.Size(249, 25);
            this.localisationCorruptionOffsetSettingsButton.TabIndex = 2;
            this.localisationCorruptionOffsetSettingsButton.Text = "Offset Settings...";
            this.localisationCorruptionOffsetSettingsButton.UseVisualStyleBackColor = true;
            this.localisationCorruptionOffsetSettingsButton.Click += new System.EventHandler(this.localisationCorruptionOffsetSettingsButton_Click);
            // 
            // localisationCorruptionOffsetChanceLabel
            // 
            this.localisationCorruptionOffsetChanceLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.localisationCorruptionOffsetChanceLabel.AutoSize = true;
            this.localisationCorruptionOffsetChanceLabel.Location = new System.Drawing.Point(668, 37);
            this.localisationCorruptionOffsetChanceLabel.Name = "localisationCorruptionOffsetChanceLabel";
            this.localisationCorruptionOffsetChanceLabel.Size = new System.Drawing.Size(33, 13);
            this.localisationCorruptionOffsetChanceLabel.TabIndex = 10;
            this.localisationCorruptionOffsetChanceLabel.Text = "100%";
            this.localisationCorruptionOffsetChanceLabel.TextChanged += new System.EventHandler(this.localisationCorruptionOffsetChanceLabel_TextChanged);
            // 
            // localisationCorruptionOffsetFilterButton
            // 
            this.localisationCorruptionOffsetFilterButton.Enabled = false;
            this.localisationCorruptionOffsetFilterButton.Location = new System.Drawing.Point(6, 37);
            this.localisationCorruptionOffsetFilterButton.Name = "localisationCorruptionOffsetFilterButton";
            this.localisationCorruptionOffsetFilterButton.Size = new System.Drawing.Size(249, 25);
            this.localisationCorruptionOffsetFilterButton.TabIndex = 1;
            this.localisationCorruptionOffsetFilterButton.Text = "Filter Options...";
            this.localisationCorruptionOffsetFilterButton.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(409, 18);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(238, 13);
            this.label13.TabIndex = 8;
            this.label13.Text = "Probability of Corruption (per Localisation Token):";
            // 
            // localisationCorruptionOffsetTrackBar
            // 
            this.localisationCorruptionOffsetTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.localisationCorruptionOffsetTrackBar.AutoSize = false;
            this.localisationCorruptionOffsetTrackBar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.localisationCorruptionOffsetTrackBar.Location = new System.Drawing.Point(386, 34);
            this.localisationCorruptionOffsetTrackBar.Maximum = 100;
            this.localisationCorruptionOffsetTrackBar.Name = "localisationCorruptionOffsetTrackBar";
            this.localisationCorruptionOffsetTrackBar.Size = new System.Drawing.Size(276, 30);
            this.localisationCorruptionOffsetTrackBar.TabIndex = 3;
            this.localisationCorruptionOffsetTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.toolTip1.SetToolTip(this.localisationCorruptionOffsetTrackBar, "Affects the chance that a localisation token can be selected for the ASCII Offset" +
        " corruption.");
            this.localisationCorruptionOffsetTrackBar.Value = 100;
            // 
            // localisationCorruptionOffsetEnableCheckBox
            // 
            this.localisationCorruptionOffsetEnableCheckBox.AutoSize = true;
            this.localisationCorruptionOffsetEnableCheckBox.Checked = true;
            this.localisationCorruptionOffsetEnableCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.localisationCorruptionOffsetEnableCheckBox.Location = new System.Drawing.Point(6, 19);
            this.localisationCorruptionOffsetEnableCheckBox.Name = "localisationCorruptionOffsetEnableCheckBox";
            this.localisationCorruptionOffsetEnableCheckBox.Size = new System.Drawing.Size(224, 17);
            this.localisationCorruptionOffsetEnableCheckBox.TabIndex = 0;
            this.localisationCorruptionOffsetEnableCheckBox.Text = "Offset ASCII Values in Localisation Entries";
            this.toolTip1.SetToolTip(this.localisationCorruptionOffsetEnableCheckBox, "When enabled, corruption will change the values of numbers by a specific offset.");
            this.localisationCorruptionOffsetEnableCheckBox.UseVisualStyleBackColor = true;
            this.localisationCorruptionOffsetEnableCheckBox.CheckedChanged += new System.EventHandler(this.localisationCorruptionOffsetEnableCheckBox_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.localisationCorruptionLanguageSeedNumeric);
            this.groupBox3.Controls.Add(this.label24);
            this.groupBox3.Controls.Add(this.localisationCorruptionLanguageSettingsButton);
            this.groupBox3.Controls.Add(this.localisationCorruptionLanguageChanceLabel);
            this.groupBox3.Controls.Add(this.localisationCorruptionLanguageFilterButton);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.localisationCorruptionLanguageTrackBar);
            this.groupBox3.Controls.Add(this.localisationCorruptionLanguageEnableCheckBox);
            this.groupBox3.Location = new System.Drawing.Point(6, 128);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(705, 98);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Swap Languages";
            // 
            // localisationCorruptionLanguageSettingsButton
            // 
            this.localisationCorruptionLanguageSettingsButton.Location = new System.Drawing.Point(6, 67);
            this.localisationCorruptionLanguageSettingsButton.Name = "localisationCorruptionLanguageSettingsButton";
            this.localisationCorruptionLanguageSettingsButton.Size = new System.Drawing.Size(249, 25);
            this.localisationCorruptionLanguageSettingsButton.TabIndex = 2;
            this.localisationCorruptionLanguageSettingsButton.Text = "Language Settings...";
            this.localisationCorruptionLanguageSettingsButton.UseVisualStyleBackColor = true;
            this.localisationCorruptionLanguageSettingsButton.Click += new System.EventHandler(this.localisationCorruptionLanguageSettingsButton_Click);
            // 
            // localisationCorruptionLanguageChanceLabel
            // 
            this.localisationCorruptionLanguageChanceLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.localisationCorruptionLanguageChanceLabel.AutoSize = true;
            this.localisationCorruptionLanguageChanceLabel.Location = new System.Drawing.Point(668, 37);
            this.localisationCorruptionLanguageChanceLabel.Name = "localisationCorruptionLanguageChanceLabel";
            this.localisationCorruptionLanguageChanceLabel.Size = new System.Drawing.Size(33, 13);
            this.localisationCorruptionLanguageChanceLabel.TabIndex = 10;
            this.localisationCorruptionLanguageChanceLabel.Text = "100%";
            this.localisationCorruptionLanguageChanceLabel.TextChanged += new System.EventHandler(this.localisationCorruptionLanguageChanceLabel_TextChanged);
            // 
            // localisationCorruptionLanguageFilterButton
            // 
            this.localisationCorruptionLanguageFilterButton.Enabled = false;
            this.localisationCorruptionLanguageFilterButton.Location = new System.Drawing.Point(6, 37);
            this.localisationCorruptionLanguageFilterButton.Name = "localisationCorruptionLanguageFilterButton";
            this.localisationCorruptionLanguageFilterButton.Size = new System.Drawing.Size(249, 25);
            this.localisationCorruptionLanguageFilterButton.TabIndex = 1;
            this.localisationCorruptionLanguageFilterButton.Text = "Filter Options...";
            this.localisationCorruptionLanguageFilterButton.UseVisualStyleBackColor = true;
            this.localisationCorruptionLanguageFilterButton.Click += new System.EventHandler(this.localisationCorruptionLanguageFilterButton_Click);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(467, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Probability of Corruption:";
            // 
            // localisationCorruptionLanguageTrackBar
            // 
            this.localisationCorruptionLanguageTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.localisationCorruptionLanguageTrackBar.AutoSize = false;
            this.localisationCorruptionLanguageTrackBar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.localisationCorruptionLanguageTrackBar.Location = new System.Drawing.Point(386, 34);
            this.localisationCorruptionLanguageTrackBar.Maximum = 100;
            this.localisationCorruptionLanguageTrackBar.Name = "localisationCorruptionLanguageTrackBar";
            this.localisationCorruptionLanguageTrackBar.Size = new System.Drawing.Size(276, 30);
            this.localisationCorruptionLanguageTrackBar.TabIndex = 3;
            this.localisationCorruptionLanguageTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.toolTip1.SetToolTip(this.localisationCorruptionLanguageTrackBar, "Affects the chance that languages will be swapped.");
            this.localisationCorruptionLanguageTrackBar.Value = 100;
            this.localisationCorruptionLanguageTrackBar.Scroll += new System.EventHandler(this.localisationCorruptionLanguageTrackBar_Scroll);
            // 
            // localisationCorruptionLanguageEnableCheckBox
            // 
            this.localisationCorruptionLanguageEnableCheckBox.AutoSize = true;
            this.localisationCorruptionLanguageEnableCheckBox.Checked = true;
            this.localisationCorruptionLanguageEnableCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.localisationCorruptionLanguageEnableCheckBox.Location = new System.Drawing.Point(6, 19);
            this.localisationCorruptionLanguageEnableCheckBox.Name = "localisationCorruptionLanguageEnableCheckBox";
            this.localisationCorruptionLanguageEnableCheckBox.Size = new System.Drawing.Size(254, 17);
            this.localisationCorruptionLanguageEnableCheckBox.TabIndex = 0;
            this.localisationCorruptionLanguageEnableCheckBox.Text = "Swap Localisation Entries with Other Languages";
            this.toolTip1.SetToolTip(this.localisationCorruptionLanguageEnableCheckBox, "When enabled, corruption will change the values of numbers by a specific offset.");
            this.localisationCorruptionLanguageEnableCheckBox.UseVisualStyleBackColor = true;
            this.localisationCorruptionLanguageEnableCheckBox.CheckedChanged += new System.EventHandler(this.localisationCorruptionLanguageEnableCheckBox_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.localisationCorruptionSwapSeedNumeric);
            this.groupBox4.Controls.Add(this.label25);
            this.groupBox4.Controls.Add(this.localisationCorruptionSwapChanceLabel);
            this.groupBox4.Controls.Add(this.localisationCorruptionSwapFilterButton);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.localisationCorruptionSwapTrackBar);
            this.groupBox4.Controls.Add(this.localisationCorruptionSwapEnableCheckBox);
            this.groupBox4.Location = new System.Drawing.Point(6, 19);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(705, 103);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Swap Localisation Entries";
            // 
            // localisationCorruptionSwapChanceLabel
            // 
            this.localisationCorruptionSwapChanceLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.localisationCorruptionSwapChanceLabel.AutoSize = true;
            this.localisationCorruptionSwapChanceLabel.Location = new System.Drawing.Point(668, 35);
            this.localisationCorruptionSwapChanceLabel.Name = "localisationCorruptionSwapChanceLabel";
            this.localisationCorruptionSwapChanceLabel.Size = new System.Drawing.Size(33, 13);
            this.localisationCorruptionSwapChanceLabel.TabIndex = 10;
            this.localisationCorruptionSwapChanceLabel.Text = "100%";
            this.localisationCorruptionSwapChanceLabel.TextChanged += new System.EventHandler(this.localisationCorruptionSwapChanceLabel_TextChanged);
            // 
            // localisationCorruptionSwapFilterButton
            // 
            this.localisationCorruptionSwapFilterButton.Location = new System.Drawing.Point(6, 37);
            this.localisationCorruptionSwapFilterButton.Name = "localisationCorruptionSwapFilterButton";
            this.localisationCorruptionSwapFilterButton.Size = new System.Drawing.Size(249, 25);
            this.localisationCorruptionSwapFilterButton.TabIndex = 1;
            this.localisationCorruptionSwapFilterButton.Text = "Filter Options...";
            this.localisationCorruptionSwapFilterButton.UseVisualStyleBackColor = true;
            this.localisationCorruptionSwapFilterButton.Click += new System.EventHandler(this.localisationCorruptionSwapFilterButton_Click);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(465, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(121, 13);
            this.label11.TabIndex = 8;
            this.label11.Text = "Probability of Corruption:";
            // 
            // localisationCorruptionSwapTrackBar
            // 
            this.localisationCorruptionSwapTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.localisationCorruptionSwapTrackBar.AutoSize = false;
            this.localisationCorruptionSwapTrackBar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.localisationCorruptionSwapTrackBar.Location = new System.Drawing.Point(386, 32);
            this.localisationCorruptionSwapTrackBar.Maximum = 100;
            this.localisationCorruptionSwapTrackBar.Name = "localisationCorruptionSwapTrackBar";
            this.localisationCorruptionSwapTrackBar.Size = new System.Drawing.Size(276, 30);
            this.localisationCorruptionSwapTrackBar.TabIndex = 2;
            this.localisationCorruptionSwapTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.toolTip1.SetToolTip(this.localisationCorruptionSwapTrackBar, "Affects the chance that parameters will be swapped");
            this.localisationCorruptionSwapTrackBar.Value = 100;
            this.localisationCorruptionSwapTrackBar.Scroll += new System.EventHandler(this.localisationCorruptionSwapTrackBar_Scroll);
            // 
            // localisationCorruptionSwapEnableCheckBox
            // 
            this.localisationCorruptionSwapEnableCheckBox.AutoSize = true;
            this.localisationCorruptionSwapEnableCheckBox.Checked = true;
            this.localisationCorruptionSwapEnableCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.localisationCorruptionSwapEnableCheckBox.Location = new System.Drawing.Point(6, 19);
            this.localisationCorruptionSwapEnableCheckBox.Name = "localisationCorruptionSwapEnableCheckBox";
            this.localisationCorruptionSwapEnableCheckBox.Size = new System.Drawing.Size(233, 17);
            this.localisationCorruptionSwapEnableCheckBox.TabIndex = 0;
            this.localisationCorruptionSwapEnableCheckBox.Text = "Swap Localisation Entries with Other Entries";
            this.toolTip1.SetToolTip(this.localisationCorruptionSwapEnableCheckBox, "When enabled, corruption will swap material parameters with others.");
            this.localisationCorruptionSwapEnableCheckBox.UseVisualStyleBackColor = true;
            this.localisationCorruptionSwapEnableCheckBox.CheckedChanged += new System.EventHandler(this.localisationCorruptionSwapEnableCheckBox_CheckedChanged);
            // 
            // localisationCorruptionEnableCheckBox
            // 
            this.localisationCorruptionEnableCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.localisationCorruptionEnableCheckBox.AutoSize = true;
            this.localisationCorruptionEnableCheckBox.Location = new System.Drawing.Point(311, 6);
            this.localisationCorruptionEnableCheckBox.Name = "localisationCorruptionEnableCheckBox";
            this.localisationCorruptionEnableCheckBox.Size = new System.Drawing.Size(110, 17);
            this.localisationCorruptionEnableCheckBox.TabIndex = 0;
            this.localisationCorruptionEnableCheckBox.Text = "Enable Corruption";
            this.localisationCorruptionEnableCheckBox.UseVisualStyleBackColor = true;
            this.localisationCorruptionEnableCheckBox.CheckedChanged += new System.EventHandler(this.LocalisationCorruptionEnableCheckBox_CheckedChanged);
            this.localisationCorruptionEnableCheckBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LocalisationCorruptionEnableCheckBox_MouseUp);
            // 
            // tabExport
            // 
            this.tabExport.Controls.Add(this.label9);
            this.tabExport.Controls.Add(this.parametersForExportList);
            this.tabExport.Controls.Add(this.customFileCheckList);
            this.tabExport.Controls.Add(this.customFilesCheckBox);
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
            this.tabExport.Size = new System.Drawing.Size(744, 636);
            this.tabExport.TabIndex = 2;
            this.tabExport.Text = "Export";
            this.tabExport.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 11);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Enabled Modifiers";
            // 
            // parametersForExportList
            // 
            this.parametersForExportList.FormattingEnabled = true;
            this.parametersForExportList.Location = new System.Drawing.Point(4, 27);
            this.parametersForExportList.Name = "parametersForExportList";
            this.parametersForExportList.Size = new System.Drawing.Size(292, 212);
            this.parametersForExportList.TabIndex = 0;
            this.parametersForExportList.SelectedIndexChanged += new System.EventHandler(this.parametersForExportList_SelectedIndexChanged);
            // 
            // customFileCheckList
            // 
            this.customFileCheckList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.customFileCheckList.CheckOnClick = true;
            this.customFileCheckList.Enabled = false;
            this.customFileCheckList.FormattingEnabled = true;
            this.customFileCheckList.Location = new System.Drawing.Point(463, 27);
            this.customFileCheckList.Name = "customFileCheckList";
            this.customFileCheckList.Size = new System.Drawing.Size(273, 214);
            this.customFileCheckList.TabIndex = 2;
            // 
            // customFilesCheckBox
            // 
            this.customFilesCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.customFilesCheckBox.AutoSize = true;
            this.customFilesCheckBox.Location = new System.Drawing.Point(463, 4);
            this.customFilesCheckBox.Name = "customFilesCheckBox";
            this.customFilesCheckBox.Size = new System.Drawing.Size(168, 17);
            this.customFilesCheckBox.TabIndex = 1;
            this.customFilesCheckBox.Text = "Include Custom Files In Export";
            this.customFilesCheckBox.UseVisualStyleBackColor = true;
            this.customFilesCheckBox.CheckedChanged += new System.EventHandler(this.CustomFilesCheckBox_CheckedChanged);
            // 
            // exportLocationValidLabel
            // 
            this.exportLocationValidLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exportLocationValidLabel.AutoSize = true;
            this.exportLocationValidLabel.Location = new System.Drawing.Point(639, 276);
            this.exportLocationValidLabel.Name = "exportLocationValidLabel";
            this.exportLocationValidLabel.Size = new System.Drawing.Size(76, 13);
            this.exportLocationValidLabel.TabIndex = 17;
            this.exportLocationValidLabel.Text = "Location valid.";
            // 
            // gameLocationValidLabel
            // 
            this.gameLocationValidLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gameLocationValidLabel.AutoSize = true;
            this.gameLocationValidLabel.Location = new System.Drawing.Point(639, 254);
            this.gameLocationValidLabel.Name = "gameLocationValidLabel";
            this.gameLocationValidLabel.Size = new System.Drawing.Size(97, 13);
            this.gameLocationValidLabel.TabIndex = 16;
            this.gameLocationValidLabel.Text = "gameinfo.txt found.";
            // 
            // gameFileLocationButton
            // 
            this.gameFileLocationButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gameFileLocationButton.Location = new System.Drawing.Point(475, 251);
            this.gameFileLocationButton.Name = "gameFileLocationButton";
            this.gameFileLocationButton.Size = new System.Drawing.Size(158, 20);
            this.gameFileLocationButton.TabIndex = 4;
            this.gameFileLocationButton.Text = "Set Game Location...";
            this.gameFileLocationButton.UseVisualStyleBackColor = true;
            this.gameFileLocationButton.Click += new System.EventHandler(this.Button3_Click);
            // 
            // gameLocationText
            // 
            this.gameLocationText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gameLocationText.Location = new System.Drawing.Point(91, 251);
            this.gameLocationText.Name = "gameLocationText";
            this.gameLocationText.Size = new System.Drawing.Size(378, 20);
            this.gameLocationText.TabIndex = 3;
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
            this.startPackagingButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.startPackagingButton.Location = new System.Drawing.Point(4, 299);
            this.startPackagingButton.Name = "startPackagingButton";
            this.startPackagingButton.Size = new System.Drawing.Size(732, 44);
            this.startPackagingButton.TabIndex = 7;
            this.startPackagingButton.Text = "Begin Packaging";
            this.startPackagingButton.UseVisualStyleBackColor = true;
            this.startPackagingButton.Click += new System.EventHandler(this.StartPackagingButton_Click);
            // 
            // progressBox
            // 
            this.progressBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBox.Location = new System.Drawing.Point(4, 349);
            this.progressBox.Multiline = true;
            this.progressBox.Name = "progressBox";
            this.progressBox.ReadOnly = true;
            this.progressBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.progressBox.Size = new System.Drawing.Size(732, 266);
            this.progressBox.TabIndex = 8;
            // 
            // saveFileLocationButton
            // 
            this.saveFileLocationButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveFileLocationButton.Location = new System.Drawing.Point(475, 273);
            this.saveFileLocationButton.Name = "saveFileLocationButton";
            this.saveFileLocationButton.Size = new System.Drawing.Size(158, 20);
            this.saveFileLocationButton.TabIndex = 6;
            this.saveFileLocationButton.Text = "Set VPK Export Location...";
            this.saveFileLocationButton.UseVisualStyleBackColor = true;
            this.saveFileLocationButton.Click += new System.EventHandler(this.SaveFileLocationButton_Click);
            // 
            // saveFileLocationText
            // 
            this.saveFileLocationText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.saveFileLocationText.Location = new System.Drawing.Point(91, 273);
            this.saveFileLocationText.Name = "saveFileLocationText";
            this.saveFileLocationText.Size = new System.Drawing.Size(378, 20);
            this.saveFileLocationText.TabIndex = 5;
            this.saveFileLocationText.Leave += new System.EventHandler(this.SaveFileLocationText_Leave);
            // 
            // tabConfiguration
            // 
            this.tabConfiguration.Controls.Add(this.groupBox7);
            this.tabConfiguration.Location = new System.Drawing.Point(4, 22);
            this.tabConfiguration.Name = "tabConfiguration";
            this.tabConfiguration.Padding = new System.Windows.Forms.Padding(3);
            this.tabConfiguration.Size = new System.Drawing.Size(744, 636);
            this.tabConfiguration.TabIndex = 8;
            this.tabConfiguration.Text = "Configuration";
            this.tabConfiguration.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.enableAutosaveCheckBox);
            this.groupBox7.Controls.Add(this.label18);
            this.groupBox7.Controls.Add(this.autosaveIntervalNumeric);
            this.groupBox7.Controls.Add(this.exportParametersButton);
            this.groupBox7.Controls.Add(this.importParametersButton);
            this.groupBox7.Controls.Add(this.launchGameArgumentsTextBox);
            this.groupBox7.Controls.Add(this.label3);
            this.groupBox7.Controls.Add(this.disableNotificationsCheckBox);
            this.groupBox7.Controls.Add(this.launchGameCheckBox);
            this.groupBox7.Controls.Add(this.muteCheckBox);
            this.groupBox7.Location = new System.Drawing.Point(8, 6);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(356, 210);
            this.groupBox7.TabIndex = 0;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Asset Editor Settings";
            // 
            // enableAutosaveCheckBox
            // 
            this.enableAutosaveCheckBox.AutoSize = true;
            this.enableAutosaveCheckBox.Checked = true;
            this.enableAutosaveCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enableAutosaveCheckBox.Location = new System.Drawing.Point(6, 156);
            this.enableAutosaveCheckBox.Name = "enableAutosaveCheckBox";
            this.enableAutosaveCheckBox.Size = new System.Drawing.Size(107, 17);
            this.enableAutosaveCheckBox.TabIndex = 30;
            this.enableAutosaveCheckBox.Text = "Enable Autosave";
            this.enableAutosaveCheckBox.UseVisualStyleBackColor = true;
            this.enableAutosaveCheckBox.CheckedChanged += new System.EventHandler(this.enableAutosaveCheckBox_CheckedChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 180);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(136, 13);
            this.label18.TabIndex = 29;
            this.label18.Text = "Autosave Interval (Minutes)";
            // 
            // autosaveIntervalNumeric
            // 
            this.autosaveIntervalNumeric.Location = new System.Drawing.Point(148, 178);
            this.autosaveIntervalNumeric.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.autosaveIntervalNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.autosaveIntervalNumeric.Name = "autosaveIntervalNumeric";
            this.autosaveIntervalNumeric.Size = new System.Drawing.Size(120, 20);
            this.autosaveIntervalNumeric.TabIndex = 28;
            this.autosaveIntervalNumeric.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.autosaveIntervalNumeric.ValueChanged += new System.EventHandler(this.autosaveIntervalNumeric_ValueChanged);
            // 
            // exportParametersButton
            // 
            this.exportParametersButton.Location = new System.Drawing.Point(179, 127);
            this.exportParametersButton.Name = "exportParametersButton";
            this.exportParametersButton.Size = new System.Drawing.Size(167, 23);
            this.exportParametersButton.TabIndex = 27;
            this.exportParametersButton.Text = "Export Parameters to File...";
            this.exportParametersButton.UseVisualStyleBackColor = true;
            this.exportParametersButton.Click += new System.EventHandler(this.exportParametersButton_Click);
            // 
            // importParametersButton
            // 
            this.importParametersButton.Location = new System.Drawing.Point(6, 127);
            this.importParametersButton.Name = "importParametersButton";
            this.importParametersButton.Size = new System.Drawing.Size(167, 23);
            this.importParametersButton.TabIndex = 26;
            this.importParametersButton.Text = "Import Parameters from File...";
            this.importParametersButton.UseVisualStyleBackColor = true;
            this.importParametersButton.Click += new System.EventHandler(this.importParametersButton_Click);
            // 
            // launchGameArgumentsTextBox
            // 
            this.launchGameArgumentsTextBox.Enabled = false;
            this.launchGameArgumentsTextBox.Location = new System.Drawing.Point(6, 101);
            this.launchGameArgumentsTextBox.Name = "launchGameArgumentsTextBox";
            this.launchGameArgumentsTextBox.Size = new System.Drawing.Size(340, 20);
            this.launchGameArgumentsTextBox.TabIndex = 4;
            this.toolTip1.SetToolTip(this.launchGameArgumentsTextBox, "If the game launches when finishing an export, what parameters should it be launc" +
        "hed with?");
            this.launchGameArgumentsTextBox.TextChanged += new System.EventHandler(this.launchGameArgumentsTextBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Game Launch Commands";
            // 
            // disableNotificationsCheckBox
            // 
            this.disableNotificationsCheckBox.AutoSize = true;
            this.disableNotificationsCheckBox.Location = new System.Drawing.Point(6, 42);
            this.disableNotificationsCheckBox.Name = "disableNotificationsCheckBox";
            this.disableNotificationsCheckBox.Size = new System.Drawing.Size(148, 17);
            this.disableNotificationsCheckBox.TabIndex = 2;
            this.disableNotificationsCheckBox.Text = "Mute System Notifications";
            this.toolTip1.SetToolTip(this.disableNotificationsCheckBox, "Mutes notifications on the taskbar (toast notifications)");
            this.disableNotificationsCheckBox.UseVisualStyleBackColor = true;
            this.disableNotificationsCheckBox.CheckedChanged += new System.EventHandler(this.disableNotificationsCheckBox_CheckedChanged);
            // 
            // launchGameCheckBox
            // 
            this.launchGameCheckBox.AutoSize = true;
            this.launchGameCheckBox.Location = new System.Drawing.Point(6, 65);
            this.launchGameCheckBox.Name = "launchGameCheckBox";
            this.launchGameCheckBox.Size = new System.Drawing.Size(207, 17);
            this.launchGameCheckBox.TabIndex = 3;
            this.launchGameCheckBox.Text = "Launch Game when Export is Finished";
            this.toolTip1.SetToolTip(this.launchGameCheckBox, "When an export is successfully completed, the application will play the game from" +
        " the specified Game Location.");
            this.launchGameCheckBox.UseVisualStyleBackColor = true;
            this.launchGameCheckBox.CheckedChanged += new System.EventHandler(this.launchGameCheckBox_CheckedChanged);
            // 
            // muteCheckBox
            // 
            this.muteCheckBox.AutoSize = true;
            this.muteCheckBox.Location = new System.Drawing.Point(6, 19);
            this.muteCheckBox.Name = "muteCheckBox";
            this.muteCheckBox.Size = new System.Drawing.Size(89, 17);
            this.muteCheckBox.TabIndex = 1;
            this.muteCheckBox.Text = "Mute Sounds";
            this.toolTip1.SetToolTip(this.muteCheckBox, "Mutes sounds.");
            this.muteCheckBox.UseVisualStyleBackColor = true;
            this.muteCheckBox.CheckedChanged += new System.EventHandler(this.muteCheckBox_CheckedChanged);
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
            this.toolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 640);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(752, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(42, 17);
            this.toolStripStatusLabel.Text = "Ready.";
            // 
            // executableOpenFileDialogue
            // 
            this.executableOpenFileDialogue.FileName = "hl2.exe";
            this.executableOpenFileDialogue.Filter = "Half Life 2 Executable|hl2.exe";
            this.executableOpenFileDialogue.FileOk += new System.ComponentModel.CancelEventHandler(this.executableOpenFileDialogue_FileOk);
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 200;
            this.toolTip1.ReshowDelay = 100;
            // 
            // importOpenFileDialogue
            // 
            this.importOpenFileDialogue.DefaultExt = "xml";
            this.importOpenFileDialogue.Filter = "XML File|*.xml";
            this.importOpenFileDialogue.FileOk += new System.ComponentModel.CancelEventHandler(this.importOpenFileDialogue_FileOk);
            // 
            // soundOpenFileDialogue
            // 
            this.soundOpenFileDialogue.Filter = "Audio Files|*.wav;*.mp3";
            this.soundOpenFileDialogue.Multiselect = true;
            this.soundOpenFileDialogue.FileOk += new System.ComponentModel.CancelEventHandler(this.soundOpenFileDialogue_FileOk);
            // 
            // localisationSeedSettingsGroupBox
            // 
            this.localisationSeedSettingsGroupBox.Controls.Add(this.localisationSeedSettingsIndividualNumeric);
            this.localisationSeedSettingsGroupBox.Controls.Add(this.label19);
            this.localisationSeedSettingsGroupBox.Controls.Add(this.localisationSeedSettingsRandomizerNumeric);
            this.localisationSeedSettingsGroupBox.Controls.Add(this.label20);
            this.localisationSeedSettingsGroupBox.Location = new System.Drawing.Point(219, 139);
            this.localisationSeedSettingsGroupBox.Name = "localisationSeedSettingsGroupBox";
            this.localisationSeedSettingsGroupBox.Size = new System.Drawing.Size(321, 77);
            this.localisationSeedSettingsGroupBox.TabIndex = 9;
            this.localisationSeedSettingsGroupBox.TabStop = false;
            this.localisationSeedSettingsGroupBox.Text = "Seed Settings (-1 for no seed)";
            // 
            // localisationSeedSettingsIndividualNumeric
            // 
            this.localisationSeedSettingsIndividualNumeric.Location = new System.Drawing.Point(195, 45);
            this.localisationSeedSettingsIndividualNumeric.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.localisationSeedSettingsIndividualNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.localisationSeedSettingsIndividualNumeric.Name = "localisationSeedSettingsIndividualNumeric";
            this.localisationSeedSettingsIndividualNumeric.Size = new System.Drawing.Size(120, 20);
            this.localisationSeedSettingsIndividualNumeric.TabIndex = 3;
            this.localisationSeedSettingsIndividualNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.localisationSeedSettingsIndividualNumeric.ValueChanged += new System.EventHandler(this.localisationSeedSettingsIndividualNumeric_ValueChanged);
            // 
            // localisationSeedSettingsRandomizerNumeric
            // 
            this.localisationSeedSettingsRandomizerNumeric.Location = new System.Drawing.Point(195, 23);
            this.localisationSeedSettingsRandomizerNumeric.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.localisationSeedSettingsRandomizerNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.localisationSeedSettingsRandomizerNumeric.Name = "localisationSeedSettingsRandomizerNumeric";
            this.localisationSeedSettingsRandomizerNumeric.Size = new System.Drawing.Size(120, 20);
            this.localisationSeedSettingsRandomizerNumeric.TabIndex = 1;
            this.localisationSeedSettingsRandomizerNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.localisationSeedSettingsRandomizerNumeric.ValueChanged += new System.EventHandler(this.localisationSeedSettingsRandomizerNumeric_ValueChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(8, 25);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(156, 13);
            this.label20.TabIndex = 0;
            this.label20.Text = "Probability of Appearance Seed";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(8, 47);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(124, 13);
            this.label19.TabIndex = 2;
            this.label19.Text = "Individual Matches Seed";
            // 
            // localisationCorruptionScrambleSeedNumeric
            // 
            this.localisationCorruptionScrambleSeedNumeric.Location = new System.Drawing.Point(536, 68);
            this.localisationCorruptionScrambleSeedNumeric.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.localisationCorruptionScrambleSeedNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.localisationCorruptionScrambleSeedNumeric.Name = "localisationCorruptionScrambleSeedNumeric";
            this.localisationCorruptionScrambleSeedNumeric.Size = new System.Drawing.Size(120, 20);
            this.localisationCorruptionScrambleSeedNumeric.TabIndex = 16;
            this.localisationCorruptionScrambleSeedNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.localisationCorruptionScrambleSeedNumeric.ValueChanged += new System.EventHandler(this.localisationCorruptionScrambleSeedNumeric_ValueChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(381, 70);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(149, 13);
            this.label21.TabIndex = 15;
            this.label21.Text = "Probability of Corruption Seed:";
            // 
            // localisationCorruptionOffsetSeedNumeric
            // 
            this.localisationCorruptionOffsetSeedNumeric.Location = new System.Drawing.Point(542, 105);
            this.localisationCorruptionOffsetSeedNumeric.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.localisationCorruptionOffsetSeedNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.localisationCorruptionOffsetSeedNumeric.Name = "localisationCorruptionOffsetSeedNumeric";
            this.localisationCorruptionOffsetSeedNumeric.Size = new System.Drawing.Size(120, 20);
            this.localisationCorruptionOffsetSeedNumeric.TabIndex = 18;
            this.localisationCorruptionOffsetSeedNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.localisationCorruptionOffsetSeedNumeric.ValueChanged += new System.EventHandler(this.localisationCorruptionOffsetSeedNumeric_ValueChanged);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(387, 107);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(149, 13);
            this.label23.TabIndex = 17;
            this.label23.Text = "Probability of Corruption Seed:";
            // 
            // localisationCorruptionLanguageSeedNumeric
            // 
            this.localisationCorruptionLanguageSeedNumeric.Location = new System.Drawing.Point(542, 67);
            this.localisationCorruptionLanguageSeedNumeric.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.localisationCorruptionLanguageSeedNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.localisationCorruptionLanguageSeedNumeric.Name = "localisationCorruptionLanguageSeedNumeric";
            this.localisationCorruptionLanguageSeedNumeric.Size = new System.Drawing.Size(120, 20);
            this.localisationCorruptionLanguageSeedNumeric.TabIndex = 16;
            this.localisationCorruptionLanguageSeedNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.localisationCorruptionLanguageSeedNumeric.ValueChanged += new System.EventHandler(this.localisationCorruptionLanguageSeedNumeric_ValueChanged);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(387, 69);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(149, 13);
            this.label24.TabIndex = 15;
            this.label24.Text = "Probability of Corruption Seed:";
            // 
            // localisationCorruptionSwapSeedNumeric
            // 
            this.localisationCorruptionSwapSeedNumeric.Location = new System.Drawing.Point(542, 77);
            this.localisationCorruptionSwapSeedNumeric.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.localisationCorruptionSwapSeedNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.localisationCorruptionSwapSeedNumeric.Name = "localisationCorruptionSwapSeedNumeric";
            this.localisationCorruptionSwapSeedNumeric.Size = new System.Drawing.Size(120, 20);
            this.localisationCorruptionSwapSeedNumeric.TabIndex = 16;
            this.localisationCorruptionSwapSeedNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.localisationCorruptionSwapSeedNumeric.ValueChanged += new System.EventHandler(this.localisationCorruptionSwapSeedNumeric_ValueChanged);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(387, 79);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(149, 13);
            this.label25.TabIndex = 15;
            this.label25.Text = "Probability of Corruption Seed:";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 662);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.windowTabControls);
            this.HelpButton = true;
            this.Icon = global::AssetManager.Properties.Resources.Icon;
            this.MinimumSize = new System.Drawing.Size(768, 701);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Team Fortress 2 Mass Asset Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            tabMaterialModification.ResumeLayout(false);
            this.materialSettingsResizePanel.ResumeLayout(false);
            this.materialSettingsResizePanel.PerformLayout();
            this.materialParameterSettingsGroupBox.ResumeLayout(false);
            this.materialRandomizerSettingsGroupBox.ResumeLayout(false);
            this.materialRandomizerSettingsGroupBox.PerformLayout();
            this.materialSeedSettingsGroupBox.ResumeLayout(false);
            this.materialSeedSettingsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.materialSeedSettingsOffsetNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialSeedSettingsRandomizerNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialRandomizerChanceTrackBar)).EndInit();
            this.deviationSettingsGroupBox.ResumeLayout(false);
            this.deviationSettingsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.randomizerOffsetNumeric3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.randomizerOffsetNumeric2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.randomizerOffsetNumeric)).EndInit();
            this.filterSettingsGroupBox.ResumeLayout(false);
            this.filterSettingsGroupBox.PerformLayout();
            this.miscellaneousSettingsGroupBox.ResumeLayout(false);
            this.miscellaneousSettingsGroupBox.PerformLayout();
            this.windowTabControls.ResumeLayout(false);
            this.tabMaterials.ResumeLayout(false);
            this.materialTabControls.ResumeLayout(false);
            this.tabMaterialCorruption.ResumeLayout(false);
            this.tabMaterialCorruption.PerformLayout();
            this.corruptionSettingsGroupBox.ResumeLayout(false);
            this.corruptionOffsetGroupBox.ResumeLayout(false);
            this.corruptionOffsetGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.materialCorruptionOffsetSeedNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.corruptionOffsetTrackBar)).EndInit();
            this.corruptionSwapSettingsGroupBox.ResumeLayout(false);
            this.corruptionSwapSettingsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.materialCorruptionSwapSeedNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.corruptionSwapTrackBar)).EndInit();
            this.tabTextures.ResumeLayout(false);
            this.textureTabControls.ResumeLayout(false);
            this.tabTextureModification.ResumeLayout(false);
            this.textureSettingsResizeLabel.ResumeLayout(false);
            this.textureSettingsResizeLabel.PerformLayout();
            this.tabSounds.ResumeLayout(false);
            this.soundsTabControls.ResumeLayout(false);
            this.tabSoundModification.ResumeLayout(false);
            this.soundSettingsResizePanel.ResumeLayout(false);
            this.soundSettingsResizePanel.PerformLayout();
            this.tabSoundAddition.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.soundFileListingDataGridView)).EndInit();
            this.tabLocalization.ResumeLayout(false);
            this.localisationTabControls.ResumeLayout(false);
            this.tabLocalisationModification.ResumeLayout(false);
            this.localisationParameterSettingsGroupBox.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.localisationLetterCountMaxNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.localisationLetterCountMinNumeric)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.localisationRandomizerIndividualChanceTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.localisationRandomizerChanceTrackBar)).EndInit();
            this.localisationSettingsResizePanel.ResumeLayout(false);
            this.localisationSettingsResizePanel.PerformLayout();
            this.tabLocalisationCorruption.ResumeLayout(false);
            this.tabLocalisationCorruption.PerformLayout();
            this.localisationCorruptionSettingsGroupBox.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.localisationCorruptionScrambleTrackBar)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.localisationCorruptionIndividualOffsetTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.localisationCorruptionOffsetTrackBar)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.localisationCorruptionLanguageTrackBar)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.localisationCorruptionSwapTrackBar)).EndInit();
            this.tabExport.ResumeLayout(false);
            this.tabExport.PerformLayout();
            this.tabConfiguration.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.autosaveIntervalNumeric)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.localisationSeedSettingsGroupBox.ResumeLayout(false);
            this.localisationSeedSettingsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.localisationSeedSettingsIndividualNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.localisationSeedSettingsRandomizerNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.localisationCorruptionScrambleSeedNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.localisationCorruptionOffsetSeedNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.localisationCorruptionLanguageSeedNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.localisationCorruptionSwapSeedNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl windowTabControls;
        private System.Windows.Forms.TabPage tabMaterials;
        private System.Windows.Forms.TabPage tabSounds;
        private System.Windows.Forms.CheckedListBox materialParameterList;
        private System.Windows.Forms.Label materialParametersLabel;
        private System.Windows.Forms.Button manageMaterialParametersButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.GroupBox materialParameterSettingsGroupBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TreeView vpkDirectoryListing;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
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
        private System.Windows.Forms.OpenFileDialog executableOpenFileDialogue;
        private System.Windows.Forms.GroupBox materialRandomizerSettingsGroupBox;
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
        private System.Windows.Forms.GroupBox filterSettingsGroupBox;
        private System.Windows.Forms.Button excludedShadersButton;
        private System.Windows.Forms.GroupBox miscellaneousSettingsGroupBox;
        private System.Windows.Forms.CheckBox caseInsensitiveCheckBox;
        private System.Windows.Forms.TabPage tabTextures;
        private System.Windows.Forms.TabPage tabLocalization;
        private System.Windows.Forms.TrackBar materialRandomizerChanceTrackBar;
        private System.Windows.Forms.Label materialRandomizerChanceLabel;
        private System.Windows.Forms.CheckBox customFilesCheckBox;
        private System.Windows.Forms.CheckedListBox customFileCheckList;
        private System.Windows.Forms.Button proxyFilterButton;
        private System.Windows.Forms.TabControl materialTabControls;
        private System.Windows.Forms.TabPage tabMaterialCorruption;
        private System.Windows.Forms.CheckBox materialCorruptionEnableCheckBox;
        private System.Windows.Forms.GroupBox corruptionSettingsGroupBox;
        private System.Windows.Forms.GroupBox corruptionSwapSettingsGroupBox;
        private System.Windows.Forms.Button corruptionSwapFilterButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar corruptionSwapTrackBar;
        private System.Windows.Forms.CheckBox corruptionSwapEnableCheckBox;
        private System.Windows.Forms.Panel materialSettingsResizePanel;
        private System.Windows.Forms.Label corruptionSwapChanceLabel;
        private System.Windows.Forms.GroupBox corruptionOffsetGroupBox;
        private System.Windows.Forms.Label corruptionOffsetChanceLabel;
        private System.Windows.Forms.Button corruptionOffsetFilterButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar corruptionOffsetTrackBar;
        private System.Windows.Forms.CheckBox corruptionOffsetCheckBox;
        private System.Windows.Forms.TabControl localisationTabControls;
        private System.Windows.Forms.TabPage tabLocalisationModification;
        private System.Windows.Forms.TabPage tabLocalisationCorruption;
        private System.Windows.Forms.TabPage tabConfiguration;
        private System.Windows.Forms.Panel localisationSettingsResizePanel;
        private System.Windows.Forms.Label localisationParametersLabel;
        private System.Windows.Forms.CheckedListBox localisationParameterList;
        private System.Windows.Forms.Button manageLocalisationParametersButton;
        private System.Windows.Forms.TabControl textureTabControls;
        private System.Windows.Forms.TabPage tabTextureModification;
        private System.Windows.Forms.Panel textureSettingsResizeLabel;
        private System.Windows.Forms.Label textureParametersLabel;
        private System.Windows.Forms.CheckedListBox checkedListBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabTextureCorruption;
        private System.Windows.Forms.TabPage tabTextureAddition;
        private System.Windows.Forms.GroupBox localisationParameterSettingsGroupBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label localisationRandomizerChanceLabel;
        private System.Windows.Forms.TrackBar localisationRandomizerChanceTrackBar;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label localisationRandomizerIndividualChanceLabel;
        private System.Windows.Forms.TrackBar localisationRandomizerIndividualChanceTrackBar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox localisationLetterCountCheckBox;
        private System.Windows.Forms.Label localisationLetterCountMaxLabel;
        private System.Windows.Forms.NumericUpDown localisationLetterCountMaxNumeric;
        private System.Windows.Forms.Label localisationLetterCountMinLabel;
        private System.Windows.Forms.NumericUpDown localisationLetterCountMinNumeric;
        private System.Windows.Forms.GroupBox localisationCorruptionSettingsGroupBox;
        private System.Windows.Forms.CheckBox localisationCorruptionEnableCheckBox;
        private System.Windows.Forms.Button corruptionOffsetSettingsButton;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label localisationCorruptionOffsetChanceLabel;
        private System.Windows.Forms.Button localisationCorruptionOffsetFilterButton;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TrackBar localisationCorruptionOffsetTrackBar;
        private System.Windows.Forms.CheckBox localisationCorruptionOffsetEnableCheckBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label localisationCorruptionLanguageChanceLabel;
        private System.Windows.Forms.Button localisationCorruptionLanguageFilterButton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TrackBar localisationCorruptionLanguageTrackBar;
        private System.Windows.Forms.CheckBox localisationCorruptionLanguageEnableCheckBox;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label localisationCorruptionSwapChanceLabel;
        private System.Windows.Forms.Button localisationCorruptionSwapFilterButton;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TrackBar localisationCorruptionSwapTrackBar;
        private System.Windows.Forms.CheckBox localisationCorruptionSwapEnableCheckBox;
        private System.Windows.Forms.Button localisationCorruptionOffsetSettingsButton;
        private System.Windows.Forms.Button localisationCorruptionLanguageSettingsButton;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label localisationCorruptionScrambleChanceLabel;
        private System.Windows.Forms.Button localisationCorruptionScrambleFilterButton;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TrackBar localisationCorruptionScrambleTrackBar;
        private System.Windows.Forms.CheckBox localisationCorruptionScrambleEnableCheckBox;
        private System.Windows.Forms.Button localisationCorruptionScrambleSettingsButton;
        private System.Windows.Forms.ListBox parametersForExportList;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox launchGameArgumentsTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox disableNotificationsCheckBox;
        private System.Windows.Forms.CheckBox launchGameCheckBox;
        private System.Windows.Forms.CheckBox muteCheckBox;
        private System.Windows.Forms.Button exportParametersButton;
        private System.Windows.Forms.Button importParametersButton;
        private System.Windows.Forms.OpenFileDialog importOpenFileDialogue;
        private System.Windows.Forms.Label localisationCorruptionIndividualOffsetLabel;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TrackBar localisationCorruptionIndividualOffsetTrackBar;
        private System.Windows.Forms.GroupBox materialSeedSettingsGroupBox;
        private System.Windows.Forms.Label materialSeedSettingsRandomizerLabel;
        private System.Windows.Forms.NumericUpDown materialSeedSettingsRandomizerNumeric;
        private System.Windows.Forms.NumericUpDown materialSeedSettingsOffsetNumeric;
        private System.Windows.Forms.Label materialSeedSettingsOffsetLabel;
        private System.Windows.Forms.NumericUpDown materialCorruptionOffsetSeedNumeric;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown materialCorruptionSwapSeedNumeric;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TabControl soundsTabControls;
        private System.Windows.Forms.TabPage tabSoundModification;
        private System.Windows.Forms.Panel soundSettingsResizePanel;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button manageSoundParametersButton;
        private System.Windows.Forms.TabPage tabSoundCorruption;
        private System.Windows.Forms.TabPage tabSoundAddition;
        private System.Windows.Forms.Button soundFileRemoveButton;
        private System.Windows.Forms.Button soundFileAddButton;
        private System.Windows.Forms.DataGridView soundFileListingDataGridView;
        private System.Windows.Forms.OpenFileDialog soundOpenFileDialogue;
        private System.Windows.Forms.DataGridViewTextBoxColumn Key;
        private System.Windows.Forms.DataGridViewTextBoxColumn FullLocation;
        private System.Windows.Forms.DataGridViewButtonColumn PreviewButton;
        private System.Windows.Forms.CheckedListBox soundParameterList;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.NumericUpDown autosaveIntervalNumeric;
        private System.Windows.Forms.CheckBox enableAutosaveCheckBox;
        private System.Windows.Forms.GroupBox localisationSeedSettingsGroupBox;
        private System.Windows.Forms.NumericUpDown localisationSeedSettingsIndividualNumeric;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.NumericUpDown localisationSeedSettingsRandomizerNumeric;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.NumericUpDown localisationCorruptionScrambleSeedNumeric;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.NumericUpDown localisationCorruptionOffsetSeedNumeric;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.NumericUpDown localisationCorruptionLanguageSeedNumeric;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.NumericUpDown localisationCorruptionSwapSeedNumeric;
        private System.Windows.Forms.Label label25;
    }
}

