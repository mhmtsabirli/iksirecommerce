<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterManagement.Master"
    AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="IKSIR.ECommerce.Management.ProductManagement.Products" %>

<%@ Register Assembly="RadAjax.Net2" Namespace="Telerik.WebControls" TagPrefix="rad" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <h2>
        Ürünler
    </h2>
    <p>
        Ürün tanımlama güncelleme ekranı.
    </p>
    <table id="tblMngForm">
        <tr>
            <td align="left">
                <asp:Label runat="server" ID="lblError" Visible="false"></asp:Label>
            </td>
            <td align="right">
                <asp:LinkButton runat="server" ID="lbtnNew" Text="Yeni Kayıt" OnClick="lbtnNew_Click"></asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <asp:Panel runat="server" ID="pnlForm" Visible="true" CssClass="pnlForm">
                    <telerik:RadTabStrip ID="TabStrip1" runat="server" TabIndex="0">
                        <Tabs>
                            <telerik:RadTab Text="Tab1" PageViewID="RadPageView1">
                            </telerik:RadTab>
                            <telerik:RadTab Text="Tab2" PageViewID="RadPageView2">
                            </telerik:RadTab>
                        </Tabs>
                    </telerik:RadTabStrip>
                    <telerik:RadMultiPage ID="RadMultiPage1" runat="server">                    
                        <telerik:RadPageView ID="RadPageView1" runat="server">                        
                            <table>
                                <tr>
                                    <td colspan="4">
                                        <strong>Ürün Formu</strong> (Ürünlerin genel bilgileri)
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
                                        <asp:Label runat="server" ID="lblProductId" Text="Yeni Kayıt"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Kategori
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlProductCategories">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator runat="server" ID="rfv1" ControlToValidate="ddlProductCategories"
                                            ValidationGroup="VGForm" SetFocusOnError="true" InitialValue="-1" ErrorMessage="Kategori seçmelisiniz"
                                            ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Ürün Kodu
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtProductCode"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="txtProductCode"
                                            ValidationGroup="VGForm" SetFocusOnError="true" ErrorMessage="Ürün Kodu alanı zorunlu"
                                            ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Ürün Adı
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtProductName"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator runat="server" ID="rfv23" ControlToValidate="txtProductName"
                                            ValidationGroup="VGForm" SetFocusOnError="true" ErrorMessage="Ürün Adı alanı zorunlu"
                                            ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Açıklama
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtProductDescription" TextMode="MultiLine" CssClass="descriptionTextBox"></asp:TextBox>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Min Stok
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtMinStock"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="txtMinStock"
                                            ValidationGroup="VGForm" SetFocusOnError="true" ErrorMessage="Minimum Stok alanı zorunlu"
                                            ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Alert Date
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtAlertDate"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3" ControlToValidate="txtMinStock"
                                            ValidationGroup="VGForm" SetFocusOnError="true" ErrorMessage="Alert Date alanı zorunlu"
                                            ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                            </table>
                        </telerik:RadPageView>
                        <telerik:RadPageView ID="RadPageView2" runat="server">
                            <table>
                                <tr>
                                    <td colspan="4">
                                        <strong>Ürün Dökümanları</strong> (jpg, gif, png, pdf, doc, xls)
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
                                        <asp:Label ID="lblDocumentId" runat="server" Text="Yeni Kayıt"></asp:Label>
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
                                        <asp:TextBox ID="txtDocumentName" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Açıklama
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDocumentDescription" runat="server" TextMode="MultiLine" Width="250px"
                                            Height="50px"></asp:TextBox>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Döküman Tipi
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlDocumentTypes" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Dosya
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <asp:FileUpload runat="server" ID="fuSelectedDocument" />
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="4">
                                        <asp:Label ID="lblDocumentAlert" runat="server" Visible="false"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="4">
                                        <asp:Button ID="btnAddDocument" runat="server" Text="Döküman Ekle" ValidationGroup="vgDocumentForm"
                                            OnClick="btnAddDocument_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:GridView runat="server" ID="gvDocumentList" AutoGenerateColumns="False" CellPadding="4"
                                            GridLines="None" PageSize="15" EnableModelValidation="True" Width="100%" Caption="Ürün Dökümanları"
                                            CaptionAlign="Left">
                                            <Columns>
                                                <asp:TemplateField ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lbtnEdit" runat="server" OnClick="lbtnEdit_Click" CommandArgument='<%# Eval("Id")%>'>[Düzenle]</asp:LinkButton>
                                                        <asp:LinkButton ID="lbtnDelete" runat="server" OnClick="lbtnDelete_Click" CommandArgument='<%# Eval("Id")%>'
                                                            OnClientClick="javascript:return confirm('Are you sure you want to delete this row?');"
                                                            CausesValidation="false" ForeColor="Red">[Sil]</asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Id" HeaderText="Id" ApplyFormatInEditMode="false" ReadOnly="true"
                                                    SortExpression="Id" />
                                                <asp:BoundField DataField="Name" HeaderText="Adı" ApplyFormatInEditMode="false" ReadOnly="true"
                                                    SortExpression="Name" />
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </telerik:RadPageView>
                    </telerik:RadMultiPage>
                    <table>
                        <tr>
                            <td colspan="4">
                                <strong>Ürün Özellikler</strong> (Ürünlere girilmesi gereken özellikler)
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
                                <asp:Label runat="server" ID="lblPropertyId" Text="Yeni Kayıt"></asp:Label>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Özellik
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlProperties" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Değer
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtPropertyValue" Height="50px" Width="250px"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4">
                                <asp:Label ID="lblPropertyAlert" runat="server" Visible="false"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4">
                                <asp:Button ID="btnAddProperty" runat="server" Text="Özellik Ekle" ValidationGroup="vgImageForm"
                                    OnClick="btnAddProperty_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:GridView runat="server" ID="gvProductProperties" AutoGenerateColumns="False"
                                    CellPadding="4" GridLines="None" PageSize="15" EnableModelValidation="True" Width="100%"
                                    Caption="Ürün Özellikleri" CaptionAlign="Left">
                                    <Columns>
                                        <asp:TemplateField ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbtnEdit" runat="server" OnClick="lbtnEdit_Click" CommandArgument='<%# Eval("Id")%>'>[Düzenle]</asp:LinkButton>
                                                <asp:LinkButton ID="lbtnDelete" runat="server" OnClick="lbtnDelete_Click" CommandArgument='<%# Eval("Id")%>'
                                                    OnClientClick="javascript:return confirm('Are you sure you want to delete this row?');"
                                                    CausesValidation="false" ForeColor="Red">[Sil]</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Id" HeaderText="Id" ApplyFormatInEditMode="false" ReadOnly="true"
                                            SortExpression="Id" />
                                        <asp:TemplateField HeaderText="Özellik">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblTitle" Text='<%# Eval("Property.Title")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Value" HeaderText="Değer" ApplyFormatInEditMode="false"
                                            ReadOnly="true" SortExpression="Value" />
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td align="center" colspan="4">
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="VGForm" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4">
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
                                <strong>Ürün Filtreleme</strong>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Üst Kategori
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:DropDownList runat="server" ID="ddlFilterParentCategories">
                                </asp:DropDownList>
                            </td>
                            <td rowspan="2">
                                <asp:Button runat="server" ID="btnFilter" Text="Filtrele" OnClick="btnFilter_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Ürün Kodu
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtFilterProductCode"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <br />
                <asp:Panel runat="server" ID="pnlList" Visible="true">
                    <table>
                        <tr>
                            <td colspan="4">
                                <strong>Ürün Listesi</strong>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:GridView runat="server" ID="gvList" AutoGenerateColumns="False" CellPadding="4"
                                    GridLines="None" PageSize="15" EnableModelValidation="True" Width="100%">
                                    <Columns>
                                        <asp:TemplateField ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbtnEdit" runat="server" OnClick="lbtnEdit_Click" CommandArgument='<%# Eval("Id")%>'>[Düzenle]</asp:LinkButton>
                                                <asp:LinkButton ID="lbtnDelete" runat="server" OnClick="lbtnDelete_Click" CommandArgument='<%# Eval("Id")%>'
                                                    OnClientClick="javascript:return confirm('Are you sure you want to delete this row?');"
                                                    CausesValidation="false" ForeColor="Red">[Sil]</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Id" HeaderText="Id" ApplyFormatInEditMode="false" ReadOnly="true"
                                            SortExpression="Id" />
                                        <asp:TemplateField ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblCategoryName" Text='"<%# Eval("ProductCategory").Title%>"'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="ProductCode" HeaderText="ProductCode" ApplyFormatInEditMode="false"
                                            ReadOnly="true" SortExpression="ProductCode" />
                                        <asp:BoundField DataField="AlertDate" HeaderText="AlertDate" ApplyFormatInEditMode="false"
                                            ReadOnly="true" SortExpression="AlertDate" />
                                        <asp:BoundField DataField="MinStock" HeaderText="MinStock" ApplyFormatInEditMode="false"
                                            ReadOnly="true" SortExpression="MinStock" />
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
