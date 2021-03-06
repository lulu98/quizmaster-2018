# Quizmaster 2018
Demonstration video: http://www.lukas-graber.tk/projects/voice_controlled_quiz.html
## Introduction
This application is a quiz that you can control with either button pressing or by using your voice. 
## Technical aspects
The application uses two databases. One for the question data and the other for tracking the scores of the players. If you want to control the quiz with your voice, you can just read out the text that is written inside the buttons. It is possible that the application will not understand at the first try, so repeat yourself multiple times if it does not seem to understand you. 
## Starting Page
The starting page gives you one of several choices. The first option leads you directly to the main page / the quiz. The second option links to the highscore page. The third option lets you close the application. At the bottom left, you will get information read out to you, by the voice of Zira of Microsoft. At the bottom right, you can add a question and possible answers to the quiz. By reading out the text written on the buttons, you do the same procedure, as if you would have clicked the button.  
  
![alt text](https://github.com/lulu98/quizmaster-2018/blob/master/startPage.PNG)
## Main Page
On the main page, you can see at the top from left to right, the question counter field, the total time that you had played the quiz so far and the time left for this question. Afterwards you will be asked a question and four possible answers. At the bottom, you also have the option to return straight to the main menu or continue with the next question. At the bottom right, you also see your current score. If you want to use voice control, just read the text written on the buttons. For the possible answers, you can either read out the character or the real logical answer. Both will work!  
  
![alt text](https://github.com/lulu98/quizmaster-2018/blob/master/mainPage.PNG)
## Final Screen
In the final screen, you can see the score and time it took for you to complete the quiz. This information is spoken by Zira as soon as you enter the page. Aftwerwards, you can enter your name and submit the data to the high score database. The other options are returning to the main menu, play again or go to the highscore page.  
  
![alt text](https://github.com/lulu98/quizmaster-2018/blob/master/finalScreen.PNG)
## High Scores
In the high score page, you can see the best highscore ever achieved and just all the scores in the database. You can return to the main menu if you get bored by it.  
  
![alt text](https://github.com/lulu98/quizmaster-2018/blob/master/highScores.PNG)
## Add a new question
On this page, you can enter a new question, four possible answers and the index of the correct answer of those four. This information is passed to the database that holds the question data. By pressing the submit button, you enter the data in the database. The newly introduced question will be used randomly from now on in the quiz. Furthermore, you can return to the main menu or get information about the form. 
  
![alt text](https://github.com/lulu98/quizmaster-2018/blob/master/addNewQuestion.PNG)

## Future extensions
- fill the databases with many questions, so that it gets interesting  
- user login and database, for not entering manually the name and more interesting high score field  
- different topics like mathematics, History,... 
