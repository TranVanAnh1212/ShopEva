(function (app) {
    'use strict';

    app.directive('pagerDirective', pagerDirective);

    function pagerDirective() {
        return {
            scope: {
                page: '@',
                pagesCount: '@',
                totalCount: '@',
                searchFunc: '&',
                customPath: '@'
            },
            replace: true,
            restrict: 'E',
            templateUrl: '/Clients/Shares/Directives/PagerDirective.html',
            controller: [
                '$scope', function ($scope) {
                    $scope.search = function (i) {
                        if ($scope.searchFunc) {
                            $scope.searchFunc({ page: i });
                        }
                    };

                    $scope.range = function () {
                        if (!$scope.pagesCount) { return []; }
                        var step = 2;
                        var doubleStep = step * 2;
                        var start = Math.max(1, parseInt($scope.page) - step);
                        var end = start + 1 + doubleStep;
                        if (end > parseInt($scope.pagesCount))
                        {
                            end = parseInt($scope.pagesCount);
                        }

                        var ret = [];
                        for (var i = start; i <= end; ++i) {
                            ret.push(i);
                        }

                        return ret;
                    };

                    $scope.pagePlus = function (count) {
                        var pageCounted = +$scope.page + count;

                        if (pageCounted > parseInt($scope.pagesCount))
                            pageCounted = parseInt($scope.pagesCount);

                        return pageCounted;
                    }

                }]
        }
    }

})(angular.module('ShopEva.Common'));