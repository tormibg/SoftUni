define(['movie', 'extensions'], function (Movie) {
    return (function () {
        var id = 0;
        function Theatre(name, lenght, rating, country, isPuppet) {
            Movie.call(this, name, lenght, country);
            this.isPuppet = isPuppet || false;
            this._id = ++id;
        }

        Theatre.extends(Movie);


        return Theatre;

    })();
})