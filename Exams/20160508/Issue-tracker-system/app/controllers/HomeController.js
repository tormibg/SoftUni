angular.module('issueTracker.controllers', ['issueTracker.services'])
    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/', {
            templateUrl: 'app/views/home.html',
            controller: 'HomeController'
        })
    }])
    .controller('HomeController', [
        '$scope',
        'authentication',
        function ($scope, authentication) {
            $scope.login = function (userData) {
                authentication.loginUser(userData)
            };

            $scope.register = function (userData) {
                authentication.registeruser(userData);
            };
        }]);
