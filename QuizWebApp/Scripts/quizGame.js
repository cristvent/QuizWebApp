$(document).ready(function () {
    // Delcare needed variables
    var nextQuestionButton = document.getElementById('next-question-button'),
        lastQuestionButton = document.getElementById('last-question-button'),
        questionArea = document.getElementById('question-area'),
        quizId = document.getElementById("quizid-holder"),
        currentQuestionId,
        sessionQuiz,
        questionCounter = 0,
        questNum = document.getElementById("quest-num"),
        questContent = document.getElementById("quest-content"),
        questAnswers = document.getElementById("quest-answers");

    // Call function to get quiz from DB based on passed ID
    getSessionQuiz();

    // Event handler for next question button click
    nextQuestionButton.addEventListener("click", function () {
        clearContent();
        questionCounter++;
        if (questionCounter >= sessionQuiz.Questions.length) {
            clearContent();
            questContent.innerText = "All Questions Have Been Asked";
            questNum.innerText = "Done";
            nextQuestionButton.innerText = "Start Over";
            questionCounter = -1;
            return;
        }
        displayQuestion();
    });

    // Event handler for last question button click
    lastQuestionButton.addEventListener("click", function () {
        clearContent();
        questionCounter--;
        if (questionCounter < 0) {
            questionCounter = 0;
        }
        displayQuestion();
    })

    // Using AJAX to make a REST call. Getting the quiz, questions, and answers from DB.
    function getSessionQuiz() {
        var callUrl = '/api/quizgame?id=' + quizId.innerText;
        $.getJSON(callUrl, function (data) {
            sessionQuiz = data;
            displayQuestion();
        });
    };

    // Function to get content and holders ready to display
    var displayQuestion = function displayQuestion() {
        if (nextQuestionButton.innerText === "Start Over") {
            nextQuestionButton.innerText = "Next";
        }
        currentQuest = sessionQuiz.Questions[questionCounter];
        questContent.innerText = currentQuest.Content;
        questNum.innerText = "Question " + (questionCounter + 1);

        for (answer in currentQuest.Answers) {
            item = document.createElement("li");
            item.classList.add("list-group-item");
            item.innerText = currentQuest.Answers[answer].Content;
            item.id = currentQuest.Answers[answer].AnswerId;
            item.classList.add("game-answer");
            item.style.cursor = "pointer";
            item.addEventListener("click", isAnswerCorrect, false);
            questAnswers.appendChild(item);
        }
    }

    // Using AJAX to make a REST call. Checking the DB if clicked answer is correct
    function isAnswerCorrect() {
        var callUrl = "/api/quizgame/isanswercorrect?answerId=" + this.id;
        element = document.getElementById(this.id);
        $.getJSON(callUrl, function (data) {
            element.style.backgroundColor = (data.IsCorrect === true) ? "#def0de" : "#f7dcdb";
            if (data.IsCorrect === true) {

            }
        });
    }

    // Clear holders 
    var clearContent = function clearContent() {
        questNum.innerText = "";
        questContent.innerText = "";
        questAnswers.innerHTML = " ";
    };

});