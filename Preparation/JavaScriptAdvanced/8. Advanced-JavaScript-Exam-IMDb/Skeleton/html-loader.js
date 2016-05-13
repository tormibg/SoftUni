var imdb = imdb || {};

(function (scope) {
    function loadHtml(selector, data) {
        var container = document.querySelector(selector),
            moviesContainer = document.getElementById('movies'),
            detailsContainer = document.getElementById('details'),
            genresUl = loadGenres(data);

        container.appendChild(genresUl);

        genresUl.addEventListener('click', function (ev) {
            if (ev.target.tagName === 'LI') {
                var genreId,
                    genre,
                    moviesHtml;

                genreId = parseInt(ev.target.getAttribute('data-id'));
                genre = data.filter(function (genre) {
                    return genre._id === genreId;
                })[0];

                moviesHtml = loadMovies(genre.getMovies());
                moviesContainer.innerHTML = moviesHtml.outerHTML;
                moviesContainer.setAttribute('data-genre-id', genreId);

                var movieNodes = Array.prototype.slice.call(moviesContainer.firstElementChild.childNodes);

                movieNodes.forEach(function (node) {
                    node.addEventListener('click', function () {
                        //console.log(this.getAttribute('data-id'));

                        while (detailsContainer.firstChild) {
                            detailsContainer.removeChild(detailsContainer.firstChild);
                        }

                        var id = this.getAttribute('data-id'),
                            movie = genre.getMovies().filter(function (movie) {
                                return movie._id == id;
                            })[0],
                            actors = movie.getActors(),
                            reviews = movie.getReviews();

                        /// ACTORS !!!!
                        var actorsFragment = document.createDocumentFragment(),
                            actorsH3 = document.createElement('h3');

                        actorsH3.innerHTML = "Actors";
                        var actorsUl = document.createElement('ul');

                        actors.forEach(function (actor) {
                            var li = document.createElement('li');
                            var h4 = document.createElement('h4');
                            h4.innerHTML = actor.name;
                            var p = document.createElement('p');
                            p.innerHTML = '<strong>Bio: </strong>' + actor.bio + '<br/>' + '<strong>Born: </strong>' + actor.born;
                            li.appendChild(h4);
                            li.appendChild(p);
                            actorsUl.appendChild(li);
                        });

                        actorsFragment.appendChild(actorsH3);
                        actorsFragment.appendChild(actorsUl);

                        /// Review !!!!
                        var reviewFragment = document.createDocumentFragment(),
                            reviewH3 = document.createElement('h3');

                        reviewH3.innerHTML = "Reviews";
                        var reviewUl = document.createElement('ul');

                        reviews.forEach(function (review) {
                            var li = document.createElement('li');
                            var h4 = document.createElement('h4');
                            h4.innerHTML = review.author;
                            var p = document.createElement('p');
                            p.innerHTML = '<strong>Bio: </strong>' + review.content + '<br/>' + '<strong>Born: </strong>' + review.date;
                            var button = document.createElement('button');
                            button.value = 'Delete';
                            button.innerHTML = 'Delete Review';
                            button.addEventListener('click', function () {
                                movie.deteleReviewById(review._id);
                                reviewUl.removeChild(li);
                            });

                            li.appendChild(h4);
                            li.appendChild(p);
                            li.appendChild(button);
                            reviewUl.appendChild(li);
                        });

                        reviewFragment.appendChild(reviewH3);
                        reviewFragment.appendChild(reviewUl);

                        detailsContainer.appendChild(actorsFragment);
                        detailsContainer.appendChild(reviewFragment);
                    });
                });
            }
        });

        console.log(document.getElementById());

        // Task 3 - Add event listener for delete button (delete movie button or delete review button)
    }

    function loadGenres(genres) {
        var genresUl = document.createElement('ul');
        genresUl.setAttribute('class', 'nav navbar-nav');
        genres.forEach(function (genre) {
            var liGenre = document.createElement('li');
            liGenre.innerHTML = genre.name;
            liGenre.setAttribute('data-id', genre._id);
            genresUl.appendChild(liGenre);
        });

        return genresUl;
    }

    function loadMovies(movies) {
        var moviesUl = document.createElement('ul');
        movies.forEach(function (movie) {
            var liMovie = document.createElement('li');
            liMovie.setAttribute('data-id', movie._id);

            liMovie.innerHTML = '<h3>' + movie.title + '</h3>';
            liMovie.innerHTML += '<div>Country: ' + movie.country + '</div>';
            liMovie.innerHTML += '<div>Time: ' + movie.length + '</div>';
            liMovie.innerHTML += '<div>Rating: ' + movie.rating + '</div>';
            liMovie.innerHTML += '<div>Actors: ' + movie._actors.length + '</div>';
            liMovie.innerHTML += '<div>Reviews: ' + movie._reviews.length + '</div>';

            var button = document.createElement('button');
            button.value = 'Delete';
            button.innerHTML = 'Delete Movie';
            button.addEventListener('click', function () {
                console.log('delete');
            });

            liMovie.appendChild(button);

            moviesUl.appendChild(liMovie);
        });

        return moviesUl;
    }

    scope.loadHtml = loadHtml;
}(imdb));