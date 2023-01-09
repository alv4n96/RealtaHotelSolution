Imports VBHotelDbLib.Model

Namespace Repository
    Public Interface IHotelRepository

        Function FindHotelById(ByVal id As Int32) As Hotel

        Function FindAllHotel() As List(Of Hotel)

        Function CreateHotel(ByVal hotel As Hotel) As Hotel

        Function UpdateHotelById(id As Integer, hotelName As String, hotelDescription As String, hotelRatingStar As Byte, hotelPhonenumber As String, hotelModifiedDate As DateTime, hotelAddrId As Integer, Optional showCommand As Boolean = False) As Boolean

        Function UpdateHotelBySp(id As Integer, hotelName As String, hotelDescription As String, hotelRatingStar As Byte, hotelPhonenumber As String, hotelModifiedDate As DateTime, hotelAddrId As Integer, Optional showCommand As Boolean = False) As Boolean

        Function DeleteHotel(ByVal id As Integer) As Int32

        Function FindAllHotelAsync() As Task(Of List(Of Hotel))

    End Interface
End Namespace
