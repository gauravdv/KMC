<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMenu
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.btn_Master = New System.Windows.Forms.GroupBox()
        Me.btn_Auditing = New System.Windows.Forms.Button()
        Me.btn_Push = New System.Windows.Forms.Button()
        Me.CMBPORTNO = New System.Windows.Forms.ComboBox()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.BtnErase = New System.Windows.Forms.Button()
        Me.btnDownLoad = New System.Windows.Forms.Button()
        Me.btnSendFile = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtProcStat = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btn_Master.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_Master
        '
        Me.btn_Master.Controls.Add(Me.Button1)
        Me.btn_Master.Controls.Add(Me.btn_Auditing)
        Me.btn_Master.Controls.Add(Me.btn_Push)
        Me.btn_Master.Controls.Add(Me.CMBPORTNO)
        Me.btn_Master.Controls.Add(Me.btnExit)
        Me.btn_Master.Controls.Add(Me.BtnErase)
        Me.btn_Master.Controls.Add(Me.btnDownLoad)
        Me.btn_Master.Controls.Add(Me.btnSendFile)
        Me.btn_Master.Location = New System.Drawing.Point(67, 68)
        Me.btn_Master.Name = "btn_Master"
        Me.btn_Master.Size = New System.Drawing.Size(241, 328)
        Me.btn_Master.TabIndex = 0
        Me.btn_Master.TabStop = False
        '
        'btn_Auditing
        '
        Me.btn_Auditing.Location = New System.Drawing.Point(130, 284)
        Me.btn_Auditing.Name = "btn_Auditing"
        Me.btn_Auditing.Size = New System.Drawing.Size(86, 29)
        Me.btn_Auditing.TabIndex = 6
        Me.btn_Auditing.Text = "Auditing"
        Me.btn_Auditing.UseVisualStyleBackColor = True
        '
        'btn_Push
        '
        Me.btn_Push.Location = New System.Drawing.Point(23, 284)
        Me.btn_Push.Name = "btn_Push"
        Me.btn_Push.Size = New System.Drawing.Size(10, 29)
        Me.btn_Push.TabIndex = 5
        Me.btn_Push.Text = "Push"
        Me.btn_Push.UseVisualStyleBackColor = True
        Me.btn_Push.Visible = False
        '
        'CMBPORTNO
        '
        Me.CMBPORTNO.FormattingEnabled = True
        Me.CMBPORTNO.Location = New System.Drawing.Point(71, 19)
        Me.CMBPORTNO.Name = "CMBPORTNO"
        Me.CMBPORTNO.Size = New System.Drawing.Size(82, 21)
        Me.CMBPORTNO.TabIndex = 4
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.Color.Blue
        Me.btnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnExit.Location = New System.Drawing.Point(23, 226)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(193, 42)
        Me.btnExit.TabIndex = 3
        Me.btnExit.Text = "Close"
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'BtnErase
        '
        Me.BtnErase.BackColor = System.Drawing.Color.Blue
        Me.BtnErase.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnErase.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.BtnErase.Location = New System.Drawing.Point(23, 170)
        Me.BtnErase.Name = "BtnErase"
        Me.BtnErase.Size = New System.Drawing.Size(193, 42)
        Me.BtnErase.TabIndex = 2
        Me.BtnErase.Text = "Erase"
        Me.BtnErase.UseVisualStyleBackColor = False
        '
        'btnDownLoad
        '
        Me.btnDownLoad.BackColor = System.Drawing.Color.Blue
        Me.btnDownLoad.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDownLoad.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnDownLoad.Location = New System.Drawing.Point(23, 114)
        Me.btnDownLoad.Name = "btnDownLoad"
        Me.btnDownLoad.Size = New System.Drawing.Size(193, 42)
        Me.btnDownLoad.TabIndex = 1
        Me.btnDownLoad.Text = "Download"
        Me.btnDownLoad.UseVisualStyleBackColor = False
        '
        'btnSendFile
        '
        Me.btnSendFile.BackColor = System.Drawing.Color.Blue
        Me.btnSendFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSendFile.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnSendFile.Location = New System.Drawing.Point(23, 58)
        Me.btnSendFile.Name = "btnSendFile"
        Me.btnSendFile.Size = New System.Drawing.Size(193, 42)
        Me.btnSendFile.TabIndex = 0
        Me.btnSendFile.Text = "Send File"
        Me.btnSendFile.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(1, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(358, 28)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Version 2.0 Rel. Oct. 2017"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(-3, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(362, 28)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "© POWERCRAFT ELECTRONICS PVT. LTD."
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtProcStat
        '
        Me.txtProcStat.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtProcStat.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProcStat.ForeColor = System.Drawing.Color.Red
        Me.txtProcStat.Location = New System.Drawing.Point(0, 442)
        Me.txtProcStat.Name = "txtProcStat"
        Me.txtProcStat.Size = New System.Drawing.Size(359, 15)
        Me.txtProcStat.TabIndex = 8
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(38, 284)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(86, 29)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "Master"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(348, 408)
        Me.Controls.Add(Me.txtProcStat)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_Master)
        Me.Name = "frmMenu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PC2M"
        Me.btn_Master.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_Master As System.Windows.Forms.GroupBox
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents BtnErase As System.Windows.Forms.Button
    Friend WithEvents btnDownLoad As System.Windows.Forms.Button
    Friend WithEvents btnSendFile As System.Windows.Forms.Button
    Friend WithEvents CMBPORTNO As System.Windows.Forms.ComboBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtProcStat As System.Windows.Forms.TextBox
    Friend WithEvents btn_Push As Button
    Friend WithEvents btn_Auditing As Button
    Friend WithEvents Button1 As Button
End Class
