<%@ Page Title="" Language="C#" MasterPageFile="~/UIMasterPage.Master" AutoEventWireup="true"
    CodeBehind="Content.aspx.cs" Inherits="IKSIR.ECommerce.UI.Pages.Content" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
        <asp:Label runat="server" ID="lblTitle" Text="Başlık"></asp:Label>
    </h2>
    <p>
        <i>
            <asp:Label runat="server" ID="lblDesciption" Text="İçerik hakkında kısa bir açıklama"></asp:Label>
        </i>
    </p>
    <div runat="server" id="divContent">
    </div>
</asp:Content>
