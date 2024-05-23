Option Strict Off
Option Explicit On
Friend Class frmOption
	Inherits System.Windows.Forms.Form
	
	
    Private Sub CookieForm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CookieForm.Click
        Dim CookieForm As New frmCookieViewer
        CookieForm.MdiParent = MDIParent1
        CookieForm.Show()
    End Sub
	
	Private Sub InetSettings_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles InetSettings.Click
        Shell("control.exe inetcpl.cpl")
    End Sub
	
	
    Private Sub geckoconfigButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles geckoconfigButton.Click
        ' Neue Instanz des untergeordneten Formulars erstellen.
        Dim ChildForm As New Form2
        ' Vor der Anzeige dem MDI-Formular unterordnen.
        ChildForm.MdiParent = MDIParent1
        ChildForm.Show()
        ChildForm.exBrowser.Navigate("about:config")
    End Sub
End Class