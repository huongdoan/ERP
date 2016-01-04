define(['application-configuration', 'ajaxService'], function (app) {

    app.register.service('accountsService', ['ajaxService', function (ajaxService) {

        this.registerUser = function (user, successFunction, errorFunction) {
            ajaxService.AjaxPostWithNoAuthenication(user, "/api/user/RegisterUser", successFunction, errorFunction);
        };

        this.login = function (user, successFunction, errorFunction) {
            ajaxService.AjaxPostWithNoAuthenication(user, "/api/user/Login", successFunction, errorFunction);
        };

        this.getUser = function (successFunction, errorFunction) {
            ajaxService.AjaxGet("/api/user/GetUser", successFunction, errorFunction);
        };        

        this.updateUser = function (user, successFunction, errorFunction) {
            ajaxService.AjaxPost(user, "/api/user/UpdateUser", successFunction, errorFunction);
        };

    }]);
});