'use strict';

angular.module('issueTracker.services.issue', [])
    .factory('issue', [
        '$http',
        '$q',
        'BASE_URL',
        function ($http, $q, BASE_URL) {

            function getMyIssue(params) {
                var deferred = $q.defer();

                var requestData = {
                    method: 'GET',
                    url: BASE_URL + 'issues/me?orderBy=DueDate desc' + '&pageSize=' + params.pageSize + '&pageNumber=' + params.pageNumber
                };


                $http(requestData)
                    .then(function success(response) {
                        deferred.resolve(response.data);
                    });

                return deferred.promise;

            }

            function getIssuesByProjectId(params, id){
                var deferred = $q.defer();

                var requestData = {
                    method: 'GET',
                    url: BASE_URL + 'projects/' + id + '/issues?pageSize=' + params.pageSize + '&pageNumber=' + params.pageNumber
                };


                $http(requestData)
                    .then(function success(response) {
                        deferred.resolve(response.data);
                    });

                return deferred.promise;

            }

            return {
                getMyIssue: getMyIssue,
                getIssuesByProjectId: getIssuesByProjectId
            }
        }]);

