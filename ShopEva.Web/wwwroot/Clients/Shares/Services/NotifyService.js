(function (app) {
    app.factory('NotifyService', NotifyService);

    function NotifyService() {
        toastr.options = {
            "closeButton": true,
            "debug": false,
            "newestOnTop": false,
            "progressBar": false,
            "positionClass": "toast-top-center",
            "preventDuplicates": false,
            "onclick": null,
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

        function Success(success) {
            toastr.success(success)
        }

        function Error(error) {
            if (Array.isArray(error)) {
                error.forEach((item) => {
                    toastr.error(item)
                })
            } else {
                toastr.error(error)
            }
        }

        function Warning(warning) {
            toastr.warning(warning)
        }

        function Info(info) {
            toastr.info(info)
        }

        return {
            Shows: Shows,
            Success: Success,
            Error: Error,
            Warning: Warning,
            Info: Info,
        }
    }
})(angular.module('ShopEva.Common'))