Imports System.ComponentModel
Imports BusinessObjects
Imports DatabaseHelper

Public Class StudentList
    Inherits [Event]
#Region " Private Members "
    Private WithEvents _List As BindingList(Of Student)
    Private WithEvents student As Student
#End Region

#Region " Public Properties "
    Public ReadOnly Property List As BindingList(Of Student)
        Get
            Return _List
        End Get
    End Property
#End Region

#Region " Private Methods "

#End Region

#Region " Public Methods "
    Public Function GetAll() As StudentList
        Dim database As New Database("Student")
        Dim dt As New DataTable
        database.Command.CommandType = CommandType.StoredProcedure
        database.Command.CommandText = "tblStudentGetAll"
        dt = database.ExecuteQuery()
        For Each dr As DataRow In dt.Rows
            Dim student As New Student
            student.Initialize(dr)
            student.InitializeBusinessData(dr)
            student.IsNew = False
            AddHandler student.Savable, AddressOf student_Savable
            AddHandler student.Phones.Savable, AddressOf student_Savable
            _List.Add(student)
        Next
        Return Me
    End Function

    Public Function Save() As StudentList
        For Each student As Student In _List
            If student.IsSavable() = True Then
                student.Save()
            End If
        Next
        Return Me
    End Function
#End Region

#Region " Private Event Handlers "
    Private Sub _List_AddingNew(sender As Object, e As AddingNewEventArgs) Handles _List.AddingNew
        e.NewObject = New Student
        Dim student As Student = e.NewObject
        AddHandler student.Savable, AddressOf student_Savable

    End Sub
#End Region

#Region " Contructors "
    Public Sub New()
        _List = New BindingList(Of Student)
    End Sub

    Private Sub student_Savable(e As SavableEventArgs)
        RaiseOurEvent(e)
    End Sub

#End Region
End Class
