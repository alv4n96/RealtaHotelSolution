using HotelConsole.HandleConsole;
using Microsoft.Extensions.Configuration;
using System;
using VBHotelDbLib.HotelVbApi;

namespace HotelConsole // Note: actual namespace depends on the project name.
{
    internal class Program
    {

        static async Task Main(string[] args)
        {
            IHotelDbLib _conn = new HotelDbLib(BuildConfig.Config().GetConnectionString("RealtaHotelDS"));

            Hotel.Run(_conn);

            //Call FindHotelAsync
            Console.WriteLine("============ini adalah asynchronous===========");

            var test = await _conn.RepositoryManager.Hotel.FindAllHotelAsync();
            test.ForEach(x => Console.WriteLine(x));


        }
    }
}