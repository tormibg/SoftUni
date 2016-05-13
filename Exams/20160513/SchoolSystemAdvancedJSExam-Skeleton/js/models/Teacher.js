var app = app || {};

(function (schoolSystem) {

    function Teacher(name, teachingSubject) {
        schoolSystem._Human.call(this, name);
        this.setTeachingSubject(teachingSubject);
    }

    Teacher.extends(schoolSystem._Human);

    Teacher.prototype.setTeachingSubject = function setTeachingSubject(teachingSubject) {
        if (teachingSubject) {
            schoolSystem.validator.validateSubject(teachingSubject);
            this._teachingSubject = teachingSubject;
        } else {
            this._teachingSubject = null;
        }
    };

    Teacher.prototype.getTeachingSubject = function getTeachingSubject() {
        return this._teachingSubject;
    };

    //(goshko, {mark: 5, subject: availableSubjects.MATH, semester: semester1})

    Teacher.prototype.addGradeToStudent = function addGradeToStudent(student, gradeParams) {

        schoolSystem.validator.validateConstructorNames(student.constructor.name, 'Student');

        var newSubject = undefined;

        if (gradeParams.subject) {
            newSubject = gradeParams.subject
        } else {
            newSubject = this.getTeachingSubject()
        }

        schoolSystem.validator.validateSubject(newSubject);
        schoolSystem.validator.validateNumber(gradeParams.mark);
        schoolSystem.validator.validateConstructorNames(gradeParams.semester.constructor.name, 'Semester');

        var grade = new schoolSystem.Grade(gradeParams.mark, newSubject, gradeParams.semester);

        student.addGrade(grade);

    };


    schoolSystem.Teacher = Teacher;
}(app));