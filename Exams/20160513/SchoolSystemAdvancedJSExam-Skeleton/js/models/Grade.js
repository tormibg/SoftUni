var app = app || {};

(function (schoolSystem) {

    function Grade(mark, subject, semester) {
        this.setMark(mark);
        this.setSubject(subject);
        this.setSemester(semester);
    }

    Grade.prototype.setMark = function setMark(mark) {
        schoolSystem.validator.validateNumber(mark);
        this._mark = mark;
    };


    Grade.prototype.getMark = function getMark() {
        return this._mark;
    };


    Grade.prototype.setSubject = function setSubject(subject) {
        schoolSystem.validator.validateSubject(subject);
        this._subject = subject;
    };


    Grade.prototype.getSubject = function getSubject() {
        return this._subject;
    };


    Grade.prototype.setSemester = function setSemester(semester) {
        schoolSystem.validator.validateConstructorNames(semester.constructor.name, 'Semester');
        this._semester = semester;
    };


    Grade.prototype.getSemester = function getSemester() {
        return this._semester;
    };


    schoolSystem.Grade = Grade;

}(app));