var app = app || {};

app.collectionRequester = (function (){
    function CollectionRequester(collection){
        this.serviceUrl = app.requester.baseUrl +
                        'appdata/' +
                        app.requester.appId +
                        '/' +
                        collection;
    }

    CollectionRequester.prototype.getAll = function(){
        return app.requester.makeRequest('GET', this.serviceUrl, null, true);
    };

    return CollectionRequester;
})();
