<%@ Page Title="" Language="C#" MasterPageFile="/SecuredPages/UIDetailSecuredMasterPage.Master"
    AutoEventWireup="true" CodeBehind="Addresses.aspx.cs" Inherits="IKSIR.ECommerce.UI.SecuredPages.UserAccount.Addresses" %>

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
                <div id="divAlert" runat="server">
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <div id="tabs">
                    <ul>
                        <li><a href="UserInfos.aspx"><span>Üye Bilgilerim</span></a></li>
                        <li><a href="Addresses.aspx" style="background-position: 0% -42px;"><span style="background-position: 0% -42px;">
                            Adreslerim</span></a></li>
                        <li><a href="Orders.aspx"><span>Siparişlerim</span></a></li>
                        <li><a href="FavoriteProducts.aspx"><span>Favori Ürünlerim</span></a></li>
                        <li><a href="ChangePassword.aspx"><span>Şifre Değiştir</span></a></li>
                    </ul>
                </div>
                <table>
                    <tr>
                        <td>
                            <strong>Adreslerim</strong> (Fatura ve teslimat adreslerinizi yönetin)
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table id="tblMngForm">
                                <tr>
                                    <td style="text-align: left" colspan="2">
                                        <asp:LinkButton runat="server" ID="lbtnNew" Text="Yeni Kayıt" OnClick="lbtnNew_Click"></asp:LinkButton>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Panel runat="server" ID="pnlForm" Visible="false" CssClass="pnlForm">
                                            <table>
                                                <tr>
                                                    <td colspan="4">
                                                        <strong>Adres Formu</strong>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Adres Başlığı
                                                    </td>
                                                    <td>
                                                        :
                                                    </td>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtAddressTitle"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Adres Tipi
                                                    </td>
                                                    <td>
                                                        :
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList runat="server" ID="ddlAddressType">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Ad
                                                    </td>
                                                    <td>
                                                        :
                                                    </td>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtFirstName"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Soyad
                                                    </td>
                                                    <td>
                                                        :
                                                    </td>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtLastName"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Ülke
                                                    </td>
                                                    <td>
                                                        :
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList runat="server" ID="ddlCountries" AutoPostBack="true" OnSelectedIndexChanged="ddlCountries_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Şehir
                                                    </td>
                                                    <td>
                                                        :
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList runat="server" ID="ddlCities" AutoPostBack="true" OnSelectedIndexChanged="ddlCities_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                        <asp:TextBox runat="server" ID="txtCity" Visible="false"></asp:TextBox>
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
                                                        <asp:DropDownList runat="server" ID="ddlDistricts">
                                                        </asp:DropDownList>
                                                        <asp:TextBox runat="server" ID="txtDistrict" Visible="false"></asp:TextBox>
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
                                                        <asp:TextBox runat="server" ID="txtPostCode"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top">
                                                        Adres
                                                    </td>
                                                    <td valign="top">
                                                        :
                                                    </td>
                                                    <td valign="top">
                                                        <asp:TextBox runat="server" ID="txtAddress" Width="250px" Height="50px" TextMode="MultiLine"></asp:TextBox>
                                                    </td>
                                                    <td valign="top">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Ev Telefonu
                                                    </td>
                                                    <td>
                                                        :
                                                    </td>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtPhone"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Cep Telefonu
                                                    </td>
                                                    <td>
                                                        :
                                                    </td>
                                                    <td>
                                                        <asp:TextBox runat="server" ID="txtGSMPhone"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" style="text-align: center">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" style="text-align: center">
                                                        <asp:Button runat="server" ID="btnAddressSave" Text="Kaydet" OnClick="btnAddressSave_Click" />
                                                        &nbsp;<asp:Button runat="server" ID="btnCancel" Text="Vazgeç" OnClick="btnCancel_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <br />
                                        <asp:Panel runat="server" ID="pnlList" Visible="true">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <strong>Adres Listesi</strong>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:GridView runat="server" ID="gvList" AutoGenerateColumns="False" CellPadding="4"
                                                            GridLines="None" PageSize="15" EnableModelValidation="True" Width="500px" EmptyDataText="Listede gösterilecek kayıt bulunamadı"
                                                            HeaderStyle-HorizontalAlign="Left">
                                                            <Columns>
                                                                <asp:TemplateField ShowHeader="False">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lbtnEdit" runat="server" OnClick="lbtnEdit_Click" CommandArgument='<%# Eval("Id")%>'>[Düzenle]</asp:LinkButton>
                                                                        <asp:LinkButton ID="lbtnDelete" runat="server" OnClick="lbtnDelete_Click" CommandArgument='<%# Eval("Id")%>'
                                                                            OnClientClick="javascript:return confirm('Bu kaydı silmek istediğinize emin misiniz?');"
                                                                            CausesValidation="false" ForeColor="Red">[Sil]</asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Adres Tipi">
                                                                    <ItemTemplate>
                                                                        <asp:Label runat="server" ID="lblAddressType" Text='<%# Eval("Type.Value")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="Title" HeaderText="Adres Tanımı" ApplyFormatInEditMode="false"
                                                                    ReadOnly="true" SortExpression="Title" />
                                                                <asp:BoundField DataField="FirstName" HeaderText="İsim" ApplyFormatInEditMode="false"
                                                                    ReadOnly="true" SortExpression="FirstName" />
                                                                <asp:BoundField DataField="LastName" HeaderText="Soyisim" ApplyFormatInEditMode="false"
                                                                    ReadOnly="true" SortExpression="LastName" />
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
