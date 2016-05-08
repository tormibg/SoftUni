'use strict';

angular.module('issueTracker.services.identity', ['ngStorage'])
    .factory('identity', [
        '$http',
        '$q',
        'BASE_URL',
        '$localStorage',
        function ($http, $q, BASE_URL, $localStorage) {

            function getUser(user, token) {
                user = user || $localStorage.logUser;
                token = token || $localStorage.logUser.access_token;
                var deferred = $q.defer();
                $http.get(BASE_URL + 'users/me', {
                        data: user,
                        headers: {
                            Authorization: 'Bearer ' + token
                        }
                    })
                    .then(function (response) {
                        deferred.resolve(response.data)
                    });

                return deferred.promise;
            }

            function getCurrentUser() {
                return $localStorage.logUser.Id;
            }

            function getCurrentUserName() {
                return $localStorage.logUser.userName;
            }

            function isUserAdmin() {
                return $localStorage.logUser.isAdmin;
            }

            function getCurrentUserData(){
                return $localStorage.logUser;
            }

            return {
                getUser: getUser,
                getCurrentUser: getCurrentUser,
                isUserAdmin: isUserAdmin,
                getCurrentUserName: getCurrentUserName,
                getCurrentUserData: getCurrentUserData
            }
        }]);
