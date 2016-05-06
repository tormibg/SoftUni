$(function () {
    'use strict';
    var questions = [],
        timer = new Timer(300, '#timer', getResult),
        aButton = $('<button id="againButton" >Again ?</button>');

    questions[1] = {
        question: 'Cairo is the capital of which country?',
        answer1: 'Georgia',
        answer2: 'Haiti',
        answer3: 'Iceland',
        answer4: 'Egypt',
        answer: 4
    };

    questions[2] = {
        question: 'Zagreb is the capital of which country?',
        answer1: 'Croatia',
        answer2: 'Costa Rica',
        answer3: 'Estonia',
        answer4: 'Fiji',
        answer: 1
    };

    questions[3] = {
        question: 'Tbilisi is the capital of which country?',
        answer1: 'Georgia',
        answer2: 'Gabon',
        answer3: 'Guatemala',
        answer4: 'Indonesia',
        answer: 1
    };

    function showAnswers(answer, i) {
        var divAnswer = $('<p></p>')
        divAnswer.append('Your answer for question ' + i + ' is ' + answer)
        $(document.body).append(divAnswer);
    }

    function getResult() {
        timer.stop();
        $(':radio').prop('disabled',true);
        $('#subButton').prop('disabled',true);
        for (var i = 1; i <= 3; i++) {
            var answer;
            if (JSON.parse(localStorage.getItem('questions'))[i]['answered'] === JSON.parse(localStorage.getItem('questions'))[i]['answer']) {
                answer = 'correct';
            }
            else {
                answer = 'incorrect';
            }
            showAnswers(answer, i);
        }
        $(document.body).append(aButton);
        $('#againButton').click(clearFunc);
    }

    function clearFunc(){
        localStorage.clear();
        location.reload();
    }

    $('#subButton').click(getResult);

    if (!localStorage.getItem('questions')) {
        localStorage.setItem('questions', JSON.stringify(questions));
    }
    else {
        $(':radio').hide();
    }

    for (var question in questions) {
        if (questions.hasOwnProperty(question)) {
            var title = $('<p>' + questions[question]['question'] + '</p>');
            title.appendTo($('#wrapper'));
            for (var i = 1; i <= 4; i++) {
                var radio = $('<input type="radio" name="' + question + '" value="' + i + '" id="' + question + '' + i + '"/> ');
                radio.click(
                    function (event) {
                        var temp = JSON.parse(localStorage.getItem('questions'));
                        temp[event.target.name]['answered'] = Number(event.target.value);
                        localStorage.setItem('questions', JSON.stringify(temp));
                    }
                );
                var text = $('<span></span>');
                text.html(questions[question]['answer' + i]);
                radio.appendTo($('#wrapper'));
                text.appendTo($('#wrapper'));
            }
        }
    }

    if (!localStorage.getItem('questions')) {
        localStorage.setItem('questions', JSON.stringify(questions));
    }
    else {
        for (i = 1; i <= 3; i++) {
            if (JSON.parse(localStorage.getItem('questions'))[i]['answered'] !== undefined) {
                $('#' + i + '' + JSON.parse(localStorage.getItem('questions'))[i]['answered']).attr('checked', 'checked');
            }
        }
    }

    if (!sessionStorage.getItem('entered-time')) {
        sessionStorage.setItem('entered-time', new Date());
    }

    timer.start();
});