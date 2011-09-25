<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCProductDetailsRelatedProducts.ascx.cs"
    Inherits="IKSIR.ECommerce.UI.UserControls.UCProductDetailsRelatedProducts" %>
<table>
    <tr>
        <td colspan="2">
            <strong>İlişkili Ürünler</strong> <i>(Bu ürünle birlikte alınabilecek ilişkili ürünler)</i>
        </td>
    </tr>
    <asp:DataList runat="server" ID="dlShowCaseProducts" RepeatColumns="3" RepeatDirection="Horizontal">
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
</table>
