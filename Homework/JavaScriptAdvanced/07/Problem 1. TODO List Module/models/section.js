define(['item'], function (Item) {

    return (function () {

        function Section(name) {
            if (!name) {
                throw new Error("Section name cannot be empty");
            }
            this._name = name;
            this._insideObj = new Item('inside');
        }

        Section.prototype.addNew = function (e) {
            var fromWho = e.target.parentNode,
                wrapper = document.querySelector('#insideWrapper'),
                name = fromWho.querySelector('input[id=groupName]').value,
                sectionObj = new Section(name),
                domSection = document.createElement('section'),
                listSection = document.createElement('section'),
                title = document.createElement('h2'),
                input = document.createElement('input'),
                button = document.createElement('button');

            //console.log(fromWho);
            listSection.className = 'listItems';
            title.innerText = name;
            input.placeholder = "task name";

            input.type = 'text';
            input.id = 'itemName';
            input.addEventListener("focus", function (event) {
                event.target.value = "";
            }, true);

            button.innerText = '+';
            button.name = 'addNewItem';
            button.addEventListener('click', sectionObj._insideObj.addNew);

            listSection.appendChild(title);
            domSection.appendChild(listSection);
            domSection.appendChild(input);
            domSection.appendChild(button);

            wrapper.appendChild(domSection);
        };

        return Section;
    })();
})