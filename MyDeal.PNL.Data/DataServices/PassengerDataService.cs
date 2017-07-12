using MyDeal.PNL.Data.DataModels;
using MyDeal.PNL.Data.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MyDeal.PNL.Data.DataServices
{
    public class PassengerDataService
    {
        public IEnumerable<PassengerData> GetPassengerDetails()
        {
            using (var dbContext = new MyDealEntities1())
            {
                return (from pd in dbContext.PassengerDetails
                        join p in dbContext.Passengers on pd.PassengerId equals p.Id
                        select new PassengerData()
                        {
                            BookingId = pd.RecordLocator,
                            Name = p.Name
                        }).ToList();
            }

        }
       
        public IEnumerable<PassengerData> SearchPassenger(string searchString)
        {
            Regex regEx = new System.Text.RegularExpressions.Regex(searchString);
            using (var dbContext = new MyDealEntities1())
            {
                return (from pd in dbContext.PassengerDetails
                        join p in dbContext.Passengers on pd.PassengerId equals p.Id
                        where (pd.RecordLocator.Contains(searchString) || p.Name.Contains(searchString))
                 select new PassengerData()
                 {
                     BookingId = pd.RecordLocator,
                     Name = p.Name
                 }).ToList();
            }
        }

        public void UpdatePassengers(string passengerList)
        {
            PassengerTextReader pt = new PassengerTextReader();
            List<PassengerData> lstPassengerData = pt.CreatePassengers(passengerList);
            if (lstPassengerData != null)
            {
                using (var dbContext = new MyDealEntities1())
                {
                    //Passengers not there in the db
                    var missingPassengers = lstPassengerData.Where(x => !dbContext.Passengers.Any(z => z.Name == x.Name)).ToList();
                    foreach (PassengerData pData in missingPassengers)
                    {
                        //add passenger record
                        Passenger passenger = new Passenger();
                        passenger.Name = pData.Name;
                        dbContext.Passengers.Add(passenger);
                        dbContext.SaveChanges();

                        //add passenger details
                        PassengerDetail pDetails = new PassengerDetail();
                        pDetails.PassengerId = passenger.Id;
                        pDetails.RecordLocator = pData.BookingId;
                        dbContext.PassengerDetails.Add(pDetails);
                        dbContext.SaveChanges();
                    }
                }
            }
        }
    }
}
