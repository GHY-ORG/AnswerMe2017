//$(document).ready(function () {
//    var sendData = {
//        count: 30
//    }

//    $.ajax({
//        method: "GET",
//        url: "api/question/choicequestion?count=" + 30,
//        contentType: "application/json",
//        dataType: "json",
//        data: JSON.stringify(sendData),
//        success: function (result) {
//            console.log(result);
//            if (result.IsSuccessful) {
//                var count = result.Body.length;
//                for (var i = 0; i < count; i++) {
//                    questions[i].setAttribute("ques-id", result.Body[i].Id);
//                    questions[i].childNodes[1].innerText = result.Body[i].Title;
//                    options[i * 4].parentNode.childNodes[3].innerText = result.Body[i].Options["A"];
//                    options[i * 4 + 1].parentNode.childNodes[3].innerText = result.Body[i].Options["B"];
//                    options[i * 4 + 2].parentNode.childNodes[3].innerText = result.Body[i].Options["C"];
//                    options[i * 4 + 3].parentNode.childNodes[3].innerText = result.Body[i].Options["D"];
//                }
//            } else {
//                alert("登录一下吧");
//            }
//        }
//    });
//})


//$("#finish").click(function () {
//    var curMin = parseInt(minute.getAttribute("data-index"));
//    var curs1 = parseInt(second1.getAttribute("data-index"));
//    var curs2 = parseInt(second2.getAttribute("data-index"));
//    var usetime = curMin * 60 + curs1 * 10 + curs2;
//    usetime = 300 - usetime;

//    var sendData = {
//        "AnswerList": [
//            {
//                "QuestionId": 1,
//                "AnswerBody": answers[0]
//            },
//            {
//                "QuestionId": 2,
//                "AnswerBody": answers[1]
//            },
//            {
//                "QuestionId": 3,
//                "AnswerBody": answers[2]
//            },
//            {
//                "QuestionId": 4,
//                "AnswerBody": answers[3]
//            },
//            {
//                "QuestionId": 5,
//                "AnswerBody": answers[4]
//            },
//            {
//                "QuestionId": 6,
//                "AnswerBody": answers[5]
//            },
//            {
//                "QuestionId": 7,
//                "AnswerBody": answers[6]
//            },
//            {
//                "QuestionId": 8,
//                "AnswerBody": answers[7]
//            },
//            {
//                "QuestionId": 9,
//                "AnswerBody": answers[8]
//            },
//            {
//                "QuestionId": 10,
//                "AnswerBody": answers[9]
//            },
//            {
//                "QuestionId": 11,
//                "AnswerBody": answers[10]
//            },
//            {
//                "QuestionId": 12,
//                "AnswerBody": answers[11]
//            },
//            {
//                "QuestionId": 13,
//                "AnswerBody": answers[12]
//            },
//            {
//                "QuestionId": 14,
//                "AnswerBody": answers[13]
//            },
//            {
//                "QuestionId": 15,
//                "AnswerBody": answers[14]
//            },
//            {
//                "QuestionId": 16,
//                "AnswerBody": answers[15]
//            },
//            {
//                "QuestionId": 17,
//                "AnswerBody": answers[16]
//            },
//            {
//                "QuestionId": 18,
//                "AnswerBody": answers[17]
//            },
//            {
//                "QuestionId": 19,
//                "AnswerBody": answers[18]
//            },
//            {
//                "QuestionId": 20,
//                "AnswerBody": answers[19]
//            },
//            {
//                "QuestionId": 21,
//                "AnswerBody": answers[20]
//            },
//            {
//                "QuestionId": 22,
//                "AnswerBody": answers[21]
//            },
//            {
//                "QuestionId": 23,
//                "AnswerBody": answers[22]
//            },
//            {
//                "QuestionId": 24,
//                "AnswerBody": answers[23]
//            },
//            {
//                "QuestionId": 25,
//                "AnswerBody": answers[24]
//            },
//            {
//                "QuestionId": 26,
//                "AnswerBody": answers[25]
//            },
//            {
//                "QuestionId": 27,
//                "AnswerBody": answers[26]
//            },
//            {
//                "QuestionId": 28,
//                "AnswerBody": answers[27]
//            },
//            {
//                "QuestionId": 29,
//                "AnswerBody": answers[28]
//            },
//            {
//                "QuestionId": 30,
//                "AnswerBody": answers[29]
//            }],
//        "UseTime": usetime
//    }

//    $.ajax({
//        method: "POST",
//        url: "api/question/answer",
//        contentType: "application/json",
//        dataType: "json",
//        data: JSON.stringify(sendData),
//        success: function (result) {
//            console.log("here");
//        }

//    })
    
//});
$(document).ready(function () {
    var sendData = {
        count: 30
    }

    $.ajax({
        method: "GET",
        url: "api/question/choicequestion?count=" + 30,
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
            setCookie("AnswerResult", JSON.stringify(result));
            $(window).attr("location", "result.html");
        }

    })
    return false;
});

function setCookie(c_name, value) {
    document.cookie = c_name + "=" + escape(value);
}
