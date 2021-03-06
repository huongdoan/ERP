﻿"use strict";

define(['application-configuration', 'angular-animate', 'ui-bootstrap', 'productService', 'alertsService'], function (app) {

    app.register.controller('productController', ['$scope', '$rootScope', '$routeParams', 'productService', 'alertsService', '$uibModal', function ($scope, $rootScope, $routeParams, productService, alertsService, $uibModal) {

        $scope.item = {};
        $scope.animationsEnabled = true;
        $scope.open = function (size) {

            var modalInstance = $uibModal.open({
                animation: $scope.animationsEnabled,
                templateUrl: 'myModalContent.html',
                controller: 'productModalController',
                size: size,
                resolve: {
                    items: function () {
                        return $scope.item;
                    }
                }
            });
            modalInstance.result.then(function (selectedItem) {
                $scope.selected = selectedItem;
            }, function () {
                //after 
            });
        };



        $scope.EditClick = function (row) {
        };

        $scope.Delete = function (grid, row) {
        };



        $scope.gridOptions = {
            paginationPageSizes: [25, 50, 75],
            paginationPageSize: 25,
            useExternalPagination: true,
            useExternalSorting: true,
            columnDefs: [
              { name: 'Name' },
              { name: 'Code'},
              { name: 'Description' },
              { name: 'UnitPrice' },
              { name: 'Action', cellEditableCondition: false, cellTemplate: '<button type="button" class="btn btn-primary btn-sm" ng-click="grid.appScope.EditClick(row)">Edit</button> <button type="button" class="btn btn-primary btn-sm" ng-click="DeleteClick(grid,row)">Delete</button>' }
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
            $scope.gridOptions.data = data.Results;
        };

        var failGetPage = function(data){

        };
         getPage();



        

    }]);





    app.register.controller('productModalController', ['$scope', '$rootScope', '$routeParams', 'productService', 'alertsService', '$uibModalInstance', 'items', function ($scope, $rootScope, $routeParams, productService, alertsService, $uibModalInstance, items) {

        $scope.ok = function () {
            $uibModalInstance.close($scope.selected.item);
        };

        $scope.cancel = function () {
            $uibModalInstance.dismiss('cancel');
        };


        //Create Page Session
        $scope.initializeController = function () {

            var productId = ($routeParams.Id || "");

            $rootScope.applicationModule = "Products";
            $rootScope.alerts = [];

            $scope.productId = productId;

            if (productId == "") {

                $scope.Code = "";
                $scope.Name = "";
                $scope.Description = "";
                $scope.UnitPrice = "0.00";
                $scope.UnitOfMeasure = "";

                $scope.setOriginalValues();

                $scope.EditMode = true;
                $scope.DisplayMode = false;

                $scope.ShowCreateButton = true;
                $scope.ShowEditButton = false;
                $scope.ShowCancelButton = false;
                $scope.ShowUpdateButton = false;

            }
            else {
                //var getProduct = new Object();
                //getProduct.ProductID = productID;
                //productService.getProduct(getProduct, $scope.getProductCompleted, $scope.getProductError);

            }

        }


        $scope.setOriginalValues = function () {

            $scope.OriginalCode = $scope.Code;
            $scope.OriginalName = $scope.Name;
            $scope.OriginalWebSiteURL = $scope.WebSiteURL;

        }

        $scope.resetValues = function () {

            $scope.Code = $scope.OriginalCode;
            $scope.Name = $scope.OriginalName;

        }

        $scope.cancelChanges = function () {

            $scope.ShowCreateButton = false;
            $scope.ShowEditButton = true;
            $scope.ShowCancelButton = false;
            $scope.ShowUpdateButton = false;
            $scope.EditMode = false;
            $scope.DisplayMode = true;
            $rootScope.alerts = [];

            $scope.resetValues();
        }

        $scope.createProduct = function () {

            var product = $scope.createProductObject();
            productService.createProduct(product, $scope.createProductCompleted, $scope.createProductError);
        }

        $scope.createProductCompleted = function (response, status) {

            $scope.EditMode = false;
            $scope.DisplayMode = true;
            $scope.ShowCreateButton = false;
            $scope.ShowEditButton = true;
            $scope.ShowCancelButton = false;

            $scope.ProductId = response.Product.Id;
            alertsService.RenderSuccessMessage(response.ReturnMessage);

            $scope.setOriginalValues();
        }

        $scope.createProductError = function (response) {
            alertsService.RenderErrorMessage(response.ReturnMessage);
            $scope.clearValidationErrors();
            alertsService.SetValidationErrors($scope, response.ValidationErrors);
        }

        $scope.clearValidationErrors = function () {

            $scope.CodeInputError = false;
            $scope.NameInputError = false;

        }
        $scope.createProductObject = function () {

            var product = new Object();

            product.Code = $scope.Code;
            product.Name = $scope.Name;
            product.Description = $scope.Description;
            product.ProductType = $scope.ProductType;
            product.FileName = $scope.FileName;
            product.UnitPrice = $scope.UnitPrice;
            product.UnitOfMeasure = $scope.UnitOfMeasure;

            return product;

        }

        $scope.initializeController();
    }]);
});


