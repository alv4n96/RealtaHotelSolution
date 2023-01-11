Namespace Model
    Public Class FacilityPhotos
        Private _faphoId As Integer
        Private _faphoThumbnailFilename As String
        Private _faphoPhotoFilename As String
        Private _faphoPrimary As Byte
        Private _faphoUrl As String
        Private _faphoModifiedDate As DateTime
        Private _faphoFaciId As Integer

        Public Sub New()
        End Sub

        Public Sub New(faphoId As Integer, faphoThumbnailFilename As String, faphoPhotoFilename As String, faphoPrimary As Byte, faphoUrl As String, faphoModifiedDate As Date, faphoFaciId As Integer)
            Me.FaphoId = faphoId
            Me.FaphoThumbnailFilename = faphoThumbnailFilename
            Me.FaphoPhotoFilename = faphoPhotoFilename
            Me.FaphoPrimary = faphoPrimary
            Me.FaphoUrl = faphoUrl
            Me.FaphoModifiedDate = faphoModifiedDate
            Me.FaphoFaciId = faphoFaciId
        End Sub

        Public Property FaphoId As Integer
            Get
                Return _faphoId
            End Get
            Set(value As Integer)
                _faphoId = value
            End Set
        End Property

        Public Property FaphoThumbnailFilename As String
            Get
                Return _faphoThumbnailFilename
            End Get
            Set(value As String)
                _faphoThumbnailFilename = value
            End Set
        End Property

        Public Property FaphoPhotoFilename As String
            Get
                Return _faphoPhotoFilename
            End Get
            Set(value As String)
                _faphoPhotoFilename = value
            End Set
        End Property

        Public Property FaphoPrimary As Byte
            Get
                Return _faphoPrimary
            End Get
            Set(value As Byte)
                _faphoPrimary = value
            End Set
        End Property

        Public Property FaphoUrl As String
            Get
                Return _faphoUrl
            End Get
            Set(value As String)
                _faphoUrl = value
            End Set
        End Property

        Public Property FaphoModifiedDate As Date
            Get
                Return _faphoModifiedDate
            End Get
            Set(value As Date)
                _faphoModifiedDate = value
            End Set
        End Property

        Public Property FaphoFaciId As Integer
            Get
                Return _faphoFaciId
            End Get
            Set(value As Integer)
                _faphoFaciId = value
            End Set
        End Property

        Public Overrides Function ToString() As String
            Return $"
Photo ID    : {FaphoId} | Facility ID : {FaphoFaciId} | Primary : {FaphoPrimary}
Thumbnail   : {FaphoThumbnailFilename}
Filename    : {FaphoPhotoFilename}
URL         : {FaphoUrl}
Modif Date  : {FaphoModifiedDate}
"
        End Function
    End Class
End Namespace
