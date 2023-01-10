Imports VBHotelDbLib.Model

Namespace Repository
    Public Interface IFacilitiesRepository
        Function FindAllFacilities() As List(Of Facilities)

        Function FindFacilitiesById(ByVal id As Int32) As Facilities

        Function CreateFacilities(ByVal facilities As Facilities) As Facilities

        Function UpdateFacilitiesById(id As Integer, faciName As String, faciDescription As String, faciMaxNumber As Integer, faciMeasureUnit As String, faciRoomNumber As String, faciStartdate As Date, faciEndate As Date, faciLowPrice As Double, faciHighPrice As Double, faciRatePrice As Double, faciDiscount As Single, faciTaxRate As Single, faciModifiedDate As Date, faciCagroId As Integer, faciHotelId As Integer, Optional showCommand As Boolean = False) As Boolean

        Function UpdateFacilitiesBySp(id As Integer, faciName As String, faciDescription As String, faciMaxNumber As Integer, faciMeasureUnit As String, faciRoomNumber As String, faciStartdate As Date, faciEndate As Date, faciLowPrice As Double, faciHighPrice As Double, faciRatePrice As Double, faciDiscount As Single, faciTaxRate As Single, faciModifiedDate As Date, faciCagroId As Integer, faciHotelId As Integer, Optional showCommand As Boolean = False) As Boolean

        Function DeleteFacilities(ByVal id As Integer) As Int32

        Function FindAllFacilitiesAsync() As Task(Of List(Of Facilities))

    End Interface
End Namespace
