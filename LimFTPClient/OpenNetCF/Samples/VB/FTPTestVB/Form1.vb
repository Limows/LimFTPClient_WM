Imports OpenNETCF.Net.Ftp
Imports System.IO

Delegate Sub StringDelegate(ByVal value As String)

Public Class Form1
    Private WithEvents m_ftp As FTP

    Private Sub connect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles connect.Click
        OnResponse("Connecting")

        m_ftp = New FTP(server.Text)
        m_ftp.BeginConnect(user.Text, password.Text)
    End Sub

    Private Sub m_ftp_Connected(ByVal source As FTP) Handles m_ftp.Connected
        ' when this happens we're ready to send command
        OnResponse("Connected.")
    End Sub

    Private Sub m_ftp_ResponseReceived(ByVal source As FTP, ByVal Response As FTPResponse) Handles m_ftp.ResponseReceived
        OnResponse(Response.Text)
    End Sub

    Private Sub OnResponse(ByVal response As String)
        If (Me.InvokeRequired) Then

            Me.Invoke(New StringDelegate(AddressOf OnResponse), New Object() {response})
            Return
        End If

        Dim item As ListViewItem = New ListViewItem(New String() {DateTime.Now.ToShortTimeString(), response})
        status.Items.Insert(0, item)
        status.Columns(1).Width = -1
    End Sub

    Private Sub getFileList_Click(ByVal sender As Object, ByVal e As EventArgs) Handles getFileList.Click
        Dim files As FTPFiles = m_ftp.EnumFiles()

        fileList.Items.Clear()

        For Each file As FTPFile In files
            fileList.Items.Add(New ListViewItem(New String() {file.Name, file.Size.ToString()}))
        Next

        tabs.SelectedIndex = 1
    End Sub

    Private Sub upload_Click(ByVal sender As Object, ByVal e As EventArgs) Handles upload.Click
        Dim stream As FileStream = File.OpenRead("\\My Documents\\My Pictures\\Waterfall.jpg")
        m_ftp.SendFile(stream, "waterfall.jpg")
        stream.Close()
    End Sub
End Class
