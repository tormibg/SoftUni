var app = app || {};

(function (eventsSystem) {

    function Party(options) {
        eventsSystem._Event.call(this, options);
        /*this._isCatered = options.isCatered;*/
        this.setIsCatered(options.isCatered);
        /*this._isBirthday = options.isBirthday;*/
        this.setIsBirthday(options.isBirthday);
        /*this._organiser = options.organiser;*/
        this.setOrganiser(options.organiser);
    }

    Party.extends(eventsSystem._Event);
    //checkIsBirthday, checkIsCatered

    Party.prototype.getOrganiser = function getOrganiser() {
        return this._organiser;
    };

    Party.prototype.setOrganiser = function setOrganiser(employee) {
        if (employee instanceof app.employee) {
            this._organiser = employee;
        } else {
            throw new ArgumentException('Organiser');
        }
    };

    Party.prototype.checkIsBirthday = function checkIsBirthday() {
        return !!this._isBirthday;
    };

    Party.prototype.setIsBirthday = function setIsBirthday(value) {
        this._isBirthday = !!value;
    };

    Party.prototype.checkIsCatered = function checkIsCatered() {
        return !!this._isCatered;
    };

    Party.prototype.setIsCatered = function setIsCatered(value) {
        this._isCatered = !!value;
    };

    Party.prototype.getClass = function () {
        return 'Party';
    };

    eventsSystem.party = Party;

    /*scope.party = function (options) {
        return new Party(options);
    }*/
})(app);