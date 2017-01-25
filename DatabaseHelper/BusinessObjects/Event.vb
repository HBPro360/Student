Public Class [Event]
    Public Delegate Sub SavableEventHandler(e As SavableEventArgs)

    Public Event Savable As SavableEventHandler

    Public Sub RaiseOurEvent(e As SavableEventArgs)
        RaiseEvent Savable(e)
    End Sub
End Class
