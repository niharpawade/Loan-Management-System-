var app = angular.module("lmsapp", []);
app.controller("loansearchcontroller", function ($scope, $http, $log, $location) {
    $log.log("loansearchcontroller initialiszed");
    $http({ "method": "get", "url": "/Loan/SearchLoan", }).then(
        function questionssuccess(response) { $scope.loans = response.data; $log.log($scope.loans) },
        function questionserror(response) { }
    );
   

    
    $scope.getcustomername = function (ID)
    {
        var entity = {};
        entity.ID = ID;
        $log.log(ID)
        $log.log("hello im triggered");
        $http({
            "method": "post",
            "url": "/Lookup/GetCustomerById",
            "data": entity
        }).then(
            function questionssuccess(response) {
                

                $scope.customer = response.data;
                $log.log($scope.customer);

                //$log.log(customer);

                
                
            },
            function questionserror(response) { }
        );
        

    }
   
    

});


