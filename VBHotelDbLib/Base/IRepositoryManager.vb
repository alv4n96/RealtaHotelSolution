Imports VBHotelDbLib.Repository

Namespace Base
    Public Interface IRepositoryManager
        ReadOnly Property Hotel As IHotelRepository

        ReadOnly Property HotelReviews As IHotelReviewsRepository

    End Interface
End Namespace
