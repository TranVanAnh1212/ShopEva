(function (app) {
    app.service('CRUDService', CRUDService);

    CRUDService.$inject = ['$http', 'NotifyService', 'authService'];

    function CRUDService($http, NotifyService, authService) {
        var baseUrl = 'https://localhost:7075';

        return {
            get: get,
            post: post,
            put: put,
            del: del,
        }

        function post(url, data, success, failure) {
            authService.setHeader();
            $http.post(baseUrl + url, data)
                .then(
                    function (result) {
                        success(result)
                    },
                    function (error) {
                        if (error.status === 401) {
                            NotifyService.Shows('error', 'Authenticate is required ...')
                        }
                        else if (failure != null) {
                            failure(error)
                        }

                    }
                )
        }

        function put(url, data, success, failure) {
            authService.setHeader();
            $http.put(baseUrl + url, data)
                .then(function (result) {
                    //console.log(result.data)
                    success(result);
                }, function (error) {
                    console.log(error.status)
                    if (error.status === 401) {
                        NotifyService.Shows('error', 'Authenticate is required.');
                    }
                    else if (failure != null) {
                        failure(error);
                    }

                });
        }

        function del(url, data, success, failure) {
            authService.setHeader();
            $http.delete(baseUrl + url, data)
                .then(
                    function (result) {
                        success(result)
                    },
                    function (error) {
                        if (error.status === 401) {
                            NotifyService.Shows('error', 'Authenticate is required.');
                        }
                        else if (failure != null) {
                            failure(error);
                        }
                    }
                )
        }

        function get(url, params, success, failure) {
            authService.setHeader();
            $http.get(baseUrl + url, params)
                .then(
                    function (result) {
                        success(result)
                    },
                    function (error) {
                        failure(error)
                    })
        }
    }
})(angular.module('ShopEva.Common'));