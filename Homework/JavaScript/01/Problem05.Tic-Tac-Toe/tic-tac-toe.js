
function winCheck(param) {
    if ($("#one").hasClass(param) && $("#two").hasClass(param) && $("#three").hasClass(param) || $("#four").hasClass(param) && $("#five").hasClass(param) && $("#six").hasClass(param) || $("#seven").hasClass(param) && $("#eight").hasClass(param) && $("#nine").hasClass(param) || $("#one").hasClass(param) && $("#four").hasClass(param) && $("#seven").hasClass(param) || $("#two").hasClass(param) && $("#five").hasClass(param) && $("#eight").hasClass(param) || $("#three").hasClass(param) && $("#six").hasClass(param) && $("#nine").hasClass(param) || $("#one").hasClass(param) && $("#five").hasClass(param) && $("#nine").hasClass(param) || $("#three").hasClass(param) && $("#five").hasClass(param) && $("#seven").hasClass(param)) {
        return true;
    } else {
        return false;
    }
};

function checkCombination(param) {
    if ($("#one").hasClass(param) && $("#two").hasClass(param) && $("#three").hasClass(param)) {
        $("#one").addClass("win");
        $("#two").addClass("win");
        $("#three").addClass("win");
        return;
    } else if ($("#four").hasClass(param) && $("#five").hasClass(param) && $("#six").hasClass(param)) {
        $("#four").addClass("win");
        $("#five").addClass("win");
        $("#six").addClass("win");
        return;
    } else if ($("#seven").hasClass(param) && $("#eight").hasClass(param) && $("#nine").hasClass(param)) {
        $("#seven").addClass("win");
        $("#eight").addClass("win");
        $("#nine").addClass("win");
        return;
    } else if ($("#one").hasClass(param) && $("#four").hasClass(param) && $("#seven").hasClass(param)) {
        $("#one").addClass("win");
        $("#four").addClass("win");
        $("#seven").addClass("win");
        return;
    } else if ($("#two").hasClass(param) && $("#five").hasClass(param) && $("#eight").hasClass(param)) {
        $("#two").addClass("win");
        $("#five").addClass("win");
        $("#eight").addClass("win");
        return;
    } else if ($("#three").hasClass(param) && $("#six").hasClass(param) && $("#nine").hasClass(param)) {
        $("#three").addClass("win");
        $("#six").addClass("win");
        $("#nine").addClass("win");
        return;
    } else if ($("#one").hasClass(param) && $("#five").hasClass(param) && $("#nine").hasClass(param)) {
        $("#one").addClass("win");
        $("#five").addClass("win");
        $("#nine").addClass("win");
        return;
    } else if ($("#three").hasClass(param) && $("#five").hasClass(param) && $("#seven").hasClass(param)) {
        $("#three").addClass("win");
        $("#five").addClass("win");
        $("#seven").addClass("win");
        return;
    }
};

$(document).ready(function () {
    var x = "x";
    var o = "o";
    var count = 0;
    $("#game li").click(function () {
        
        if ($(this).hasClass("disable")) {
            alert("Already selected");
        }
        else if (count % 2 === 0) {
            count++;
            $(this).text(o);
            $(this).addClass("disable o btn-primary");
            if (winCheck("o")) {
                checkCombination("o");
                alert("O wins");
                reset();
            } else if (count === 9) {
                alert("Its a tie. It will restart.");
                reset();
            }
        }
        else {
            count++;
            $(this).text(x);
            $(this).addClass("disable x btn-info");
            if (winCheck("x")) {
                checkCombination("x");
                alert("X wins");
                reset();
            }
            else if (count === 9) {
                alert("Its a tie. It will restart.");
                reset();
            }
        }

    });
    function reset() {
        $("#game li").text(" ");
        $("#game li").removeClass("disable");
        $("#game li").removeClass("o");
        $("#game li").removeClass("x");
        $("#game li").removeClass("btn-primary");
        $("#game li").removeClass("btn-info");
        $("#game li").removeClass("win");
        count = 0;
    };
});

