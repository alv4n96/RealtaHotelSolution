Namespace Model
    Public Class Facilities
        Private _faciId As Integer
        Private _faciName As String
        Private _faciDescription As String
        Private _faciMaxNumber As Integer
        Private _faciMeasureUnit As String
        Private _faciRoomNumber As String
        Private _faciStartdate As DateTime
        Private _faciEndate As DateTime
        Private _faciLowPrice As Double
        Private _faciHighPrice As Double
        Private _faciRatePrice As Double
        Private _faciDiscount As Single
        Private _faciTaxRate As Single
        Private _faciModifiedDate As DateTime
        Private _faciCagroId As Integer
        Private _faciHotelId As Integer

        Public Sub New()
        End Sub

        Public Sub New(faciId As Integer, faciName As String, faciDescription As String, faciMaxNumber As Integer, faciMeasureUnit As String, faciRoomNumber As String, faciStartdate As Date, faciEndate As Date, faciLowPrice As Double, faciHighPrice As Double, faciRatePrice As Double, faciDiscount As Single, faciTaxRate As Single, faciModifiedDate As Date, faciCagroId As Integer, faciHotelId As Integer)
            Me.FaciId = faciId
            Me.FaciName = faciName
            Me.FaciDescription = faciDescription
            Me.FaciMaxNumber = faciMaxNumber
            Me.FaciMeasureUnit = faciMeasureUnit
            Me.FaciRoomNumber = faciRoomNumber
            Me.FaciStartdate = faciStartdate
            Me.FaciEndate = faciEndate
            Me.FaciLowPrice = faciLowPrice
            Me.FaciHighPrice = faciHighPrice
            Me.FaciRatePrice = faciRatePrice
            Me.FaciDiscount = faciDiscount
            Me.FaciTaxRate = faciTaxRate
            Me.FaciModifiedDate = faciModifiedDate
            Me.FaciCagroId = faciCagroId
            Me.FaciHotelId = faciHotelId
        End Sub

        Public Property FaciId As Integer
            Get
                Return _faciId
            End Get
            Set(value As Integer)
                _faciId = value
            End Set
        End Property

        Public Property FaciName As String
            Get
                Return _faciName
            End Get
            Set(value As String)
                _faciName = value
            End Set
        End Property

        Public Property FaciDescription As String
            Get
                Return _faciDescription
            End Get
            Set(value As String)
                _faciDescription = value
            End Set
        End Property

        Public Property FaciMaxNumber As Integer
            Get
                Return _faciMaxNumber
            End Get
            Set(value As Integer)
                _faciMaxNumber = value
            End Set
        End Property

        Public Property FaciMeasureUnit As String
            Get
                Return _faciMeasureUnit
            End Get
            Set(value As String)
                _faciMeasureUnit = value
            End Set
        End Property

        Public Property FaciRoomNumber As String
            Get
                Return _faciRoomNumber
            End Get
            Set(value As String)
                _faciRoomNumber = value
            End Set
        End Property

        Public Property FaciStartdate As Date
            Get
                Return _faciStartdate
            End Get
            Set(value As Date)
                _faciStartdate = value
            End Set
        End Property

        Public Property FaciEndate As Date
            Get
                Return _faciEndate
            End Get
            Set(value As Date)
                _faciEndate = value
            End Set
        End Property

        Public Property FaciLowPrice As Double
            Get
                Return _faciLowPrice
            End Get
            Set(value As Double)
                _faciLowPrice = value
            End Set
        End Property

        Public Property FaciHighPrice As Double
            Get
                Return _faciHighPrice
            End Get
            Set(value As Double)
                _faciHighPrice = value
            End Set
        End Property

        Public Property FaciRatePrice As Double
            Get
                Return _faciRatePrice
            End Get
            Set(value As Double)
                _faciRatePrice = value
            End Set
        End Property

        Public Property FaciDiscount As Single
            Get
                Return _faciDiscount
            End Get
            Set(value As Single)
                _faciDiscount = value
            End Set
        End Property

        Public Property FaciTaxRate As Single
            Get
                Return _faciTaxRate
            End Get
            Set(value As Single)
                _faciTaxRate = value
            End Set
        End Property

        Public Property FaciModifiedDate As Date
            Get
                Return _faciModifiedDate
            End Get
            Set(value As Date)
                _faciModifiedDate = value
            End Set
        End Property

        Public Property FaciCagroId As Integer
            Get
                Return _faciCagroId
            End Get
            Set(value As Integer)
                _faciCagroId = value
            End Set
        End Property

        Public Property FaciHotelId As Integer
            Get
                Return _faciHotelId
            End Get
            Set(value As Integer)
                _faciHotelId = value
            End Set
        End Property

        Public Overrides Function ToString() As String
            Return $"
Fasilitas ID : {FaciId}{vbTab} | Fasilitas : {FaciName}	
Deskripsi : {FaciDescription}	
Berisi : {FaciMeasureUnit}     {vbTab} | Kapasitas : {FaciMaxNumber} {vbTab} {vbTab} | Number : {FaciRoomNumber}	
Harga Rendah : {FaciLowPrice} {vbTab} | Harga Maksimum : {FaciHighPrice} {vbTab} | Pajak  : {FaciTaxRate}
Nomor Kategori : {FaciCagroId}  {vbTab} | HotelId : {FaciHotelId} {vbTab}
Tanggal Awal {vbTab}{vbTab} : {FaciStartdate} 
Tanggal Akhir {vbTab}{vbTab} : {FaciEndate}
Tanggal Pembaharuan {vbTab} : {FaciModifiedDate}
"
        End Function
    End Class
End Namespace
