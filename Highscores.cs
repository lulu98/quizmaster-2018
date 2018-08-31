using System;
using System.Windows.Forms;
using System.Threading;
using System.Speech.Recognition;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;

namespace Quiz
{
    public partial class Highscores : Form
    {
        SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine();
        Thread th;
        SqlConnection connection;
        string connectionString;

        void recEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            //action Commands entered manually
            switch (e.Result.Text)
            {
                case "main menu":
                    btnReturnToMainMenu_Click(btnReturnToMainMenu, EventArgs.Empty);
                    break;
                default:
                    break;
            }
        }

        private void prepareSpeachRecognition()
        {
            Choices commands = new Choices();
            string[] actionCommands = { "main menu"};

            // builds the grammar that will trigger the different commands by loading trigger sentences into the grammar
            commands.Add(actionCommands);
            GrammarBuilder gBuilder = new GrammarBuilder();
            gBuilder.Append(commands);
            Grammar grammar = new Grammar(gBuilder);

            recEngine.LoadGrammarAsync(grammar);
            recEngine.SetInputToDefaultAudioDevice();
            recEngine.SpeechRecognized += recEngine_SpeechRecognized;
            recEngine.RecognizeAsync(RecognizeMode.Multiple);
        }

        private void preparePage()
        {
            using (connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM HighScore", connection))
            {
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                List<string> highScoreData = new List<string>();
                DataRow maxRow = dataTable.Rows[0];
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    highScoreData.Add(dataRow["Score"].ToString() + " Points by " + dataRow["Player"].ToString() + " in " + dataRow["Time"].ToString() + " seconds");
                    if (int.Parse(dataRow["Score"].ToString()) > int.Parse(maxRow["Score"].ToString()))
                    {
                        maxRow = dataRow;
                    }
                }
                lstHighscores.DataSource = highScoreData;

                List<string> bestHighScore = new List<string>();
                bestHighScore.Add(maxRow["Score"] + " Points by " + maxRow["Player"] + " in " + maxRow["Time"] + " seconds") ;
                lstBestHighScore.DataSource = bestHighScore;

            }

        }

        public Highscores()
        {
            InitializeComponent();
            prepareSpeachRecognition();
            connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Projects\\Visual Studio\\Quiz\\Quiz\\Quiz.mdf;Integrated Security=True";
            //connectionString = ConfigurationManager.ConnectionStrings["Quiz.Properties.Settings.QuizConnectionString"].ConnectionString;
            preparePage();
            this.Activate();
        }

        private void openStartPage(object obj)
        {
            Application.Run(new StartPage());
        }

        private void btnReturnToMainMenu_Click(object sender, EventArgs e)
        {
            th = new Thread(openStartPage);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            this.Close();
        }

    }
}
