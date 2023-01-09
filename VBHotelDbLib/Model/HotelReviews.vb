Namespace Model
    Public Class HotelReviews

        Private _horeId As Integer
        Private _horeUserReview As String
        Private _horeRating As Int16
        Private _horeCreatedOn As DateTime
        Private _horeUserId As Integer
        Private _horeHotelId As Integer

        Public Sub New(horeId As Integer, horeUserReview As String, horeRating As Short, horeCreatedOn As Date, horeUserId As Integer, horeHotelId As Integer)
            Me.HoreId = horeId
            Me.HoreUserReview = horeUserReview
            Me.HoreRating = horeRating
            Me.HoreCreatedOn = horeCreatedOn
            Me.HoreUserId = horeUserId
            Me.HoreHotelId = horeHotelId
        End Sub

        Public Property HoreId As Integer
            Get
                Return _horeId
            End Get
            Set(value As Integer)
                _horeId = value
            End Set
        End Property

        Public Property HoreUserReview As String
            Get
                Return _horeUserReview
            End Get
            Set(value As String)
                _horeUserReview = value
            End Set
        End Property

        Public Property HoreRating As Short
            Get
                Return _horeRating
            End Get
            Set(value As Short)
                _horeRating = value
            End Set
        End Property

        Public Property HoreCreatedOn As Date
            Get
                Return _horeCreatedOn
            End Get
            Set(value As Date)
                _horeCreatedOn = value
            End Set
        End Property

        Public Property HoreUserId As Integer
            Get
                Return _horeUserId
            End Get
            Set(value As Integer)
                _horeUserId = value
            End Set
        End Property

        Public Property HoreHotelId As Integer
            Get
                Return _horeHotelId
            End Get
            Set(value As Integer)
                _horeHotelId = value
            End Set
        End Property

        Public Overrides Function ToString() As String
            Return $" === Data Review ===
Review : 
{HoreUserReview}
Review Id : {HoreId} | Rating : {HoreRating} | UserId : {HoreUserId} | HotelId : {HoreHotelId} | Date : {HoreCreatedOn}"
        End Function
    End Class
End Namespace
