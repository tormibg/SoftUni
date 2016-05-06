'use strict';
function createParagraph(parrent, text) {
    var el = document.getElementById(parrent),
        newEl = document.createElement('p');

    newEl.innerHTML = text;
    el.appendChild(newEl);
}
createParagraph('wrapper', 'Some text');