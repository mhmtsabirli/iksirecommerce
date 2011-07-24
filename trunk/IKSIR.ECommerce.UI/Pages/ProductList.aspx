<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/UIMasterPage.Master"
    AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="IKSIR.ECommerce.UI.Pages.ProductList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DataList runat="server" ID="dlProductList" RepeatColumns="3" RepeatDirection="Horizontal">
        <ItemTemplate>
        <asp:HiddenField runat="server" ID="hdnProductId" Value='<%# Eval("Id")%>' />
             <div class="section">
            <h3>
                <%# Eval("ProductCategory.Title")%>
            </h3>
            <div class="section_image">
                <asp:Image runat="server" ID="imgProduct" /></div>
            <div class="section_info">
                <table>
                    <tr>
                        <td>
                            Ürün Kodu
                        </td>
                        <td>
                            :
                        </td>
                        <td style="color: #848484;">
                            <%# Eval("ProductCode")%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Ürün Adı
                        </td>
                        <td>
                            :
                        </td>
                        <td style="color: #848484;">
                            <%# Eval("Title")%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Fiyatı
                        </td>
                        <td>
                            :
                        </td>
                        <td style="color: #094073;">
                            <%# Eval("ProductPrice.UnitPrice")%>
                            TL + KDV
                        </td>
                    </tr>
                </table>
            </div>
            <div class="section_links">
                <a href='<%# "../Pages/ProductDetails.aspx?pid="+ Eval("Id")%>'>
                    <img src="../images/section_incele.jpg" alt="" /></a> <a href="#">
                        <img src="../images/section_sepete_ekle.jpg" alt="" /></a>
            </div>
        </div>
        </ItemTemplate>
    </asp:DataList>
    <div class="page_array">
        <asp:DataList runat="server" ID="dlPaging" RepeatColumns="10" RepeatDirection="Horizontal"
            OnItemDataBound="dlPaging_ItemDataBound">
            <ItemTemplate>
                <asp:HyperLink runat="server" ID="hplPageNo" Text='<%# Eval("Key")%>' NavigateUrl='<%# Eval("Value")%>'></asp:HyperLink>
            </ItemTemplate>
        </asp:DataList>
        <div class="clear">
        </div>
    </div>
</asp:Content>
