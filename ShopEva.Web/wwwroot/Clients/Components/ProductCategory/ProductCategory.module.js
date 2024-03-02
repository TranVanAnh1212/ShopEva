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
        })
    }
})();