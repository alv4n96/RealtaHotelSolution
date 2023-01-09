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
        public static void Run()
        {
            IHotelVbApi _conn = new HotelVbApi(BuildConfig.Config().GetConnectionString("RealtaHotelDS"));

            //GetAllDataHotel(_conn);
            GetDataHotelById(_conn, 99);
        }

        private static void GetAllDataHotel(IHotelVbApi config)
        {
            var listHotel = config.RepositoryManager.Hotel.FindAllHotel();
            listHotel.ForEach(item => { Console.WriteLine(item); });
        }

        private static void GetDataHotelById(IHotelVbApi config, int id)
        {
            var regionById = config.RepositoryManager.Hotel.FindHotelById(id);
            Console.WriteLine($"Data Found : {regionById}");

        }
    }
}
