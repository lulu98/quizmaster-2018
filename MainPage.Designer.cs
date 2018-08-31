namespace Quiz
{
    partial class MainPage
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
            this.questionBox = new System.Windows.Forms.RichTextBox();
            this.scoreBox = new System.Windows.Forms.RichTextBox();
            this.btnReturnToMainMenu = new System.Windows.Forms.Button();
            this.answerA = new System.Windows.Forms.Button();
            this.answerB = new System.Windows.Forms.Button();
            this.answerC = new System.Windows.Forms.Button();
            this.answerD = new System.Windows.Forms.Button();
            this.questionNumberBox = new System.Windows.Forms.RichTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timeBox = new System.Windows.Forms.RichTextBox();
            this.totalTimeBox = new System.Windows.Forms.RichTextBox();
            this.btnNextQuestion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // questionBox
            // 
            this.questionBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.questionBox.Location = new System.Drawing.Point(40, 71);
            this.questionBox.Name = "questionBox";
            this.questionBox.Size = new System.Drawing.Size(723, 58);
            this.questionBox.TabIndex = 6;
            this.questionBox.Text = "Question";
            // 
            // scoreBox
            // 
            this.scoreBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreBox.Location = new System.Drawing.Point(549, 353);
            this.scoreBox.Name = "scoreBox";
            this.scoreBox.Size = new System.Drawing.Size(214, 72);
            this.scoreBox.TabIndex = 8;
            this.scoreBox.Text = "Score";
            // 
            // btnReturnToMainMenu
            // 
            this.btnReturnToMainMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturnToMainMenu.Location = new System.Drawing.Point(40, 353);
            this.btnReturnToMainMenu.Name = "btnReturnToMainMenu";
            this.btnReturnToMainMenu.Size = new System.Drawing.Size(190, 72);
            this.btnReturnToMainMenu.TabIndex = 10;
            this.btnReturnToMainMenu.Text = "Main Menu";
            this.btnReturnToMainMenu.UseVisualStyleBackColor = true;
            this.btnReturnToMainMenu.Click += new System.EventHandler(this.btnReturnToMainMenu_Click);
            // 
            // answerA
            // 
            this.answerA.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.answerA.Location = new System.Drawing.Point(40, 151);
            this.answerA.Name = "answerA";
            this.answerA.Size = new System.Drawing.Size(345, 72);
            this.answerA.TabIndex = 11;
            this.answerA.Text = "A";
            this.answerA.UseVisualStyleBackColor = true;
            this.answerA.Click += new System.EventHandler(this.answerA_Click);
            // 
            // answerB
            // 
            this.answerB.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.answerB.Location = new System.Drawing.Point(418, 151);
            this.answerB.Name = "answerB";
            this.answerB.Size = new System.Drawing.Size(345, 72);
            this.answerB.TabIndex = 12;
            this.answerB.Text = "B";
            this.answerB.UseVisualStyleBackColor = true;
            this.answerB.Click += new System.EventHandler(this.answerB_Click);
            // 
            // answerC
            // 
            this.answerC.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.answerC.Location = new System.Drawing.Point(40, 253);
            this.answerC.Name = "answerC";
            this.answerC.Size = new System.Drawing.Size(345, 72);
            this.answerC.TabIndex = 13;
            this.answerC.Text = "C";
            this.answerC.UseVisualStyleBackColor = true;
            this.answerC.Click += new System.EventHandler(this.answerC_Click);
            // 
            // answerD
            // 
            this.answerD.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.answerD.Location = new System.Drawing.Point(418, 253);
            this.answerD.Name = "answerD";
            this.answerD.Size = new System.Drawing.Size(345, 72);
            this.answerD.TabIndex = 14;
            this.answerD.Text = "D";
            this.answerD.UseVisualStyleBackColor = true;
            this.answerD.Click += new System.EventHandler(this.answerD_Click);
            // 
            // questionNumberBox
            // 
            this.questionNumberBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.questionNumberBox.Location = new System.Drawing.Point(40, 12);
            this.questionNumberBox.Name = "questionNumberBox";
            this.questionNumberBox.Size = new System.Drawing.Size(251, 38);
            this.questionNumberBox.TabIndex = 15;
            this.questionNumberBox.Text = "Question/Total";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // timeBox
            // 
            this.timeBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeBox.Location = new System.Drawing.Point(563, 12);
            this.timeBox.Name = "timeBox";
            this.timeBox.Size = new System.Drawing.Size(200, 38);
            this.timeBox.TabIndex = 16;
            this.timeBox.Text = "time";
            // 
            // totalTimeBox
            // 
            this.totalTimeBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalTimeBox.Location = new System.Drawing.Point(341, 12);
            this.totalTimeBox.Name = "totalTimeBox";
            this.totalTimeBox.Size = new System.Drawing.Size(200, 38);
            this.totalTimeBox.TabIndex = 17;
            this.totalTimeBox.Text = "total time";
            // 
            // btnNextQuestion
            // 
            this.btnNextQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNextQuestion.Location = new System.Drawing.Point(301, 353);
            this.btnNextQuestion.Name = "btnNextQuestion";
            this.btnNextQuestion.Size = new System.Drawing.Size(190, 72);
            this.btnNextQuestion.TabIndex = 18;
            this.btnNextQuestion.Text = "Next ";
            this.btnNextQuestion.UseVisualStyleBackColor = true;
            this.btnNextQuestion.Click += new System.EventHandler(this.btnNextQuestion_Click);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnNextQuestion);
            this.Controls.Add(this.totalTimeBox);
            this.Controls.Add(this.timeBox);
            this.Controls.Add(this.questionNumberBox);
            this.Controls.Add(this.answerD);
            this.Controls.Add(this.answerC);
            this.Controls.Add(this.answerB);
            this.Controls.Add(this.answerA);
            this.Controls.Add(this.btnReturnToMainMenu);
            this.Controls.Add(this.scoreBox);
            this.Controls.Add(this.questionBox);
            this.Name = "MainPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Page";
            this.Load += new System.EventHandler(this.MainPage_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox questionBox;
        private System.Windows.Forms.RichTextBox scoreBox;
        private System.Windows.Forms.Button btnReturnToMainMenu;
        private System.Windows.Forms.Button answerA;
        private System.Windows.Forms.Button answerB;
        private System.Windows.Forms.Button answerC;
        private System.Windows.Forms.Button answerD;
        private System.Windows.Forms.RichTextBox questionNumberBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.RichTextBox timeBox;
        private System.Windows.Forms.RichTextBox totalTimeBox;
        private System.Windows.Forms.Button btnNextQuestion;
    }
}