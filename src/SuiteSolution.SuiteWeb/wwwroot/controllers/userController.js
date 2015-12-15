(function () {
    'use strict';
    angular
        .module('AngularSuiteApp')
        .controller('userController', userController);

    userController.$inject = ['$scope','User']; 

    function userController($scope, User) {
        $scope.title = 'userController';
        $scope.Users = User.listUser.query();
        User.login(1,2);
        console.log($scope.Users);
    }

    function logIn() {

    }

})();
