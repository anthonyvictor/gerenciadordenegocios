Imports System.Data
Imports System.Data.OleDb
Imports System.Drawing
Imports System.Windows.Forms
Public Class frmLOGIN
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
    Public Sub entrar()
        If Trim(UsernameTextBox.Text) = "" Then
            lberro.Text = "****** DIGITE O USUÁRIO ******"
            lberro.Visible = True
            UsernameTextBox.Focus()
            Exit Sub
        End If
        If Trim(PasswordTextBox.Text) = "" Then
            lberro.Text = "****** DIGITE A SENHA ******"
            lberro.Visible = True
            PasswordTextBox.Focus()
            Exit Sub
        End If
        Using con As OleDbConnection = ConexaoBD()
            Try
                con.Open()
                Dim str = "select * from tbl_USER where ucase(user_nome) like '" & UCase(UsernameTextBox.Text) & "' or user_numero like '" & UsernameTextBox.Text & "' or ucase(user_email) like '" & UCase(UsernameTextBox.Text) & "'"
                Dim cmd As New OleDbCommand(str, con)
                Dim leitor = cmd.ExecuteReader
                If leitor.Read() Then
                    If leitor.Item(5).ToString = PasswordTextBox.Text Then
                        Me.Hide()
                        Dim form As New frmPRINC
                        form.ShowDialog()
                    Else
                        lberro.Text = "****** SENHA INCORRETA ******"
                        lberro.Visible = True
                        PasswordTextBox.Focus()
                    End If
                Else
                    lberro.Text = "****** USUÁRIO NÃO CADASTRADO ******"
                    lberro.Visible = True
                    UsernameTextBox.Focus()
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "GERNEG")
            End Try
        End Using
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        entrar()
    End Sub

    Private Sub GERNEG_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub PasswordTextBox_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles PasswordTextBox.KeyUp
        If e.KeyCode = Keys.Enter Then
            entrar()
        End If
    End Sub
End Class
