<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCProductDetailsRelatedAndSimilarProducts.ascx.cs"
    Inherits="IKSIR.ECommerce.UI.UserControls.UCProductDetailsRelatedAndSimilarProducts" %>
<table width="100%">
    <tr>
        <td valign="top">
            <table width="400px">
                <tr>
                    <td>
                        <strong>İlişkili Ürünler</strong> <i>(Bu ürünle birlikte alınabilecek ilişkili ürünler)</i>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DataList runat="server" ID="dlRelatedProducts" RepeatColumns="3" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:HiddenField runat="server" ID="hdnRelatedProductId" Value='<%# Eval("Id")%>' />
                                        <a href='<%# "../Pages/ProductDetails.aspx?pid="+ Eval("Id")%>'>
                                            <asp:Image runat="server" ID="imgProduct" />
                                        </a>
                                    </td>
                                    <td valign="top">
                                        Ürün Adı: <a href='<%# "../Pages/ProductDetails.aspx?pid="+ Eval("Id")%>'>
                                            <%# Eval("Title")%></a>
                                        <br />
                                        Ürün Kodu:
                                        <%# Eval("ProductCode")%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:DataList>
                    </td>
                </tr>
            </table>
        </td>
        <td valign="top">
            <table width="400px">
                <tr>
                    <td>
                        <strong>Benzer Ürünler</strong> <i>(Bu ürünle benzer alternatif ürünler)</i>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DataList runat="server" ID="dlSimilarProducts" RepeatColumns="3" RepeatDirection="Horizontal">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:HiddenField runat="server" ID="hdnSimularProductId" Value='<%# Eval("Id")%>' />
                                        <a href='<%# "../Pages/ProductDetails.aspx?pid="+ Eval("Id")%>'>
                                            <asp:Image runat="server" ID="imgProduct" />
                                        </a>
                                    </td>
                                    <td valign="top">
                                        Ürün Adı: <a href='<%# "../Pages/ProductDetails.aspx?pid="+ Eval("Id")%>'>
                                            <%# Eval("Title")%></a>
                                        <br />
                                        Ürün Kodu:
                                        <%# Eval("ProductCode")%>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:DataList>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
