"use strict";

angular.module('issueTracker.controllers.HomeController', ['issueTracker.services', 'ui-notification', 'issueTracker.services.identity'])
    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/', {
            templateUrl: 'app/views/home.html',
            controller: 'HomeController'
        });
    }])
    .controller('HomeController', [
        '$scope',
        '$location',
        'authentication',
        'Notification',
        'identity',
        function ($scope, $location, authentication, Notification, identity) {

            $scope.login = function (userData) {
                authentication.loginUser(userData).then(
                    function success(data) {
                        identity.getUser(data, data.access_token).then(
                            function success(responseData) {
                                data.isAdmin = responseData.isAdmin;
                                data.Id = responseData.Id;
                                authentication.loggedUser(data);
                                Notification.success('User successfully logged in');
                                $location.path('/');
                            }
                        );
                    }
                )
            };

            $scope.register = function (userData) {
                authentication.registerUser(userData).then(
                    function success() {
                        var loginData = {
                            username: userData.Email,
                            password: userData.Password
                        };
                        authentication.loginUser(loginData).then(
                            function success(data) {
                                identity.getUser(data, data.access_token).then(
                                    function success(responseData) {
                                        authentication.loggedUser(responseData);
                                        Notification.success('User registered successfully');
                                    }
                                );
                            }
                        )
                    }
                )
            };

            $scope.isAuthenticated = function () {
                return authentication.isAuthenticated();
            };

            $scope.logout = function () {
                authentication.logoutUser().then(
                    function success(response) {
                        authentication.deleteLoggedUser();
                        Notification.success('User logout complete');
                        $location.path('/')
                    }
                )
            };

        }]);
