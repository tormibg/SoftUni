var app = app || {};

(function (scope) {
    function Employee(name, workHours) {
        /*this._name = name;*/
        this.setName(name);
        /*this._workHours = workHours;*/
        this.setWorkhours(workHours);
    }

    Employee.prototype.getName = function getName() {
        return this._name;
    };

    Employee.prototype.setName = function setName(name) {
        var pat = /^[A-Za-z ]+$/g;
        if(pat.test(name)) {
            this._name = name;
        } else {
            throw new ArgumentException('letters and spaces only');
        }
    };

    Employee.prototype.getWorkhours = function getWorkhours() {
        return this._workHours;
    };

    Employee.prototype.setWorkhours = function setWorkhours(workHours) {
        if(typeof workHours === 'number') {
            this._workHours = workHours;
        } else {
            throw new ArgumentException('Number');
        }
    };

    scope.employee = Employee;

    /*scope.employee = function (name, workHours) {
        return new Employee(name, workHours);
    }*/
})(app);