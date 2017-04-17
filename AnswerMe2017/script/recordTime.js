var minute = document.getElementById("timer_minute");
var second1 = document.getElementById("timer_second_01");
var second2 = document.getElementById("timer_second_02");

(function setTimer() {
    setInterval(function () { changeByTime(); }, 1000)
})();

function changeByTime() {
    var curMin = parseInt(minute.getAttribute("data-index"));
    var curs1 = parseInt(second1.getAttribute("data-index"));
    var curs2 = parseInt(second2.getAttribute("data-index"));

    curs2--;
    if (curs2 == -1) {
        curs2 = 9;
        curs1--;
        if (curs1 == -1) {
            curs1 = 5;
            curMin--;
            if (curMin == -1) {
                $("#finish").click();
                // document.getElementById("finish").onclick();
            }
        }
    }
    second2.setAttribute("data-index", curs2);
    second1.setAttribute("data-index", curs1);
    minute.setAttribute("data-index", curMin);
}

// var btn = document.getElementById("finish");
// var timeInput = document.getElementById("time-input");
// btn.onclick = function(e){
//     var curMin = parseInt(minute.getAttribute("data-index"));
//     var curs1 = parseInt(second1.getAttribute("data-index"));
//     var curs2 = parseInt(second2.getAttribute("data-index"));
//     timeInput.value = curMin + ':' + curs1 + curs2;
//     console.log(timeInput.value);
// }


