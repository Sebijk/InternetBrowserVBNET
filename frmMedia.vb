Option Strict Off
Option Explicit On
Public Class frmMedia
    Inherits System.Windows.Forms.Form
    Sub frmMedia_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
    End Sub

    'UPGRADE_WARNING: Event cboAddress.SelectedIndexChanged may fire when form is initialized. Click for more: 'ms-help://MS.VSExpressCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub cboAddress_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cboAddress.SelectedIndexChanged
        timTimer.Enabled = True
        MediaPlayer.FileName = cboAddress.Text
        MediaPlayer.Play()
        cboAddress.Items.Add(cboAddress.Text)
    End Sub


    Private Sub cboAddress_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As KeyPressEventArgs) Handles cboAddress.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        On Error Resume Next
        If KeyAscii = System.Windows.Forms.Keys.Return Then
            cboAddress_SelectedIndexChanged(cboAddress, New System.EventArgs())
        End If
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub


    Private Sub btnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpen.Click
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Alle Dateien (*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = DialogResult.OK) Then
            Dim sFile As String = OpenFileDialog.FileName
            MediaPlayer.FileName = sFile
            MediaPlayer.Play()
            cboAddress.Text = sFile
            cboAddress.Items.Add(sFile)
        End If
    End Sub

    Private Sub btnEigenschaften_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEigenschaften.Click
        MediaPlayer.ShowPropertyPages()
    End Sub
End Class