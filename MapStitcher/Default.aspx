<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="MapStitcher._Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <asp:TextBox ID="NE_Latitude" runat="server" />

        <asp:TextBox ID="NE_Longitude" runat="server" />

        <hr />

        <asp:TextBox ID="SW_Latitude" runat="server" />

        <asp:TextBox ID="SW_Longitude" runat="server" />

        <hr />

        <asp:TextBox ID="Zoom" runat="server" />

        <hr />

        <asp:Button ID="submit" Text="GO" runat="server" />

        <asp:Image ID="result" runat="server" />

    
    </div>
    </form>
</body>
</html>
