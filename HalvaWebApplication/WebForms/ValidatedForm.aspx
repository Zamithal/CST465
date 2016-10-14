<%@ Page Language="C#" MasterPageFile="~/WebForms/ThisIsMyBeautfulMasterPageName.Master" AutoEventWireup="true" CodeBehind="ValidatedForm.aspx.cs" Inherits="HalvaWebApplication.WebForms.ValidatedForm" %>

<%@ Register TagPrefix="CST" TagName="RequiredTextBox" Src="~/WebForms/RequiredTextBox.ascx" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <title>Validated Form</title>
</asp:Content>

<asp:Content ContentPlaceHolderID="main" runat="server">
    <asp:Panel ID="uxPersonalInformation" runat="server">

    </asp:Panel>
</asp:Content>
