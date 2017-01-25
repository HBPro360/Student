Imports System.ComponentModel
Imports DatabaseHelper

Public Class AddressTypeList
#Region " Private Members "
    Private WithEvents _List As BindingList(Of AddressType)

#End Region

#Region " Public Properties "
    Public ReadOnly Property List As BindingList(Of AddressType)
        Get
            Return _List
        End Get
    End Property
#End Region

#Region " Private Methods "

#End Region

#Region " Public Methods "
    Public Function GetAll() As AddressTypeList
        Dim database As New Database("Student")
        Dim dt As New DataTable
        database.Command.CommandType = CommandType.StoredProcedure
        database.Command.CommandText = "tblAddressTypeGetAll"
        dt = database.ExecuteQuery()
        For Each dr As DataRow In dt.Rows
            Dim addresstype As New AddressType
            addresstype.Initialize(dr)
            addresstype.InitializeBusinessData(dr)
            addresstype.IsNew = False
            _List.Add(addresstype)
        Next
        Return Me
    End Function

    Public Function Save() As AddressTypeList
        For Each addresstype As AddressType In _List
            If addresstype.IsSavable() = True Then
                addresstype.Save()
            End If
        Next
        Return Me
    End Function
#End Region

#Region " Private Event Handlers "
    Private Sub _List_AddingNew(sender As Object, e As AddingNewEventArgs) Handles _List.AddingNew
        e.NewObject = New AddressType

    End Sub
#End Region

#Region " Contructors "
    Public Sub New()
        _List = New BindingList(Of AddressType)
    End Sub

#End Region
End Class