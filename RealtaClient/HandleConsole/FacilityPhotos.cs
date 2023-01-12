using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VBHotelDbLib.HotelVbApi;

namespace HotelConsole.HandleConsole
{
    internal class FacilityPhotos
    {
        public static void Run(IHotelDbLib config)
        {
            FacilityPhotos res = new FacilityPhotos();
            //res.GetAllDataFaPho(config);
            //res.GetDataFaPhoById(config, 4);
            //res.CreateFaPho(config);
            //res.UpdateFaPho(config);
            //res.UpdateFaPhoBySP(config);
            //res.DeleteFaPho(config, 4);

            Task s = res.GetDataFaPhoAsync(config);
            Thread.Sleep(25);
        }


        private void GetAllDataFaPho(IHotelDbLib config)
        {
            var getDataFaPhoReviews = config.RepositoryManager.FacilityPhotos.FindAllFacilityPhotos();
            foreach (var item in getDataFaPhoReviews) Console.WriteLine(item);
        }

        private void GetDataFaPhoById(IHotelDbLib config, int id)
        {
            var hoReById = config.RepositoryManager.FacilityPhotos.FindFacilityPhotosById(id);
            Console.WriteLine($"RESULT : " +
                              $"{hoReById}");
        }

        private void CreateFaPho(IHotelDbLib config)
        {
            var newFaPho = config.RepositoryManager.FacilityPhotos.CreateFacilityPhotos(new VBHotelDbLib.Model.FacilityPhotos
            {
                FaphoFaciId = 3,
                FaphoThumbnailFilename = null,
                FaphoPhotoFilename = "Create-New.png",
                FaphoPrimary = false,
                FaphoUrl = "https://github.com/testajasih",
                FaphoModifiedDate = DateTime.Now
            });

            Console.WriteLine($"New Hotel Review Created : {newFaPho}");
        }
        
        private void UpdateFaPho(IHotelDbLib config)
        {
            var updateFacilityPhotos = config.RepositoryManager.FacilityPhotos.UpdateFacilityPhotosById(4, null, "Test-Update2.png", false, "https://github.com/testajasih", new DateTime(2023, 1, 11, 16, 39, 29),3);
            var facilityPhotoUpdateResult = config.RepositoryManager.FacilityPhotos.FindFacilityPhotosById(4);
            Console.WriteLine(facilityPhotoUpdateResult);
        }
        
        private void UpdateFaPhoBySP(IHotelDbLib config)
        {
            //Call UpdateFaciltyPhotos with SQL - STORE PROCEDURE
            var updateFacilityPhotos = config.RepositoryManager.FacilityPhotos.UpdateFacilityPhotosById(4, null, "Test-Update.png", false, "https://github.com/testajasih", new DateTime(2023, 1, 11, 16, 39, 29),3);
            var facilityPhotoBySpupdateResult = config.RepositoryManager.FacilityPhotos.FindFacilityPhotosById(4);
            Console.WriteLine("=== Updated ===");
            Console.WriteLine(facilityPhotoBySpupdateResult);
        }

        private void DeleteFaPho(IHotelDbLib config, int id)
        {
            var rowDelete = config.RepositoryManager.FacilityPhotos.DeleteFacilityPhotos(id);
            Console.WriteLine($"Delete Hotel Reviews row : {rowDelete}");
            GetDataFaPhoById(config, id);
        }

        private async Task GetDataFaPhoAsync(IHotelDbLib config)
        {
            Console.WriteLine("============ini adalah asynchronous===========");

            var dataFacilityPhotos = await config.RepositoryManager.FacilityPhotos.FindAllFacilityPhotosAsync();
            foreach (var item in dataFacilityPhotos) Console.WriteLine(item);
        }
    }
}
