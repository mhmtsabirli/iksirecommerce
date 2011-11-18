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
                            <strong>Siparişlerim</strong> (Geçmiş ve aktif siparişlerinizi listeleyin)
                        </td>
                    </tr>
                </table>
                <div id="dvMyOrder" runat="server" visible="false">
                    <table width="100%">
                        <tr>
                            <td colspan="2">
                            <input type="hidden" value="" runat="server" id="CustomerOrderId" />
                                <span style="color: Red">Sipariş Detayı</span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span style="color: Red">Sevkiyat Bilgileri</span>
                            </td>
                            <td>
                                <span style="color: Red">Fatura Bilgileri</span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                            Ad Soyad
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <asp:Label runat="server" ID="lblShippingAddressNameSurName"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Adres
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <asp:Label runat="server" ID="lblShippingAddressDetail"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Telefon
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <asp:Label runat="server" ID="lblShippingAddressPhone"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                            Ad Soyad
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <asp:Label runat="server" ID="lblBillingAddressNameSurname"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Adres
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <asp:Label runat="server" ID="lblBillingAddressDetail"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Telefon
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <asp:Label runat="server" ID="lblBillingAddressPhone"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <span style="color: Red">Ürünler</span>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <table width="100%">
                                    <asp:Repeater runat="server" ID="rptBasketProducts">
                                        <HeaderTemplate>
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
                                            </tr>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td class="table_first">
                                                    <a href='<%# String.Format("ProductDetails.aspx?pid={0}", Eval("Product.Id"))%>'
                                                        target="_blank">
                                                        <%# Eval("Product.ProductCategory.Title")%>
                                                        /
                                                        <%# Eval("Product.Title")%>
                                                    </a>
                                                </td>
                                                <td class="table_second">
                                                    <%# Eval("Count")%>
                                                </td>
                                                <td class="table_third">
                                                    <%# Eval("Product.ProductPrice.Price")%>&nbsp;TL
                                                </td>
                                                <td class="table_fourth">
                                                    <%# Eval("ItemPrice")%>&nbsp;TL
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <span style="color: Red">Kargo Bilgileri</span>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <table>
                                    <tr>
                                        <td>
                                            Kargo Firması
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <asp:Label runat="server" ID="lblShippingCompanyName"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Kargo Tutarı
                                        </td>
                                        <td>
                                            :
                                        </td>
                                        <td>
                                            <asp:Label runat="server" ID="lblShippingPrice"></asp:Label>
                                            &nbsp;TL
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <span style="color: Red">Ödeme Tipi</span>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div class="sepet_content_footer" id="divBasketTotal" runat="server" style="float: right">
                                    <div style="float: right!important; text-align: right;">
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
                                                    <strong>
                                                        <asp:Label runat="server" ID="lblTotalPrice"></asp:Label>
                                                        &nbsp;TL</strong>
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
                                                    <strong>
                                                        <asp:Label runat="server" ID="lblTotalTax"></asp:Label>
                                                        &nbsp;TL</strong>
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
                                                    <strong>
                                                        <asp:Label runat="server" ID="lblBasketTotal"></asp:Label>
                                                        &nbsp;TL</strong>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Taksit Sayısı
                                                </td>
                                                <td>
                                                    :
                                                </td>
                                                <td>
                                                    <strong>
                                                        <asp:Label runat="server" ID="lblMonth"></asp:Label>
                                                    </strong>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </table>
                    <%--<table>
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
                    </table>--%>
                     <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Siparişi iptal Et" />&#160;<asp:Button
                                    
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
                                Bitiş Tarihi
                            </td>
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
