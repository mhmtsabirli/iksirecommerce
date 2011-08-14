<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterManagement.Master"
    AutoEventWireup="true" ValidateRequest="false" CodeBehind="SiteCategories.aspx.cs"
    Inherits="IKSIR.ECommerce.Management.ProductManagement.SiteCategories" %>

<%@ Register Assembly="RadAjax.Net2" Namespace="Telerik.WebControls" TagPrefix="rad" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <h2>
        Site Kategorileri
    </h2>
    <p>
        Sitelere Kategori Tanımlama Ekranı
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
                    <table>
                        <tr>
                            <td colspan="4">
                                <strong>Site Kategori Bilgisi</strong>
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
                                <asp:Label runat="server" ID="lblId" Text="Yeni Kayıt"></asp:Label>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Site
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlSite" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator4" ControlToValidate="ddlSite"
                                    ValidationGroup="vgProductProperties" SetFocusOnError="true" InitialValue="-1"
                                    ErrorMessage="Site seçmelisiniz" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Ana Kategori
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlParentCategories" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="ddlParentCategories"
                                    ValidationGroup="vgProductProperties" SetFocusOnError="true" InitialValue="-1"
                                    ErrorMessage="Kategori seçmelisiniz" ForeColor="Red">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    </table>
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
                                Site
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlFilterSite" runat="server">
                                </asp:DropDownList>
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
                                        <asp:TemplateField HeaderText="Site">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblSite" Text='<%# Eval("Site.Name")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Ana Kategori">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblProductCategory" Text='<%# Eval("ProductCategory.Title")%>'></asp:Label>
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
