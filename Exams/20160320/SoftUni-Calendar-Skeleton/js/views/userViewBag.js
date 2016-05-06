var app = app || {};

app.userViewBag = (function () {
    function showLoginScreen(selector) {
        $.get('templates/login.html', function (templ) {
            $(selector).html(templ);
            $('#login-button').on('click', function () {

                var username = $('#username').val(),
                    password = $('#password').val();

                Sammy(function() {
                    this.trigger('login', {username: username, password: password});
                })
            })
        })
    }

    function showRegisterScreen(selector) {
        $.get('templates/register.html', function (templ) {
            $(selector).html(templ);
            $('#register-button').on('click', function () {
                var username = $('#username').val(),
                    password = $('#password').val(),
                    comfPass = $('#confirm-password').val();
                if (((!(!username)) && (!(!password)) && (!(!comfPass))) && (password === comfPass)) {
                    Sammy(function() {
                        this.trigger('register', {username: username, password: password});
                    })
                } else {
                    errorDispl()
                }
            })
        })
    }

    function errorDispl(){
        noty({
            theme: 'relax',
            text: 'Username,Password and Confirm password must not be EMPTY or Password and Confirm password must be equal!',
            type: 'error',
            timeout: 2000,
            closeWith: ['click']
        });
    }

    return {
        load: function () {
            return {
                showLoginScreen: showLoginScreen,
                showRegisterScreen: showRegisterScreen
            }
        }
    }
}());