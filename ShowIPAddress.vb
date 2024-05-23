Imports System.Net
Public Class ShowIPAddress

    Private Sub Button1_Click(ByVal sender As System.Object, _
   ByVal e As System.EventArgs) Handles Button1.Click

        Dim Addresslist() As IPAddress = _
          Dns.GetHostEntry(Dns.GetHostName()).AddressList
        Dim IPs As IPAddress

        ' alle IP-Adressen auflisten
        ListBox1.Items.Clear()
        For Each IPs In Addresslist
            ListBox1.Items.Add(IPs.ToString)
        Next IPs
    End Sub
End Class