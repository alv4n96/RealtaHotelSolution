Imports System.ComponentModel
Imports System.Data.SqlClient
Imports VBHotelDbLib.Context
Imports VBHotelDbLib.Model

Namespace Repository
    Public Class FacilityPhotosRepository
        Implements IFacilityPhotosRepository

        Private ReadOnly _context As IRepositoryContext

        Public Sub New()
        End Sub

        Public Sub New(context As IRepositoryContext)
            _context = context
        End Sub

        Public Function FindFacilityPhotosById(id As Integer) As FacilityPhotos Implements IFacilityPhotosRepository.FindFacilityPhotosById
            Dim resFaPho As New FacilityPhotos()

            Dim sql As String = "SELECT * FROM Hotel.Facility_Photos " &
                                "WHERE fapho_id = @faphoId;"

            Using cnn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = cnn, .CommandText = sql}
                    cmd.Parameters.AddWithValue("@faphoId", id)

                    Try
                        cnn.Open()

                        Dim reader = cmd.ExecuteReader()

                        If reader.HasRows Then
                            reader.Read()

                            resFaPho.FaphoId = id
                            resFaPho.FaphoThumbnailFilename = If(reader.IsDBNull(1), "", reader.GetString(1))
                            resFaPho.FaphoPhotoFilename = If(reader.IsDBNull(2), "", reader.GetString(2))
                            resFaPho.FaphoPrimary = If(reader.IsDBNull(3), "", reader.GetBoolean(3))
                            resFaPho.FaphoUrl = If(reader.IsDBNull(4), "", reader.GetString(4))
                            resFaPho.FaphoModifiedDate = reader.GetDateTime(5)
                            resFaPho.FaphoFaciId = reader.GetInt32(6)

                        End If
                        reader.Close()
                        cnn.Close()
                    Catch ex As Exception
                        Console.WriteLine(resFaPho)
                    End Try
                End Using
            End Using
            Return resFaPho
        End Function

        Public Function FindAllFacilityPhotos() As List(Of FacilityPhotos) Implements IFacilityPhotosRepository.FindAllFacilityPhotos
            Dim resFapho As New List(Of FacilityPhotos)

            Dim sql As String = "SELECT * FROM Hotel.Facility_Photos;"

            Using cnn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = cnn, .CommandText = sql}
                    Try
                        cnn.Open()

                        Dim reader = cmd.ExecuteReader()

                        While reader.Read()
                            resFapho.Add(New FacilityPhotos With {
                                .FaphoId = reader.GetInt32(0),
                                .FaphoThumbnailFilename = If(reader.IsDBNull(1), "", reader.GetString(1)),
                                .FaphoPhotoFilename = If(reader.IsDBNull(2), "", reader.GetString(2)),
                                .FaphoPrimary = If(reader.IsDBNull(3), False, reader.GetBoolean(3)),
                                .FaphoUrl = If(reader.IsDBNull(4), "", reader.GetString(4)),
                                .FaphoModifiedDate = reader.GetDateTime(5),
                                .FaphoFaciId = reader.GetInt32(6)
                            })
                        End While

                        reader.Close()
                        cnn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using

            Return resFapho
        End Function

        Public Function CreateFacilityPhotos(facilityPhotos As FacilityPhotos) As FacilityPhotos Implements IFacilityPhotosRepository.CreateFacilityPhotos
            Dim newFaPho = New FacilityPhotos

            Dim sql As String = "INSERT INTO Hotel.Facility_Photos " &
                                "(fapho_faci_id, fapho_thumbnail_filename, " &
                                "fapho_photo_filename, fapho_primary, fapho_url, " &
                                "fapho_modified_date) " &
                                "VALUES " &
                                "(@faphoFaciId, @faphoThumbnailFilename, " &
                                "@faphoPhotoFilename, @faphoPrimary, @faphoUrl, " &
                                "@faphoModifiedDate);" &
                                "SELECT IDENT_CURRENT('Hotel.Facility_Photos');"

            Using cnn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = cnn, .CommandText = sql}
                    Dim FaphoThumbnailFilenameChecker = If(String.IsNullOrEmpty(facilityPhotos.FaphoThumbnailFilename), DBNull.Value, facilityPhotos.FaphoThumbnailFilename)
                    Dim FaphoPhotoFilenameChecker = If(String.IsNullOrEmpty(facilityPhotos.FaphoPhotoFilename), DBNull.Value, facilityPhotos.FaphoPhotoFilename)
                    Dim FaphoPrimaryChecker = If(facilityPhotos.FaphoPrimary = False Or facilityPhotos.FaphoPrimary = 0, 0, 1)
                    Dim FaphoUrlChecker = If(String.IsNullOrEmpty(facilityPhotos.FaphoUrl), DBNull.Value, facilityPhotos.FaphoUrl)

                    cmd.Parameters.AddWithValue("@faphoFaciId", facilityPhotos.FaphoFaciId)
                    cmd.Parameters.AddWithValue("@faphoThumbnailFilename", FaphoThumbnailFilenameChecker)
                    cmd.Parameters.AddWithValue("@faphoPhotoFilename", FaphoPhotoFilenameChecker)
                    cmd.Parameters.AddWithValue("@faphoPrimary", FaphoPrimaryChecker)
                    cmd.Parameters.AddWithValue("@faphoUrl", FaphoUrlChecker)
                    cmd.Parameters.AddWithValue("@faphoModifiedDate", facilityPhotos.FaphoModifiedDate)


                    Try
                        cnn.Open()

                        Dim faPho = cmd.ExecuteScalar()
                        newFaPho = FindFacilityPhotosById(faPho)

                        cnn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using

            Return newFaPho
        End Function

        Public Function UpdateFacilityPhotosById(faphoId As Integer, faphoThumbnailFilename As String, faphoPhotoFilename As String, faphoPrimary As Boolean, faphoUrl As String, faphoModifiedDate As Date, faphoFaciId As Integer, Optional showCommand As Boolean = False) As Boolean Implements IFacilityPhotosRepository.UpdateFacilityPhotosById
            Dim sql As String = "UPDATE Hotel.Facility_Photos " &
                                "SET " &
                                    "fapho_faci_id = @faphoFaciId," &
                                    "fapho_thumbnail_filename = @faphoThumbnailFilename," &
                                    "fapho_photo_filename = @faphoPhotoFilename," &
                                    "fapho_primary = @faphoPrimary," &
                                    "fapho_url = @faphoUrl," &
                                    "fapho_modified_date = @faphoModifiedDate " &
                                "WHERE fapho_id = @faPhoId;"

            Using cnn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = cnn, .CommandText = sql}
                    cmd.Parameters.AddWithValue("@faPhoId", faphoId)
                    cmd.Parameters.AddWithValue("@faphoFaciId", faphoFaciId)
                    If String.IsNullOrEmpty(faphoThumbnailFilename) Then
                        cmd.Parameters.AddWithValue("@faphoThumbnailFilename", DBNull.Value)
                    Else
                        cmd.Parameters.AddWithValue("@faphoThumbnailFilename", faphoThumbnailFilename)
                    End If
                    If String.IsNullOrEmpty(faphoPhotoFilename) Then
                        cmd.Parameters.AddWithValue("@faphoPhotoFilename", DBNull.Value)
                    Else
                        cmd.Parameters.AddWithValue("@faphoPhotoFilename", faphoPhotoFilename)
                    End If
                    If faphoPrimary = False Then
                        cmd.Parameters.AddWithValue("@faphoPrimary", 0)
                    Else
                        cmd.Parameters.AddWithValue("@faphoPrimary", faphoPrimary)
                    End If
                    If String.IsNullOrEmpty(faphoUrl) Then
                        cmd.Parameters.AddWithValue("@faphoUrl", DBNull.Value)
                    Else
                        cmd.Parameters.AddWithValue("@faphoUrl", faphoUrl)
                    End If
                    cmd.Parameters.AddWithValue("@faphoModifiedDate", faphoModifiedDate)


                    Try
                        cnn.Open()

                        cmd.ExecuteNonQuery()

                        cnn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try

                    If showCommand Then
                        Console.WriteLine(cmd.CommandText)
                    End If
                End Using
            End Using

            Return True
        End Function

        Public Function UpdateFacilityPhotosBySp(faphoId As Integer, faphoThumbnailFilename As String, faphoPhotoFilename As String, faphoPrimary As Boolean, faphoUrl As String, faphoModifiedDate As Date, faphoFaciId As Integer, Optional showCommand As Boolean = False) As Boolean Implements IFacilityPhotosRepository.UpdateFacilityPhotosBySp
            Dim sql As String = "sp_update_facility_photos"

            Using cnn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = cnn, .CommandText = sql}
                    cmd.Parameters.AddWithValue("@faPhoId", faphoId)
                    cmd.Parameters.AddWithValue("@faphoFaciId", faphoFaciId)
                    If String.IsNullOrEmpty(faphoThumbnailFilename) Then
                        cmd.Parameters.AddWithValue("@faphoThumbnailFilename", DBNull.Value)
                    Else
                        cmd.Parameters.AddWithValue("@faphoThumbnailFilename", faphoThumbnailFilename)
                    End If
                    If String.IsNullOrEmpty(faphoPhotoFilename) Then
                        cmd.Parameters.AddWithValue("@faphoPhotoFilename", DBNull.Value)
                    Else
                        cmd.Parameters.AddWithValue("@faphoPhotoFilename", faphoPhotoFilename)
                    End If
                    If faphoPrimary = False Then
                        cmd.Parameters.AddWithValue("@faphoPrimary", 0)
                    Else
                        cmd.Parameters.AddWithValue("@faphoPrimary", faphoPrimary)
                    End If
                    If String.IsNullOrEmpty(faphoUrl) Then
                        cmd.Parameters.AddWithValue("@faphoUrl", DBNull.Value)
                    Else
                        cmd.Parameters.AddWithValue("@faphoUrl", faphoUrl)
                    End If
                    cmd.Parameters.AddWithValue("@faphoModifiedDate", faphoModifiedDate)


                    Try
                        cnn.Open()

                        cmd.ExecuteNonQuery()

                        cnn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try

                    If showCommand Then
                        Console.WriteLine(cmd.CommandText)
                    End If
                End Using
            End Using

            Return True
        End Function

        Public Function DeleteFacilityPhotos(faPhoId As Integer) As Integer Implements IFacilityPhotosRepository.DeleteFacilityPhotos
            Dim rowEffect As Int16 = 0

            Dim sql As String = "DELETE FROM Hotel.Facility_Photos " &
                                "WHERE fapho_id = @faphoId;"

            Using cnn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = cnn, .CommandText = sql}
                    cmd.Parameters.AddWithValue("@faphoId", faPhoId)

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

        Public Async Function FindAllFacilityPhotosAsync() As Task(Of List(Of FacilityPhotos)) Implements IFacilityPhotosRepository.FindAllFacilityPhotosAsync
            Dim resFapho As New List(Of FacilityPhotos)

            Dim sql As String = "SELECT * FROM Hotel.Facility_Photos;"

            Using cnn As New SqlConnection With {.ConnectionString = _context.GetConnectionString}
                Using cmd As New SqlCommand With {.Connection = cnn, .CommandText = sql}
                    Try
                        cnn.Open()

                        Dim reader = Await cmd.ExecuteReaderAsync()

                        While reader.Read()
                            resFapho.Add(New FacilityPhotos With {
                                .FaphoId = reader.GetInt32(0),
                                .FaphoThumbnailFilename = If(reader.IsDBNull(1), "", reader.GetString(1)),
                                .FaphoPhotoFilename = If(reader.IsDBNull(2), "", reader.GetString(2)),
                                .FaphoPrimary = If(reader.IsDBNull(3), False, reader.GetBoolean(3)),
                                .FaphoUrl = If(reader.IsDBNull(4), "", reader.GetString(4)),
                                .FaphoModifiedDate = reader.GetDateTime(5),
                                .FaphoFaciId = reader.GetInt32(6)
                            })
                        End While

                        reader.Close()
                        cnn.Close()
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                End Using
            End Using

            Return resFapho
        End Function
    End Class
End Namespace
