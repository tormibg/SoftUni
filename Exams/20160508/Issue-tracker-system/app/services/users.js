'use strict';

angular.module('issueTracker.services.users',[])
    .factory('users', ['$http', '$q', 'BASE_URL', function ($http, $q, BASE_URL) {

        function getAll() {
            var defered = $q.defer();
            var url = BASE_URL + 'users/';
            $http.get(url)
                .success(function success(data) {
                    defered.resolve(data);
                })
                .error(function error(err) {
                    defered.reject(err);
                });

            return defered.promise;
        }

        function getMyInfo() {
            headersService.setHeaders();

            var defered = $q.defer();
            var url = BASE_URL + 'users/me';
            $http.get(url)
                .success(function success(data) {
                    defered.resolve(data);
                })
                .error(function error(err) {
                    defered.reject(err);
                });

            return defered.promise;
        }

        function getByQuery(query) {

            headersService.setHeaders();

            var defered = $q.defer();
            var url = BASE_URL + 'users?' + 'filter=' + query;
            $http.get(url)
                .success(function success(data) {
                    defered.resolve(data);
                })
                .error(function error(err) {
                    defered.reject(err);
                });

            return defered.promise;
        }

        return {
            getAll: getAll,
            getByQuery: getByQuery,
            getMyInfo: getMyInfo
        }
    }]);