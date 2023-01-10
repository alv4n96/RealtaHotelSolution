using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBHotelDbLib.HotelVbApi;

namespace HotelConsole.HandleConsole
{
    internal class Facilities
    {
        public static void Run(IHotelDbLib config)
        {

            //GetAllDataFaci(config);
            //GetDataFaciById(config, 27);
            //CreateFaci(config);


            //UpdateHoRe(config);
            //UpdateHoReBySP(config);
            //DeleteHoRe(config, 6);
            //GetDataFaciById(config, 6);
            //RunAsync(config);
        }

        private static async Task RunAsync(IHotelDbLib _conn)
        {
            /*
            HotelReviews s = new HotelReviews();
            s.GetDataHoReAsync(_conn);
            Thread.Sleep(25);
            */
        }

        private static void GetAllDataFaci(IHotelDbLib config)
        {
            var getAllDataFaci = config.RepositoryManager.Facilities.FindAllFacilities();
            foreach (var x in getAllDataFaci) Console.WriteLine(x);
        }

        private static void GetDataFaciById(IHotelDbLib config, int id)
        {
            var facilitiesById = config.RepositoryManager.Facilities.FindFacilitiesById(id);
            Console.WriteLine($"RESULT : " +
                              $"{facilitiesById}");
        }

        private static void CreateFaci(IHotelDbLib config)
        {
            var newFacilities = config.RepositoryManager.Facilities.CreateFacilities(new VBHotelDbLib.Model.Facilities
            {
                FaciName = "Test New Facilities",
                FaciDescription = null,
                FaciMaxNumber = 0,
                FaciMeasureUnit = null,
                FaciRoomNumber = "TEST04",
                FaciStartdate = new DateTime(2023, 1, 1, 6, 51, 39),
                FaciEndate = new DateTime(2024, 1, 1, 6, 51, 39),
                FaciLowPrice = 200000,
                FaciHighPrice = 250000,
                FaciRatePrice = 230000,
                FaciDiscount = 25000,
                FaciTaxRate = 10000,
                FaciModifiedDate = DateTime.Now,
                FaciCagroId = 1,
                FaciHotelId = 4
            });

            Console.WriteLine($"New Hotel Review Created : {newFacilities}");
        }

        private static void UpdateHoRe(IHotelDbLib config)
        {
            DateTime dateUpdate = new DateTime(2023, 1, 10, 6, 51, 39);
            var updateHotelReview = config.RepositoryManager.HotelReviews.UpdateHotelReviewsById(6, "Limboto 20 Updated!", 4, 1, 2, dateUpdate);
            var hotelReviewUpdateResult = config.RepositoryManager.HotelReviews.FindHotelReviewsById(6);
            Console.WriteLine(hotelReviewUpdateResult);
        }

        private static void UpdateHoReBySP(IHotelDbLib config)
        {
            DateTime dateUpdate = new DateTime(2023, 1, 10, 6, 51, 39);
            //Call UpdateHotelReviews with SQL - STORE PROCEDURE
            var updateHotelReview = config.RepositoryManager.HotelReviews.UpdateHotelReviewsById(6, "Limboto Updated by SP!", 4, 1, 2, dateUpdate);
            var hotelReviewUpdateSpResult = config.RepositoryManager.HotelReviews.FindHotelReviewsById(6);
            Console.WriteLine(hotelReviewUpdateSpResult);
        }

        private static void DeleteHoRe(IHotelDbLib config, int id)
        {
            var rowDelete = config.RepositoryManager.HotelReviews.DeleteHotelReviews(id);
            Console.WriteLine($"Delete Hotel Reviews row : {rowDelete}");
            //GetDataHotelById(config, id);
        }

        private async Task GetDataHoReAsync(IHotelDbLib config)
        {
            Console.WriteLine("============ini adalah asynchronous===========");

            var dataHotel = await config.RepositoryManager.HotelReviews.FindAllHotelReviewsAsync();
            foreach (var item in dataHotel) Console.WriteLine(item);
        }
    }
}
