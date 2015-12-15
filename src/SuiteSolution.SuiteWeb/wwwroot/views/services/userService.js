(function () {
    'use strict';
    var userService = angular.module('AngularSuiteApp', ['ngResource']);

    userService.factory('User', User);

    User.$inject = ['$resource'];



    function User($resource) {
        var service = {
            listUser: getData($resource),
            login: login
        }
        //return $resource('/api/user', {}, {
        //    query: { method: 'GET', params: {}, isArray: true }
        //});
        //var service = {
        //    getData: getData($resource)
        //};

        return service;

        function getData($resource) {
            return $resource('/api/user', {}, {
                query: { method: 'GET', params: {}, isArray: true }
            });
        }

        function login(user, pass) {

        }
    }

 
})();