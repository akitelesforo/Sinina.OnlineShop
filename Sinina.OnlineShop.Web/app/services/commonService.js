'use strict';
app.factory('commonService', ['$http', 'ngAuthSettings', function ($http, ngAuthSettings) {

    var serviceBase = ngAuthSettings.apiServiceBaseUri;

    var commonServiceFactory = {};

    var _isBlank = function (str) {

        return (!str || /^\s*$/.test(str));
    };

    var _getQueryString = function (name, url) {

        if (!url) url = window.location.href;
        name = name.replace(/[\[\]]/g, "\\$&");
        var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
            results = regex.exec(url);
        if (!results) return null;
        if (!results[2]) return '';
        return decodeURIComponent(results[2].replace(/\+/g, " "));

    }

    commonServiceFactory.isBlank = _isBlank;
    commonServiceFactory.getQueryString = _getQueryString;

    return commonServiceFactory;

}]);