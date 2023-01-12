Namespace Model
    Public Class FacilityPriceHistory
        Private _faphId As Integer
        Private _faphFaciId As Integer
        Private _faphStartdate As DateTime
        Private _faphEnddate As DateTime
        Private _faphLowPrice As Double
        Private _faphHighPrice As Double
        Private _faphRatePrice As Double
        Private _faphDiscount As Single
        Private _faphTaxRate As Single
        Private _faphModifiedDate As DateTime

        Public Sub New()
        End Sub

        Public Sub New(faphId As Integer, faphFaciId As Integer, faphStartdate As Date, faphEnddate As Date, faphLowPrice As Double, faphHighPrice As Double, faphRatePrice As Double, faphDiscount As Single, faphTaxRate As Single, faphModifiedDate As Date)
            Me.FaphId = faphId
            Me.FaphFaciId = faphFaciId
            Me.FaphStartdate = faphStartdate
            Me.FaphEnddate = faphEnddate
            Me.FaphLowPrice = faphLowPrice
            Me.FaphHighPrice = faphHighPrice
            Me.FaphRatePrice = faphRatePrice
            Me.FaphDiscount = faphDiscount
            Me.FaphTaxRate = faphTaxRate
            Me.FaphModifiedDate = faphModifiedDate
        End Sub

        Public Property FaphId As Integer
            Get
                Return _faphId
            End Get
            Set(value As Integer)
                _faphId = value
            End Set
        End Property

        Public Property FaphFaciId As Integer
            Get
                Return _faphFaciId
            End Get
            Set(value As Integer)
                _faphFaciId = value
            End Set
        End Property

        Public Property FaphStartdate As Date
            Get
                Return _faphStartdate
            End Get
            Set(value As Date)
                _faphStartdate = value
            End Set
        End Property

        Public Property FaphEnddate As Date
            Get
                Return _faphEnddate
            End Get
            Set(value As Date)
                _faphEnddate = value
            End Set
        End Property

        Public Property FaphLowPrice As Double
            Get
                Return _faphLowPrice
            End Get
            Set(value As Double)
                _faphLowPrice = value
            End Set
        End Property

        Public Property FaphHighPrice As Double
            Get
                Return _faphHighPrice
            End Get
            Set(value As Double)
                _faphHighPrice = value
            End Set
        End Property

        Public Property FaphRatePrice As Double
            Get
                Return _faphRatePrice
            End Get
            Set(value As Double)
                _faphRatePrice = value
            End Set
        End Property

        Public Property FaphDiscount As Single
            Get
                Return _faphDiscount
            End Get
            Set(value As Single)
                _faphDiscount = value
            End Set
        End Property

        Public Property FaphTaxRate As Single
            Get
                Return _faphTaxRate
            End Get
            Set(value As Single)
                _faphTaxRate = value
            End Set
        End Property

        Public Property FaphModifiedDate As Date
            Get
                Return _faphModifiedDate
            End Get
            Set(value As Date)
                _faphModifiedDate = value
            End Set
        End Property

        Public Overrides Function ToString() As String
            Return $"
History id : {FaphId} {vbTab} | Facility id : {FaphFaciId}
History Low Price  : {FaphLowPrice}
History High Price : {FaphHighPrice}
History Rate Price : {FaphRatePrice}
History Discount   : {FaphDiscount}
History Tax Rate   : {FaphTaxRate}
History Start Date : {FaphStartdate} 
History End Date   : {FaphEnddate}
History Modif Date : {FaphModifiedDate}
"
        End Function
    End Class
End Namespace
