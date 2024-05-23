Option Strict Off
Option Explicit On
Friend Class frmDownload
	Inherits System.Windows.Forms.Form

    Private Declare Function DoFileDownload Lib "shdocvw.dll" (ByVal lpszFile() As Int16) As Integer
    Public Sub DisplayDownloadBox(ByVal sPath As String)
        Dim abUnicode(sPath.Length) As Int16
        For i As Integer = 0 To sPath.Length - 1
            abUnicode(i) = Microsoft.VisualBasic.Strings.AscW(sPath.Substring(i, 1))
        Next i
        Call DoFileDownload(abUnicode)
        Erase abUnicode
    End Sub


    Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
        DisplayDownloadBox(Text1.Text)
    End Sub
End Class