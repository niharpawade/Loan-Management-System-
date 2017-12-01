var app = angular.module("lmsapp", []);
app.controller("customercontroller", function ($scope, $http, $location, $log)
{
    $log.log("customercontroller initialiszed");
    $scope.gender = "f";
    $scope.present = {};
    $scope.savecustomer = function()
    {
        // Build the customer object
        var customerObject = { "PresentAddress": {}};
        customerObject.ID = -1;
        customerObject.Name = $scope.txtname;
        customerObject.Adhaarno = $scope.Adhaarno;
        customerObject.MobileNo = $scope.MobileNo;
        customerObject.PanCard = $scope.pancard;
        customerObject.DOB = $scope.dob;
        customerObject.Gender = $scope.gender;
        customerObject.AnnualIncome = $scope.AnnualIncome;
        customerObject.PresentAddress.Address1 = $scope.present.address1;
        customerObject.PresentAddress.Address2 = $scope.present.address2;
        customerObject.PresentAddress.City = $scope.present.city;
        customerObject.PresentAddress.District = $scope.present.district;
        customerObject.PresentAddress.State = $scope.present.state;
        customerObject.PresentAddress.Pincode = $scope.present.pincode;

        
        //$log.log(customerObject);
        var oHttp = $http({ "method": "post", "url": "/Customer/Create", "data": customerObject });
        savecustomer($scope, oHttp, $location, $log)

    }
});


var savecustomer=function(scopeObj, httpObj, locationObj, logObj)
{
    httpObj.then(function savecustomersuccess(response) { alert('saved success'); },
        function savecustomererror(response) { logObj.log("error"); });

}