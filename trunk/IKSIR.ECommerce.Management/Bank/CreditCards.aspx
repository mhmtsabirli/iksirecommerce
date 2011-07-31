<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterManagement.Master"
    AutoEventWireup="true" ValidateRequest="false" CodeBehind="CreditCards.aspx.cs"
    Inherits="IKSIR.ECommerce.Management.Bank.CreditCards" %>

<%@ Register Assembly="RadAjax.Net2" Namespace="Telerik.WebControls" TagPrefix="rad" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <h2>
        Kredi Kartı Tanımlama
    </h2>
    <p>
        Kredi Kartı Bilgileri güncelleme ve tanımlama ekranı
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
                <asp:LinkButton runat="server" ID="lbtnNew" Text="Yeni Kayıt" OnClick="lbtnNew_Click"></asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <asp:Panel runat="server" ID="pnlForm" Visible="false" CssClass="pnlForm">
                    <telerik:RadTabStrip ID="RadTabStrip1" runat="server" Skin="Web20" MultiPageID="RadMultiPage1"
                        SelectedIndex="1" Width="400px">
                        <Tabs>
                            <telerik:RadTab Text="Kredi Kartı Bilgileri" Selected="true" PageViewID="RadPageView1">
                            </telerik:RadTab>
                            <telerik:RadTab Text="Vade Oranları" PageViewID="RadPageView2">
                            </telerik:RadTab>
                        </Tabs>
                    </telerik:RadTabStrip>
                    <telerik:RadMultiPage ID="RadMultiPage1" runat="server">
                        <telerik:RadPageView ID="RadPageView1" runat="server" Selected="true">
                            <table>
                                <tr>
                                    <td colspan="4">
                                        <strong>Kredi Kartı Formu</strong> (Kredi Kartı Bilgileri)
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
                                        <asp:Label runat="server" ID="lblCreditCardId" Visible="false" Text=""></asp:Label>
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
                                        <asp:DropDownList runat="server" ID="ddlBanks">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator8" ControlToValidate="ddlBanks"
                                            ValidationGroup="VGForm" SetFocusOnError="true" InitialValue="-1" ErrorMessage="Banka seçmelisiniz"
                                            ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Kredi Kart Adı
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" Width="100%" ID="txtName"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator runat="server" ID="rfv1" ControlToValidate="txtName"
                                            ValidationGroup="VGForm" SetFocusOnError="true" ErrorMessage="Kart Adı Girmelisiniz"
                                            ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Imaj
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <telerik:RadUpload ID="ruCreditCardImage" runat="server" InitialFileInputsCount="2"
                                            MaxFileInputsCount="1" AllowedFileExtensions=".jpg,.jpeg,.pdf,.doc,.gif,.png"
                                            Localization-Select="Seç" />
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:Image ID="CardImage" Width="50px" Height="24px" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Kredi Kart Durumu
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlCreditCardStatus">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator13" ControlToValidate="ddlCreditCardStatus"
                                            ValidationGroup="VGForm" SetFocusOnError="true" InitialValue="-1" ErrorMessage="Kredi Kart Durumu seçmelisiniz"
                                            ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                            </table>
                        </telerik:RadPageView>
                        <telerik:RadPageView ID="RadPageView2" runat="server">
                            <table>
                                <tr>
                                    <td colspan="4">
                                        <strong>Vade Oranları</strong> (Kredi kartı için vade ve oranlarının tanımlanması)
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
                                        <asp:Label runat="server" ID="lblPaymetTermRateId" Text="Yeni Kayıt"></asp:Label>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Vade ( Ay )
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" Width="50px" ID="txtMonth"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="txtMonth"
                                            ValidationGroup="vgTermRate" SetFocusOnError="true" ErrorMessage="Vade ( Ay ) Girmelisiniz"
                                            ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Vade Oranı
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:TextBox runat="server" ID="txtRateOne"></asp:TextBox>
                                                </td>
                                                <td>
                                                    ,
                                                </td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="txtRateTwo"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator5" ControlToValidate="txtRateOne"
                                            ValidationGroup="vgTermRate" SetFocusOnError="true" ErrorMessage="Lütfen 00,00 şeklinde Giriniz"
                                            ForeColor="Red">*</asp:RequiredFieldValidator>
                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator9" ControlToValidate="txtRateTwo"
                                            ValidationGroup="vgTermRate" SetFocusOnError="true" ErrorMessage="Lütfen 00,00 şeklinde Giriniz"
                                            ForeColor="Red">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtRateOne"
                                            ErrorMessage="RegularExpressionValidator" ValidationExpression="\d*">* Sadece Sayı Girilebilir</asp:RegularExpressionValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtRateTwo"
                                            ErrorMessage="RegularExpressionValidator" ValidationExpression="\d*">* Sadece Sayı Girilebilir</asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Vade Durumu
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlRate">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="ddlRate"
                                            ValidationGroup="vgTermRate" SetFocusOnError="true" InitialValue="-1" ErrorMessage="Vade Durumu seçmelisiniz"
                                            ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: center" colspan="4">
                                        <asp:Label ID="lblPropertyAlert" runat="server" Visible="false"></asp:Label>
                                        <asp:ValidationSummary runat="server" ID="vsProductProperties" ValidationGroup="vgTermRate"
                                            ForeColor="Red" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: center" colspan="4">
                                        <asp:Button ID="btnAddTermRate" runat="server" Text="Vade Kaydet" ValidationGroup="vgTermRate"
                                            OnClick="btnAddTermRate_Click" />
                                    </td>
                                </tr>
                            </table>
                            <asp:GridView runat="server" ID="gvTermRate" AutoGenerateColumns="False" CellPadding="4"
                                GridLines="None" PageSize="15" EnableModelValidation="True" Width="100%" Caption="Kredi Kartı Vade Oranları"
                                CaptionAlign="Left">
                                <Columns>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbtnEdit" runat="server" OnClick="lbtTermRateEdit_Click" CommandArgument='<%# Eval("Id")%>'>[Düzenle]</asp:LinkButton>
                                            <asp:LinkButton ID="lbtnDelete" runat="server" OnClick="lbtnTermRateDelete_Click"
                                                CommandArgument='<%# Eval("Id")%>' OnClientClick="javascript:return confirm('Bu kaydı silmek istediğinize emin misiniz?');"
                                                CausesValidation="false" ForeColor="Red">[Sil]</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Id" HeaderText="Id" ApplyFormatInEditMode="false" ReadOnly="true"
                                        SortExpression="Id" />
                                    <asp:BoundField DataField="Month" HeaderText="Vade" ApplyFormatInEditMode="false"
                                        ReadOnly="true" SortExpression="Month" />
                                    <asp:BoundField DataField="Rate" HeaderText="Oran" ApplyFormatInEditMode="false"
                                        ReadOnly="true" SortExpression="Rate" />
                                </Columns>
                            </asp:GridView>
                        </telerik:RadPageView>
                    </telerik:RadMultiPage>
                    <table>
                        <tr>
                            <td colspan="4" style="text-align: center">
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="VGForm" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" style="text-align: center">
                                <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Kaydet" ValidationGroup="VGForm" />&#160;<asp:Button
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
                                Kredi Kart Adı
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtFilterName"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="btnFilter" runat="server" OnClick="btnFilter_Click" Text="Filtrele" />
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
                                    Font-Size="Small" EmptyDataText="Listede gösterilecek kayıt bulunamadı" GridLines="None"
                                    PageSize="10" EnableModelValidation="True" Width="100%" AllowPaging="True" OnPageIndexChanging="gvList_PageIndexChanging">
                                    <Columns>
                                        <asp:TemplateField ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbtnEdit" runat="server" OnClick="lbtnEdit_Click" CommandArgument='<%# Eval("Id")%>'>[Düzenle]</asp:LinkButton>
                                                <asp:LinkButton ID="lbtnDelete" runat="server" OnClick="lbtnDelete_Click" CommandArgument='<%# Eval("Id")%>'
                                                    OnClientClick="javascript:return confirm('Bu kaydı silmek istediğinize emin misiniz?');"
                                                    CausesValidation="false" ForeColor="Red">[Sil]</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Id" HeaderText="Id" ApplyFormatInEditMode="false" ReadOnly="true"
                                            SortExpression="Id" />
                                        <asp:BoundField DataField="Name" HeaderText="Kredi Kartı" ApplyFormatInEditMode="false"
                                            ReadOnly="true" SortExpression="Name" />
                                        <asp:TemplateField HeaderText="Value" Visible="false">
                                            <ItemTemplate>
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
