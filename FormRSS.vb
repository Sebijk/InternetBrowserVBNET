
Imports System.Collections.Generic
Imports System.Linq
Imports System.ServiceModel.Syndication
Imports System.Xml

Public Class FormRSS

    Public Sub New()

        InitializeComponent()

        Dim rssfile As String
        rssfile = InputBox("Bitte geben Sie die URL zu dem gewünschten RSS-Feed an:", "RSS-Reader", "")
        If rssfile = "" Then
            Me.Close()
            Exit Sub
        End If

        urlLbl.Text = rssfile


        Dim rdr As New ConsoleApplication1.RSSReader
        rdr.GetRSSFeeds(rssfile, Me.cb1)

    End Sub

    Private Sub cb1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb1.SelectedIndexChanged
        rtb1.Text = cb1.SelectedItem.ToString
    End Sub
End Class

Public Class RSS
    Public Property Id() As String
        Get
            Return m_Id
        End Get
        Set
            m_Id = Value
        End Set
    End Property
    Private m_Id As String
    Public Property QuestionID() As String
        Get
            Return m_QuestionID
        End Get
        Set
            m_QuestionID = Value
        End Set
    End Property
    Private m_QuestionID As String
    Public Property QuestionTitle() As String
        Get
            Return m_QuestionTitle
        End Get
        Set
            m_QuestionTitle = Value
        End Set
    End Property
    Private m_QuestionTitle As String
    Public Property QuestionDescription() As String
        Get
            Return m_QuestionDescription
        End Get
        Set
            m_QuestionDescription = Value
        End Set
    End Property
    Private m_QuestionDescription As String
    Public Property PublishDate() As DateTime
        Get
            Return m_PublishDate
        End Get
        Set
            m_PublishDate = Value
        End Set
    End Property
    Private m_PublishDate As DateTime
End Class

Namespace ConsoleApplication1

    Public Class RSSReader
        Public Sub GetRSSFeeds(ByVal myurl As String, ByVal cb As ComboBox)
            Dim url As String = myurl
            Dim feed As SyndicationFeed = Nothing

            Using reader = XmlReader.Create(url)
                feed = SyndicationFeed.Load(reader)
                Dim syndicationItems = feed.Items.ToArray()

                For i As Integer = 0 To syndicationItems.Length - 1
                    Try
                        Dim sdfa = syndicationItems(i).PublishDate.[Date] & " " & syndicationItems(i).Title.Text
                        cb.Items.Add(sdfa)
                    Catch ex As Exception
                        Console.WriteLine(ex.Message)
                    End Try
                Next
            End Using
        End Sub
    End Class

End Namespace

