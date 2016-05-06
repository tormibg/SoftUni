define(['section'], function (Section) {

    return (function () {

        function Container(name) {
            this._name = name;
            this._insideObj = new Section('inside');
        }

        Container.prototype.AddToDom = function () {
            var body = document.body,
                section = document.createElement('section'),
                title = document.createElement('h1'),
                insideSection = document.createElement('section'),
                input = document.createElement('input'),
                button = document.createElement('button');

            section.id = 'wrapper';

            title.innerText = this._name;

            insideSection.id = 'insideWrapper';

            input.type = 'text';
            input.id = 'groupName';
            input.value = '';
            input.placeholder = "tasks group name";
            //input.addEventListener("blur", function (event) {
            //    event.target.value = "";
            //}, true);
            input.addEventListener("focus", function (event) {
                event.target.value = "";
            }, true);

            button.innerText = 'New Group';
            button.name = 'addNewSection';
            button.addEventListener('click', this._insideObj.addNew);

            section.appendChild(title);
            section.appendChild(insideSection);
            section.appendChild(input);
            section.appendChild(button);

            body.appendChild(section);
        }

        return Container;

    })();
})