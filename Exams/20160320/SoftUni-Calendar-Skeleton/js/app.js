var app = app || {};

(function () {

    app.router = Sammy(function () {
        var selector = '#container';
        var menuUser = 'templates/menu-home.html';
        var menuLogin = 'templates/menu-login.html';

        var requester = app._requester.load('kid_Z19UVhETJ-', 'f7008f7ee7ab4d10aa010b607fa50418', 'https://baas.kinvey.com/');

        var homeViewBag = app.homeViewBag.load();
        var userViewBag = app.userViewBag.load();
        var lectureViewBag = app.lectureViewBag.load();

        var userModel = app.userModel.load(requester);
        var lectureModel = app.lectureModel.load(requester);

        var homeController = app.homeController.load(homeViewBag);
        var userController = app.userController.load(userViewBag, userModel);
        var lectureController = app.lectureController.load(lectureViewBag, lectureModel);

        this.before({except: {path: '#\/(register\/|login\/)?'}}, function () {
            var userId = sessionStorage['userId'];
            if (!userId) {
                noty({
                    theme: 'relax',
                    text: 'You should be logged in to do this action!',
                    type: 'error',
                    timeout: 2000,
                    closeWith: ['click']
                });
                this.redirect('#/');
                return false;
            }
        });

        this.get('#/', function () {
            var userId = sessionStorage['userId'];
            if (!userId) {
                homeController.showWelcomeQuest(selector, menuLogin);
            } else {
                homeController.loadWelcomeUser(selector, menuUser);
            }
        });

        this.get('#/register/', function () {
            userController.loadRegisterScreen(selector);
        });

        this.get('#/login/', function () {
            userController.showLoginScreen(selector);
        });

        this.get('#/logout/', function () {
            userController.logout();
        });

        this.get('#/calendar/list/', function () {
            lectureController.loadAllLectures(selector, menuUser);
        });

        this.get('#/calendar/my/', function () {
            lectureController.loadMyLectures(selector, menuUser);
        });

        this.get('#/calendar/add/', function () {
            lectureController.loadAddLecture(selector);
        });


        this.bind('redirectUrl', function (ev, data) {
            this.redirect(data.url);
        });

        this.bind('register', function (ev, data) {
            userController.register(data);
        });

        this.bind('login', function (ev, data) {
            userController.login(data);
        });

        this.bind('addLecture', function (ev, data) {
            lectureController.addLecture(data);
        });

        this.bind('showEditLecture', function (ev, data) {
            lectureController.loadEditLecture(selector, data);
        });

        this.bind('editLecture', function (ev, data) {
            lectureController.editLecture(data);
        });

        this.bind('showDeleteLecture', function (ev, data) {
            lectureController.loadDeleteLecture(selector, data);
        });

        this.bind('deleteLecture', function (ev, data) {
            lectureController.deleteLecture(data._id);
        })

    });

    app.router.run('#/');
}());