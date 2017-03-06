$(document).ready(function () {
    var addContentButton = document.getElementById("add-content-button"),
        contentHolder = document.getElementById("question-holder"),
        addAnswerButton,
        nextId = 0;

    var questionTemplate =
    '<div class="panel-heading">' +
    '<h5> Question {{~}}</h5>' +
    '</div>' +
    '<div class="panel-body">' +
    '<input type="text" id="{{~}}" name="{{~}}" class="form-control"/>' +
    '<br />' +
    '<a href="#q{{~}}-answers" data-toggle="collapse">Q {{~}} - Answers</a>' +
    '<div id="q{{~}}-answers" class="collapse">' +
    '<br />' +
    '<button type="button" class="btn btn-success btn-xs" id="add-answer-button-{{~}}"> Add Answer </button>' +
    '<div class="col-md-12">' +
    '<br />' +
    '<div class="col-md-6">' +
    '<h5>Answer </h5>' +
    '</div>' +
    '<div class="col-md-6">' +
    '<h5> Is Correct </h5>' +
    '</div>' +
    '</div>' +
    '</div>' +
    '</div>';

    var answerTemplate =
    '<div class="col-md-12">' +
    '<br />' +
    '<div class="col-md-6">' +
    '<input type="text" id="{{~}}" name="{{~}}" class="form-control"/>' +
    '</div>' +
    '<div class="col-md-6">' +
    '<input type="checkbox" id="{{~}}}" name="{{~}}" class="form-control edit-checkbox" value="true" />' +
    '<input type="hidden" id="{{~}}" name="{{~}}" class="form-control" value="false" />' +
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
        //var questionTemp = answerTemplate.replace(/{{~}}/g, nextId++);
        var answerHolder = document.getElementById(this.parentElement.id);
        var answerTemp = document.createElement("div");
        answerTemp.innerHTML = answerTemplate;
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
