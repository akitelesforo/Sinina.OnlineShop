'use strict';
app.controller('emailconfirmationController', ['$scope', 'authService', function ($scope, authService) {

    var init = function () {
        authService.confirmEmail();
    };

    init();
}]);