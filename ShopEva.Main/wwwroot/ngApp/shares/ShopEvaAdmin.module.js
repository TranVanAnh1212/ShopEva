(function () {
    angular.module('ShopEvaAdmin.Module',
        ['ui.router',
            'angular-loading-bar',
            'ngSanitize',
            'ngMessages'
        ]).config(['cfpLoadingBarProvider', function (cfpLoadingBarProvider) {
                // Thay đổi màu sắc của loading bar
                cfpLoadingBarProvider.includeSpinner = true;
                cfpLoadingBarProvider.includeBar = true;
                cfpLoadingBarProvider.parentSelector = '#loading-bar-container';
                cfpLoadingBarProvider.spinnerTemplate = ' <div><span class="fa fa-spinner">Đang tải...</div> ';
            }])
})();