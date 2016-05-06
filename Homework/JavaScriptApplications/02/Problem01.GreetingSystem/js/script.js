$(function () {
    'use strict';
    var firstInput = $('<input id="nameInput" placeholder="Enter your name here"/>'),
        firstButton = $('<button id="submitButton">Submit</button>'),
        firstBlock = $('#first'),
        greetBlock = $('#greeting'),
        delButton = $('<button id="delButton">LogOut</button>'),
        clearButton = $('<button id="clearButton">Clear visits</button>'),
        newLine = '<br />',
        totalVisit,
        sessVisit;

    firstInput.on('input',changeInput);

    function changeInput(){
        firstButton.prop("disabled",false);
    }

    firstButton.prop("disabled",true);

    firstButton.on('click', firstButtonClick);

    function firstButtonClick() {
        var firstName = firstInput.val();
        if (!firstName) {
            alert("Please enter name !")
        }
        else
        {
            localStorage.setItem('firstName', firstName);
            firstBlock.hide();
            greetingUser()
        }
    }

    delButton.click(delButtonClick);

    function delButtonClick() {
        localStorage.removeItem('firstName');
        location.reload();
    }

    clearButton.click(clearButtonClick);

    function clearButtonClick() {
        localStorage.removeItem('localCountVisit');
        sessionStorage.removeItem('sessCountVisit');
        location.reload();
    }

    function greetingUser() {
        var userName = localStorage.getItem('firstName');
        greetBlock.text('Hello ' + userName);
        greetBlock.append(newLine);
        greetBlock.append(delButton);
    }

    function getNewVisit(storage) {
        var visits;
        if (storage === 'total') {
            visits = localStorage.getItem('localCountVisit');
            visits++;
            localStorage.setItem('localCountVisit', visits);
        } else {
            visits = sessionStorage.getItem('sessCountVisit');
            visits++;
            sessionStorage.setItem('sessCountVisit', visits);
        }
        return visits;
    }

    if (!localStorage.getItem('firstName')) {
        firstBlock.append(firstInput);
        firstBlock.append(firstButton);
    } else {
        greetingUser();
    }

    if (!localStorage.getItem('localCountVisit')) {
        localStorage.setItem('localCountVisit', 0)
    }

    if (!sessionStorage.getItem('sessCountVisit')) {
        sessionStorage.setItem('sessCountVisit', 0)
    }

    totalVisit = getNewVisit('total');
    sessVisit = getNewVisit('session');

    $(document.body).append("Session visit : " + sessVisit + newLine);
    $(document.body).append("Total visit : " + totalVisit + newLine);
    $(document.body).append(clearButton)
});
