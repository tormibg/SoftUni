(function () {
    require.config({
        paths: {
            'actor': 'models/actor',
            'genre': 'models/genre',
            'movie': 'models/movie',
            'review': 'models/review',
            'theatre': 'models/theatre',
            'generator': 'helpers/generator',
            'extensions': 'helpers/extensions',
            'loader': 'html-loader'
        }
    });
})();

require(['generator', 'loader'], function (imdb, loadHtml) {
    var genres;

    imdb.generateData();
    genres = imdb.getGenres();

    loadHtml('#genres', genres);
});


//(function (imdb) {
//	var genres;

//	imdb.generateData();
//	genres = imdb.getGenres();

//	imdb.loadHtml('#genres', genres);

//	// For testing
//	console.log(genres);
//}(imdb));