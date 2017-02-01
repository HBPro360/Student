Imports System.ComponentModel
Imports BusinessObjects
Imports DatabaseHelper
Imports SQLHelper
Imports DataTypeHelper.SearchCriteria
Imports System.Reflection

Public Class StudentList
    Inherits [Event]
#Region " Private Members "
    Private WithEvents _List As BindingList(Of Student)
    Private WithEvents student As Student
    Private _Criteria As New Criteria
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

    'Private List<String> GetSearchList()
    '    {
    '        List<string> list = New List<string>();
    '        If (studentList == null)
    '        {
    '            studentList = New StudentList();
    '        }
    '        PropertyInfo[] myProperties = studentList.GetType().GetProperties(BindingFlags.Public |
    '                                                BindingFlags.SetProperty |
    '                                                BindingFlags.Instance);
    '        list.Add(string.Empty);
    '        foreach (PropertyInfo item in myProperties)
    '        {
    '            If (item.CanWrite)
    '            {
    '                list.Add(item.Name);
    '            }    
    '        }
    '        studentList = null;
    '        Return list;

    '    }

    Public Shared Function GetSearchList() As List(Of String)
        Dim list As New List(Of String)
        Dim sl As New StudentList
        Dim myProperties As PropertyInfo() = sl.GetType().GetProperties(BindingFlags.Public _
                                                                        Or BindingFlags.SetProperty _
                                                                        Or BindingFlags.Instance)
        list.Add(String.Empty)
        For Each item As PropertyInfo In myProperties
            If item.CanWrite Then
                list.Add(item.Name)
            End If
        Next
        Return list
    End Function

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
            AddHandler student.Emails.Savable, AddressOf student_Savable
            AddHandler student.Addresses.Savable, AddressOf student_Savable
            _List.Add(student)
        Next
        Return Me
    End Function

    Public Function Search() As StudentList
        Dim db As New Database("Student")
        Dim dt As DataTable
        _Criteria.TableName = "tblStudent"
        db.Command.CommandType = CommandType.Text
        db.Command.CommandText = Builder.Build(_Criteria)

        dt = db.ExecuteQuery()
        For Each dr As DataRow In dt.Rows
            Dim student As New Student
            student.Initialize(dr)
            student.InitializeBusinessData(dr)
            student.IsNew = False
            AddHandler student.Savable, AddressOf student_Savable
            AddHandler student.Phones.Savable, AddressOf student_Savable
            AddHandler student.Emails.Savable, AddressOf student_Savable
            AddHandler student.Addresses.Savable, AddressOf student_Savable
            _List.Add(student)
        Next
        Return Me
    End Function

    Public Function SearchPhoneList() As StudentList
        Dim db As New Database("Student")
        Dim dt As DataTable
        _Criteria.TableName = "tblStudentPhone"
        db.Command.CommandType = CommandType.Text
        db.Command.CommandText = Builder.BuildList(_Criteria)

        dt = db.ExecuteQuery()
        For Each dr As DataRow In dt.Rows
            Dim s As New Student
            s = s.GetById(dr("StudentId"))
            _List.Add(s)
            AddHandler s.Savable, AddressOf student_Savable
            AddHandler s.Phones.Savable, AddressOf student_Savable
            AddHandler s.Emails.Savable, AddressOf student_Savable
            AddHandler s.Addresses.Savable, AddressOf student_Savable
        Next
        Return Me
    End Function

    Public Function SearchEmailList() As StudentList
        Dim db As New Database("Student")
        Dim dt As DataTable
        _Criteria.TableName = "tblStudentEmail"
        db.Command.CommandType = CommandType.Text
        db.Command.CommandText = Builder.BuildList(_Criteria)

        dt = db.ExecuteQuery()
        For Each dr As DataRow In dt.Rows
            Dim s As New Student
            s = s.GetById(dr("StudentId"))
            _List.Add(s)
            AddHandler s.Savable, AddressOf student_Savable
            AddHandler s.Phones.Savable, AddressOf student_Savable
            AddHandler s.Emails.Savable, AddressOf student_Savable
            AddHandler s.Addresses.Savable, AddressOf student_Savable
        Next
        Return Me
    End Function

    Public Function SearchAddressList() As StudentList
        Dim db As New Database("Student")
        Dim dt As DataTable
        _Criteria.TableName = "tblStudentAddress"
        db.Command.CommandType = CommandType.Text
        db.Command.CommandText = Builder.BuildList(_Criteria)

        dt = db.ExecuteQuery()
        For Each dr As DataRow In dt.Rows
            Dim s As New Student
            s = s.GetById(dr("StudentId"))
            _List.Add(s)
            AddHandler s.Savable, AddressOf student_Savable
            AddHandler s.Phones.Savable, AddressOf student_Savable
            AddHandler s.Emails.Savable, AddressOf student_Savable
            AddHandler s.Addresses.Savable, AddressOf student_Savable
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

    Public WriteOnly Property FirstName() As String

        Set(value As String)
            If value <> String.Empty Then
                _Criteria.Fields.Add("FirstName")
                _Criteria.Values.Add(value)
                _Criteria.Types.Add(Type.String_Contains)
            End If
        End Set
    End Property

    Public WriteOnly Property LastName() As String

        Set(value As String)
            If value <> String.Empty Then
                _Criteria.Fields.Add("LastName")
                _Criteria.Values.Add(value)
                _Criteria.Types.Add(Type.String_Contains)
            End If
        End Set
    End Property

    Public WriteOnly Property Phone() As String

        Set(value As String)
            If value <> String.Empty Then
                _Criteria.Fields.Add("Phone")
                _Criteria.Values.Add(value)
                _Criteria.Types.Add(Type.String_Contains)
            End If
        End Set
    End Property

    Public WriteOnly Property Email() As String

        Set(value As String)
            If value <> String.Empty Then
                _Criteria.Fields.Add("Email")
                _Criteria.Values.Add(value)
                _Criteria.Types.Add(Type.String_Contains)
            End If
        End Set
    End Property

    Public WriteOnly Property Address() As String

        Set(value As String)
            If value <> String.Empty Then
                _Criteria.Fields.Add("Address")
                _Criteria.Values.Add(value)
                _Criteria.Types.Add(Type.String_Contains)
            End If
        End Set
    End Property

    Public WriteOnly Property City() As String

        Set(value As String)
            If value <> String.Empty Then
                _Criteria.Fields.Add("City")
                _Criteria.Values.Add(value)
                _Criteria.Types.Add(Type.String_Contains)
            End If
        End Set
    End Property

    Public WriteOnly Property State() As String

        Set(value As String)
            If value <> String.Empty Then
                _Criteria.Fields.Add("State")
                _Criteria.Values.Add(value)
                _Criteria.Types.Add(Type.String_Contains)
            End If
        End Set
    End Property

    Public WriteOnly Property ZipCode() As String

        Set(value As String)
            If value <> String.Empty Then
                _Criteria.Fields.Add("ZipCode")
                _Criteria.Values.Add(value)
                _Criteria.Types.Add(Type.String_Contains)
            End If
        End Set
    End Property


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
