'use strict';

angular.module('issueTracker.controllers.IssueController', [
        'issueTracker.services.issue',
        'issueTracker.services.identity',
        'issueTracker.services.projects',
        'ui-notification'])

    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/issues/:id', {
            templateUrl: 'app/views/issue.html',
            controller: 'IssueController'
        });
    }])

    .controller('IssueController', [
        '$scope',
        '$routeParams',
        'issue',
        'identity',
        'Notification',
        'projects',
        function ($scope, $routeParams, issue, identity, Notification, projects) {

            var id = $routeParams['id'];

            $scope.isAssignee = null;
            $scope.isIssueAuthor = null;
            $scope.newStatusId = undefined;
            $scope.isPrLead = undefined;

            function getIsueById() {
                issue.getIssueById(id).then(
                    function success(data) {
                        if (data.Assignee.Id === identity.getCurrentUser()) {
                            $scope.isAssignee = true;
                        }
                        if (data.Author.Id === identity.getCurrentUser()) {
                            $scope.isIssueAuthor = true;
                        }
                        $scope.issuesById = data;
                       /* console.log($scope.issuesById)*/
                        projects.getProjectById($scope.issuesById.Project.Id).then(
                            function success(project) {
                                $scope.priorities = project.Priorities;
                                if (project.Lead.Id === identity.getCurrentUser()) {
                                    $scope.isPrLead = true;
                                }
                                /*console.log(project);*/
                                /*console.log(project.Priorities)*/
                            }
                        )
                    }
                )
            }

            $scope.changeStatus = function () {
                /*console.log($scope.newStatusId.Id);*/
                issue.changeStatus($scope.issuesById.Id, $scope.newStatusId.Id).then(
                    function success(data) {
                        Notification.success("Status changed successfully!");
                        getIsueById();
                    })
            };

            getIsueById();
        }]);
