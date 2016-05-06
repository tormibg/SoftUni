var app = app || {};

app.studentRequester = (function () {
    function WorkerRequester() {
        this.serviceUrl = app.requester.baseUrl +
            'appdata/' +
            app.requester.appId +
            '/workers';
    }

    WorkerRequester.prototype.getAllWorkers = function () {
        var defer = Q.defer();
        app.requester.makeRequest('GET', this.serviceUrl, null, true)
            .then(function (workers) {
                var result = {
                    workers: []
                };

                workers.forEach(function (worker) {
                    result.workers.push(new Worker(worker['Name'], worker['Job Title'], worker['Website']));
                });
                defer.resolve(result);
            }, function (error) {
                defer.reject(error);
            }).done();

        return defer.promise;
    };

    return WorkerRequester;
}());

