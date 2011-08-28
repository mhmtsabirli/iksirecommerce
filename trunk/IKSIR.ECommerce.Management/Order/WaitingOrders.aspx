<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterManagement.Master"
    AutoEventWireup="true" CodeBehind="WaitingOrders.aspx.cs" Inherits="IKSIR.ECommerce.Management.Order.WaitingOrders" %>

<%@ Register Assembly="RadAjax.Net2" Namespace="Telerik.WebControls" TagPrefix="rad" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <h2>
        Bekleyen Siparişler</h2>
    <p>
        Tamamlanmamış siparişlerin düzenlendiği Ekran
    </p>
    <table id="tblMngForm">
        <tr>
            <td colspan="2">
                Blgi:<br />
                <div id="divAlert" runat="server" class="scrolledDiv">
                </div>
            </td>
        </tr>
        <tr>
            <td align="left">
                <asp:Label runat="server" ID="lblError" Visible="false"></asp:Label>
            </td>
            <td style="text-align: right">
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <asp:Panel runat="server" ID="pnlForm" Visible="false" CssClass="pnlForm">
                    <telerik:RadTabStrip ID="RadTabStrip1" runat="server" Skin="Web20" MultiPageID="RadMultiPage1"
                        SelectedIndex="1" Width="600px">
                        <Tabs>
                            <telerik:RadTab Text="Müşteri Bilgleri" Selected="true" PageViewID="RadPageView1">
                            </telerik:RadTab>
                            <telerik:RadTab Text="Ürün Bilgileri" PageViewID="RadPageView2">
                            </telerik:RadTab>
                            <telerik:RadTab Text="Ödeme Bilgleri" PageViewID="RadPageView3">
                            </telerik:RadTab>
                            <telerik:RadTab Text="Fatura Bilgileri" PageViewID="RadPageView4">
                            </telerik:RadTab>
                        </Tabs>
                    </telerik:RadTabStrip>
                    <telerik:RadMultiPage ID="RadMultiPage1" runat="server">
                        <telerik:RadPageView ID="RadPageView1" runat="server" Selected="true">
                            <table>
                                <tr>
                                    <td colspan="4">
                                        <strong>Müşeri Bilgileri</strong> (Müşteri Genel Bilgileri)
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Id
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblUserId"></asp:Label>
                                        <asp:Label runat="server" ID="lblId" Visible="false"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Tc Kimlik No
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblTcIdentity"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Adı
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblFirstName"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Soyadı
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblLastName"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Email
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblEmail"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Cep Telefon
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblMobilePhone"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </telerik:RadPageView>
                        <telerik:RadPageView ID="RadPageView2" runat="server">
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
                            <asp:GridView runat="server" ID="gvBasketItems" AutoGenerateColumns="False" CellPadding="4"
                                GridLines="None" PageSize="15" EnableModelValidation="True" Width="100%" Caption="Ürünler"
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
                                            <asp:Label runat="server" ID="lblPrice" Text='<%# Eval("ItemPrice")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mikarı">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblCount" Text='<%# Eval("Count")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </telerik:RadPageView>
                        <telerik:RadPageView ID="RadPageView3" runat="server">
                            <table>
                                <tr>
                                    <td colspan="4">
                                        <strong>Ödeme Bilgileri</strong> (Sipariş Ödeme Bilgileri)
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Id
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <asp:Label runat="server" ID="lblPaymentInfoId"></asp:Label>
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
                                        <asp:DropDownList runat="server" ID="ddlPaymentType" AutoPostBack="true" OnSelectedIndexChanged="ddlPaymentType_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <div id="DvTransferAccount" runat="server" visible="false">
                                            <table>
                                                <tr>
                                                    <td>
                                                        Havale Hesabı
                                                    </td>
                                                    <td>
                                                        :
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList runat="server" ID="ddlTransferAccount">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div id="DvCreditCard" runat="server" visible="false">
                                            <table>
                                                <tr>
                                                    <td>
                                                        Kredi Kartı
                                                    </td>
                                                    <td>
                                                        :
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList runat="server" ID="ddlCreditCard">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Banka
                                                    </td>
                                                    <td>
                                                        :
                                                    </td>
                                                    <td>
                                                        <asp:Label runat="server" ID="lblBank"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Taksit / Vade
                                                    </td>
                                                    <td>
                                                        :
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList runat="server" ID="ddlMonth">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:Label runat="server" ID="lblRate"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Kredi Kart Üzerindeki İsim
                                                    </td>
                                                    <td>
                                                        :
                                                    </td>
                                                    <td>
                                                        <asp:Label runat="server" ID="lblCardName"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Kredi Kart Numarası
                                                    </td>
                                                    <td>
                                                        :
                                                    </td>
                                                    <td>
                                                        <asp:Label runat="server" ID="lblCardNumber"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Kredi Kart Son Kullanma Tarihi
                                                    </td>
                                                    <td>
                                                        :
                                                    </td>
                                                    <td>
                                                        <asp:Label runat="server" ID="lblExDate"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Kredi Kart CVV
                                                    </td>
                                                    <td>
                                                        :
                                                    </td>
                                                    <td>
                                                        <asp:Label runat="server" ID="lblCvv"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="1">
                                        Sipariş Toplam Fiyatı
                                    </td>
                                    <td colspan="3">
                                        <asp:Label runat="server" ID="lbltotalPrice"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="1">
                                        Sipariş Vadeli Fiyat
                                    </td>
                                    <td colspan="3">
                                        <asp:Label runat="server" ID="lbltotalRatedPrice"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </telerik:RadPageView>
                        <telerik:RadPageView ID="RadPageView4" runat="server">
                            <table>
                                <tr>
                                    <td colspan="4">
                                        <strong>Fatura Bilgileri</strong> (Fatura Adres Bilgileri)
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
                            </table>
                        </telerik:RadPageView>
                    </telerik:RadMultiPage>
                    <table>
                        <tr>
                            <td colspan="4" style="text-align: center">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" style="text-align: center">
                                <asp:Button ID="btnApprove" runat="server" OnClick="btnApprove_Click" Text="Siparişi Onayla" />&#160;
                                <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Siparişi iptal Et" />&#160;<asp:Button
                                    ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Vazgeç" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel runat="server" ID="pnlFilter" Visible="true">
                    <table>
                        <tr>
                            <td colspan="4">
                                <strong>Filtre</strong>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Sipariş Durumu
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:DropDownList runat="server" ID="ddlFilterOrderStatus">
                                </asp:DropDownList>
                            </td>
                            <td rowspan="2">
                                <asp:Button runat="server" ID="btnFilter" Text="Filtrele" OnClick="btnFilter_Click" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <br />
                <asp:Panel runat="server" ID="pnlList" Visible="true">
                    <table>
                        <tr>
                            <td colspan="4">
                                <strong>Liste</strong>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:GridView runat="server" ID="gvList" AutoGenerateColumns="False" CellPadding="4"
                                    GridLines="None" PageSize="15" EnableModelValidation="True" Width="100%" EmptyDataText="Listede gösterilecek kayıt bulunamadı">
                                    <Columns>
                                        <asp:TemplateField ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbtnEdit" runat="server" OnClick="lbtnEdit_Click" CommandArgument='<%# Eval("Id")%>'>[Düzenle]</asp:LinkButton>
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
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
        </tr>
    </table>
</asp:Content>
