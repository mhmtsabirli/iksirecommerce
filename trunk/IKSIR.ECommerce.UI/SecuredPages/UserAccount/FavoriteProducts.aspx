<%@ Page Title="" Language="C#" MasterPageFile="/SecuredPages/UIDetailSecuredMasterPage.Master"
    AutoEventWireup="true" CodeBehind="FavoriteProducts.aspx.cs" Inherits="IKSIR.ECommerce.UI.SecuredPages.UserAccount.FavoriteProducts" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main" style="padding-left: 10px; margin-left: 200px">
        <h2>
            Hesabım
        </h2>
        <p>
            Kullanıcı hesap biglileri görüntüleme, düzenleme.
        </p>
        <table cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td align="left" colspan="2">
                    <div id="divAlert" runat="server">
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div id="tabs">
                        <ul>
                            <li><a href="UserInfos.aspx"><span>Üye Bilgilerim</span></a></li>
                            <li><a href="Addresses.aspx"><span>Adreslerim</span></a></li>
                            <li><a href="Orders.aspx"><span>Siparişlerim</span></a></li>
                            <li><a href="FavoriteProducts.aspx" style="background-position: 0% -42px;"><span
                                style="background-position: 0% -42px;">Favori Ürünlerim</span></a></li>
                            <li><a href="ChangePassword.aspx"><span>Şifre Değiştir</span></a></li>
                        </ul>
                    </div>
                    <table>
                        <tr>
                            <td>
                                <strong>Favori Ürünlerim</strong> (Favorilerinize eklediğiniz ürünler)
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label runat="server" ID="lblNoUserFavoriteProducts" Text="Henüz hiç favori ürün eklememişsiniz."></asp:Label>
                                <table>
                                    <asp:Repeater runat="server" ID="rptUserFavoriteProducts">
                                        <ItemTemplate>
                                            <tr>
                                                <td valign="top" align="center">
                                                    <asp:HiddenField runat="server" ID="hdnProductId" Value='<%# Eval("Product.Id")%>' />
                                                    <a href='<%# String.Format("/Pages/ProductDetails.aspx?pid={0}", Eval("Product.Id"))%>'
                                                        target="_blank">
                                                        <asp:Image runat="server" ID="imgProduct" ImageUrl='<%# Eval("Product.MainImage", "https://banyom.com.tr/management/ProductDocuments/Images/Small/small_{0:C}")%>'
                                                            BorderWidth="0  " />
                                                    </a>
                                                </td>
                                                <td valign="top">
                                                    <h2>
                                                        <a href='<%# String.Format("/Pages/ProductDetails.aspx?pid={0}", Eval("Product.Id"))%>'
                                                            target="_blank">
                                                            <%# Eval("Product.ProductCategory.Title")%>
                                                            /
                                                            <%# Eval("Product.Title")%>
                                                        </a>
                                                    </h2>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
