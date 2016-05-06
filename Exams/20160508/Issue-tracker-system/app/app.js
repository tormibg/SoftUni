'use strict';

angular.module('issueTracker', [
        'ngRoute',
        'issueTracker.controllers'
    ])
    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider.otherwise({redirectTo: '/'});
    }]);
