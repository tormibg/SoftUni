var imdb = imdb || {};

(function (scope) {
    var id = 0;
    function Theatre(name, lenght, rating, country, isPuppet) {
        scope._Movie.call(this, name, lenght, country);
        this.isPuppet = isPuppet || false;
        this._id = ++id;
    }

    Theatre.extends(scope._Movie);

    scope.getTheatre = function (name, lenght, rating, country, isPuppet) {
        return new Theatre(name, lenght, rating, country, isPuppet);
    }

})(imdb);