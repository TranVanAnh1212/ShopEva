(function (app) {
    'use strict'

    app.factory('authData', [
        function () {
            var authDataFactory = {};

            var authentication = {
                is_authenticated: false,
                user_name: ''
            };

            authDataFactory.authenticationData = authentication;

            return authDataFactory;
        }]);
})(angular.module('ShopEva.Common'));