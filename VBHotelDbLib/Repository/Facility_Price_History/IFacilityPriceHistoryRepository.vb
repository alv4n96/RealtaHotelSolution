Imports VBHotelDbLib.Model

Namespace Repository
    Public Interface IFacilityPriceHistoryRepository
        Function FindAllFaph() As List(Of FacilityPriceHistory)

        Function FindFaphById(ByVal id As Integer) As FacilityPriceHistory

        Function FindFaphByIdFaciId(ByVal id As Integer) As List(Of FacilityPriceHistory)

    End Interface
End Namespace
