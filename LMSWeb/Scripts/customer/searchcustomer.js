var app = angular.module("lmsapp", []);
app.controller("customersearchcontroller", function ($scope, $http, $log, $location)
{
    $log.log("customersearchcontroller initialiszed");
    var oHttp = $http({ "method": "get", "url": "/Customer/SearchCustomers" });
    bindCustomers($scope, oHttp, $log, $location);
});

var bindCustomers=function(scopeObj, httpObj, logObj, locationObj)
{
    httpObj.then(function bindCustomersSuccess(response) {
        logObj.log("bindCustomersSuccess");
        scopeObj.customers = response.data;
    },
                function bindCustomersError(response){}
        )

}