var app = app || {};

(function (scope) {
    function Lecture(options) {
        scope._Event.call(this, options);
        this._trainer = options.trainer;
        this._course = options.course;
    }

    Lecture.extends(scope._Event);

    Lecture.prototype.getCourse = function getCourse() {
        return this._course;
    }

    Lecture.prototype.setCourse = function setCourse(options) {
        this._course = options.course;
    }

    Lecture.prototype.getTrainer = function getTrainer() {
        return this._trainer;
    }

    Lecture.prototype.setTrainer = function setTrainer(options) {
        this._trainer = options.trainer;
    }

    Lecture.prototype.getClass = function () {
        return 'Lecture';
    }

    scope.lecture = function (options) {
        return new Lecture(options);
    }
})(app);