// create the module and name it scotchApp
var lesFloristApp = angular.module('lesFloristApp', ['ngRoute']);

// configure our routes
lesFloristApp.config(function($routeProvider) {
    $routeProvider

        // route for the funeral page
        .when('/funeral', {
            templateUrl : 'pages/funeral.html',
            controller  : 'funeralController'
        })
});

lesFloristApp.controller('mainController', function($scope) {
    // create a message to display in our view
    $scope.message = 'Everyone come and see how good I look!';
});

// create the controller and inject Angular's $scope
lesFloristApp.controller('funeralController', function($scope) {
    // create a message to display in our view
    $scope.message = 'Everyone come and see how good I look!';
});