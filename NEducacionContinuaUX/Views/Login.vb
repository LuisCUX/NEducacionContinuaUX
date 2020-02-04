Imports System.Configuration
Imports System.Data.SqlClient
Imports System.IO

Public Class Login
    Dim xml As XmlService = New XmlService()
    Dim st As SelladoTimbradoService = New SelladoTimbradoService()
    Dim ch As ConceptHandlerController = New ConceptHandlerController()
    Dim db As DataBaseService = New DataBaseService()
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        EnviromentService.setEnviroment()
        Dim tableConceptos As DataTable = db.getDataTableFromSQL("SELECT ID, Nombre FROM ing_ConceptosTemp")
        cbconcepto.DataSource = tableConceptos
        cbconcepto.DisplayMember = "nombre"
        cbconcepto.ValueMember = "id"
        lblTotal.Text = "0.00"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Certificado As String = ConfigurationSettings.AppSettings.Get("developmentCertificadoContent").ToString()
        Dim NoCertificado As String = ConfigurationSettings.AppSettings.Get("developmentCertificado").ToString()

        Dim listaConceptos As New List(Of Concepto)
        listaConceptos = ch.getListaConceptos()

        Dim subtotalSuma As Decimal
        For Each concepto As Concepto In listaConceptos
            subtotalSuma = subtotalSuma + CDec(concepto.costoTotal)
        Next
        Dim SubTotal As String = subtotalSuma.ToString()

        Dim totalSuma As Decimal
        For Each concepto As Concepto In listaConceptos
            totalSuma = totalSuma + CDec(concepto.costoFinal)
        Next
        Dim Total As String = totalSuma.ToString()

        Dim totalIVASuma As Decimal
        For Each concepto As Concepto In listaConceptos
            totalIVASuma = totalIVASuma + CDec(concepto.costoIVATotal)
        Next
        Dim totalIVA As String = totalIVASuma.ToString()

        Dim Descuento As Decimal
        For Each concepto As Concepto In listaConceptos
            Descuento = Descuento + CDec(concepto.descuento)
        Next
        Dim DescuentoS As String = Descuento.ToString()
        Dim FormaPago As String = "01"
        Dim Folio As String = "177"
        Dim Serie As String = "H"
        Dim UsoCFDI As String = "P01"

        SubTotal = ch.getFormat(SubTotal)
        totalIVA = ch.getFormat(totalIVA)
        DescuentoS = ch.getFormat(DescuentoS)
        Total = ((CDec(SubTotal) - CDec(Descuento)) + CDec(totalIVA))

        Dim Fecha As String = db.exectSQLQueryScalar("select STUFF(CONVERT(VARCHAR(50),GETDATE(), 127) ,20,4,'') as fecha")
        MessageBox.Show(Fecha)

        Dim cadena = xml.cadenaPrueba(Serie, Folio, Fecha, FormaPago, NoCertificado, SubTotal, DescuentoS, Total, listaConceptos, totalIVA)
        Dim sello As String = st.Sellado("C:\Users\Luis\Desktop\pfx\uxa_pfx33.pfx", "12345678a", cadena)
        Dim xmlString As String = xml.xmlPrueba(Total, SubTotal, DescuentoS, totalIVA, Fecha, sello, Certificado, NoCertificado, FormaPago, Folio, Serie, UsoCFDI, listaConceptos)
        xmlString = xmlString.Replace("utf-16", "UTF-8")
        Dim xmlTimbrado As String = st.Timbrado(xmlString, Folio)
        File.WriteAllText("C:\Users\Luis\Desktop\wea.xml", xmlTimbrado)
        db.execSQLQueryWithoutParams("INSERT INTO ing_xmlPruebas(XML) VALUES ('" & xmlTimbrado & "')")
        MessageBox.Show("XML completado")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ch.agregarconcepto(cbconcepto.SelectedValue, txtCantidad.Text, DataGridView1, lblTotal)
    End Sub
End Class