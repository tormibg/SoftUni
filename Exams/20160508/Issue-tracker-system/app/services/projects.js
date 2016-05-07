'use strict';

angular.module('issueTracker.services.projects', [])
    .factory('projects', [
        '$http',
        '$q',
        'BASE_URL',
        'PRJ_PARAM',
        function ($http, $q, BASE_URL, PRJ_PARAM) {

            function getProjectById(id) {
                var deferred = $q.defer();
                var filter = '';
                if (id) {
                    filter = 'Lead.Id="' + id + '"'
                }
                /*console.log(filter);
                console.log(id);*/
                var requestData = {
                    method: 'GET',
                    url: BASE_URL + 'projects/'
                };
                //url: BASE_URL + 'projects?filter=' + filter + '&pageSize='+ PRJ_PARAM.pageSize + '&pageNumber=' + PRJ_PARAM.pageNumber
                /*console.log(param.pageNumber);
                console.log(requestData);*/

                $http(requestData)
                    .then(function success(response) {
                        deferred.resolve(response.data);
                    });

                return deferred.promise;

            }

            return {
                getProjects: getProjectById
            }
        }]);

