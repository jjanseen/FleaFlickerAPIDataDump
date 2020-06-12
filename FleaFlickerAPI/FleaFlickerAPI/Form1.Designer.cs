namespace FleaFlickerAPI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtLeagueID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSeason = new System.Windows.Forms.TextBox();
            this.btnGetLeagueScoreboard = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtLeagueID
            // 
            this.txtLeagueID.Location = new System.Drawing.Point(95, 10);
            this.txtLeagueID.Name = "txtLeagueID";
            this.txtLeagueID.Size = new System.Drawing.Size(125, 27);
            this.txtLeagueID.TabIndex = 0;
            this.txtLeagueID.Text = "295664";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "League ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Season";
            // 
            // txtSeason
            // 
            this.txtSeason.Location = new System.Drawing.Point(95, 55);
            this.txtSeason.Name = "txtSeason";
            this.txtSeason.Size = new System.Drawing.Size(125, 27);
            this.txtSeason.TabIndex = 3;
            this.txtSeason.Text = "2019";
            // 
            // btnGetLeagueScoreboard
            // 
            this.btnGetLeagueScoreboard.Location = new System.Drawing.Point(33, 100);
            this.btnGetLeagueScoreboard.Name = "btnGetLeagueScoreboard";
            this.btnGetLeagueScoreboard.Size = new System.Drawing.Size(187, 29);
            this.btnGetLeagueScoreboard.TabIndex = 4;
            this.btnGetLeagueScoreboard.Text = "Get Scoreboard Data";
            this.btnGetLeagueScoreboard.UseVisualStyleBackColor = true;
            this.btnGetLeagueScoreboard.Click += new System.EventHandler(this.btnGetLeagueScoreboard_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(13, 144);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 20);
            this.lblStatus.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 185);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnGetLeagueScoreboard);
            this.Controls.Add(this.txtSeason);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLeagueID);
            this.Name = "Form1";
            this.Text = "Fleaflicker API";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLeagueID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSeason;
        private System.Windows.Forms.Button btnGetLeagueScoreboard;
        private System.Windows.Forms.Label lblStatus;
    }
}

