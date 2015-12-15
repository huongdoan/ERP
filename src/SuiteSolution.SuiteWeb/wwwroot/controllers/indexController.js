(function () {
    'use strict';

    angular
        .module('AngularSuiteApp')
        .controller('indexController', indexController);

    indexController.$inject = ['$location','$scope', '$rootScope', '$http','blockUI' ]; 

    function indexController($location, $scope, $rootScope, $http, blockUI) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'indexController';

        $scope.$on('$routeChangeStart', function (scope, next, current) {

            if ($rootScope.IsloggedIn == true) {
                $scope.authenicateUser($location.path(), $scope.authenicateUserComplete, $scope.authenicateUserError);
            }

        });

        $scope.$on('$routeChangeSuccess', function (scope, next, current) {

            setTimeout(function () {
                if ($scope.isCollapsed == true) {
                    set95PercentWidth();
                }
            }, 1000);


        });

        activate($rootScope, $scope);

        function activate($rootScope, $scope) {
            $rootScope.displayContent = false;
            if ($location.path() != "") {
                $scope.initializeApplication($scope.initializeApplicationComplete, $scope.initializeApplicationError);
            }
        }

        $scope.initializeApplicationComplete = function (response) {
            $rootScope.MenuItems = response.MenuItems;
            $rootScope.displayContent = true;
            $rootScope.IsloggedIn = true;
        }

        $scope.initializeApplication = function (successFunction, errorFunction) {
            blockUI.start();
            $scope.AjaxGet("/api/main/InitializeApplication", successFunction, errorFunction);
            blockUI.stop();
        };

        $scope.authenicateUser = function (route, successFunction, errorFunction) {
            var authenication = new Object();
            authenication.route = route;
            $scope.AjaxGetWithData(authenication, "/api/main/AuthenicateUser", successFunction, errorFunction);
        };

        $scope.authenicateUserComplete = function (response) {

            if (response.IsAuthenicated == false)
                window.location = "/index.html";
        }

        $scope.authenicateUserError = function (response) {
            alert("ERROR= " + response.IsAuthenicated);
        }
    }
})();
