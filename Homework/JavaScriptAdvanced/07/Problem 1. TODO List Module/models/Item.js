define([], function () {

    return (function () {

        var countItems = -2;

        function Item(name) {
            if (!name) {
                throw new Error("Item name cannot be empty");
            }
            this._name = name;
            countItems++;
        }

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

        return Item;
    })();
})