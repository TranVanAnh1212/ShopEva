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

        function Success(success) {
            toastr.success(success);
        }

        function Error(error) {
            toastr.error(error);
        }

        function Warning(warning) {
            toastr.warning(warning);
        }

        function Info(info) {
            toastr.info(info);
        }

        return {
            Success: Success,
            Error: Error,
            Warning: Warning,
            Info: Info
        }
    }
})(angular.module('ShopEva.Common'))