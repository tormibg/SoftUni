'use strict';

angular.module('myApp.studentView', ['ngRoute'])

    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/studentView', {
            templateUrl: 'studentView/studentView.html',
            controller: 'studentViewCtrl'
        });
    }])

    .controller('studentViewCtrl', function ($scope) {
        $scope.student = {
            name: "Pesho",
            photo: "http://www.nakov.com/wp-content/uploads/2014/05/SoftUni-Logo.png",
            grade: 5,
            school: "High School of Mathematics",
            teacher: "Gichka Pesheva"
        };

    });