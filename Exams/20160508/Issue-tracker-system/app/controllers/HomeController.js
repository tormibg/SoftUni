angular.module('issueTracker.controllers', [])
    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/', {
            templateUrl: 'app/views/home.html',
            controller: 'HomeController'
        })
    }])
    .controller('HomeController', [
        '$scope',
        function($scope){
        $scope.login = function(userData){
            console.log(userData)
        }
    }]);
