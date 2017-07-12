pnlApp.component("passengerDetails", {
    templateUrl: "../MyDeal.PNL.Web/app/components/pnl-template.html",
    controller: (['$scope', 'getPassengerService', function ($scope, getPassengerService) {
        $scope.title = "Passenger Finder"; //App title

        $scope.passengerData = "";
        $scope.errorMessage = "";
        $scope.uploadSuccess = "";
        $scope.uploadProgress = false;
        $scope.uploadPassengers = function () {
            $scope.uploadProgress = true;
            if ($scope.passengerData == "") {
                $scope.errorMessage="Please enter passenger details to upload"
            } else {
                getPassengerService.getUploadPassenger($scope.passengerData).then(function(){
                    //success
                   $scope.uploadProgress = false;
                   $scope.uploadSuccess = "Upload completed successfully...!";                    
                }, function () {
                    //error
                    $scope.uploadProgress = false;
                    $scope.errorMessage = "An error occured please contact administrator";
                });
            }            
        }
        $scope.passengerList = null;
        $scope.progress = false;
        $scope.getPassengers = function () {
            $scope.progress = true;
            //get all the passengers
            getPassengerService.getPassengers().then(function (result) {
                //success
                $scope.passengerList = result.data;
                $scope.progress = false;
            }, function (result) {
                //error
                $scope.progress = false;
                $scope.passengerList = null;
            });
        }

        $scope.searchError = "";
        $scope.searchPassenger = "";
        $scope.searchPassengers = function () {
            if ($scope.searchPassenger == "") {
                $scope.searchError ="Please enter search data"
            } else {
                $scope.searchError = "";
                getPassengerService.searchPassenger($scope.searchPassenger).then(function (result) {
                    $scope.passengerList = result.data;
                }, function (result) {
                    $scope.passengerList = null;
                });
            }
            
        }
    }])
});