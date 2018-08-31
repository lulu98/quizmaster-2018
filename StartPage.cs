using System;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Threading;
using System.Speech.Synthesis;

namespace Quiz
{
    public partial class StartPage : Form
    {
        SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine();
        SpeechSynthesizer synthesizer = new SpeechSynthesizer();

        Thread th;

        public StartPage()
        {
            InitializeComponent();
            synthesizer.SelectVoice("Microsoft Zira Desktop");
            this.Activate();
        }

        private void StartPage_Load(object sender, EventArgs e)
        {
            prepareSpeachRecognition();
        }
        
        private void prepareSpeachRecognition()
        {
            Choices commands = new Choices();
            string[] actionCommands = { "start quiz", "high score", "close application", "information", "stop audio", "add question" };

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
                case "start quiz":
                    button1_Click(button1,EventArgs.Empty);
                    break;
                case "high score":
                    btnHighScore_Click(btnHighScore, EventArgs.Empty);
                    break;
                case "close application":
                    btnCloseApplication_Click(btnCloseApplication, EventArgs.Empty);
                    break;
                case "information":
                    btnInformation_Click(btnInformation, EventArgs.Empty);
                    break;
                case "stop audio":
                    synthesizer.SpeakAsyncCancelAll();
                    break;
                case "add question":
                    btnAddQuestion_Click(btnAddQuestion, EventArgs.Empty);
                    break;
                default:
                    break;
            }
        }

        private void openMainPage(object obj)
        {
            Application.Run(new MainPage());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            synthesizer.SpeakAsyncCancelAll();
            th = new Thread(openMainPage);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            this.Close();
        }

        private void openHighScores(object obj)
        {
            Application.Run(new Highscores());
        }

        private void btnHighScore_Click(object sender, EventArgs e)
        {
            synthesizer.SpeakAsyncCancelAll();
            th = new Thread(openHighScores);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            this.Close();
        }

        private void btnCloseApplication_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnInformation_Click(object sender, EventArgs e)
        {
            string informationString = "Hello I am the Quizmaster 2018, but my friends also call me Zira. You can control the buttons by either " +
                "your voice or by pushing them manually with the mouse. If you want to use voice control, just read the text that is written inside " +
                "the buttons. If you don't want to use voice control, then just press the buttons. You will be asked several questions. For each question " +
                "there are 4 possible answers. For the different answers, you can also just say A,B,C or D. Good luck!";
            synthesizer.SpeakAsync(informationString);
        }

        private void openAddQuestionPage(object obj)
        {
            Application.Run(new AddQuestion());
        }

        private void btnAddQuestion_Click(object sender, EventArgs e)
        {
            synthesizer.SpeakAsyncCancelAll();
            th = new Thread(openAddQuestionPage);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            this.Close();
        }
    }
}
