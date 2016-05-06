var app = app || {};

(function () {
    app.router = Sammy(function () {
        var selector = '#wrapper';
        var bookSelector = '#bookList'
        var requester = app.requester.config('kid_b1A0IeZGJW', '3e43f860bfde4a5586a1de06c1a97753');

        var userModel = app.userModel.load(requester);
        var bookModel = app.bookModel.load(requester);

        var homeViewBag = app.homeViews.load();
        var userViewBag = app.userViews.load();
        var bookViewBag = app.bookViews.load();
        var addBookViewBag = app.addBookViews.load();

        var homeControler = app.homeController.load(homeViewBag);
        var userController = app.userController.load(userModel, userViewBag);
        var bookController = app.bookController.load(bookModel, bookViewBag, addBookViewBag);

        this.before({except: {path: '#\/(login)?'}}, function () {
            var sessionId = sessionStorage['sessionAuth'];
            if (!sessionId) {
                this.redirect('#/login');
                return false;
            } else {
                this.redirect('#/books');
            }
        });

        this.get('#/', function () {
            homeControler.loadHomePage(selector);
        });

        this.get('#/login', function () {
            userController.loadLoginPage(selector);
        });

        this.get('#/books', function () {
            bookController.getAllBooks(selector, bookSelector);
        });

        /*this.get('#/login', function () {
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
         });*/

        this.get('#/logOut', function () {
            var _this = this;
            userController.logout()
                .then(function () {
                    _this.redirect('#/');
                })
        });

        this.bind('login', function (e, data) {
            userController.login(data)
        });

        this.bind('redirectUrl', function (e, data) {
            this.redirect(data.url);
        });

        this.bind('add-book', function (e, data) {
            bookController.addBook(data, selector, bookSelector);
        });

        this.bind('show-add-book', function (e) {
            bookController.showAddBooks(selector, bookSelector);
        });

        this.bind('delete-book', function (e, data) {
            bookController.deleteBook(data, selector, bookSelector);
        });

        this.bind('show-edit-book', function (e, data) {
            bookController.showEditBook(selector, data);
        });

        this.bind('edit-book', function (e, data) {
            bookController.editBook(data, selector, bookSelector);
        });

    });

    app.router.run('#/');
}());