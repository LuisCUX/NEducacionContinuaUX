Imports System.Xml
Imports System.IO
Imports System.Text
Imports System.Threading

Public Class Form3
    Dim db As DataBaseService = New DataBaseService()
    Public QR_Generator As New MessagingToolkit.QRCode.Codec.QRCodeEncoder
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim xml As String = Me.generarXML("Matutino", "L", "2025-2025")
    End Sub

    Function generarXML(Turno As String, Nivel As String, Periodo As String) As String
        Dim config As New XmlWriterSettings
        config.Indent = True
        config.Encoding = Encoding.UTF8
        config.Async = True
        Dim xml As String
        Dim archivo_xml As String = "C:\Users\Luis\Desktop\wea.xml"

        Using sw As New StringWriter()
            Using wr As XmlWriter = XmlWriter.Create(sw, config)
                wr.WriteStartDocument()
                wr.WriteStartElement("fet", Nothing)
                wr.WriteAttributeString("version", Nothing, "5.37.5") ''START NODO PRINCIPAL FET

                wr.WriteElementString("Institution_Name", "Universidad de xalapa")
                wr.WriteElementString("Comments", "Default comments")

                If ((Turno = "Matutino" And Nivel = "L") Or (Turno = "Vespertino" And Nivel = "L")) Then

                    wr.WriteStartElement("Days_List", Nothing) ''START NODO DIAS POR SEMANA
                    wr.WriteElementString("Number_of_Days", "5")
                    wr.WriteStartElement("Day", Nothing)
                    wr.WriteElementString("Name", "Lunes")
                    wr.WriteEndElement()
                    wr.WriteStartElement("Day", Nothing)
                    wr.WriteElementString("Name", "Martes")
                    wr.WriteEndElement()
                    wr.WriteStartElement("Day", Nothing)
                    wr.WriteElementString("Name", "Miercoles")
                    wr.WriteEndElement()
                    wr.WriteStartElement("Day", Nothing)
                    wr.WriteElementString("Name", "Jueves")
                    wr.WriteEndElement()
                    wr.WriteStartElement("Day", Nothing)
                    wr.WriteElementString("Name", "Viernes")
                    wr.WriteEndElement()
                    wr.WriteEndElement()


                    wr.WriteStartElement("Hours_List", Nothing) ''START NODO HORAS POR DIA
                    wr.WriteElementString("Number_of_Hours", "8")
                    wr.WriteStartElement("Hour", Nothing)
                    wr.WriteElementString("Name", "07:00-08:00")
                    wr.WriteEndElement()
                    wr.WriteStartElement("Hour", Nothing)
                    wr.WriteElementString("Name", "08:00-09:00")
                    wr.WriteEndElement()
                    wr.WriteStartElement("Hour", Nothing)
                    wr.WriteElementString("Name", "09:00-10:00")
                    wr.WriteEndElement()
                    wr.WriteStartElement("Hour", Nothing)
                    wr.WriteElementString("Name", "10:00-11:00")
                    wr.WriteEndElement()
                    wr.WriteStartElement("Hour", Nothing)
                    wr.WriteElementString("Name", "11:00-12:00")
                    wr.WriteEndElement()
                    wr.WriteStartElement("Hour", Nothing)
                    wr.WriteElementString("Name", "12:00-13:00")
                    wr.WriteEndElement()
                    wr.WriteStartElement("Hour", Nothing)
                    wr.WriteElementString("Name", "13:00-14:00")
                    wr.WriteEndElement()
                    wr.WriteStartElement("Hour", Nothing)
                    wr.WriteElementString("Name", "14:00-15:00")
                    wr.WriteEndElement()
                    wr.WriteEndElement()
                End If

                wr.WriteStartElement("Subjects_List", Nothing) ''START NODO MATERIAS
                Dim tableMaterias As DataTable = db.getDataTableFromSQL($"DECLARE @T TABLE(periodo varchar(max), nivel varchar(max), turno varchar(max), clave_escuela varchar(max), nombre_escuela varchar(max), clave_carrera varchar(max), 
                                                                          carrera varchar(max), clave_materia varchar(max), materia varchar(max), horas_materia int, grupo varchar(max), nup_docente varchar(max), ap_pat varchar(max), ap_mat varchar(max), nombre_docente varchar(max),
                                                                          autorizado varchar(max), visto_bueno varchar(max), fecha_visto_bueno datetime, exp_docente varchar(max), exp_profesional varchar(max), act_academ varchar(max), promocion varchar(max),
                                                                          evsatisf varchar(max), posgrado varchar(max))
                                                                          insert @T EXEC UX.DBO.obtenerListaDocentesPropuestosPrePlantilla '{Periodo}', '{Nivel}', '{Turno}', '', '', '', ''
                                                                          SELECT DISTINCT clave_materia, materia, clave_carrera, ('(' + clave_materia + ') ' + materia) AS NombreMateria FROM @T
                                                                          where autorizado = 'Si'")
                For Each row As DataRow In tableMaterias.Rows
                    wr.WriteStartElement("Subject", Nothing)
                    wr.WriteElementString("Name", row("NombreMateria"))
                    wr.WriteElementString("Comments", "")
                    wr.WriteEndElement()
                Next
                wr.WriteEndElement() ''END NODO MATERIAS

                wr.WriteStartElement("Activity_Tags_List", Nothing) ''START NODO ACTIVITY TAGS
                wr.WriteEndElement() ''END NODO ACTIVITY TAGS

                wr.WriteStartElement("Teachers_List") ''START NODO DOCENTES
                Dim tableDocentes As DataTable = db.getDataTableFromSQL($"DECLARE @T TABLE(periodo varchar(max), nivel varchar(max), turno varchar(max), clave_escuela varchar(max), nombre_escuela varchar(max), clave_carrera varchar(max), 
                                                                        carrera varchar(max), clave_materia varchar(max), materia varchar(max), horas_materia int, grupo varchar(max), nup_docente varchar(max), ap_pat varchar(max), ap_mat varchar(max), nombre_docente varchar(max),
                                                                        autorizado varchar(max), visto_bueno varchar(max), fecha_visto_bueno datetime, exp_docente varchar(max), exp_profesional varchar(max), act_academ varchar(max), promocion varchar(max),
                                                                        evsatisf varchar(max), posgrado varchar(max))

                                                                        insert @T EXEC UX.DBO.obtenerListaDocentesPropuestosPrePlantilla '{Periodo}', '{Nivel}', '{Turno}', '', '', '', ''

                                                                        SELECT DISTINCT nup_docente, ('(' + UPPER(nup_docente) + ') ' + nombre_docente + ' ' + ap_pat + ' ' + ap_mat) NombreDocente FROM @T
                                                                        where autorizado = 'Si'")
                For Each row As DataRow In tableDocentes.Rows
                    wr.WriteStartElement("Teacher", Nothing)
                    wr.WriteElementString("Name", row("NombreDocente"))
                    wr.WriteElementString("Comments", "")
                    wr.WriteEndElement()
                Next
                wr.WriteEndElement() ''END NODO DOCENTES

                wr.WriteStartElement("Students_List") ''START NODO CARRERAS/GRUPOS
                wr.WriteStartElement("Year") ''START NODO AÑO

                wr.WriteElementString("Name", Periodo)
                wr.WriteElementString("Number_of_Students", "0")
                wr.WriteElementString("Comments", "")

                Dim tableCarreras As DataTable = db.getDataTableFromSQL($"DECLARE @T TABLE(periodo varchar(max), nivel varchar(max), turno varchar(max), clave_escuela varchar(max), nombre_escuela varchar(max), clave_carrera varchar(max), 
                                                                        carrera varchar(max), clave_materia varchar(max), materia varchar(max), horas_materia int, grupo varchar(max), nup_docente varchar(max), ap_pat varchar(max), ap_mat varchar(max), nombre_docente varchar(max),
                                                                        autorizado varchar(max), visto_bueno varchar(max), fecha_visto_bueno datetime, exp_docente varchar(max), exp_profesional varchar(max), act_academ varchar(max), promocion varchar(max),
                                                                        evsatisf varchar(max), posgrado varchar(max))

                                                                        insert @T EXEC UX.DBO.obtenerListaDocentesPropuestosPrePlantilla '{Periodo}', '{Nivel}', '{Turno}', '', '', '', ''

                                                                        SELECT DISTINCT clave_carrera FROM @T
                                                                        where autorizado = 'Si'")

                For Each row As DataRow In tableCarreras.Rows
                    wr.WriteStartElement("Group", Nothing) ''START NODO CARRERA
                    wr.WriteElementString("Name", row("clave_carrera"))
                    wr.WriteElementString("Number_of_Students", "0")
                    wr.WriteElementString("Comments", "")

                    Dim tableGrupos As DataTable = db.getDataTableFromSQL($"DECLARE @T TABLE(periodo varchar(max), nivel varchar(max), turno varchar(max), clave_escuela varchar(max), nombre_escuela varchar(max), clave_carrera varchar(max), 
                                                                        carrera varchar(max), clave_materia varchar(max), materia varchar(max), horas_materia int, grupo varchar(max), nup_docente varchar(max), ap_pat varchar(max), ap_mat varchar(max), nombre_docente varchar(max),
                                                                        autorizado varchar(max), visto_bueno varchar(max), fecha_visto_bueno datetime, exp_docente varchar(max), exp_profesional varchar(max), act_academ varchar(max), promocion varchar(max),
                                                                        evsatisf varchar(max), posgrado varchar(max))

                                                                        insert @T EXEC UX.DBO.obtenerListaDocentesPropuestosPrePlantilla '{Periodo}', '{Nivel}', '{Turno}', '', '', '', ''

                                                                        SELECT DISTINCT ('(' + clave_carrera + ') '+ grupo) AS grupo FROM @T
                                                                        where autorizado = 'Si' AND clave_carrera = '{row("clave_carrera")}'")

                    For Each row2 As DataRow In tableGrupos.Rows
                        wr.WriteStartElement("Subgroup", Nothing)
                        wr.WriteElementString("Name", row2("grupo"))
                        wr.WriteElementString("Number_of_Students", "0")
                        wr.WriteElementString("Comments", "")
                        wr.WriteEndElement()
                    Next

                    wr.WriteEndElement()
                Next

                wr.WriteEndElement() ''END NODO AÑO
                wr.WriteEndElement() ''END NODO GRUPOS

                wr.WriteStartElement("Activities_List", Nothing)

                Dim tableActivities As DataTable = db.getDataTableFromSQL($"DECLARE @T TABLE(periodo varchar(max), nivel varchar(max), turno varchar(max), clave_escuela varchar(max), nombre_escuela varchar(max), clave_carrera varchar(max), 
                                                                            carrera varchar(max), clave_materia varchar(max), materia varchar(max), horas_materia int, grupo varchar(max), nup_docente varchar(max), ap_pat varchar(max), ap_mat varchar(max), nombre_docente varchar(max),
                                                                            autorizado varchar(max), visto_bueno varchar(max), fecha_visto_bueno datetime, exp_docente varchar(max), exp_profesional varchar(max), act_academ varchar(max), promocion varchar(max),
                                                                            evsatisf varchar(max), posgrado varchar(max))

                                                                            insert @T EXEC UX.DBO.obtenerListaDocentesPropuestosPrePlantilla '{Periodo}', '{Nivel}', '{Turno}', '', '', '', ''

                                                                            SELECT ('(' + UPPER(nup_docente) + ') ' + nombre_docente + ' ' + ap_pat + ' ' + ap_mat) NombreDocente, ('(' + clave_materia + ') ' + materia) AS NombreMateria, ('(' + clave_carrera + ') '+ grupo) AS grupo,
                                                                            '1' AS Duration, ROW_NUMBER() OVER (ORDER BY grupo) AS 'Id', horas_materia
                                                                            FROM @T
                                                                            where autorizado = 'Si' and nombre_docente != 'DOCENTE NUEVO'")
                Dim id As Integer = 1
                For Each row As DataRow In tableActivities.Rows
                    For x = 0 To row("horas_materia") - 1
                        wr.WriteStartElement("Activity", Nothing)
                        wr.WriteElementString("Teacher", row("NombreDocente"))
                        wr.WriteElementString("Subject", row("NombreMateria"))
                        wr.WriteElementString("Students", row("grupo"))
                        wr.WriteElementString("Duration", row("Duration"))
                        wr.WriteElementString("Total_Duration", row("Duration"))
                        wr.WriteElementString("Id", id)
                        wr.WriteElementString("Activity_Group_Id", "0")
                        wr.WriteElementString("Active", "true")
                        wr.WriteElementString("Comments", "")
                        wr.WriteEndElement()
                        id = id + 1
                    Next
                Next

                wr.WriteEndElement()


                wr.WriteEndElement() ''END NODO PRINCIPAL FET
                wr.WriteEndDocument()
            End Using
            xml = sw.ToString()
        End Using

        Return xml
    End Function

    Function gethsm(hsm As Integer) As String()
        Select Case hsm
            Case 1
                Return {"1"}
            Case 2
                Return {"2"}
            Case 3
                Return {"3"}
            Case 4
                Return {"2", "2"}
            Case 5
                Return {"2", "2", "1"}
            Case 6
                Return {"2", "2", "2"}
            Case 7
                Return {"2", "2", "2", "1"}
            Case 8
                Return {"2", "2", "2", "2", "2"}
        End Select
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim name As String = "Luis Alberto Carmona Ronzón"
        name = Me.QuitarAcentos(name)
    End Sub

    Function QuitarAcentos(input As String) As String
        Dim acentos As String = "áéíóúÁÉÍÓÚñÑ"
        Dim sinAcentos As String = "aeiouAEIOUnN"

        Dim resultado As New Text.StringBuilder()

        For Each c As Char In input
            Dim index As Integer = acentos.IndexOf(c)
            If index >= 0 Then
                resultado.Append(sinAcentos(index))
            Else
                resultado.Append(c)
            End If
        Next

        Return resultado.ToString()
    End Function

    Public Sub generarQR(QR As String, Nombre As String)

        Try
            Dim img As New Bitmap(QR_Generator.Encode(QR.ToString), New Size(220, 220))
            ''img.Save($"\\{EnviromentService.serverIP}\ti\NEducacionContinua\QR\{Nombre}.png", Imaging.ImageFormat.Png)
            ''img.Save($"\\{EnviromentService.serverIP}\Reportes\NEDC\QR\{Nombre}.png", Imaging.ImageFormat.Png)
            img.Save($"C:\Users\LuisUXX\Desktop\{Nombre}.png", Imaging.ImageFormat.Png)
            Thread.Sleep(1500)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.generarQR("EC25PS326", "wea")
    End Sub
End Class