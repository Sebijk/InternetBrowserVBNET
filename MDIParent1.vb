Imports System.Windows.Forms

Public Class MDIParent1
    Private Declare Function ShellAbout Lib "shell32.dll" Alias "ShellAboutA" (ByVal hWnd As Integer, ByVal szApp As String, ByVal szOtherStuff As String, ByVal hIcon As Integer) As Integer

    Public Function GetTempDir2(Optional ByVal AddBackslash As Boolean = True) As String
        Dim nTempDir As String

        On Error Resume Next
        nTempDir = Environ$("temp")
        If Len(nTempDir) = 0 Then
            nTempDir = Environ$("tmp")
        End If
        If Len(nTempDir) Then
            If AddBackslash Then
                GetTempDir2 = nTempDir & "\"
            Else
                GetTempDir2 = nTempDir
            End If
        End If
        Return nTempDir
    End Function

    Private Sub MDIParent1_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        ShowNewForm(Me, New System.EventArgs())
    End Sub

    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs) Handles NeuTridentToolStripMenuItem.Click, NewToolStripButton.Click, NewWindowToolStripMenuItem.Click
        ' Neue Instanz des untergeordneten Formulars erstellen.
        Dim ChildForm As New Form1
        ' Vor der Anzeige dem MDI-Formular unterordnen.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "Fenster " & m_ChildFormNumber

        ChildForm.Show()
    End Sub

    Private Sub ShowNewGeckoForm(ByVal sender As Object, ByVal e As EventArgs) Handles NeuGeckoToolStripMenuItem.Click, ToolStripNewGeckoToolStrip.Click
        ' Neue Instanz des untergeordneten Formulars erstellen.
        Dim ChildForm As New Form2
        ' Vor der Anzeige dem MDI-Formular unterordnen.
        ChildForm.MdiParent = Me
        m_ChildFormNumber += 1
        ChildForm.Show()
        ChildForm.Text = "Fenster " & m_ChildFormNumber
        ChildForm.exBrowser.Navigate("about:blank")
    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs) Handles OpenToolStripMenuItem.Click, OpenToolStripButton.Click
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "HTML-Dateien (*.html)|*.html|Alle Dateien (*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            ' TODO: Hier Code zum Öffnen der Datei hinzufügen.
            Dim ChildForm As New Form1
            ' Vor der Anzeige dem MDI-Formular unterordnen.
            ChildForm.MdiParent = Me
            m_ChildFormNumber += 1
            ChildForm.Text = "Fenster " & m_ChildFormNumber
            ChildForm.exBrowser.Navigate(FileName)
            ChildForm.Show()
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SaveToolStripMenuItem.Click, SaveToolStripButton.Click
        Dim activeChild As Form = Me.ActiveMdiChild
        If (Not activeChild Is Nothing) Then
            Try
                Dim theBox As WebBrowser = CType(activeChild.ActiveControl, WebBrowser)
                If (Not theBox Is Nothing) Then
                    theBox.ShowSaveAsDialog()
                End If
            Catch
                MessageBox.Show("You need to select a WebBrowser.")
            End Try
        End If
    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExitToolStripMenuItem.Click
        Global.System.Windows.Forms.Application.Exit()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CutToolStripMenuItem.Click
        ' Mithilfe von My.Computer.Clipboard den ausgewählten Text bzw. die ausgewählten Bilder in die Zwischenablage kopieren
        Dim activeChild As Form = Me.ActiveMdiChild
        On Error Resume Next
        If (Not activeChild Is Nothing) Then
            Dim theBox As WebBrowser = CType(activeChild.ActiveControl, WebBrowser)
            If (Not theBox Is Nothing) Then
                theBox.Document.ExecCommand("Cut", False, System.DBNull.Value)
                Exit Sub
            End If
            Dim theBox2 As Global.Gecko.GeckoWebBrowser = CType(activeChild.ActiveControl, Global.Gecko.GeckoWebBrowser)
            If (Not theBox2 Is Nothing) Then
                theBox2.CutSelection()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CopyToolStripMenuItem.Click
        ' Mithilfe von My.Computer.Clipboard den ausgewählten Text bzw. die ausgewählten Bilder in die Zwischenablage kopieren
        Dim activeChild As Form = Me.ActiveMdiChild
        On Error Resume Next
        If (Not activeChild Is Nothing) Then
            Dim theBox As WebBrowser = CType(activeChild.ActiveControl, WebBrowser)
            If (Not theBox Is Nothing) Then
                theBox.Document.ExecCommand("Copy", False, System.DBNull.Value)
                Exit Sub
            End If
            Dim theBox2 As Global.Gecko.GeckoWebBrowser = CType(activeChild.ActiveControl, Global.Gecko.GeckoWebBrowser)
            If (Not theBox2 Is Nothing) Then
                theBox2.CopySelection()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles PasteToolStripMenuItem.Click
        'Mithilfe von My.Computer.Clipboard.GetText() oder My.Computer.Clipboard.GetData Informationen aus der Zwischenablage abrufen
        Dim activeChild As Form = Me.ActiveMdiChild
        On Error Resume Next
        If (Not activeChild Is Nothing) Then
            Dim theBox As WebBrowser = CType(activeChild.ActiveControl, WebBrowser)
            If (Not theBox Is Nothing) Then
                theBox.Document.ExecCommand("Paste", False, System.DBNull.Value)
                Exit Sub
            End If
            Dim theBox2 As Global.Gecko.GeckoWebBrowser = CType(activeChild.ActiveControl, Global.Gecko.GeckoWebBrowser)
            If (Not theBox2 Is Nothing) Then
                theBox2.Paste()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub ToolBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolBarToolStripMenuItem.Click
        Me.ToolStrip.Visible = Me.ToolBarToolStripMenuItem.Checked
    End Sub

    Private Sub StatusBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles StatusBarToolStripMenuItem.Click
        Me.StatusStrip.Visible = Me.StatusBarToolStripMenuItem.Checked
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CascadeToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticleToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileVerticalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileHorizontalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ArrangeIconsToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CloseAllToolStripMenuItem.Click
        ' Alle untergeordneten Formulare des übergeordneten Formulars schließen.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer = 0

    Public Sub ToolStripButton1_Click(ByVal sender As System.Object,
     ByVal e As System.EventArgs) Handles ToolStripButton1.Click

        ' Determine the active child form.
        Dim activeChild As Form = Me.ActiveMdiChild

        ' If there is an active child form, find the active control, which
        ' in this example should be a RichTextBox.
        If (Not activeChild Is Nothing) Then
            Try
                Dim theBox As WebBrowser = CType(activeChild.ActiveControl, WebBrowser)
                If (Not theBox Is Nothing) Then
                    theBox.Navigate(cboAddress.Text)
                    Exit Sub
                End If
            Catch
            End Try
        End If

        If (Not activeChild Is Nothing) Then
            Try
                Dim theBox2 As Global.Gecko.GeckoWebBrowser = CType(activeChild.ActiveControl, Global.Gecko.GeckoWebBrowser)
                If (Not theBox2 Is Nothing) Then
                    theBox2.Navigate(cboAddress.Text)
                End If
            Catch
            End Try
        End If
    End Sub

    Private Sub cboAddress_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboAddress.KeyUp
        If e.KeyCode = Keys.Enter Then
            Dim activeChild As Form = Me.ActiveMdiChild

            ' If there is an active child form, find the active control, which
            ' in this example should be a RichTextBox.
            If (Not activeChild Is Nothing) Then
                Try
                    Dim theBox As WebBrowser = CType(activeChild.ActiveControl, WebBrowser)
                    If (Not theBox Is Nothing) Then
                        theBox.Navigate(cboAddress.Text)
                        Exit Sub
                    End If
                Catch
                End Try
            End If

            If (Not activeChild Is Nothing) Then
                Try
                    Dim theBox2 As Global.Gecko.GeckoWebBrowser = CType(activeChild.ActiveControl, Global.Gecko.GeckoWebBrowser)
                    If (Not theBox2 Is Nothing) Then
                        theBox2.Navigate(cboAddress.Text)
                    End If
                Catch
                End Try
            End If

        End If
    End Sub

    Public Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem.Click, PrintToolStripButton.Click
        Dim activeChild As Form = Me.ActiveMdiChild

        If (Not activeChild Is Nothing) Then
            On Error Resume Next
            Dim theBox As WebBrowser = CType(activeChild.ActiveControl, WebBrowser)
            If (Not theBox Is Nothing) Then
                theBox.ShowPrintDialog()
            End If
            Dim theBox2 As Global.Gecko.GeckoWebBrowser = CType(activeChild.ActiveControl, Global.Gecko.GeckoWebBrowser)
            If (Not theBox2 Is Nothing) Then
                theBox2.Navigate("javascript:window.print()")
            End If

        End If


    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        AboutBox.ShowDialog()
    End Sub

    Private Sub SearchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchToolStripMenuItem.Click, ToolStripButtonSearch.Click
        Dim ChildForm As New Form1
        ' Vor der Anzeige dem MDI-Formular unterordnen.
        ChildForm.MdiParent = Me
        m_ChildFormNumber += 1
        ChildForm.Text = "Fenster " & m_ChildFormNumber
        ChildForm.exBrowser.GoSearch()
        ChildForm.Show()
    End Sub

    Private Sub OptionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptionsToolStripMenuItem.Click
        Dim ChildForm As New frmOption
        ' Vor der Anzeige dem MDI-Formular unterordnen.
        ChildForm.MdiParent = Me
        ChildForm.Show()
    End Sub

    Private Sub PrintPreviewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintPreviewToolStripMenuItem.Click, PrintPreviewToolStripButton.Click
        Dim activeChild As Form = Me.ActiveMdiChild
        If (Not activeChild Is Nothing) Then
            Try
                Dim theBox As WebBrowser = CType(activeChild.ActiveControl, WebBrowser)
                If (Not theBox Is Nothing) Then
                    theBox.ShowPrintPreviewDialog()
                End If
            Catch
                MessageBox.Show("You need to select a WebBrowser.")
            End Try
        End If
    End Sub

    Private Sub PrintSetupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintSetupToolStripMenuItem.Click
        Dim activeChild As Form = Me.ActiveMdiChild
        If (Not activeChild Is Nothing) Then
            Try
                Dim theBox As WebBrowser = CType(activeChild.ActiveControl, WebBrowser)
                If (Not theBox Is Nothing) Then
                    theBox.ShowPageSetupDialog()
                End If
            Catch
                MessageBox.Show("You need to select a WebBrowser.")
            End Try
        End If
    End Sub

    Private Sub ToolStripButtonBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonBack.Click
        Dim activeChild As Form = Me.ActiveMdiChild
        If (Not activeChild Is Nothing) Then
            On Error Resume Next
            Dim theBox As WebBrowser = CType(activeChild.ActiveControl, WebBrowser)
            If (Not theBox Is Nothing) Then
                theBox.GoBack()
                Exit Sub
            End If
            Dim theBox2 As Global.Gecko.GeckoWebBrowser = CType(activeChild.ActiveControl, Global.Gecko.GeckoWebBrowser)
            If (Not theBox2 Is Nothing) Then
                theBox2.GoBack()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub ToolStripButtonForward_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonForward.Click
        Dim activeChild As Form = Me.ActiveMdiChild
        On Error Resume Next
        If (Not activeChild Is Nothing) Then
            Dim theBox As WebBrowser = CType(activeChild.ActiveControl, WebBrowser)
            If (Not theBox Is Nothing) Then
                theBox.GoForward()
                Exit Sub
            End If
            Dim theBox2 As Global.Gecko.GeckoWebBrowser = CType(activeChild.ActiveControl, Global.Gecko.GeckoWebBrowser)
            If (Not theBox2 Is Nothing) Then
                theBox2.GoForward()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub ToolStripButtonRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonRefresh.Click
        Dim activeChild As Form = Me.ActiveMdiChild
        On Error Resume Next
        If (Not activeChild Is Nothing) Then
            Dim theBox As WebBrowser = CType(activeChild.ActiveControl, WebBrowser)
            If (Not theBox Is Nothing) Then
                theBox.Refresh()
                Exit Sub
            End If
            Dim theBox2 As Global.Gecko.GeckoWebBrowser = CType(activeChild.ActiveControl, Global.Gecko.GeckoWebBrowser)
            If (Not theBox2 Is Nothing) Then
                theBox2.Reload()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub ToolStripButtonHome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonHome.Click
        Dim activeChild As Form = Me.ActiveMdiChild
        If (Not activeChild Is Nothing) Then
            Try
                Dim theBox As WebBrowser = CType(activeChild.ActiveControl, WebBrowser)
                If (Not theBox Is Nothing) Then
                    theBox.GoHome()
                    Exit Sub
                End If
            Catch
                MessageBox.Show("You need to select a WebBrowser.")
            End Try
        End If
    End Sub

    Private Sub ToolStripMenuAddress_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuAddress.Click
        Me.cboAddress.Visible = Me.ToolStripMenuAddress.Checked
    End Sub

    Private Sub ToolStripButtonStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButtonStop.Click
        Dim activeChild As Form = Me.ActiveMdiChild
        On Error Resume Next
        If (Not activeChild Is Nothing) Then
            Dim theBox As WebBrowser = CType(activeChild.ActiveControl, WebBrowser)
            If (Not theBox Is Nothing) Then
                theBox.Stop()
                Exit Sub
            End If
            Dim theBox2 As Global.Gecko.GeckoWebBrowser = CType(activeChild.ActiveControl, Global.Gecko.GeckoWebBrowser)
            If (Not theBox2 Is Nothing) Then
                theBox2.Stop()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub IPAdressenAnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IPAdressenAnToolStripMenuItem.Click
        Dim IPForm As New ShowIPAddress
        ' Vor der Anzeige dem MDI-Formular unterordnen.
        IPForm.MdiParent = Me
        IPForm.Show()
    End Sub

    Private Sub CloseAllDateiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseAllDateiToolStripMenuItem.Click
        CloseAllToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub EigenschaftenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EigenschaftenToolStripMenuItem.Click
        Dim activeChild As Form = Me.ActiveMdiChild
        On Error Resume Next
        If (Not activeChild Is Nothing) Then
            Dim theBox As WebBrowser = CType(activeChild.ActiveControl, WebBrowser)
            If (Not theBox Is Nothing) Then
                theBox.ShowPropertiesDialog()
                Exit Sub
            End If
            Dim theBox2 As Global.Gecko.GeckoWebBrowser = CType(activeChild.ActiveControl, Global.Gecko.GeckoWebBrowser)
            If (Not theBox2 Is Nothing) Then
                'theBox2.ShowPageProperties()
                Exit Sub
            End If

        End If
    End Sub

    Private Sub LinkSendenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkSendenToolStripMenuItem.Click
        Dim activeChild As Form = Me.ActiveMdiChild
        On Error Resume Next
        If (Not activeChild Is Nothing) Then

            Dim theBox As WebBrowser = CType(activeChild.ActiveControl, WebBrowser)
            If (Not theBox Is Nothing) Then
                theBox.Navigate("mailto:?subject=E-Mail schreiben an: " & theBox.DocumentTitle & "&body=Hallo, Ich habe eine tolle Seite gefunden. Schau doch mal unter " & theBox.Url.OriginalString & ".")
                Exit Sub
            End If
            Dim theBox2 As Global.Gecko.GeckoWebBrowser = CType(activeChild.ActiveControl, Global.Gecko.GeckoWebBrowser)
            If (Not theBox2 Is Nothing) Then
                theBox2.Navigate("mailto:?subject=E-Mail schreiben an: " & theBox.DocumentTitle & "&body=Hallo, Ich habe eine tolle Seite gefunden. Schau doch mal unter " & theBox.Url.OriginalString & ".")
                Exit Sub
            End If
        End If
    End Sub

    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        Dim ChildForm As Form = Me.ActiveMdiChild
        ChildForm.Close()
    End Sub

    Private Sub ShowSourceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowSourceToolStripMenuItem.Click
        Dim activeChild As Form = Me.ActiveMdiChild
        If (Not activeChild Is Nothing) Then
            Try
                Dim theBox As WebBrowser = CType(activeChild.ActiveControl, WebBrowser)
                If (Not theBox Is Nothing) Then
                    theBox.Stop()
                    'Dim sQuelltext As String = theBox.DocumentText.ToString
                    Dim sUrlString As String = theBox.Url.OriginalString
                    Dim ChildForm As New frmQuelltext
                    ' Vor der Anzeige dem MDI-Formular unterordnen.
                    ChildForm.MdiParent = Me
                    ChildForm.Text = "Quelltext von: " & theBox.DocumentTitle
                    If theBox.DocumentTitle = "" Then
                        ChildForm.Text = "Quelltext von: " & theBox.Url.OriginalString
                    End If
                    ChildForm.Show()
                    ChildForm.exBrowser.Navigate("view-source:" & sUrlString)
                End If
                Exit Sub
            Catch
            End Try

            Try
                Dim theBox As Global.Gecko.GeckoWebBrowser = CType(activeChild.ActiveControl, Global.Gecko.GeckoWebBrowser)
                If (Not theBox Is Nothing) Then
                    theBox.Stop()
                    'Dim sQuelltext As String = theBox.DocumentText.ToString
                    Dim sUrlString As String = theBox.Url.OriginalString
                    Dim ChildForm As New frmQuelltext
                    ' Vor der Anzeige dem MDI-Formular unterordnen.
                    ChildForm.MdiParent = Me
                    ChildForm.Text = "Quelltext von: " & theBox.DocumentTitle
                    If theBox.DocumentTitle = "" Then
                        ChildForm.Text = "Quelltext von: " & theBox.Url.OriginalString
                    End If
                    ChildForm.Show()
                    ChildForm.exBrowser.Navigate("view-source:" & sUrlString)
                End If
                Exit Sub
            Catch
                MessageBox.Show("You need to select a WebBrowser.")
            End Try
        End If
    End Sub

    Private Sub RSSReaderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RSSReaderToolStripMenuItem.Click
        Dim ChildForm As New FormRSS
        ChildForm.MdiParent = Me
        m_ChildFormNumber += 1
        ChildForm.Text = "Fenster " & m_ChildFormNumber
        ChildForm.Show()
    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectAllToolStripMenuItem.Click
        Dim activeChild As Form = Me.ActiveMdiChild
        On Error Resume Next
        If (Not activeChild Is Nothing) Then
            Dim theBox As WebBrowser = CType(activeChild.ActiveControl, WebBrowser)
            If (Not theBox Is Nothing) Then
                theBox.Document.Focus()
                theBox.Document.ExecCommand("SelectAll", False, System.DBNull.Value)
                theBox.Document.Focus()
                Exit Sub
            End If
            Dim theBox2 As Global.Gecko.GeckoWebBrowser = CType(activeChild.ActiveControl, Global.Gecko.GeckoWebBrowser)
            If (Not theBox2 Is Nothing) Then
                theBox2.SelectAll()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub CookiesAnsehenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CookiesAnsehenToolStripMenuItem.Click
        ' Neue Instanz des untergeordneten Formulars erstellen.
        Dim ChildForm As New frmCookieViewer
        ' Vor der Anzeige dem MDI-Formular unterordnen.
        ChildForm.MdiParent = Me
        ChildForm.Show()
    End Sub

    Private Sub WHOISSucheToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WHOISSucheToolStripMenuItem.Click
        ' Neue Instanz des untergeordneten Formulars erstellen.
        Dim ChildForm As New FormWhois
        ' Vor der Anzeige dem MDI-Formular unterordnen.
        ChildForm.MdiParent = Me
        ChildForm.Show()
    End Sub

    Private Sub UserAgentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserAgentToolStripMenuItem.Click
        Dim activeChild As Form = Me.ActiveMdiChild
        On Error Resume Next
        If (Not activeChild Is Nothing) Then
            Dim OrgString As String
            Dim theBox As WebBrowser = CType(activeChild.ActiveControl, WebBrowser)
            If (Not theBox Is Nothing) Then
                OrgString = Me.cboAddress.Text
                theBox.Navigate("javascript:alert('User-Agent: ' + navigator.userAgent)")
                Me.cboAddress.Text = OrgString
                Exit Sub
            End If
            Dim theBox2 As Global.Gecko.GeckoWebBrowser = CType(activeChild.ActiveControl, Global.Gecko.GeckoWebBrowser)
            If (Not theBox2 Is Nothing) Then
                OrgString = Me.cboAddress.Text
                theBox2.Navigate("javascript:alert('User-Agent: ' + navigator.userAgent)")
                Me.cboAddress.Text = OrgString
                Exit Sub
            End If
        End If
    End Sub

    Private Sub MediaPlayerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MediaPlayerToolStripMenuItem.Click
        Dim ChildForm As New frmMedia
        ' Vor der Anzeige dem MDI-Formular unterordnen.
        ChildForm.MdiParent = Me
        ChildForm.Show()
    End Sub

    Private Sub ShowChangesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowChangesToolStripMenuItem.Click
        Dim activeChild As Form = Me.ActiveMdiChild
        On Error Resume Next
        If (Not activeChild Is Nothing) Then
            Dim OrgString As String
            Dim theBox As WebBrowser = CType(activeChild.ActiveControl, WebBrowser)
            If (Not theBox Is Nothing) Then
                OrgString = Me.cboAddress.Text
                theBox.Navigate("javascript:alert('Diese Seite wurde zuletzt am ' + document.lastModified + ' aktualisiert.')")
                Me.cboAddress.Text = OrgString
                Exit Sub
            End If
            Dim theBox2 As Global.Gecko.GeckoWebBrowser = CType(activeChild.ActiveControl, Global.Gecko.GeckoWebBrowser)
            If (Not theBox2 Is Nothing) Then
                OrgString = Me.cboAddress.Text
                theBox2.Navigate("javascript:alert('Diese Seite wurde zuletzt am ' + document.lastModified + ' aktualisiert.')")
                Me.cboAddress.Text = OrgString
                Exit Sub
            End If

        End If
    End Sub

    Private Sub CookiesAnzeigenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CookiesAnzeigenToolStripMenuItem.Click
        Dim activeChild As Form = Me.ActiveMdiChild
        On Error Resume Next
        If (Not activeChild Is Nothing) Then
            Dim OrgString As String
            Dim theBox As WebBrowser = CType(activeChild.ActiveControl, WebBrowser)
            If (Not theBox Is Nothing) Then
                OrgString = Me.cboAddress.Text
                theBox.Navigate("javascript:alert('Cookie: ' + document.cookie)")
                Me.cboAddress.Text = OrgString
                Exit Sub
            End If
            Dim theBox2 As Global.Gecko.GeckoWebBrowser = CType(activeChild.ActiveControl, Global.Gecko.GeckoWebBrowser)
            If (Not theBox2 Is Nothing) Then
                OrgString = Me.cboAddress.Text
                theBox2.Navigate("javascript:alert('Cookie: ' + document.cookie)")
                Me.cboAddress.Text = OrgString
                Exit Sub
            End If
        End If
    End Sub

    Private Sub ServerAnpingenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ServerAnpingenToolStripMenuItem.Click
        Dim domain As String
        Dim oPing As clsVBnetPing = New clsVBnetPing

        domain = InputBox("Geben Sie eine Internetadresse (ohne http://) ein", My.Application.Info.Title)
        If domain = "" Then Exit Sub

        ' Als erstes muss die Funktion Ping aufgerufen werden
        If oPing.Ping(domain) = True Then
            ' Ping erfolgreich
        Else
            ' Ping fehlgeschlagen
        End If

        ' Jetzt können die Rückgabe-Werte der Funktion ausgelesen werden
        MessageBox.Show("IP-Adresse: " & oPing.IpAddress & vbCrLf &
          "Host: " & oPing.HostName & vbCrLf &
          "Erfolgreich: " & oPing.Success & vbCrLf &
          "Millisek.: " & oPing.ResponseTime & vbCrLf &
          "Fehlermeldung: " & oPing.ErrorDesc)
        oPing = Nothing
    End Sub

    Private Sub VerbindungenVerfolgenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerbindungenVerfolgenToolStripMenuItem.Click
        Dim MyFiles = CreateObject("Scripting.FileSystemObject")
        Dim domain As String
        Dim tracertbat As Object

        domain = InputBox("Geben Sie eine Internetadresse (ohne http://) ein", "Verbindungen verfolgen")
        If domain = "" Then Exit Sub
        tracertbat = MyFiles.OpenTextFile(GetTempDir2() & "\tracert.bat", 2, True)
        tracertbat.Writeline("@echo off")
        tracertbat.Writeline("echo " & My.Application.Info.Title & " " & String.Format("Version {0}", My.Application.Info.Version.ToString))
        tracertbat.Writeline("echo Copyright 2005 - 2024 Home of the Sebijk.com.")
        tracertbat.Writeline("echo http://www.sebijk.com")
        tracertbat.Writeline("echo.")
        tracertbat.Writeline("tracert " & domain)
        tracertbat.Writeline("echo.")
        tracertbat.Writeline("pause")
        tracertbat.Close()
        Shell(GetTempDir2() & "\tracert.bat")
    End Sub

    Private Sub UndoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UndoToolStripMenuItem.Click
        Dim activeChild As Form = Me.ActiveMdiChild
        On Error Resume Next
        If (Not activeChild Is Nothing) Then
            Dim OrgString As String
            Dim theBox2 As Global.Gecko.GeckoWebBrowser = CType(activeChild.ActiveControl, Global.Gecko.GeckoWebBrowser)
            If (Not theBox2 Is Nothing) Then
                CType(activeChild.ActiveControl, Global.Gecko.GeckoWebBrowser).Undo()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub RedoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RedoToolStripMenuItem.Click
        Dim activeChild As Form = Me.ActiveMdiChild
        On Error Resume Next
        If (Not activeChild Is Nothing) Then
            Dim OrgString As String
            Dim theBox2 As Global.Gecko.GeckoWebBrowser = CType(activeChild.ActiveControl, Global.Gecko.GeckoWebBrowser)
            If (Not theBox2 Is Nothing) Then
                CType(activeChild.ActiveControl, Global.Gecko.GeckoWebBrowser).Redo()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub InfoAboutWindowsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InfoAboutWindowsToolStripMenuItem.Click
        Call ShellAbout(Me.Handle.ToInt32, Me.Text, "", 1)
    End Sub

    Private Sub fileDownloadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles fileDownloadToolStripMenuItem.Click
        Dim DownloadForm As New frmDownload
        ' Vor der Anzeige dem MDI-Formular unterordnen.
        DownloadForm.MdiParent = Me
        DownloadForm.Show()
    End Sub

    Private Sub EMailToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EMailToolStripMenuItem.Click
        Dim ChildForm As New Form1
        ' Vor der Anzeige dem MDI-Formular unterordnen.
        ChildForm.MdiParent = Me
        ChildForm.exBrowser.Navigate("mailto:")
    End Sub
End Class