Imports System.ComponentModel
Imports DatabaseHelper

Public Class ProgramList
#Region " Private Members "
    Private WithEvents _List As BindingList(Of Program)

#End Region

#Region " Public Properties "
    Public ReadOnly Property List As BindingList(Of Program)
        Get
            Return _List
        End Get
    End Property
#End Region

#Region " Private Methods "

#End Region

#Region " Public Methods "
    Public Function GetAll() As ProgramList
        Dim database As New Database("Student")
        Dim dt As New DataTable
        database.Command.CommandType = CommandType.StoredProcedure
        database.Command.CommandText = "tblProgramGetAll"
        dt = database.ExecuteQuery()
        For Each dr As DataRow In dt.Rows
            Dim program As New Program
            program.Initialize(dr)
            program.InitializeBusinessData(dr)
            program.IsNew = False
            _List.Add(Program)
        Next
        Return Me
    End Function

    Public Function Save() As ProgramList
        For Each program As Program In _List
            If program.IsSavable() = True Then
                program.Save()
            End If
        Next
        Return Me
    End Function
#End Region

#Region " Private Event Handlers "
    Private Sub _List_AddingNew(sender As Object, e As AddingNewEventArgs) Handles _List.AddingNew
        e.NewObject = New Program

    End Sub
#End Region

#Region " Contructors "
    Public Sub New()
        _List = New BindingList(Of Program)
    End Sub

#End Region
End Class