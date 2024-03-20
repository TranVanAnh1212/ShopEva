(function () {
    angular.module('ShopEva.Product', ['ShopEva.Common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('product', {
            url: '/product',
            parent: 'base',
            templateUrl: '/Clients/Components/Products/ProductView.html',
            controller: 'ProductController',
        }).state('product_overview_add', {
            url: '/product_overview',
            parent: 'base',
            templateUrl: '/Clients/Components/Products/ProductOverview.html',
            controller: 'ProductOverviewController',
        }).state('product_edit', {
            url: '/product_overview/:id',
            parent: 'base',
            templateUrl: '/Clients/Components/Products/ProductOverview.html',
            controller: 'ProductOverviewController',
        });
    }

})();