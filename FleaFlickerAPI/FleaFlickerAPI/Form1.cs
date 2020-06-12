using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FleaFlickerAPI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void btnGetLeagueScoreboard_Click(object sender, EventArgs e)
        {
            DisableForm();
            FetchScoreData fsd = new FetchScoreData(txtLeagueID.Text, txtSeason.Text);
            var reportProgress = new Progress<string>(progressText => lblStatus.Text = progressText);
            var enableForm = new Progress<string>(s => EnableForm(s));
            try
            {
                await Task.Factory.StartNew(() => fsd.ExecuteAsync(reportProgress, enableForm), TaskCreationOptions.LongRunning);
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error running import: " + ex.Message;
                EnableForm(null);
            }
        }

        private void DisableForm()
        {
            txtLeagueID.Enabled = false;
            txtSeason.Enabled = false;
            btnGetLeagueScoreboard.Enabled = false;
        }

        private void EnableForm(string excelFilePath)
        {
            txtLeagueID.Enabled = true;
            txtSeason.Enabled = true;
            btnGetLeagueScoreboard.Enabled = true;

            if (!string.IsNullOrWhiteSpace(excelFilePath))
            {
                lblStatus.Text = "Download complete!";
                var excelFile = new FileInfo(excelFilePath);

                if (excelFile.Exists && excelFile.Length != 0)
                {
                    try
                    {
                        ProcessStartInfo processStartInfo = new ProcessStartInfo()
                        {
                            UseShellExecute = true,
                            FileName = excelFilePath
                        };
                        //MessageBox.Show($"Some files were unable to be downloaded. Log file with details is located at {failedDownloads}. Attempting to open text file now.");
                        Process.Start(processStartInfo);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Couldn't open Excel automatically. Your Excel file is here: " + excelFilePath);
                    }
                }
            }
        }
    }
}
