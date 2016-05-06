angular.module('issueTracker.services', ['ui-notification'])
    .factory('authentication', [
        '$http',
        '$q',
        'BASE_URL',
        'Notification',
        function ($http, $q, BASE_URL, Notification) {

            function loginUser(userData) {
                var deferred = $q.defer();
                var loginData = 'Username=' + userData.username + '&Password=' + userData.password + '&grant_type=password';
                $http.post(BASE_URL + 'api/Token', loginData)
                    .then(function success(response) {
                            Notification.success('User successfully logged in');
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

            return {
                loginUser: loginUser,
                registeruser: registerUser
            }
        }]);
