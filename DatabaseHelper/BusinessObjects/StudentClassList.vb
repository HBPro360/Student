Imports System.ComponentModel
Imports BusinessObjects
Imports DatabaseHelper

Public Class StudentClassList
    Inherits [Event]


#Region " Private Members "
    Private WithEvents _List As BindingList(Of StudentClass)
    Private _BrokenRules As BrokenRuleList
#End Region

#Region " Public Properties "
    Public ReadOnly Property List As BindingList(Of StudentClass)
        Get
            Return _List
        End Get
    End Property
    Public ReadOnly Property BrokenRules As BrokenRuleList
        Get
            For Each br As BrokenRule In _BrokenRules.List
                _BrokenRules.List.Add(br)
            Next
            Return _BrokenRules
        End Get
    End Property
#End Region

#Region " Private Methods "

#End Region

#Region " Public Methods "
    Public Function GetAll() As StudentClassList
        Dim database As New Database("Student")
        Dim dt As New DataTable
        database.Command.CommandType = CommandType.StoredProcedure
        database.Command.CommandText = "tblStudentGetAll"
        dt = database.ExecuteQuery()
        For Each dr As DataRow In dt.Rows
            Dim studentClass As New StudentClass
            studentClass.Initialize(dr)
            studentClass.InitializeBusinessData(dr)
            studentClass.IsNew = False
            _List.Add(studentClass)
        Next
        Return Me
    End Function

    Public Function GetByStudentID(studentId As Guid) As StudentClassList
        Dim database As New Database("Student")
        Dim dt As New DataTable
        database.Command.CommandType = CommandType.StoredProcedure
        database.Command.CommandText = "tblStudentClassGetByStudentID"
        database.Command.Parameters.Add("@studentId", SqlDbType.UniqueIdentifier).Value = studentId
        dt = database.ExecuteQuery()
        For Each dr As DataRow In dt.Rows
            Dim studentClass As New StudentClass
            studentClass.Initialize(dr)
            studentClass.InitializeBusinessData(dr)
            studentClass.IsNew = False
            AddHandler studentClass.Savable, AddressOf studentClass_Savable
            _List.Add(studentClass)
        Next
        Return Me
    End Function

    Public Function Save(database As Database, parentID As Guid) As Boolean
        Dim result As Boolean = True
        For Each studentClass As StudentClass In _List
            If studentClass.IsSavable() = True Then
                studentClass.Save(database, parentID)
                If studentClass.IsDirty = True Then
                    result = False
                    Exit For
                End If
            End If
        Next
        Return result
    End Function

    Public Function isSavable() As Boolean
        Dim result As Boolean = False
        For Each studentClass As StudentClass In _List
            If studentClass.BrokenRules.List.Count > 0 Then
                result = True
                Exit For
            End If
        Next
        Return result

    End Function
#End Region

#Region " Private Event Handlers "
    Private Sub _List_AddingNew(sender As Object, e As AddingNewEventArgs) Handles _List.AddingNew
        e.NewObject = New StudentClass
        Dim studentClass As StudentClass = e.NewObject
        AddHandler studentClass.Savable, AddressOf studentClass_Savable

    End Sub
#End Region

#Region " Contructors "
    Public Sub New()
        _List = New BindingList(Of StudentClass)
        _BrokenRules = New BrokenRuleList()
    End Sub

    Private Sub studentClass_Savable(e As SavableEventArgs)
        RaiseOurEvent(e)
    End Sub

#End Region
End Class
