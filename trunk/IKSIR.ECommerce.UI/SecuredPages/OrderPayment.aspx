<%@ Page Title="" Language="C#" MasterPageFile="~/SecuredPages/UIDetailSecuredMasterPage.Master"
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
                Ödemenizin alınacağı sayfadır. Ödenmenizi kredi kartı ya da havale ile yapabilirsiniz.
            </h4>
        </div>
        <table width="100%">
            <tr>
                <td>
                    <strong>Sepeteki Ürünler</strong>
                    <br />
                    <asp:Repeater runat="server" ID="rptBasketProducts" OnItemDataBound="rptBasketProducts_ItemDataBound">
                        <HeaderTemplate>
                            <tr>
                                <td class="table_header">
                                    Ürün
                                </td>
                                <td class="table_header">
                                    Adet
                                </td>
                                <td class="table_header">
                                    Tutar
                                </td>
                                <td class="table_header">
                                    Toplam
                                </td>
                            </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td colspan="4">
                                    <a href='<%# String.Format("ProductDetails.aspx?pid={0}", Eval("Product.Id"))%>'
                                        target="_blank">
                                        <%# Eval("Product.ProductCategory.Title")%>
                                        /
                                        <%# Eval("Product.Title")%>
                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td class="table_first">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:HiddenField runat="server" ID="hdnProductId" Value='<%# Eval("Product.Id")%>' />
                                                <a href='<%# String.Format("ProductDetails.aspx?pid={0}", Eval("Product.Id"))%>'
                                                    target="_blank">
                                                    <asp:Image runat="server" ID="imgProduct" ImageUrl='<%# Eval("Product.MainImage", "http://banyom.com.tr/documents/Images/Small/small_{0:C}")%>'
                                                        BorderWidth="0  " />
                                                </a>
                                            </td>
                                            <td>
                                                <table>
                                                    <asp:Repeater runat="server" ID="rptProductProperties">
                                                        <ItemTemplate>
                                                            <tr>
                                                                <td>
                                                                    <%# Eval("Property.Title")%></strong>
                                                                </td>
                                                                <td>
                                                                    :
                                                                </td>
                                                                <td>
                                                                    <%# Eval("Value")%>
                                                                </td>
                                                            </tr>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td class="table_second">
                                    <asp:DropDownList ID="ddlItemCount" Enabled="false" runat="server" OnSelectedIndexChanged="ddlItemCount_SelectedIndexChanged"
                                        ToolTip='<%# Eval("Product.Id")%>' AutoPostBack="true">
                                    </asp:DropDownList>
                                </td>
                                <td class="table_third">
                                    <p>
                                        <%# Eval("ProductPrice.UnitPrice")%>
                                        TL</p>
                                </td>
                                <td class="table_fourth">
                                    <p>
                                        <%# Eval("BasketItemPrice")%>
                                        TL</p>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </td>
            </tr>
            <tr>
                <td>
                    <table width="100%">
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
                                <asp:RadioButtonList runat="server" ID="rblTransferAccount">
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
