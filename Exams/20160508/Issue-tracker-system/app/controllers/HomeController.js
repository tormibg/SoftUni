angular.module('issueTracker.controllers', ['issueTracker.services', 'ui-notification'])
    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/', {
            templateUrl: 'app/views/home.html',
            controller: 'HomeController'
        })
    }])
    .controller('HomeController', [
        '$scope',
        'authentication',
        'Notification',
        function ($scope, authentication, Notification) {
            $scope.login = function (userData) {
                authentication.loginUser(userData).then(
                    function success(data){
                        authentication.getUser(data, data.access_token).then(
                            function success(responseData){
                                authentication.loggedUser(responseData);
                                Notification.success('User successfully logged in');
                            }
                        );
                    }
                )
            };

            $scope.register = function (userData) {
                authentication.registerUser(userData);
            };
        }]);
