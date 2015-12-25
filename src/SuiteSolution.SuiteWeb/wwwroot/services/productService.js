define(['application-configuration', 'ajaxService'], function (app) {

    app.register.service('productService', ['ajaxService', function (ajaxService) {


        this.importProducts = function (successFunction, errorFunction) {
            ajaxService.AjaxGet("/api/product/ImportProducts", successFunction, errorFunction);
        };

        this.getProducts = function (product, successFunction, errorFunction) {
            ajaxService.AjaxGetWithData(product, "/api/product", successFunction, errorFunction);
        };
             
        this.getProductsWithNoBlock = function (product, successFunction, errorFunction) {
            ajaxService.AjaxGetWithNoBlock(product, "/api/product/GetProducts", successFunction, errorFunction);
        };

        this.createProduct = function (product, successFunction, errorFunction) {
            ajaxService.AjaxPost(product, "/api/product/CreateProduct", successFunction, errorFunction);
        };

        this.updateProduct = function (product, successFunction, errorFunction) {
            ajaxService.AjaxPost(product, "/api/product/UpdateProduct", successFunction, errorFunction);
        };

        this.getProduct = function (productID, successFunction, errorFunction) {
            ajaxService.AjaxGetWithData(productID, "/api/product/GetProduct", successFunction, errorFunction);
        };

        

    }]);
});