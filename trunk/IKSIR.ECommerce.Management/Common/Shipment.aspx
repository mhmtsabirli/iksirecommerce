<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterManagement.Master"
    AutoEventWireup="true" CodeBehind="Shipment.aspx.cs" Inherits="IKSIR.ECommerce.Management.Common.Shipment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <h2>
        Kargo Firmaları</h2>
    <p>
        Sistemdeki Kargo Ekranlarının ve Baz değerlerinin tanımlandığı ekran
    </p>
    <table id="tblMngForm">
        <tr>
            <td align="left">
                <asp:Label runat="server" ID="lblError" Visible="false"></asp:Label>
                <div id="divAlert" runat="server">
                </div>
            </td>
            <td style="text-align: right">
                <asp:LinkButton runat="server" ID="lbtnNew" Text="Yeni Kayıt" OnClick="lbtnNew_Click"></asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Panel runat="server" ID="pnlForm" Visible="false" CssClass="pnlForm">
                    <table>
                        <tr>
                            <td colspan="4">
                                <strong>Form</strong>
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
                                <asp:Label runat="server" ID="lblId"></asp:Label>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Kargo Firması
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtShipment"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator runat="server" ID="rfv1" ControlToValidate="txtShipment"
                                    ValidationGroup="VGForm" SetFocusOnError="true" ErrorMessage="Firması Girmelisiniz"
                                    ForeColor="Red">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Fiyat
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtPriceOne"></asp:TextBox>
                                        </td>
                                        <td>
                                            ,
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtPriceTwo"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="txtPriceOne"
                                    ValidationGroup="VGForm" SetFocusOnError="true" ErrorMessage="00,00 Şeklinde Giriş yapmalısınız"
                                    ForeColor="Red">*</asp:RequiredFieldValidator>
                                       <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="txtPriceTwo"
                                    ValidationGroup="VGForm" SetFocusOnError="true" ErrorMessage="00,00 Şeklinde Giriş yapmalısınız"
                                    ForeColor="Red">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" style="text-align: center">
                                <asp:ValidationSummary runat="server" ID="vsForm" ValidationGroup="VGForm" ForeColor="Red" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" style="text-align: center">
                                <asp:Button runat="server" ID="btnSave" Text="Kaydet" ValidationGroup="VGForm" OnClick="btnSave_Click" />
                                &nbsp;<asp:Button runat="server" ID="btnCancel" Text="Vazgeç" OnClick="btnCancel_Click" />
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
                                Kargo Firması
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtFilterShipment"></asp:TextBox>
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
                                    GridLines="None" PageSize="15" EnableModelValidation="True" Width="100%" EmptyDataText="Listede gösterilecek kayıt bulunamadı">
                                    <Columns>
                                        <asp:TemplateField ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbtnEdit" runat="server" OnClick="lbtnEdit_Click" CommandArgument='<%# Eval("Id")%>'>[Düzenle]</asp:LinkButton>
                                                <asp:LinkButton ID="lbtnDelete" runat="server" OnClick="lbtnDelete_Click" CommandArgument='<%# Eval("Id")%>'
                                                    OnClientClick="javascript:return confirm('Bu kaydı silmek istediğinize emin misiniz?');"
                                                    CausesValidation="false" ForeColor="Red">[Sil]</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Id" HeaderText="Değer" ApplyFormatInEditMode="false" ReadOnly="true"
                                            SortExpression="Id" />
                                        <asp:BoundField DataField="Title" HeaderText="Firma" ApplyFormatInEditMode="false"
                                            ReadOnly="true" SortExpression="Title" />
                                             <asp:BoundField DataField="UnitPrice" HeaderText="Baz Fiyat" ApplyFormatInEditMode="false"
                                            ReadOnly="true" SortExpression="UnitPrice" />
                                        <asp:TemplateField HeaderText="Id" Visible="false">
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
