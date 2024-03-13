(function (app) {
    app.controller('LoginPageController', LoginPageController);

    LoginPageController.$inject = ['$scope', 'CRUDService', 'loginService', 'NotifyService', '$injector'];

    function LoginPageController($scope, CRUDService, loginService, NotifyService, $injector) {
        var vm = $scope;

        vm.loginData = {
            user_name: 'demo',
            password: '@ABCabc123'
        };
        vm.loading = false;

        vm.login = function () {
            vm.loading = true;

            console.log('Đang đăng nhập ...');

            loginService.login(vm.loginData.user_name, vm.loginData.password)
                .then((res) => {
                    console.log(res);

                    if (res != null) {
                        NotifyService.Shows('error', 'Login failue ... ');
                    }
                    else {
                        var stateService = $injector.get('$state');
                        stateService.go('Dashboard');
                    }
                })
                .finally(function () {
                    vm.loading = false;
                });
        }

        vm.demo = demo;
        function demo() {
            console.log('Đây là demo ....');
        }

    }
})(angular.module('ShopEva'));