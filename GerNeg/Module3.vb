Imports System.Data
Imports System.Data.OleDb
Imports System.Windows.Forms

Module Module3
    Public Function ConexaoBD() As OleDbConnection
        Dim sql As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\GNBD.accdb"
        Return New OleDbConnection(sql)
    End Function
End Module
