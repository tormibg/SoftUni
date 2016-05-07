'use strict';

angular.module('issueTracker.controllers.ProjectController', ['issueTracker.services.projects', 'ui.bootstrap.pagination'])
    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/projects', {
            templateUrl: 'app/views/allProjects.html',
            controller: 'ProjectController'
        });
    }])

    .controller('ProjectController', [
        '$scope',
        'projects',
        function ($scope, projects) {
            projects.getProjects().then(
                function success(data) {
                    console.log(data);
                    $scope.allProjetcs = data;
                }
            );

            $scope.allProjetcsParams = {
                pageNumber: 1,
                pageSize: 8
            };
        }]);
