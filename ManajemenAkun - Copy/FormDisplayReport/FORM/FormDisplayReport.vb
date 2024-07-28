Imports Microsoft.Reporting.WinForms
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Forms

Public Class FormDisplayReport
	Private ReportViewer As ReportViewer

	Public Sub ReportViewerForm()
		Text = "Report viewer"
		WindowState = FormWindowState.Maximized
		ReportViewer = New ReportViewer()
		ReportViewer.Dock = DockStyle.Fill
		Controls.Add(ReportViewer)
	End Sub

	Private Sub FormDisplayReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		Try
			Report.Load(ReportViewer.LocalReport)
			ReportViewer.RefreshReport()
			'base.OnLoad(e)
			MyBase.OnLoad(e)
		Catch ex As Exception
			MsgBox("Error")
		End Try
	End Sub
End Class
