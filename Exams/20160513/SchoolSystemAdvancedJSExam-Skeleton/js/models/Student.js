var app = app || {};

(function (schoolSystem) {

    function Student(name) {
        schoolSystem._Human.call(this, name);
        this._grades = [];
    }

    Student.extends(schoolSystem._Human);

    Student.prototype.addGrade = function addGrade(grade) {
        schoolSystem.validator.validateConstructorNames(grade.constructor.name, 'Grade');
        this._grades.push(grade);
    };

    Student.prototype.getGrades = function getGrades() {
        return this._grades;
    };

    schoolSystem.Student = Student;
}(app));