Imports VB = Microsoft.VisualBasic
Public Class Form1

    Private Sub WebBrowser_CanGoBackChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles exBrowser.CanGoBackChanged
        MDIParent1.ToolStripButtonBack.Enabled = exBrowser.CanGoBack
    End Sub

    Private Sub WebBrowser_DocumentCompleted(ByVal sender As Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles exBrowser.DocumentCompleted
        MDIParent1.cboAddress.Items.Add(MDIParent1.cboAddress.Text)
    End Sub

    Private Sub WebBrowser_Navigated(ByVal sender As Object, ByVal e As System.Windows.Forms.WebBrowserNavigatedEventArgs) Handles exBrowser.Navigated
        MDIParent1.ToolStripStatusLabel.Text = "Navigation zur Adresse: " & e.Url.Host.ToString & " war erfolgreich"
        MDIParent1.cboAddress.Text = exBrowser.Url.AbsoluteUri
    End Sub

    Private Sub WebBrowser_Navigating(ByVal sender As Object, ByVal e As System.Windows.Forms.WebBrowserNavigatingEventArgs) Handles exBrowser.Navigating
        MDIParent1.ToolStripStatusLabel.Text = "Navigation zur Adresse: " & e.Url.Host.ToString
        MDIParent1.cboAddress.Text = e.Url.OriginalString.ToString
        'Bei solchen Urls, das Fenster schließen
        If e.Url.AbsoluteUri = "javascript:window.close()" Then
            Me.Close()
            MDIParent1.ToolStripStatusLabel.Text = "Das Fenster wurde geschlossen"
        End If
        'If Media(e.Url.AbsoluteUri) = True Then e.Cancel = True : System.Windows.Forms.Application.DoEvents() : Exit Sub
    End Sub

    Function Media(ByVal sUrl As String) As Boolean
        Dim FMediaForm As New frmMedia
        FMediaForm.MdiParent = MDIParent1
        If VB.Right(LCase(sUrl), 4) = ".wav" Then
            Media = True
            System.Windows.Forms.Application.DoEvents()
            'FMediaForm.StartingAddress = sUrl
            FMediaForm.Show()
        ElseIf VB.Right(LCase(sUrl), 4) = ".avi" Then
            Media = True
            System.Windows.Forms.Application.DoEvents()
            'FMediaForm.StartingAddress = sUrl
            FMediaForm.Show()
        ElseIf VB.Right(LCase(sUrl), 4) = ".mp3" Then
            Media = True
            System.Windows.Forms.Application.DoEvents()
            'FMediaForm.StartingAddress = sUrl
            FMediaForm.Show()
        ElseIf VB.Right(LCase(sUrl), 4) = ".wma" Then
            Media = True
            System.Windows.Forms.Application.DoEvents()
            'FMediaForm.StartingAddress = sUrl
            FMediaForm.Show()
        ElseIf VB.Right(LCase(sUrl), 4) = ".wmv" Then
            Media = True
            System.Windows.Forms.Application.DoEvents()
            'FMediaForm.StartingAddress = sUrl
            FMediaForm.Show()
        End If
    End Function

    Private Sub WebBrowser_StatusTextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles exBrowser.StatusTextChanged
        Dim Text_Status As String = CType(eventSender, WebBrowser).StatusText
        MDIParent1.ToolStripStatusLabel.Text = Text_Status
    End Sub

    Private Sub WebBrowser_DocumentTitleChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles exBrowser.DocumentTitleChanged
        Dim Text_Title As String = CType(eventSender, WebBrowser).DocumentTitle
        If Text_Title = "" Then
            Me.Text = "In Bearbeitung ..."
        Else
            Me.Text = Text_Title
        End If
    End Sub

    Private Sub WebBrowser_ProgressChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.WebBrowserProgressChangedEventArgs) Handles exBrowser.ProgressChanged
        If e.CurrentProgress < e.MaximumProgress Then
            If MDIParent1.ToolStripProgressBar.Value >= MDIParent1.ToolStripProgressBar.Maximum Then
                MDIParent1.ToolStripProgressBar.Value = MDIParent1.ToolStripProgressBar.Minimum
            Else
                MDIParent1.ToolStripProgressBar.PerformStep()
            End If
        Else
            MDIParent1.ToolStripProgressBar.Value = MDIParent1.ToolStripProgressBar.Minimum
        End If
    End Sub


    Private Sub WebBrowser_NewWindow(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles exBrowser.NewWindow
        e.Cancel = True
    End Sub

    Private Sub WebBrowser_NewWindowExtended(ByVal sender As Object, _
    ByVal e As exBrowser.WebBrowserNewWindowExtendedEventArgs) Handles exBrowser.NewWindowExtended
        Dim frage As Object
        frage = MsgBox("Die Webseite möchte ein neues Fenster öffnen. Möchten Sie das zulassen?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, My.Application.Info.Title)
        If frage = MsgBoxResult.Yes Then
            e.Cancel = True
            Dim ChildForm As New Form1
            ' Vor der Anzeige dem MDI-Formular unterordnen.
            ChildForm.MdiParent = MDIParent1
            ChildForm.exBrowser.Navigate(e.Url.ToString)
            ChildForm.Show()
        End If
        If frage = MsgBoxResult.No Then e.Cancel = True

    End Sub


    Private Sub WebBrowser_CanGoForwardChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles exBrowser.CanGoForwardChanged
        MDIParent1.ToolStripButtonForward.Enabled = exBrowser.CanGoForward
    End Sub
End Class
