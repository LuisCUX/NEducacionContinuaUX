Imports System.Runtime.InteropServices
Imports System.Threading

Public Class Form2
    <DllImport("user32.dll")>
    Private Shared Function SetParent(hWndChild As IntPtr, hWndNewParent As IntPtr) As IntPtr
    End Function

    <DllImport("user32.dll")>
    Private Shared Function SendMessage(hWnd As IntPtr, Msg As Integer, wParam As Integer, lParam As Integer) As IntPtr
    End Function

    Private Const WM_SYSCOMMAND As Integer = &H112
    Private Const SC_MAXIMIZE As Integer = &HF030


    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Ruta de FET
        Dim fetPath As String = "C:\Users\LuisUXX\Desktop\fet-5.37.5\fet.exe"
        ' Ruta del archivo a abrir
        Dim filePath As String = "C:\Users\LuisUXX\Desktop\asdasd.fet"

        ' Iniciar FET
        Dim proc As New Process()
        proc.StartInfo.FileName = fetPath
        proc.StartInfo.UseShellExecute = False
        proc.Start()

        ' Esperar a que la ventana de FET esté lista
        Thread.Sleep(2000) ' Espera de 2 segundos (ajustar si es necesario)
        proc.WaitForInputIdle()

        ' Anidar FET en el Panel
        SetParent(proc.MainWindowHandle, Me.Panel1.Handle)
        SendMessage(proc.MainWindowHandle, WM_SYSCOMMAND, SC_MAXIMIZE, 0)
        Me.BringToFront()

        ' Simular Ctrl+O para abrir archivo
        SendKeys.SendWait("^o")
        Thread.Sleep(500) ' Esperar a que la ventana de abrir aparezca
        SendKeys.SendWait(filePath) ' Escribir la ruta del archivo
        SendKeys.SendWait("{ENTER}") ' Presionar Enter
    End Sub

End Class