Imports DataTypeHelper.SearchCriteria
Public Class Criteria

    Private mTableName As String = String.Empty
    Private mFields As New List(Of String)
    Private mValues As New List(Of String)
    Private mTypes As New List(Of Type)





#Region " Public Properties "
    Public Property TableName As String
        Get
            Return mTableName
        End Get
        Set(value As String)
            mTableName = value
        End Set
    End Property

    Public ReadOnly Property Fields As List(Of String)
        Get
            Return mFields
        End Get
    End Property

    Public ReadOnly Property Values As List(Of String)
        Get
            Return mValues
        End Get
    End Property

    Public ReadOnly Property Types As List(Of Type)
        Get
            Return mTypes
        End Get
    End Property


#End Region

#Region " Private Methods "

#End Region

#Region " Public Methods "

#End Region

#Region " Contructors "

#End Region

End Class
