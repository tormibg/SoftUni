angular.module('issueTracker.services', ['ngStorage'])
    .factory('authentication', [
        '$http',
        '$q',
        'BASE_URL',
        '$localStorage',
        function ($http, $q, BASE_URL, $localStorage) {

            function preserveUserData(data) {
                var accessToken = data.access_token;
                $http.defaults.headers.common.Authorization = 'Bearer ' + accessToken;
            }

            function loginUser(userData) {
                var deferred = $q.defer();
                var loginData = 'Username=' + userData.username + '&Password=' + userData.password + '&grant_type=password';
                $http.post(BASE_URL + 'api/Token', loginData)
                    .then(function success(response) {
                            preserveUserData(response.data);
                            deferred.resolve(response.data);
                        }
                    );
                return deferred.promise;
            }

            function registerUser(userData) {
                var deferred = $q.defer();
                $http.post(BASE_URL + 'api/Account/Register', userData)
                    .then(function success(response) {
                        deferred.resolve(response)
                    });

                return deferred.promise;
            }

            function loggedUser(data) {
                $localStorage.logUser = data;
            }

            function isAuthenticated() {
                return $localStorage.logUser != undefined;
            }

            function logoutUser() {
                var deferred = $q.defer();

                var token = $localStorage.logUser.access_token;

                var requestData = {
                    method: 'POST',
                    url: BASE_URL + 'api/Account/Logout',
                    headers:{'Authorization': 'Bearer ' + token}
                };

                $http(requestData)
                    .then(function success(response){
                        $http.defaults.headers.common.Authorization = undefined;
                        deferred.resolve(response);
                    });

                /*$http.post(BASE_URL + 'api/Account/Logout', {
                    headers: {
                        Authorization: 'Bearer ' + token
                    }
                })
                    .then(function success(response) {
                        deferred.resolve(response)
                    });*/

                return deferred.promise;
            }

            function  deleteLoggedUser() {
                $localStorage.$reset();
            }

            return {
                loginUser: loginUser,
                registerUser: registerUser,
                loggedUser: loggedUser,
                isAuthenticated: isAuthenticated,
                logoutUser: logoutUser,
                deleteLoggedUser: deleteLoggedUser,
                preserveUserData: preserveUserData
            }
        }]);
