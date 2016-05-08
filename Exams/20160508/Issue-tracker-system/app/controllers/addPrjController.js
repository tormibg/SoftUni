'use strict';

angular.module('issueTracker.controllers.AddPrjController', [
        'ui.bootstrap.modal',
        'issueTracker.services.projects',
        'issueTracker.services.users',
        'ui-notification'])

    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/projects/add', {
            title: "Add Project",
            resolve: {
                showModal: ['$uibModal', '$route', function ($uibModal, $route) {
                    var modalInstance = $uibModal.open({
                        animation: true,
                        templateUrl: 'app/views/add-project.html',
                        controller: 'AddPrjController'
                    });
                }]
            }
        });
    }])
    .controller('AddPrjController', [
        '$scope',
        '$uibModalInstance',
        '$location',
        'projects',
        'users',
        'Notification',
        function ($scope, $uibModalInstance, $location, projects, users, Notification) {

            $scope.newProject = {};

            users.getAll().then(
                function success(data) {
                    $scope.users = data;
                });

            $scope.createProject = function () {
                /*console.log($scope.newProject);*/

                var priorities = [];
                var labels = [];

                if ($scope.newProject.Priorities) {
                    var tmpPriorities = $scope.newProject.Priorities.split(',');
                    tmpPriorities.forEach(function (el) {
                        priorities.push({Name: el})
                    });
                }

                if ($scope.newProject.Labels) {
                    var tmpLabels = $scope.newProject.Labels.split(',');
                    tmpLabels.forEach(function (el) {
                        labels.push({Name: el})
                    });
                }

                var createNewProject = {
                    LeadId: $scope.newProject.Lead.Id,
                    ProjectKey: $scope.newProject.ProjectKey,
                    priorities: priorities,
                    labels: labels,
                    Name: $scope.newProject.Name,
                    Description: $scope.newProject.Description
                };

                /*console.log(createNewProject);*/

                projects.createProject(createNewProject).then(
                    function success(data) {
                        $uibModalInstance.close();
                        $location.path('/');
                        Notification.success("Successfully created project!");
                    }
                )
            };

            $scope.cancel = function () {
                $uibModalInstance.dismiss('cancel');
                $location.path('/');
            };

        }]);