var app = app || {};

app.bookController = (function () {
    function BookController(model, viewBag,addBookViewBag) {
        this._model = model;
        this._viewBag = viewBag;
        this._addViewBag = addBookViewBag;
    }

    BookController.prototype.getAllBooks = function (selector, bookSelector) {
        var _this = this;

        this._model.getAllBooks()
            .then(function (books) {
                var result = {
                    books: []
                };

                books.forEach(function (book) {
                    result.books.push(new Book(book._id, book.title, book.author, book.isbn));
                });

                _this._viewBag.showBooks(selector, result, bookSelector)
                    .then(function (){
                        $("table").on('click', _this.captureClickOnBooks)});
            })
            .done();
    };

    BookController.prototype.captureClickOnBooks = function (e) {
        var buttonName = $(e.target).attr('name'),
            bookId = $(e.target).parent().attr('id');

        switch (buttonName) {
            case 'TR':
                $.sammy(function () {
                    var trData = {
                        _id: bookId,
                        title: $(e.target).parent().children(':nth-child(1)').text(),
                        author: $(e.target).parent().children(':nth-child(2)').text(),
                        isbn: $(e.target).parent().children(':nth-child(3)').text()
                    };
                    //debugger;
                    this.trigger('show-edit-book',trData);
                });
                break;
            case 'removeBookButton':
                $.sammy(function () {
                    this.trigger('delete-book',{_id: bookId});
                });
                break;
        }
    };

    BookController.prototype.editBook = function (data,selector,bookSelector) {
        var _this = this;

        this._model.editBook(data)
            .then(function () {
                _this.getAllBooks(selector, bookSelector);
            })
    };

    BookController.prototype.showEditBook = function(selector, data) {
        this._addViewBag.showEditBooks(selector, data);
    };

    BookController.prototype.deleteBook = function (data,selector,bookSelector){
        var _this = this;

        this._model.delBook(data)
            .then(function () {
                _this.getAllBooks(selector, bookSelector);
            })
    };

    BookController.prototype.addBook = function (data,selector,bookSelector) {
        var _this = this;

        this._model.addBook(data)
            .then(function () {
                _this.getAllBooks(selector, bookSelector);
            })
    };

    BookController.prototype.showAddBooks = function(selector) {
        this._addViewBag.showAddBooks(selector);
    };

    return {
        load: function (model, viewBag, addBookViewBag) {
            return new BookController(model, viewBag, addBookViewBag);
        }
    };
}());