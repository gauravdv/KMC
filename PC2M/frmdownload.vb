Public Class frmDownload
    Dim tFileName As String
    Dim tAckChr As String
    Dim tDwnData As String

    Private Sub frmDownload_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        tFileName = System.String.Concat(My.Application.Info.DirectoryPath, "\output" & Date.Today.Day & "_" & Date.Today.Month & "_" & Date.Today.Year & ".txt")
        If IO.File.Exists(tFileName) Then IO.File.Delete(tFileName)
        Try
            TextBox1.Text = ""
            With IOPORT_DW
                If .IsOpen Then .Close()
                .PortName = frmMenu.CMBPORTNO.Text
                .RtsEnable = True
                .BaudRate = 115200
                .Parity = IO.Ports.Parity.None
                .ParityReplace = 8
                .StopBits = 1
                tAckChr = "D"
                .Open()
                .Write("$")
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            If IOPORT_DW.IsOpen Then IOPORT_DW.Close()
        End Try

    End Sub

    Private Sub IOPORT_DW_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles IOPORT_DW.DataReceived
        Dim tBuffer As String
        Dim tStr As String
        Dim tData As String
        Dim tcntr As Int16
        Dim tPrevFileName As String
        Try
            With IOPORT_DW
                tBuffer = .ReadExisting
                If InStr(tBuffer, "$") > 0 Then 'tBuffer.StartsWith("$") Then
                    If Len(Trim(tAckChr)) <> 0 Then
                        .Write(tAckChr)
                        tAckChr = ""
                    Else
                        .Write("O")
                    End If
                ElseIf InStr(tBuffer, Chr(4)) <> 0 Then '  tBuffer.StartsWith(Chr(4)) Then
                    IOPORT_DW.Close()
                    TextBox1.Text = TextBox1.Text & tBuffer
                    IO.File.AppendAllText(tFileName, tBuffer)

                    tcntr = 1
                    tStr = ""
                    Dim tReader As New IO.StreamReader(tFileName)
                    tPrevFileName = tFileName
                    tFileName = ""
                    While Not tReader.EndOfStream
                        tData = tReader.ReadLine
                        If tData <> Chr(4) Then
                            tStr = tStr & tData & vbCrLf
                        End If
                        If tcntr = 1 Then
                            tFileName = Replace(tStr, vbCrLf, "")
                            tStr = ""
                        End If
                        tcntr = tcntr + 1
                    End While
                    tReader.Close()
                    tReader.Dispose()
                    'If Len(Trim(tFileName)) > 0 Then
                    tStr = Replace(tStr, Chr(4), "")
                    IO.File.AppendAllText(tPrevFileName, tStr)
                    'End If
                    MsgBox("Data download Successfully!!!", MsgBoxStyle.OkOnly)
                    Me.Close()
                Else
                    TextBox1.Text = TextBox1.Text & tBuffer
                    IO.File.AppendAllText(tFileName, tBuffer)

                    'tcntr = 1
                    'tStr = ""
                    'Dim tReader As New IO.StreamReader(tFileName)
                    'tFileName = ""
                    'While Not tReader.EndOfStream

                    '    tStr = tStr & tReader.ReadLine
                    '    If tcntr = 1 Then
                    '        tFileName = Replace(tStr, vbCrLf, "")
                    '        tStr = ""
                    '    End If
                    '    tcntr = tcntr + 1
                    'End While
                    'tReader.Close()
                    'tReader.Dispose()
                    ''If Len(Trim(tFileName)) > 0 Then
                    'tStr = Replace(tStr, Chr(4), "")
                    'IO.File.AppendAllText(My.Application.Info.DirectoryPath & "\" & tFileName, tStr)
                    ''End If
                    'MsgBox("Data download Successfully!!!", MsgBoxStyle.OkOnly)
                    'Me.Close()
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly)
            If IOPORT_DW.IsOpen Then IOPORT_DW.Close()
            Me.Close()
        End Try

    End Sub
End Class