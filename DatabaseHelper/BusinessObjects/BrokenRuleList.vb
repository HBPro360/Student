Imports System.ComponentModel
Public Class BrokenRuleList
#Region " Private Members "
    Private _List As BindingList(Of BrokenRule)
#End Region

#Region " Public Properties "
    Public ReadOnly Property List As BindingList(Of BrokenRule)
        Get
            Return _List
        End Get
    End Property
#End Region

#Region " Public Methods "

#End Region

#Region " Contructors "
    Public Sub New()
        _List = New BindingList(Of BrokenRule)
    End Sub
#End Region
End Class
