var app = app || {};

app.userController = (function () {
    function UserController(model, viewBag) {
        var _this = this;
        this._model = model;
        this._viewBag = viewBag;

    }

    UserController.prototype.loadLoginPage = function(selector) {
        this._viewBag.showLoginPage(selector)
    };

    UserController.prototype.login = function(data) {
        var userOutputModel = {
            username: data.username,
            password: data.password
        };

        this._model.login(userOutputModel)
            .then(function (success) {
                sessionStorage['sessionAuth'] = success._kmd.authtoken;
                sessionStorage['userId'] = success._id;
                sessionStorage['fullName'] = success.fullName;
                sessionStorage['username'] = success.username;
                $.sammy(function () {
                    this.trigger('redirectUrl', {url:'#/home/'});
                })
            }).done()
    };

    UserController.prototype.loadRegisterPage = function(selector) {
        this._viewBag.showRegisterPage(selector)
    };

    UserController.prototype.register = function(data) {
        var userOutputModel = {
            username: data.username,
            password: data.password,
            fullName: data.fullName
        };

        this._model.register(userOutputModel)
            .then(function (success) {
                sessionStorage['sessionAuth'] = success._kmd.authtoken;
                sessionStorage['userId'] = success._id;
                sessionStorage['fullName'] = success.fullName;
                sessionStorage['username'] = success.username;
                $.sammy(function () {
                 this.trigger('redirectUrl', {url:'#/home/'});
                 })
            }).done()
    };

    UserController.prototype.logout = function() {
        this._model.logout()
            .then(function() {
                sessionStorage.clear();
                $.sammy(function () {
                    this.trigger('redirectUrl', {url:'#/'});
                })
            })
    };

    return {
        load: function (model, viewBag) {
            return new UserController(model, viewBag)
        }
    }
}());