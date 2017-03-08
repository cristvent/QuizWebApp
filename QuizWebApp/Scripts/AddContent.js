$(document).ready(function () {
    var addContentButton = document.getElementById("add-content-button"),
        contentHolder = document.getElementById("question-holder"),
        addAnswerButton;

    var questionCounter = document.getElementById("question-count");
    var nextId = parseInt(questionCounter.innerText);

    var questionTemplate =
    '<div class="panel-heading question-heading">' +
    '<h5><strong> Question {{#}} </strong></h5>' +
    '</div>' +
    '<div id="question-body" class="panel-body">' +
    '<input type="text" id="Questions[{{~}}].Id" name="Questions[{{~}}].Id" value="{{~}}"class="hidden"/>' +
    '<input type="text" id="Questions[{{~}}].Content" name="Questions[{{~}}].Content" class="form-control question-content-input"/>' +
    '<a href="#{{~}}" data-toggle="collapse">Answers</a>' +
    '<div id="{{~}}" class="collapse answers-body">' +
    '<button type="button" class="btn btn-success btn-xs add-button" id="add-answer-button-{{~}}"> Add Answer </button>' +
    '</div>' +
    '</div>' +
    '</div>';

    var answerTemplate =
    '<div class="col-md-12 new-answer-holder">' +
    '<div class="col-md-8 answer-content-input">' +
    '<input type="text" id="{{~}}.Id" name="{{~}}.Id" class="hidden"/>' +
    '<input type="text" id="{{~}}.Content" name="{{~}}.Content" class="form-control"/>' +
    '</div>' +
    '<div class="col-md-4 answer-iscorrect-input">' +
    '<input type="checkbox" id="{{#}}.IsCorrect" name="{{#}}.IsCorrect" class="form-control edit-checkbox" value="true" />' +
    '<input type="hidden" id="{{#}}.IsCorrect" name="{{#}}.IsCorrect" class="form-control" value="false" />' +
    '</div>' +
    '</div>';

    addContentButton.addEventListener("click", function () {
        var questionTemp = questionTemplate.replace(/{{~}}/g, nextId).replace(/{{#}}/g, (nextId + 1));
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
        var tempWithReplaces = answerTemplate.replace(/{{~}}/g, "Questions[" + answerHolder.id + "].Answers[" + answerCounter + "]")
            .replace(/{{#}}/g, "Questions[" + answerHolder.id + "].Answers[" + answerCounter + "]");
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
