Imports System.ComponentModel
Imports DatabaseHelper

Public Class PhoneTypeList
#Region " Private Members "
    Private WithEvents _List As BindingList(Of PhoneType)

#End Region

#Region " Public Properties "
    Public ReadOnly Property List As BindingList(Of PhoneType)
        Get
            Return _List
        End Get
    End Property
#End Region

#Region " Private Methods "

#End Region

#Region " Public Methods "
    Public Function GetAll() As PhoneTypeList
        Dim database As New Database("Student")
        Dim dt As New DataTable
        database.Command.CommandType = CommandType.StoredProcedure
        database.Command.CommandText = "tblPhoneTypeGetAll"
        dt = database.ExecuteQuery()
        For Each dr As DataRow In dt.Rows
            Dim phonetype As New PhoneType
            phonetype.Initialize(dr)
            phonetype.InitializeBusinessData(dr)
            phonetype.IsNew = False
            _List.Add(phonetype)
        Next
        Return Me
    End Function

    Public Function Save() As PhoneTypeList
        For Each phonetype As PhoneType In _List
            If phonetype.IsSavable() = True Then
                phonetype.Save()
            End If
        Next
        Return Me
    End Function
#End Region

#Region " Private Event Handlers "
    Private Sub _List_AddingNew(sender As Object, e As AddingNewEventArgs) Handles _List.AddingNew
        e.NewObject = New PhoneType

    End Sub
#End Region

#Region " Contructors "
    Public Sub New()
        _List = New BindingList(Of PhoneType)
    End Sub

#End Region
End Class