Public Class SavableEventArgs
#Region "Private Members"
    Private _Savable As Boolean
#End Region

#Region "Public Properties"
    Public Property Savable As Boolean
        Get
            Return _Savable
        End Get
        Set(value As Boolean)
            _Savable = value
        End Set
    End Property
#End Region

#Region "Construction"
    Public Sub New(Savable As Boolean)
        _Savable = Savable
    End Sub
#End Region

End Class
