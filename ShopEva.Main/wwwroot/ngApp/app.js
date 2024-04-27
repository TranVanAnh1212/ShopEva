/// <reference path="../lib/angular.js/angular.js" />
(function () {
    angular.module("ShopEvaAdmin", ['ShopEvaAdmin.Module'])
        .config(config);


    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        //$stateProvider
        //    .state('Dashboard', {
        //        url: '/Dashboard',
        //        templateUrl: '/Areas/AdminArea/Views/AdminHome/Dashboard.html',
        //        controller: 'DashboardController'
        //    })
            //.state('LoginPage', {
            //    url: '/login',
            //    templateUrl: '/Clients/Components/LoginPage/LoginPageView.html',
            //    controller: 'LoginPageController'
            //});

        //$urlRouterProvider.otherwise('/Login');
    }
})();