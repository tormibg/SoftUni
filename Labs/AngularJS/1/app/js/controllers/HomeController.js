'use strict';

app.controller('HomeController', function ($scope, adsService, notifyService, pageSize) {
    $scope.adsParams = {
        'startPage': 1,
        'pageSize': pageSize
    };
    $scope.reloadAds = function () {
        adsService.getAds(
            $scope.adsParams,
            function success(data) {
                $scope.ads = data;
            },
            function error(data) {
                notifyService.showError("Cannot load ads", err);
            }
        )
    };
    $scope.reloadAds();

    $scope.$on("categorySelectionChanged", function (event, selectCategoryId) {
        $scope.adsParams.categoryId = selectCategoryId;
        $scope.adsParams.startPage = 1;
        $scope.reloadAds();
    });

    $scope.$on("townSelectionChanged", function (event, selectTownId) {
        $scope.adsParams.townId = selectTownId;
        $scope.adsParams.startPage = 1;
        $scope.reloadAds();
    })
});