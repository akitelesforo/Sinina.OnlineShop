'use strict';
app.controller('signupController', ['$scope', '$location', '$timeout', 'authService', 'commonService', function ($scope, $location, $timeout, authService, commonService) {

    $scope.savedSuccessfully = false;
    $scope.message = "";

    $scope.registration = {
        userName: "",
        password: "",
        confirmPassword: ""
    };

    $scope.signUp = function () {

        if (!commonService.isBlank($scope.registration.userName) &&
            !commonService.isBlank($scope.registration.password) &&
            !commonService.isBlank($scope.registration.confirmPassword)) {

            authService.saveRegistration($scope.registration).then(function (response) {

                $scope.savedSuccessfully = true;
                $scope.message = "User has been registered successfully, you will be redicted to login page in 2 seconds.";
                startTimer();

            },
             function (response) {
                 var errors = [];
                 for (var key in response.data) {
                     errors.push(response.data[key]);
                 }
                 $scope.message = "Failed to register user due to:" + errors.join(' ');
             });

        }
    };

    var startTimer = function () {
        var timer = $timeout(function () {
            $timeout.cancel(timer);
            $location.path('/login');
        }, 2000);
    }

}]);