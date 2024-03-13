/// <reference path="../../../lib/angular.js/angular.js" />

(function (app) {
    app.controller('RootController', RootController);

    RootController.$inject = ['$scope', 'authData'];

    function RootController($scope, authData) {
        $scope.DemoValue = "Trần Văn Anh Demo value angular.js"

        $scope.authentication = authData.authenticationData;
    }

})(angular.module('ShopEva'));