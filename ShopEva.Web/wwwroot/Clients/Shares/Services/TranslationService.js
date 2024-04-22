(function (app) {
    'use strict';

    app.service('translationService', ['$resource', function ($resource) {

        this.getTranslation = function ($scope, lang) {
            var lang_file_path = '/clients/shares/localizations/translation_' + lang + '.json';
            var ssid = 'ssid_' + lang;

            if (sessionStorage) {
                if (sessionStorage.getItem(ssid)) {
                    $scope.translation = JSON.parse(sessionStorage.getItem(ssid));
                } else {
                    $resource(lang_file_path).get(function (data) {
                        $scope.translation = data;
                        sessionStorage.setItem(ssid, JSON.stringify($scope.translation));
                    });
                }
            } else {
                $resource(lang_file_path).get(function (data) {
                    $scope.translation = data;
                });

            }
        }
    }]);
})(angular.module('ShopEva.Common'));