﻿/// <reference path="../../../lib/angular.js/angular.js" />

(function (app) {
    app.controller('ProductCategoryListController', ProductCategoryListController);

    ProductCategoryListController.$inject = ['$scope', 'CRUDService', 'NotifyService',
        '$filter', '$ngBootbox', '$location', 'localStorageService', '$timeout', 'ExcelService'];
    function ProductCategoryListController($scope, CRUDService, NotifyService, $filter,
        $ngBootbox, $location, localStorageService, $timeout, ExcelService) {
        var vm = $scope;
        vm.product_category_list = [];
        vm.product_category_original = [];
        vm.product_category_list_checked;
        vm.status_list = [];
        vm.totalCount = 0;
        vm.pagesCount = 0;
        vm.page = 1;
        vm.keyword = '';
        vm.status = {
            id: -1,
            name: 'Tất cả'
        };
        vm.order_type = 'ASC';
        vm.is_selected_all = false;
        vm.search_value;

        // func
        vm.GetProductCategoryList = GetProductCategoryList;
        vm.selected_all = Selected_all;
        vm.Reload = Reload;
        vm.ChangeCombobox = ChangeCombobox;
        vm.SelectProductCategory = SelectProductCategory;
        vm.DeleteMultiple = DeleteMultiple;
        vm.ChangeSorted = ChangeSorted;
        vm.UpdateProductCategory = UpdateProductCategory;
        vm.Improved = Improved;
        vm.Dlb_Select = Dlb_Select;
        vm.ExportExcel = ExportExcel;
        vm.TblInternalSearch = TblInternalSearch;

        function TblInternalSearch(keyword, col_name) {
            switch (col_name) {
                case 'name':
                    setTimeout(function () {
                        var searched_list = [];

                        if (keyword) {
                            GetProductCategoryList(vm.page, vm.status.id, 'name', keyword);
                        }
                        else {
                            GetProductCategoryList(vm.page, vm.status.id, 'name', '');
                        }
                    }, 200);

                    break;
            }
        }

        // Hàm export
        function ExportExcel() {            
            ExcelService.exportToExcel(vm.product_category_list, "ProductCategory_Export");
        }

        // Hàm double click to choose a record
        function Dlb_Select(id) {
            $location.path('/product_category_overview/' + id);
        }

        function Improved() {
            if (!vm.product_category_list_checked.length) {
                NotifyService.Shows('error', 'Please choose one record!');
                return;
            }

            var isError = false;

            angular.forEach(vm.product_category_list_checked, (item) => {
                if (item.status != 15) {
                    NotifyService.Shows('error', 'There is a record with a different status waiting for approval');
                    isError = true;
                    return;
                }
            })

            if (isError) return;

            angular.forEach(vm.product_category_list_checked, (item) => {
                item.status = 1;

                CRUDService.put('/api/ProductCategoryAPI/update', item, (result) => {

                }, (err) => {
                    NotifyService.Shows('error', 'Cannot improve, some wrong ..');
                    return;
                });
            })

            GetProductCategoryList(vm.page, vm.status.id, 'name', '');
        }

        function UpdateProductCategory() {
            if (vm.product_category_list_checked.length <= 0) {
                NotifyService.Shows('error', 'Please choose one record .... ');
                return;
            }

            if (vm.product_category_list_checked.length > 1) {
                NotifyService.Shows('error', 'Please choose only one record .... ');
                return;
            }

            $location.path('/product_category_overview/' + vm.product_category_list_checked[0].id);
        }

        function ChangeSorted(type) {
            vm.order_type = vm.order_type == 'DESC' ? 'ASC' : 'DESC';
            GetProductCategoryList(vm.page, vm.status.id, type, '');
        }

        function DeleteMultiple() {
            if (vm.product_category_list_checked.length <= 0) {
                NotifyService.Shows('error', 'Please choose one record .... ');
                return;
            }

            $ngBootbox.confirm({ message: "Are you sure you want to delete?", title: 'Delete record ?' })
                .then(function () {
                    var list_checked_custom = [];

                    angular.forEach(vm.product_category_list_checked, (item) => {
                        var proCateg = {
                            ID: item.id,
                            Name: item.name
                        };

                        list_checked_custom.push(proCateg);
                    })

                    var config = {
                        params: {
                            productCategoryJSON: JSON.stringify(list_checked_custom)
                        }
                    };

                    CRUDService.del('/api/ProductCategoryAPI/delete', config, (result) => {
                        NotifyService.Shows('success', 'Deleted ' + result.data.result + ' record!');
                        vm.product_category_list_checked = [];
                        GetProductCategoryList(vm.page, vm.status.id, 'name', '');
                    }, (err) => {
                        NotifyService.Shows('error', "Có lỗi xảy ra");
                    });
                }, function () {
                    //
                });
        }

        function SelectProductCategory(item) {
            item.selected = !item.selected;
        }

        function ChangeCombobox(type, item) {
            switch (type) {
                case 'status':
                    GetProductCategoryList(vm.page, item.id, 'name', '');
                    break;
            }
        }

        function Reload() {
            GetProductCategoryList(vm.page, vm.status.id, 'name', '');
            vm.is_selected_all = false;
        }

        function Selected_all(is_selected_all) {
            vm.is_selected_all = !is_selected_all;

            angular.forEach(vm.product_category_list, (item) => {
                item.selected = vm.is_selected_all;
            })
        }

        vm.$watch('product_category_list', function (n, o) {
            var selected_list = $filter('filter')(n, { selected: true, });

            vm.product_category_list_checked = selected_list;

            if (selected_list.length) {
                if (selected_list.length == n.length) {
                    vm.is_selected_all = true;
                }
                else {
                    vm.is_selected_all = false;
                }
            }
        }, true);

        function GetStatus() {
            var config = {
                params: {
                    status_of: 1
                }
            }

            CRUDService.get('/api/StatusAPI/get_status', config, (result) => {
                vm.status_list = result.data.result;
                vm.status_list.push({
                    id: -1,
                    name: 'Tất cả'
                })
            }, (err) => {
                NotifyService.Shows('error', err);
            })
        }

        function GetProductCategoryList(page, status, order, keyword) {
            page = page || 1;

            var config = {
                params: {
                    keyword: keyword,
                    order_by: order,
                    status: status,
                    order_type: vm.order_type,
                    page: page,
                }
            }

            CRUDService.get('/api/ProductCategoryAPI/getall', config, (result) => {
                var value = result.data;

                if (value.result.totalCount <= 0) {
                    //NotifyService.Shows('info', 'Product category empty ...');
                    NotifyService.Success('Product category empty ...');
                }
                else {
                    vm.product_category_original = value.result.data;
                    vm.product_category_list = value.result.data;
                    vm.page = value.result.page;
                    vm.totalCount = value.result.totalCount;
                    vm.pagesCount = value.result.totalPage;
                }
            }, (err) => {
                //NotifyService.Shows('error', err);
                NotifyService.Success('Error ...');
            })
        }

        GetProductCategoryList(vm.page, -1, 'name', '');
        GetStatus();
    }


})(angular.module('ShopEva.ProductCategory'));