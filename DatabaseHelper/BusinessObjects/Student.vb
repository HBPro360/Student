Imports DatabaseHelper
Imports System.Data

Public Class Student
    Inherits HeaderData

#Region " Private Members "
    Private _FirstName As String
    Private _LastName As String
    Private _Email As String
    Private _Password As String
    Private _IsPasswordPending As Boolean
    Private _ProgramID As Guid
    Private _Phones As StudentPhoneList
    Private _Emails As StudentEmailList
    Private _Addresses As StudentAddressList
#End Region

#Region " Public Properties "

    Public ReadOnly Property Phones As StudentPhoneList
        Get
            If _Phones Is Nothing Then
                _Phones = New StudentPhoneList
                _Phones = _Phones.GetByStudentID(MyBase.ID)
            End If
            Return _Phones
        End Get
    End Property

    Public ReadOnly Property Emails As StudentEmailList
        Get
            If _Emails Is Nothing Then
                _Emails = New StudentEmailList
                _Emails = _Emails.GetByStudentID(MyBase.ID)
            End If
            Return _Emails
        End Get
    End Property

    Public ReadOnly Property Addresses As StudentAddressList
        Get
            If _Addresses Is Nothing Then
                _Addresses = New StudentAddressList
                _Addresses = _Addresses.GetByStudentID(MyBase.ID)
            End If
            Return _Addresses
        End Get
    End Property

    Public ReadOnly Property FullName As String
        Get
            Return _FirstName & " " & _LastName
        End Get
    End Property
    Public Property FirstName As String
        Get
            Return _FirstName
        End Get
        Set(value As String)
            If _FirstName <> value Then
                _FirstName = value
                MyBase.IsDirty = True
                Dim savable As Boolean = IsSavable()
                Dim e As New SavableEventArgs(savable)
                RaiseOurEvent(e)
            End If
        End Set
    End Property

    Public Property LastName As String
        Get
            Return _LastName
        End Get
        Set(value As String)
            If _LastName <> value Then
                _LastName = value
                MyBase.IsDirty = True
                Dim savable As Boolean = IsSavable()
                Dim e As New SavableEventArgs(savable)
                RaiseOurEvent(e)
            End If
        End Set
    End Property

    Public Property Email As String
        Get
            Return _Email
        End Get
        Set(value As String)
            If _Email <> value Then
                _Email = value
                MyBase.IsDirty = True
                Dim savable As Boolean = IsSavable()
                Dim e As New SavableEventArgs(savable)
                RaiseOurEvent(e)
            End If
        End Set
    End Property

    Public Property Password As String
        Get
            Return _Password
        End Get
        Set(value As String)
            If _Password <> value Then
                _Password = value
                MyBase.IsDirty = True
                Dim savable As Boolean = IsSavable()
                Dim e As New SavableEventArgs(savable)
                RaiseOurEvent(e)
            End If
        End Set
    End Property
    Public Property ProgramID As Guid
        Get
            Return _ProgramID
        End Get
        Set(value As Guid)
            If _ProgramID <> value Then
                _ProgramID = value
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
            database.Command.CommandText = "tblStudentInsert"
            'Add Busines Parameters to the command object
            database.Command.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = _FirstName
            database.Command.Parameters.Add("@LastName", SqlDbType.VarChar).Value = _LastName
            database.Command.Parameters.Add("@Email", SqlDbType.VarChar).Value = _Email
            database.Command.Parameters.Add("@Password", SqlDbType.VarChar).Value = _Password
            database.Command.Parameters.Add("@ProgramID", SqlDbType.UniqueIdentifier).Value = _ProgramID
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
    End Function

    Private Function Update(database As Database) As Boolean
        Dim result As Boolean = True
        Try
            database.Command.Parameters.Clear()
            database.Command.CommandType = CommandType.StoredProcedure
            database.Command.CommandText = "tblStudentUpdate"
            'Add Business Parameters to the command object
            database.Command.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = _FirstName
            database.Command.Parameters.Add("@LastName", SqlDbType.VarChar).Value = _LastName
            database.Command.Parameters.Add("@Email", SqlDbType.VarChar).Value = _Email
            database.Command.Parameters.Add("@Password", SqlDbType.VarChar).Value = _Password
            database.Command.Parameters.Add("@ProgramID", SqlDbType.UniqueIdentifier).Value = _ProgramID
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
            database.Command.CommandText = "tblStudentDelete"
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
    End Function

    Private Function IsValid() As Boolean
        Dim result As Boolean = True
        If _FirstName.Trim = String.Empty Then
            result = False
        End If

        If _LastName.Trim = String.Empty Then
            result = False
        End If

        If _Email.Trim = String.Empty Then
            result = False
        End If

        If _Password = String.Empty Then
            result = False
        End If

        If _ProgramID = Guid.Empty Then
            result = False
        End If

        'If IsStrongPassword(Password) = False Then
        '    result = False
        'End If

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
    Public Function GetById(ID As Guid) As Student
        Dim database As New Database("Student")
        Dim dt As New DataTable
        database.Command.CommandType = CommandType.StoredProcedure
        database.Command.CommandText = "tblStudentGetById"
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

    Public Function Save() As Boolean
        Dim result As Boolean = True

        Dim database = New Database("Student")
        database.BeginTransaction()

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

            If result = True AndAlso _Phones IsNot Nothing AndAlso _Phones.isSavable() Then
                result = _Phones.Save(database, MyBase.ID)
            End If

            If result = True AndAlso _Emails IsNot Nothing AndAlso _Emails.isSavable() Then
                result = _Emails.Save(database, MyBase.ID)
            End If

            If result = True AndAlso _Addresses IsNot Nothing AndAlso _Addresses.isSavable() Then
                result = _Addresses.Save(database, MyBase.ID)
            End If

            If result = True Then
                database.Endtransaction()
            Else
                database.RollBack()
            End If

            Return result
        Catch ex As Exception
            result = False
        End Try
        Return result
    End Function

    Public Function IsSavable() As Boolean
        Dim result As Boolean = False
        If MyBase.IsDirty = True AndAlso IsValid() = True _
            OrElse _Emails IsNot Nothing AndAlso _Emails.isSavable() = True _
            OrElse _Phones IsNot Nothing AndAlso _Phones.isSavable() = True Then
            result = True
        End If
        Return result
    End Function

    Public Function InitializeBusinessData(dr As DataRow)
        _FirstName = dr("FirstName").ToString
        _LastName = dr("LastName").ToString
        _Email = dr("Email").ToString
        _Password = dr("Password").ToString
        _IsPasswordPending = Convert.ToBoolean(dr("IsPasswordPending"))
        _ProgramID = New Guid(dr("ProgramID").ToString)

    End Function

#End Region

#Region " Contructors "

    Public Sub New()
        _FirstName = String.Empty
        _LastName = String.Empty
        _Email = String.Empty
        _Password = String.Empty
        _IsPasswordPending = False
        _ProgramID = Guid.Empty
        _Phones = Nothing
        _Emails = Nothing
        _Addresses = Nothing
    End Sub

#End Region

End Class
