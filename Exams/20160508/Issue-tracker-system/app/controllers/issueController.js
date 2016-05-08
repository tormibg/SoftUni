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

            $scope.comParams = {
                'pageNumber': 1,
                'pageSize': 5
            };

            $scope.isIssueAuthor = undefined;
            $scope.newStatusId = undefined;
            $scope.isPrLead = undefined;
            $scope.commentText = undefined;

            function getIsueById() {
                issue.getIssueById(id).then(
                    function success(data) {
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

            function getComments() {
                $scope.commentText = '';
                issue.getComments(id).then(
                    function success(data) {
                        $scope.comments = data;
                        /*console.log(data);*/
                        changePage();
                    }
                )
            }

            $scope.postComment = function () {
                var data = {
                    Text: $scope.commentText
                };
                issue.postComment(id, data).then(
                    function success(data) {
                        Notification.success('Comment posted successfully');
                        getComments();
                    })
            };


            $scope.changeStatus = function () {
                /*console.log($scope.newStatusId.Id);*/
                issue.changeStatus($scope.issuesById.Id, $scope.newStatusId.Id).then(
                    function success(data) {
                        Notification.success("Status changed successfully!");
                        getIsueById();
                    })
            };

            $scope.reloadComments = function () {
                if (!$scope.comments) {
                    getComments();
                } else {
                    changePage();
                }
            };

            function changePage() {
                var start = ($scope.comParams.pageNumber - 1) * $scope.comParams.pageSize;
                var end = $scope.comParams.pageNumber * $scope.comParams.pageSize;
                if (end > $scope.comments.length) {
                    end = $scope.comments.length;
                }
                $scope.paggedComments = $scope.comments.slice(start, end);
            }

            getIsueById();
            getComments();
        }]);
