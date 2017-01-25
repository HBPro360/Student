Imports System.ComponentModel
Imports DatabaseHelper

Public Class StudentAddressList
#Region " Private Members "
    Private WithEvents _List As BindingList(Of StudentAddress)

#End Region

#Region " Public Properties "
    Public ReadOnly Property List As BindingList(Of StudentAddress)
        Get
            Return _List
        End Get
    End Property
#End Region

#Region " Private Methods "

#End Region

#Region " Public Methods "
    Public Function GetAll() As StudentAddressList
        Dim database As New Database("Student")
        Dim dt As New DataTable
        database.Command.CommandType = CommandType.StoredProcedure
        database.Command.CommandText = "tblStudentGetAll"
        dt = database.ExecuteQuery()
        For Each dr As DataRow In dt.Rows
            Dim studentAddress As New StudentAddress
            studentAddress.Initialize(dr)
            studentAddress.InitializeBusinessData(dr)
            studentAddress.IsNew = False
            _List.Add(StudentAddress)
        Next
        Return Me
    End Function

    Public Function GetByStudentID(studentId As Guid) As StudentAddressList
        Dim database As New Database("Student")
        Dim dt As New DataTable
        database.Command.CommandType = CommandType.StoredProcedure
        database.Command.CommandText = "tblStudentAddressGetByStudentID"
        database.Command.Parameters.Add("@studentId", SqlDbType.UniqueIdentifier).Value = studentId
        dt = database.ExecuteQuery()
        For Each dr As DataRow In dt.Rows
            Dim studentAddress As New StudentAddress
            studentAddress.Initialize(dr)
            studentAddress.InitializeBusinessData(dr)
            studentAddress.IsNew = False
            _List.Add(studentAddress)
        Next
        Return Me
    End Function

    Public Function Save(database As Database, parentID As Guid) As Boolean
        Dim result As Boolean = True
        For Each studentAddress As StudentAddress In _List
            If studentAddress.IsSavable() = True Then
                studentAddress.Save(database, parentID)
                If studentAddress.IsDirty = True Then
                    result = False
                    Exit For
                End If
            End If
        Next
        Return result
    End Function

    Public Function isSavable() As Boolean
        Dim result As Boolean = False
        For Each studentAddress As StudentAddress In _List
            If studentAddress.IsSavable = True Then
                result = True
                Exit For
            End If
        Next
        Return result

    End Function
#End Region

#Region " Private Event Handlers "
    Private Sub _List_AddingNew(sender As Object, e As AddingNewEventArgs) Handles _List.AddingNew
        e.NewObject = New StudentAddress

    End Sub
#End Region

#Region " Contructors "
    Public Sub New()
        _List = New BindingList(Of StudentAddress)
    End Sub

#End Region
End Class
