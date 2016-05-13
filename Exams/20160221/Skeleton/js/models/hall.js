var app = app || {};

(function (scope) {
    function Hall(name, capacity) {
        /*this._name = name;*/
        this.setName(name);
        /*this._capacity = capacity;*/
        this.setCapacity(capacity);
        this.parties = [];
        this.lectures = [];
    }

    Hall.prototype.addEvent = function addEvent(title) {
        /*var typeOfTitle = title.getClass();
         if (typeOfTitle === 'Lecture') {
         this.lectures.push(title);
         } else if (typeOfTitle === 'Party') {
         this.parties.push(title);
         }*/

        if (title instanceof scope.party) {
            this.parties.push(title);
        } else if (title instanceof scope.lecture) {
            this.lectures.push(title);
        } else {
            throw new ArgumentException('Event');
        }
    };

    Hall.prototype.getCapacity = function getCapacity() {
        return this._capacity;
    };

    Hall.prototype.setCapacity = function setCapacity(capacity) {
        if (typeof capacity === 'number') {
            this._capacity = capacity;
        } else {
            throw new ArgumentException('Number')
    }
    };

    Hall.prototype.getName = function getName() {
        return this._name;
    };

    Hall.prototype.setName = function setName(name) {
        var pat = /^[A-Za-z ]+$/g;
        if (pat.test(name)) {
            this._name = name;
        } else {
            throw new ArgumentException('letters and spaces only');
        }
    };

    Hall.prototype.lectures = function lectures() {
        return this.lectures;
    };

    Hall.prototype.parties = function parties() {
        return this.parties;
    };

    scope.hall = Hall;

    /*scope.hall = function (name, capacity) {
     return new Hall(name, capacity);
     }*/
})(app);