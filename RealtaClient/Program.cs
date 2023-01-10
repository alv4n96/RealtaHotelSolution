using HotelConsole.HandleConsole;
using Microsoft.Extensions.Configuration;
using System;
using VBHotelDbLib.HotelVbApi;

namespace HotelConsole // Note: actual namespace depends on the project name.
{
    internal class Program
    {

        static void Main(string[] args)
        {
            IHotelDbLib config = new HotelDbLib(BuildConfig.Config().GetConnectionString("RealtaHotelDS"));

            /* -- Hotel -- */
            //Hotel.Run(config);

            /* -- Hotel Reviews -- */
            //HotelReviews.Run(config);

            /* -- Facilities -- */
            Facilities.Run(config);


        }
    }
}