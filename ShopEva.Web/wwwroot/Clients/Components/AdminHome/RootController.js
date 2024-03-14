/// <reference path="../../../lib/angular.js/angular.js" />

(function (app) {
    app.controller('RootController', ['$scope', 'authData', 'loginService', '$state', '$ngBootbox',
        function ($scope, authData, loginService, $state, $ngBootbox) {
            var vm = $scope;

            vm.DemoValue = "Trần Văn Anh Demo value angular.js"

            vm.authentication = authData.authenticationData;

            //vm.LogOut = function () {
            //    $ngBootbox.confirm('Logout ?')
            //        .then(() => {
            //            loginService.logOut();
            //            $state.go('LoginPage');
            //        })

            //};

        }]);
})(angular.module('ShopEva'));