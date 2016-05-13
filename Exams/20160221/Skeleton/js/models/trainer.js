var app = app || {};

(function (scope) {
    function Trainer(name, workHours) {
        scope.employee.apply(this, arguments);
        this.courses = [];
        this.feedbacks = [];
    }

    Trainer.prototype = Object.create(scope.employee.prototype);

    Trainer.prototype.addFeedback = function addFeedback(feedback) {
        this.feedbacks.push(feedback);
    };

    Trainer.prototype.addCourse = function addCourse(course) {
        this.courses.push(course);
    };

    scope.trainer = Trainer;

    /*scope.trainer = function (name, workHours) {
        return new Trainer(name, workHours);
    };*/
})(app);