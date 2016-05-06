var app = app || {};

app.homeViewBag = (function () {
    function showWelcomeQuest(selector, menu) {
        $.get(menu, function (temp1) {
            $('#menu').html(temp1);
        });
        $.get('templates/welcome-guest.html', function (templ) {
            $(selector).html(templ);
        });
    }

    function showWelcomeUser(selector, data, menu) {
        $.get(menu, function (temp1) {
            $('#menu').html(temp1);
        });
        $.get('templates/welcome-user.html', function (templ) {
            var renderedData = Mustache.render(templ, data);
            $(selector).html(renderedData);
        })
    }

    return {
        load: function () {
            return {
                showWelcomeQuest: showWelcomeQuest,
                showWelcomeUser: showWelcomeUser
            }
        }
    }
}());