var ToDoList = (function () {
    var countItems = -2,
        Container,
        Section,
        Item;

    Container = (function () {
        function Container(name) {
            this._name = name;
            this._insideObj = new Section('inside');
        }

        return Container;
    })();

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
    };

    Section = (function () {
        function Section(name) {
            if (!name) {
                throw new Error("Section name cannot be empty");
            }
            this._name = name;
            this._insideObj = new Item('inside');
        }

        return Section;
    })();

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


    Item = (function () {
        function Item(name) {
            if (!name) {
                throw new Error("Item name cannot be empty");
            }
            this._name = name;
            countItems++;
        }

        return Item;
    })();

    Item.prototype.addNew = function (e) {
        var fromWho = e.target.parentNode,
            //console.log(fromWho);
            wrapper = fromWho.querySelector('.listItems'),
            name = fromWho.querySelector('input[id=itemName]').value,
            itemObj = new Item(name),
            domItem = document.createElement('div'),
            label = document.createElement('label'),
            checkbox = document.createElement('input');

        checkbox.type = 'checkbox';
        checkbox.id = 'ch-item-' + countItems;
        label.innerText = itemObj._name;
        label.htmlFor = checkbox.id;

        domItem.appendChild(checkbox);
        domItem.appendChild(label);

        wrapper.appendChild(domItem);
    };

    return { Container: Container };
})();
var todoList = new ToDoList.Container('Tuesday TODO List');
todoList.AddToDom();