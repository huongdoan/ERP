(function () {
    'use strict';

    angular
        .module('app')
        .controller('productController', productController);

    productController.$inject = ['$scope']; 

    function productController($scope) {
        $scope.title = 'productController';

        activate();

        function activate() { }
    }
})();
