'use strict';
app.factory('commonService', ['$http', 'ngAuthSettings', function ($http, ngAuthSettings) {

    var serviceBase = ngAuthSettings.apiServiceBaseUri;

    var commonServiceFactory = {};

    var _isBlank = function (str) {

        return (!str || /^\s*$/.test(str));
    };

    commonServiceFactory.isBlank = _isBlank;

    return commonServiceFactory;

}]);