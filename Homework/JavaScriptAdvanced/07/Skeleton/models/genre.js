define([], function () {
    return (function () {
        var id = 0;
        function Genre(name) {
            this.name = name;
            this._movies = [];
            this._id = ++id;
        }

        Genre.prototype.addMovie = function (movie) {
            this._movies.push(movie);
        }

        Genre.prototype.deleteMovie = function (movie) {
            this._movies = this._movies.filter(function (curMovie) {
                return curMovie !== movie;
            });
        }

        Genre.prototype.deleteMovieById = function (id) {
            this._movies = this._movies.filter(function (movie) {
                return movie._id !== id;
            });
        }

        Genre.prototype.getMovies = function () {
            return this._movies;
        }


        return Genre;
 
    })();
})

