(function () {
    app.router = Sammy(function () {
        var selector = '#container';
        var notesPerPage = 10;
        var requester = app.requester.load('kid_b1A0IeZGJW', '3e43f860bfde4a5586a1de06c1a97753', 'https://baas.kinvey.com/');

        var userModel = app.userModel.load(requester);
        var notesModel = app.notesModel.load(requester);

        var userViewBag = app.userViewBag.load();
        var homeViewBag = app.homeViewsBag.load();
        var notesViewBag = app.notesViewsBag.load();

        var userController = app.userController.load(userModel, userViewBag);
        var homeControler = app.homeController.load(homeViewBag);
        var notesControler = app.notesController.load(notesModel, notesViewBag, notesPerPage);

        /*this.before({except: {path: '#\/(login\/|register\/)?'}}, function () {
            var sessionId = sessionStorage['sessionAuth'];
            if (!sessionId) {
                $('#menu').hide();
                this.redirect('#/login/');
                return false;
            }
        });*/

        this.before(function () {
            if (sessionStorage['sessionId']) {
                $('#welcomeMenu').text('Welcome' + sessionStorage['fullName']);
                $('#menu').show();
                /*title: data.title,
                text: data.text,
                    deadline: data.deadline,*/
                /*notesControler.addNote({title:title1,text:text1,deadline:'19-03-2016'})
                notesControler.addNote({title:title2,text:text2,deadline:'19-03-2016'})
                notesControler.addNote({title:title3,text:text3,deadline:'19-03-2016'})
                notesControler.addNote({title:title4,text:text4,deadline:'19-03-2016'})*/
            } else {
                $('#menu').hide();
            }
        });

        this.before({except: {path:'#\/(register\/|login\/)?'}}, function() {
            var userId = sessionStorage['userId'];
            if(!userId) {
                noty({
                    theme: 'relax',
                    text: 'You should be logged in to do this action!',
                    type:'error',
                    timeout: 2000,
                    closeWith: ['click']
                });
                this.redirect('#/');
                return false;
            } else {
                $('#menu').show();
            }
        });

        this.get('#/', function () {
            homeControler.loadWelcomePage(selector);
        });

        this.get('#/login/', function () {
            userController.loadLoginPage(selector);
        });

        this.get('#/register/', function () {
            userController.loadRegisterPage(selector);
        });

        this.get('#/home/', function () {
            homeControler.loadHomePage(selector);
        });

        this.get('#/logout/', function () {
            userController.logout()
        });

        /*this.get('#/office/', function () {
            notesControler.loadOfficeNotes(selector);
        });*/

        this.get('#/office/([-0-9]+)?', function () {
            var page = 1;

            if(this.params['splat'][0]){
                page = this.params['splat'][0];
            }

            notesControler.loadOfficeNotes(selector, page);
        });

        this.get('#/myNotes/', function () {
            notesControler.loadMyNotes(selector);
        });

        this.get('#/addNote/', function () {
            notesControler.loadAddNote(selector);
        });

        this.bind('redirectUrl', function (e, data) {
            this.redirect(data.url);
        });

        this.bind('register', function (e, data) {
            userController.register(data);
        });

        this.bind('login', function (e, data) {
            //var _this = this;
            userController.login(data);
                /*.then(function() {
                    _this.redirect('#/home/');
                }).done();*/
        });

        this.bind('addNote', function (e, data, selector) {
            notesControler.addNote(data);
        });

        this.bind('showEditNote', function (e, data) {
            notesControler.loadEditNote(selector, data);
        });

        this.bind('showDeleteNote', function (e, data) {
            notesControler.loadDeleteNote(selector, data);
        });

        this.bind('deleteNote', function (e, data) {
            notesControler.deleteNote(data);
        });

        this.bind('EditNote', function (e, data) {
            notesControler.editNote(data);
        });
    });

    app.router.run('#/');
}());