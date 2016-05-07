"use strict";

angular.module('issueTracker.controllers.DashboardController', ['issueTracker.services.identity', 'issueTracker.services.projects'])
    .controller('DashboardController', [
        '$scope',
        'identity',
        'projects',
        function ($scope, identity, projects) {

            $scope.prjParams = {
                'pageNumber': 1,
                'pageSize': 5
            };

            reloadProject();

            function reloadProject() {
                var userId = identity.getCurrentUser();
                projects.getProjects($scope.prjParams, userId).then(
                    function success(data){
                        $scope.myProjetcs = data;
                        /*console.log($scope.myProjetcs)*/
                    }
                )
            }
        }]);
