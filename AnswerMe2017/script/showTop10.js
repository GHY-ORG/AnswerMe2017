$(document).ready(function () {
    $.ajax({
        method: "GET",
        url: "api/user/top10",
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify(),
        success: function (result) {
            //console.log(result);
            updateTop10(result);
        }
    });

});

var top10Line = $(".rank-holder .line-title");
top10Line.splice(0, 1); // 删除首项

var updateTop10 = function (top10Result) {
    //console.log(top10Result);
    if (top10Result.IsSuccessful) {
        $(top10Result.Body).each(function (index, vaule) {
            var playName = vaule.Name;
            if( playName.length>5 ) playName = playName.substr(0,5)+"...";
            top10Line.children(".player")[index].innerHTML = playName + " " + vaule.StudentNumber.substr(0,2) + "****" + vaule.StudentNumber.substr(-2,2) || "匿名";
            top10Line.children(".accuracy")[index].innerHTML = vaule.Grade * 100 + "%";
            top10Line.children(".time")[index].innerHTML = parseInt(vaule.Time/60) + "分" + vaule.Time%60 + "秒" ;
        });
    }
}