var imbd = imdb || {};

(function (scope) {
    var id = 0;
    function Movie(title, lenght, rating, country) {
        this.title = title;
        this.length = lenght;
        this.rating = rating;
        this.country = country;
        this._actors = [];
        this._reviews = [];
        this._id = ++id;
    }

    Movie.prototype.addActor = function (actor) {
        this._actors.push(actor);
    }

    Movie.prototype.getActors = function () {
        return this._actors;
    }

    Movie.prototype.addReview = function (review) {
        this._reviews.push(review);
    }

    Movie.prototype.getReviews = function () {
        return this._reviews;
    }

    Movie.prototype.deleteReview = function (review) {
        this._reviews = this._reviews.filter(function (curRev) {
            return curRev !== review;
        });
    }

    Movie.prototype.deteleReviewById = function (id) {
        this._reviews = this._reviews.filter(function (review) {
            return review._id !== id;
        });
    }

    scope._Movie = Movie;

    scope.getMovie = function (title, lenght, rating, country) {
        return new Movie(title, lenght, rating, country);
    }
})(imdb);