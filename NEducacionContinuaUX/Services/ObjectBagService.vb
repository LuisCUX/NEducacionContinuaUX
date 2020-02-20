Public Class ObjectBagService
    Private Shared bag As New Hashtable

    ''-----INTRODUCE UN ITEM EN LA BOLSA-----
    Public Shared Sub setItem(ID As String, item As Object)
        If (bag.ContainsKey(ID)) Then
            Return
        Else
            bag.Add(ID, item)
        End If
    End Sub

    ''-----OBTIENE UN ITEM DE LA BOLSA-----
    Public Shared Function getItem(ID As String) As Object
        If (bag.ContainsKey(ID)) Then
            Return bag(ID)
        Else
            Return Nothing
        End If
    End Function

    ''-----ELIMINA UN ITEM DE LA BOLSA-----
    Public Shared Sub clearItem(ID As String)
        If (bag.ContainsKey(ID)) Then
            bag.Remove(ID)
        Else
            Return
        End If
    End Sub

    ''-----ELIMINA TODOS LOS ITEMS DE LA BOLSA-----
    Public Shared Sub clearBag()
        bag.Clear()
    End Sub
End Class
