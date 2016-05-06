'use strict';

angular.module('issueTracker', [
        'ngRoute',
        'issueTracker.controllers'
    ])
    .config(['$routeProvider', '$httpProvider', function ($routeProvider, $httpProvider) {

        $routeProvider.otherwise({redirectTo: '/'});

        $httpProvider.interceptors.push(['$q', 'toastr', function ($q, toastr) {
            return {
                'responseError': function (rejection) {
                    if (rejection.data && rejection.data['error_description']) {
                        toastr.error(rejection.data['error_description']);
                    }
                    else if (rejection.data && rejection.data.modelState && rejection.data.modelState['']) {
                        var errors = rejection.data.modelState[''];
                        if (errors.length > 0) {
                            toastr.error(errors[0]);
                        }
                    }

                    return $q.reject(rejection);
                }
            }
        }]);
    }])

    .constant('BASE_URL', 'http://softuni-issue-tracker.azurewebsites.net/')
    .constant('toastr', toastr);
