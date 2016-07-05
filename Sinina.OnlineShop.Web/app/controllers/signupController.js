'use strict';
app.controller('signupController', ['$scope', '$location', '$timeout', 'authService', 'commonService', function ($scope, $location, $timeout, authService, commonService) {

    $scope.savedSuccessfully = false;
    $scope.message = "";

    $scope.registration = {
        userName: "",
        email: "",
        password: "",
        confirmPassword: ""
    };

    $scope.signUp = function () {

        if (!commonService.isBlank($scope.registration.userName) &&
            !commonService.isBlank($scope.registration.email) &&
            !commonService.isBlank($scope.registration.password) &&
            !commonService.isBlank($scope.registration.confirmPassword)) {

            authService.saveRegistration($scope.registration).then(function (response) {

                $scope.savedSuccessfully = true;
                $scope.message = "User has been registered successfully, you will be redicted to login page in 2 seconds.";
                startTimer();

            },
             function (response) {
                 var errors = [];
                 if (response.data.modelState) {
                     for (var key in response.data.modelState) {
                         for (var i = 0; i < response.data.modelState[key].length; i++) {
                             errors.push(response.data.modelState[key][i]);
                         }
                     }
                 } else {
                     for (var key in response.data) {
                         errors.push(response.data[key]);
                     }
                 }
                 
                 $scope.message = "Failed to register user due to: " + errors.join(' ');
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