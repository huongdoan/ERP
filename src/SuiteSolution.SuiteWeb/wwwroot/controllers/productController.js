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


    define(['application-configuration', 'ui-grid', 'productService', 'alertsService'], function (app) {
        app.register.controller('productController', ['$scope', '$rootScope', 'productService', 'alertsService', function ($scope, $rootScope, productService, alertsService) {

            $scope.gridOptions = {
                paginationPageSizes: [25, 50, 75],
                paginationPageSize: 10,
                useExternalPagination: true,
                useExternalSorting: true,
                enableGridMenu: true,
                columnDefs: [
                  { name: 'name' },
                  { name: 'code'},
                  { name: 'description'},
                  {name: 'UnitPrice'}
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

            var getPage = function (curPage, pageSize, sort) {
                var url;
                switch (sort) {
                    case uiGridConstants.ASC:
                        url = '/data/100_ASC.json';
                        break;
                    case uiGridConstants.DESC:
                        url = '/data/100_DESC.json';
                        break;
                    default:
                        url = '/data/100.json';
                        break;
                }

                var _scope = $scope;
                return $http.get(url)
                .success(function (data) {
                    var firstRow = (curPage - 1) * pageSize;
                    $scope.gridOptions.totalItems = 100;
                    $scope.gridOptions.data = data.slice(firstRow, firstRow + pageSize)
                });
            };

            getPage(1, $scope.gridOptions.paginationPageSize);


        }]);
    });



})();
