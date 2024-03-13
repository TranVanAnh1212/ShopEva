﻿(function (app) {
    'use strict';
    app.service('authService', ['$http', '$q', '$window', 'localStorageService', 'authData',
        function ($http, $q, $window, localStorageService, authData) {
            var tokenInfo;

            this.setTokenInfo = function (data) {
                tokenInfo = data;
                localStorageService.set('TokenInfo', JSON.stringify(tokenInfo));
            }

            this.getTokenInfo = function () {
                return tokenInfo;
            }

            this.removeToken = function () {
                tokenInfo = null;
                localStorageService.set('TokenInfo', null);
            }

            this.init = function () {
                var tokenInfo = localStorageService.get('TokenInfo');

                if (tokenInfo) {
                    tokenInfo = JSON.parse(tokenInfo);
                    authData.authenticationData.is_authenticated = true;
                    authData.authenticationData.user_name = tokenInfo.user_name;
                    authData.authenticationData.access_token = tokenInfo.access_token;
                }
            }

            this.setHeader = function () {
                delete $http.defaults.headers.common['X-Requested-With'];

                if (authData.authenticationData && authData.authenticationData.access_token) {
                    $http.defaults.headers.common['Authorization'] = 'Bearer ' + authData.authenticationData.access_token;
                    $http.defaults.headers.common['Content-Type'] = 'application/x-www-form-urlencoded;charset=utf-8';
                }
            }

            this.validateRequest = function () {
                var url = '/api/home/TestMethod';

                var deferred = $q.defer();

                $http.get(url)
                    .then(
                        function () {
                            deferred.resolve(null);
                        },
                        function (error) {
                            deferred.reject(error);
                        }
                    );
                return deferred.promise;
            }

            this.init();
        }
    ]);
})(angular.module('ShopEva.Common'));