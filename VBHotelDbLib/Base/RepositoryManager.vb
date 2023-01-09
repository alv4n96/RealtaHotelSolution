Imports VBHotelDbLib.Context
Imports VBHotelDbLib.Repository

Namespace Base
    Public Class RepositoryManager
        Implements IRepositoryManager

        Private _hotelRepository As IHotelRepository

        Private ReadOnly _repositoryContext As IRepositoryContext

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
    End Class
End Namespace
