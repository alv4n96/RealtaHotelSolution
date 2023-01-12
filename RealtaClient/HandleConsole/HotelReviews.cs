using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBHotelDbLib.HotelVbApi;

namespace HotelConsole.HandleConsole
{
    internal class HotelReviews
    {
        public static void Run(IHotelDbLib config)
        {
            HotelReviews res = new HotelReviews();

            //res.GetAllDataHoRe(config);
            //res.GetDataHoReById(config, 5);
            //res.CreateHoRe(config);
            //res.UpdateHoRe(config);
            //res.UpdateHoReBySP(config);
            //res.DeleteHoRe(config, 5);
            //res.GetDataHoReById(config, 6);
            //Task s = res.GetDataHoReAsync(config);
            //Thread.Sleep(25);
        }


        private void GetAllDataHoRe(IHotelDbLib config)
        {
            var getDataHoreReviews = config.RepositoryManager.HotelReviews.FindAllHotelReviews();
            foreach (var item in getDataHoreReviews) Console.WriteLine(item);
        }

        private void GetDataHoReById(IHotelDbLib config, int id)
        {
            var hoReById = config.RepositoryManager.HotelReviews.FindHotelReviewsById(id);
            Console.WriteLine($"RESULT : " +
                              $"{hoReById}");
        }

        private void CreateHoRe(IHotelDbLib config)
        {
            var newHotelReview = config.RepositoryManager.HotelReviews.CreateHotelReviews(new VBHotelDbLib.Model.HotelReviews
            {
                HoreUserReview = "Limboto 20 kembali lagi nih bos",
                HoreRating = 4,
                HoreCreatedOn = DateTime.Now,
                HoreUserId = 1,
                HoreHotelId = 2
            });

            Console.WriteLine($"New Hotel Review Created : {newHotelReview}");
        }
        
        private void UpdateHoRe(IHotelDbLib config)
        {
            DateTime dateUpdate = new DateTime(2023, 1, 10, 6, 51, 39);
            var updateHotelReview = config.RepositoryManager.HotelReviews.UpdateHotelReviewsById(6, "Limboto 20 Updated!", 4, 1, 2, dateUpdate);
            var hotelReviewUpdateResult = config.RepositoryManager.HotelReviews.FindHotelReviewsById(6);
            Console.WriteLine(hotelReviewUpdateResult);
        }
        
        private void UpdateHoReBySP(IHotelDbLib config)
        {
            DateTime dateUpdate = new DateTime(2023, 1, 10, 6, 51, 39);
            //Call UpdateHotelReviews with SQL - STORE PROCEDURE
            var updateHotelReview = config.RepositoryManager.HotelReviews.UpdateHotelReviewsById(6, "Limboto Updated by SP!", 4, 1, 2, dateUpdate);
            var hotelReviewUpdateSpResult = config.RepositoryManager.HotelReviews.FindHotelReviewsById(6);
            Console.WriteLine(hotelReviewUpdateSpResult);
        }

        private void DeleteHoRe(IHotelDbLib config, int id)
        {
            var rowDelete = config.RepositoryManager.HotelReviews.DeleteHotelReviews(id);
            Console.WriteLine($"Delete Hotel Reviews row : {rowDelete}");
            GetDataHoReById(config, id);
        }

        private async Task GetDataHoReAsync(IHotelDbLib config)
        {
            Console.WriteLine("============ini adalah asynchronous===========");

            var dataHotel = await config.RepositoryManager.HotelReviews.FindAllHotelReviewsAsync();
            foreach (var item in dataHotel) Console.WriteLine(item);
        }
    }
}
