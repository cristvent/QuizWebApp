$(document).ready(function () {
    // Declared required variables 
    var addContentButton = document.getElementById("add-content-button"),
        contentHolder = document.getElementById("question-holder"),
        quizId = document.getElementById("quiz-id"),
        addAnswerButton;

    // Checked question count generated from DB. If none, start count at 1 since itll be the first question
    var questionCounter = document.getElementById("question-count");
    var nextId = parseInt(questionCounter.innerText);
    if (isNaN(nextId) === true) {
        nextId = 1;
    }

    // Question template to generate html for question holder (panel and dropdown)
    var questionTemplate =
    '<div class="panel-heading question-heading">' +
    '<strong> Question {{#}} </strong>' +
    '</div>' +
    '<div id="{{~}}" class="panel-body question-list">' +
    '<span class="hidden" id="question-count-db-{{~}}">0</span>' +
    '<input type="text" id="Questions[{{~}}].QuizId" name="Questions[{{~}}].QuizId" value="' + quizId.innerText + '" class="hidden"/>' +
    '<input type="text" id="" name="" class="form-control quest-input question-content-{{~}}"/>' +
    '<a href="#drop{{~}}" data-toggle="collapse">Answers</a>' +
    '<div id="drop{{~}}" class="collapse answers-body">' +
    '<button type="button" class="btn btn-success btn-xs add-button add-answer-button"> Add Answer </button>' +
    '</div>' +
    '</div>' +
    '</div>';

    // Answer template to generate html with required input and elements 
    var answerTemplate =
    '<div class="col-xs-12 new-answer-holder">' +
    '<button type="button" id="delete-this-{{#}}-{{~}}" class="btn btn-danger btn-xs delete-new-answer">x</button>' +
    '<div class="col-xs-8 answer-content-input">' +
    '<input type="text" id="" name="" class="hidden answer-question-id-{{#}}"/>' +
    '<input type="text" id="" name="" class="form-control content-{{#}}"/>' +
    '</div>' +
    '<div class="col-xs-1 answer-iscorrect-input">' +
    '<input type="checkbox" id="" name="" class="edit-checkbox is-correct-{{#}}" value="true" />' +
    '<input type="hidden" id="" name="" class="form-control" value="false" />' +
    '</div>' +
    '</div>';

    // Used question template to generate a new question holder
    addContentButton.addEventListener("click", function () {
        var questionTemp = questionTemplate.replace(/{{~}}/g, nextId).replace(/{{#}}/g, (nextId + 1));
        var questionHolder = document.createElement("div");
        questionHolder.classList.add("panel");
        questionHolder.classList.add("panel-default");
        questionHolder.innerHTML = questionTemp;
        var allQuestions = document.getElementById("all-questions");
        allQuestions.appendChild(questionHolder);
        var addAnswerButton = document.getElementsByClassName("add-answer-button");
        for (var x = 0; x < addAnswerButton.length; x++) {
            addAnswerButton[x].addEventListener('click', addAnswer, false);
        }
        nextId++;
    })

    // Used answer template to generate a new answer element.
    function addAnswer() {
        var answerHolder = document.getElementById(this.parentElement.id);
        var answerHolderCount = document.getElementById(answerHolder.parentElement.id)
        var answerCounter = (answerHolderCount.childElementCount) - 1;
        var answerTemp = document.createElement("div");
        var tempWithReplaces = answerTemplate.replace(/{{#}}/g, answerHolderCount.id).replace(/{{~}}/g, answerCounter);
        answerTemp.innerHTML = tempWithReplaces;
        answerHolder.appendChild(answerTemp);
        var deleteNewButtons = document.getElementsByClassName("delete-new-answer");
        for (var x = 0 ; x < deleteNewButtons.length; x++) {
            deleteNewButtons[x].addEventListener("click", deleteThisNew, false);
        }
    };

    // Added event listenr to add answer button, to add new answer
    var addAnswerButtons = document.getElementsByClassName("add-answer-button");
    for (var x = 0; x < addAnswerButtons.length; x++) {
        addAnswerButtons[x].addEventListener('click', addAnswer, false);
    }

    // Added event listeners to the delete button element attached to the content rendered.
    var deleteCurrentButton = document.getElementsByClassName("delete-current-answer");
    for (var x = 0 ; x < deleteCurrentButton.length; x++) {
        deleteCurrentButton[x].addEventListener("click", deleteThisCurrent, false);
    }

    // Hides and changes property value to flag answer as deleted. Appears deleted in the DOM. 
    function deleteThisCurrent() {
        this.children[0].value = "true";
        this.parentElement.classList.add("hidden");
    }

    // Deletes answer element created in session
    function deleteThisNew() {
        this.parentElement.remove();
    }

    var submitToDb = document.getElementById("submitToDb-Button");

    // Adding correct attributes and their values ** Pending code refactor
    submitToDb.addEventListener("click", function () {
        // Collecting a list of all the question holders
        var questionList = document.getElementsByClassName("question-list");

        // Loop through question holder list 
        for (var x = 0; x < questionList.length; x++) {

            // Get question element holder id
            var questionPosition = questionList[x].id;

            // Get question input element id and add attributes / values
            var questionContent = document.getElementsByClassName("question-content-" + questionPosition);
            questionContent[0].id = "Questions[" + x + "].Content";
            questionContent[0].name = "Questions[" + x + "].Content";

            // Get all question answers properties required for form collection 
            var answersContent = document.getElementsByClassName("content-" + questionPosition);
            var answerIsCorrect = document.getElementsByClassName("is-correct-" + questionPosition);
            var answerQuestionId = document.getElementsByClassName("answer-question-id-" + questionPosition);

            // Get answer count 
            var answersList = answersContent.length;
           
            // Loop through answer list and set each answers properties required for form collection
            for (var i = 0; i < answersList; i++) {
                answersContent[i].id = "Questions[" + x + "].Answers[" + i + "].Content";
                answersContent[i].name = "Questions[" + x + "].Answers[" + i + "].Content";
                answerIsCorrect[i].id = "Questions[" + x + "].Answers[" + i + "].IsCorrect";
                answerIsCorrect[i].name = "Questions[" + x + "].Answers[" + i + "].IsCorrect";
                answerQuestionId[i].name = "Questions[" + x + "].Answers[" + i + "].QuestionId";
                answerQuestionId[i].id = "Questions[" + x + "].Answers[" + i + "].QuestionId";
                var questIdInDatabase = document.getElementById("question-count-db-" + x).innerText;
                answerQuestionId[i].value = questIdInDatabase;
            }
        }

    })
});
