﻿namespace Quiz
{
    partial class Highscores
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
            this.btnReturnToMainMenu = new System.Windows.Forms.Button();
            this.lstHighscores = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lstBestHighScore = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnReturnToMainMenu
            // 
            this.btnReturnToMainMenu.Location = new System.Drawing.Point(305, 359);
            this.btnReturnToMainMenu.Name = "btnReturnToMainMenu";
            this.btnReturnToMainMenu.Size = new System.Drawing.Size(218, 79);
            this.btnReturnToMainMenu.TabIndex = 0;
            this.btnReturnToMainMenu.Text = "Main Menu";
            this.btnReturnToMainMenu.UseVisualStyleBackColor = true;
            this.btnReturnToMainMenu.Click += new System.EventHandler(this.btnReturnToMainMenu_Click);
            // 
            // lstHighscores
            // 
            this.lstHighscores.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstHighscores.FormattingEnabled = true;
            this.lstHighscores.ItemHeight = 22;
            this.lstHighscores.Location = new System.Drawing.Point(206, 230);
            this.lstHighscores.Name = "lstHighscores";
            this.lstHighscores.Size = new System.Drawing.Size(404, 114);
            this.lstHighscores.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(316, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 38);
            this.label1.TabIndex = 3;
            this.label1.Text = "Highscores";
            // 
            // lstBestHighScore
            // 
            this.lstBestHighScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstBestHighScore.FormattingEnabled = true;
            this.lstBestHighScore.ItemHeight = 22;
            this.lstBestHighScore.Location = new System.Drawing.Point(206, 111);
            this.lstBestHighScore.Name = "lstBestHighScore";
            this.lstBestHighScore.Size = new System.Drawing.Size(404, 70);
            this.lstBestHighScore.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(203, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Best HighScore";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(203, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Scores";
            // 
            // Highscores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstBestHighScore);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstHighscores);
            this.Controls.Add(this.btnReturnToMainMenu);
            this.Name = "Highscores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Highscores";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReturnToMainMenu;
        private System.Windows.Forms.ListBox lstHighscores;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstBestHighScore;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}