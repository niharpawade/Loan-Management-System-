var app = angular.module("lmsapp", []);
app.controller("usercontroller", function ($scope, $http,$location)
{
    $scope.name = '';
   // $scope.isnameinvalid = false;

    $scope.userpassword = '';
    $scope.userretypepassword = '';
    //$scope.ispasswordinvalid = false;
    $scope.usermobileno = '';
    $scope.useremailid = '';
    $scope.userrole = '';
    $scope.userisactive = false;
    $scope.userislocked = false;
    $scope.userid = -1;
    //$scope.userid = -1;
    //usersecurityquestion
    //usersecurityanswer
    // Save
    $scope.saveuser = function () {
        var userModel = {};
        userModel.Id = $scope.userid;
        userModel.Name = $scope.name;
        userModel.Password = $scope.userpassword;
        userModel.MobileNo = $scope.usermobileno;
        userModel.EmailId = $scope.useremailid;
        userModel.Role = $scope.userrole.Id; // $("#ddlRole").val().toString(); $scope.userrole;
        userModel.IsActive = true;
        userModel.IsLocked = false;
        userModel.SecurityQuestionId = $scope.usersecurityquestion.Id; //$("#ddlSecurityQuestion").val().toString();//$scope.usersecurityquestion;
        userModel.Answer = $scope.usersecurityanswer;
        userModel.Id = $scope.userid;
        console.log(userModel);
        $http({
            "method": "post",
            "url": "/LMSHome/CreateUser",
            "data": userModel
        }).then(
            function saveusersuccess(response) { alert('User Saved Successfully'); },
            function saveusererror(respone) { }
            );

       

    };
    // Save

  

   
  
    $http({ "method": "get", "url": "/Lookup/GetRoles" }).
        then(
        function usersuccess(response)
        {
            $scope.roles = response.data;
            // console.log(response.data);
            //$.each(response.data, function (index, role)
            //{
            //    var roleOption = $("<option></option>").val(role.Id).html(role.Name);
            //    $('#ddlRole').append(roleOption);
            //});
        },
        function usererror(response) { alert('error'); }
        );
    //bindQuestionDropDown(response.data); 
    $http({  "method": "get", "url": "/Lookup/GetQuestions"}).then(
      function questionssuccess(response) { $scope.questions = response.data; },
      function questionserror(response) { }
      );


   
    var urls = $location.absUrl().split('/');
    if (urls.length >= 6) {
        $scope.userid = urls[5];

        //console.log($scope.userid);
        $http(
            {
                "method": "get",
                "url": "/LMSHome/GetUser/" + $scope.userid
            }).then(function getusersuccess(response) {
                //console.log(response.data);
                var editUser = response.data;
                $scope.name = editUser.Name;
                $scope.userpassword = editUser.Password;
                $scope.userretypepassword = editUser.Password;
                $scope.usermobileno = editUser.MobileNo;
                $scope.useremailid = editUser.EmailId;
                var currentrole = editUser.Role;
                console.log(currentrole);
                angular.forEach($scope.roles, function (value, key) {
                    //console.log(value);
                    if ($scope.roles[key].Id == currentrole)
                    {
                        $scope.userrole = $scope.roles[key];
                    }
                });
                $scope.usersecurityanswer = editUser.Answer;

                // Binding Questions
                var currentQuestionId = editUser.SecurityQuestionId;

                angular.forEach($scope.questions, function (value, questionindex)
                {
                    if($scope.questions[questionindex].Id==currentQuestionId)
                    {
                        $scope.usersecurityquestion = $scope.questions[questionindex];
                    }
                });

            }, function getusererror(response) { });
    }

   
}
);

var bindQuestionDropDown = function(questions)
{
    $.each(questions, function (index, question)
    {
        var questionOption = $("<option></option>").val(question.Id).html(question.QuestionName);
        $('#ddlSecurityQuestion').append(questionOption);

    });
}