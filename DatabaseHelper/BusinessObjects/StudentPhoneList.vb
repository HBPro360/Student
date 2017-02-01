Imports System.ComponentModel
Imports BusinessObjects
Imports DatabaseHelper

Public Class StudentPhoneList
    Inherits [Event]


#Region " Private Members "
    Private WithEvents _List As BindingList(Of StudentPhone)
    Private _BrokenRules As BrokenRuleList
#End Region

#Region " Public Properties "
    Public ReadOnly Property List As BindingList(Of StudentPhone)
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
    Public Function GetAll() As StudentPhoneList
        Dim database As New Database("Student")
        Dim dt As New DataTable
        database.Command.CommandType = CommandType.StoredProcedure
        database.Command.CommandText = "tblStudentGetAll"
        dt = database.ExecuteQuery()
        For Each dr As DataRow In dt.Rows
            Dim studentPhone As New StudentPhone
            studentPhone.Initialize(dr)
            studentPhone.InitializeBusinessData(dr)
            studentPhone.IsNew = False
            _List.Add(studentPhone)
        Next
        Return Me
    End Function

    Public Function GetByStudentID(studentId As Guid) As StudentPhoneList
        Dim database As New Database("Student")
        Dim dt As New DataTable
        database.Command.CommandType = CommandType.StoredProcedure
        database.Command.CommandText = "tblStudentPhoneGetByStudentID"
        database.Command.Parameters.Add("@studentId", SqlDbType.UniqueIdentifier).Value = studentId
        dt = database.ExecuteQuery()
        For Each dr As DataRow In dt.Rows
            Dim studentPhone As New StudentPhone
            studentPhone.Initialize(dr)
            studentPhone.InitializeBusinessData(dr)
            studentPhone.IsNew = False
            AddHandler studentPhone.Savable, AddressOf studentPhone_Savable
            _List.Add(studentPhone)
        Next
        Return Me
    End Function

    Public Function Save(database As Database, parentID As Guid) As Boolean
        Dim result As Boolean = True
        For Each studentPhone As StudentPhone In _List
            If studentPhone.IsSavable() = True Then
                studentPhone.Save(database, parentID)
                If studentPhone.IsDirty = True Then
                    result = False
                    Exit For
                End If
            End If
        Next
        Return result
    End Function

    Public Function isSavable() As Boolean
        Dim result As Boolean = False
        For Each studentPhone As StudentPhone In _List
            If studentPhone.BrokenRules.List.Count > 0 Then
                result = True
                Exit For
            End If
        Next
        Return result

    End Function
#End Region

#Region " Private Event Handlers "
    Private Sub _List_AddingNew(sender As Object, e As AddingNewEventArgs) Handles _List.AddingNew
        e.NewObject = New StudentPhone
        Dim studentPhone As StudentPhone = e.NewObject
        AddHandler studentPhone.Savable, AddressOf studentPhone_Savable

    End Sub
#End Region

#Region " Contructors "
    Public Sub New()
        _List = New BindingList(Of StudentPhone)
        _BrokenRules = New BrokenRuleList()
    End Sub

    Private Sub studentPhone_Savable(e As SavableEventArgs)
        RaiseOurEvent(e)
    End Sub

#End Region
End Class
