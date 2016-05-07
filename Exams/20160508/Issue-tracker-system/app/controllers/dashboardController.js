"use strict";

angular.module('issueTracker.controllers.DashboardController', ['issueTracker.services.identity', 'issueTracker.services.projects'])
    .controller('DashboardController', [
        '$scope',
        'identity',
        'projects',
        function ($scope, identity, projects) {

            reloadProject();

            function reloadProject() {
                var userId = identity.getCurrentUser();
                projects.getProjects(userId).then(
                    function success(data){
                        $scope.myProjetcs = data;
                        /*console.log($scope.myProjetcs)*/
                    }
                )
            }
        }]);
