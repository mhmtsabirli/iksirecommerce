<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCProductDetailsSimilarProducts.ascx.cs"
    Inherits="IKSIR.ECommerce.UI.UserControls.UCProductDetailsSimilarProducts" %>
<table>
    <tr>
        <td colspan="2">
            <strong>Benzer Ürünler</strong> <i>(Bu ürünle benzer alternatif ürünler)</i>
        </td>
    </tr>
    <asp:DataList runat="server" ID="dlShowCaseProducts" RepeatColumns="3" RepeatDirection="Horizontal">
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
</table>
