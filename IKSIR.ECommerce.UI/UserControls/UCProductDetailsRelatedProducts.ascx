<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCProductDetailsRelatedProducts.ascx.cs"
    Inherits="IKSIR.ECommerce.UI.UserControls.UCProductDetailsRelatedProducts" %>
<table>
    <tr>
        <td>
            <strong>İlişkili Ürünler</strong> <i>(Bu ürünle birlikte alınabilecek ilişkili ürünler)</i>
        </td>
    </tr>
    <tr>
        <td>
            <asp:DataList runat="server" ID="dlShowCaseProducts" RepeatColumns="2">
                <ItemTemplate>
                    <table>
                        <tr>
                            <td valign="top" style="padding-left: 5px" colspan="3">
                                <asp:HiddenField runat="server" ID="hdnRelatedProductId" Value='<%# Eval("Id")%>' />
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
