Imports DatabaseHelper
Imports System.Data.SqlClient


Public Class HeaderData
    Inherits [Event]
#Region " Private Members "
    Private _ID As Guid
    Private _Version As Integer
    Private _LastUpdated As DateTime
    Private _Deleted As Boolean
    Private _IsNew As Boolean
    Private _IsDirty As Boolean
#End Region

#Region " Public Properties "
    Public Property ID As Guid
        Get
            Return _ID
        End Get
        Set(value As Guid)
            _ID = value
        End Set
    End Property

    Public Property Version As Integer
        Get
            Return _Version
        End Get
        Set(value As Integer)
            _Version = value
        End Set
    End Property

    Public Property LastUpdated As DateTime
        Get
            Return _LastUpdated
        End Get
        Set(value As DateTime)
            _LastUpdated = value
        End Set
    End Property

    Public Property Deleted As Boolean
        Get
            Return _Deleted
        End Get
        Set(value As Boolean)
            _Deleted = value
            _IsDirty = True
        End Set
    End Property

    Public Property IsNew As Boolean
        Get
            Return _IsNew
        End Get
        Set(value As Boolean)
            _IsNew = value
        End Set
    End Property

    Public Property IsDirty As Boolean
        Get
            Return _IsDirty
        End Get
        Set(value As Boolean)
            _IsDirty = value
        End Set
    End Property
#End Region

#Region " Public Methods "
    Public Sub Initialize(database As Database, ID As Guid)
        Dim parm As New SqlParameter
        parm.ParameterName = "@ID"
        parm.Direction = ParameterDirection.InputOutput
        parm.SqlDbType = SqlDbType.UniqueIdentifier
        parm.Value = ID
        database.Command.Parameters.Add(parm)

        parm = New SqlParameter
        parm.ParameterName = "@Version"
        parm.Direction = ParameterDirection.Output
        parm.SqlDbType = SqlDbType.Int
        parm.Value = 0
        database.Command.Parameters.Add(parm)

        parm = New SqlParameter
        parm.ParameterName = "@LastUpdated"
        parm.Direction = ParameterDirection.Output
        parm.SqlDbType = SqlDbType.DateTime
        parm.Value = DateTime.MaxValue
        database.Command.Parameters.Add(parm)

        parm = New SqlParameter
        parm.ParameterName = "@Deleted"
        parm.Direction = ParameterDirection.Output
        parm.SqlDbType = SqlDbType.Bit
        parm.Value = 0
        database.Command.Parameters.Add(parm)
    End Sub
    Public Sub Initialize(cmd As SqlCommand)
        _ID = New Guid(cmd.Parameters("@ID").Value.ToString())
        _Version = Convert.ToInt32(cmd.Parameters("@Version").Value)
        _LastUpdated = Convert.ToDateTime(cmd.Parameters("@LastUpdated").Value)
        _Deleted = Convert.ToBoolean(cmd.Parameters("@Deleted").Value)
    End Sub
    Public Sub Initialize(dr As DataRow)
        _ID = dr("ID")             'no "@" because coming from row, Not data parameter
        _Version = dr("Version")
        _LastUpdated = dr("LastUpdated")
        _Deleted = dr("Deleted")
    End Sub
#End Region

#Region " Contructors "
    Public Sub New()
        _IsDirty = False
        _IsNew = True
    End Sub
#End Region
End Class
