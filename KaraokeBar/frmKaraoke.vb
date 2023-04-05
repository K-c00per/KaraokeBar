' Program Name: Karaoke Music Night
' Developers: Katelyn Cooper
' Date: April 4, 2023
' Purpose: This application displays the cost of renting a Karaoke room based on the song selection and how many hours rented.
Option Strict On

Public Class frmKaraoke

    Private _decSong As Decimal = 2.99D
    Private _decHourlyRate As Decimal = 8.99D
    Private Sub Karaoke_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Hold the splash screen for about 6 seconds
        Threading.Thread.Sleep(3000)
    End Sub
    Private Function ValidateInput() As Boolean
        'This procedure validates the input
        Dim intNumber As Integer
        Dim blnValid As Boolean = False
        Try
            'converts the target amount to an integer value
            intNumber = Convert.ToInt32(txtValue.Text)
            If intNumber > 0D Then
                blnValid = True
                Return blnValid
            Else
                MsgBox("Please enter a number greater than 0", , "Error")
            End If
        Catch Exception As FormatException
            'This catch block detects letters, symbols, blank entries, etc...
            MsgBox("Please enter a valid amount", , "Error")
        Catch Exception As OverflowException
            'This catch block detects numbers that are too large or too small
            MsgBox("Please enter a reasonable amount", , "Error")
        Catch Exception As SystemException
            'This catch block detects a generic exception not caught by the earlier catch blocks
            MsgBox("Entry invalid. Plese enter a valid number representing the number in your party", , "Error")
        End Try
        'Place focus back onto the textbox
        txtValue.Focus()
        txtValue.Clear()
        Return blnValid
    End Function

    Private Function ComputeSongCost(ByVal intPass As Integer) As Decimal
        Dim decPassCost As Decimal
        decPassCost = intPass * _decSong
        Return decPassCost
    End Function

    Private Function ComputeRoomCost(ByVal intPass As Integer) As Decimal
        Dim decTicketCost As Decimal
        decTicketCost = intPass * _decHourlyRate
        Return decTicketCost
    End Function

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        'The btnClear click event clears the form
        ClearForm()
    End Sub

    Private Sub ClearForm()
        'Clears the form
        cboDropDown.SelectedIndex = -1
        lblRental.Visible = False
        txtValue.Visible = False
        btnTotalCost.Visible = False
        btnClear.Visible = False
        lblTotalCost.Visible = False
        txtValue.Clear()
    End Sub

    Private Sub btnTotalCost_Click(sender As Object, e As EventArgs) Handles btnTotalCost.Click
        Dim blnAmountIsValid As Boolean = False
        Dim intValue As Integer
        Dim decTotal As Decimal

        'A function procedure is called to validate teh value entered
        blnAmountIsValid = ValidateInput()
        If blnAmountIsValid = True Then
            'Input is assigned to varaible 
            intValue = Convert.ToInt32(txtValue.Text)
            If cboDropDown.SelectedIndex = 0 Then
                decTotal = ComputeSongCost(intValue)
            Else
                decTotal = ComputeRoomCost(intValue)
            End If

            lblTotalCost.Visible = True
            lblTotalCost.Text = "Total Cost of Karaoke Night - " & decTotal.ToString("C")
        End If
    End Sub

    Private Sub cboDropDown_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDropDown.SelectedIndexChanged
        'The event places the objects on the form
        If cboDropDown.SelectedIndex = 0 Then
            lblRental.Text = "Number of Karaoke Songs"
            lblRental.Visible = True
            txtValue.Visible = True
            btnClear.Visible = True
            btnTotalCost.Visible = True
            'places focus on the textbox
            txtValue.Focus()
        End If
        If cboDropDown.SelectedIndex = 1 Then
            lblRental.Text = "Hourly Rental of Karaoke Room:"
            lblRental.Visible = True
            txtValue.Visible = True
            btnTotalCost.Visible = True
            btnClear.Visible = True
            'places focus on the textbox
            txtValue.Focus()
        End If
    End Sub
End Class
