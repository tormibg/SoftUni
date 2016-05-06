var app = app || {};

app.homeViewsBag = (function () {
    function showHomePage(selector, data) {
        $.get('templates/home.html', function (templ) {
            var rederedDate = Mustache.render(templ, data)
            $(selector).html(rederedDate);
        })
    }

    function showWelcomePage(selector) {
        $.get('templates/welcome.html', function (templ) {
            $(selector).html(templ);
        })
    }

    return {
        load: function () {
            return {
                showHomePage: showHomePage,
                showWelcomePage: showWelcomePage
            }
        }
    }
}());