'use strict';
app.controller('itemsController', ['$scope', 'itemsService', function ($scope, itemsService) {

    $scope.items = [];

    itemsService.getItems().then(function (results) {

        $scope.items = results.data;

    }, function (error) {
        alert(error.data.message);
    });

}]);