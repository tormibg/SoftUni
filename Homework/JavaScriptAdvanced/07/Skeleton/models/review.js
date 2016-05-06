define([], function () {
    return (function () {
        var id = 0;
        function Review(author, content, date) {
            this.author = author;
            this.content = content;
            this.date = date;
            this._id = ++id;
        }

        return Review;

    })();
})