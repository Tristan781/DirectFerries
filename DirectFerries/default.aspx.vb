Public Class _default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim i As Integer
        Dim strMonth As String 
        Dim intYear As Integer

        If Not IsPostBack Then

            'Add values to date of birth drop down lists
            ddlDay.Items.Add(New ListItem("DD", "0"))
            ddlMonth.Items.Add(New ListItem("MMM", "0"))
            ddlYear.Items.Add(New ListItem("YYYY", "0"))

            'Add values to day dropdown           
            For i = 1 To 31
                ddlDay.Items.Add(New ListItem(i, i))
            Next

            'Add values to month dropdown
            For i = 1 To 12 
                strMonth = MonthName(i, True)
                ddlMonth.Items.Add(New ListItem(strMonth, strMonth))
            Next

            'Add values to year dropdown
            For i = 0 To 120
                intYear = Date.Today.Year - i
                ddlYear.Items.Add(New ListItem(intYear, intYear))
            Next

        End If

    End Sub

    Protected Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Dim strFirstName As String 
        Dim strSurname As String 
        Dim strDay As String 
        Dim strMonth As String
        Dim strYear As String 
        Dim strDateOfBirth As String 
        dim strRedirectURL As String 

        strFirstName = txtFirstName.Text.Trim()
        strSurname = txtSurname.Text.Trim()
        strDay = ddlDay.Text
        strMonth = ddlMonth.Text
        strYear = ddlYear.Text

        strDateOfBirth = strDay & "-" & strMonth & "-" & strYear

        'Hide errors panel
        errors.Visible = False

        If String.IsNullOrEmpty(strFirstName) Then

            ltlErrors.Text = "Please enter your first name."
            errors.Visible = true
            Exit Sub

        End If

        If String.IsNullOrEmpty(strSurname) Then

            ltlErrors.Text = "Please enter your surname."
            errors.Visible = true
            Exit Sub

        End If

        If Not IsDate(strDateOfBirth) Then

            ltlErrors.Text = "Please select a valid date of birth."
            errors.Visible = true
            Exit Sub

        End If

        'Redirect user to the next page
        strRedirectURL = "welcome.aspx?firstname=" & Server.UrlEncode(strFirstName) & "&surname=" & Server.UrlEncode(strSurname) & "&day=" & Server.UrlEncode(strDay) & "&month=" & Server.UrlEncode(strMonth) & "&year=" & Server.UrlEncode(strYear)
        Response.Redirect(strRedirectURL)

    End Sub
End Class