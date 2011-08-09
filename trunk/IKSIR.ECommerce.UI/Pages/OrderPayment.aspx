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
                Ödeme seçeneklerinden birini seçebilir kart bilgilerinizi girerek alışverişinizi
                tamamlayabilirsiniz.
            </h4>
        </div>
        <table>
            <tr>
                <td>
                    <table>
                        <tr>
                            <td colspan="2">
                                Ödeme seçenekleri
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <a href="#">Havale</a>
                            </td>
                            <td>
                                <a href="#">Kredi Kartı</a>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <asp:RadioButtonList runat="server" ID="rblTransferAccounts">
                                </asp:RadioButtonList>
                            </td>
                            <td valign="top">
                                <strong>Kredi Kartı bilgileri:</strong>
                                <br />
                                <table>
                                    <tr>
                                        <td>
                                            Kart Üzerindeki İsim
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtCustomerName"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Kart Numarası
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtCreditCardNumber"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Son Kullanma Tarihi
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <asp:DropDownList runat="server" ID="ddlMount">
                                                <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                            </asp:DropDownList>
                                            &nbsp;
                                            <asp:DropDownList runat="server" ID="ddlYear">
                                                <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            CVC2
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtCvv2" Width="20px"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
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
