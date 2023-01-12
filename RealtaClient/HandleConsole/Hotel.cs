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
            Hotel res = new Hotel();
            // res.GetAllDataHotel(_conn);
            // res.CreateHotel(_conn);
            // res.GetDataHotelById(_conn, 11);
            // res.UpdateHotel(_conn);
            // res.DeleteHotel(_conn, 11);
            // res.UpdateHotelBySP(_conn);

            // Task s = res.GetDataHotelAsync(_conn);
            // Thread.Sleep(25);
        }


        private void GetAllDataHotel(IHotelDbLib config)
        {
            var listHotel = config.RepositoryManager.Hotel.FindAllHotel();
            listHotel.ForEach(item => { Console.WriteLine(item); });
        }

        private void GetDataHotelById(IHotelDbLib config, int id)
        {
            var hotelById = config.RepositoryManager.Hotel.FindHotelById(id);
            Console.WriteLine($"Data Found : {hotelById}");

        }

        private void CreateHotel(IHotelDbLib config)
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

        private void UpdateHotel(IHotelDbLib config)
        {
            var updateHotel = config.RepositoryManager.Hotel.UpdateHotelById(24, "Hotel Limboto 22", "Hotel Good",4, "+62 823 4545 2222",DateTime.Now, 3);
            var hotelUpdateResult = config.RepositoryManager.Hotel.FindHotelById(24);
            Console.WriteLine(hotelUpdateResult);
        }

        private void DeleteHotel(IHotelDbLib config, int id)
        {
            var rowDelete = config.RepositoryManager.Hotel.DeleteHotel(id);
            Console.WriteLine($"Delete Hotel row : {rowDelete}");
            GetDataHotelById(config, id);
        }

        private void UpdateHotelBySP(IHotelDbLib config)
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
