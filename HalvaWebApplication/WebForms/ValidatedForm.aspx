<%@ Page Language="C#" MasterPageFile="~/WebForms/ThisIsMyBeautfulMasterPageName.Master" AutoEventWireup="true" CodeBehind="ValidatedForm.aspx.cs" Inherits="HalvaWebApplication.WebForms.ValidatedForm" %>

<%@ Register TagPrefix="CST" TagName="RequiredTextBox" Src="~/WebForms/RequiredTextBox.ascx" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <title>Validated Form</title>
</asp:Content>

<asp:Content ContentPlaceHolderID="main" runat="server">
    <h1>Validation Form</h1>
    <asp:Panel ID="uxPersonalInformation" runat="server">
        <CST:RequiredTextBox ID="uxName" LabelText="Name: " runat="server"/>
        <CST:RequiredTextBox ID="uxFavoriteColor" LabelText="Favorite Color: " runat="server" />
        <CST:RequiredTextBox ID="uxCity" LabelText ="City: " runat="server" />
        <asp:Button ID="uxSubmit" Text="Submit" OnClick="uxSubmit_Click" runat="server"/>
    </asp:Panel>
</asp:Content>
