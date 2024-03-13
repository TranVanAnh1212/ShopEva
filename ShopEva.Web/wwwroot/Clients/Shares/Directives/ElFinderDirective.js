(function(app) {
    app.directive('elFinder', function () {
        return {
            restrict: 'A',
            link: function (scope, element, attrs) {
                // Định cấu hình cho elFinder
                var elfinderOptions = {
                    // Cấu hình các đường dẫn
                    //url: 'path/to/elfinder/php/connector.php',
                    getFileCallback: function (file) {
                        // Xử lý sự kiện trả về khi người dùng chọn tệp tin
                        console.log('File selected:', file);
                        // Đưa dữ liệu file vào $scope hoặc thực hiện các hành động khác tùy thuộc vào nhu cầu của ứng dụng của bạn
                        scope.$apply();
                    },
                    // Thêm các cài đặt khác tùy thuộc vào nhu cầu của bạn
                };

                // Khởi tạo elFinder
                $(element).elfinder(elfinderOptions);
            }
        };
    });
}) (angular.module('ShopEva.Common'));