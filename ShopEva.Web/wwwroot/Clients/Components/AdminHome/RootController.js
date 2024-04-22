/// <reference path="../../../lib/angular.js/angular.js" />

(function (app) {
    app.controller('RootController', ['$scope', 'authData', 'loginService', '$state', '$ngBootbox',
        'authService', 'translationService',
        function ($scope, authData, loginService, $state, $ngBootbox, authService, translationService) {
            var vm = $scope;

            vm.authentication = authData.authenticationData;

            vm.LogOut = function () {
                $ngBootbox.confirm({ message: "Bạn có chắc muốn đăng xuất?", title: 'Đăng xuất' })
                    .then(() => {
                        loginService.logOut();
                        $state.go('LoginPage');
                    })
            };

            //authService.validateRequest();

            vm.langs = [
                {
                    img: '../../../img/Flag-United-States-of-America.png',
                    lang_text: 'English',
                    lang_code: 'en'
                },
                {
                    img: '../../../img/Flag_of_Vietnam.png',
                    lang_text: 'Tiếng việt',
                    lang_code: 'vi'
                }
            ];
            vm.lang = {};
            vm.ChangeLanguage = function (lang) {
                translationService.getTranslation($scope, lang);
                angular.forEach(vm.langs, function (element, index) {
                    if (element.lang_code === lang) {
                        vm.lang = element;
                    };
                })
            };
            vm.ChangeLanguage('vi');

        }]);
})(angular.module('ShopEva'));