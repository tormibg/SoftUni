(function () {
    'use strict';

    var HTMLGen = (function () {
        var createParagraph,
            createDiv,
            createLink;

        createParagraph = function (id, text) {
            var el = document.getElementById(id),
                newEl = document.createElement('p');

            newEl.innerHTML = text;
            el.appendChild(newEl);
        };

        createDiv = function (id, classSection) {
            var el = document.getElementById(id),
                newEl = document.createElement('div');

            newEl.className = classSection;
            el.appendChild(newEl);
        };

        createLink = function (id, text, url) {
            var el = document.getElementById(id),
                newEl = document.createElement('a');

            newEl.text = text;
            newEl.href = url;
            el.appendChild(newEl);
        };

        return {
            createParagraph: createParagraph,
            createDiv: createDiv,
            createLink: createLink
        };

    })();

    HTMLGen.createParagraph('wrapper', 'Soft Uni');
    HTMLGen.createDiv('wrapper', 'section');
    HTMLGen.createLink('book', 'C# basics book', 'http://www.introprogramming.info/');
})();
