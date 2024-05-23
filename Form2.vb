Imports VB = Microsoft.VisualBasic
Public Class Form2

    Private Sub Form2_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        exBrowser.Navigate("about:blank")
    End Sub

    Private Sub exBrowser_CanGoBackChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        MDIParent1.ToolStripButtonBack.Enabled = exBrowser.CanGoBack
    End Sub

    Private Sub exBrowser_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MDIParent1.cboAddress.Items.Add(MDIParent1.cboAddress.Text)
        MDIParent1.ToolStripStatusLabel.Text = "Fertig"
    End Sub


    Private Sub exBrowser_StatusTextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim Text_Status As String = CType(eventSender, Global.Gecko.GeckoWebBrowser).StatusText
        MDIParent1.ToolStripStatusLabel.Text = Text_Status
    End Sub

    Private Sub exBrowser_DocumentTitleChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim Text_Title As String = CType(eventSender, Global.Gecko.GeckoWebBrowser).DocumentTitle
        If Text_Title = "" Then
            Me.Text = "In Bearbeitung ..."
        Else
            Me.Text = Text_Title
        End If
    End Sub

    Private Sub WebBrowser_ProgressChanged(ByVal sender As System.Object, ByVal e As Global.Gecko.GeckoWebBrowser)
        'If e.CurrentProgress < e.MaximumProgress Then
        'If MDIParent1.ToolStripProgressBar.Value >= MDIParent1.ToolStripProgressBar.Maximum Then
        'MDIParent1.ToolStripProgressBar.Value = MDIParent1.ToolStripProgressBar.Minimum
        'Else
        'MDIParent1.ToolStripProgressBar.PerformStep()
        'End If
        'Else
        'MDIParent1.ToolStripProgressBar.Value = MDIParent1.ToolStripProgressBar.Minimum
        'End If
    End Sub


    Private Sub exBrowser_CanGoForwardChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        MDIParent1.ToolStripButtonForward.Enabled = exBrowser.CanGoForward
    End Sub

    Private Sub WebBrowser_Navigating(ByVal sender As System.Object, ByVal e As Global.Gecko.Events.GeckoNavigatingEventArgs)
        MDIParent1.ToolStripStatusLabel.Text = "Navigation zur Adresse: " & e.Uri.Host.ToString
        MDIParent1.cboAddress.Text = e.Uri.OriginalString.ToString
        'Bei solchen Urls, das Fenster schließen
        If e.Uri.AbsoluteUri = "javascript:window.close()" Then
            Me.Close()
            MDIParent1.ToolStripStatusLabel.Text = "Das Fenster wurde geschlossen"
        End If
    End Sub

    Private Sub WebBrowser_CreateWindow(ByVal sender As Object, ByVal e As Global.Gecko.GeckoCreateWindowEventArgs)
        Dim newurl As String = exBrowser.StatusText
        Dim frage As Object
        frage = MsgBox("Die Webseite möchte ein neues Fenster öffnen. Möchten Sie das zulassen?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, My.Application.Info.Title)
        If frage = MsgBoxResult.Yes Then
            Dim ChildForm As New Form1
            ' Vor der Anzeige dem MDI-Formular unterordnen.
            ChildForm.MdiParent = MDIParent1
            ChildForm.exBrowser.Navigate(newurl)
            ChildForm.Show()
        End If
    End Sub

End Class