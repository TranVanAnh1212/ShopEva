(function (app) {
    app.directive('ngImportant', function () {
        return {
            template: '<span style="color:red;">&nbsp;*&nbsp;</span>'
        };
    });
})(angular.module('ShopEva.Common'));