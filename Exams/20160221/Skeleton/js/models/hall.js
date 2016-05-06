var app = app || {};

(function (scope) {
    function Hall(name, capacity) {
        this._name = name;
        this._capacity = capacity;
        this.parties = [];
        this.lectures = [];
    }

    Hall.prototype.addEvent = function addEvent(title) {
        var typeOfTitle = title.getClass();
        if (typeOfTitle === 'Lecture') {
            this.lectures.push(title);
        } else if (typeOfTitle === 'Party') {
            this.parties.push(title);
        }
    }

    Hall.prototype.getCapacity = function getCapacity() {
        return this._capacity;
    }

    Hall.prototype.setCapacity = function setCapacity(capacity) {
        this._capacity = capacity;
    }

    Hall.prototype.getName = function getName() {
        return this._name;
    }

    Hall.prototype.setName = function setName(name) {
        this._name = name;
    }

    Hall.prototype.lectures = function lectures() {
        return this.lectures;
    }

    Hall.prototype.parties = function parties() {
        return this.parties;
    }

    scope.hall = function (name, capacity) {
        return new Hall(name, capacity);
    }
})(app);