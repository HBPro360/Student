Imports System.IO
Imports System.Xml
Imports System.Web.Configuration

Public Class Configuration
    Public Shared Function GetConnectionString(name As String) As String
        Dim result As String = String.Empty

        Dim path As String = String.Empty
        path = System.Reflection.Assembly.GetExecutingAssembly.GetName.CodeBase
        path = System.IO.Path.GetDirectoryName(path)
        path = System.IO.Path.Combine(path, "DataSystems.config")

        Dim xmldoc As New XmlDocument
        xmldoc.Load(path)

        Dim xmlNodeList As XmlNodeList = xmldoc.SelectNodes("configuration/connectionStrings/add")
        For Each xmlnode As XmlNode In xmlNodeList
            If xmlnode.Attributes("name").Value.ToUpper = name.ToUpper Then
                result = xmlnode.Attributes("connectionString").Value
                Exit For
            End If
        Next
        If result.Trim = String.Empty Then
            Throw New Exception("Connection String not Found")
        End If
        Return result
    End Function

    Public Shared Function GetConnectionStringWeb(name As String) As String
        Dim result As String = WebConfigurationManager.ConnectionStrings(name).ConnectionString
        If result.Trim = String.Empty Then
            Throw New Exception("Connection String not found")
        End If
        Return result
    End Function
End Class
