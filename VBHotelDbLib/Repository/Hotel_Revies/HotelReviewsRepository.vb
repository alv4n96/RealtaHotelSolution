Imports System.ComponentModel
Imports System.Data
Imports System.Data.SqlClient
Imports VBHotelDbLib.Context
Imports VBHotelDbLib.Model

Namespace Repository
    Public Class HotelReviewsRepository
        Implements IHotelReviewsRepository

        'dependency injection
        Private ReadOnly _context As IRepositoryContext

        Public Sub New()
        End Sub

        Public Sub New(context As IRepositoryContext)
            _context = context
        End Sub

        Public Function FindAllHotelReviews() As List(Of HotelReviews) Implements IHotelReviewsRepository.FindAllHotelReviews
            Dim listHotelReviews As New List(Of HotelReviews)

            Dim sql As String = "SELECT hore_id, hore_user_review, hore_rating, hore_created_on, hore_user_id, hore_hotel_id " &
                                "FROM Hotel.Hotel_Reviews;"

            Using cnn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = cnn, .CommandText = sql}
                    Try
                        cnn.Open()

                        Dim reader = cmd.ExecuteReader()

                        While reader.Read()
                            listHotelReviews.Add(New HotelReviews() With {
                                .HoreId = reader.GetInt32(0),
                                .HoreUserReview = reader.GetString(1),
                                .HoreRating = reader.GetByte(2),
                                .HoreCreatedOn = If(reader.IsDBNull(3), "01/01/0001 00:00:00", reader.GetDateTime(3)),
                                .HoreUserId = reader.GetInt32(4),
                                .HoreHotelId = reader.GetInt32(5)
                            })

                        End While

                        reader.Close()
                        cnn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using

            Return listHotelReviews
        End Function

        Public Function FindHotelReviewsById(id As Integer) As HotelReviews Implements IHotelReviewsRepository.FindHotelReviewsById
            Dim resHotelReviews As New HotelReviews With {.HoreId = id}

            Dim sql As String = "SELECT hore_id, hore_user_review, hore_rating, hore_created_on, hore_user_id, hore_hotel_id " &
                                "FROM Hotel.Hotel_Reviews " &
                                "WHERE hore_id = @hotelId;"
            Using cnn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = cnn, .CommandText = sql}
                    cmd.Parameters.AddWithValue("@hotelId", id)

                    Try
                        cnn.Open()
                        Dim reader = cmd.ExecuteReader()
                        If reader.HasRows Then
                            reader.Read()

                            resHotelReviews.HoreUserReview = reader.GetString(1)
                            resHotelReviews.HoreRating = reader.GetByte(2)
                            resHotelReviews.HoreCreatedOn = If(reader.IsDBNull(3), "01/01/0001 00:00:00", reader.GetDateTime(3))
                            resHotelReviews.HoreUserId = reader.GetInt32(4)
                            resHotelReviews.HoreHotelId = reader.GetInt32(5)
                        Else
                            resHotelReviews.HoreUserReview = "DATA NOT FOUND"
                            resHotelReviews.HoreRating = 0
                            resHotelReviews.HoreCreatedOn = "01/01/0001 00:00:00"
                            resHotelReviews.HoreUserId = 0
                            resHotelReviews.HoreHotelId = 0

                        End If

                        reader.Close()
                        cnn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using

            Return resHotelReviews
        End Function

        Public Function CreateHotelReviews(hotelReview As HotelReviews) As HotelReviews Implements IHotelReviewsRepository.CreateHotelReviews
            Dim newHotelReviews As New HotelReviews()

            Dim sql As String = "INSERT INTO Hotel.Hotel_Reviews " &
                                "(hore_user_review, hore_rating, hore_created_on, hore_user_id, hore_hotel_id) " &
                                "values (@horeUserReview, @horeRating, @horeCreatedOn, @horeUserId, @horeHotelId);" &
                                "SELECT IDENT_CURRENT('Hotel.Hotel_Reviews');"

            Using cnn As New SqlConnection With {.ConnectionString = _context.GetConnectionString()}
                Using cmd As New SqlCommand With {.Connection = cnn, .CommandText = sql}
                    cmd.Parameters.AddWithValue("@horeUserReview", hotelReview.HoreUserReview)
                    cmd.Parameters.AddWithValue("@horeRating", hotelReview.HoreRating)
                    cmd.Parameters.AddWithValue("@horeCreatedOn", hotelReview.HoreCreatedOn)
                    cmd.Parameters.AddWithValue("@horeUserId", hotelReview.HoreUserId)
                    cmd.Parameters.AddWithValue("@horeHotelId", hotelReview.HoreHotelId)

                    Try
                        cnn.Open()

                        Dim hotelReviewId = cmd.ExecuteScalar
                        newHotelReviews = FindHotelReviewsById(hotelReviewId)

                        cnn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using

            Return newHotelReviews
        End Function

        Public Function UpdateHotelReviewsById(id As Integer, userReview As String, rating As Short, userId As Integer, hotelId As Integer, createdOn As Date, Optional showCommand As Boolean = False) As Boolean Implements IHotelReviewsRepository.UpdateHotelReviewsById

            Dim sql As String = "UPDATE Hotel.Hotel_Reviews " &
                                "SET " &
                                "hore_user_review = @horeUserReview, " &
                                "hore_rating = @horeRating, " &
                                "hore_created_on = @horeCreatedOn, " &
                                "hore_user_id = @horeUserId," &
                                "hore_hotel_id = @horeHotelId " &
                                "WHERE hore_id = @id;"


            Using cnn As New SqlConnection With {
                .ConnectionString = _context.GetConnectionString
            }
                Using cmd As New SqlCommand With {
                    .Connection = cnn,
                    .CommandText = sql
                }
                    cmd.Parameters.AddWithValue("@id", id)
                    cmd.Parameters.AddWithValue("@horeUserReview", userReview)
                    cmd.Parameters.AddWithValue("@horeRating", rating)
                    cmd.Parameters.AddWithValue("@horeCreatedOn", createdOn)
                    cmd.Parameters.AddWithValue("@horeUserId", userId)
                    cmd.Parameters.AddWithValue("@horeHotelId", hotelId)


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

        Public Function UpdateHotelReviewsBySp(id As Integer, userReview As String, rating As Short, userId As Integer, hotelId As Integer, createdOn As Date, Optional showCommand As Boolean = False) As Boolean Implements IHotelReviewsRepository.UpdateHotelReviewsBySp

            Dim sql As String = "sp_update_hotel_reviews"


            Using cnn As New SqlConnection With {
                .ConnectionString = _context.GetConnectionString
            }
                Using cmd As New SqlCommand With {
                    .Connection = cnn,
                    .CommandText = sql,
                    .CommandType = Data.CommandType.StoredProcedure
                }
                    cmd.Parameters.AddWithValue("@id", id)
                    cmd.Parameters.AddWithValue("@horeUserReview", userReview)
                    cmd.Parameters.AddWithValue("@horeRating", rating)
                    cmd.Parameters.AddWithValue("@horeCreatedOn", createdOn)
                    cmd.Parameters.AddWithValue("@horeUserId", userId)
                    cmd.Parameters.AddWithValue("@horeHotelId", hotelId)


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

        Public Function DeleteHotelReviews(id As Integer) As Integer Implements IHotelReviewsRepository.DeleteHotelReviews
            Dim rowEffect As Int32 = 0

            'declare statement
            Dim sql As String = "DELETE FROM Hotel.Hotel_Reviews
            WHERE hore_id = 6;"

            Using cnn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = cnn, .CommandText = sql}
                    cmd.Parameters.AddWithValue("@id", id)

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

        Public Async Function FindAllHotelReviewsAsync() As Task(Of List(Of HotelReviews)) Implements IHotelReviewsRepository.FindAllHotelReviewsAsync
            Dim listHotelReviews As New List(Of HotelReviews)

            Dim sql As String = "SELECT hore_id, hore_user_review, hore_rating, hore_created_on, hore_user_id, hore_hotel_id " &
                                "FROM Hotel.Hotel_Reviews;"

            Using cnn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = cnn, .CommandText = sql}
                    Try
                        cnn.Open()

                        Dim reader = Await cmd.ExecuteReaderAsync()

                        While reader.Read()
                            listHotelReviews.Add(New HotelReviews() With {
                                .HoreId = reader.GetInt32(0),
                                .HoreUserReview = reader.GetString(1),
                                .HoreRating = reader.GetByte(2),
                                .HoreCreatedOn = If(reader.IsDBNull(3), "01/01/0001 00:00:00", reader.GetDateTime(3)),
                                .HoreUserId = reader.GetInt32(4),
                                .HoreHotelId = reader.GetInt32(5)
                            })

                        End While

                        reader.Close()
                        cnn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using

            Return listHotelReviews
        End Function
    End Class
End Namespace
