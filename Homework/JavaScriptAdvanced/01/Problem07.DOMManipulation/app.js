(function () {
    'use strict';
    
    var domModule = (function () {
        
        var appendChild = function (element, child) {
            var el = document.querySelector(child);
            el.appendChild(element);
        };
        
        var removeChild = function (element, child) {
            var el = document.querySelector(element);
            var childForRemove = document.querySelector(child);
            el.removeChild(childForRemove);
        };
        
        var addHandler = function (element, evenType, even) {
            var el = document.querySelectorAll(element);
            for (var i = 0; i < el.length; i++) {
                el[i].addEventListener(evenType, even);
            };
        };
        
        var retrieveElements = function (element) {
            var el = document.querySelectorAll(element);
            return el;
        };
        
        return {
            appendChild: appendChild,
            removeChild: removeChild,
            addHandler: addHandler,
            retrieveElements: retrieveElements
        };

    })();
    
    
    var liElement = document.createElement("li");
    // Appends a list item to ul.birds-list
    domModule.appendChild(liElement, ".birds-list");
    // Removes the first li child from the bird list
    domModule.removeChild("ul.birds-list", "li:first-child");
    // Adds a click event to all bird list items
    domModule.addHandler("li.bird", 'click', function () { alert("I'm a bird!") });
    // Retrives all elements of class "bird"
    var elements = domModule.retrieveElements(".bird");
    console.log(elements);
})();