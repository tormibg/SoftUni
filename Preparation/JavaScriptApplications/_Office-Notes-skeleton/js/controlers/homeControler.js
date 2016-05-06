var app = app || {};

app.homeController = (function() {
    function HomeController(viewBag) {
        this._viewBag = viewBag;
    }

    HomeController.prototype.loadWelcomePage = function(selector) {
        this._viewBag.showWelcomePage(selector);
    };

    HomeController.prototype.loadHomePage = function(selector) {
        var data = {
            fullName: sessionStorage['fullName'],
            username: sessionStorage['username']
        }
        this._viewBag.showHomePage(selector,data);
    };

    return {
        load: function (viewBag) {
            return new HomeController(viewBag);
        }
    }
}());