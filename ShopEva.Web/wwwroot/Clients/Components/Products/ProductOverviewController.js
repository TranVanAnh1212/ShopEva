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
            vm.CategoryList = [];
            vm.GetSEOTitle = GetSEOTitle;
            vm.SaveAdd = SaveAdd;
            vm.Edit = Edit;


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

            function GetCategory() {
                CRUDService.get('/api/ProductCategoryAPI/get_parent', null, (result) => {
                    //console.log(result);
                    vm.CategoryList = result.data.result;
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

            GetStatus();
            GetCategory();
        }]);

})(angular.module('ShopEva.Product'));