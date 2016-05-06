var app = app || {};

app.collectionRequester = (function () {
    function CollectionRequester(collection) {
        this.serviceUrl = app.requester.baseUrl +
            'appdata/' +
            app.requester.appId +
            '/';
    }

    CollectionRequester.prototype.getAll = function (collection) {
        var requestUrl = this.serviceUrl + collection;
        return app.requester.makeRequest('GET', requestUrl, null, true);
    };

    CollectionRequester.prototype.getWith = function (collection, column, value) {
            requestUrl = this.serviceUrl + collection + '?query={"' + column + '": "' + value + '"}';
       return app.requester.makeRequest('GET', requestUrl, null, true);
    };

    CollectionRequester.prototype.addToCollection = function (collection, data) {
        var defer = Q.defer(),
            requestUrl = this.serviceUrl + collection;

        app.requester.makeRequest('POST', requestUrl, data, true)
            .then(function (success) {
                defer.resolve();
            }, function (error) {
                defer.reject()
            }).done();

        return defer.promise;
    };

    CollectionRequester.prototype.deleteCollection = function (collection, id, data) {
        var defer = Q.defer(),
            requestUrl = this.serviceUrl + collection + '/' + id;

        app.requester.makeRequest('DELETE', requestUrl, data, true)
            .then(function(success){
                defer.resolve();
            }, function(error){
                console.error(error);
                defer.reject();
            }).done();

        return defer.promise;
    };

    CollectionRequester.prototype.editCollection = function(collection, id, data){
        var defer = Q.defer(),
            requestUrl = this.serviceUrl + collection + '/' + id;

        app.requester.makeRequest('PUT', requestUrl, data, true)
            .then(function(success){
                defer.resolve();
            }, function(error){
                console.error(error);
                defer.reject();
            }).done();

        return defer.promise;
    };

    return CollectionRequester;
})();
