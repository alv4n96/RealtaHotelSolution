Imports VBHotelDbLib.Model

Namespace Repository
    Public Interface IFacilityPhotosRepository
        Function FindFacilityPhotosById(ByVal id As Int32) As FacilityPhotos

        Function FindAllFacilityPhotos() As List(Of FacilityPhotos)

        Function CreateFacilityPhotos(ByVal facilityPhotos As FacilityPhotos) As FacilityPhotos

        Function UpdateFacilityPhotosById(faphoId As Integer, faphoThumbnailFilename As String, faphoPhotoFilename As String, faphoPrimary As Boolean, faphoUrl As String, faphoModifiedDate As Date, faphoFaciId As Integer, Optional showCommand As Boolean = False) As Boolean

        Function UpdateFacilityPhotosBySp(faphoId As Integer, faphoThumbnailFilename As String, faphoPhotoFilename As String, faphoPrimary As Boolean, faphoUrl As String, faphoModifiedDate As Date, faphoFaciId As Integer, Optional showCommand As Boolean = False) As Boolean

        Function DeleteFacilityPhotos(ByVal id As Integer) As Int32

        Function FindAllFacilityPhotosAsync() As Task(Of List(Of FacilityPhotos))

    End Interface
End Namespace
