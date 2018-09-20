Public Class frmMenu
    Dim strdata As String
    Dim NoofRecords As Long
    Dim strSysdateTime As String
    Dim tFileName As String
    Dim objReader As System.IO.StreamReader
    Dim tStr As String
    Dim tLenCntr As Int64
    Dim tAckChr As String
    Dim tDataCntr As Int64
    Dim tDwnData As String
    Dim tRecCntr As Int64
    Public Declare Sub Sleep Lib "kernel32.dll" (ByVal dwMilliseconds As Long)

    Private Sub btnSendFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSendFile.Click
        Dim strSendFileName As String
        Dim tChar As String
        OpenFileDialog1.ShowDialog()
        strSendFileName = OpenFileDialog1.FileName
        If strSendFileName.Length > 1 Then
            Try
                tLenCntr = 1
                tDataCntr = 1
                'Call ReadIni()
                tRecCntr = 1
                txtProcStat.Text = ""
                With IoPort
                    If .IsOpen Then .Close()
                    .PortName = CMBPORTNO.Text
                    .Handshake = IO.Ports.Handshake.None
                    .RtsEnable = True
                    .WriteBufferSize = 512
                    .BaudRate = 115200
                    .Parity = IO.Ports.Parity.None
                    .ParityReplace = 8
                    .StopBits = 1
                    If System.IO.File.Exists(strSendFileName) = True Then
                        tStr = ""
                        objReader = New System.IO.StreamReader(strSendFileName, System.Text.UnicodeEncoding.UTF8)
                        txtProcStat.Text = "Please Wait !!! Process Text file..."
                        tStr = objReader.ReadToEnd
                        'Do While objReader.Peek() <> -1
                        '    tChar = Chr(objReader.Read)

                        '    tStr = tStr & tChar
                        '    If tChar = "@" Then tLenCntr = tLenCntr + 1
                        '    Application.DoEvents()
                        'Loop
                        objReader.Close()
                        txtProcStat.Text = "Text File Process Completed... Starting Data Send to HHD..."
                        MsgBox("Make a HHD On!!!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "PC2M")


                        '  If Asc(Mid(tStr, 1, 1)) = 239 Then
                        'tStr = Mid(tStr, 6, Len(tStr))
                        'End If
                        tLenCntr = 1
                        tAckChr = Mid(tStr, 2, 1)
                        tStr = Mid(tStr, 3, Len(tStr))
                        .Open()
                        .Write("$")
                    Else
                        MsgBox("File Does Not Exist")
                    End If
                End With
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

    Private Sub IoPort_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles IoPort.DataReceived
        Dim encodedString() As Byte
        Dim tBuffer As String
        Dim tFname As String
        Dim tCntr As Int64
        Dim tLCntr As Int64
        Dim tUCntr As Int64
        Dim tSendString As String

        Try
            With IoPort
                tBuffer = Chr(.ReadChar)
                TextBox2.Text = TextBox2.Text & "Receive String : " & tBuffer
                If tBuffer.StartsWith("$") Then
                    'TextBox1.Text = tBuffer
                    If Len(tAckChr) <> 0 Then
                        .Write(tAckChr)
                        TextBox2.Text = TextBox2.Text & "Sending String : " & tAckChr & vbCrLf
                        tAckChr = ""
                    End If
                ElseIf tBuffer.StartsWith("O") Then
                    'TextBox1.Text = tBuffer
                    If tDataCntr >= Len(tStr) Then
                        .Write(Chr(4))
                        Sleep(300)
                        .Close()
                        'System.IO.File.AppendAllText(My.Application.Info.DirectoryPath & "\Send.txt", TextBox2.Text)
                        MsgBox("Process Completed Successfully!!!", MsgBoxStyle.OkOnly)
                        txtProcStat.Text = ""
                    Else
                        tSendString = ""
                        For tCntr = tDataCntr To Len(tStr)
                            tSendString = tSendString & Mid(tStr, tCntr, 1)
                            If Mid(tStr, tCntr, 1) = "@" Then
                                Exit For
                            End If
                        Next tCntr
                        tDataCntr = tCntr + 1

                        tSendString = tSendString.Replace(vbCrLf, "")
                        tSendString = tSendString.Replace(vbCr, "")

                        TextBox2.Text = tSendString
                        encodedString = encode(tSendString)
                        .Write(encodedString, 0, encodedString.Length)
                        TextBox2.Text = "Send String :" & encodedString.ToString
                        Call ProStat()
                        tLenCntr = tLenCntr + 1
                        tRecCntr = tRecCntr + 1
                        If tSendString = Chr(4) Then
                            Sleep(300)
                            .Close()
                            MsgBox("Process Completed Successfully!!!", MsgBoxStyle.OkOnly)
                            txtProcStat.Text = ""
                        End If
                    End If
                End If

            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly)
            txtProcStat.Text = ""
            If IoPort.IsOpen Then IoPort.Close()
        End Try
    End Sub
    Private Sub ProStat()
        txtProcStat.Text = "Please Wait..... Loading Record No.: " & tRecCntr
    End Sub
    Private Sub btnDownLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDownLoad.Click
        frmDownload.ShowDialog()
    End Sub
    Private Sub BtnErase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnErase.Click
        Dim strSendFileName As String
        strSendFileName = System.String.Concat(My.Application.Info.DirectoryPath, "\Erase.txt")
        If strSendFileName.Length > 1 Then
            Try
                tRecCntr = 1
                tLenCntr = 1
                tDataCntr = 1
                With IoPort
                    If .IsOpen Then .Close()
                    .PortName = CMBPORTNO.Text
                    .Handshake = IO.Ports.Handshake.None
                    .RtsEnable = True
                    .WriteBufferSize = 512
                    .BaudRate = 115200
                    .Parity = IO.Ports.Parity.None
                    .ParityReplace = 8
                    .StopBits = 1
                    If System.IO.File.Exists(strSendFileName) = True Then
                        tStr = ""
                        objReader = New System.IO.StreamReader(strSendFileName)
                        Do While objReader.Peek() <> -1
                            tStr = tStr & objReader.ReadLine
                            tLenCntr = tLenCntr + 1

                            Application.DoEvents()
                        Loop
                        objReader.Close()
                        tLenCntr = 1
                        tAckChr = Mid(tStr, 2, 1)

                        tStr = Mid(tStr, 3, Len(tStr))
                        'tStr = Space(2) & tStr
                        .Open()
                        .Write("$")
                    Else
                        MsgBox("File Does Not Exist")
                    End If
                End With
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Public Shared Function encode(ByVal str As String) As Byte()
        Dim utf8Encoding As New System.Text.UTF8Encoding
        Dim encodedString() As Byte

        encodedString = utf8Encoding.GetBytes(str)

        Return encodedString
    End Function
    
End Class
