var questions = document.getElementsByClassName("question");
var prev = document.getElementById("prev");
var next = document.getElementById("next");
var cnt = 30;
var index = 1;


prev.onclick = function (e) {
    if (index == 1) return;
    changeTo(index - 1);
}

next.onclick = function (e) {
    if (index == cnt) return;
    changeTo(index + 1);
}

function changeTo(now) {
    questions[now - 1].className = "question que-onshow";
    questions[index - 1].className = "question";

    index = now;
}

var btn = document.getElementById("finish");
var answerInput = document.getElementById("answer-input");
var options = document.getElementsByClassName("btnn");
var answers = new Array('E', 'E', 'E', 'E', 'E', 'E', 'E', 'E', 'E', 'E', 'E', 'E', 'E', 'E', 'E','E', 'E', 'E', 'E', 'E', 'E', 'E', 'E', 'E', 'E', 'E', 'E', 'E', 'E', 'E');

var len = options.length;
for (var i = 0; i < len; i++)
    options[i].onclick = function (e) {
        clearSibling(this.parentNode.parentNode);
        this.className = "btnn answer-on";
        var whichOpt = this.parentNode.getAttribute("answer-inde");
        var whichQue = parseInt(this.parentNode.parentNode.getAttribute("ques-index"));
        answers[whichQue - 1] = whichOpt;
    }

var timeInput = document.getElementById("time-input");

function clearSibling(currentP) {
    var active = currentP.getElementsByClassName("answer-on");
    if (active.length == 0) return;
    active[0].className = "btnn answer-off";
}