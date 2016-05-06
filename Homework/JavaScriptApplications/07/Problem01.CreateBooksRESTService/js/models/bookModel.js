var app = app || {};

app.bookModel = (function () {
    function BookModel(requester) {
        this.requester = requester;
        this.serviceUrl = this.requester.baseUrl +
            'appdata/' +
            this.requester.appId +
            '/books';
    }

    BookModel.prototype.getAllBooks = function () {
        return this.requester.get(this.serviceUrl, true);
    };

    BookModel.prototype.addBook = function (data) {
        return this.requester.post(this.serviceUrl, data, true);
    };

    BookModel.prototype.delBook = function (data) {
        var serviceUrlforDelete = this.serviceUrl + '/' + data._id;
        return this.requester.del(serviceUrlforDelete, data, true);
    };

    BookModel.prototype.editBook = function (data) {
        var serviceUrlforDelete = this.serviceUrl + '/' + data._id;
        delete data._id;
        return this.requester.put(serviceUrlforDelete, data, true);
    };

    return {
        load: function (requester) {
            return new BookModel(requester);
        }
    }
}());

