Imports VBHotelDbLib.Context
Imports VBHotelDbLib.Model
Imports VBHotelDbLib.Repository

Namespace Base
    Public Class RepositoryManager
        Implements IRepositoryManager

        Private ReadOnly _repositoryContext As IRepositoryContext

        Private _hotelRepository As IHotelRepository
        Private _hotelReviewsRepository As IHotelReviewsRepository
        Private _facilitiesRepository As IFacilitiesRepository
        Private _facilityPhotos As IFacilityPhotosRepository

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

        Public ReadOnly Property Facilities As IFacilitiesRepository Implements IRepositoryManager.Facilities
            Get
                'Up IFacilities & Implementation
                If _facilitiesRepository Is Nothing Then
                    _facilitiesRepository = New FacilitiesRepository(_repositoryContext)
                End If
                Return _facilitiesRepository
            End Get
        End Property

        Public ReadOnly Property FacilityPhotos As IFacilityPhotosRepository Implements IRepositoryManager.FacilityPhotos
            Get
                If _facilityPhotos Is Nothing Then
                    _facilityPhotos = New FacilityPhotosRepository(_repositoryContext)
                End If
                Return _facilityPhotos
            End Get
        End Property
    End Class
End Namespace
