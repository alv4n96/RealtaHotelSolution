Imports System.Data.SqlClient
Imports System.Diagnostics.Eventing
Imports System.Runtime.InteropServices
Imports VBHotelDbLib.Context
Imports VBHotelDbLib.Model

Namespace Repository
    Public Class FacilitiesRepository
        Implements IFacilitiesRepository

        'dependency injection
        Private ReadOnly _context As IRepositoryContext

        Public Sub New()
        End Sub

        Public Sub New(context As IRepositoryContext)
            _context = context
        End Sub

        Public Function FindAllFacilities() As List(Of Facilities) Implements IFacilitiesRepository.FindAllFacilities
            Dim resFacilities = New List(Of Facilities)

            Dim sql = "SELECT * FROM Hotel.Facilities;"

            Using cnn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = cnn, .CommandText = sql}
                    Try
                        cnn.Open()
                        Dim reader = cmd.ExecuteReader()

                        While reader.Read()
                            resFacilities.Add(New Facilities With {
                                .FaciId = reader.GetInt32(0),
                                .FaciName = reader.GetString(1),
                                .FaciDescription = If(reader.IsDBNull(2), "", reader.GetString(2)),
                                .FaciMaxNumber = If(reader.IsDBNull(3), 0, reader.GetInt32(3)),
                                .FaciMeasureUnit = If(reader.IsDBNull(4), "", reader.GetString(4)),
                                .FaciRoomNumber = reader.GetString(5),
                                .FaciStartdate = reader.GetDateTime(6),
                                .FaciEndate = reader.GetDateTime(7),
                                .FaciLowPrice = reader.GetDecimal(8),
                                .FaciHighPrice = reader.GetDecimal(9),
                                .FaciRatePrice = reader.GetDecimal(10),
                                .FaciDiscount = If(reader.IsDBNull(11), 0, reader.GetDecimal(11)),
                                .FaciTaxRate = If(reader.IsDBNull(12), 0, reader.GetDecimal(12)),
                                .FaciModifiedDate = If(reader.IsDBNull(13), "01/01/0001 00:00:00", reader.GetDateTime(13)),
                                .FaciCagroId = reader.GetInt32(14),
                                .FaciHotelId = reader.GetInt32(15)
                              })
                        End While

                        reader.Close()
                        cnn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using

            Return resFacilities
        End Function

        Public Function FindFacilitiesById(id As Integer) As Facilities Implements IFacilitiesRepository.FindFacilitiesById
            Dim resFacilities As New Facilities() With {.FaciId = id}

            Dim sql As String = "SELECT * FROM Hotel.Facilities " &
                                "WHERE faci_id = @id;"

            Using cnn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = cnn, .CommandText = sql}
                    cmd.Parameters.AddWithValue("@id", id)

                    Try
                        cnn.Open()
                        Dim reader = cmd.ExecuteReader()

                        If reader.HasRows Then
                            reader.Read()

                            resFacilities.FaciName = reader.GetString(1)
                            resFacilities.FaciDescription = If(reader.IsDBNull(2), "", reader.GetString(2))
                            resFacilities.FaciMaxNumber = If(reader.IsDBNull(3), 0, reader.GetInt32(3))
                            resFacilities.FaciMeasureUnit = If(reader.IsDBNull(4), "", reader.GetString(4))
                            resFacilities.FaciRoomNumber = reader.GetString(5)
                            resFacilities.FaciStartdate = reader.GetDateTime(6)
                            resFacilities.FaciEndate = reader.GetDateTime(7)
                            resFacilities.FaciLowPrice = reader.GetDecimal(8)
                            resFacilities.FaciHighPrice = reader.GetDecimal(9)
                            resFacilities.FaciRatePrice = reader.GetDecimal(10)
                            resFacilities.FaciDiscount = If(reader.IsDBNull(11), 0, reader.GetDecimal(11))
                            resFacilities.FaciTaxRate = If(reader.IsDBNull(12), 0, reader.GetDecimal(12))
                            resFacilities.FaciModifiedDate = If(reader.IsDBNull(13), "01/01/0001 00:00:00", reader.GetDateTime(13))
                            resFacilities.FaciCagroId = reader.GetInt32(14)
                            resFacilities.FaciHotelId = reader.GetInt32(15)

                        Else
                            resFacilities.FaciName = "DATA NOT FOUND!"
                            resFacilities.FaciDescription = "DATA NOT FOUND!"
                            resFacilities.FaciMaxNumber = 0
                            resFacilities.FaciMeasureUnit = ""
                            resFacilities.FaciRoomNumber = "NOT FOUND!"
                            resFacilities.FaciStartdate = "01/01/0001 00:00:00"
                            resFacilities.FaciEndate = "01/01/0001 00:00:00"
                            resFacilities.FaciLowPrice = 0
                            resFacilities.FaciHighPrice = 0
                            resFacilities.FaciRatePrice = 0
                            resFacilities.FaciDiscount = 0
                            resFacilities.FaciTaxRate = 0
                            resFacilities.FaciModifiedDate = "01/01/0001 00:00:00"
                            resFacilities.FaciCagroId = 0
                            resFacilities.FaciHotelId = 0
                        End If

                        reader.Close()
                        cnn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try

                    Return resFacilities
                End Using
            End Using

        End Function

        Public Function CreateFacilities(facilities As Facilities) As Facilities Implements IFacilitiesRepository.CreateFacilities
            Dim newFacilities As New Facilities()

            Dim sql As String = "INSERT INTO Hotel.Facilities " &
                                "(faci_name, faci_description, faci_max_number, faci_measure_unit, " &
                                "faci_room_number, faci_startdate, faci_endate, " &
                                "faci_low_price, faci_high_price, faci_rate_price, " &
                                "faci_discount, faci_tax_rate, faci_modified_date, faci_cagro_id, faci_hotel_id) " &
                                "VALUES" &
                                "(@faciName, @faciDescription, @faciMaxNumber, @faciMeasureUnit, " &
                                "@faciRoomNumber, @faciStartdate, @faciEndate, " &
                                "@faciLowPrice, @faciHighPrice, @faciRatePrice, " &
                                "@faciDiscount, @faciTaxRate, @faciModifiedDate, @faciCagroId, @faciHotelId)" &
                                "SELECT IDENT_CURRENT('Hotel.Facilities');"

            Using cnn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = cnn, .CommandText = sql}
                    Dim faciDescChecker = If(String.IsNullOrEmpty(facilities.FaciDescription), DBNull.Value, facilities.FaciDescription)
                    Dim faciMaxNumberChecker = If(facilities.FaciMaxNumber = 0, DBNull.Value, facilities.FaciMaxNumber)
                    Dim faciMeasureUnitChecker = If(String.IsNullOrEmpty(facilities.FaciMeasureUnit), DBNull.Value, facilities.FaciMeasureUnit)
                    Dim faciDiscountChecker = If(facilities.FaciDiscount = 0, DBNull.Value, facilities.FaciDiscount)
                    Dim faciTaxRateChecker = If(facilities.FaciTaxRate = 0, DBNull.Value, facilities.FaciTaxRate)
                    Dim faciModifDateChecker = If(String.IsNullOrEmpty(facilities.FaciModifiedDate), DBNull.Value, facilities.FaciModifiedDate)

                    cmd.Parameters.AddWithValue("@faciName", facilities.FaciName)
                    cmd.Parameters.AddWithValue("@faciDescription", faciDescChecker)
                    cmd.Parameters.AddWithValue("@faciMaxNumber", faciMaxNumberChecker)
                    cmd.Parameters.AddWithValue("@faciMeasureUnit", faciMeasureUnitChecker)
                    cmd.Parameters.AddWithValue("@faciRoomNumber", facilities.FaciRoomNumber)
                    cmd.Parameters.AddWithValue("@faciStartdate", facilities.FaciStartdate)
                    cmd.Parameters.AddWithValue("@faciEndate", facilities.FaciEndate)
                    cmd.Parameters.AddWithValue("@faciLowPrice", facilities.FaciLowPrice)
                    cmd.Parameters.AddWithValue("@faciHighPrice", facilities.FaciHighPrice)
                    cmd.Parameters.AddWithValue("@faciRatePrice", facilities.FaciRatePrice)
                    cmd.Parameters.AddWithValue("@faciDiscount", faciDiscountChecker)
                    cmd.Parameters.AddWithValue("@faciTaxRate", faciTaxRateChecker)
                    cmd.Parameters.AddWithValue("@faciModifiedDate", faciModifDateChecker)
                    cmd.Parameters.AddWithValue("@faciCagroId", facilities.FaciCagroId)
                    cmd.Parameters.AddWithValue("@faciHotelId", facilities.FaciHotelId)

                    Try
                        cnn.Open()

                        Dim facilitiesId = cmd.ExecuteScalar()
                        newFacilities = FindFacilitiesById(facilitiesId)

                        cnn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return newFacilities
        End Function

        Public Function UpdateFacilitiesById(id As Integer, faciName As String, faciDescription As String, faciMaxNumber As Integer, faciMeasureUnit As String, faciRoomNumber As String, faciStartdate As Date, faciEndate As Date, faciLowPrice As Double, faciHighPrice As Double, faciRatePrice As Double, faciDiscount As Single, faciTaxRate As Single, faciModifiedDate As Date, faciCagroId As Integer, faciHotelId As Integer, Optional showCommand As Boolean = False) As Boolean Implements IFacilitiesRepository.UpdateFacilitiesById
            Throw New NotImplementedException()
        End Function

        Public Function UpdateFacilitiesBySp(id As Integer, faciName As String, faciDescription As String, faciMaxNumber As Integer, faciMeasureUnit As String, faciRoomNumber As String, faciStartdate As Date, faciEndate As Date, faciLowPrice As Double, faciHighPrice As Double, faciRatePrice As Double, faciDiscount As Single, faciTaxRate As Single, faciModifiedDate As Date, faciCagroId As Integer, faciHotelId As Integer, Optional showCommand As Boolean = False) As Boolean Implements IFacilitiesRepository.UpdateFacilitiesBySp
            Throw New NotImplementedException()
        End Function

        Public Function DeleteFacilities(id As Integer) As Integer Implements IFacilitiesRepository.DeleteFacilities
            Throw New NotImplementedException()
        End Function

        Public Function FindAllFacilitiesAsync() As Task(Of List(Of Facilities)) Implements IFacilitiesRepository.FindAllFacilitiesAsync
            Throw New NotImplementedException()
        End Function
    End Class
End Namespace
