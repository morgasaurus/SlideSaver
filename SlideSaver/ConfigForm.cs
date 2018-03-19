using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SlideSaver
{
    public partial class ConfigForm : Form
    {
        public ConfigForm()
        {
            InitializeComponent();
        }

        private void ConfigForm_Load(object sender, EventArgs e)
        {
            ReadConfig();
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Button_OK_Click(object sender, EventArgs e)
        {
            WriteConfig();
            Close();
        }

        private void Button_Browse_Click(object sender, EventArgs e)
        {
            if (FolderBrowserDialog_Folder.ShowDialog() == DialogResult.OK)
            {
                TextBox_Folder.Text = FolderBrowserDialog_Folder.SelectedPath;
            }
        }

        private void ReadConfig()
        {
            Config config = Utils.LoadConfig();

            switch (config.SequenceMode)
            {
                case SequenceMode.Name:
                    RadioButton_Name.Checked = true;
                    break;
                case SequenceMode.Date:
                    RadioButton_Date.Checked = true;
                    break;
                case SequenceMode.Random:
                    RadioButton_Random.Checked = true;
                    break;
                case SequenceMode.Shuffle:
                    RadioButton_Shuffle.Checked = true;
                    break;
                default:
                    RadioButton_Name.Checked = true;
                    break;
            }

            TextBox_Folder.Text = config.BasePath;

            CheckBox_IncludeSubfolders.Checked = config.IncludeSubdirectories;
        }

        private void WriteConfig()
        {
            Config config = new Config();

            config.SequenceMode = SequenceMode.Name;
            if (RadioButton_Date.Checked)
            {
                config.SequenceMode = SequenceMode.Date;
            }
            else if (RadioButton_Random.Checked)
            {
                config.SequenceMode = SequenceMode.Random;
            }
            else if (RadioButton_Shuffle.Checked)
            {
                config.SequenceMode = SequenceMode.Shuffle;
            }

            config.BasePath = TextBox_Folder.Text;

            config.IncludeSubdirectories = CheckBox_IncludeSubfolders.Checked;

            Utils.SaveConfig(config);
        }
    }
}
