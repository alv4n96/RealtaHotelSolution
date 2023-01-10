Imports VBHotelDbLib.Model

Namespace Repository
    Public Interface IHotelReviewsRepository
        Function FindAllHotelReviews() As List(Of HotelReviews)

        Function FindHotelReviewsById(ByVal id As Int32) As HotelReviews

        Function CreateHotelReviews(ByVal hotelReview As HotelReviews) As HotelReviews

        Function UpdateHotelReviewsById(id As Integer, userReview As String, rating As Int16, userId As Int32, hotelId As Int32, createdOn As DateTime, Optional showCommand As Boolean = False) As Boolean

        Function UpdateHotelReviewsBySp(id As Integer, userReview As String, rating As Int16, userId As Int32, hotelId As Int32, createdOn As DateTime, Optional showCommand As Boolean = False) As Boolean

        Function DeleteHotelReviews(ByVal id As Integer) As Int32

        Function FindAllHotelReviewsAsync() As Task(Of List(Of HotelReviews))

    End Interface
End Namespace
