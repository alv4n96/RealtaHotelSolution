Imports VBHotelDbLib.Base

Namespace HotelVbApi
    Public Interface IHotelVbApi

        ReadOnly Property RepositoryManager As IRepositoryManager
        Sub SayHello()

    End Interface
End Namespace
