(function (app) {
    app.controller('ProductController', ['$scope', 'CRUDService', 'NotifyService', '$filter', '$ngBootbox', '$location',
        function ($scope, CRUDService, NotifyService, $filter, $ngBootbox, $location) {
            var vm = $scope;

            vm.product_list = [];
            vm.page = 1;
            vm.status = {
                id: -1,
                Name: 'Tất cả'
            };
            vm.status_list = [];
            vm.totalCount;
            vm.pagesCount;
            vm.is_selected_all = false;
            vm.keyword = '';
            vm.order_by = '';
            vm.order_type = '';
            vm.product_list_checked = [];

            vm.GetProductList = GetProductList;
            vm.SelectProduct = SelectProduct;
            vm.selected_all = Selected_all;
            vm.Reload = Reload;
            vm.DeleteMultiple = DeleteMultiple;
            vm.Dlb_Select = Dlb_Select;

            function Dlb_Select(prod_id) {
                $location.path('/product_overview/' + prod_id);
            }

            function DeleteMultiple() {
                if (vm.product_list_checked.length <= 0) {
                    NotifyService.Shows('error', 'Please choose a record ...');
                    return;
                }

                var list_product_short = [];

                angular.forEach(vm.product_list_checked, (item) => {
                    var i = {
                        ID: item.id,
                        Name: item.name
                    }

                    list_product_short.push(i);
                })

                $ngBootbox.confirm({ message: 'Are you sure you want to delete?', title: 'Delete ' + vm.product_list_checked.length + ' record ?' })
                    .then(() => {
                        var config = {
                            params: {
                                productListIdJson: JSON.stringify(list_product_short)
                            }
                        }

                        //console.log(list_product_short);
                        CRUDService.del('/api/ProductAPI/delete', config, (res) => {
                            NotifyService.Shows('success', `Deleted ${res.data.result} record.`);
                            GetProductList(vm.page, vm.status.id);
                        }, (err) => {
                            NotifyService.Shows('error', 'An error occurred while deleting.');
                        });
                    })
            }

            function Reload() {
                GetProductList(vm.page, vm.status.id);
                vm.is_selected_all = false;
            }

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

            vm.$watch('product_list', function (n, o) {
                var selected_list = $filter('filter')(n, { selected: true, });

                vm.product_list_checked = selected_list;

                if (selected_list.length) {
                    if (selected_list.length == n.length) {
                        vm.is_selected_all = true;
                    }
                    else {
                        vm.is_selected_all = false;
                    }
                }
            }, true);

            function Selected_all(is_selected_all) {
                vm.is_selected_all = !is_selected_all;

                angular.forEach(vm.product_list, (item) => {
                    item.selected = vm.is_selected_all;
                })
            }

            function SelectProduct(item) {
                item.selected = !item.selected;
            }

            function GetProductList(page, status_id) {
                var config = {
                    params: {
                        page: page,
                        status: status_id,
                        keyword: vm.keyword,
                        order_by: vm.order_by,
                        order_type: vm.order_type
                    }
                }

                CRUDService.get('/api/ProductAPI/get_all', config, (res) => {
                    //console.log(res);
                    var value = res.data.result;
                    vm.totalCount = value.totalCount;
                    vm.product_list = value.data;
                    vm.pagesCount = value.totalPage;
                }, (err) => {
                    NotifyService.Shows('error', 'Get products list falure ...');
                });
            }

            GetProductList(vm.page, vm.status.id);
            GetStatus();
        }])
})(angular.module("ShopEva.Product"));