var app = app || {};

app.studentRequester = (function () {
    function StudentRequester() {
        this.serviceUrl = app.requester.baseUrl +
            'appdata/' +
            app.requester.appId +
            '/students';
    }

    StudentRequester.prototype.getAllStudents = function () {
        var defer = Q.defer();
        app.requester.makeRequest('GET', this.serviceUrl, null, true)
            .then(function (students) {
                var result = {
                    students: []
                };

                students.forEach(function (student) {
                    result.students.push(new Student(student['firstName'], student['lastName'], student['age'], student['country']));
                });
                //debugger;
                defer.resolve(result);
            }, function (error) {
                defer.reject(error);
            }).done();

        return defer.promise;
    };

    return StudentRequester;
}());

