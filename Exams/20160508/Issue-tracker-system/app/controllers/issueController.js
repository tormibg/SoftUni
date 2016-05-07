'use strict';

angular.module('issueTracker.controllers.IssueController', [])
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

            $scope.prjParams = {
                'pageNumber': 1,
                'pageSize': 5
            };

            $scope.reloadProjects = function(){
                projects.getProjects($scope.prjParams).then(
                    function success(data){
                        console.log(data);
                        $scope.allProjetcs = data;
                    })
            };

            $scope.reloadProjects();

        }]);
