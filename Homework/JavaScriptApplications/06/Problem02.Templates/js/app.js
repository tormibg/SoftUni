var app = app || {};

(function () {
    app.router = Sammy(function () {
        var selector = '#wrapper';
        app.requester.config('kid_b1A0IeZGJW', '3e43f860bfde4a5586a1de06c1a97753');
        var userRequester = new app.UserRequester();
        var workerRequester = new app.studentRequester();

        this.before({except: {path: '#\/(login)?'}}, function () {
            var sessionId = sessionStorage['sessionAuth'];
            if (!sessionId) {
                this.redirect('#/login');
                return false;
            } else {
                this.redirect('#/getTable');
            }
        });

        this.get('#/', function () {
            $.get('templates/loginBtn.html', function (param) {
                $(selector).html(param);
            })
        });

        this.get('#/login', function () {
            var _this = this;
            $.get('templates/loginFrm.html', function (param) {
                $(selector).html(param);
                $('#login').on('click', function () {
                    var username = $('#username').val();
                    var password = $('#password').val();

                    userRequester.login('testuser', '1234')
                        .then(function () {
                            //console.log(this)
                            _this.redirect('#/getTable');
                        }, function (error) {
                            console.error(error);
                        })
                        .done();
                })
            })
        });

        this.get('#/getTable', function () {
            studentRequester.getAllWorkers()
                .then(function (success) {
                    $.get('templates/table.html', function (template) {
                        var options = {
                            'success': success,
                            'nameHeader': 'Name',
                            "ageHeader": 'Job Title',
                            "country": 'Website'
                        };
                        var htmlOutput = Mustache.render(template, options);
                        $(selector).html(htmlOutput);
                    })
                }, function (error) {
                    console.error(error);
                })
                .done();
        })

        this.get('#/logOut', function () {
            var _this = this;
            userRequester.logout()
                .then(function () {
                    _this.redirect('#/');
                })
        })
    });

    app.router.run('#/')
})();