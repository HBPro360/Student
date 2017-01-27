Imports DatabaseHelper
Imports System.Data
Imports BusinessObjects
Public Class StudentAddress
    Inherits HeaderData

#Region " Private Members "
    Private _StudentID As Guid
    Private _AddressTypeID As Guid
    Private _Address As String
    Private _City As String
    Private _State As String
    Private _ZipCode As String
    Private _BrokenRules As BrokenRuleList
#End Region

#Region " Public Properties "

    Public ReadOnly Property BrokenRules As BrokenRuleList
        Get
            Return _BrokenRules
        End Get
    End Property

    Public ReadOnly Property FullName
        Get
            Dim student As New Student
            student = student.GetById(_StudentID)
            Return student.FullName
        End Get
    End Property
    Public Property StudentID As Guid
        Get
            Return _StudentID
        End Get
        Set(value As Guid)
            If _StudentID <> value Then
                _StudentID = value
                MyBase.IsDirty = True
                Dim savable As Boolean = IsSavable()
                Dim e As New SavableEventArgs(savable)
                RaiseOurEvent(e)
            End If
        End Set
    End Property

    Public Property AddressTypeID As Guid
        Get
            Return _AddressTypeID
        End Get
        Set(value As Guid)
            If _AddressTypeID <> value Then
                _AddressTypeID = value
                MyBase.IsDirty = True
                Dim savable As Boolean = IsSavable()
                Dim e As New SavableEventArgs(savable)
                RaiseOurEvent(e)
            End If
        End Set
    End Property

    Public Property Address As String
        Get
            Return _Address
        End Get
        Set(value As String)
            If _Address <> value Then
                _Address = value
                MyBase.IsDirty = True
                Dim savable As Boolean = IsSavable()
                Dim e As New SavableEventArgs(savable)
                RaiseOurEvent(e)
            End If
        End Set
    End Property

    Public Property City As String
        Get
            Return _City
        End Get
        Set(value As String)
            If _City <> value Then
                _City = value
                MyBase.IsDirty = True
                Dim savable As Boolean = IsSavable()
                Dim e As New SavableEventArgs(savable)
                RaiseOurEvent(e)
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
                Dim savable As Boolean = IsSavable()
                Dim e As New SavableEventArgs(savable)
                RaiseOurEvent(e)
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

                Dim zip As New localhost.Zipcode.www.StudentWebService

                Dim result As localhost.Zipcode.www.ZipCode

                result = zip.GetCityStateByZip(_ZipCode)

                _City = result.City
                _State = result.State

                MyBase.IsDirty = True
                Dim savable As Boolean = IsSavable()
                Dim e As New SavableEventArgs(savable)
                RaiseOurEvent(e)
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
            database.Command.CommandText = "tblStudentAddressInsert"
            'Add Busines Parameters to the command object
            database.Command.Parameters.Add("@StudentID", SqlDbType.UniqueIdentifier).Value = _StudentID
            database.Command.Parameters.Add("@AddressTypeID", SqlDbType.UniqueIdentifier).Value = _AddressTypeID
            database.Command.Parameters.Add("@Address", SqlDbType.VarChar).Value = _Address
            database.Command.Parameters.Add("@City", SqlDbType.VarChar).Value = _City
            database.Command.Parameters.Add("@State", SqlDbType.VarChar).Value = _State
            database.Command.Parameters.Add("@ZipCode", SqlDbType.VarChar).Value = _ZipCode
            'Add header data parameters to the commend object (or empty buckets)
            MyBase.Initialize(database, Guid.Empty)
            'Insert the student and fill up the header data parameters
            database.ExecuteNonQueryWithTransaction()
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
            database.Command.CommandText = "tblStudentAddressUpdate"
            'Add Business Parameters to the command object
            database.Command.Parameters.Add("@StudentID", SqlDbType.UniqueIdentifier).Value = _StudentID
            database.Command.Parameters.Add("@AddressTypeID", SqlDbType.UniqueIdentifier).Value = _AddressTypeID
            database.Command.Parameters.Add("@Address", SqlDbType.VarChar).Value = _Address
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
            database.Command.CommandText = "tblStudentAddressDelete"
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
        _BrokenRules.List.Clear()

        If _AddressTypeID = Guid.Empty Then
            _BrokenRules.List.Add(New BrokenRule("Address type must be selected."))
            result = False
        End If

        If _Address.Trim = String.Empty Then
            _BrokenRules.List.Add(New BrokenRule("Address must be present."))
            result = False
        End If

        If _City.Trim = String.Empty Then
            _BrokenRules.List.Add(New BrokenRule("City must be present."))
            result = False
        End If

        If _State.Trim = String.Empty Then
            _BrokenRules.List.Add(New BrokenRule("State must be present."))
            result = False
        End If

        If _ZipCode.Trim = String.Empty Then
            _BrokenRules.List.Add(New BrokenRule("Zip code must be present."))
            result = False
        End If

        Return result
    End Function

    Private Function IsStrongPassword(password As String) As Boolean
        Dim result As Boolean = False
        Dim conditionsCount As Integer = 0

        If Char.IsLower(password) = True Then
            conditionsCount += 1
        End If

        If Char.IsUpper(password) Then
            conditionsCount += 1
        End If

        If Char.IsDigit(password) Then
            conditionsCount += 1
        End If

        If password.Contains("$") OrElse password.Contains("#") OrElse password.Contains("@") Then
            conditionsCount += 1
        End If

        If conditionsCount >= 3 Then
            result = True
        End If

        If password.Length <= 8 Then
            result = False
        End If

        Return result

    End Function

#End Region

#Region " Public Methods "
    Public Function GetById(ID As Guid) As StudentAddress
        Dim database As New Database("LocalZip")
        Dim dt As New DataTable
        database.Command.CommandType = CommandType.StoredProcedure
        database.Command.CommandText = "tblStudentAddressGetById"
        database.Command.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = ID
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

    Public Function Save(database As Database, parentID As Guid) As Boolean
        Dim result As Boolean = True
        _StudentID = parentID
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
                MyBase.IsNew = True
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
        _StudentID = New Guid(dr("StudentID").ToString())
        _AddressTypeID = New Guid(dr("AddressTypeID").ToString())
        _Address = dr("Address").ToString()
        _City = dr("City").ToString()
        _State = dr("State").ToString()
        _ZipCode = dr("ZipCode").ToString()
    End Sub

#End Region

#Region " Contructors "

    Public Sub New()
        _StudentID = Guid.Empty
        _AddressTypeID = Guid.Empty
        _Address = String.Empty
        _City = String.Empty
        _State = String.Empty
        _ZipCode = String.Empty
        _BrokenRules = New BrokenRuleList
    End Sub

#End Region


End Class