/// <reference path="../../../lib/angular.js/angular.js" />

(function () {
    angular.module('ShopEva.Common',
        ['ui.router',
            'angular-loading-bar',
            'ngMessages',
            'ngAnimate'
        ]).config(['cfpLoadingBarProvider', function (cfpLoadingBarProvider) {
            // Thay đổi màu sắc của loading bar
            cfpLoadingBarProvider.includeSpinner = true;
            cfpLoadingBarProvider.includeBar = true;
            cfpLoadingBarProvider.parentSelector = '#loading-bar-container';
            cfpLoadingBarProvider.spinnerTemplate = '<div><span class="fa fa-spinner">Loading...</div>';
        }])
})()