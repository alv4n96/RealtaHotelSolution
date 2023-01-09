Namespace Model
    Public Class Hotel
        Private _hotelId As Integer
        Private _hotelName As String
        Private _hotelDescription As String
        Private _hotelRatingStar As Byte
        Private _hotelPhonenumber As String
        Private _hotelModifiedDate As DateTime
        Private _hotelAddrId As Integer

        Public Sub New()
        End Sub

        Public Sub New(hotelId As Integer, hotelName As String, hotelDescription As String, hotelRatingStar As Byte, hotelPhonenumber As String, hotelModifiedDate As Date, hotelAddrId As Integer)
            Me.HotelId = hotelId
            Me.HotelName = hotelName
            Me.HotelDescription = hotelDescription
            Me.HotelRatingStar = hotelRatingStar
            Me.HotelPhonenumber = hotelPhonenumber
            Me.HotelModifiedDate = hotelModifiedDate
            Me.HotelAddrId = hotelAddrId
        End Sub

        Public Property HotelId As Integer
            Get
                Return _hotelId
            End Get
            Set(value As Integer)
                _hotelId = value
            End Set
        End Property

        Public Property HotelName As String
            Get
                Return _hotelName
            End Get
            Set(value As String)
                _hotelName = value
            End Set
        End Property

        Public Property HotelDescription As String
            Get
                Return _hotelDescription
            End Get
            Set(value As String)
                _hotelDescription = value
            End Set
        End Property

        Public Property HotelRatingStar As Byte
            Get
                Return _hotelRatingStar
            End Get
            Set(value As Byte)
                _hotelRatingStar = value
            End Set
        End Property

        Public Property HotelPhonenumber As String
            Get
                Return _hotelPhonenumber
            End Get
            Set(value As String)
                _hotelPhonenumber = value
            End Set
        End Property

        Public Property HotelModifiedDate As Date
            Get
                Return _hotelModifiedDate
            End Get
            Set(value As Date)
                _hotelModifiedDate = value
            End Set
        End Property

        Public Property HotelAddrId As Integer
            Get
                Return _hotelAddrId
            End Get
            Set(value As Integer)
                _hotelAddrId = value
            End Set
        End Property

        Public Overrides Function ToString() As String
            Return $"=== Data Hotel ===
ID Hotel        = {HotelId} 
Nama Hotel      = {HotelName} 
Deskripsi Hotel = {HotelDescription} 
Rating Hotel    = {HotelRatingStar} 
Kontak Hotel    = {HotelPhonenumber} 
Alamat Hotel    = {HotelAddrId} 
Modified Date   = {HotelModifiedDate} 
"
        End Function
    End Class
End Namespace
