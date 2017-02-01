Imports DatabaseHelper
Imports System.Data

Public Class StudentPhone
    Inherits HeaderData

#Region " Private Members "
    Private _StudentID As Guid
    Private _PhoneTypeID As Guid
    Private _Phone As String
    Private _IsPasswordPending As Boolean
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

    Public Property PhoneTypeID As Guid
        Get
            Return _PhoneTypeID
        End Get
        Set(value As Guid)
            If _PhoneTypeID <> value Then
                _PhoneTypeID = value
                MyBase.IsDirty = True
                Dim savable As Boolean = IsSavable()
                Dim e As New SavableEventArgs(savable)
                RaiseOurEvent(e)
            End If
        End Set
    End Property

    Public Property Phone As String
        Get
            Return _Phone
        End Get
        Set(value As String)
            If _Phone <> value Then
                _Phone = value
                MyBase.IsDirty = True
                Dim savable As Boolean = IsSavable()
                Dim e As New SavableEventArgs(savable)
                RaiseOurEvent(e)
            End If
        End Set
    End Property

    Public Property IsPasswordPending As Boolean
        Get
            Return _IsPasswordPending
        End Get
        Set(value As Boolean)
            If _IsPasswordPending <> value Then
                _IsPasswordPending = value
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
            database.Command.CommandText = "tblStudentPhoneInsert"
            'Add Busines Parameters to the command object
            database.Command.Parameters.Add("@StudentID", SqlDbType.UniqueIdentifier).Value = _StudentID
            database.Command.Parameters.Add("@PhoneTypeID", SqlDbType.UniqueIdentifier).Value = _PhoneTypeID
            database.Command.Parameters.Add("@Phone", SqlDbType.VarChar).Value = _Phone
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
            database.Command.CommandText = "tblStudentPhoneUpdate"
            'Add Business Parameters to the command object
            database.Command.Parameters.Add("@StudentID", SqlDbType.UniqueIdentifier).Value = _StudentID
            database.Command.Parameters.Add("@PhoneTypeID", SqlDbType.UniqueIdentifier).Value = _PhoneTypeID
            database.Command.Parameters.Add("@Phone", SqlDbType.VarChar).Value = _Phone
            'Add header data parameters to the commend object (or empty buckets)
            MyBase.Initialize(database, MyBase.ID)
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

    Private Function Delete(database As Database) As Boolean
        Dim result As Boolean = True
        Try
            database.Command.Parameters.Clear()
            database.Command.CommandType = CommandType.StoredProcedure
            database.Command.CommandText = "tblStudentPhoneDelete"
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
        If _PhoneTypeID = Guid.Empty Then
            _BrokenRules.List.Add(New BrokenRule("Phone Type must be Selected."))
            result = False
        End If

        If _Phone.Trim = String.Empty Then
            _BrokenRules.List.Add(New BrokenRule("Phone must be Present."))
            result = False
        End If

        If _Phone.Trim.Length <> 10 Then
            _BrokenRules.List.Add(New BrokenRule("Phone must consist of 10 numbers."))
            result = False
        End If

        If IsNumeric(_Phone.ToString()) = False Then
            _BrokenRules.List.Add(New BrokenRule("Phone must be numeric."))
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
    Public Function GetById(ID As Guid) As StudentPhone
        Dim database As New Database("Student")
        Dim dt As New DataTable
        database.Command.CommandType = CommandType.StoredProcedure
        database.Command.CommandText = "tblStudentPhoneGetById"
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
        _PhoneTypeID = New Guid(dr("PhoneTypeID").ToString())
        _Phone = dr("Phone").ToString()
    End Sub

#End Region

#Region " Contructors "

    Public Sub New()
        _StudentID = Guid.Empty
        _PhoneTypeID = Guid.Empty
        _Phone = String.Empty
        _IsPasswordPending = False
        _BrokenRules = New BrokenRuleList
    End Sub

#End Region


End Class