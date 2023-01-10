using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
            //UpdateFaci(config);
            //UpdateFaciBySP(config);
            //DeleteFaci(config, 28);
            //RunAsync(config);
        }

        private static async Task RunAsync(IHotelDbLib _conn)
        {
            Facilities s = new Facilities();
            s.GetDataFaciAsync(_conn);
            Thread.Sleep(50);
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

        private static void UpdateFaci(IHotelDbLib config)
        {
            //Data Update!
            var id = 27;
            var faciName = "Test New Facilities";
            var faciDescription = "Updated FacilitiesName";
            var faciMaxNumber = 0;
            //var faciMeasureUnit = null;
            var faciRoomNumber = "TEST04";
            var faciStartdate = new DateTime(2023, 1, 1, 6, 51, 39);
            var faciEndate = new DateTime(2024, 1, 1, 6, 51, 39);
            var faciLowPrice = 200000;
            var faciHighPrice = 250000;
            var faciRatePrice = 230000;
            var faciDiscount = 25000;
            var faciTaxRate = 10000;
            var faciModifiedDate = new DateTime(2023,1,11,00,26,16);
            var faciCagroId =1;
            var faciHotelId =4;

            var updateFacilities = config.RepositoryManager.Facilities.UpdateFacilitiesById(id, faciName, faciDescription, faciMaxNumber, null, faciRoomNumber, faciStartdate, faciEndate, faciLowPrice, faciHighPrice, faciRatePrice, faciDiscount, faciTaxRate, faciModifiedDate, faciCagroId, faciHotelId);
            var facilitiesResult = config.RepositoryManager.Facilities.FindFacilitiesById(id);
            Console.WriteLine(facilitiesResult);
        }

        private static void UpdateFaciBySP(IHotelDbLib config)
        {
            //Data Update!
            var id = 27;
            var faciName = "Test New Facilities";
            var faciDescription = "Updated FacilitiesName BySP";
            var faciMaxNumber = 0;
            var faciMeasureUnit = "people";
            var faciRoomNumber = "TEST04";
            var faciStartdate = new DateTime(2023, 1, 1, 6, 51, 39);
            var faciEndate = new DateTime(2024, 1, 1, 6, 51, 39);
            var faciLowPrice = 200000;
            var faciHighPrice = 250000;
            var faciRatePrice = 230000;
            var faciDiscount = 25000;
            var faciTaxRate = 10000;
            var faciModifiedDate = new DateTime(2023, 1, 11, 00, 26, 16);
            var faciCagroId = 1;
            var faciHotelId = 4;

            var updateFacilitiesBySp = config.RepositoryManager.Facilities.UpdateFacilitiesBySp(id, faciName, faciDescription, faciMaxNumber, faciMeasureUnit, faciRoomNumber, faciStartdate, faciEndate, faciLowPrice, faciHighPrice, faciRatePrice, faciDiscount, faciTaxRate, faciModifiedDate, faciCagroId, faciHotelId);
            var facilitiesResult = config.RepositoryManager.Facilities.FindFacilitiesById(id);
            Console.WriteLine(facilitiesResult);
        }

        private static void DeleteFaci(IHotelDbLib config, int id)
        {
            var rowDelete = config.RepositoryManager.Facilities.DeleteFacilities(id);
            Console.WriteLine($"Delete Facilities Reviews row : {rowDelete}" +
                              $"");
            GetDataFaciById(config, id);
        }

        private async Task GetDataFaciAsync(IHotelDbLib config)
        {
            Console.WriteLine("============ini adalah asynchronous===========");

            var dataFacilities = await config.RepositoryManager.Facilities.FindAllFacilitiesAsync();
            foreach (var item in dataFacilities) Console.WriteLine(item);
        }
    }
}
