/// <reference path="../../../lib/angular.js/angular.js" />

(function (app) {
    app.controller('RootController', RootController);

    RootController.$inject = ['$scope'];

    function RootController($scope) {
        $scope.DemoValue = "Trần Văn Anh Demo value angular.js"
    }

})(angular.module('ShopEva'));