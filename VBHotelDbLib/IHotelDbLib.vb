Imports VBHotelDbLib.Base

Namespace HotelVbApi
    Public Interface IHotelDbLib

        ReadOnly Property RepositoryManager As IRepositoryManager
        Sub SayHello()

    End Interface
End Namespace
