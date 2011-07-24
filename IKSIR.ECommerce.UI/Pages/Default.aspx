<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/UIMasterPage.Master"
    AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="IKSIR.ECommerce.UI.Pages.Default" %>

<%@ Register Src="../UserControls/UCShowCaseProducts.ascx" TagName="UCShowCaseProducts"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UCShowCaseProducts ID="UCShowCaseProducts1" runat="server" />
    <div class="clear">
    </div>
</asp:Content>
