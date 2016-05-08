'use strict';

angular.module('issueTracker.services.projects', [])
    .factory('projects', [
        '$http',
        '$q',
        'BASE_URL',
        '$resource',
        function ($http, $q, BASE_URL, $resource) {

            function getProjects(params, id) {
                var deferred = $q.defer();
                var filter = '';
                if (id) {
                    filter = 'Lead.Id="' + id + '"'
                }
                /*console.log(filter);
                 console.log(id);*/
                var requestData = {
                    method: 'GET',
                    url: BASE_URL + 'projects?filter=' + filter + '&pageSize=' + params.pageSize + '&pageNumber=' + params.pageNumber
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

            function getProjectById(id) {
                var deferred = $q.defer();

                var requestData = {
                    method: 'GET',
                    url: BASE_URL + 'projects/' + id
                };

                $http(requestData)
                    .then(function success(response) {
                        deferred.resolve(response.data);
                    });

                return deferred.promise;
            }

            function editProject(id, data) {
                var deferred = $q.defer();

                var requestData = {
                    method: 'PUT',
                    url: BASE_URL + 'projects/' + id,
                    data: data
                };

                $http(requestData)
                    .then(function success(response) {
                        deferred.resolve(response.data);
                    });

                return deferred.promise;
            }

            return {
                getProjects: getProjects,
                getProjectById: getProjectById,
                editProject: editProject
            }
        }]);

