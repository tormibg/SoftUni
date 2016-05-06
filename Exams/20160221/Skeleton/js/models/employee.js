var app = app || {};

(function (scope) {
    function Employee(name, workHours) {
        this._name = name;
        this._workHours = workHours;
    }

    Employee.prototype.getName = function getName() {
        return this._name;
    }

    Employee.prototype.setName = function setName(name) {
        this._name = name;
    }

    Employee.prototype.getWorkhours = function getWorkhours() {
        return this._workHours;
    }

    Employee.prototype.setWorkhours = function setWorkhours(workHours) {
        this._workHours = workHours;
    }

    scope._Employee = Employee;

    scope.employee = function (name, workHours) {
        return new Employee(name, workHours);
    }
})(app);