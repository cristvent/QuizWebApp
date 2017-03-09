$(document).ready(function () {
    var addContentButton = document.getElementById("add-content-button"),
        contentHolder = document.getElementById("question-holder"),
        addAnswerButton;

    var questionCounter = document.getElementById("question-count");
    var nextId = parseInt(questionCounter.innerText);

    var questionTemplate =
    '<div class="panel-heading question-heading">' +
    '<strong> Question {{#}} </strong>' +
    '</div>' +
    '<div id="{{~}}" class="panel-body question-list">' +
    '<input type="text" id="Questions[{{~}}].Id" name="Questions[{{~}}].Id" value="{{~}}" class="hidden"/>' +
    '<input type="text" id="" name="" class="form-control question-content"/>' +
    '<a href="#drop{{~}}" data-toggle="collapse">Answers</a>' +
    '<div id="drop{{~}}" class="collapse answers-body">' +
    '<button type="button" class="btn btn-success btn-xs add-button" id="add-answer-button-{{~}}"> Add Answer </button>' +
    '</div>' +
    '</div>' +
    '</div>';

    var answerTemplate =
    '<div class="col-xs-12 new-answer-holder">' +
    '<button type="button" id="delete-this-{{#}}-{{~}}" class="btn btn-danger btn-xs delete-new-answer">x</button>' +
    '<div class="col-xs-8 answer-content-input">' +
    '<input type="text" id="" name="" class="hidden"/>' +
    '<input type="text" id="" name="" class="form-control content-{{#}}"/>' +
    '</div>' +
    '<div class="col-xs-1 answer-iscorrect-input">' +
    '<input type="checkbox" id="" name="" class="edit-checkbox is-correct-{{#}}" value="true" />' +
    '<input type="hidden" id="" name="" class="form-control" value="false" />' +
    '</div>' +
    '</div>';

    addContentButton.addEventListener("click", function () {
        var questionTemp = questionTemplate.replace(/{{~}}/g, nextId).replace(/{{#}}/g, (nextId + 1));
        var questionHolder = document.createElement("div");
        questionHolder.classList.add("panel");
        questionHolder.classList.add("panel-default");
        questionHolder.innerHTML = questionTemp;
        var allQuestions = document.getElementById("all-questions");
        allQuestions.appendChild(questionHolder);
        addAnswerButton = document.getElementById("add-answer-button-" + nextId++);
        addAnswerButton.addEventListener('click', addAnswer, false);
    })

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

    var deleteButton = document.getElementsByClassName("delete-current-answer");

    for (var x = 0 ; x < deleteButton.length; x++) {
        deleteButton[x].addEventListener("click", deleteThisCurrent, false);
    }

    function deleteThisCurrent() {
        var element = document.getElementById(this.id);
        element.parentElement.remove();
    }

    function deleteThisNew() {
        var element = document.getElementById(this.id);
        element.parentElement.parentElement.remove();
    }

    var assignId = document.getElementById("assign-id");

    assignId.addEventListener("click", function () {
        var holder = document.getElementsByClassName("question-list");
        var questionContent = document.getElementsByClassName("question-content");
        for (var x = 0; x < holder.length; x++) {
            var questionPosition = holder[x].id;
            questionContent[x].id = "Questions[" + x + "].Content";
            questionContent[x].name = "Questions[" + x + "].Content";

            var answersContent = document.getElementsByClassName("content-" + questionPosition);
            var answerIsCorrect = document.getElementsByClassName("is-correct-" + questionPosition);

            for (var i = 0; i < answersContent.length; i++) {
                answersContent[i].id = "Questions[" + x + "].Answers[" + i + "].Content";
                answersContent[i].name = "Questions[" + x + "].Answers[" + i + "].Content";
                answerIsCorrect[i].id = "Questions[" + x + "].Answers[" + i + "].IsCorrect";
                answerIsCorrect[i].name = "Questions[" + x + "].Answers[" + i + "].IsCorrect";
            }
        }

    })
});
