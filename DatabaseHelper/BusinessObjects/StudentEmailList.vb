Imports System.ComponentModel
Imports DatabaseHelper

Public Class StudentEmailList
#Region " Private Members "
    Private WithEvents _List As BindingList(Of StudentEmail)

#End Region

#Region " Public Properties "
    Public ReadOnly Property List As BindingList(Of StudentEmail)
        Get
            Return _List
        End Get
    End Property
#End Region

#Region " Private Methods "

#End Region

#Region " Public Methods "
    Public Function GetAll() As StudentEmailList
        Dim database As New Database("Student")
        Dim dt As New DataTable
        database.Command.CommandType = CommandType.StoredProcedure
        database.Command.CommandText = "tblStudentGetAll"
        dt = database.ExecuteQuery()
        For Each dr As DataRow In dt.Rows
            Dim studentEmail As New StudentEmail
            studentEmail.Initialize(dr)
            studentEmail.InitializeBusinessData(dr)
            studentEmail.IsNew = False
            _List.Add(studentEmail)
        Next
        Return Me
    End Function

    Public Function GetByStudentID(studentId As Guid) As StudentEmailList
        Dim database As New Database("Student")
        Dim dt As New DataTable
        database.Command.CommandType = CommandType.StoredProcedure
        database.Command.CommandText = "tblStudentEmailGetByStudentID"
        database.Command.Parameters.Add("@studentId", SqlDbType.UniqueIdentifier).Value = studentId
        dt = database.ExecuteQuery()
        For Each dr As DataRow In dt.Rows
            Dim studentEmail As New StudentEmail
            studentEmail.Initialize(dr)
            studentEmail.InitializeBusinessData(dr)
            studentEmail.IsNew = False
            _List.Add(studentEmail)
        Next
        Return Me
    End Function

    Public Function Save(database As Database, parentID As Guid) As Boolean
        Dim result As Boolean = True
        For Each studentEmail As StudentEmail In _List
            If studentEmail.IsSavable() = True Then
                studentEmail.Save(database, parentID)
                If studentEmail.IsDirty = True Then
                    result = False
                    Exit For
                End If
            End If
        Next
        Return result
    End Function

    Public Function isSavable() As Boolean
        Dim result As Boolean = False
        For Each studentEmail As StudentEmail In _List
            If studentEmail.IsSavable = True Then
                result = True
                Exit For
            End If
        Next
        Return result

    End Function
#End Region

#Region " Private Event Handlers "
    Private Sub _List_AddingNew(sender As Object, e As AddingNewEventArgs) Handles _List.AddingNew
        e.NewObject = New StudentEmail

    End Sub
#End Region

#Region " Contructors "
    Public Sub New()
        _List = New BindingList(Of StudentEmail)
    End Sub

#End Region
End Class
