var app = app || {};

app.bookViews = (function () {
    function showBooks(selector, data, bookSelector) {
        var defer = Q.defer();
        $.get('templates/books.html', function (templ) {
            var rendered = Mustache.render(templ, null);
            $(selector).html(rendered);

            data.books.forEach(function (book) {
                var $table = $(bookSelector),
                    $tr = $('<tr id="' + book['_id'] + '">'),
                    $td1 = $('<td name="TR" >' + book['_title'] + '</td>'),
                    $td2 = $('<td name="TR" >' + book['_author'] + '</td>'),
                    $td3 = $('<td name="TR" >' + book['_isbn'] + '</td>'),
                    //$span = $('<span>').text(book['_title']),
                    $td4 = $('<button name="removeBookButton" id="' + book['_id'] + '">').text('Remove');
                    //$editButton = $('<button name="editBookButton" _id="' + book['_id'] + '">').text('Edit');
                //$td.append($span).append($removeButton).append($editButton);
                //$td.append($span).append($removeButton);
                $tr.append($td1).append($td2).append($td3).append($td4);
                $table.append($tr);
            });

            $('.addBook').on('click', function () {

                $.sammy(function () {
                    this.trigger('show-add-book');
                });
            });
            defer.resolve(data);
        });
        return defer.promise;
    }

    return {
        load: function () {
            return {
                showBooks: showBooks
            }
        }
    }
}());