Imports DatabaseHelper

Public Class ZipCode
    Inherits HeaderData
#Region " Private Members "
    Private _City As String
    Private _State As String
    Private _ZipCode As String

#End Region

#Region " Public Properties "

    Public Property City As String
        Get
            Return _City
        End Get
        Set(value As String)
            If _City <> value Then
                _City = value
                MyBase.IsDirty = True
            End If
        End Set
    End Property

    Public Property State As String
        Get
            Return _State
        End Get
        Set(value As String)
            If _State <> value Then
                _State = value
                MyBase.IsDirty = True
            End If
        End Set
    End Property

    Public Property ZipCode As String
        Get
            Return _ZipCode
        End Get
        Set(value As String)
            If _ZipCode <> value Then
                _ZipCode = value
                MyBase.IsDirty = True
            End If
        End Set
    End Property

#End Region

#Region " Private Methods "
    Private Function Insert(database As Database) As Boolean
        Dim result As Boolean = True
        Try
            database.Command.Parameters.Clear()
            database.Command.CommandType = CommandType.StoredProcedure
            database.Command.CommandText = "tblZipCodeInsert"
            'Add Busines Parameters to the command object
            database.Command.Parameters.Add("@City", SqlDbType.VarChar).Value = _City
            database.Command.Parameters.Add("@State", SqlDbType.VarChar).Value = _State
            database.Command.Parameters.Add("@ZipCode", SqlDbType.VarChar).Value = _ZipCode
            'Add header data parameters to the commend object (or empty buckets)
            MyBase.Initialize(database, Guid.Empty)
            'Insert the student and fill up the header data parameters
            database.ExecuteNonQueryJ()
            'Once the header data parameter are full we can get them from the command
            MyBase.Initialize(database.Command)
            result = True
        Catch ex As Exception
            result = False
            Throw
        End Try
        Return result
    End Function

    Private Function Update(database As Database) As Boolean
        Dim result As Boolean = True
        Try
            database.Command.Parameters.Clear()
            database.Command.CommandType = CommandType.StoredProcedure
            database.Command.CommandText = "tblZipCodeUpdate"
            'Add Business Parameters to the command object
            database.Command.Parameters.Add("@City", SqlDbType.VarChar).Value = _City
            database.Command.Parameters.Add("@State", SqlDbType.VarChar).Value = _State
            database.Command.Parameters.Add("@ZipCode", SqlDbType.VarChar).Value = _ZipCode
            'Add header data parameters to the commend object (or empty buckets)
            MyBase.Initialize(database, MyBase.ID)
            'Insert the student and fill up the header data parameters
            database.ExecuteNonQueryJ()
            'Once the header data parameter are full we can get them from the command
            MyBase.Initialize(database.Command)
            result = True
        Catch ex As Exception
            result = False
            Throw
        End Try
        Return result
    End Function

    Private Function Delete(database As Database) As Boolean
        Dim result As Boolean = True
        Try
            database.Command.Parameters.Clear()
            database.Command.CommandType = CommandType.StoredProcedure
            database.Command.CommandText = "tblZipCodeDelete"
            'Add header data parameters to the commend object (or empty buckets)
            MyBase.Initialize(database, MyBase.ID)
            'Soft delete the student and fill up the header data parameters
            database.ExecuteNonQueryJ()
            'Once the header data parameter are full we can get them from the command
            MyBase.Initialize(database.Command)
            result = True
        Catch ex As Exception
            result = False
            Throw
        End Try
        Return result
    End Function

    Private Function IsValid() As Boolean
        Dim result As Boolean = True
        If _City.Trim = String.Empty Then
            result = False
        End If
        If _State.Trim = String.Empty Then
            result = False
        End If
        If _ZipCode.Trim = String.Empty Then
            result = False
        End If
        Return result
    End Function

#End Region

#Region " Public Methods "
    Public Function GetById(ID As Guid) As ZipCode
        Dim database As New Database("LocalZip")
        Dim dt As New DataTable
        database.Command.CommandType = CommandType.StoredProcedure
        database.Command.CommandText = "tblZipCodeGetById"
        database.Command.Parameters.Add("@ZipCodeId", SqlDbType.UniqueIdentifier).Value = ID        '@ZipCodeId is placeholder
        dt = database.ExecuteQuery()
        If dt IsNot Nothing AndAlso dt.Rows.Count = 1 Then
            Dim dr As DataRow = dt.Rows(0)
            MyBase.Initialize(dr)
            InitializeBusinessData(dr)
            MyBase.IsDirty = False ' 'MyBase' is similar to 'Me'
            MyBase.IsNew = False
        End If
        Return Me

    End Function

    Public Function GetCityStateByZipCode(zipCode As String) As ZipCode
        Dim database As New Database("LocalZip")
        Dim dt As New DataTable
        database.Command.CommandType = CommandType.StoredProcedure
        database.Command.CommandText = "tblGetCityStateByZipCode"
        database.Command.Parameters.Add("@ZipCode", SqlDbType.VarChar).Value = zipCode        '@ZipCodeId is placeholder
        dt = database.ExecuteQuery()
        If dt IsNot Nothing AndAlso dt.Rows.Count = 1 Then
            Dim dr As DataRow = dt.Rows(0)
            MyBase.Initialize(dr)
            InitializeBusinessData(dr)
            MyBase.IsDirty = False ' 'MyBase' is similar to 'Me'
            MyBase.IsNew = False
        End If
        Return Me

    End Function

    Public Function Save() As Boolean
        Dim result As Boolean = True

        Dim database = New Database("Student")
        Try
            If MyBase.IsNew = True AndAlso IsSavable() = True Then
                result = Insert(database)
            ElseIf MyBase.Deleted = True Then
                result = Delete(database)
            ElseIf MyBase.IsNew = False AndAlso IsSavable() = True Then
                result = Update(database)
            End If
            If result = True Then
                MyBase.IsDirty = False
                MyBase.IsNew = False
            End If
            Return result
        Catch ex As Exception
            result = False
        End Try
        Return result
    End Function

    Public Function IsSavable() As Boolean
        Dim result As Boolean = False
        If MyBase.IsDirty = True AndAlso IsValid() = True Then
            result = True
        End If
        Return result
    End Function

    Public Sub InitializeBusinessData(dr As DataRow)
        _City = dr("City").ToString
        _State = dr("State").ToString
        _ZipCode = dr("ZipCode").ToString
    End Sub

#End Region

#Region " Contructors "

    Public Sub New()
        _City = String.Empty
        _State = String.Empty
        _ZipCode = String.Empty
    End Sub

#End Region

End Class
