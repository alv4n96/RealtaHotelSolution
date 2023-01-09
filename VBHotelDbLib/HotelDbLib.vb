Imports VBHotelDbLib.Base
Imports VBHotelDbLib.Context
Imports VBHotelDbLib.Model

Namespace HotelVbApi
    Public Class HotelDbLib
        Implements IHotelDbLib

        Private ReadOnly _repositoryContext As IRepositoryContext

        Private Property _repoManager As IRepositoryManager

        Public Sub New(ByVal connString As String)
            'Membuat Interface repository dan Implentasi nya
            If _repositoryContext Is Nothing Then
                _repositoryContext = New RepositoryContext(connString)
            End If
        End Sub

        Public ReadOnly Property RepositoryManager As IRepositoryManager Implements IHotelDbLib.RepositoryManager
            Get
                If _repoManager Is Nothing Then
                    _repoManager = New RepositoryManager(_repositoryContext)
                End If

                Return _repoManager
            End Get
        End Property

        Public Sub SayHello() Implements IHotelDbLib.SayHello
            Console.WriteLine("Ini dari methods SayHello()")
        End Sub

    End Class
End Namespace
