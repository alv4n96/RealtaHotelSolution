Imports VBHotelDbLib.Base
Imports VBHotelDbLib.Context

Namespace HotelVbApi
    Public Class HotelVbApi
        Implements IHotelVbApi

        Private ReadOnly _repositoryContext As IRepositoryContext

        Private Property _repoManager As IRepositoryManager

        Public Sub New(ByVal connString As String)
            'Membuat Interface repository dan Implentasi nya
            If _repositoryContext Is Nothing Then
                _repositoryContext = New RepositoryContext(connString)
            End If
        End Sub

        Public ReadOnly Property RepositoryManager As IRepositoryManager Implements IHotelVbApi.RepositoryManager
            Get
                If _repoManager Is Nothing Then
                    _repoManager = New RepositoryManager(_repositoryContext)
                End If

                Return _repoManager
            End Get
        End Property

        Public Sub SayHello() Implements IHotelVbApi.SayHello
            Console.WriteLine("Ini dari methods SayHello()")
        End Sub
    End Class
End Namespace
