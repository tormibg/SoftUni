'use strict';
// call onload or in script segment below form
function attachCheckboxHandlers() {
    // get reference to element containing toppings checkboxes
    var el = document.getElementById('button');

    el.onclick = validate;
}

function validateEmail(email) {
    var re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(email);
}

function validate(e) {
    var inputS = document.getElementById('text-input'),
        inputText = inputS.value.trim(),
        divS = document.getElementById('text-copy'),
        isMail = validateEmail(inputText);

    if (isMail) {
        divS.style.background = 'LightGreen';
    } else {
        divS.style.background = 'red';
    }
    divS.innerHTML = inputText;
}

attachCheckboxHandlers();