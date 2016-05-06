$(document).ready(function() {
    var index = 1;

    (function() {
        changeSlide('+');
        setTimeout(arguments.callee, 5000);
    })();

    function changeSlide(sign) {
        $('#slideShowWindow').css('background-image', "url('./pictures/" + index + ".jpg')");

        switch (sign) {
            case '+':
                index++;
                if (index > 6) {
                    index = 1;
                };
                break;
            case '-':
                index--;
                if (index < 1) {
                    index = 6;
                };
                break;
            default:
                break;
        }
    }

    (function clickedButton() {
        var leftArrow = $('#leftArrow').click(function() {
            changeSlide('-');
        });
        var rightArrow = $('#rightArrow').click(function() {
            changeSlide('+');
        });
    })();
});
