"use strict";

angular.module('issueTracker.controllers.DashboardController', ['issueTracker.services.identity', 'issueTracker.services.projects', 'issueTracker.services.issue'])
    .controller('DashboardController', [
        '$scope',
        'identity',
        'projects',
        'issue',
        function ($scope, identity, projects, issue) {

            $scope.prjParams = {
                'pageNumber': 1,
                'pageSize': 5
            };

            $scope.issParams = {
                'pageNumber': 1,
                'pageSize': 5
            };

            $scope.reloadDashboard = function () {
                reloadProject();
                reloadIssue();
            };

            $scope.reloadProject = function(){
                reloadProject();
            };

            $scope.reloadIssue = function(){
                reloadIssue();
            };

            $scope.reloadDashboard();

            function reloadProject() {
                var userId = identity.getCurrentUser();
                projects.getProjects($scope.prjParams, userId).then(
                    function success(data) {
                        $scope.myProjetcs = data;
                        /*console.log($scope.myProjetcs)*/
                    }
                )
            }

            function reloadIssue() {
                issue.getMyIssue($scope.issParams).then(
                    function success(data) {
                        $scope.myIssues = data;
                        /*console.log(data);*/
                    }
                )
            }
        }]);
