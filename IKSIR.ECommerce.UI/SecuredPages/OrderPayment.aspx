<%@ Page Title="" Language="C#" MasterPageFile="/SecuredPages/UIDetailSecuredMasterPage.Master"
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
        <table>
            <tr>
                <td>
                    <strong>Sepeteki Ürünler</strong>
                    <br />
                    <table>
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
                                                        <asp:Image runat="server" ID="imgProduct" ImageUrl='<%# Eval("Product.MainImage", "https://www.banyom.com.tr/management/ProductDocuments/Images/Small/small_{0:C}")%>'
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
                                        <asp:DropDownList ID="ddlItemCount" Enabled="false" runat="server" ToolTip='<%# Eval("Product.Id")%>'
                                            AutoPostBack="true">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="table_third">
                                        <p>
                                            <asp:Label runat="server" ID="lblUnitPrice" Text='<%# Eval("ProductPrice.UnitPrice")%>'></asp:Label>&nbsp;TL</p>
                                    </td>
                                    <td class="table_fourth">
                                        <p>
                                            <asp:Label runat="server" ID="lblBasketItemPrice" Text='<%# Eval("BasketItemPrice")%>'></asp:Label>&nbsp;TL</p>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="5" align="right" style="text-align: right;">
                    <div class="sepet_content_footer" id="divBasketTotal" runat="server" style="float: right">
                        <div style="float: right!important; text-align: right;">
                            <br />
                            <strong>Sepet Toplamı:</strong>
                            <br />
                            <table>
                                <tr>
                                    <td>
                                        Kargo Tutarı
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <strong>
                                            <asp:Label runat="server" ID="lblShippingPrice"></asp:Label>
                                            TL</strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Toplam Ürün Tutarı
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <strong>
                                            <asp:Label runat="server" ID="lblTotalPrice"></asp:Label>
                                            TL</strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Toplam KDV
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <strong>
                                            <asp:Label runat="server" ID="lblTotalTax"></asp:Label>
                                            TL</strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Toplam Ödenecek Tutar
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <strong>
                                            <asp:Label runat="server" ID="lblBasketTotal"></asp:Label>
                                            TL</strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Taksit Sayısı
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <strong>
                                            <asp:Label runat="server" ID="lblMonth"></asp:Label>
                                        </strong>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <table width="100%">
                        <tr>
                            <td colspan="2">
                                <strong>Ödeme seçenekleri</strong>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <a href="#">Ödeme Tipi</a>
                            </td>
                            <td>
                                <asp:DropDownList runat="server" ID="ddlPaymentType" AutoPostBack="true" OnSelectedIndexChanged="ddlPaymentType_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div id="DvTransferAccount" runat="server" visible="false">
                                    <asp:RadioButtonList runat="server" ID="rblTransferAccount" Width="100%">
                                    </asp:RadioButtonList>
                                </div>
                                <div id="DvCreditCard" runat="server" visible="false">
                                    <strong>Kredi Kartı bilgileri:</strong>
                                    <br />
                                    <br />
                                    <table width="100%">
                                        <tr>
                                            <td>
                                                Kredi Kartı
                                            </td>
                                            <td>
                                                :
                                            </td>
                                            <td>
                                                <asp:DropDownList runat="server" ID="ddlCreditCard" AutoPostBack="true" OnSelectedIndexChanged="ddlCreditCard_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Taksit / Vade
                                            </td>
                                            <td>
                                                :
                                            </td>
                                            <td>
                                                <asp:DropDownList runat="server" ID="ddlCreditCardMonth" AutoPostBack="true" OnSelectedIndexChanged="ddlCreditCardMonth_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:Label runat="server" ID="lblRate"></asp:Label>
                                            </td>
                                        </tr>
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
                                                <asp:DropDownList runat="server" ID="ddlMonth">
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
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
            <td>
                Blgi:<br />
                <div id="divAlert" runat="server" class="scrolledDiv">
                </div>
            </td></tr>
            <tr>
                <td align="center">
                <asp:ImageButton runat="server" ID="imgbtnBack" 
                        ImageUrl="/images/sepet_end_iptal.jpg" AlternateText="Geri" 
                        onclick="imgbtnBack_Click" />
                    <asp:ImageButton ID="btnApprove" runat="server" OnClick="btnApprove_Click" ImageUrl="../images/sepet_end_devam.jpg" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
