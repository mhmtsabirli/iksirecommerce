<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/UIDetailMasterPage.Master"
    AutoEventWireup="true" CodeBehind="OrderPaymentResult.aspx.cs" Inherits="IKSIR.ECommerce.UI.Pages.OrderPaymentResult" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="sepet_content_middle">
        <div class="sepet_content_header">
            <img src="../images/sepet_sepet.jpg" alt="" />
            <h3>
                Ödeme Sonuç</h3>
            <h4>
                Ödemenizin başarıyla alınıp alınmadığının bilgisini verir.
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
