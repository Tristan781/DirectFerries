<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="default.aspx.vb" Inherits="DirectFerries._default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Direct Ferries</title>
    <style type="text/css">

        body {
            font-family:Arial, Helvetica, sans-serif;
            font-size: 14px;
        }

        .errors {
            color: red;
            font-weight:bold;
        }

    </style>
</head>
<body>
    <form id="frmDefault" runat="server">
        <div>
            <h3>Please enter your full name and date of birth.</h3>
            
            <p>First Name:</p>
            <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>

            <p>Surname:</p>
            <asp:TextBox ID="txtSurname" runat="server"></asp:TextBox>

            <p>Date of Birth:</p>
            <p>
                <asp:DropDownList ID="ddlDay" runat="server"></asp:DropDownList>&nbsp;-
                <asp:DropDownList ID="ddlMonth" runat="server"></asp:DropDownList>&nbsp;-
                <asp:DropDownList ID="ddlYear" runat="server"></asp:DropDownList>
            </p>  
            <p style="margin-top:30px;">
                When you have entered the information above then please click the submit button below.
            </p>
            <p>
                <asp:Button ID="btnSubmit" runat="server" Text="Submit Information >" />
            </p>

            <asp:Panel ID="errors" Visible="false" runat="server">
                <p class="errors" style="margin-top:20px;">
                    <asp:Literal ID="ltlErrors" runat="server"></asp:Literal>
                </p>
            </asp:Panel>  
        </div>
    </form>
</body>
</html>
