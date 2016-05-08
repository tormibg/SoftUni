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

            function getIssuesByProjectId(params, id) {
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

            function getIssueById(id) {
                var deferred = $q.defer();

                var requestData = {
                    method: 'GET',
                    url: BASE_URL + 'issues/' + id
                };

                $http(requestData)
                    .then(function success(response) {
                        deferred.resolve(response.data);
                    });

                return deferred.promise;
            }

            function getComments(id) {
                var deferred = $q.defer();

                var requestData = {
                    method: 'GET',
                    url: BASE_URL + 'issues/' + id + '/comments'
                };

                $http(requestData)
                    .then(function success(response) {
                        deferred.resolve(response.data);
                    });

                return deferred.promise;

            }

            function postComment(id, data) {
                var deferred = $q.defer();

                var requestData = {
                    method: 'POST',
                    url: BASE_URL + 'issues/' + id + '/comments',
                    data: data
                };

                $http(requestData)
                    .then(function success(response) {
                        deferred.resolve(response.data);
                    });

                return deferred.promise;

            }

            function addIssue(data) {
                var deferred = $q.defer();

                data.Labels = [];
                data.AssigneeId = data.AssigneeId.Id;

                var requestData = {
                    method: 'POST',
                    url: BASE_URL + 'issues',
                    data: data
                };

                $http(requestData)
                    .then(function success(response) {
                        deferred.resolve(response.data);
                    });

                return deferred.promise;
            }

            function changeStatus(id, statusId) {
                var deferred = $q.defer();

                var requestData = {
                    method: 'PUT',
                    url: BASE_URL + 'issues/' + id + "/changeStatus?statusId=" + statusId
                };

                $http(requestData)
                    .then(function success(response) {
                        deferred.resolve(response.data);
                    });

                return deferred.promise;
            }

            function updateIssue(id, issue) {
                var deferred = $q.defer();

                var requestData = {
                    method: 'PUT',
                    url: BASE_URL + 'issues/' + id,
                    data: issue
                };

                console.log(requestData);

                $http(requestData).then(
                    function success(response) {
                        deferred.resolve(response.data);
                    }
                );

                return deferred.promise;
            }

            return {
                getMyIssue: getMyIssue,
                getIssuesByProjectId: getIssuesByProjectId,
                getIssueById: getIssueById,
                addIssue: addIssue,
                changeStatus: changeStatus,
                updateIssue: updateIssue,
                getComments: getComments,
                postComment: postComment
            }
        }]);

