var app = app || {};

(function (schoolSystem) {

    function Semester(name) {
        this.setName(name);
    }

    Semester.prototype.setName = function setName(name) {
        schoolSystem.validator.validateString(name);
        return this._name = name;
    };

    Semester.prototype.getName = function getName() {
        return this._name;
    };


    schoolSystem.Semester = Semester;
}(app));