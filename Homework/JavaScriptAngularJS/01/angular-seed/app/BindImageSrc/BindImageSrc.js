'use strict';

angular.module('myApp.BindImageSrc', ['ngRoute'])

    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/BindImageSrc', {
            templateUrl: 'BindImageSrc/BindImageSrc.html',
            controller: 'BindImageSrcCtrl',
            factory: 'BindImageSrcFactory',
            directive: 'validateImageUrl'
        });
    }])

    .controller('BindImageSrcCtrl', [function () {

    }])

    .factory('BindImageSrcFactory', function ($q) {
        return {
            isImage: function (src) {

                var deferred = $q.defer();

                var image = new Image();
                image.onerror = function () {
                    deferred.resolve(false);
                };
                image.onload = function () {
                    deferred.resolve(true);
                };
                image.src = src;

                return deferred.promise;
            }
        };
    })
    .directive('validateImageUrl', function ($http, BindImageSrcFactory) {
        return {
            restrict: 'A',
            require: 'ngModel',
            link: function (scope, element, attrs, ngModel) {

                scope.test = function () {
                    BindImageSrcFactory.isImage(scope.imageUrl).then(function (result) {
                        if (result) {
                            ngModel.$setValidity('validateImageUrl', true);
                        } else {
                            ngModel.$setValidity('validateImageUrl', false);
                        }
                    });
                };

                scope.$watch(attrs.ngModel, function () {
                    if (scope.imageUrl) {
                        scope.test();
                    }
                });
            }
        };
    });
