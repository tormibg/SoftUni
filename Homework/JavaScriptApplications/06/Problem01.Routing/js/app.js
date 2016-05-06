var app = app || {};

(function () {
    app.router = Sammy(function () {
        var selector = '#greeting';

        this.get('#/', function () {
            welcomeHome(selector,'home');
        });

        this.get('#/:name', function () {
            welcomeHome(selector,this.params['name']);
        })
    });

    app.router.run('#/')
})();

function welcomeHome(selector, name) {
    $(selector).html('Welcome '+name);
};