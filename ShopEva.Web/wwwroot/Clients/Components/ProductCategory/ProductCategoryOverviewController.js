/// <reference path="../../../lib/angular.js/angular.js" />

(function (app) {
    app.controller('ProductCategoryOverviewController', ProductCategoryOverviewController);

    ProductCategoryOverviewController.$inject = ['$scope', '$state', '$stateParams', 'CRUDService', 'NotifyService'];

    function ProductCategoryOverviewController($scope, $state, $stateParams, CRUDService, NotifyService) {
        var vm = $scope;

        vm.ProductCategoryID = $stateParams.id;

        vm.AddAction = true;
        vm.EditMode = false;
        vm.AddAction = true;
        vm.ProductCategory = {};
        vm.ProductCategoryGlobal;
        vm.ParentList;
        vm.Parent;
        vm.StatusList;
        vm.Productcategory_Status;
        vm.submitted = false;

        vm.SaveAdd = SaveAdd;
        vm.SaveEdit = SaveEdit;
        vm.Reload = Reload;

        if (vm.ProductCategoryID) {
            GetByID(vm.ProductCategoryID);
            vm.AddAction = false;
        }

        function GetByID(id) {
            var config = {
                params: {
                    id: id
                }
            }

            CRUDService.get('/api/ProductCategoryAPI/getbyid', config, (result) => {
                console.log(result);
            }, (error) => {
                NotifyService.Shows('error', 'Cannot get record');
            });
        }

        function SaveAdd(invalid) {
            vm.submitted = invalid;

            if (vm.submitted)
                return;

            vm.ProductCategory.parentID = !vm.Parent ? null : vm.Parent.id;
            vm.ProductCategory.status = vm.Productcategory_Status.id;

            CRUDService.post('/api/ProductCategoryAPI/addnew', vm.ProductCategory, (result) => {
                console.log(result);
                vm.ProductCategoryGlobal = result.data.result;
                vm.ProductCategory = angular.copy(vm.ProductCategoryGlobal);
                vm.AddAction = false;
                vm.EditMode = false;
                vm.submitted = false;
                NotifyService.Shows('success', 'Add new successfully.');
            }, (err) => {
                console.log(err);
                NotifyService.Shows('error', 'Cannot create, some wrong...');
            });
        }


        function SaveEdit() {
            vm.EditMode = true;
            vm.AddAction = false;


        }

        function Reload() {

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
                console.log(result.data);
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