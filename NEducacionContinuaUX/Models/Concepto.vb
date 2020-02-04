Public Class Concepto
    Public Property NombreConcepto As String
    Public Property cveClase As String
    Public Property cveUnidad As String

    Public Property Cantidad As Integer ''Cantidad de conceptos
    Public Property costoUnitario As String ''Costo de cada concepto
    Public Property costoTotal As String ''Costo unitario * Cantidad
    Public Property costoIVAUnitario As String ''Valor de IVA por concepto
    Public Property costoIVATotal As String ''IVA * Cantidad
    Public Property descuento As String ''Valor del descuento
    Public Property costoFinal As String ''Valor del costo total considerando iva y descuento
    Public Property costoBase As String ''Valor de base para nodo traslados 
    Public Property absorbeIVA As Boolean ''Bandera de IVA absorbido por la UX
    Public Property consideraIVA As Boolean ''Bandera de IVA cobrado adicional al concepto   
    Public Property IVAExento As Boolean ''Bandera de IVA exento    
End Class