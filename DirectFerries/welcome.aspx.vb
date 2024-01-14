Public Class welcome
    Inherits System.Web.UI.Page

    Public function GetVowelCount(byval strFirstName As string) As Integer
        Dim i As Integer 
        Dim strChar As String   
        Dim intVowelCount = 0

        For i = 1 To strFirstName.Length

            strChar = Mid(strFirstName, i, 1)

            If InStr("aeiou", strChar) > 0 Then
                intVowelCount = intVowelCount + 1
            End If

        Next

        Return intVowelCount
    End function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim i As Integer = 0
        Dim strFirstName As String = ""
        Dim strSurname As String = ""
        Dim strDay As String 
        Dim strMonth As String
        Dim strYear As String
        Dim strDateOfBirth As String = "" 
        Dim intYearsOld As Integer = 0
        Dim strBirthdayDayMonth As String = ""
        Dim intDaysUntil As Integer = 0
        Dim strRunUp As New StringBuilder
        Dim dRunUp As date
        dim strRunUpDay As String 
        Dim strRunUpMonth As String 
        Dim strRunUpLink As String 
        Dim strHistoryLink As String = "https://www.historynet.com/today-in-history"

        If Not IsPostBack Then            

            strFirstName = Trim(Request.QueryString("firstname"))
            strSurname = Trim(Request.QueryString("surname"))
            strDay = Trim(Request.QueryString("day"))
            strMonth = Trim(Request.QueryString("month"))
            strYear = Trim(Request.QueryString("year"))

            strDateOfBirth = strDay & "-" & strMonth & "-" & strYear

            If Not IsDate(strDateOfBirth) Then

                'Redirect back to the default page
                Response.Redirect("default.aspx")
                Response.End

            End If

            'Display welcome details
            ltlFirstName.Text = strFirstName
            ltlVowelCount.Text = GetVowelCount(strFirstName)

            'Calculate how old someone is
            intYearsOld = DateDiff(DateInterval.Year, Convert.ToDateTime(strDateOfBirth), Date.Today)
            ltlYearsOld.Text = intYearsOld           
            
            'Calculate the number of days until their next birthday
            strBirthdayDayMonth = strDay & "-" & strMonth & "-" & Date.Today.Year
            intDaysUntil = DateDiff(DateInterval.Day, Date.Today, Convert.ToDateTime(strBirthdayDayMonth))
            
            If intDaysUntil < 0 Then

                'Birthday next year                
                intDaysUntil = DateDiff(DateInterval.Day, Date.Today, DateAdd(DateInterval.Year, 1, Convert.ToDateTime(strBirthdayDayMonth)))
                strBirthdayDayMonth = strDay & "-" & strMonth & "-" & (Date.Today.Year + 1)

            End If

            ltlDaysUntil.Text = intDaysUntil

            'Build 14 day birthday run up table
            strRunUp.Append("<table>")

            For i = -13 To 0

                dRunUp = DateAdd(DateInterval.Day, i, Convert.ToDateTime(strBirthdayDayMonth))
                strRunUpDay = dRunUp.Day
                strRunUpMonth = MonthName(dRunUp.Month, False)
                strRunUpLink = strHistoryLink & "/" & strRunUpMonth & "-" & strRunUpDay

                strRunUp.Append("<tr><td><a href=""" & strRunUpLink & """ target=""_blank"">" & Format(dRunUp, "ddd dd MMM yyyy") & "</a></td></tr>")

            Next

            strRunUp.Append("</table>")

            'Display birthday run-up data on screen
            ltlRunUp.Text = strRunUp.ToString()

        End If

    End Sub

End Class