$(document).ready(function () {
    var nextQuestionButton = document.getElementById('next-question-button'),
        questionArea = document.getElementById('question-area'),
        quizId = document.getElementById("quizid-holder"),
        currentQuestionId,
        sessionQuiz,
        questionCounter = 0,
        questNum = document.getElementById("quest-num"),
        questContent = document.getElementById("quest-content"),
        questAnswers = document.getElementById("quest-answers");

    getSessionQuiz();

    nextQuestionButton.addEventListener("click", function () {
        clearContent();
        displayQuestion();
    });

    function getSessionQuiz() {
        var callUrl = '/api/quizgame?id=' + quizId.innerText;
        $.getJSON(callUrl, function (data) {
            sessionQuiz = data;
            displayQuestion();
        });
    };

    var displayQuestion = function displayQuestion() {
        if (questionCounter >= sessionQuiz.Questions.length) {
            clearContent();
            questContent.innerText = "All Questions Have Been Asked";
            return;
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
        questionCounter++;
    }

    function isAnswerCorrect() {
        var callUrl = "/api/quizgame/isanswercorrect?answerId=" + this.id;
        element = document.getElementById(this.id);
        $.getJSON(callUrl, function (data) {
            element.style.backgroundColor = (data.IsCorrect === true) ? "#def0de" : "#f7dcdb";
        });
    }

    var clearContent = function clearContent() {
        questNum.innerText = "";
        questContent.innerText = "";
        questAnswers.innerHTML = " ";
    };

});