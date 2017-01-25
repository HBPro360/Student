Public Class BrokenRule
#Region " Private Members "
    Private _Rule As String
#End Region

#Region " Public Properties "
    Public Property Rule As String
        Get
            Return _Rule
        End Get
        Set(value As String)
            _Rule = value
        End Set
    End Property
#End Region

#Region " Public Methods "

#End Region

#Region " Contructors "
    Public Sub New(rule As String)
        _Rule = rule
    End Sub
#End Region
End Class
