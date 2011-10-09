<%@ Page Title="" Language="C#" MasterPageFile="/SecuredPages/UIDetailSecuredMasterPage.Master"
    AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="IKSIR.ECommerce.UI.SecuredPages.UserAccount.Orders" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
        Hesabım
    </h2>
    <p>
        Kullanıcı hesap biglileri görüntüleme, düzenleme.
    </p>
    <table cellpadding="0" cellspacing="0" border="0">
        <tr>
            <td align="left" colspan="2">
                <div id="divAlert" visible="false" runat="server">
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <div id="tabs">
                    <ul>
                        <li><a href="UserInfos.aspx"><span>Üye Bilgilerim</span></a></li>
                        <li><a href="Addresses.aspx"><span>Adreslerim</span></a></li>
                        <li><a href="Orders.aspx" style="background-position: 0% -42px;"><span style="background-position: 0% -42px;">
                            Siparişlerim</span></a></li>
                        <li><a href="FavoriteProducts.aspx"><span>Favori Ürünlerim</span></a></li>
                        <li><a href="ChangePassword.aspx"><span>Şifre Değiştir</span></a></li>
                    </ul>
                </div>
                <table>
                    <tr>
                        <td>
                            <strong>Sipariş</strong> (Geçmiş ve aktif siparişlerinizi listeleyin)
                        </td>
                    </tr>
                </table>
                <div id="dvMyOrder" runat="server" visible="false">
                    <table>
                        <tr>
                            <td>
                                Sipariş No
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblId"></asp:Label>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Ödeme Tipi
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:DropDownList runat="server" ID="ddlPaymentType">
                                </asp:DropDownList>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="1">
                                Sipariş Toplam Fiyatı
                            </td>
                            <td>
                                :
                            </td>
                            <td colspan="2">
                                <asp:Label runat="server" ID="lbltotalPrice"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="1">
                                Sipariş Vadeli Fiyat
                            </td>
                            <td>
                                :
                            </td>
                            <td colspan="2">
                                <asp:Label runat="server" ID="lbltotalRatedPrice"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Fatura Adres Detayı
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblBillingDetail"></asp:Label>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                İl
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblBillingCity"></asp:Label>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                İlçe
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblBillingDistrict"></asp:Label>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Posta Kodu
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblBillingPostalCode"></asp:Label>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <div id="dvAdress" runat="server" visible="false">
                                    <table>
                                        <tr>
                                            <td>
                                                Adres Detayı
                                            </td>
                                            <td>
                                                :
                                            </td>
                                            <td>
                                                <asp:Label runat="server" ID="lblDetail"></asp:Label>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                İl
                                            </td>
                                            <td>
                                                :
                                            </td>
                                            <td>
                                                <asp:Label runat="server" ID="lblCity"></asp:Label>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                İlçe
                                            </td>
                                            <td>
                                                :
                                            </td>
                                            <td>
                                                <asp:Label runat="server" ID="lblDistrict"></asp:Label>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Posta Kodu
                                            </td>
                                            <td>
                                                :
                                            </td>
                                            <td>
                                                <asp:Label runat="server" ID="lblPostalCode"></asp:Label>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:GridView runat="server" ID="gvBasketItems" AutoGenerateColumns="False" CellPadding="4"
                                    GridLines="None" PageSize="15" EnableModelValidation="True" Caption="Ürünler"
                                    CaptionAlign="Left">
                                    <Columns>
                                        <asp:TemplateField ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbtnAddress" runat="server" OnClick="lbtnAddress_Click" CommandArgument='<%# Eval("Id")%>'>[Adres Bilgisi]</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ShowHeader="False">
                                            <ItemTemplate>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Ürün Adı">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblTitle" Text='<%# Eval("Product.Title")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Ürün Kodu">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblProductCode" Text='<%# Eval("Product.ProductCode")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fiyat">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblPrice" Text='<%# Eval("ProductPrice.Price")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Mikarı">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblCount" Text='<%# Eval("Count")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </div>
                <div>
                    <table>
                        <tr>
                            <td>
                                Sipariş Durumu
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:DropDownList runat="server" ID="ddlFilterOrderStatus">
                                    <asp:ListItem Text="Bekleyen Siparişler" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Tamamlanan Siparişler" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="İptal olan Siparişler" Value="3"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Sipariş Numarası
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtOrderNo"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                Tarih aralığı girerek siparişlerinizi bulabilirsiniz.
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Başlangıç Tarihi
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:DropDownList runat="server" ID="ddlFilterOrderStarDateDay" Width="40px">
                                </asp:DropDownList>
                                /
                                <asp:DropDownList runat="server" ID="ddlFilterOrderStarDateMonth" Width="40px">
                                </asp:DropDownList>
                                /
                                <asp:DropDownList runat="server" ID="ddlFilterOrderStarDateYear" Width="60px">
                                </asp:DropDownList>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Bitiş Tarihi</td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:DropDownList runat="server" ID="ddlFilterOrderEndDateDay" Width="40px">
                                </asp:DropDownList>
                                /
                                <asp:DropDownList runat="server" ID="ddlFilterOrderEndDateMonth" Width="40px">
                                </asp:DropDownList>
                                /
                                <asp:DropDownList runat="server" ID="ddlFilterOrderEndDateYear" Width="60px">
                                </asp:DropDownList>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:Button runat="server" ID="btnFilter" Text="Listele" OnClick="btnFilter_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <strong>Liste</strong>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:GridView runat="server" ID="gvOrderList" AutoGenerateColumns="False" CellPadding="4"
                                    GridLines="None" PageSize="15" EnableModelValidation="True" EmptyDataText="Listede gösterilecek kayıt bulunamadı">
                                    <Columns>
                                        <asp:TemplateField ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbtnView" runat="server" OnClick="lbtnView_Click" CommandArgument='<%# Eval("Id")%>'>[Incele]</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Id" HeaderText="Id" ApplyFormatInEditMode="false" ReadOnly="true"
                                            SortExpression="Id" />
                                        <asp:TemplateField HeaderText="Adı">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblGvFirstName" Text='<%# Eval("User.FirstName")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Soyadı">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblGvLastName" Text='<%# Eval("User.LastName")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Ödeme Tipi">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblPaymentType" Text='<%# Eval("PaymetInfo.PaymentType.Value")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Durumu">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblStatus" Text='<%# Eval("Status.Value")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
