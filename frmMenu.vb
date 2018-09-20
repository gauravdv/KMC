Imports PC2M.PC2M
Public Class frmMenu

    Private Sub btnSendFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSendFile.Click
        Dim strSendFileName As String

        OpenFileDialog1.ShowDialog()

        strSendFileName = OpenFileDialog1.FileName

        If strSendFileName.Length > 1 Then
            Try
                Dim tSendFile As New PC2M
                Call tSendFile.UploadData(strSendFileName, CMBPORTNO.Text)

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
    Private Sub frmMenu_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False
        For Each sp As String In My.Computer.Ports.SerialPortNames
            CMBPORTNO.Items.Add(sp)
        Next
    End Sub
    Private Sub btnDownLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDownLoad.Click
        Dim strRecFile As String
        Dim objReader As System.IO.StreamReader
        Dim tStr As String
        If Not IO.Directory.Exists(My.Application.Info.DirectoryPath & "\download") Then IO.Directory.CreateDirectory(My.Application.Info.DirectoryPath & "\download")
        strRecFile = System.String.Concat(My.Application.Info.DirectoryPath, "\download\outputdata" & Format(Now, "dd_MM_yyyy_hh_mm") & ".txt")
        If strRecFile.Length > 1 Then
            Try
                Dim tGetFile As New PC2M
                tGetFile.DownLoad(strRecFile, "D", CMBPORTNO.Text)
                If IO.File.Exists(System.String.Concat(My.Application.Info.DirectoryPath, "\download\outputdata" & Format(Now, "dd_MM_yyyy_hh_mm") & ".txt")) Then
                    If IO.File.Exists(System.String.Concat(My.Application.Info.DirectoryPath, "\download\outputdata" & Format(Now, "dd_MM_yyyy_hh_mm") & ".csv")) Then
                        IO.File.Delete(System.String.Concat(My.Application.Info.DirectoryPath, "\download\outputdata" & Format(Now, "dd_MM_yyyy_hh_mm") & ".csv"))
                    End If
                    objReader = New System.IO.StreamReader(strRecFile)
                    tStr = Replace(objReader.ReadToEnd, "@", "")
                    objReader.Close()
                    IO.File.AppendAllText(System.String.Concat(My.Application.Info.DirectoryPath, "\download\outputdata" & Format(Now, "dd_MM_yyyy_hh_mm") & ".csv"), tStr)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
    Private Sub BtnErase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnErase.Click
        Dim strSendFileName As String
        strSendFileName = System.String.Concat(My.Application.Info.DirectoryPath, "\Erase.txt")
        If strSendFileName.Length > 1 Then
            Try
                Dim tSendFile As New PC2M
                tSendFile.UploadData(strSendFileName, CMBPORTNO.Text)

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub


End Class
