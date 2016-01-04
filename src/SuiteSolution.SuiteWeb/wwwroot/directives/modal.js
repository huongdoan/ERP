"use strict";

define(['application-configuration'], function (app) {
    app.register.factory('modal', [ function () {
        return {
            itemForm: {
                on: false
            },
            accountSelector: {
                on: false
            },
            contraSelector: {
                on: false
            },
            close: function (boxName) {
                this[boxName].on = false;
            }
        };

    }]);
});


