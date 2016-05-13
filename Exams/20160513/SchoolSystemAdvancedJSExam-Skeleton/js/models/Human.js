var app = app || {};

(function (schoolSystem) {
    function Human(name) {
        if (this.constructor === Event) {
            throw new ArgumentException("Can't instantiate abstract class!");
        }
        this.setName(name);
    }

    Human.prototype.setName = function setName(name) {
        schoolSystem.validator.validateString(name);
        return this._name = name;
    };

    Human.prototype.getName = function getName() {
        return this._name;
    };

    schoolSystem._Human = Human;
}(app));