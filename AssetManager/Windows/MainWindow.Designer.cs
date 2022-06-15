﻿using System;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.materialSettingsResizePanel = new System.Windows.Forms.Panel();
            this.materialParametersLabel = new System.Windows.Forms.Label();
            this.materialParameterList = new System.Windows.Forms.CheckedListBox();
            this.manageMaterialParametersButton = new System.Windows.Forms.Button();
            this.materialParameterSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.overwriteModeComboBox = new System.Windows.Forms.ComboBox();
            this.materialRandomizerSettingsGroupBox = new System.Windows.Forms.GroupBox();
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
            this.corruptionOffsetSettingsButton = new System.Windows.Forms.Button();
            this.corruptionOffsetChanceLabel = new System.Windows.Forms.Label();
            this.corruptionOffsetFilterButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.corruptionOffsetTrackBar = new System.Windows.Forms.TrackBar();
            this.corruptionOffsetCheckBox = new System.Windows.Forms.CheckBox();
            this.corruptionSwapSettingsGroupBox = new System.Windows.Forms.GroupBox();
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
            this.button8 = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.trackBar4 = new System.Windows.Forms.TrackBar();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.trackBar3 = new System.Windows.Forms.TrackBar();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.localisationCorruptionLanguageSettingsButton = new System.Windows.Forms.Button();
            this.localisationCorruptionLanguageChanceLabel = new System.Windows.Forms.Label();
            this.localisationCorruptionLanguageFilterButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.localisationCorruptionLanguageTrackBar = new System.Windows.Forms.TrackBar();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
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
            tabMaterialModification = new System.Windows.Forms.TabPage();
            tabMaterialModification.SuspendLayout();
            this.materialSettingsResizePanel.SuspendLayout();
            this.materialParameterSettingsGroupBox.SuspendLayout();
            this.materialRandomizerSettingsGroupBox.SuspendLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.corruptionOffsetTrackBar)).BeginInit();
            this.corruptionSwapSettingsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.corruptionSwapTrackBar)).BeginInit();
            this.tabTextures.SuspendLayout();
            this.textureTabControls.SuspendLayout();
            this.tabTextureModification.SuspendLayout();
            this.textureSettingsResizeLabel.SuspendLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.trackBar4)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.localisationCorruptionLanguageTrackBar)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.localisationCorruptionSwapTrackBar)).BeginInit();
            this.tabExport.SuspendLayout();
            this.tabConfiguration.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.statusStrip1.SuspendLayout();
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
            this.deviationSettingsGroupBox.Location = new System.Drawing.Point(10, 68);
            this.deviationSettingsGroupBox.Name = "deviationSettingsGroupBox";
            this.deviationSettingsGroupBox.Size = new System.Drawing.Size(313, 109);
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
            this.corruptionOffsetGroupBox.Controls.Add(this.corruptionOffsetSettingsButton);
            this.corruptionOffsetGroupBox.Controls.Add(this.corruptionOffsetChanceLabel);
            this.corruptionOffsetGroupBox.Controls.Add(this.corruptionOffsetFilterButton);
            this.corruptionOffsetGroupBox.Controls.Add(this.label4);
            this.corruptionOffsetGroupBox.Controls.Add(this.corruptionOffsetTrackBar);
            this.corruptionOffsetGroupBox.Controls.Add(this.corruptionOffsetCheckBox);
            this.corruptionOffsetGroupBox.Location = new System.Drawing.Point(6, 93);
            this.corruptionOffsetGroupBox.Name = "corruptionOffsetGroupBox";
            this.corruptionOffsetGroupBox.Size = new System.Drawing.Size(705, 100);
            this.corruptionOffsetGroupBox.TabIndex = 2;
            this.corruptionOffsetGroupBox.TabStop = false;
            this.corruptionOffsetGroupBox.Text = "Random Number Offset";
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
            this.toolTip1.SetToolTip(this.corruptionOffsetTrackBar, "Affects the chance that parameters will be swapped");
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
            this.corruptionSwapSettingsGroupBox.Controls.Add(this.corruptionSwapChanceLabel);
            this.corruptionSwapSettingsGroupBox.Controls.Add(this.corruptionSwapFilterButton);
            this.corruptionSwapSettingsGroupBox.Controls.Add(this.label1);
            this.corruptionSwapSettingsGroupBox.Controls.Add(this.corruptionSwapTrackBar);
            this.corruptionSwapSettingsGroupBox.Controls.Add(this.corruptionSwapEnableCheckBox);
            this.corruptionSwapSettingsGroupBox.Location = new System.Drawing.Point(6, 19);
            this.corruptionSwapSettingsGroupBox.Name = "corruptionSwapSettingsGroupBox";
            this.corruptionSwapSettingsGroupBox.Size = new System.Drawing.Size(705, 68);
            this.corruptionSwapSettingsGroupBox.TabIndex = 0;
            this.corruptionSwapSettingsGroupBox.TabStop = false;
            this.corruptionSwapSettingsGroupBox.Text = "Swap Parameters";
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
            this.toolTip1.SetToolTip(this.corruptionSwapTrackBar, "Affects the chance that parameters will be swapped");
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
            this.tabSounds.Location = new System.Drawing.Point(4, 22);
            this.tabSounds.Name = "tabSounds";
            this.tabSounds.Padding = new System.Windows.Forms.Padding(3);
            this.tabSounds.Size = new System.Drawing.Size(744, 636);
            this.tabSounds.TabIndex = 1;
            this.tabSounds.Text = "Sounds";
            this.tabSounds.UseVisualStyleBackColor = true;
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
            this.groupBox6.Controls.Add(this.button8);
            this.groupBox6.Controls.Add(this.label14);
            this.groupBox6.Controls.Add(this.button7);
            this.groupBox6.Controls.Add(this.label15);
            this.groupBox6.Controls.Add(this.trackBar4);
            this.groupBox6.Controls.Add(this.checkBox4);
            this.groupBox6.Location = new System.Drawing.Point(6, 301);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(705, 98);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Scramble Text";
            this.groupBox6.Visible = false;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(6, 68);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(249, 25);
            this.button8.TabIndex = 2;
            this.button8.Text = "Scramble Settings...";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(668, 35);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(33, 13);
            this.label14.TabIndex = 10;
            this.label14.Text = "100%";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(6, 37);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(249, 25);
            this.button7.TabIndex = 1;
            this.button7.Text = "Filter Options...";
            this.button7.UseVisualStyleBackColor = true;
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
            // trackBar4
            // 
            this.trackBar4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar4.AutoSize = false;
            this.trackBar4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.trackBar4.Location = new System.Drawing.Point(386, 32);
            this.trackBar4.Maximum = 100;
            this.trackBar4.Name = "trackBar4";
            this.trackBar4.Size = new System.Drawing.Size(276, 30);
            this.trackBar4.TabIndex = 3;
            this.trackBar4.TickStyle = System.Windows.Forms.TickStyle.None;
            this.toolTip1.SetToolTip(this.trackBar4, "Affects the chance that parameters will be swapped");
            this.trackBar4.Value = 100;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Checked = true;
            this.checkBox4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox4.Location = new System.Drawing.Point(6, 19);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(180, 17);
            this.checkBox4.TabIndex = 0;
            this.checkBox4.Text = "Scramble Localisation Entry Text";
            this.toolTip1.SetToolTip(this.checkBox4, "When enabled, corruption will swap material parameters with others.");
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.button5);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.button4);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.trackBar3);
            this.groupBox5.Controls.Add(this.checkBox3);
            this.groupBox5.Location = new System.Drawing.Point(6, 197);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(705, 98);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "ASCII Offset";
            this.groupBox5.Visible = false;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(6, 67);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(249, 25);
            this.button5.TabIndex = 2;
            this.button5.Text = "Offset Settings...";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(668, 37);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(33, 13);
            this.label12.TabIndex = 10;
            this.label12.Text = "100%";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(6, 37);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(249, 25);
            this.button4.TabIndex = 1;
            this.button4.Text = "Filter Options...";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(467, 18);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(121, 13);
            this.label13.TabIndex = 8;
            this.label13.Text = "Probability of Corruption:";
            // 
            // trackBar3
            // 
            this.trackBar3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar3.AutoSize = false;
            this.trackBar3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.trackBar3.Location = new System.Drawing.Point(386, 34);
            this.trackBar3.Maximum = 100;
            this.trackBar3.Name = "trackBar3";
            this.trackBar3.Size = new System.Drawing.Size(276, 30);
            this.trackBar3.TabIndex = 3;
            this.trackBar3.TickStyle = System.Windows.Forms.TickStyle.None;
            this.toolTip1.SetToolTip(this.trackBar3, "Affects the chance that parameters will be swapped");
            this.trackBar3.Value = 100;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Checked = true;
            this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox3.Location = new System.Drawing.Point(6, 19);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(224, 17);
            this.checkBox3.TabIndex = 0;
            this.checkBox3.Text = "Offset ASCII Values in Localisation Entries";
            this.toolTip1.SetToolTip(this.checkBox3, "When enabled, corruption will change the values of numbers by a specific offset.");
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.localisationCorruptionLanguageSettingsButton);
            this.groupBox3.Controls.Add(this.localisationCorruptionLanguageChanceLabel);
            this.groupBox3.Controls.Add(this.localisationCorruptionLanguageFilterButton);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.localisationCorruptionLanguageTrackBar);
            this.groupBox3.Controls.Add(this.checkBox1);
            this.groupBox3.Location = new System.Drawing.Point(6, 93);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(705, 98);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Swap Languages";
            this.groupBox3.Visible = false;
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
            // 
            // localisationCorruptionLanguageFilterButton
            // 
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
            this.toolTip1.SetToolTip(this.localisationCorruptionLanguageTrackBar, "Affects the chance that parameters will be swapped");
            this.localisationCorruptionLanguageTrackBar.Value = 100;
            this.localisationCorruptionLanguageTrackBar.Scroll += new System.EventHandler(this.localisationCorruptionLanguageTrackBar_Scroll);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(6, 19);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(254, 17);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Swap Localisation Entries with Other Languages";
            this.toolTip1.SetToolTip(this.checkBox1, "When enabled, corruption will change the values of numbers by a specific offset.");
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.localisationCorruptionSwapChanceLabel);
            this.groupBox4.Controls.Add(this.localisationCorruptionSwapFilterButton);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.localisationCorruptionSwapTrackBar);
            this.groupBox4.Controls.Add(this.localisationCorruptionSwapEnableCheckBox);
            this.groupBox4.Location = new System.Drawing.Point(6, 19);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(705, 68);
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
            this.groupBox7.Controls.Add(this.exportParametersButton);
            this.groupBox7.Controls.Add(this.importParametersButton);
            this.groupBox7.Controls.Add(this.launchGameArgumentsTextBox);
            this.groupBox7.Controls.Add(this.label3);
            this.groupBox7.Controls.Add(this.disableNotificationsCheckBox);
            this.groupBox7.Controls.Add(this.launchGameCheckBox);
            this.groupBox7.Controls.Add(this.muteCheckBox);
            this.groupBox7.Location = new System.Drawing.Point(8, 6);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(356, 163);
            this.groupBox7.TabIndex = 0;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Asset Editor Settings";
            // 
            // exportParametersButton
            // 
            this.exportParametersButton.Location = new System.Drawing.Point(179, 127);
            this.exportParametersButton.Name = "exportParametersButton";
            this.exportParametersButton.Size = new System.Drawing.Size(167, 23);
            this.exportParametersButton.TabIndex = 27;
            this.exportParametersButton.Text = "Export Parameters to File...";
            this.exportParametersButton.UseVisualStyleBackColor = true;
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
            this.launchGameArgumentsTextBox.Location = new System.Drawing.Point(6, 101);
            this.launchGameArgumentsTextBox.Name = "launchGameArgumentsTextBox";
            this.launchGameArgumentsTextBox.Size = new System.Drawing.Size(340, 20);
            this.launchGameArgumentsTextBox.TabIndex = 4;
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
            ((System.ComponentModel.ISupportInitialize)(this.corruptionOffsetTrackBar)).EndInit();
            this.corruptionSwapSettingsGroupBox.ResumeLayout(false);
            this.corruptionSwapSettingsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.corruptionSwapTrackBar)).EndInit();
            this.tabTextures.ResumeLayout(false);
            this.textureTabControls.ResumeLayout(false);
            this.tabTextureModification.ResumeLayout(false);
            this.textureSettingsResizeLabel.ResumeLayout(false);
            this.textureSettingsResizeLabel.PerformLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.trackBar4)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
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
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TrackBar trackBar3;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label localisationCorruptionLanguageChanceLabel;
        private System.Windows.Forms.Button localisationCorruptionLanguageFilterButton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TrackBar localisationCorruptionLanguageTrackBar;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label localisationCorruptionSwapChanceLabel;
        private System.Windows.Forms.Button localisationCorruptionSwapFilterButton;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TrackBar localisationCorruptionSwapTrackBar;
        private System.Windows.Forms.CheckBox localisationCorruptionSwapEnableCheckBox;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button localisationCorruptionLanguageSettingsButton;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TrackBar trackBar4;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.Button button8;
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
    }
}
