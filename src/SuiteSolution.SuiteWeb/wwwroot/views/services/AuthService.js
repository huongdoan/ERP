﻿(function () {
    'use strict';

    angular.module('AngularSuiteApp',['ngCookies']).factory('Auth', AuthService);

    AuthService.$inject = ['$http', '$cookieStore'];

    function AuthService($http, $cookieStore) {

        var accessLevels = routingConfig.accessLevels
       , userRoles = routingConfig.userRoles
       , currentUser = $cookieStore.get('user') || { username: '', role: userRoles.public };

        $cookieStore.remove('user');


        var service = {
            authorize: function (accessLevel, role) {
                if (role === undefined) {
                    role = currentUser.role;
                }

                return accessLevel.bitMask & role.bitMask;
            },
            isLoggedIn: function (user) {
                if (user === undefined) {
                    user = currentUser;
                }
                return user.role.title === userRoles.user.title || user.role.title === userRoles.admin.title;
            },
            register: function (user, success, error) {
                $http.post('/register', user).success(function (res) {
                    changeUser(res);
                    success();
                }).error(error);
            },
            login: function (user, success, error) {
                $http.post('/login', user).success(function (user) {
                    changeUser(user);
                    success(user);
                }).error(error);
            },
            logout: function (success, error) {
                $http.post('/logout').success(function () {
                    changeUser({
                        username: '',
                        role: userRoles.public
                    });
                    success();
                }).error(error);
            },
            accessLevels: accessLevels,
            userRoles: userRoles,
            user: currentUser
           
        };

        return service;
        

        function changeUser(user) {
            angular.extend(currentUser, user);
        }
    }
})();