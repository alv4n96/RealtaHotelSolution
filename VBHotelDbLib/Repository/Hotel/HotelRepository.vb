Imports System.Data.SqlClient
Imports VBHotelDbLib.Context
Imports VBHotelDbLib.Model

Namespace Repository
    Public Class HotelRepository
        Implements IHotelRepository

        'dependency injection
        Private ReadOnly _context As IRepositoryContext

        Public Sub New()
        End Sub

        Public Sub New(context As IRepositoryContext)
            _context = context
        End Sub

        Public Function FindHotelById(id As Integer) As Hotel Implements IHotelRepository.FindHotelById
            Dim resHotel As New Hotel With {.HotelId = id}

            Dim sql As String = "Select hotel_id, hotel_name, hotel_description, " &
                                "hotel_rating_star, hotel_phonenumber, hotel_modified_date, hotel_addr_id " &
                                "FROM Hotel.Hotels " &
                                "WHERE hotel_id = @hotelId;"
            Using cnn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = cnn, .CommandText = sql}
                    cmd.Parameters.AddWithValue("@hotelId", id)

                    Try
                        cnn.Open()
                        Dim reader = cmd.ExecuteReader()
                        If reader.HasRows Then
                            reader.Read()


                            resHotel.HotelName = reader.GetString(1)
                            resHotel.HotelDescription = reader.GetString(2)
                            resHotel.HotelRatingStar = reader.GetInt16(3)
                            resHotel.HotelPhonenumber = reader.GetString(4)
                            resHotel.HotelModifiedDate = reader.GetDateTime(5)
                            resHotel.HotelAddrId = reader.GetInt32(6)
                        Else
                            resHotel.HotelName = "Data Not Found"
                            resHotel.HotelDescription = "Data Not Found"
                            resHotel.HotelRatingStar = 0
                            resHotel.HotelPhonenumber = "Data Not Found"
                            resHotel.HotelModifiedDate = ""
                            resHotel.HotelAddrId = 0

                        End If

                        reader.Close()
                        cnn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using

            Return resHotel
        End Function

        Public Function FindAllHotel() As List(Of Hotel) Implements IHotelRepository.FindAllHotel
            Dim listHotel As New List(Of Hotel)

            Dim sql As String = "SELECT hotel_id, hotel_name, hotel_description, " &
                                "hotel_rating_star, hotel_phonenumber, hotel_modified_date, hotel_addr_id " &
                                "FROM Hotel.Hotels"

            Using cnn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = cnn, .CommandText = sql}
                    Try
                        cnn.Open()

                        Dim reader = cmd.ExecuteReader()
                        Console.WriteLine("sebelum memanggil read")
                        While reader.Read()
                            listHotel.Add(New Hotel() With {
                                     .HotelId = reader.GetInt32(0),
                                     .HotelName = reader.GetString(1),
                                     .HotelDescription = reader.GetString(2),
                                     .HotelRatingStar = reader.GetInt16(3),
                                     .HotelPhonenumber = reader.GetString(4),
                                     .HotelModifiedDate = reader.GetDateTime(5),
                                     .HotelAddrId = reader.GetInt32(6)
                            })
                        End While

                        reader.Close()
                        cnn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using

            Return listHotel
        End Function

        Public Function CreateHotel(region As Hotel) As Hotel Implements IHotelRepository.CreateHotel
            Throw New NotImplementedException()
        End Function

        Public Function UpdateHotelById(id As Integer, value As String, Optional showCommand As Boolean = False) As Boolean Implements IHotelRepository.UpdateHotelById
            Throw New NotImplementedException()
        End Function

        Public Function UpdateHotelBySp(id As Integer, value As String, Optional showCommand As Boolean = False) As Boolean Implements IHotelRepository.UpdateHotelBySp
            Throw New NotImplementedException()
        End Function

        Public Function DeleteHotel(id As Integer) As Integer Implements IHotelRepository.DeleteHotel
            Throw New NotImplementedException()
        End Function

        Public Function FindAllHotelAsync() As Task(Of List(Of Hotel)) Implements IHotelRepository.FindAllHotelAsync
            Throw New NotImplementedException()
        End Function
    End Class
End Namespace
