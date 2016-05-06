'use strict';

function alphaAscending(a, b) {
    var textA = a.toLowerCase();
    var textB = b.toLowerCase();
    if (textA < textB) {
        return -1;
    } else if (textA > textB) {
        return 1;
    } else {
        return 0;
    };
};

function alphaDescending(a, b) {
    var textA = a.toLowerCase();
    var textB = b.toLowerCase();
    if (textA < textB) {
        return 1;
    } else if (textA > textB) {
        return -1;
    } else {
        return 0;
    };
};



function sortLetters(string, boolean){
    if (boolean) {
        string = string.split('').sort(alphaAscending).join('');
    } else {
        string = string.split('').sort(alphaDescending).join('');
    }
    return string;
};

var result = sortLetters('HelloWorld', true);
console.log(result);
result = sortLetters('HelloWorld', false);
console.log(result);