<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmQuelltext
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmQuelltext))
        Me.exBrowser = New Gecko.GeckoWebBrowser()
        Me.SuspendLayout()
        '
        'exBrowser
        '
        Me.exBrowser.ConsoleMessageEventReceivesConsoleLogCalls = True
        Me.exBrowser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.exBrowser.FrameEventsPropagateToMainWindow = False
        Me.exBrowser.Location = New System.Drawing.Point(0, 0)
        Me.exBrowser.Name = "exBrowser"
        Me.exBrowser.Size = New System.Drawing.Size(292, 268)
        Me.exBrowser.TabIndex = 5
        Me.exBrowser.UseHttpActivityObserver = False
        '
        'frmQuelltext
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 268)
        Me.Controls.Add(Me.exBrowser)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmQuelltext"
        Me.Text = "Quelltext zeigen"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents exBrowser As Global.Gecko.GeckoWebBrowser
End Class
