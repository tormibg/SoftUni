var app = app || {};

app.userController = (function () {
    function UserController(viewBag, model) {
        this._model = model;
        this._viewBag = viewBag;
    }

    UserController.prototype.showLoginScreen = function (selector) {
        this._viewBag.showLoginScreen(selector);
    };

    UserController.prototype.login = function (data) {
        return this._model.login(data)
            .then(function (success) {
                noty({
                    theme: 'relax',
                    text: 'You have successfully logged in!',
                    type: 'success',
                    timeout: 2000,
                    closeWith: ['click']
                });
                sessionStorage['sessionId'] = success._kmd.authtoken;
                sessionStorage['username'] = success.username;
                sessionStorage['userId'] = success._id;

                Sammy(function () {
                    this.trigger('redirectUrl', {url: '#/'});
                });

            }, function (error) {
                noty({
                    theme: 'relax',
                    text: error.responseJSON.error || 'A problem occurred while signing in!',
                    type: 'error',
                    timeout: 2000,
                    closeWith: ['click']
                });
            }).done();
    };


    UserController.prototype.loadRegisterScreen = function (selector) {
        this._viewBag.showRegisterScreen(selector);
    };

    UserController.prototype.register = function (data) {
        return this._model.register(data)
            .then(function (success) {
                noty({
                    theme: 'relax',
                    text: 'You have successfully registered!',
                    type: 'success',
                    timeout: 2000,
                    closeWith: ['click']
                });

                sessionStorage['sessionId'] = success._kmd.authtoken;
                sessionStorage['username'] = success.username;
                sessionStorage['userId'] = success._id;

                Sammy(function () {
                    this.trigger('redirectUrl', {url: '#/'});
                });
            }, function (error) {
                noty({
                    theme: 'relax',
                    text: error.responseJSON.error || 'A problem occurred while trying to register!',
                    type: 'error',
                    timeout: 2000,
                    closeWith: ['click']
                });
            }).done();
    };

    UserController.prototype.logout = function () {
        this._model.logout()
            .then(function () {
                noty({
                    theme: 'relax',
                    text: 'You have successfully logged out!',
                    type: 'success',
                    timeout: 2000,
                    closeWith: ['click']
                });
                sessionStorage.clear();

                $.sammy(function () {
                    this.trigger('redirectUrl', {url: '#/'});
                });
            }, function(error) {
                noty({
                    theme: 'relax',
                    text: error.responseJSON.error || 'A problem occurred while signing out!',
                    type: 'error',
                    timeout: 2000,
                    closeWith: ['click']
                });
            }).done();
    };

    return {
        load: function (viewBag, model) {
            return new UserController(viewBag, model);
        }
    }
}());