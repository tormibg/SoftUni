'use strict';

angular.module('issueTracker', [
        'ngRoute',
        'issueTracker.controllers.HomeController',
        'issueTracker.controllers.DashboardController',
        'issueTracker.controllers.ProjectController',
        'issueTracker.controllers.ProjectIdController',
        'ngStorage',
        'ui.bootstrap.pagination',
        'ngResource'
    ])

    .config(['$routeProvider', '$httpProvider', function ($routeProvider, $httpProvider, $localStorage) {

        $routeProvider.otherwise({redirectTo: '/'});

        $httpProvider.interceptors.push(['$q', 'toastr', function ($q, toastr) {
            return {
                'responseError': function (rejection) {
                    if (rejection.data && rejection.data['error_description']) {
                        toastr.error(rejection.data['error_description']);
                    }
                    else if (rejection.data && rejection.data.ModelState && rejection.data.ModelState['']) {
                        var errors = rejection.data.ModelState[''];
                        if (errors.length > 0) {
                            toastr.error(errors[0]);
                        }
                    }
                    else if (rejection.data && rejection.data.ModelState && rejection.data.ModelState['model.Email']) {
                        var errors = rejection.data.ModelState['model.Email'];
                        if (errors.length > 0) {
                            toastr.error(errors[0]);
                        }
                    }
                    else if (rejection.data && rejection.data.ModelState && rejection.data.ModelState['model.Password']) {
                        var errors = rejection.data.ModelState['model.Password'];
                        if (errors.length > 0) {
                            toastr.error(errors[0]);
                        }
                    }

                    return $q.reject(rejection);
                }
            }
        }])
    }])

    .constant('BASE_URL', 'http://softuni-issue-tracker.azurewebsites.net/')
    .constant('toastr', toastr)

    .run(['$rootScope', '$location', '$route', '$http', 'authentication', '$localStorage', function ($rootScope, $location, $route, $http, authentication, $localStorage) {
        $rootScope.$on('$locationChangeStart', function (event) {
            if ($location.path() != "/" && !authentication.isAuthenticated()) {
                $location.path("/");
            }
            if ($localStorage.logUser) {
                $http.defaults.headers.common.Authorization = 'Bearer ' + $localStorage.logUser.access_token;
            }
        })
    }]);