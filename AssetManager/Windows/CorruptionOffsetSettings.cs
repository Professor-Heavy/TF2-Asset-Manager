﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AssetManager
{
    public partial class CorruptionOffsetSettings : Form
    {
        public MaterialCorruptionSettings settings;
        public CorruptionOffsetSettings()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            settings.Arguments["OffsetLow"] = corruptionLowOffsetNumeric.Value.ToString();
            settings.Arguments["OffsetHigh"] = corruptionHighOffsetNumeric.Value.ToString();
            Close();
        }

        private void CorruptionOffsetSettings_Load(object sender, EventArgs e)
        {
            corruptionLowOffsetNumeric.Value = decimal.Parse(settings.Arguments["OffsetLow"]);
            corruptionHighOffsetNumeric.Value = decimal.Parse(settings.Arguments["OffsetHigh"]);
        }
    }
}
