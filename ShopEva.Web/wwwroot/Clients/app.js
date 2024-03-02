/// <reference path="../lib/angular.js/angular.js" />

(function () {
    angular.module('ShopEva', ['ShopEva.Common',
                                'ShopEva.ProductCategory']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('base', {
                url: '',
                templateUrl: '/Clients/Shares/Views/BaseView.html',
                abstract: true
            })
            .state('Dashboard', {
                url: '/Dashboard',
                parent: 'base',
                templateUrl: '/Clients/Components/AdminHome/DashboardView.html',
                controller: 'DashboardController'
            });

        $urlRouterProvider.otherwise('/Dashboard');
    }
})();