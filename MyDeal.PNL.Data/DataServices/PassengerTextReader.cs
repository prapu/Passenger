using MyDeal.PNL.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDeal.PNL.Data.DataServices
{
    public class PassengerTextReader
    {
        public List<PassengerData> CreatePassengers(string passengerList)
        {
            if (string.IsNullOrEmpty(passengerList)) return null;
            //split the input using newline character.
            string[] data = passengerList.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            //ignore all the entries begin with data .R / and blanks
            //then replace - with / and .L/ with / and .L with empty string
            data = data.Where(s => !s.Contains(".R/") && s != "")
            .Select(s => { return s.Replace("-", "|").Replace(".L/", "|.L/ ").Replace(".L /", "|.L/ "); }).ToArray();

            List<PassengerData> lstPassenger = new List<PassengerData>();
            //loop the strign array to extract passenger details
            for (int i = 0; i < data.Length; i++)
            {
                var temp = data[i].Split('|');

                if (temp != null)
                {
                    var passenger = new PassengerData();
                    for (int j = 0; j < temp.Length; j++)
                    {
                        //name
                        if (temp[j].StartsWith("1"))
                        {
                            passenger.Name = temp[j].Replace("1", string.Empty).Replace("/", " ");
                        }
                        //booking id
                        if (temp[j].StartsWith(".L/"))
                        {
                            passenger.BookingId = temp[j].Replace(".L/ ", "");
                        }

                    }
                    if (passenger.Name != null) { lstPassenger.Add(passenger); }
                    
                }
            }
            return lstPassenger;
        }

    }
}
