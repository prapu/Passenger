﻿using System.Web;
using System.Web.Mvc;

namespace MyDeal.Passenger.Api
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
