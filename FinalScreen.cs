using System;
using System.Windows.Forms;
using System.Threading;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Configuration;
using System.Data.SqlClient;

namespace Quiz
{
    public partial class FinalScreen : Form
    {
        System.Globalization.CultureInfo myCulture = null;
        SpeechRecognitionEngine recEngine = null;
        //SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine();
        SpeechSynthesizer synthesizer = new SpeechSynthesizer();
        Thread th;
        SqlConnection connection;
        string connectionString;

        void recEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            //action Commands entered manually
            switch (e.Result.Text)
            {
                case "high score":
                    btnHighScore_Click(btnHighScore, EventArgs.Empty);
                    break;
                case "main menu":
                    btnReturnToMainMenu_Click(btnReturnToMainMenu, EventArgs.Empty);
                    break;
                case "play again":
                    btnPlayAgain_Click(btnPlayAgain, EventArgs.Empty);
                    break;
                default:
                    break;
            }
        }

        private void prepareSpeachRecognition()
        {
            Choices commands = new Choices();
            string[] actionCommands = { "main menu", "high score", "play again" };

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

        public FinalScreen()
        {
            InitializeComponent();
            myCulture = new System.Globalization.CultureInfo("en-US");
            recEngine = new SpeechRecognitionEngine(myCulture);
            connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Projects\\Visual Studio\\Quiz\\Quiz\\Quiz.mdf;Integrated Security=True";
            //connectionString = ConfigurationManager.ConnectionStrings["Quiz.Properties.Settings.QuizConnectionString"].ConnectionString;
            synthesizer.SelectVoice("Microsoft Zira Desktop");
            finalScoreBox.Text = "Final score: " + MainPage.score + " / " + MainPage.questionTotal + " in " + MainPage.totalTime + " seconds";
            string informationString = "You have achieved " + MainPage.score + " out of " + MainPage.questionTotal + " points in " + MainPage.totalTime + " seconds.";
            synthesizer.SpeakAsync(informationString);
            prepareSpeachRecognition();
        }

        private void openStartPage(object obj)
        {
            Application.Run(new StartPage());
        }

        private void btnReturnToMainMenu_Click(object sender, EventArgs e)
        {
            synthesizer.SpeakAsyncCancelAll();
            th = new Thread(openStartPage);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            this.Close();
        }

        private void openHighscoresPage(object obj)
        {
            Application.Run(new Highscores());
        }

        private void btnHighScore_Click(object sender, EventArgs e)
        {
            synthesizer.SpeakAsyncCancelAll();
            th = new Thread(openHighscoresPage);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            this.Close();
        }

        private void openMainPage(object obj)
        {
            Application.Run(new MainPage());
        }

        private void btnPlayAgain_Click(object sender, EventArgs e)
        {
            synthesizer.SpeakAsyncCancelAll();
            th = new Thread(openMainPage);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO HighScore VALUES (@score,@user,@time)";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@score", MainPage.score);
                command.Parameters.AddWithValue("@user", playerNameBox.Text);
                command.Parameters.AddWithValue("@time", MainPage.totalTime);
                command.ExecuteScalar();
            }
            playerNameBox.Text = "";

            synthesizer.SpeakAsyncCancelAll();
            th = new Thread(openStartPage);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            this.Close();
        }

        private void FinalScreen_Load(object sender, EventArgs e)
        {
            this.Activate();
        }
    }
}
