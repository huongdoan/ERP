"use strict";

define(['application-configuration', 'productService', 'alertsService'], function (app) {

    app.register.controller('productController', ['$scope', '$rootScope', 'productService', 'alertsService', function ($scope, $rootScope, productService, alertsService) {
        $scope.gridOptions = {
            paginationPageSizes: [25, 50, 75],
            paginationPageSize: 25,
            useExternalPagination: true,
            useExternalSorting: true,
            columnDefs: [
              { name: 'name' },
              { name: 'code'},
              { name: 'description' }
            ],
            onRegisterApi: function (gridApi) {
                $scope.gridApi = gridApi;
                $scope.gridApi.core.on.sortChanged($scope, function (grid, sortColumns) {
                    if (sortColumns.length == 0) {
                        paginationOptions.sort = null;
                    } else {
                        paginationOptions.sort = sortColumns[0].sort.direction;
                    }
                    getPage();
                });
                gridApi.pagination.on.paginationChanged($scope, function (newPage, pageSize) {
                    paginationOptions.pageNumber = newPage;
                    paginationOptions.pageSize = pageSize;
                    getPage();
                });
            }
        };

        var getPage = function () {

            var criteria = {

            };

            productService.getProducts(criteria, susccessGetPage, failGetPage)
            //var url;
            //switch (paginationOptions.sort) {
            //    case uiGridConstants.ASC:
            //        url = '/data/100_ASC.json';
            //        break;
            //    case uiGridConstants.DESC:
            //        url = '/data/100_DESC.json';
            //        break;
            //    default:
            //        url = '/data/100.json';
            //        break;
            //}

            //$http.get(url)
            //.success(function (data) {
            //    $scope.gridOptions.totalItems = 100;
            //    var firstRow = (paginationOptions.pageNumber - 1) * paginationOptions.pageSize;
            //    $scope.gridOptions.data = data.slice(firstRow, firstRow + paginationOptions.pageSize);
            //});
        };


        var susccessGetPage = function(data){
            $scope.gridOptions.totalItems = data.TotalCount;
            $scope.gridOptions.data = data;
        };

        var failGetPage = function(data){

        };


    }]);
});


