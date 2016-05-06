var app = app || {};

app.addBookViews = (function () {
    function showAddBooks(selector) {
        $.get('templates/addBook.html', function (templ) {
            var rendered = Mustache.render(templ, null);
            $(selector).html(rendered);

            $('.submit').on('click', function () {
                var newBook = {
                 title: $('#bookTitle').val(),
                 author: $('#bookAauthor').val(),
                 isbn: $('#bookIsbn').val()
                 };

                $.sammy(function () {
                    this.trigger('add-book',newBook);
                });
            })
        });
    }

    function showEditBooks(selector, data) {
        $.get('templates/editBook.html', function (templ) {
            //debugger;
            var rendered = Mustache.render(templ, data);
            $(selector).html(rendered);

            $('.submit').on('click', function () {
                var newBook = {
                    _id: $('#bookTitle').attr("_id"),
                    title: $('#bookTitle').val(),
                    author: $('#bookAauthor').val(),
                    isbn: $('#bookIsbn').val()
                };

                $.sammy(function () {
                    this.trigger('edit-book',newBook);
                });
            })
        });
    }

    return {
        load: function () {
            return {
                showAddBooks: showAddBooks,
                showEditBooks: showEditBooks
            }
        }
    }
}());