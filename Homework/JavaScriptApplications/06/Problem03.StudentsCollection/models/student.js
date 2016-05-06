var Student = (function () {
    function Student(firstName, lastName, age, country) {
        this._fullName = firstName + ' ' + lastName;
        this._age = age;
        this._country = country;
    }

    return Student;
})();