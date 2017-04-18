var questions = document.getElementsByClassName("question");
var prev = document.getElementById("prev");
var next = document.getElementById("next");
var queNumber = document.getElementsByClassName("number");
var cnt = 30;
var current = document.querySelector(".number-onshow");
var index = parseInt(current.childNodes[0].nodeValue);


for (var i = 1; i <= cnt; i++) {
    queNumber[i - 1].onclick = function () { changeTo(parseInt(this.childNodes[0].nodeValue)); }
}


prev.onclick = function (e) {
    if (index == 1) return;
    changeTo(index - 1);
}

next.onclick = function (e) {
    if (index == cnt) return;
    changeTo(index + 1);
}

function changeTo(now) {
    if (index == now) return;
    questions[now - 1].className = "question que-onshow";
    queNumber[now - 1].className = "number number-onshow";
    questions[index - 1].className = "question";
    queNumber[index - 1].className = "number";

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