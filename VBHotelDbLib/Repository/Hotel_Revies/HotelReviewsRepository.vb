Imports VBHotelDbLib.Context
Imports VBHotelDbLib.Model

Namespace Repository
    Public Class HotelReviewsRepository
        Implements IHotelReviewsRepository

        'dependency injection
        Private ReadOnly _context As IRepositoryContext

        Public Sub New()
        End Sub

        Public Sub New(context As IRepositoryContext)
            _context = context
        End Sub

        Public Function FindAllHotelReviews() As List(Of HotelReviews) Implements IHotelReviewsRepository.FindAllHotelReviews
            Throw New NotImplementedException()
        End Function

        Public Function FindHotelReviewsById(id As Integer) As HotelReviews Implements IHotelReviewsRepository.FindHotelReviewsById
            Throw New NotImplementedException()
        End Function

        Public Function CreateHotelReviews(hotel As HotelReviews) As HotelReviews Implements IHotelReviewsRepository.CreateHotelReviews
            Throw New NotImplementedException()
        End Function

        Public Function UpdateHotelReviewsById(id As Integer, userReview As String, rating As Short, userId As Integer, hotelId As Integer, createdOn As Date, Optional showCommand As Boolean = False) As Boolean Implements IHotelReviewsRepository.UpdateHotelReviewsById
            Throw New NotImplementedException()
        End Function

        Public Function UpdateHotelReviewsBySp(id As Integer, userReview As String, rating As Short, userId As Integer, hotelId As Integer, createdOn As Date, Optional showCommand As Boolean = False) As Boolean Implements IHotelReviewsRepository.UpdateHotelReviewsBySp
            Throw New NotImplementedException()
        End Function

        Public Function DeleteHotelReviews(id As Integer) As Integer Implements IHotelReviewsRepository.DeleteHotelReviews
            Throw New NotImplementedException()
        End Function

        Public Function FindAllHotelReviewsAsync() As Task(Of List(Of HotelReviews)) Implements IHotelReviewsRepository.FindAllHotelReviewsAsync
            Throw New NotImplementedException()
        End Function
    End Class
End Namespace
