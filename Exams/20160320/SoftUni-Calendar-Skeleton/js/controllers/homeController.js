var app = app || {};

app.homeController = (function() {
    function HomeController(viewBag, model) {
        this._model = model;
        this._viewBag = viewBag;
    }

    HomeController.prototype.showWelcomeQuest = function(selector, menu) {
        this._viewBag.showWelcomeQuest(selector, menu);
    };

    HomeController.prototype.loadWelcomeUser = function(selector, menu) {
        var data = {
            fullName: sessionStorage['fullName'],
            username: sessionStorage['username']
        };

        this._viewBag.showWelcomeUser(selector, data, menu);
    };

    return {
        load: function(viewBag, model) {
            return new HomeController(viewBag, model);
        }
    }
}());