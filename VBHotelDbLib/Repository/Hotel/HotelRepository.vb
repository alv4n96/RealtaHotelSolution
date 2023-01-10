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
                            resHotel.HotelModifiedDate = "01/01/0001 00:00:00"
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

        Public Function CreateHotel(hotel As Hotel) As Hotel Implements IHotelRepository.CreateHotel
            Dim newHotel As New Hotel()

            Dim sql As String = "INSERT INTO Hotel.Hotels " &
                                "(hotel_name, hotel_description, hotel_rating_star, hotel_phonenumber, " &
                                "hotel_modified_date, hotel_addr_id) " &
                                "values (@hotelName, @hotelDescription, @hotelRatingStar, @hotelPhonenumber, @hotelModifiedDate, @hotelAddrId);" &
                                "SELECT IDENT_CURRENT('Hotel.Hotels');"

            Using cnn As New SqlConnection With {.ConnectionString = _context.GetConnectionString()}
                Using cmd As New SqlCommand With {.Connection = cnn, .CommandText = sql}
                    cmd.Parameters.AddWithValue("@hotelName", hotel.HotelName)
                    cmd.Parameters.AddWithValue("@hotelDescription", hotel.HotelDescription)
                    cmd.Parameters.AddWithValue("@hotelRatingStar", hotel.HotelRatingStar)
                    cmd.Parameters.AddWithValue("@hotelPhonenumber", hotel.HotelPhonenumber)
                    cmd.Parameters.AddWithValue("@hotelModifiedDate", hotel.HotelModifiedDate)
                    cmd.Parameters.AddWithValue("@hotelAddrId", hotel.HotelAddrId)

                    Try
                        cnn.Open()

                        Dim hotelId = cmd.ExecuteScalar
                        newHotel = FindHotelById(hotelId)

                        cnn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using

            Return newHotel
        End Function

        Public Function UpdateHotelById(id As Integer, hotelName As String, hotelDescription As String, hotelRatingStar As Byte, hotelPhonenumber As String, hotelModifiedDate As Date, hotelAddrId As Integer, Optional showCommand As Boolean = False) As Boolean Implements IHotelRepository.UpdateHotelById
            'declare statement
            Dim sql As String = "UPDATE Hotel.Hotels " &
                                      "SET " &
                                      "hotel_name = @hotelName, " &
                                      "hotel_description = @hotelDescription, " &
                                      "hotel_rating_star = @hotelRatingStar, " &
                                      "hotel_phonenumber = @hotelPhonenumber, " &
                                      "hotel_modified_date = @hotelModifiedDate, " &
                                      "hotel_addr_id = @hotelAddrId " &
                                      "WHERE hotel_id = @hotelId;"

            Using cnn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = cnn, .CommandText = sql}
                    cmd.Parameters.AddWithValue("@hotelId", id)
                    cmd.Parameters.AddWithValue("@hotelName", hotelName)
                    cmd.Parameters.AddWithValue("@hotelDescription", hotelDescription)
                    cmd.Parameters.AddWithValue("@hotelRatingStar", hotelRatingStar)
                    cmd.Parameters.AddWithValue("@hotelPhonenumber", hotelPhonenumber)
                    cmd.Parameters.AddWithValue("@hotelModifiedDate", hotelModifiedDate)
                    cmd.Parameters.AddWithValue("@hotelAddrId", hotelAddrId)

                    'Show command
                    If showCommand Then
                        Console.WriteLine(cmd.CommandText)
                    End If

                    Try
                        cnn.Open()
                        cmd.ExecuteNonQuery()

                        cnn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try

                End Using
            End Using

            Return showCommand
        End Function


        Public Function UpdateHotelBySp(id As Integer, hotelName As String, hotelDescription As String, hotelRatingStar As Byte, hotelPhonenumber As String, hotelModifiedDate As Date, hotelAddrId As Integer, Optional showCommand As Boolean = False) As Boolean Implements IHotelRepository.UpdateHotelBySp

            Dim sql As String = "sp_update_hotel"


            Using cnn As New SqlConnection With {
                .ConnectionString = _context.GetConnectionString
            }
                Using cmd As New SqlCommand With {
                    .Connection = cnn,
                    .CommandText = sql,
                    .CommandType = Data.CommandType.StoredProcedure
                }
                    cmd.Parameters.AddWithValue("@hotelId", id)
                    cmd.Parameters.AddWithValue("@hotelName", hotelName)
                    cmd.Parameters.AddWithValue("@hotelDescription", hotelDescription)
                    cmd.Parameters.AddWithValue("@hotelRatingStar", hotelRatingStar)
                    cmd.Parameters.AddWithValue("@hotelPhonenumber", hotelPhonenumber)
                    cmd.Parameters.AddWithValue("@hotelModifiedDate", hotelModifiedDate)
                    cmd.Parameters.AddWithValue("@hotelAddrId", hotelAddrId)

                    'showCommand
                    If showCommand Then
                        Console.WriteLine(cmd.CommandText)
                    End If

                    Try
                        cnn.Open()
                        cmd.ExecuteNonQuery()

                        cnn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using

            Return True
        End Function

        Public Function DeleteHotel(id As Integer) As Integer Implements IHotelRepository.DeleteHotel
            Dim rowEffect As Int32 = 0

            'declare statement
            Dim sql As String = "DELETE FROM Hotel.Hotels " &
                                      "WHERE hotel_id = @hotelId"

            Using cnn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = cnn, .CommandText = sql}
                    cmd.Parameters.AddWithValue("@hotelId", id)

                    Try
                        cnn.Open()
                        rowEffect = cmd.ExecuteNonQuery()

                        cnn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using

            Return rowEffect
        End Function

        Public Async Function FindAllHotelAsync() As Task(Of List(Of Hotel)) Implements IHotelRepository.FindAllHotelAsync
            Dim listHotel As New List(Of Hotel)

            Dim sql As String = "SELECT hotel_id, hotel_name, hotel_description, " &
                                "hotel_rating_star, hotel_phonenumber, hotel_modified_date, hotel_addr_id " &
                                "FROM Hotel.Hotels"

            Using cnn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = cnn, .CommandText = sql}
                    Try
                        cnn.Open()

                        Dim reader = Await cmd.ExecuteReaderAsync()

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
    End Class
End Namespace
