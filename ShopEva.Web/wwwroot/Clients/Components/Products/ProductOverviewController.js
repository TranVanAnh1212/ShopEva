(function (app) {

    app.controller('ProductOverviewController', ['$scope', '$state', '$stateParams', 'CommonService', 'CRUDService',
                    'NotifyService',
        function ($scope, $state, $stateParams, CommonService, CRUDService, NotifyService) {
            var vm = $scope;

            
            vm.ProductID = $stateParams.id;

            vm.Saved = false;
            vm.EditMode = false;
            vm.AddAction = true;
            vm.Product = {};
            vm.ProductDetail = {};
            vm.StatusList = [];
            vm.Product_Status;
            vm.submitted = false;
            vm.Category;
            vm.CategoryShow = '';
            vm.CategoryList = [];
            vm.CategoryListChildrent1 = [];
            vm.Brands = [];
            vm.Brand;
            vm.SaveAdd = SaveAdd;
            vm.Edit = Edit;
            vm.SelectedCategory = '';

            // FUNCTION 
            vm.GetSEOTitle = GetSEOTitle;
            vm.GetChildrent = GetChildrent;
            vm.ChoosecategorySubmit = ChooseCategorySubmit;

            function ChooseCategorySubmit() {
                vm.SelectedCategory = vm.CategoryShow;

                $('#productCategoryModal').modal('hide');
            }

            var name_root = '';
            var name_child_1 = '';
            var name_child_2 = '';
            function GetChildrent(prodCateg, parentID, index) {
                if (index == 1) {
                    name_root = prodCateg.name;
                    vm.CategoryShow = name_root;

                    //$(`#prodCate-root-${parentID}`).on('click', function () {
                    //    $(this).addClass('selected-item');
                    //})
                }

                if (index == 2) {
                    name_child_1 = prodCateg.name;
                    vm.CategoryShow = `${name_root} > ${name_child_1}`;
                }

                var config = {
                    params: {
                        id: parentID,
                        index: index
                    }
                }

                CRUDService.get('/api/ProductCategoryAPI/get-all-by-parent-id', config, function (res) {
                    if (index == 1) {
                        vm.CategoryListChildrent1 = res.data.result;
                    }
                }, function (err) {
                    NotifyService.error(err.message);
                })
            }

            (function Init() {
                if (vm.ProductID) {
                    GetByID(vm.ProductID);
                    vm.AddAction = false;
                    vm.EditMode = false;
                    vm.Saved = true;
                }
            })();

            function Edit() {

            }

            function SaveAdd(invalid) {
                debugger

                vm.submitted = invalid;

                if (vm.submitted) return;
                
                vm.Product.status = vm.Product_Status ? vm.Product_Status.id : '';

                var Product2Category = [];

                angular.forEach(vm.Category, (item) => {
                    var p2c = {
                        CategoryID: item.id
                    }

                    Product2Category.push(p2c);
                })

                var data = {
                    ProductViewModel: vm.Product,
                    Product2CategoryViewModel: Product2Category,
                }

                CRUDService.post('/api/ProductAPI/create_new', data, (res) => {
                    console.log(res.data);

                    var value = res.data;

                    vm.Product = value.result.productViewModel;
                    vm.Category = value.result.product2CategoryViewModel;

                    vm.Saved = true;
                    vm.EditMode = false;
                    vm.AddAction = false;

                    NotifyService.Shows('success', 'Create new product successfully ... ');
                }, (err) => {
                    console.error(err);
                    NotifyService.Shows('error', 'Cannot save product ...');
                });

            }

            function GetByID(id) {
                var config = {
                    params: {
                        id: id
                    }
                }

                CRUDService.get('/api/ProductAPI/get_by_id', config, (result) => {
                    console.log(result);
                    var value = result.data;

                    vm.Product = value.result.product;
                    vm.Category = value.result.product_categories;
                    vm.ProductDetail = value.result.product_detail;
                    vm.ProductID = value.result.product.id;

                }, (error) => {
                    NotifyService.Shows('error', 'Cannot get produc ...');
                });
            }

            function GetCategory(index) {
                CRUDService.get(`/api/ProductCategoryAPI/getall?status=1&page=1&order_type=ASC&index=${index}`, null, (result) => {
                    console.log(result);
                    vm.CategoryList = result.data.result.data;
                }, (err) => {
                    NotifyService.Shows('error', 'Cannot get data, an error occurred!');
                });
            }

            function GetSEOTitle() {
                console.log('đasadasdsa')

                vm.Product.alias = CommonService.GetSEOTitle(vm.Product.name);
            }

            function GetStatus() {
                var config = {
                    params: {
                        status_of: 1
                    }
                }

                CRUDService.get('/api/StatusAPI/get_status', config, (result) => {
                    vm.StatusList = result.data.result;
                    vm.Product_Status = vm.StatusList['0'];
                }, (err) => {
                    NotifyService.Shows('error', 'Cannot get data, an error occurred!');
                });
            }

            function GetBrand() {
                CRUDService.get('/api/BrandAPI/get_all?status=1&order_by=name&order_type=ASC&page=1&page_size=20', null, function (res) {
                    vm.Brands = res.data.result.data;
                }, function (err) {
                    NotifyService.Shows('error', 'Cannot get data, an error occurred!');
                });
            }

            GetStatus();
            GetCategory(0);
            GetBrand();
        }]);

})(angular.module('ShopEva.Product'));