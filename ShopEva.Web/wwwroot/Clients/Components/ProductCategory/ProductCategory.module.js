/// <reference path="../../../lib/angular.js/angular.js" />

(function () {
    angular.module('ShopEva.ProductCategory', ['ShopEva.Common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider']

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('product_category', {
            url: '/product_category',
            parent: 'base',
            templateUrl: 'Clients/Components/ProductCategory/ProductCategoryListView.html',
            controller: 'ProductCategoryListController'
        }).state('product_category_overview_add', {
            url: '/product_category_overview',
            parent: 'base',
            templateUrl: 'Clients/Components/ProductCategory/ProductCategoryOverview.html',
            controller: 'ProductCategoryOverviewController'
        }).state('product_category_overview_edit', {
            url: '/product_category_overview/:id',
            parent: 'base',
            templateUrl: 'Clients/Components/ProductCategory/ProductCategoryOverview.html',
            controller: 'ProductCategoryOverviewController'
        });
    }
})();