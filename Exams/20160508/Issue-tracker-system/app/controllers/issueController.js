'use strict';

angular.module('issueTracker.controllers.IssueController', [
        'issueTracker.services.issue',
        'issueTracker.services.identity',
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
        function ($scope, $routeParams, issue, identity, Notification) {

            var id = $routeParams['id'];

            $scope.isAssignee = null;
            $scope.isPrjLeader = null;
            $scope.newStatusId = undefined;

            function getIsueById() {
                issue.getIssueById(id).then(
                    function success(data) {
                        if (data.Assignee.Id === identity.getCurrentUser()) {
                            $scope.isAssignee = true;
                        }
                        if (data.Author.Id === identity.getCurrentUser()) {
                            $scope.isPrjLeader = true;
                        }
                        $scope.issuesById = data;
                       /* console.log($scope.issuesById)*/
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
