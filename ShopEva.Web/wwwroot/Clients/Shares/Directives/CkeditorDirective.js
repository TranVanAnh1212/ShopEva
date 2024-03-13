(function (app) {
    'use strict';
    app.directive('ckEditor', function () {
        return {
            require: '?ngModel',
            link: function (scope, element, attr, ngModel) {
                var ck = CKEDITOR.replace(element[0]);

                if (!ngModel) return;

                ck.on('pasteState', function () {
                    scope.$apply(function () {
                        ngModel.$setViewValue(ck.getData());
                    });
                });

                ngModel.$render = function (value) {
                    ck.setData(ngModel.$viewValue);
                };

                //if (!ngModel) return;

                //ClassicEditor.create(element[0])
                //    .then(editor => {
                //        editor.model.document.on('change:data', () => {
                //            scope.$evalAsync(() => {
                //                ngModel.$setViewValue(editor.getData());
                //            });
                //        });
                //    })
                //    .catch(err => {
                //        console.error(err.stack);
                //    });

                //ngModel.$render = function () {
                //    element.val(ngModel.$viewValue);
                //};
            }
        };
    });
})(angular.module('ShopEva.Common'));