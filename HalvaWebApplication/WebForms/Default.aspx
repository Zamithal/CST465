<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HalvaWebApplication.WebForms.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Default</title>
</head>
<body>
    <h1>
        Default Form
    </h1>
    <form id="DefautForm" runat="server">
    <div>
        <asp:Label AssociatedControlID="uxName" runat="server">Name</asp:Label>
        <asp:TextBox ID="uxName" runat="server"/>
        <asp:Label AssociatedControlID="uxPriority" runat="server">Priority</asp:Label>
        <asp:DropDownList ID="uxPriority" runat="server">
            <asp:ListItem Text="High" />
            <asp:ListItem Text="Medium" />
            <asp:ListItem Text="Low" />
        </asp:DropDownList>
        <asp:Label AssociatedControlID="uxSubject" runat="server">Subject</asp:Label>
        <asp:TextBox ID="uxSubject" TextMode="SingleLine" runat="server" />
        <asp:Label AssociatedControlID="uxDescription" runat="server">Description</asp:Label>
        <asp:TextBox ID="uxDescription" TextMode="MultiLine" runat="server" />
        <asp:Button ID="uxSubmit" Text="Submit" OnClick="uxSubmit_Click" runat="server" />
        <asp:Literal ID="uxFormOutput" runat="server" />
        <asp:Literal ID="uxEventOutput" runat="server" />
    </div>
    </form>
</body>
</html>
