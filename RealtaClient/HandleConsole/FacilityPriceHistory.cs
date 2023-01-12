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
            FacilityPriceHistory res = new FacilityPriceHistory();
            //res.GetAllDataFaPH(config);
            //res.GetDataById(config, 99);
            //res.GetDataByIdFaci(config, 3);

            //Task s = res.GetAllDataFaPHAsync(config);
            //Thread.Sleep(25);
        }

        private void GetAllDataFaPH(IHotelDbLib config)
        {
            var resFaPH = config.RepositoryManager.FacilityPriceHistory.FindAllFaph();

            resFaPH.ForEach(item => Console.WriteLine(item));
        }

        private void GetDataById(IHotelDbLib config, int id)
        {
            var resFaPH = config.RepositoryManager.FacilityPriceHistory.FindFaphById(id);

            Console.WriteLine(resFaPH);
        }
        private void GetDataByIdFaci(IHotelDbLib config, int id)
        {
            var resGetDataByFaciId = config.RepositoryManager.FacilityPriceHistory.FindFaphByIdFaciId(id);

            resGetDataByFaciId.ForEach(data => Console.WriteLine(data));
        }

        private async Task GetAllDataFaPHAsync(IHotelDbLib config)
        {
            var resGetAllData = await config.RepositoryManager.FacilityPriceHistory.FindAllFaphReviewsAsync();

            resGetAllData.ForEach(item => Console.WriteLine(item));
        }

    }
}
