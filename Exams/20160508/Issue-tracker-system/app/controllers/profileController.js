'use strict';

angular.module('issueTracker.controllers.ProfileController', [
        'ui.bootstrap.modal',
        'ui-notification',
        'issueTracker.services.identity'])

    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/profile/password', {
            title: "Profile",
            resolve: {
                showModal: ['$uibModal', '$route', function ($uibModal, $route) {
                    var modalInstance = $uibModal.open({
                        animation: true,
                        templateUrl: 'app/views/profile.html',
                        controller: 'ProfileController',
                    });
                }]
            }
        });
    }])
    .controller('ProfileController', [
        '$scope',
        '$uibModalInstance',
        '$location',
        'Notification',
        'identity',
        'authentication',
        function ($scope, $uibModalInstance, $location, Notification, identity, authentication) {

            $scope.UserData = {};

            function getCurrentUserName(){
                $scope.UserData.userName = identity.getCurrentUserName();
            }

            getCurrentUserName();


            $scope.changePassword = function(data){
                /*console.log(data);*/
                authentication.changePassword(data).then(
                    function success(data){
                        /*console.log(data);*/
                        $uibModalInstance.close();
                        $location.path('/');
                        Notification.success("Password changed !!!");
                    }
                )
            };

            $scope.cancel = function () {
                $uibModalInstance.dismiss('cancel');
                $location.path('/');
            };

        }]);