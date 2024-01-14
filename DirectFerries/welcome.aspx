<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="welcome.aspx.vb" Inherits="DirectFerries.welcome" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Direct Ferries - Welcome</title>
    <style type="text/css">

        body {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 14px;
        }

        table {
            border: 1px solid #CCC;
            padding: 10px;
        }
        
    </style>
</head>
<body>
    <form id="frmWelcome" runat="server">
        <div>
            <h3>Welcome <asp:Literal ID="ltlFirstName" runat="server"></asp:Literal></h3>
            <p>Number of vowels in your name: <asp:Literal ID="ltlVowelCount" runat="server"></asp:Literal></p>
            <p>
                You are <asp:Literal ID="ltlYearsOld" runat="server"></asp:Literal>
                and you have <asp:Literal ID="ltlDaysUntil" runat="server"></asp:Literal> days until your next birthday.
            </p>

            <p style="font-weight:bold;">
                14 days run up to next birthday...
            </p>

            <asp:Literal ID="ltlRunUp" runat="server"></asp:Literal>
        </div>
    </form>
</body>
</html>
