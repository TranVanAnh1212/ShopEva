(function (app) {
    app.factory('NotifyService', NotifyService);

    function NotifyService() {
        toastr.options = {
            "closeButton": true,
            "debug": true,
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

        function Shows(type, msg) {
            switch (type) {
                case "error":
                    if (Array.isArray(msg)) {
                        msg.forEach((item) => {
                            toastr[type](msg, type);
                        });
                    } else {
                        toastr[type](msg, type);
                    }
                    break;
                default:
                    toastr[type](msg, type);
                    break;
            }
        }

        return {
            Shows: Shows
        }
    }
})(angular.module('ShopEva.Common'))