using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBHotelDbLib.HotelVbApi;

namespace HotelConsole.HandleConsole
{
    internal class FacilityPriceHistory
    {
        public static void Run(IHotelDbLib config)
        {
            //GetAllDataFaPH(config);
            GetDataById(config, 3);
            //GetDataByIdFaci(config);

        }

        public static void GetAllDataFaPH(IHotelDbLib config)
        {
            var resFaPH = config.RepositoryManager.FacilityPriceHistory.FindAllFaph();

            resFaPH.ForEach(item => Console.WriteLine(item));
        }
        private static void GetDataByIdFaci(IHotelDbLib config)
        {


        }

        private static void GetDataById(IHotelDbLib config, int id)
        {
            var resFaPH = config.RepositoryManager.FacilityPriceHistory.FindFaphById(id);

            Console.WriteLine(resFaPH);
        }

    }
}
