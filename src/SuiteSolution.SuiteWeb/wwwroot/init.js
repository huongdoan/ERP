/// <reference path="Scripts/ui-bootstrap-tpls-0.11.0.js" />
/// <reference path="Scripts/ui-bootstrap-tpls-0.11.0.js" />
/// <reference path="Scripts/ui-bootstrap-tpls-0.11.0.js" />
/// <reference path="controllers/indexcontroller.js" />
require.config({

    baseUrl: "",
    // alias libraries paths
    paths: {
        'application-configuration': 'application-configuration',
        'angular': 'lib/angular/angular',
        'angular-route': 'lib/angular-route/angular-route',
        'angularAMD': 'lib/angularAMD/angularAMD',
        'ui-bootstrap': 'lib/angular-ui-bootstrap-bower/ui-bootstrap-tpls',
        'ui-grid': 'lib/angular-ui-grid/ui-grid',
        'angular-touch': 'lib/angular-touch/angular-touch',
        'angular-animate': 'lib/angular-animate/angular-animate',
        'blockUI': 'lib/angular-block-ui/dist/angular-block-ui',
        'ngload': 'lib/angularAMD/ngload',
        'angular-sanitize': 'lib/angular-sanitize/angular-sanitize',
        'mainService': 'services/mainServices',
        'ajaxService': 'services/ajaxServices',
        'alertsService': 'services/alertsServices',
        'accountsService': 'services/accountsServices',
        'customersService': 'services/customersServices',
        'productService': 'services/productService',
        'defaultController': 'controllers/defaultController',
        'loginController': 'controllers/loginController',
        'productController': 'controllers/productController'
    },

    // Add angular modules that does not support AMD out of the box, put it in a shim
    shim: {
        "angular": { exports: "angular" },
        'angularAMD': ['angular'],
        'angular-route': ['angular'],
        'blockUI': ['angular'],
        'angular-sanitize': ['angular'],
        'ui-bootstrap': ['angular'],
        'ui-grid': ['angular'],
        'angular-animate': ['angular'],
        'angular-touch': ['angular'],
        'ngload': ['angularAMD']

    },

    // kick start application
    deps: ['application-configuration']
});
