var app = app || {};

(function (scope) {
    function Party(options) {
        scope._Event.call(this, options);
        this._isCatered = options.isCatered;
        this._isBirthday = options.isBirthday;
        this._organiser = options.organiser;
    }

    Party.extends(scope._Event);
    //checkIsBirthday, checkIsCatered

    Party.prototype.getOrganiser = function getOrganiser() {
        return this._organiser;
    }

    Party.prototype.setOrganiser = function setOrganiser(options) {
        this._organiser = options.organiser;
    }

    Party.prototype.checkIsBirthday = function checkIsBirthday() {
        return this._isBirthday;
    }

    Party.prototype.setIsBirthday = function setIsBirthday(options) {
        this._isBirthday = options.isBirthday;
    }

    Party.prototype.checkIsCatered = function checkIsCatered() {
        return this._isCatered;
    }

    Party.prototype.setIsCatered = function setIsCatered(options) {
        this._isCatered = options.isCatered;
    }

    Party.prototype.getClass = function () {
        return 'Party';
    }

    scope.party = function (options) {
        return new Party(options);
    }
})(app);