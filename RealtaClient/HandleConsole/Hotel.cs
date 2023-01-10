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

            GetAllDataHotel(_conn);
            //CreateHotel(_conn);
            //GetDataHotelById(_conn, 2);
            //UpdateHotel(_conn);
            //DeleteHotel(_conn,24);
            //GetDataHotelById(_conn, 24);
            //UpdateHotelBySP(_conn);
            //RunAsync(_conn);
        }

        private static async Task RunAsync(IHotelDbLib _conn)
        {
            Hotel s = new Hotel();
            s.GetDataHotelAsync(_conn);
            Thread.Sleep(25);
        }

        private static void GetAllDataHotel(IHotelDbLib config)
        {
            var listHotel = config.RepositoryManager.Hotel.FindAllHotel();
            listHotel.ForEach(item => { Console.WriteLine(item); });
        }

        private static void GetDataHotelById(IHotelDbLib config, int id)
        {
            var hotelById = config.RepositoryManager.Hotel.FindHotelById(id);
            Console.WriteLine($"Data Found : {hotelById}");

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
            var updateHotel = config.RepositoryManager.Hotel.UpdateHotelById(24, "Hotel Limboto 22", "Hotel Good",4, "+62 823 4545 2222",DateTime.Now, 3);
            var hotelUpdateResult = config.RepositoryManager.Hotel.FindHotelById(24);
            Console.WriteLine(hotelUpdateResult);
        }

        private static void DeleteHotel(IHotelDbLib config, int id)
        {
            var rowDelete = config.RepositoryManager.Hotel.DeleteHotel(id);
            Console.WriteLine($"Delete Hotel row : {rowDelete}");
            GetDataHotelById(config, id);
        }

        private static void UpdateHotelBySP(IHotelDbLib config)
        {
            //Call UpdateHotel with SQL - STORE PROCEDURE
            var updateHotel = config.RepositoryManager.Hotel.UpdateHotelById(25, "Hotel Limboto 22", "Hotel Cihuy Bos", 4, "+62 823 4545 2222", DateTime.Now, 3);
            var hotelUpdateSpResult = config.RepositoryManager.Hotel.FindHotelById(25);
            Console.WriteLine(hotelUpdateSpResult);
        }

        private async Task GetDataHotelAsync(IHotelDbLib config)
        {
            Console.WriteLine("============ini adalah asynchronous===========");

            var dataHotel = await config.RepositoryManager.Hotel.FindAllHotelAsync();
            foreach (var item in dataHotel) Console.WriteLine(item);
        }

    }
}
