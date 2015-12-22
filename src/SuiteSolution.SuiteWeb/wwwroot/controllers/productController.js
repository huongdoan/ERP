(function () {
    'use strict';

    //angular
    //    .module('app')
    //    .controller('productController', productController);

    //productController.$inject = ['$scope']; 

    //function productController($scope) {
    //    $scope.title = 'productController';

    //    activate();

    //    function activate() { }
    //}
    define(['application-configuration', 'ui-grid', 'angular-touch', 'angular-animate', 'productService', 'alertsService'], function (app) {
        app.register.controller('productController', ['$scope', '$rootScope', 'productService', 'alertsService', function ($scope, $rootScope, productService, alertsService) {
            var paginationOptions = {
                sort: null
            };

            $scope.gridOptions = {
                paginationPageSizes: [25, 50, 75],
                paginationPageSize: 25,
                useExternalPagination: true,
                useExternalSorting: true,
                enableGridMenu: true,
                columnDefs: [
                  { name: 'name' },
                  { name: 'gender', enableSorting: false },
                  { name: 'company', enableSorting: false }
                ],
                exporterAllDataFn: function () {
                    return getPage(1, $scope.gridOptions.totalItems, paginationOptions.sort)
                    .then(function () {
                        $scope.gridOptions.useExternalPagination = false;
                        $scope.gridOptions.useExternalSorting = false;
                        getPage = null;
                    });
                },
                onRegisterApi: function (gridApi) {
                    $scope.gridApi = gridApi;
                    $scope.gridApi.core.on.sortChanged($scope, function (grid, sortColumns) {
                        if (getPage) {
                            if (sortColumns.length > 0) {
                                paginationOptions.sort = sortColumns[0].sort.direction;
                            } else {
                                paginationOptions.sort = null;
                            }
                            getPage(grid.options.paginationCurrentPage, grid.options.paginationPageSize, paginationOptions.sort)
                        }
                    });
                    gridApi.pagination.on.paginationChanged($scope, function (newPage, pageSize) {
                        if (getPage) {
                            getPage(newPage, pageSize, paginationOptions.sort);
                        }
                    });
                }
            };


        }]);
    });



})();
