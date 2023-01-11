Imports VBHotelDbLib.Repository

Namespace Base
    Public Interface IRepositoryManager

        ReadOnly Property Hotel As IHotelRepository
        ReadOnly Property HotelReviews As IHotelReviewsRepository
        ReadOnly Property Facilities As IFacilitiesRepository
        ReadOnly Property FacilityPhotos As IFacilityPhotosRepository

    End Interface
End Namespace
