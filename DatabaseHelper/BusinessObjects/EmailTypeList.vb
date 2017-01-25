Imports System.ComponentModel
Imports DatabaseHelper

Public Class EmailTypeList
#Region " Private Members "
    Private WithEvents _List As BindingList(Of EmailType)

#End Region

#Region " Public Properties "
    Public ReadOnly Property List As BindingList(Of EmailType)
        Get
            Return _List
        End Get
    End Property
#End Region

#Region " Private Methods "

#End Region

#Region " Public Methods "
    Public Function GetAll() As EmailTypeList
        Dim database As New Database("Student")
        Dim dt As New DataTable
        database.Command.CommandType = CommandType.StoredProcedure
        database.Command.CommandText = "tblEmailTypeGetAll"
        dt = database.ExecuteQuery()
        For Each dr As DataRow In dt.Rows
            Dim emailtype As New EmailType
            emailtype.Initialize(dr)
            emailtype.InitializeBusinessData(dr)
            emailtype.IsNew = False
            _List.Add(emailtype)
        Next
        Return Me
    End Function

    Public Function Save() As EmailTypeList
        For Each emailtype As EmailType In _List
            If emailtype.IsSavable() = True Then
                emailtype.Save()
            End If
        Next
        Return Me
    End Function
#End Region

#Region " Private Event Handlers "
    Private Sub _List_AddingNew(sender As Object, e As AddingNewEventArgs) Handles _List.AddingNew
        e.NewObject = New EmailType

    End Sub
#End Region

#Region " Contructors "
    Public Sub New()
        _List = New BindingList(Of EmailType)
    End Sub

#End Region
End Class