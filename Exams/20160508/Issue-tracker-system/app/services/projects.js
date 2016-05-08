'use strict';

angular.module('issueTracker.services.projects', [])
    .factory('projects', [
        '$http',
        '$q',
        'BASE_URL',
        '$resource',
        function ($http, $q, BASE_URL, $resource) {

            function getMyProjects(params, id) {
                var deferred = $q.defer();
                var filter = '';
                if (id) {
                    filter = 'Lead.Id="' + id + '"'
                }

                var requestData = {
                    method: 'GET',
                    url: BASE_URL + 'projects?' + 'filter=LeadId=\"' + id + '\"' + ' or Issues.Any(AssigneeId==\"' + id + '\")' + '&pageSize=' + params.pageSize + '&pageNumber=' + params.pageNumber
                };

                $http(requestData)
                    .then(function success(response) {
                        deferred.resolve(response.data);
                    });

                return deferred.promise;

            }

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

            function createProject(data) {
                var deferred = $q.defer();

                var requestData = {
                    method: 'POST',
                    url: BASE_URL + 'projects',
                    data: data
                };

                $http(requestData)
                    .then(function success(response) {
                        deferred.resolve(response.data);
                    });

                return deferred.promise;
            }

            return {
                getMyProjects: getMyProjects,
                getProjects: getProjects,
                getProjectById: getProjectById,
                editProject: editProject,
                createProject: createProject
            }
        }]);

