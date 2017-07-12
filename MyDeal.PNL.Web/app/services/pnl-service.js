pnlApp.service('getPassengerService', ['$http', function ($http) {
  
    this.getPassengers = function () {
        return $http.get("http://localhost/MyDeal.Passenger.Api/api/Passenger/");            
    }

    this.getUploadPassenger = function (passengerList) {
        if (passengerList) {
            var Indata = { listOfPassengers: passengerList };
            return $http({
                url: 'http://localhost/MyDeal.Passenger.Api/api/Passenger',
                method: 'POST',
                params: Indata,
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' },

            });            
        }       
    }
   
    this.searchPassenger = function (searchString) {
        if (searchString) {
            return $http.get("http://localhost/MyDeal.Passenger.Api/api/Passenger/SearchPassenger?searchQuery="+searchString);
        }
    }
}]);
