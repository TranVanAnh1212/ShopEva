/// <reference path="../../../lib/angular.js/angular.js" />

(function () {
    angular.module('ShopEva.Common',
        ['ui.router',
            'angular-loading-bar',
            'ngMessages',
            'ngAnimate',
            'ngBootbox',
            'ngSanitize',
            'LocalStorageModule',
            'ngCkeditor',
            'angular-jwt',
            'ngResource',
            'ngCookies',
            'angular-price-format'
        ]).config(['cfpLoadingBarProvider', function (cfpLoadingBarProvider) {
            // Thay đổi màu sắc của loading bar
            cfpLoadingBarProvider.includeSpinner = true;
            cfpLoadingBarProvider.includeBar = true;
            cfpLoadingBarProvider.parentSelector = '#loading-bar-container';
            cfpLoadingBarProvider.spinnerTemplate = ' <div><span class="fa fa-spinner">Đang tải...</div> ';  
        }])
})()

// 'datatables'

//LicenseName = "@tuannguyen";
//LicenseKey = "AUKPSE6XSVSJTP4MSV9RQKJBKGLL3KN7";
