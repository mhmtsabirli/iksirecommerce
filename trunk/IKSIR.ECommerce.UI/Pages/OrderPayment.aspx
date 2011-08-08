<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/UIDetailMasterPage.Master"
    AutoEventWireup="true" CodeBehind="OrderPayment.aspx.cs" Inherits="IKSIR.ECommerce.UI.Pages.OrderPayment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="sepet_content_middle">
        <div class="sepet_content_header">
            <img src="../images/sepet_sepet.jpg" alt="" />
            <h3>
                Ödeme Bilgileri</h3>
            <h4>
                Ödeme seçeneklerinden birini seçebilir kart bilgilerinizi girerek alışverişinizi tamamlayabilirsiniz.
            </h4>
        </div>
        <table>
            <tr>
                <td>
                    <asp:RadioButtonList runat="server" ID="rblShippingCompanies">
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <a href="#">
                        <img src="../images/sepet_end_iptal.jpg" alt="" /></a> <a href="OrderShipping.aspx">
                            <img src="../images/sepet_end_devam.jpg" alt="" /></a>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
