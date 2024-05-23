Option Strict On
Imports Gecko
Imports System.IO
Namespace My
    Partial Friend Class MyApplication
        Protected Overrides Function OnStartup(ByVal eventArgs As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) As Boolean
            'Pfad für temporäre Dateien festlegen (kann geändert werden natürlich)
            Dim ProfileDirectory As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "sjbrowsergecko", "DefaultProfile")
            Dim di As DirectoryInfo = New DirectoryInfo(ProfileDirectory)
            If Not di.Exists Then
                Directory.CreateDirectory(ProfileDirectory)
            End If
            'Profilordner für Gecko auf den oben festgelegten stellen
            Xpcom.ProfileDirectory = ProfileDirectory
            'Pfad des Ortes, an dem der xulrunner Ordner liegt, festlegen
            Dim xrPath As String = System.Reflection.Assembly.GetExecutingAssembly.Location
            xrPath = Path.Combine(xrPath.Substring(0, xrPath.LastIndexOf("") + 1), "Firefox")
            'Pfad laden für Gecko
            Global.Gecko.Xpcom.Initialize(My.Application.Info.DirectoryPath & "\Firefox")
            Global.Gecko.GeckoPreferences.User("browser.xul.error_pages.enabled") = True
            Return True
        End Function
    End Class
End Namespace