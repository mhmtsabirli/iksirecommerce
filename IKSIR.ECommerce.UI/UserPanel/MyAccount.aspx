<%@ Page Title="" Language="C#" MasterPageFile="~/UIMasterPage.Master" AutoEventWireup="true"
    CodeBehind="MyAccount.aspx.cs" Inherits="IKSIR.ECommerce.UI.UserPanel.MyAccount" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <h2>
        Hesabım
    </h2>
    <p>
        Kullanıcı hesap biglileri görüntüleme, düzenleme.
    </p>
    <telerik:RadTabStrip ID="RadTabStrip1" runat="server" Skin="Web20" MultiPageID="RadMultiPage1"
        SelectedIndex="1" Width="400px">
        <Tabs>
            <telerik:RadTab Text="Üye Bilgilerim" Selected="true" PageViewID="RadPageView1">
            </telerik:RadTab>
            <telerik:RadTab Text="Adreslerim" PageViewID="RadPageView2">
            </telerik:RadTab>
            <telerik:RadTab Text="Siparişlerim" PageViewID="RadPageView3">
            </telerik:RadTab>
        </Tabs>
    </telerik:RadTabStrip>
</asp:Content>
