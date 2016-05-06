var app = app || {};

(function (scope) {

    function Event(options) {
        if (this.constructor === Event) {
            throw new Error("Can't instantiate abstract class!");
        }
        this._title = options.title;
        this._type = options.type;
        this._duration = options.duration;
        this._date = options.date;
    }

    Event.prototype.getTitle = function getTitle() {
        return this._title;
    }

    Event.prototype.setTitle = function setTitle(options) {
        this._title = options.title;
    }

    Event.prototype.getDuration = function getDuration() {
        return this._duration;
    }

    Event.prototype.setDuration = function setDuration(options) {
        this._duration = options.duration;
    }

    Event.prototype.getDate = function getDate() {
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
    }

    Event.prototype.setDate = function setDate(options) {
        this._date = options.date;
    }

    scope._Event = Event;
})(app);