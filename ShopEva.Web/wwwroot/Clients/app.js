/// <reference path="../lib/angular.js/angular.js" />

(function () {
    angular.module('ShopEva', ['ShopEva.Common',
        'ShopEva.ProductCategory',
        'ShopEva.Product'
    ])
        .config(config)
        .config(configAuthentication)

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
            })
            .state('LoginPage', {
                url: '/login',
                templateUrl: '/Clients/Components/LoginPage/LoginPageView.html',
                controller: 'LoginPageController'
            });

        $urlRouterProvider.otherwise('/login');
    }

    function configAuthentication($httpProvider) {
        $httpProvider.interceptors.push(function ($q, $injector, $state) {
            return {
                request: function (config) {
                    return config;
                },
                requestError: function (rejection) {
                    return $q.reject(rejection);
                },
                response: function (response) {
                    if (response.status === 401) {
                        $state.go('LoginPage');
                    }
                    //the same response/modified/or a new one need to be returned.
                    return response;
                },
                responseError: function (rejection) {
                    //var authService = $injector.get('authService');
                    //authService.validateRequest();

                    if (rejection.status === 401) {
                        $state.go('LoginPage');
                    }

                    return $q.reject(rejection);
                }
            };
        });
    }
})();