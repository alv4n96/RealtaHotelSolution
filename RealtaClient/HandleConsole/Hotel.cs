using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBHotelDbLib.HotelVbApi;

namespace HotelConsole.HandleConsole
{
    internal class Hotel
    {
        public static void Run(IHotelDbLib _conn)
        {

            //GetAllDataHotel(_conn);
            //CreateHotel(_conn);
            GetDataHotelById(_conn, 2);
            //UpdateHotel(_conn);
            //DeleteHotel(_conn,24);
            //GetDataHotelById(_conn, 24);
            //UpdateHotelBySP(_conn);
        }


        private static void GetAllDataHotel(IHotelDbLib config)
        {
            var listHotel = config.RepositoryManager.Hotel.FindAllHotel();
            listHotel.ForEach(item => { Console.WriteLine(item); });
        }

        private static void GetDataHotelById(IHotelDbLib config, int id)
        {
            var regionById = config.RepositoryManager.Hotel.FindHotelById(id);
            Console.WriteLine($"Data Found : {regionById}");

        }

        private static void CreateHotel(IHotelDbLib config)
        {
            var newHotel = config.RepositoryManager.Hotel.CreateHotel(new VBHotelDbLib.Model.Hotel
            {
                HotelName = "Hotel Limboto",
                HotelDescription = "Hotel Mantap",
                HotelRatingStar = 4,
                HotelPhonenumber = "+62 823 4545 2222",
                HotelModifiedDate = DateTime.Now,
                HotelAddrId= 3,
            });

            Console.WriteLine($"New Hotel : {newHotel}");
        }

        private static void UpdateHotel(IHotelDbLib config)
        {
            var updateRegion = config.RepositoryManager.Hotel.UpdateHotelById(24, "Hotel Limboto 22", "Hotel Good",4, "+62 823 4545 2222",DateTime.Now, 3);
            var hotelUpdateResult = config.RepositoryManager.Hotel.FindHotelById(24);
            Console.WriteLine(hotelUpdateResult);
        }

        private static void DeleteHotel(IHotelDbLib config, int id)
        {
            var rowDelete = config.RepositoryManager.Hotel.DeleteHotel(id);
            Console.WriteLine($"Delete region row : {rowDelete}");
            GetDataHotelById(config, id);
        }

        private static void UpdateHotelBySP(IHotelDbLib config)
        {
            //Call UpdateRegion with SQL - STORE PROCEDURE
            var updateRegion = config.RepositoryManager.Hotel.UpdateHotelById(25, "Hotel Limboto 22", "Hotel Cihuy Bos", 4, "+62 823 4545 2222", DateTime.Now, 3);
            var regionUpdateSpResult = config.RepositoryManager.Hotel.FindHotelById(25);
            Console.WriteLine(regionUpdateSpResult);
        }


        private async Task GetDataHotelAsync(IHotelDbLib config)
        {
            

        }
       
    }
}
