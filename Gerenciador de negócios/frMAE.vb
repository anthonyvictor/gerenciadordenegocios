Imports GerNeg
Public Class frMAE

    Private Sub frMAE_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If logado.Text = 1 Then
            Dim form As New frmPRINC
            form.MdiParent = Me
            form.Show()
            form.WindowState = Windows.Forms.FormWindowState.Maximized
        Else
            Dim form As New frmLOGIN
            form.ShowDialog()
            Me.Close()
        End If
    End Sub
End Class
