<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/UIMasterPage.Master"
    AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="IKSIR.ECommerce.UI.Pages.ProductList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DataList runat="server" ID="dlProductList" RepeatColumns="3" RepeatDirection="Horizontal">
        <ItemTemplate>
            <div class="section">
                <h3>
                    <asp:Label runat="server" ID="lblProductCategoryName" Text='<%# Eval("ProductCategory.Title")%>'></asp:Label>
                </h3>
                <div class="section_image">
                    <asp:Image runat="server" ID="imgProductImage" AlternateText="" /></div>
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
                                <asp:Label runat="server" ID="lblProductCode" Text='<%# Eval("ProductCode")%>'></asp:Label>
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
                                <asp:Label runat="server" ID="lblProductName" Text='<%# Eval("Title")%>'></asp:Label>
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
                                <asp:Label runat="server" ID="lblProductPrice" Text="lblProductPrice"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="section_links">
                    <a href="#">
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
    <%--<asp:GridView runat="server" ID="gvProductList" AutoGenerateColumns="false">
        <Columns>
            <asp:TemplateField>
                <AlternatingItemTemplate>
                    <div class="section">
                        <h3>
                            <asp:Label runat="server" ID="lblProductCategoryName" Text='<%# Eval("ProductCategory.Title")%>'></asp:Label>
                        </h3>
                        <div class="section_image">
                            <asp:Image runat="server" ID="imgProductImage" AlternateText="" /></div>
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
                                        <asp:Label runat="server" ID="lblProductCode" Text='<%# Eval("ProductCode")%>'></asp:Label>
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
                                        <asp:Label runat="server" ID="lblProductName" Text='<%# Eval("Title")%>'></asp:Label>
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
                                        <asp:Label runat="server" ID="lblProductPrice" Text="lblProductPrice"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="section_links">
                            <a href="#">
                                <img src="../images/section_incele.jpg" alt="" /></a> <a href="#">
                                    <img src="../images/section_sepete_ekle.jpg" alt="" /></a>
                        </div>
                    </div>
                </AlternatingItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <AlternatingItemTemplate>
                    <div class="section">
                        <h3>
                            <asp:Label runat="server" ID="lblProductCategoryName" Text='<%# Eval("ProductCategory.Title")%>'></asp:Label>
                        </h3>
                        <div class="section_image">
                            <asp:Image runat="server" ID="imgProductImage" AlternateText="" /></div>
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
                                        <asp:Label runat="server" ID="lblProductCode" Text='<%# Eval("ProductCode")%>'></asp:Label>
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
                                        <asp:Label runat="server" ID="lblProductName" Text='<%# Eval("Title")%>'></asp:Label>
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
                                        <asp:Label runat="server" ID="lblProductPrice" Text="lblProductPrice"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="section_links">
                            <a href="#">
                                <img src="../images/section_incele.jpg" alt="" /></a> <a href="#">
                                    <img src="../images/section_sepete_ekle.jpg" alt="" /></a>
                        </div>
                    </div>
                </AlternatingItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <AlternatingItemTemplate>
                    <div class="section">
                        <h3>
                            <asp:Label runat="server" ID="lblProductCategoryName" Text='<%# Eval("ProductCategory.Title")%>'></asp:Label>
                        </h3>
                        <div class="section_image">
                            <asp:Image runat="server" ID="imgProductImage" AlternateText="" /></div>
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
                                        <asp:Label runat="server" ID="lblProductCode" Text='<%# Eval("ProductCode")%>'></asp:Label>
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
                                        <asp:Label runat="server" ID="lblProductName" Text='<%# Eval("Title")%>'></asp:Label>
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
                                        <asp:Label runat="server" ID="lblProductPrice" Text="lblProductPrice"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="section_links">
                            <a href="#">
                                <img src="../images/section_incele.jpg" alt="" /></a> <a href="#">
                                    <img src="../images/section_sepete_ekle.jpg" alt="" /></a>
                        </div>
                    </div>
                </AlternatingItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>--%>
</asp:Content>
