Imports System.Configuration
Imports System.Data.SqlClient
Imports System.IO

Public Class Cobros
    Dim xml As XmlService = New XmlService()
    Dim st As SelladoTimbradoService = New SelladoTimbradoService()
    Dim ch As ConceptHandlerController = New ConceptHandlerController()
    Dim db As DataBaseService = New DataBaseService()

    Private Sub Cobros_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        EnviromentService.setEnviroment()
        Dim tableConceptos As DataTable = db.getDataTableFromSQL("SELECT ID, Nombre FROM ing_ConceptosTemp")
        cbconcepto.DataSource = tableConceptos
        cbconcepto.DisplayMember = "nombre"
        cbconcepto.ValueMember = "id"
        lblTotal.Text = "0.00"

        Dim tableFormaPago As DataTable = db.getDataTableFromSQL("SELECT Forma_Pago, Descripcion FROM ing_CatFormaPago")
        cbFormaPago.DataSource = Nothing
        cbFormaPago.DataSource = tableFormaPago
        cbFormaPago.DisplayMember = "Descripcion"
        cbFormaPago.ValueMember = "Forma_Pago"
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
        Dim FormaPago As String = cbFormaPago.SelectedValue.ToString()
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

    'Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    '    ch.agregarconcepto(cbconcepto.SelectedValue, txtCantidad.Text, DataGridView1, lblTotal)
    'End Sub

    'Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
    '    Dim index As Integer
    '    index = DataGridView1.CurrentCell.RowIndex
    '    Dim conceptoID As Integer = Convert.ToInt32(DataGridView1.Rows(index).Cells(0).Value)
    '    Dim cantidad As Integer = Convert.ToInt32(DataGridView1.Rows(index).Cells(5).Value)
    '    ch.eliminarconcepto(index, conceptoID, , cantidad)
    'End Sub
End Class