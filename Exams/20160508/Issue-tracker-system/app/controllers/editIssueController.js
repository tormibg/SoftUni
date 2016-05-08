'use strict';

angular.module('issueTracker.controllers.EditIssueController', [
        'issueTracker.services.issue',
        'issueTracker.services.identity',
        'issueTracker.services.users',
        'issueTracker.services.projects',
        'ui-notification'])

    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/issues/:id/edit', {
            templateUrl: 'app/views/edit-issue.html',
            controller: 'EditIssueController'
        });
    }])

    .controller('EditIssueController', [
        '$scope',
        '$routeParams',
        'issue',
        'identity',
        'Notification',
        'users',
        'projects',
        function ($scope, $routeParams, issue, identity, Notification, users, projects) {

            var id = $routeParams['id'];

            $scope.isAssignee = null;
            $scope.isPrjLeader = null;
            $scope.newStatusId = undefined;
            $scope.issuesById = {};

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
                        $scope.currentDueDate = new Date(data.DueDate);
                        /* console.log($scope.issuesById)*/
                        /*console.log($scope.issuesById.Project.Id)*/
                        projects.getProjectById($scope.issuesById.Project.Id).then(
                            function success(project) {
                                $scope.priorities = project.Priorities;
                                /*console.log(project.Priorities)*/
                            }
                        )
                    }
                )
            }

            $scope.saveIssue = function () {
                var changedIssue = {
                    Title: $scope.issuesById.Title,
                    Description: $scope.issuesById.Description,
                    DueDate: $scope.currentDueDate,
                    PriorityId: $scope.issuesById.Priority.Id.toString(),
                    AssigneeId: $scope.issuesById.Assignee.Id,
                    Labels: $scope.issuesById.Labels
                };
                issue.updateIssue($scope.issuesById.Id, changedIssue).then(
                    function success(data) {
                        $scope.reloadIssue();
                        Notification.success("Issue edited successfully!");
                    }
                )
            };


            users.getAll().then(
                function success(data) {
                    $scope.users = data;
                    /*console.log(data)*/
                });

            $scope.changeStatus = function () {
                /*console.log($scope.newStatusId.Id);*/
                issue.changeStatus($scope.issuesById.Id, $scope.newStatusId.Id).then(
                    function success(data) {
                        Notification.success("Status changed successfully!");
                        getIsueById();
                    })
            };

            //Datepicker
            $scope.today = function () {
                $scope.issuesById.DueDate = new Date();
            };
            $scope.today();

            $scope.openDatepicker = function () {
                $scope.datepicker.opened = true;
            };

            $scope.formats = ['dd-MMMM-yyyy', 'yyyy/MM/dd', 'dd.MM.yyyy', 'shortDate'];
            $scope.format = $scope.formats[0];
            $scope.altInputFormats = ['M!/d!/yyyy'];

            $scope.datepicker = {
                opened: false
            };

            $scope.dateOptions = {
                formatYear: 'yy',
                maxDate: new Date(2020, 5, 22),
                minDate: new Date(),
                startingDay: 1
            };

            getIsueById();

        }]);
