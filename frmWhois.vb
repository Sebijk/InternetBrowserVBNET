Imports System
Imports Whois
Public Class FormWhois

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim wlookup As New WhoisLookup()
        Dim wresponse
        Try
            wresponse = wlookup.Lookup(TextBoxWhois.Text)
            RichTextBox1.Text = wresponse.Content
        Catch ex As Exception
            RichTextBox1.Text = "Fehler: {0}"
        End Try
    End Sub

End Class