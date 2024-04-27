/// <reference path="../../../lib/angular.js/angular.js" />

(function (app) {
    app.controller('ProductCategoryOverviewController', ProductCategoryOverviewController);

    ProductCategoryOverviewController.$inject = ['$scope', '$state', '$stateParams', 'CRUDService', 'NotifyService', 'CommonService'];

    function ProductCategoryOverviewController($scope, $state, $stateParams, CRUDService, NotifyService, CommonService) {
        var vm = $scope;

        vm.ProductCategoryID = $stateParams.id;

        vm.AddAction = true;
        vm.EditMode = false;
        vm.Saved = false;
        vm.ProductCategory = {};
        vm.ProductCategoryGlobal;
        vm.ParentList;
        vm.Parent;
        vm.StatusList;
        vm.Productcategory_Status;
        vm.submitted = false;

        vm.SaveAdd = SaveAdd;
        vm.Edit = Edit;
        vm.Close = Close;
        vm.GetSEOTitle = GetSEOTitle;
        vm.updateDescriptionValue = updateDescriptionValue;
        vm.ChooseImage = ChooseImage;

        function ChooseImage() {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                vm.$apply(function () {
                    vm.ProductCategory.image = fileUrl;
                })
            }
            finder.popup();
        }

        function GetSEOTitle() {
            vm.ProductCategory.alias = CommonService.GetSEOTitle(vm.ProductCategory.name);
        }

        (function Init() {
            if (vm.ProductCategoryID) {
                GetByID(vm.ProductCategoryID);
                vm.AddAction = false;
                vm.EditMode = false;
                vm.Saved = true;
            }
        })();

        function updateDescriptionValue(editor) {
            var value = editor.getData();
            $scope.$apply(function () {
                $scope.ProductCategory.description = value;
            });
        }

        function GetByID(id) {
            var config = {
                params: {
                    id: id
                }
            }

            CRUDService.get('/api/ProductCategoryAPI/getbyid', config, (result) => {
                console.log(result);
                var value = result.data;

                vm.ProductCategory = value.result;
                vm.ProductCategoryID = value.result.id;

                angular.forEach(vm.ParentList, (item) => {
                    if (item.id === value.result.parentID) {
                        vm.Parent = angular.copty(item);
                    }
                })

            }, (error) => {
                NotifyService.Shows('error', 'Cannot get record');
            });
        }

        function SaveAdd(invalid) {
            debugger;

            vm.submitted = invalid;

            if (vm.submitted)
                return;

            vm.ProductCategory.parentID = !vm.Parent ? null : vm.Parent.id;
            vm.ProductCategory.status = vm.Productcategory_Status.id;

            if (vm.AddAction)
                CRUDService.post('/api/ProductCategoryAPI/addnew', vm.ProductCategory, (result) => {
                    vm.AddAction = false;
                    vm.EditMode = false;
                    vm.submitted = false;
                    vm.Saved = true;

                    vm.ProductCategoryGlobal = result.data.result;
                    vm.ProductCategory = angular.copy(vm.ProductCategoryGlobal);
                    vm.ProductCategoryID = vm.ProductCategory.id;

                    localStorage.setItem('ls.ProductCategory', JSON.stringify(vm.ProductCategory));

                    NotifyService.Shows('success', 'Add new successfully.');
                }, (err) => {
                    NotifyService.Shows('error', 'Cannot create, some wrong...');
                });
            else
                CRUDService.put('/api/ProductCategoryAPI/update', vm.ProductCategory, (result) => {
                    var value = result.data;
                    if (value.result.id === vm.ProductCategoryID) {

                        vm.AddAction = false;
                        vm.EditMode = false;
                        vm.submitted = false;
                        vm.Saved = true;

                        vm.ProductCategoryGlobal = value.result;
                        vm.ProductCategory = angular.copy(vm.ProductCategoryGlobal);
                        vm.ProductCategoryID = vm.ProductCategory.id;

                        localStorage.setItem('ls.ProductCategory', JSON.stringify(vm.ProductCategory));

                        NotifyService.Shows('success', 'Update product category successfully!');
                    }
                }, (err) => {
                    NotifyService.Shows('error', 'Cannot create, some wrong...');
                });
        }

        function Edit() {
            vm.EditMode = true;
            vm.AddAction = false;
            vm.Saved = false;
        }

        $(window).on('load', function () {
            var ls = JSON.parse(localStorage.getItem('ls.ProductCategory'));

            if (ls) {
                vm.ProductCategoryGlobal = ls;
                vm.ProductCategory = angular.copy(vm.ProductCategoryGlobal);

                vm.AddAction = false;
                vm.EditMode = false;
                vm.submitted = false;
                vm.Saved = true;
            }
        });

        function Close() {
            if (vm.EditMode) {
                localStorage.removeItem('ls.ProductCategory');
                $state.go('product_category');
            }
            else {
                localStorage.removeItem('ls.ProductCategory');
                $state.go('product_category');
            }
        }

        function GetStatus() {
            var config = {
                params: {
                    status_of: 1
                }
            }

            CRUDService.get('/api/StatusAPI/get_status', config, (result) => {
                vm.StatusList = result.data.result;
                vm.Productcategory_Status = vm.StatusList['0'];
            }, (err) => {
                NotifyService.Shows('error', 'Cannot get data, an error occurred!');
            });
        }

        function GetParentCategory() {
            var current_id = vm.ProductCategoryID ?? null;

            var config = {
                params: {
                    id: current_id
                }
            }

            CRUDService.get('/api/ProductCategoryAPI/get_parent', config, (result) => {
                vm.ParentList = result.data.result;
            }, (err) => {
                NotifyService.Shows('error', 'Cannot get data, an error occurred!');
            });
        }

        GetStatus();
        GetParentCategory();
    }


    app.filter('propsFilter', function () {
        return function (items, props) {
            var out = [];

            if (angular.isArray(items)) {
                var keys = Object.keys(props);

                items.forEach(function (item) {
                    var itemMatches = false;

                    for (var i = 0; i < keys.length; i++) {
                        var prop = keys[i];
                        var text = props[prop].toLowerCase();
                        if (item[prop].toString().toLowerCase().indexOf(text) !== -1) {
                            itemMatches = true;
                            break;
                        }
                    }

                    if (itemMatches) {
                        out.push(item);
                    }
                });
            } else {
                // Let the output be the input untouched
                out = items;
            }

            return out;
        };
    });

})(angular.module('ShopEva.ProductCategory'));