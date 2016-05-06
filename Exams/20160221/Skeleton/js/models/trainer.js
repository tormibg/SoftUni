var app = app || {};

(function (scope) {
    function Trainer(name, workHours) {
        scope._Employee.apply(this, arguments);
        this.courses = [];
        this.feedbacks = [];
    }

    Trainer.prototype = Object.create(scope._Employee.prototype);

    Trainer.prototype.addFeedback = function addFeedback(feedback) {
        this.feedbacks.push(feedback);
    }

    Trainer.prototype.addCourse = function addCourse(course) {
        this.courses.push(course);
    }

    scope.trainer = function (name, workHours) {
        return new Trainer(name, workHours);
    };
})(app);