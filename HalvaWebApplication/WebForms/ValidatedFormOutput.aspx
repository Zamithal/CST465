<%@ Page Title="" Language="C#" MasterPageFile="~/WebForms/ThisIsMyBeautfulMasterPageName.Master" AutoEventWireup="true" CodeBehind="ValidatedFormOutput.aspx.cs" Inherits="HalvaWebApplication.WebForms.ValidatedFormOutput" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Validated Form Output</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ASPBlogNav" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="main" runat="server">
    <h1>Validated Form</h1>
    <asp:Placeholder ID="uxValidDataArea" Visible="false" runat="server">
        <div>
            Name:
            <asp:Literal ID="uxName" runat="server" />
        </div>
        <div>
            Favorite Color:
            <asp:Literal ID="uxFavoriteColor" runat="server" />
        </div>
        <div>
            City:
            <asp:Literal ID="uxCity" runat="server" />
        </div>
    </asp:Placeholder>
    <asp:Placeholder ID="uxInvalidDataArea" Visible="false" runat="server">
        This form did not receive the parameters expected
    </asp:Placeholder>
</asp:Content>
