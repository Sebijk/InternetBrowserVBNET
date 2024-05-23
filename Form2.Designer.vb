<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form2))
        Me.exBrowser = New Global.Gecko.GeckoWebBrowser()
        Me.SuspendLayout()
        '
        'exBrowser
        '
        Me.exBrowser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.exBrowser.Location = New System.Drawing.Point(0, 0)
        Me.exBrowser.Name = "exBrowser"
        Me.exBrowser.Size = New System.Drawing.Size(617, 401)
        Me.exBrowser.TabIndex = 0
        Me.exBrowser.UseHttpActivityObserver = False
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(617, 401)
        Me.Controls.Add(Me.exBrowser)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form2"
        Me.Text = "Browser"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents exBrowser As Global.Gecko.GeckoWebBrowser

End Class
