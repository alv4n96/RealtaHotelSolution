Imports VBHotelDbLib.Context
Imports VBHotelDbLib.Repository

Namespace Base
    Public Class RepositoryManager
        Implements IRepositoryManager

        Private ReadOnly _repositoryContext As IRepositoryContext

        Private _hotelRepository As IHotelRepository
        Private _hotelReviewsRepository As IHotelReviewsRepository

        Public Sub New(repositoryContext As IRepositoryContext)
            _repositoryContext = repositoryContext
        End Sub

        Public ReadOnly Property Hotel As IHotelRepository Implements IRepositoryManager.Hotel
            Get
                'up IHotel & implementation
                If _hotelRepository Is Nothing Then
                    _hotelRepository = New HotelRepository(_repositoryContext)
                End If
                Return _hotelRepository
            End Get
        End Property

        Public ReadOnly Property HotelReviews As IHotelReviewsRepository Implements IRepositoryManager.HotelReviews
            Get
                'Up IHotelReviews & Implementation
                If _hotelReviewsRepository Is Nothing Then
                    _hotelReviewsRepository = New HotelReviewsRepository(_repositoryContext)
                End If
                Return _hotelReviewsRepository
            End Get
        End Property
    End Class
End Namespace
