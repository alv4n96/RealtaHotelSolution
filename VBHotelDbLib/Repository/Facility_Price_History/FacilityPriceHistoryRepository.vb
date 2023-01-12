Imports System.Data
Imports System.Data.SqlClient
Imports HotelRealtaVbNetApi.Context
Imports HotelRealtaVbNetApi.Model
Imports VBHotelDbLib.Context
Imports VBHotelDbLib.Model

Namespace Repository
    Public Class FacilityPriceHistoryRepository
        Implements IFacilityPriceHistoryRepository

        Private ReadOnly _context As RepositoryContext

        Public Sub New()
        End Sub

        Public Sub New(context As RepositoryContext)
            _context = context
        End Sub

        Public Function FindAllFaph() As List(Of FacilityPriceHistory) Implements IFacilityPriceHistoryRepository.FindAllFaph
            Dim resFaph As New List(Of FacilityPriceHistory)

            Dim sql As String = "SELECT * FROM Hotel.Facility_Price_History"

            Using cnn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = cnn, .CommandText = sql}
                    Try
                        cnn.Open()
                        Dim reader = cmd.ExecuteReader()

                        While reader.Read()
                            resFaph.Add(New FacilityPriceHistory() With {
                                .FaphId = reader.GetInt32(0),
                                .FaphStartdate = reader.GetDateTime(1),
                                .FaphEnddate = reader.GetDateTime(2),
                                .FaphLowPrice = reader.GetSqlMoney(3),
                                .FaphHighPrice = reader.GetSqlMoney(4),
                                .FaphRatePrice = reader.GetSqlMoney(5),
                                .FaphDiscount = reader.GetSqlMoney(6),
                                .FaphTaxRate = reader.GetSqlMoney(7),
                                .FaphModifiedDate = reader.GetDateTime(8),
                                .FaphFaciId = reader.GetInt32(9)
                            })
                        End While

                        reader.Close()
                        cnn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return resFaph
        End Function

        Public Function FindFaphById(id As Integer) As FacilityPriceHistory Implements IFacilityPriceHistoryRepository.FindFaphById
            Dim resFaPH = New FacilityPriceHistory With {.FaphId = id}

            Dim sql As String = "SELECT * FROM Hotel.Facility_Price_History " &
                                "WHERE faph_id = @faphId;"

            Using cnn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = cnn, .CommandText = sql}
                    cmd.Parameters.AddWithValue("@faphId", id)

                    Try
                        cnn.Open()

                        Dim reader = cmd.ExecuteReader()

                        If reader.HasRows Then
                            reader.Read()

                            resFaPH.FaphStartdate = reader.GetDateTime(1)
                            resFaPH.FaphEnddate = reader.GetDateTime(2)
                            resFaPH.FaphLowPrice = reader.GetSqlMoney(3)
                            resFaPH.FaphHighPrice = reader.GetSqlMoney(4)
                            resFaPH.FaphRatePrice = reader.GetSqlMoney(5)
                            resFaPH.FaphDiscount = reader.GetSqlMoney(6)
                            resFaPH.FaphTaxRate = reader.GetSqlMoney(7)
                            resFaPH.FaphModifiedDate = reader.GetDateTime(8)
                            resFaPH.FaphFaciId = reader.GetInt32(9)
                        Else
                            resFaPH.FaphStartdate = "01/01/0001 00:00:00"
                            resFaPH.FaphEnddate = "01/01/0001 00:00:00"
                            resFaPH.FaphLowPrice = 0
                            resFaPH.FaphHighPrice = 0
                            resFaPH.FaphRatePrice = 0
                            resFaPH.FaphDiscount = 0
                            resFaPH.FaphTaxRate = 0
                            resFaPH.FaphModifiedDate = "01/01/0001 00:00:00"
                            resFaPH.FaphFaciId = 0
                        End If
                        reader.Close
                        cnn.Close
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return resFaPH
        End Function

        Public Function FindFaphByIdFaciId(id As Integer) As List(Of FacilityPriceHistory) Implements IFacilityPriceHistoryRepository.FindFaphByIdFaciId
            Dim resFaPHByFaci As New List(Of FacilityPriceHistory)

            Dim sql As String = "SELECT * FROM Hotel.Facility_Price_History " &
                                "WHERE faph_faci_id = @faphFaciId;"

            Using cnn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = cnn, .CommandText = sql}

                    cmd.Parameters.AddWithValue("@faphFaciId", id)

                    Try
                        cnn.Open()

                        Dim reader = cmd.ExecuteReader()

                        If reader.HasRows Then
                            While reader.Read()
                                resFaPHByFaci.Add(New FacilityPriceHistory With {
                                .FaphFaciId = reader.GetInt32(9),
                                .FaphId = reader.GetInt32(0),
                                .FaphStartdate = reader.GetDateTime(1),
                                .FaphEnddate = reader.GetDateTime(2),
                                .FaphLowPrice = reader.GetSqlMoney(3),
                            .FaphHighPrice = reader.GetSqlMoney(4),
                            .FaphRatePrice = reader.GetSqlMoney(5),
                            .FaphDiscount = reader.GetSqlMoney(6),
                            .FaphTaxRate = reader.GetSqlMoney(7),
                            .FaphModifiedDate = reader.GetDateTime(8)
                            })
                            End While
                        Else
                            resFaPHByFaci.Add(New FacilityPriceHistory With {
                            .FaphFaciId = 0,
                            .FaphId = 0,
                            .FaphStartdate = "01/01/0001 00:00:00",
                            .FaphEnddate = "01/01/0001 00:00:00",
                            .FaphLowPrice = 0,
                            .FaphHighPrice = 0,
                            .FaphRatePrice = 0,
                            .FaphDiscount = 0,
                            .FaphTaxRate = 0,
                            .FaphModifiedDate = "01/01/0001 00:00:00"
                                })
                        End If


                        reader.Close()
                        cnn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return resFaPHByFaci
        End Function

        Public Async Function FindAllFaphReviewsAsync() As Task(Of List(Of FacilityPriceHistory)) Implements IFacilityPriceHistoryRepository.FindAllFaphReviewsAsync
            Dim resFaph As New List(Of FacilityPriceHistory)

            Dim sql As String = "SELECT * FROM Hotel.Facility_Price_History"

            Using cnn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = cnn, .CommandText = sql}
                    Try
                        cnn.Open()
                        Dim reader = Await cmd.ExecuteReaderAsync()

                        While reader.Read()
                            resFaph.Add(New FacilityPriceHistory() With {
                                .FaphId = reader.GetInt32(0),
                                .FaphStartdate = reader.GetDateTime(1),
                                .FaphEnddate = reader.GetDateTime(2),
                                .FaphLowPrice = reader.GetSqlMoney(3),
                                .FaphHighPrice = reader.GetSqlMoney(4),
                                .FaphRatePrice = reader.GetSqlMoney(5),
                                .FaphDiscount = reader.GetSqlMoney(6),
                                .FaphTaxRate = reader.GetSqlMoney(7),
                                .FaphModifiedDate = reader.GetDateTime(8),
                                .FaphFaciId = reader.GetInt32(9)
                            })
                        End While

                        reader.Close()
                        cnn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using
            Return resFaph
        End Function
    End Class
End Namespace
