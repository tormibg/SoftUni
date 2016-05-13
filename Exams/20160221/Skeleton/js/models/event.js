var app = app || {};

(function (scope) {

    function Event(options) {
        if (this.constructor === Event) {
            throw new Error("Can't instantiate abstract class!");
        }
        /*this._title = options.title;*/
        this.setTitle(options.title);
        /*this._type = options.type;*/
        this.setType(options.type);
        /*this._duration = options.duration;*/
        this.setDuration(options.duration);
        this._date = options.date;
    }

    Event.prototype.setTitle = function (title) {
        var pat = /^[A-Za-z ]+$/g;
        if (pat.test(title)) {
            this._title = title;
        } else {
            throw new ArgumentException('letters and spaces only');
        }
    };

    Event.prototype.getTitle = function () {
        return this._title;
    };

    Event.prototype.setType = function (type) {
        var pat = /^[A-Za-z ]+$/g;
        if (pat.test(type)) {
            this._type = type;
        } else {
            throw new ArgumentException('letters and spaces only');
        }
    };

    Event.prototype.getType = function () {
        return this._type;
    };

    Event.prototype.setDuration = function (duration) {
        if (typeof duration === 'number') {
            this._duration = duration;
        } else {
            throw new ArgumentException('only numbers');
        }
    };

    Event.prototype.getDuration = function () {
        return this._duration;
    };

    Event.prototype.setDate = function(date) {
        if(date instanceof Date) {
            this._date = date;
        } else {
            throw new ArgumentException('Date');
        }
    };

    Event.prototype.getDate = function() {
        return this._date;
    };

    /*Event.prototype.getDate = function getDate() {
        var dd = this._date.getDate();
        var mm = this._date.getMonth() + 1; //January is 0!
        var yyyy = this._date.getFullYear();
        if (dd < 10) {
            dd = '0' + dd;
        }

        if (mm < 10) {
            mm = '0' + mm;
        }
        return (dd + '-' + mm + '-' + yyyy);
    }*/


    scope._Event = Event;
})(app);