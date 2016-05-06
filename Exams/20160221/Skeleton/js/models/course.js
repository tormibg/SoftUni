var app = app || {};

(function (scope) {
    function Course(name, numberOfLectures) {
        this._name = name;
        this._numberOfLectures = numberOfLectures;
    }

    Course.prototype.getName = function getName() {
        return this._name;
    };

    Course.prototype.setName = function setName(name) {
        this._name = name;
    };

    Course.prototype.getNumberOfLectures = function getNumberOfLectures() {
        return this._numberOfLectures;
    };

    Course.prototype.setNumberOfLectures = function setNumberOfLectures(numberOfLectures) {
        this._numberOfLectures = numberOfLectures;
    };

    scope.course = function (name, numberOfLectures) {
        return new Course(name, numberOfLectures);
    }
})(app);