Imports VBHotelDbLib.Context
Imports VBHotelDbLib.Model

Namespace Repository
    Public Class FacilityPhotosRepository
        Implements IFacilityPhotosRepository

        Private ReadOnly _context As IRepositoryContext

        Public Sub New()
        End Sub

        Public Sub New(context As IRepositoryContext)
            _context = context
        End Sub

        Public Function FindFacilityPhotosById(id As Integer) As FacilityPhotos Implements IFacilityPhotosRepository.FindFacilityPhotosById

        End Function

        Public Function FindAllFacilityPhotos() As List(Of FacilityPhotos) Implements IFacilityPhotosRepository.FindAllFacilityPhotos
            Throw New NotImplementedException()
        End Function

        Public Function CreateFacilityPhotos(facilityPhotos As FacilityPhotos) As FacilityPhotos Implements IFacilityPhotosRepository.CreateFacilityPhotos
            Throw New NotImplementedException()
        End Function

        Public Function UpdateFacilityPhotosById(faphoId As Integer, faphoThumbnailFilename As String, faphoPhotoFilename As String, faphoPrimary As Byte, faphoUrl As String, faphoModifiedDate As Date, faphoFaciId As Integer, Optional showCommand As Boolean = False) As Boolean Implements IFacilityPhotosRepository.UpdateFacilityPhotosById
            Throw New NotImplementedException()
        End Function

        Public Function UpdateFacilityPhotosBySp(faphoId As Integer, faphoThumbnailFilename As String, faphoPhotoFilename As String, faphoPrimary As Byte, faphoUrl As String, faphoModifiedDate As Date, faphoFaciId As Integer, Optional showCommand As Boolean = False) As Boolean Implements IFacilityPhotosRepository.UpdateFacilityPhotosBySp
            Throw New NotImplementedException()
        End Function

        Public Function DeleteFacilityPhotos(id As Integer) As Integer Implements IFacilityPhotosRepository.DeleteFacilityPhotos
            'Throw New NotImplementedException()
            Return id
        End Function

        Public Function FindAllFacilityPhotosAsync() As Task(Of List(Of FacilityPhotos)) Implements IFacilityPhotosRepository.FindAllFacilityPhotosAsync
            Throw New NotImplementedException()
        End Function
    End Class
End Namespace
