(function (app) {
    'use strict'

    app.service('loginService', ['$http', '$q', 'authService', 'authData', 'CRUDService', 'jwtHelper', 'NotifyService'
,        function ($http, $q, authService, authData, CRUDService, jwtHelper, NotifyService) {
            var userInfo;
            var deferred;

            this.login = function (username, password) {
                deferred = $q.defer();

                var data = {
                    userName: username,
                    password: password
                }

                $http.post('https://localhost:7075/api/AuthAPI/Login', data, { headers: { 'Content-Type': 'application/json' } })
                    .then(function (response) {
                        userInfo = {
                            access_token: response.data.result.access_token,
                            is_authenticated: true,
                            user_name: username
                        };

                        authService.setTokenInfo(userInfo);

                        authData.authenticationData.is_authenticated = true;
                        authData.authenticationData.user_name = username;
                        authData.authenticationData.access_token = userInfo.access_token;
                        authData.authenticationData.roles = jwtHelper.decodeToken(userInfo.access_token)['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];

                        deferred.resolve(null);

                        //NotifyService.Shows('success', 'Login successfully, you logged in with ADMIN permissions');

                    }, function (error, status) {
                        authData.authenticationData.is_authenticated = false;
                        authData.authenticationData.user_name = "";
                        authData.authenticationData.access_token = '';
                        authData.authenticationData.roles = null;

                        deferred.resolve(error);
                    })

                return deferred.promise;
            }

            this.loginOAuth = function (username, password) {
                deferred = $q.defer();

                var data = "grant_type=password&username=" + username + "&password=" + password;

                $http.post('/oauth/token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } })
                    .then(function (response) {
                        userInfo = {
                            access_token: response.data.access_token,
                            is_authenticated: true,
                            user_name: userName
                        };

                        authService.setTokenInfo(userInfo);

                        authData.authenticationData.is_authenticated = true;
                        authData.authenticationData.user_name = userName;
                        authData.authenticationData.accessToken = userInfo.accessToken;

                        deferred.resolve(null);

                    }, function (error, status) {
                        authData.authenticationData.is_authenticated = false;
                        authData.authenticationData.user_name = "";

                        deferred.resolve(error);
                    })

                return deferred.promise;
            }

            this.logOut = function () {
                CRUDService.post('/api/AuthAPI/LogOut', null, function (response) {
                    console.log(response);

                    authService.removeToken();
                    authData.authenticationData.is_authenticated = false;
                    authData.authenticationData.user_name = "";
                    authData.authenticationData.access_token = "";
                }, null)
            }
        }]);
})(angular.module('ShopEva.Common'));