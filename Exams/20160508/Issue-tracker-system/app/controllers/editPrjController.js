'use strict';

angular.module('issueTracker.controllers.EditPrjController', [
        'ui.bootstrap.modal',
        'issueTracker.services.projects',
        'issueTracker.services.issue',
        'issueTracker.services.users',
        'issueTracker.services.identity',
        'ui-notification'])

    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/projects/:id/edit', {
            title: "Add Issue",
            resolve: {

                showModal: ['$uibModal', '$route', function ($uibModal, $route) {
                 var modalInstance = $uibModal.open({
                 animation: true,
                 templateUrl: 'app/views/edit-project.html',
                 controller: 'EditPrjController',
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
    .controller('EditPrjController', [
        '$scope',
        '$uibModalInstance',
        '$location',
        'projects',
        'issue',
        'users',
        'id',
        'Notification',
        'identity',
        function ($scope, $uibModalInstance, $location, projects, issues, users, id, Notification, identity) {

            $scope.isAdmin = null;

            projects.getProjectById(id).then(
                function success(data) {
                    $scope.project = data;
                    /*console.log($scope.project);*/
                    if (identity.isUserAdmin()) {
                        $scope.isAdmin = true;
                    }
                    $scope.allPriorities = data.Priorities.map(function (el) {
                        return el.Name;
                    }).join();
                    /*console.log($scope.allPriorities);*/
                });

            users.getAll().then(
                function success(data) {
                    $scope.users = data;
                });

            $scope.editProject = function () {
                var newPriorities = [];
                if ($scope.allPriorities) {
                    var priorities = $scope.allPriorities.split(',');
                    priorities.forEach(function (el) {
                        newPriorities.push({Name: el})
                    });
                }

                var changedProject = {
                    Name: $scope.project.Name,
                    Description: $scope.project.Description,
                    LeadId: $scope.project.Lead.Id,
                    priorities: newPriorities,
                    labels: $scope.project.Labels
                };

                /*console.log(changedProject);*/

                projects.editProject($scope.project.Id, changedProject).then(
                    function success(data) {
                        $uibModalInstance.close();
                        $location.path('/projects/' + id);
                        Notification.success("Project edited successfully!");
                    }
                )
            };

            $scope.cancel = function () {
                $uibModalInstance.dismiss('cancel');
                $location.path('/projects/' + id);
            };

        }]);