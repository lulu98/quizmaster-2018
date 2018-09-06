using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.Speech.Recognition;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Quiz
{
    public partial class MainPage : Form
    {
        //Global variables
        System.Globalization.CultureInfo myCulture = null;
        SpeechRecognitionEngine recEngine = null;
        //SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine();
        Thread th;
        SqlConnection connection;
        string connectionString;

        public static int score = 0;
        public static int questionCounter = 0;
        public static int questionTotal = 5;
        public static int totalTime = 0;
        const int maxTime = 30;
        int timeLeft = 0;
        int nextQuestion = 0;

        List<string> questions = new List<string>();
        List<string[]> answers = new List<string[]>();
        List<int> correctAnswers = new List<int>();
        //-------------------------------------------------------------------------

        private void basicVariableSetter()
        {
            score = 0;
            questionCounter = 0;
            questionTotal = 5;
        }

        private void setTimeProperties()
        {
            totalTime = 0;
            totalTimeBox.Text = "Total time: " + totalTime + " seconds";
            timeLeft = maxTime;
            timeBox.Text = "Time left: " + timeLeft + " seconds";
            timer1.Start();
        }

        private void simulateDatabase()
        {
            using (connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM QuestionData", connection))
            {
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                foreach (DataRow dataRow in dataTable.Rows)
                {
                    questions.Add(dataRow["Question"].ToString());
                    answers.Add(new string[] { dataRow["AnswerA"].ToString(), dataRow["AnswerB"].ToString(), dataRow["AnswerC"].ToString(), dataRow["AnswerD"].ToString() });
                    correctAnswers.Add(int.Parse(dataRow["CorrectAnswer"].ToString()));
                }
            }

        }

        private string[] constructTheCommands()
        {
            List<string> actionCommands = new List<string>();
            actionCommands.Add("a");
            actionCommands.Add("b");
            actionCommands.Add("c");
            actionCommands.Add("d");
            actionCommands.Add("main menu");
            actionCommands.Add("next");
            for (int i = 0; i < questions.Count; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    actionCommands.Add(answers[i][j]);
                }
            }
            return actionCommands.ToArray();
        }

        private void prepareSpeachRecognition()
        {
            Choices commands = new Choices();
            //string[] actionCommands = { "a", "b", "c", "d", "main menu", "next" };
            string[] actionCommands = constructTheCommands();
            // builds the grammar that will trigger the different commands by loading trigger sentences into the grammar
            commands.Add(actionCommands);
            GrammarBuilder gBuilder = new GrammarBuilder();
            gBuilder.Append(commands);
            gBuilder.Culture = myCulture;
            Grammar grammar = new Grammar(gBuilder);

            recEngine.LoadGrammarAsync(grammar);
            recEngine.SetInputToDefaultAudioDevice();
            recEngine.SpeechRecognized += recEngine_SpeechRecognized;
            recEngine.RecognizeAsync(RecognizeMode.Multiple);
        }

        void recEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            //action Commands entered manually
            switch (e.Result.Text)
            {
                case "a":
                    answerA_Click(answerA, EventArgs.Empty);
                    break;
                case "b":
                    answerB_Click(answerB, EventArgs.Empty);
                    break;
                case "c":
                    answerC_Click(answerC, EventArgs.Empty);
                    break;
                case "d":
                    answerD_Click(answerD, EventArgs.Empty);
                    break;
                case "main menu":
                    btnReturnToMainMenu_Click(btnReturnToMainMenu, EventArgs.Empty);
                    break;
                case "next":
                    btnNextQuestion_Click(btnNextQuestion, EventArgs.Empty);
                    break;
                default:
                    break;
            }
            if (e.Result.Text.Equals(answers[nextQuestion][0]))
            {
                answerA_Click(answerA, EventArgs.Empty);
            }
            else if (e.Result.Text.Equals(answers[nextQuestion][1]))
            {
                answerB_Click(answerB, EventArgs.Empty);
            }
            else if (e.Result.Text.Equals(answers[nextQuestion][2]))
            {
                answerC_Click(answerC, EventArgs.Empty);
            }
            else if (e.Result.Text.Equals(answers[nextQuestion][3]))
            {
                answerD_Click(answerD, EventArgs.Empty);
            }
        }

        public MainPage()
        {
            InitializeComponent();
            myCulture = new System.Globalization.CultureInfo("en-US");
            recEngine = new SpeechRecognitionEngine(myCulture);
            connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Projects\\Visual Studio\\Quiz\\Quiz\\Quiz.mdf;Integrated Security=True";
            //connectionString = ConfigurationManager.ConnectionStrings["Quiz.Properties.Settings.QuizConnectionString"].ConnectionString;
            basicVariableSetter();
            setTimeProperties();
            simulateDatabase();
            prepareSpeachRecognition();
        }

        private void UpdatePage()
        {
            questionCounter++;
            if (!isFinished())
            {
                Random rnd = new Random();
                nextQuestion = rnd.Next(0, questions.Count());
                questionBox.Text = questions[nextQuestion];
                answerA.Text = "A) " + answers[nextQuestion][0];
                answerB.Text = "B) " + answers[nextQuestion][1];
                answerC.Text = "C) " + answers[nextQuestion][2];
                answerD.Text = "D) " + answers[nextQuestion][3];

                questionNumberBox.Text = "Question: " + questionCounter + "/" + questionTotal;
                scoreBox.Text = "Score: " + score;

                timeLeft = maxTime;
                timeBox.Text = timeLeft + " seconds";
                timer1.Start();
            }
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            this.Activate();
            UpdatePage();
        }

        private bool isFinished()
        {
            if (questionCounter > questionTotal)
            {
                timer1.Stop();
                recEngine.RecognizeAsyncStop();
                FinalScreen newPage = new FinalScreen();
                newPage.Closed += (s, args) => this.Close();
                newPage.Show();
                this.Hide();
                return true;
            }
            else
            {
                return false;
            }
        }

        private void openStartPage(object obj)
        {
            Application.Run(new StartPage());
        }

        private void btnReturnToMainMenu_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            th = new Thread(openStartPage);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            this.Close();
        }

        private void answer_ClickEvent(int num)
        {
            if (num == correctAnswers[nextQuestion])
            {
                score++;
            }
            UpdatePage();
        }

        private void answerA_Click(object sender, EventArgs e)
        {
            answer_ClickEvent(1);
        }

        private void answerB_Click(object sender, EventArgs e)
        {
            answer_ClickEvent(2);
        }

        private void answerC_Click(object sender, EventArgs e)
        {
            answer_ClickEvent(3);
        }

        private void answerD_Click(object sender, EventArgs e)
        {
            answer_ClickEvent(4);
        }
        
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                // Display the new time left
                totalTime = totalTime + 1;
                totalTimeBox.Text = "Total time: " + totalTime + " seconds";
                timeLeft = timeLeft - 1;
                timeBox.Text = "Time left:" + timeLeft + " seconds";
            }
            else
            {
                timer1.Stop();
                //timeBox.Text = "Time's up!";
                //MessageBox.Show("You didn't finish in time.", "Sorry!");
                UpdatePage();
            }
        }

        private void btnNextQuestion_Click(object sender, EventArgs e)
        {
            UpdatePage();
        }
    }
}
