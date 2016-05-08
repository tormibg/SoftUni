'use strict';

angular.module('issueTracker.controllers.AddIssueController', [
        'ui.bootstrap.modal',
        'issueTracker.services.projects',
        'issueTracker.services.issue',
        'issueTracker.services.users',
        'ui-notification'])

    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/projects/:id/add-issue', {
            title: "Add Issue",
            resolve: {
                showModal: ['$uibModal', '$route', function ($uibModal, $route) {
                    var modalInstance = $uibModal.open({
                        animation: true,
                        templateUrl: 'app/views/add-issue.html',
                        controller: 'AddIssueController',
                        resolve: {
                            id: function () {
                                return $route.current.params['id'];
                            }
                        }
                    });
                }]
            }
        });
    }])
    .controller('AddIssueController', [
        '$scope',
        '$uibModalInstance',
        '$location',
        'projects',
        'issue',
        'users',
        'id',
        'Notification',
        function ($scope, $uibModalInstance, $location, projects, issues, users, id, Notification) {

            $scope.issue = {};
            $scope.issue.ProjectId = id;

            projects.getProjectById(id).then(function success(data) {
                $scope.project = data;
            });

            users.getAll().then(
                function success(data) {
                    $scope.users = data;
                });


            $scope.addIssue = function () {
                issues.addIssue($scope.issue).then(
                    function success(data) {
                        /*console.log(data);*/
                        $uibModalInstance.close();
                        $location.path('/projects/' + id);
                        Notification.success('Issue added successfully');
                    });
            };

            $scope.cancel = function () {
                $uibModalInstance.dismiss('cancel');
                $location.path('/projects/' + id);
            };


            //Datepicker
            $scope.today = function () {
                debugger;
                $scope.issue.DueDate = new Date();
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
        }]);