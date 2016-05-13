var app = app || {};

(function (scope) {

    function Course(name, numberOfLectures) {
        /*this._name = name;*/
        this.setName(name);
        /*this._numberOfLectures = numberOfLectures;*/
        this.setNumberOfLectures(numberOfLectures);
    }

    Course.prototype.getName = function getName() {
        return this._name;
    };

    Course.prototype.setName = function setName(name) {
        var pat = /^[A-Za-z ]+$/g;
        if(pat.test(name)) {
            this._name = name;
        } else {
            throw new ArgumentException('letters and spaces only');
        }
    };

    Course.prototype.getNumberOfLectures = function getNumberOfLectures() {
        return this._numberOfLectures;
    };

    Course.prototype.setNumberOfLectures = function setNumberOfLectures(numberOfLectures) {
        if(typeof numberOfLectures === 'number') {
            this._numberOfLectures = numberOfLectures;
        } else {
            throw new ArgumentException('Number');
        }
    };

    scope.course = Course;

    /*scope.course = function (name, numberOfLectures) {
        return new Course(name, numberOfLectures);
    }*/
})(app);