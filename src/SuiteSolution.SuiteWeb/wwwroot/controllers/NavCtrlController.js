(function () {
    'use strict';

    angular
        .module('AngularSuiteApp')
        .controller('NavCtrl', NavCtrlController);

    NavCtrlController.$inject = ['$rootScope', '$scope', '$location', 'Auth']; 

    function NavCtrlController($rootScope, $scope, $location, Auth) {
        $scope.title = 'NavCtrlController';

        activate($rootScope, $scope, $location, Auth);

        function activate($rootScope, $scope, $location, Auth) {
            $scope.user = Auth.user;
            $scope.userRoles = Auth.userRoles;
            $scope.accessLevels = Auth.accessLevels;

            $scope.logout = function () {
                Auth.logout(function () {
                    $location.path('/login');
                }, function () {
                    $rootScope.error = "Failed to logout";
                });
            };
        }
    }
})();
