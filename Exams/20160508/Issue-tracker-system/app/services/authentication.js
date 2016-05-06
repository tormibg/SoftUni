angular.module('issueTracker.services', ['ngStorage'])
    .factory('authentication', [
        '$http',
        '$q',
        'BASE_URL',
        '$localStorage',
        function ($http, $q, BASE_URL, $localStorage) {

            function loginUser(userData) {
                var deferred = $q.defer();
                var loginData = 'Username=' + userData.username + '&Password=' + userData.password + '&grant_type=password';
                $http.post(BASE_URL + 'api/Token', loginData)
                    .then(function success(response) {
                            deferred.resolve(response.data);
                        }
                    );
                return deferred.promise;
            }

            function registerUser(userData) {
                var deferred = $q.defer();

                $http.post(BASE_URL + 'api/Account/Register', userData)
                    .then(function (response) {
                        deferred.resolve(response.data)
                    });

                return deferred.promise;
            }

            function loggedUser(data) {
                $localStorage.currentUser = data;
            }

            function getUser(user, token) {
                var deferred = $q.defer();

                $http.get(BASE_URL + 'Users/me', {
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

            return {
                loginUser: loginUser,
                registerUser: registerUser,
                loggedUser: loggedUser,
                getUser: getUser
            }
        }]);
