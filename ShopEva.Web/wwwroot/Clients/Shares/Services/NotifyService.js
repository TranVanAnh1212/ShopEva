(function (app) {
    app.factory('NotifyService', NotifyService);

    function NotifyService() {
        toastr.options = {
            "closeButton": true,
            "debug": false,
            "newestOnTop": true,
            "progressBar": true,
            "positionClass": "toast-top-center",
            "preventDuplicates": true,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }

        function Shows(type, value) {
            switch (type) {
                case "error":
                    if (Array.isArray(value)) {
                        value.forEach((item) => {
                            toastr[type](value, type);
                        });
                    } else {
                        toastr[type](value, type);
                    }
                    break;
                default:
                    toastr[type](value, type);
                    break;
            }
        }

        return {
            Shows: Shows
        }
    }
})(angular.module('ShopEva.Common'))