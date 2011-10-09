<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCProductDetailsSimilarProducts.ascx.cs"
    Inherits="IKSIR.ECommerce.UI.UserControls.UCProductDetailsSimilarProducts" %>
<table>
    <tr>
        <td colspan="2">
            <strong>Benzer Ürünler</strong> <i>(Bu ürünle benzer alternatif ürünler)</i>
        </td>
    </tr>
    <tr>
        <td>
            <asp:DataList runat="server" ID="dlShowCaseProducts" RepeatColumns="2">
                <ItemTemplate>
                    <table>
                        <tr>
                            <td valign="top" style="padding-left: 5px" colspan="3">
                                <asp:HiddenField runat="server" ID="hdnSimularProductId" Value='<%# Eval("Id")%>' />
                                <a href='<%# "../Pages/ProductDetails.aspx?pid="+ Eval("Id")%>'>
                                    <asp:Image runat="server" ID="imgProduct" />
                                </a>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" style="padding-left: 5px">
                                Ürün Adı
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <a href='<%# "../Pages/ProductDetails.aspx?pid="+ Eval("Id")%>'>
                                    <%# Eval("Title")%></a>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" style="padding-left: 5px">
                                Ürün Kodu
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <%# Eval("ProductCode")%>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
        </td>
    </tr>
</table>
