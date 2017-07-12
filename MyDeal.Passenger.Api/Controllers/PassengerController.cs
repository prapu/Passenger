using MyDeal.PNL.Data.DataModels;
using MyDeal.PNL.Data.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyDeal.Passenger.Api.Controllers
{
    public class PassengerController : ApiController
    {
        PassengerDataService pdService = new PassengerDataService();
        
        [HttpPost]
        public void CreatePassengers( string listOfPassengers)
        {            
            pdService.UpdatePassengers(listOfPassengers);
        }

        [HttpGet]
        public IEnumerable<PassengerData> GetAllPassengers()
        {
            return pdService.GetPassengerDetails();
        }
        [HttpGet]
        public IEnumerable<PassengerData> SearchPassengers(string searchQuery)
        {
            return pdService.SearchPassenger(searchQuery);
        }
    }
}
