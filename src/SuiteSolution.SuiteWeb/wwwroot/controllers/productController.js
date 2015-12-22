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

        }]);
    });



})();
