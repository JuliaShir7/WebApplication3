var checks = document.querySelectorAll(".check");
var checksd = document.querySelectorAll(".check_d");

var max = 3;
for (var i = 0; i < checks.length; i++)
    checks[i].onclick = selectiveCheck;

function selectiveCheck(event) {
    var checkedChecks = document.querySelectorAll(".check:checked");
    if (checkedChecks.length >= max + 1) {
        alert("Вы можете выбрать не более 3 объектов") 
        return false;
    }
}

var maxd = 3;
for (var i = 0; i < checksd.length; i++)
    checksd[i].onclick = selectiveCheckD;

function selectiveCheckD(event) {
    var checkedChecks = document.querySelectorAll(".check_d:checked");
    if (checkedChecks.length >= maxd + 1) {
        alert("Вы можете выбрать не более 3 объектов")
        return false;
    }
}