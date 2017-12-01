var app = angular.module("lmsapp", []);
app.controller("usersearchcontroller", function ($scope, $http) {


    //console.log('user search screen loaded');

    $http({ "method": "get", "url": "/LMSHome/SearchUserData" }).then(
        function usersearchsucess(response) { $scope.users = response.data; },
        function usersearcherror(response) { console.log(response.data); }
        )
});