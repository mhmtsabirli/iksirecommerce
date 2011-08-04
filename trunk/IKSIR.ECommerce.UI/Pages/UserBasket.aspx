<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/UIDetailMasterPage.Master"
    AutoEventWireup="true" CodeBehind="UserBasket.aspx.cs" Inherits="IKSIR.ECommerce.UI.Pages.UserBasket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="sepet_content_middle">
        <div class="sepet_content_header">
            <img src="../images/sepet_sepet.jpg" alt="" />
            <h4>
            </h4>
            <h3>
                Alışveriş Sepetiniz</h3>
            <div class="clear">
            </div>
        </div>
        <table>
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
                <td class="table_header">
                </td>
            </tr>
            <asp:Repeater runat="server" ID="rptBasketProducts" OnItemDataBound="rptBasketProducts_ItemDataBound"
                OnItemCommand="rptBasketProducts_ItemCommand">
                <ItemTemplate>
                    <tr>
                        <td class="table_first"> 
                            <asp:HiddenField runat="server" ID="hdnProductId" Value='<%# Eval("Product.Id")%>' />
                            <asp:Image runat="server" ID="imgProduct" ImageUrl='<%# Eval("Product.MainImage", "http://212.58.8.103/documents/Images/Small/small_{0:C}")%>' />
                            <h2>
                                <%# Eval("Product.ProductCategory.Title")%>
                                /
                                <%# Eval("Product.Title")%></h2>
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
                            <div class="clear">
                            </div>
                        </td>
                        <td class="table_second">
                            <form action="">
                            <asp:TextBox runat="server" ID="txtItemCount" CssClass="table_second_text" Text='<%# Eval("Count")%>'></asp:TextBox><br />
                            <asp:ImageButton runat="server" ID="imgbtnRefreshItemCount" ImageUrl="../images/table_second_guncelle.png"
                                CommandName="Refresh" CommandArgument='<%# Eval("Product.Id")%>' />
                            </form>
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
                        <td class="table_fifth">
                            <a href="#">
                                <asp:ImageButton runat="server" ID="imgbtnDeleteItem" ImageUrl="../images/table_fifth_one.jpg"
                                    CommandName="Delete" CommandArgument='<%# Eval("Product.Id")%>' />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <div class="sepet_content_footer">
            <div style="float: right!important; text-align: left;">
                <br />
                <strong>Sepet Toplamı:</strong>
                <br />
                <table>
                    <tr>
                        <td>
                            Toplam Ürün Tutarı
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <strong><asp:Label runat="server" ID="lblBasketTotal"></asp:Label> TL</strong>
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
                            <strong><asp:Label runat="server" ID="lblTotalTax"></asp:Label> TL</strong>
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
                            <strong><asp:Label runat="server" ID="lblTotalPrice"></asp:Label>  TL</strong>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="sepet_content_end">
            <a href="#">
                <img src="../images/sepet_end_iptal.jpg" alt="" /></a> <a href="#">
                    <img src="../images/sepet_end_devam.jpg" alt="" /></a>
        </div>
    </div>
    <div class="sepet_content_bottom">
    </div>
</asp:Content>
