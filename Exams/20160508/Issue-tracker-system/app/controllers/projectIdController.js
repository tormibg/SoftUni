'use strict';

angular.module('issueTracker.controllers.ProjectIdController', ['issueTracker.services.projects', 'issueTracker.services.issue'])
    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/projects/:id', {
            templateUrl: 'app/views/project.html',
            controller: 'ProjectIdController'
        });
    }])

    .controller('ProjectIdController', [
        '$scope',
        '$routeParams',
        'projects',
        'issue',
        function ($scope, $routeParams, projects, issue) {

            $scope.issParams = {
                'pageNumber': 1,
                'pageSize': 5
            };

            var id = $routeParams['id'];

            function getProjectById() {
                projects.getProjectById(id).then(
                    function success(data) {
                        $scope.project = data;
                    }
                )
            }

            function getIsuesByProjectId() {
                issue.getIssuesByProjectId($scope.issParams, id).then(
                    function success(data) {
                        $scope.allIssuesByPrjId = data;
                        changePage();
                    }
                )
            }

            $scope.reloadIssues = function () {
                if (!$scope.allIssuesByPrjId) {
                    getIsuesByProjectId();
                } else {
                    changePage();
                }
            };

            function changePage() {
                var start = ($scope.issParams.pageNumber - 1) * $scope.issParams.pageSize;
                var end = $scope.issParams.pageNumber * $scope.issParams.pageSize;
                if (end > $scope.allIssuesByPrjId.length) {
                    end = $scope.allIssuesByPrjId.length;
                }
                $scope.paggedIssues = $scope.allIssuesByPrjId.slice(start, end);
            }

            getProjectById();
            getIsuesByProjectId();
        }]);
