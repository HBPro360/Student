Imports System.Data
Imports System.Data.SqlClient

Public Class Database
#Region " Private Members "
    Private _ConnectionName As String
    Private _cn As SqlConnection
    Private _cmd As SqlCommand
    Private _da As SqlDataAdapter
    Private _dt As DataTable

#End Region
#Region " Public Properties "
    Public ReadOnly Property Command() As SqlCommand
        Get
            Return _cmd
        End Get
    End Property
#End Region
#Region " Public Methods "

    Public Sub BeginTransaction()
        Try
            _cn.ConnectionString = Configuration.GetConnectionStringWeb(_ConnectionName)
        Catch ex As Exception
            _cn.ConnectionString = Configuration.GetConnectionString(_ConnectionName)
        End Try

        _cn.Open()
        _cmd.Connection = _cn
        _cmd.Transaction = _cn.BeginTransaction()
    End Sub

    Public Sub Endtransaction()
        _cmd.Transaction.Commit()
        _cn.Close()
    End Sub

    Public Sub RollBack()
        _cmd.Transaction.Rollback()
        _cn.Close()
    End Sub

    Public Function ExecuteNonQueryWithTransaction() As SqlCommand
        Try
            _cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw
        End Try
        Return _cmd
    End Function

    Public Function ExecuteNonQueryJ() As SqlCommand
        Try
            Try
                _cn.ConnectionString = Configuration.GetConnectionStringWeb(_ConnectionName)
            Catch ex As Exception
                _cn.ConnectionString = Configuration.GetConnectionString(_ConnectionName)
            End Try
            _cn.Open()
            _cmd.Connection = _cn
            _cmd.ExecuteNonQuery()
            _cn.Close()

        Catch ex As Exception
            _cn.Close()
        End Try
        Return _cmd
    End Function

    Public Function ExecuteQuery() As DataTable
        Try
            Try
                _cn.ConnectionString = Configuration.GetConnectionStringWeb(_ConnectionName)
            Catch ex As Exception
                _cn.ConnectionString = Configuration.GetConnectionString(_ConnectionName)
            End Try
            _cn.Open()
            _cmd.Connection = _cn
            _da.SelectCommand = _cmd
            _da.Fill(_dt)
            _cn.Close()

        Catch ex As Exception
            _cn.Close()
        End Try
        Return _dt
    End Function
#End Region
#Region " Private Methods "

#End Region
#Region " Constructor "
    Public Sub New(name As String)

        _ConnectionName = name
        _cn = New SqlConnection
        _cmd = New SqlCommand
        _da = New SqlDataAdapter
        _dt = New DataTable

    End Sub
#End Region

End Class
