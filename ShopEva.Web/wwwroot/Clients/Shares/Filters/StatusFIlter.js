(function (app) {
    app.filter('StatusFilter', () => {
        return function (status) {
            switch (status) {
                case 1:
                    return 'Sử dụng';
                case 2:
                    return 'Không sử dụng';
                case 0:
                    return 'Nháp';
                case 15:
                    return 'Chờ duyệt';
            }
        }
    })

})(angular.module('ShopEva.Common'))