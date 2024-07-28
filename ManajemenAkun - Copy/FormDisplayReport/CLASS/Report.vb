Imports Microsoft.Reporting.WinForms
Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Text

Public Class Report
    Public Shared Sub Load(Report As LocalReport)
        'var items = New[] { New ReportItem { Description = "Widget 6000", Price = 104.99m, Qty = 1 }, New ReportItem { Description = "Gizmo MAX", Price = 1.41m, Qty = 25 } };
        'Dim items() As String = New ReportItem { Description = "Widget 6000", Price = 104.99m, Qty = 1 }, New ReportItem { Description = "Gizmo MAX", Price = 1.41m, Qty = 25 }
        Dim items As ReportItem() = {New ReportItem With {._description = "Widget 6000", ._price = 104.99D, ._qty = 1},
                              New ReportItem With {._description = "Gizmo MAX", ._price = 1.41D, ._qty = 25}}
        'var parameters = New[] { New ReportParameter("Title", "Invoice 4/2020") };
        Dim parameters As ReportParameter() = {New ReportParameter("Title", "Invoice 4/2020")}
        'Using var fs = New FileStream("Report.rdlc", FileMode.Open);
        Using fs As New FileStream("TesReport.rdlc", FileMode.Open)
            ' Code to read from or write to the file goes here
            Report.LoadReportDefinition(fs)
        End Using
        Report.DataSources.Add(New ReportDataSource("Items", items))
        Report.SetParameters(parameters)
    End Sub
End Class
