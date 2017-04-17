$(document).ready(function () {
    var sendData = {
        count: 15
    }

    $.ajax({
        method: "GET",
        url: "api/question/choicequestion?count=" + 15,
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify(sendData),
        success: function (result) {
            console.log(result);
            if (result.IsSuccessful) {
                var count = result.Body.length;
                for (var i = 0; i < count; i++) {
                    questions[i].setAttribute("ques-id", result.Body[i].Id);
                    questions[i].childNodes[1].innerText = result.Body[i].Title;
                    options[i * 4].parentNode.childNodes[3].innerText = result.Body[i].Options["A"];
                    options[i * 4 + 1].parentNode.childNodes[3].innerText = result.Body[i].Options["B"];
                    options[i * 4 + 2].parentNode.childNodes[3].innerText = result.Body[i].Options["C"];
                    options[i * 4 + 3].parentNode.childNodes[3].innerText = result.Body[i].Options["D"];
                }
            } else {
                alert("登录一下吧");
            }
        }
    });
})


$("#finish").click(function () {
    var curMin = parseInt(minute.getAttribute("data-index"));
    var curs1 = parseInt(second1.getAttribute("data-index"));
    var curs2 = parseInt(second2.getAttribute("data-index"));
    var usetime = curMin * 60 + curs1 * 10 + curs2;
    usetime = 300 - usetime;

    var sendData = {};


    sendData["AnswerList"] = [];
    $.each(questions, function (index, value) {
        sendData["AnswerList"].push({
            "QuestionId": questions[index].getAttribute("ques-id"),
            "AnswerBody": answers[index] || "E"
        });
    });
    sendData["UseTime"] = usetime || 9999;

    $.ajax({
        method: "POST",
        url: "api/question/answer",
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify(sendData),
        success: function (result) {
            console.log(result);
        }

    })
    return false;
});