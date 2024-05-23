Imports System
Imports System.Net
Imports System.Net.Sockets
Public Class clsVBnetPing
    Dim mIpAddr As String
    Dim mResponseTime As Long
    Dim mError As String
    Dim mHostName As String
    Dim mSuccess As Boolean

    ''' <summary>
    ''' Liefert die Rückmeldezeit in Millisekunden zurück
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ResponseTime() As Integer
        Get
            ResponseTime = mResponseTime
        End Get
    End Property

    ''' <summary>
    ''' Liefert die Fehlermeldung zurück (ist leer bei erfolreichem Ping)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property ErrorDesc() As String
        Get
            ErrorDesc = mError
        End Get
    End Property

    ''' <summary>
    ''' Liefert True zurück wenn Ping erfolgreich war (sonst False)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Success() As Boolean
        Get
            Success = mSuccess
        End Get
    End Property

    ''' <summary>
    ''' Liefert die IP-Adresse des Hosts zurück
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property IpAddress() As String
        Get
            If mIpAddr IsNot Nothing Then
                IpAddress = mIpAddr.ToString()
            Else
                IpAddress = ""
            End If
        End Get
    End Property

    ''' <summary>
    ''' Liefert den Hostnamen zurück
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property HostName() As String
        Get
            HostName = mHostName
        End Get
    End Property

    ''' <summary>
    ''' Versucht den Hostnamen aufzulösen (Führt kein Ping durch.)
    ''' </summary>
    ''' <param name="HName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CheckByName(ByVal HName As String) As Boolean
        mError = ""
        Try
            mIpAddr = Dns.GetHostEntry(HName).AddressList(0).ToString
            mHostName = Dns.GetHostEntry(HName.ToString).HostName
            If mHostName.Length = 0 Then mHostName = HName
            Return True
        Catch ex As System.Net.Sockets.SocketException
            mError = ex.Message
            If mHostName.Length = 0 Then mHostName = HName
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Versucht die IP-Adresse aufzulösen (Führt kein Ping durch.)
    ''' </summary>
    ''' <param name="ipAddr"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CheckByIpAddr(ByVal ipAddr As String) As Boolean
        mError = ""
        Try
            mIpAddr = System.Net.IPAddress.Parse(ipAddr).ToString
            Try
                mHostName = Dns.GetHostEntry(mIpAddr.ToString).HostName
                If mHostName.Equals(mIpAddr) Then mHostName = ""
                Return True
            Catch SEx As SocketException
                mError = SEx.Message
                Return False
            End Try
        Catch Ex As Exception
            mError = Ex.Message
            Return False
        End Try
        Return False
    End Function

    ''' <summary>
    ''' Diese Funktion prüft ob der übergebene String eine 
    ''' (gültige) IP-Adresse ist
    ''' </summary>
    ''' <param name="sHostNameOrAddress">IP oder Hostname</param>
    ''' <returns>Liefert False zurück wenn die IP ungültig ist 
    ''' bzw. ein Hostname übergeben wurde</returns>
    ''' <remarks></remarks>
    Public Function IsValidIP(ByVal sHostNameOrAddress As String) As Boolean
        Return System.Net.IPAddress.TryParse(sHostNameOrAddress, _
          System.Net.IPAddress.Any)
    End Function

    ''' <summary>
    ''' Sendet ein Ping-Signal an die angegebene IP-Adresse oder den Hostnamen.
    ''' Über "Success" erhalten sie die Fehlermledung fals beim Pingen ein 
    ''' Fehler aufgetreten ist
    ''' </summary>
    ''' <param name="sHostNameOrAddress">String. Der URL, der Computername oder 
    ''' die IP-Adressse des Servers an den ein Ping-Signal gesendet werden soll.</param>
    ''' <param name="timeout">Zeitgrenzwert (in Millisekunden) für das Herstellen 
    ''' einer Verbindung mit dem Ziel</param>
    ''' <param name="ResolveIPAndHostname">Wenn True, wird die IP-Adresse zu dem 
    ''' übergebenen Hostnamen (und umgekehrt) ermittelt.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Ping(ByVal sHostNameOrAddress As String, _
      Optional ByVal timeout As Integer = 5000, _
      Optional ByVal ResolveIPAndHostname As Boolean = True) As Boolean

        Dim bIsIP As Boolean = System.Net.IPAddress.TryParse( _
          sHostNameOrAddress, System.Net.IPAddress.Any)
        Dim oPing = New System.Net.NetworkInformation.Ping
        Dim PingReturn As System.Net.NetworkInformation.PingReply

        mError = ""
        mHostName = ""
        mIpAddr = ""
        mResponseTime = 0

        Try
            PingReturn = oPing.Send(sHostNameOrAddress, timeout)
            ' Feststellen ob Ping erfolgreich war
            If PingReturn.Status = NetworkInformation.IPStatus.Success Then
                ' IP und Hostname ermitteln (jenachdem od übergebener String 
                ' eine IP oder Host war)
                If ResolveIPAndHostname = True Then
                    If bIsIP = False Then
                        mIpAddr = PingReturn.Address().ToString
                        mHostName = sHostNameOrAddress
                    Else
                        mIpAddr = sHostNameOrAddress
                        mHostName = Dns.GetHostEntry(mIpAddr).HostName
                    End If
                End If

                mResponseTime = PingReturn.RoundtripTime
                mSuccess = True
                Return True
            Else
                ' Prüfen ob der String von sHostNameOrAddress eine IP oder 
                ' ein Hostname war
                If bIsIP Then
                    mIpAddr = sHostNameOrAddress
                Else
                    mHostName = sHostNameOrAddress
                End If
                mError = "Ping failed. IPStatus: " & PingReturn.Status.ToString
                mSuccess = False
                Return False
            End If

        Catch ex As System.Net.NetworkInformation.PingException
            If bIsIP Then
                mIpAddr = sHostNameOrAddress
            Else
                mHostName = sHostNameOrAddress
            End If
            mError = ex.InnerException.Message
            mSuccess = False
            Return False
        End Try
    End Function
End Class
