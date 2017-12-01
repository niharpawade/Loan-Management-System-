var app = angular.module("lmsapp", []);
app.controller("loancontroller", function ($http, $scope, $location, $log) {
    $log.log("loancontroller initialized")
    var maxx;
    var maxamt;
    
       
  

    $scope.saveloan = function () {


        var LoanEntity = { "PresentAddress": {} };
        LoanEntity.AppliedDate = $scope.applieddate;
        LoanEntity.CustomerId = $scope.customer.ID;////check this
        LoanEntity.LoantypeId = $scope.loantype.Id;
        //LoanEntity.AppliedDate = $scope.applieddate;
        LoanEntity.Amount = $scope.amount;
        LoanEntity.intrestrate = $scope.intrestrate;
        LoanEntity.NoOfInstallments = $scope.noofinstallments;
        LoanEntity.Nominee = $scope.nomineename;
        LoanEntity.PresentAddress.Address1 = $scope.present.address1;
        LoanEntity.PresentAddress.Address2 = $scope.present.Address2;
        LoanEntity.PresentAddress.City = $scope.present.city;
        LoanEntity.PresentAddress.District = $scope.present.district;
        LoanEntity.PresentAddress.State = $scope.present.state;
        LoanEntity.PresentAddress.PINCode = $scope.present.pincode;
        $log.log(LoanEntity)
        $http({ "method": "post", "url": "/Loan/Create", "data": LoanEntity }).then(
            function questionssuccess(response) { alert(response) },
            function questionserror(response) { }
        );

    };

    $scope.getrelatedvals = function (loantype) {
        var loantypeobject = {};
        loantypeobject.LoanName = loantype.LoanName;
        loantypeobject.IntrestRate = loantype.IntrestRate;
        loantypeobject.MaxInstallments = loantype.MaxInstallments;
        loantypeobject.MaxAmount = loantype.MaxAmount;
        $log.log(loantypeobject);
        var intrest = loantype.IntrestRate + " %";
        var maxinstallmentstext = "Maximum Installments : " + loantype.MaxInstallments;
        var maxamounttext = "Maximum Amount : " + loantype.MaxAmount;
        var errmsg = "Maximum Installments Allowed : " + loantype.MaxInstallments;
        maxx = loantype.MaxInstallments;
        maxamt = loantype.MaxAmount;
        
        $scope.intrestrate = intrest;
        $scope.noofinstallments = null;
        $scope.amount = null;
        $('#txtnoofinstallments').attr("placeholder", maxinstallmentstext);   
        $('#txtamount').attr("placeholder", maxamounttext);


    };
    $scope.changemaxinstallments = function () {
        $log.log(maxx)
        if ($scope.noofinstallments > maxx) {
            $scope.noofinstallments = null;
        }

    };
    $scope.changemaxamount = function () {
        $log.log(maxamt)
        if ($scope.amount > maxamt) {
            $scope.amount = null;
        }

    };

   
    
    $http({ "method": "get", "url": "/Lookup/GetLoanTypes" }).then(
        function questionssuccess(response) { $scope.loantypes = response.data; },
        function questionserror(response) { }
    );

    //Check Again neewds Work
    $http({ "method": "get", "url": "/Lookup/GetTodayDate" }).then(
        function questionssuccess(response) { $scope.today = response.data; $scope.applieddate = $scope.today },
        function questionserror(response) { }
    );

    //getting customer names lis
    $http({ "method": "get", "url": "/Customer/SearchCustomers" }).then(
        function questionssuccess(response) { $scope.customers = response.data; $log.log($scope.customers);  },
        function questionserror(response) { }
    );







}
);
var bindLoanTypesDropDown = function (loantypes) {
    $.each(loantypes, function (index, loantype) {
        var loantypeOption = $("<option></option>").val(loantype.Id).html(loantype.LoanName);
        $('#ddlloantype').append(loantypeOption);

    });
}
//document.getElementById('txtapplieddate').valueAsDate = new Date();
