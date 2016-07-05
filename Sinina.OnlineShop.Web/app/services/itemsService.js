'use strict';
app.factory('itemsService', ['$http', 'ngAuthSettings', function ($http, ngAuthSettings) {

    var serviceBase = ngAuthSettings.apiServiceBaseUri;

    var itemsServiceFactory = {};

    var _getItems = function () {

        return $http.get(serviceBase + 'api/items').then(function (results) {
            return results;
        });
    };

    itemsServiceFactory.getItems = _getItems;

    return itemsServiceFactory;

}]);