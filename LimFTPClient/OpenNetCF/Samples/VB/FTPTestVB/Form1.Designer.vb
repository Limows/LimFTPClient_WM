<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    private mainMenu1 As System.Windows.Forms.MainMenu

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.mainMenu1 = New System.Windows.Forms.MainMenu
        Me.statusTab = New System.Windows.Forms.TabPage
        Me.status = New System.Windows.Forms.ListView
        Me.columnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.columnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.MainMenu2 = New System.Windows.Forms.MainMenu
        Me.connect = New System.Windows.Forms.MenuItem
        Me.menuItem1 = New System.Windows.Forms.MenuItem
        Me.getFileList = New System.Windows.Forms.MenuItem
        Me.upload = New System.Windows.Forms.MenuItem
        Me.tabs = New System.Windows.Forms.TabControl
        Me.fileTab = New System.Windows.Forms.TabPage
        Me.fileList = New System.Windows.Forms.ListView
        Me.columnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.columnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.label3 = New System.Windows.Forms.Label
        Me.panel1 = New System.Windows.Forms.Panel
        Me.password = New System.Windows.Forms.TextBox
        Me.label2 = New System.Windows.Forms.Label
        Me.user = New System.Windows.Forms.TextBox
        Me.label1 = New System.Windows.Forms.Label
        Me.server = New System.Windows.Forms.TextBox
        Me.statusTab.SuspendLayout()
        Me.tabs.SuspendLayout()
        Me.fileTab.SuspendLayout()
        Me.panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'statusTab
        '
        Me.statusTab.Controls.Add(Me.status)
        Me.statusTab.Location = New System.Drawing.Point(0, 0)
        Me.statusTab.Name = "statusTab"
        Me.statusTab.Size = New System.Drawing.Size(234, 158)
        Me.statusTab.Text = "Status"
        '
        'status
        '
        Me.status.Columns.Add(Me.columnHeader1)
        Me.status.Columns.Add(Me.columnHeader2)
        Me.status.Dock = System.Windows.Forms.DockStyle.Fill
        Me.status.Location = New System.Drawing.Point(0, 0)
        Me.status.Name = "status"
        Me.status.Size = New System.Drawing.Size(234, 158)
        Me.status.TabIndex = 0
        Me.status.View = System.Windows.Forms.View.Details
        '
        'columnHeader1
        '
        Me.columnHeader1.Text = "Time"
        Me.columnHeader1.Width = 80
        '
        'columnHeader2
        '
        Me.columnHeader2.Text = "Response"
        Me.columnHeader2.Width = 160
        '
        'MainMenu2
        '
        Me.MainMenu2.MenuItems.Add(Me.connect)
        Me.MainMenu2.MenuItems.Add(Me.menuItem1)
        '
        'connect
        '
        Me.connect.Text = "Connect"
        '
        'menuItem1
        '
        Me.menuItem1.MenuItems.Add(Me.getFileList)
        Me.menuItem1.MenuItems.Add(Me.upload)
        Me.menuItem1.Text = "Commands"
        '
        'getFileList
        '
        Me.getFileList.Text = "Get File List"
        '
        'upload
        '
        Me.upload.Text = "Upload File"
        '
        'tabs
        '
        Me.tabs.Controls.Add(Me.statusTab)
        Me.tabs.Controls.Add(Me.fileTab)
        Me.tabs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabs.Location = New System.Drawing.Point(0, 0)
        Me.tabs.Name = "tabs"
        Me.tabs.SelectedIndex = 0
        Me.tabs.Size = New System.Drawing.Size(234, 181)
        Me.tabs.TabIndex = 0
        '
        'fileTab
        '
        Me.fileTab.Controls.Add(Me.fileList)
        Me.fileTab.Location = New System.Drawing.Point(0, 0)
        Me.fileTab.Name = "fileTab"
        Me.fileTab.Size = New System.Drawing.Size(226, 155)
        Me.fileTab.Text = "File List"
        '
        'fileList
        '
        Me.fileList.Columns.Add(Me.columnHeader3)
        Me.fileList.Columns.Add(Me.columnHeader4)
        Me.fileList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.fileList.Location = New System.Drawing.Point(0, 0)
        Me.fileList.Name = "fileList"
        Me.fileList.Size = New System.Drawing.Size(226, 155)
        Me.fileList.TabIndex = 1
        Me.fileList.View = System.Windows.Forms.View.Details
        '
        'columnHeader3
        '
        Me.columnHeader3.Text = "File Name"
        Me.columnHeader3.Width = 80
        '
        'columnHeader4
        '
        Me.columnHeader4.Text = "Size"
        Me.columnHeader4.Width = 160
        '
        'label3
        '
        Me.label3.Location = New System.Drawing.Point(11, 58)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(46, 20)
        Me.label3.Text = "pwd"
        '
        'panel1
        '
        Me.panel1.Controls.Add(Me.tabs)
        Me.panel1.Location = New System.Drawing.Point(3, 84)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(234, 181)
        '
        'password
        '
        Me.password.Location = New System.Drawing.Point(63, 57)
        Me.password.Name = "password"
        Me.password.Size = New System.Drawing.Size(174, 21)
        Me.password.TabIndex = 14
        Me.password.Text = "skyh00k"
        '
        'label2
        '
        Me.label2.Location = New System.Drawing.Point(11, 31)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(46, 20)
        Me.label2.Text = "user"
        '
        'user
        '
        Me.user.Location = New System.Drawing.Point(63, 30)
        Me.user.Name = "user"
        Me.user.Size = New System.Drawing.Size(174, 21)
        Me.user.TabIndex = 13
        Me.user.Text = "skyhook"
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(11, 4)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(46, 20)
        Me.label1.Text = "ftp://"
        '
        'server
        '
        Me.server.Location = New System.Drawing.Point(63, 3)
        Me.server.Name = "server"
        Me.server.Size = New System.Drawing.Size(174, 21)
        Me.server.TabIndex = 11
        Me.server.Text = "www.opennetcf.com"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(240, 268)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.panel1)
        Me.Controls.Add(Me.password)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.user)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.server)
        Me.Menu = Me.mainMenu1
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.statusTab.ResumeLayout(False)
        Me.tabs.ResumeLayout(False)
        Me.fileTab.ResumeLayout(False)
        Me.panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents statusTab As System.Windows.Forms.TabPage
    Private WithEvents status As System.Windows.Forms.ListView
    Private WithEvents columnHeader1 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader2 As System.Windows.Forms.ColumnHeader
    Private WithEvents MainMenu2 As System.Windows.Forms.MainMenu
    Private WithEvents connect As System.Windows.Forms.MenuItem
    Private WithEvents menuItem1 As System.Windows.Forms.MenuItem
    Private WithEvents getFileList As System.Windows.Forms.MenuItem
    Private WithEvents upload As System.Windows.Forms.MenuItem
    Private WithEvents tabs As System.Windows.Forms.TabControl
    Private WithEvents fileTab As System.Windows.Forms.TabPage
    Private WithEvents fileList As System.Windows.Forms.ListView
    Private WithEvents columnHeader3 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader4 As System.Windows.Forms.ColumnHeader
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents password As System.Windows.Forms.TextBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents user As System.Windows.Forms.TextBox
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents server As System.Windows.Forms.TextBox

End Class
