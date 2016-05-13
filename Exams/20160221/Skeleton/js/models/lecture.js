var app = app || {};

(function (scope) {

    function Lecture(options) {
        scope._Event.call(this, options);
        /*this.trainer = options.trainer;*/
        this.setTrainer(options.trainer);
        /*this.course = options.course;*/
        this.setCourse(options.course);
    }

    Lecture.extends(scope._Event);

    Lecture.prototype.getCourse = function getCourse() {
        return this.course;
    };

    Lecture.prototype.setCourse = function setCourse(course) {
        if (course instanceof app.course) {
            this.course = course;
        } else {
            throw new ArgumentException('Course');
        }
    };

    Lecture.prototype.getTrainer = function getTrainer() {
        return this.trainer;
    };

    Lecture.prototype.setTrainer = function setTrainer(trainer) {
        if (trainer instanceof app.trainer) {
            this.trainer = trainer;
        } else {
            throw new ArgumentException('Trainer');
        }
    };

    Lecture.prototype.getClass = function () {
        return 'Lecture';
    };

    scope.lecture = Lecture;

    /*scope.lecture = function (options) {
        return new Lecture(options);
    }*/
})(app);