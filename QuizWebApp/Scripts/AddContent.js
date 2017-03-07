$(document).ready(function () {
    var addContentButton = document.getElementById("add-content-button"),
        contentHolder = document.getElementById("question-holder"),
        addAnswerButton,
        nextId = 0;

    var questionTemplate =
    '<div id="question-heading" class="panel-heading">' +
    '<h5> Question {{~}}</h5>' +
    '</div>' +
    '<div id="question-body" class="panel-body">' +
    '<input type="text" id="Questions[{{~}}].Content" name="Questions[{{~}}].Content" class="form-control"/>' +
    '<a href="#{{~}}" data-toggle="collapse">Q {{~}} - Answers</a>' +
    '<div id="{{~}}" class="collapse answers-body">' +
    '<button type="button" class="btn btn-success btn-xs" id="add-answer-button-{{~}}"> Add Answer </button>' +
    '</div>' +
    '</div>' +
    '</div>';

    var answerTemplate =
    '<div id="new-answer-holder" class="col-md-12">' +
    '<div class="col-md-8">' +
    '<input type="text" id="{{~}}" name="{{~}}" class="form-control"/>' +
    '</div>' +
    '<div class="col-md-4">' +
    '<input type="checkbox" id="{{#}}" name="{{#}}" class="form-control edit-checkbox" value="true" />' +
    '<input type="hidden" id="{{#}}" name="{{#}}" class="form-control" value="false" />' +
    '</div>' +
    '</div>';

    addContentButton.addEventListener("click", function () {
        var questionTemp = questionTemplate.replace(/{{~}}/g, nextId);
        var questionHolder = document.createElement("div");
        questionHolder.classList.add("panel");
        questionHolder.classList.add("panel-default");
        questionHolder.innerHTML = questionTemp;
        contentHolder.appendChild(questionHolder);
        addAnswerButton = document.getElementById("add-answer-button-" + nextId++);
        addAnswerButton.addEventListener('click', addAnswer, false);
    })

    var addAnswer = function addAnswer() {
        var answerHolder = document.getElementById(this.parentElement.id);
        var answerCounter = (answerHolder.childElementCount) - 1;
        var answerTemp = document.createElement("div");
        var tempWithReplaces = answerTemplate.replace(/{{~}}/g, "Questions[" + answerHolder.id + "].Answers[" + answerCounter + "].Content")
            .replace(/{{#}}/g, "Questions[" + answerHolder.id + "].Answers[" + answerCounter + "].IsCorrect");
        answerTemp.innerHTML = tempWithReplaces;
        answerHolder.appendChild(answerTemp);
    }

});


//'<div class="col-md-12">' +
//'<br />' +
//'<div class="col-md-6">' +
//'<input type="text" id="{{~}}" name="{{~}}" class="form-control"/>' +
//'</div>' +
//'<div class="col-md-6">' +
//'<input type="checkbox" id="{{~}}}" name="{{~}}" class="form-control edit-checkbox" value="true" checked />' +
//'<input type="hidden" id="{{~}}" name="{{~}}" class="form-control" value="false" />' +
//'</div>' +
//'</div>' +
