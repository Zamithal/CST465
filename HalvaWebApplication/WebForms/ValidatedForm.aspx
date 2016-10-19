<%@ Page Language="C#" MasterPageFile="~/WebForms/ThisIsMyBeautfulMasterPageName.Master" AutoEventWireup="true" CodeBehind="ValidatedForm.aspx.cs" Inherits="HalvaWebApplication.WebForms.ValidatedForm" %>

<%@ Register TagPrefix="CST" TagName="RequiredTextBox" Src="~/WebForms/RequiredTextBox.ascx" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <title>Validated Form</title>
</asp:Content>

<asp:Content ContentPlaceHolderID="main" runat="server">
    <asp:Panel ID="uxPersonalInformation" runat="server">
        <CST:RequiredTextBox ID="uxName" runat="server"/>
        <CST:RequiredTextBox ID="uxFavoriteColor" runat="server" />
        <CST:RequiredTextBox ID="uxCity" runat="server" />
        <asp:Button ID="uxSubmit" Text="Submit" OnClick="uxSubmit_Click" runat="server"/>
    </asp:Panel>
</asp:Content>
