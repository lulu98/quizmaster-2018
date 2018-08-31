using System;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Threading;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Quiz
{
    public partial class AddQuestion : Form
    {
        SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine();
        SpeechSynthesizer synthesizer = new SpeechSynthesizer();
        SqlConnection connection;
        string connectionString;

        Thread th;

        private void prepareSpeachRecognition()
        {
            Choices commands = new Choices();
            string[] actionCommands = { "main menu", "information", "stop audio", "submit" };

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

        void recEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            //action Commands entered manually
            switch (e.Result.Text)
            {
                case "main menu":
                    btnReturnToMainMenu_Click(btnReturnToMainMenu, EventArgs.Empty);
                    break;
                case "information":
                    btnInformation_Click(btnInformation, EventArgs.Empty);
                    break;
                case "stop audio":
                    synthesizer.SpeakAsyncCancelAll();
                    break;
                case "submit":
                    btnSubmit_Click(btnSubmit, EventArgs.Empty);
                    break;
                default:
                    break;
            }
        }

        public AddQuestion()
        {
            InitializeComponent();
            //connectionString = ConfigurationManager.ConnectionStrings["Quiz.Properties.Settings.QuizConnectionString"].ConnectionString;
            connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Projects\\Visual Studio\\Quiz\\Quiz\\Quiz.mdf;Integrated Security=True";
            prepareSpeachRecognition();
            synthesizer.SelectVoice("Microsoft Zira Desktop");
            this.Activate();
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

        private void btnInformation_Click(object sender, EventArgs e)
        {
            string informationString = "In this windows, you can add a new question to the quiz. Therefore, you need to write in the according" +
                " field the question, the 4 possible answers and the number of the correct answer. At the end you have to push the submit button" +
                " to submit the question to the database.";
            synthesizer.SpeakAsync(informationString);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO QuestionData VALUES (@question,@answerA,@answerB,@answerC,@answerD,@correctAnswer)";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@question", questionBox.Text);
                command.Parameters.AddWithValue("@answerA", answerABox.Text);
                command.Parameters.AddWithValue("@answerB", answerBBox.Text);
                command.Parameters.AddWithValue("@answerC", answerCBox.Text);
                command.Parameters.AddWithValue("@answerD", answerDBox.Text);
                command.Parameters.AddWithValue("@correctAnswer", int.Parse(correctAnswerBox.Text));
                command.ExecuteScalar();
            }
            
            synthesizer.SpeakAsyncCancelAll();
            th = new Thread(openStartPage);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            this.Close();
        }
        
    }
}
