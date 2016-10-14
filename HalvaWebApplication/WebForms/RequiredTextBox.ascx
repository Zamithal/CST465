<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RequiredTextBox.ascx.cs" Inherits="HalvaWebApplication.WebForms.RequiredTextBox" %>
<asp:Label ID="uxFieldLabel" AssociatedControlID="uxTextBox" runat="server">Missing Label</asp:Label>
<asp:TextBox ID="uxTextBox" TextMode="SingleLine" runat="server" />
<asp:RequiredFieldValidator ID="uxValidator" ControlToValidate="uxTextBox" Text="*" ErrorMessage="Field is required." runat="server" />