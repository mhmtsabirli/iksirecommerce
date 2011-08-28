<%@ Page Title="" Language="C#" MasterPageFile="~/SecuredPages/UIDetailSecuredMasterPage.Master"
    AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="IKSIR.ECommerce.UI.SecuredPages.Order" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="sepet_content_middle">
        <div class="sepet_content_header">
            <img src="../images/sepet_sepet.jpg" alt="" />
            <h3>
                Sipariş Tamamlanmıştır</h3>
            <h4>
                Merhaba Sayın
                <asp:Label Font-Size="Large" runat="server" ID="lblUser"></asp:Label>
            </h4>
        </div>
        <table>
            <tr>
                <td>
                    Senar İnşaat Yatırımları San. Tic. Ltd. Şti'nin sağlamış olduğu banyom.com.tr online
                    alışveriş sitesinden vermiş olduğunuz siparişiniz başarıyla tamamlanmıştır. Sipariş
                    Numaranız :
                    <asp:Label Font-Size="Large" runat="server" ID="lblOrderNo"></asp:Label>
                    olup, siparişiniz kargoya verildiğinde tarafınıza e-mail ile bilgi verilecektir.
                </td>
            </tr>
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
                                        <asp:DropDownList ID="ddlItemCount" Enabled="false" runat="server" ToolTip='<%# Eval("Product.Id")%>'
                                            AutoPostBack="true">
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
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="5" align="right" style="text-align: right;">
                    <div class="sepet_content_footer" id="divBasketTotal" runat="server" style="float: right">
                        <div style="float: right!important; text-align: right;">
                            <br />
                            <strong>Sipariş Toplamı:</strong>
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
                            </table>
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
