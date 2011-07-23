<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterManagement.Master"
    AutoEventWireup="true" ValidateRequest="false" CodeBehind="Products.aspx.cs"
    Inherits="IKSIR.ECommerce.Management.ProductManagement.Products" %>

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
                        SelectedIndex="1" Width="600px">
                        <Tabs>
                            <telerik:RadTab Text="Ürün" Selected="true" PageViewID="RadPageView1">
                            </telerik:RadTab>
                            <telerik:RadTab Text="Özellikler" PageViewID="RadPageView3">
                            </telerik:RadTab>
                            <telerik:RadTab Text="Resimler" PageViewID="RadPageView2">
                            </telerik:RadTab>
                            <telerik:RadTab Text="Video" PageViewID="RadPageView4">
                            </telerik:RadTab>
                            <telerik:RadTab Text="İlişkili Ürünler" PageViewID="RadPageView5">
                            </telerik:RadTab>
                            <telerik:RadTab Text="Benzer Ürünler" PageViewID="RadPageView6">
                            </telerik:RadTab>
                        </Tabs>
                    </telerik:RadTabStrip>
                    <telerik:RadMultiPage ID="RadMultiPage1" runat="server">
                        <telerik:RadPageView ID="RadPageView1" runat="server" Selected="true">
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
                                        Site
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlSites" AutoPostBack="true" OnSelectedIndexChanged="ddlSites_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator6" ControlToValidate="ddlSites"
                                            ValidationGroup="VGForm" SetFocusOnError="true" InitialValue="-1" ErrorMessage="Site seçmelisiniz"
                                            ForeColor="Red">*</asp:RequiredFieldValidator>
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
                                        <asp:DropDownList runat="server" ID="ddlParentProductCategories" AutoPostBack="true"
                                            OnSelectedIndexChanged="ddlParentProductCategories_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator7" ControlToValidate="ddlParentProductCategories"
                                            ValidationGroup="VGForm" SetFocusOnError="true" InitialValue="-1" ErrorMessage="Kategori seçmelisiniz"
                                            ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Alt Kategori
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
                                        <asp:TextBox runat="server" MaxLength="100" Width="100%" ID="txtProductCode"></asp:TextBox>
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
                                        <asp:TextBox runat="server" MaxLength="250" Width="100%" ID="txtProductName"></asp:TextBox>
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
                                        <asp:TextBox runat="server"  MaxLength='500'  onkeyUp="checkTextAreaMaxLength(this,event,'500','Llbldescription');"   Width="100%" ID="txtProductDescription" TextMode="MultiLine"
                                            CssClass="descriptionTextBox"></asp:TextBox>
                                              
                                           
                                    </td>
                                    <td>
                                    
                                    <div id="Llbldescription">500</div>
                                     
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
                                        <asp:TextBox runat="server" Width="50px" ID="txtMinStock"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="txtMinStock"
                                            ValidationGroup="VGForm" SetFocusOnError="true" ErrorMessage="Minimum Stok alanı zorunlu"
                                            ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Mevcut Stok
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" Width="50px" ID="txtStok"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator11" ControlToValidate="txtStok"
                                            ValidationGroup="VGForm" SetFocusOnError="true" ErrorMessage="Mevcut Stok alanı zorunlu"
                                            ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Maksimum Satış Adedi
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" Width="50px" ID="txtMaxQuantity"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator12" ControlToValidate="txtMinStock"
                                            ValidationGroup="VGForm" SetFocusOnError="true" ErrorMessage="Maksimum satış adati alanı zorunlu"
                                            ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Garanti Süresi (Yıl)
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" Width="50px" ID="txtguarantee"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator10" ControlToValidate="txtguarantee"
                                            ValidationGroup="VGForm" SetFocusOnError="true" ErrorMessage="Garanti alanı zorunlu"
                                            ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Stok Durumu
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlStokStatus">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator13" ControlToValidate="ddlStokStatus"
                                            ValidationGroup="VGForm" SetFocusOnError="true" InitialValue="-1" ErrorMessage="Stok Durumu seçmelisiniz"
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
                                        <telerik:RadDatePicker ID="txtAlertDate" runat="server">
                                        </telerik:RadDatePicker>
                                        <%--<asp:TextBox runat="server" ID="" ></asp:TextBox>--%>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3" ControlToValidate="txtMinStock"
                                            ValidationGroup="VGForm" SetFocusOnError="true" ErrorMessage="Alert Date alanı zorunlu"
                                            ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Ürün Durumu
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlProductStatus">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator14" ControlToValidate="ddlProductStatus"
                                            ValidationGroup="VGForm" SetFocusOnError="true" InitialValue="-1" ErrorMessage="Ürün Durumu seçmelisiniz"
                                            ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                            </table>
                        </telerik:RadPageView>
                        <telerik:RadPageView ID="RadPageView2" runat="server">
                            <table>
                                <tr>
                                    <td colspan="4">
                                        <strong>Ürün Resimleri</strong> (jpg, gif, png, pdf, doc, xls)
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
                                <%--<tr>
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
                                </tr>--%>
                                <%--<tr>
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
                                </tr>--%>
                                <tr>
                                    <td valign="top">
                                        Resimler
                                    </td>
                                    <td valign="top">
                                        :
                                    </td>
                                    <td>
                                        <telerik:RadUpload ID="ruProductDocuments" runat="server" InitialFileInputsCount="2"
                                            MaxFileInputsCount="10" AllowedFileExtensions=".jpg,.jpeg,.pdf,.doc,.gif,.png"
                                            Localization-Add="Ekle" Localization-Clear="Temizle" Localization-Delete="Sil"
                                            Localization-Remove="Kaldır" Localization-Select="Seç" />
                                        <div runat="server" id="divDocuments">
                                        </div>
                                        <%-- <asp:Button runat="server" ID="btnCancelShowDocuments" Text="Vazgeç" OnClick="btnCancelShowDocuments_Click" Visible="false" />--%>
                                        <%--<telerik:RadProgressArea ID="progressArea1" runat="server" />--%>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: center" colspan="4">
                                        <asp:Label ID="lblDocumentAlert" runat="server" Visible="false"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <asp:GridView runat="server" ID="gvDocumentList" AutoGenerateColumns="False" CellPadding="4"
                                GridLines="None" PageSize="15" EnableModelValidation="True" Width="100%" Caption="Ürün Resimleri"
                                CaptionAlign="Left">
                                <Columns>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbtnEdit" runat="server" OnClick="lbtnDocumentEdit_Click" CommandArgument='<%# Eval("Id")%>'>[Kontrol Et]</asp:LinkButton>
                                            <asp:LinkButton ID="lbtnDelete" runat="server" OnClick="lbtnDocumentDelete_Click"
                                                CommandArgument='<%# Eval("Id")%>' OnClientClick="javascript:return confirm('Bu kaydı silmek istediğinize emin misiniz?');"
                                                CausesValidation="false" ForeColor="Red">[Sil]</asp:LinkButton>
                                            <asp:LinkButton ID="lbtnUsed" runat="server" OnClick="lbtnDocumentUsed_Click" CommandArgument='<%# Eval("Id")%>'
                                                OnClientClick="javascript:return confirm('Bu kaydı varsayılan yapmak istediğinize emin misiniz?');"
                                                CausesValidation="false" ForeColor="Blue">[Varsayılan]</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Id" HeaderText="Id" ApplyFormatInEditMode="false" ReadOnly="true"
                                        SortExpression="Id" />
                                    <asp:BoundField DataField="FilePath" HeaderText="Adı" ApplyFormatInEditMode="false"
                                        ReadOnly="true" SortExpression="Name" />
                                    <asp:BoundField DataField="IsDefault" HeaderText="Varsayılan" ApplyFormatInEditMode="false"
                                        ReadOnly="true" SortExpression="IsDefault" />
                                </Columns>
                            </asp:GridView>
                        </telerik:RadPageView>
                        <telerik:RadPageView ID="RadPageView3" runat="server">
                            <table>
                                <tr>
                                    <td colspan="4">
                                        <strong>Ürün Özellikleri</strong> (Ürünlere girilmesi gereken özellikler)
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
                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator4" ControlToValidate="ddlProperties"
                                            ValidationGroup="vgProductProperties" SetFocusOnError="true" InitialValue="-1"
                                            ErrorMessage="Özellik seçmelisiniz" ForeColor="Red">*</asp:RequiredFieldValidator>
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
                                        <asp:TextBox runat="server" MaxLength="20" ID="txtPropertyValue" Width="250px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator5" ControlToValidate="txtPropertyValue"
                                            ValidationGroup="vgProductProperties" SetFocusOnError="true" ErrorMessage="Değer alanı zorunlu"
                                            ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: center" colspan="4">
                                        <asp:Label ID="lblPropertyAlert" runat="server" Visible="false"></asp:Label>
                                        <asp:ValidationSummary runat="server" ID="vsProductProperties" ValidationGroup="vgProductProperties"
                                            ForeColor="Red" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: center" colspan="4">
                                        <asp:Button ID="btnAddProperty" runat="server" Text="Özelliği Kaydet" ValidationGroup="vgProductProperties"
                                            OnClick="btnAddProperty_Click" />
                                    </td>
                                </tr>
                            </table>
                            <asp:GridView runat="server" ID="gvProductProperties" AutoGenerateColumns="False"
                                CellPadding="4" GridLines="None" PageSize="15" EnableModelValidation="True" Width="100%"
                                Caption="Ürün Özellikleri" CaptionAlign="Left">
                                <Columns>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbtnEdit" runat="server" OnClick="lbtnPropertyEdit_Click" CommandArgument='<%# Eval("Id")%>'>[Düzenle]</asp:LinkButton>
                                            <asp:LinkButton ID="lbtnDelete" runat="server" OnClick="lbtnPropertyDelete_Click"
                                                CommandArgument='<%# Eval("Id")%>' OnClientClick="javascript:return confirm('Bu kaydı silmek istediğinize emin misiniz?');"
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
                        </telerik:RadPageView>
                        <telerik:RadPageView ID="RadPageView4" runat="server" Selected="true">
                            <table>
                                <tr>
                                    <td colspan="4">
                                        <strong>Ürün Videoları</strong> (Ürünlerin Video Scriptleri)
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Viedo Script
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" Width="100%" onkeyUp="checkTextAreaMaxLength(this,event,'4000','lblvideo');" Height="100px" ID="txtVideo" TextMode="MultiLine"
                                            CssClass="descriptionTextBox"></asp:TextBox>
                                    </td>
                                    <td>
                                  
                                    <div id="lblvideo">4000</div>


                                    </td>
                                </tr>
                            </table>
                        </telerik:RadPageView>
                        <telerik:RadPageView ID="RadPageView5" runat="server">
                            <table>
                                <tr>
                                    <td colspan="4">
                                        <strong>İlişkili Ürünler</strong> (Ürünlere ilişkili olacak başka ürünlerin girilmesi)
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
                                        <asp:Label runat="server" ID="lblRelatedProductId" Text="Yeni Kayıt"></asp:Label>
                                        <asp:Label runat="server" Visible="false" ID="lblhRelatedProductId" Text=""></asp:Label>
                                    </td>
                                    <td>
                                        &nbsp;
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
                                        <asp:TextBox runat="server"  MaxLength="100" Width="100%" ID="txtRProductCode"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Button runat="server" ID="btnSearch" Text="Ürün Bul" OnClick="btnSearch_Click" />
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
                                        <asp:TextBox runat="server" MaxLength="250" Width="100%" Enabled="false" ID="txtRProductName"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator9" ControlToValidate="txtRProductName"
                                            ValidationGroup="vgProductRelated" SetFocusOnError="true" ErrorMessage="Ürün Bulunuz"
                                            ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: center" colspan="4">
                                        <asp:Label ID="Label2" runat="server" Visible="false"></asp:Label>
                                        <asp:ValidationSummary runat="server" ID="ValidationSummary2" ValidationGroup="vgProductRelated"
                                            ForeColor="Red" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: center" colspan="4">
                                        <asp:Button ID="btnAddRelatedProduct" runat="server" Text="Kaydet" ValidationGroup="vgProductRelated"
                                            OnClick="btnAddRelatedProduct_Click" />
                                    </td>
                                </tr>
                            </table>
                            <asp:GridView runat="server" ID="grvRelatedProduct" AutoGenerateColumns="False" CellPadding="4"
                                GridLines="None" PageSize="15" EnableModelValidation="True" Width="100%" Caption="İlişkili Ürünler"
                                CaptionAlign="Left">
                                <Columns>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbtnDelete" runat="server" OnClick="lbtnRelatedProductDelete_Click"
                                                CommandArgument='<%# Eval("Id")%>' OnClientClick="javascript:return confirm('Bu kaydı silmek istediğinize emin misiniz?');"
                                                CausesValidation="false" ForeColor="Red">[Sil]</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Id" HeaderText="Id" ApplyFormatInEditMode="false" ReadOnly="true"
                                        SortExpression="Id" />
                                    <asp:TemplateField HeaderText="Ürün Adı">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblRTitle" Text='<%# Eval("Title")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ürün Kodu">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblRProductCode" Text='<%# Eval("ProductCode")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </telerik:RadPageView>
                        <telerik:RadPageView ID="RadPageView6" runat="server">
                            <table>
                                <tr>
                                    <td colspan="4">
                                        <strong>Benzer Ürünler</strong> (Ürünlere Benzer olacak başka ürünlerin girilmesi)
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
                                        <asp:Label runat="server" ID="lblSimilarProductId" Text="Yeni Kayıt"></asp:Label>
                                        <asp:Label runat="server" Visible="false" ID="lblhSimilarProductId" Text=""></asp:Label>
                                    </td>
                                    <td>
                                        &nbsp;
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
                                        <asp:TextBox runat="server" MaxLength="100" Width="100%" ID="txtSProductCode"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Button runat="server" ID="btnSSearch" Text="Ürün Bul" OnClick="btnSSearch_Click" />
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
                                        <asp:TextBox runat="server" MaxLength="250" Width="100%" Enabled="false" ID="txtSProductName"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator15" ControlToValidate="txtSProductName"
                                            ValidationGroup="vgProductSimilar" SetFocusOnError="true" ErrorMessage="Ürün Bulunuz"
                                            ForeColor="Red">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: center" colspan="4">
                                        <asp:Label ID="Label4" runat="server" Visible="false"></asp:Label>
                                        <asp:ValidationSummary runat="server" ID="ValidationSummary3" ValidationGroup="vgProductSimilar"
                                            ForeColor="Red" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: center" colspan="4">
                                        <asp:Button ID="btnAddSimilarProduct" runat="server" Text="Kaydet" ValidationGroup="vgProductSimilar"
                                            OnClick="btnAddSimilarProduct_Click" />
                                    </td>
                                </tr>
                            </table>
                            <asp:GridView runat="server" ID="grvSimilarProduct" AutoGenerateColumns="False" CellPadding="4"
                                GridLines="None" PageSize="15" EnableModelValidation="True" Width="100%" Caption="Benzer Ürünler"
                                CaptionAlign="Left">
                                <Columns>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbtnDelete" runat="server" OnClick="lbtnSimilarProductDelete_Click"
                                                CommandArgument='<%# Eval("Id")%>' OnClientClick="javascript:return confirm('Bu kaydı silmek istediğinize emin misiniz?');"
                                                CausesValidation="false" ForeColor="Red">[Sil]</asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Id" HeaderText="Id" ApplyFormatInEditMode="false" ReadOnly="true"
                                        SortExpression="Id" />
                                    <asp:TemplateField HeaderText="Ürün Adı">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblSTitle" Text='<%# Eval("Title")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Ürün Kodu">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblSProductCode" Text='<%# Eval("ProductCode")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
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
                                Site
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:DropDownList runat="server" ID="ddlFilterSite" AutoPostBack="true" OnSelectedIndexChanged="ddlFilterSites_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator8" ControlToValidate="ddlSites"
                                    ValidationGroup="VGForm" SetFocusOnError="true" InitialValue="-1" ErrorMessage="Site seçmelisiniz"
                                    ForeColor="Red">*</asp:RequiredFieldValidator>
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
                                <asp:DropDownList runat="server"  AutoPostBack="true" ID="ddlFilterParentCategories" 
                                    onselectedindexchanged="ddlFilterParentCategories_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td rowspan="2">
                                <asp:Button runat="server" ID="btnFilter" Text="Filtrele" OnClick="btnFilter_Click" />
                            </td>
                        </tr>
                           <tr>
                                    <td>
                                        Alt Kategori
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlFilterCategories">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                       
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
                                <asp:TextBox runat="server" MaxLength="100" ID="txtFilterProductCode"></asp:TextBox>
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
                                                    OnClientClick="javascript:return confirm('Bu kayıd sistemden tüm bilgileri ile beaber silinecektir. Emin misiniz?');"
                                                    CausesValidation="false" ForeColor="Red">[Sil]</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Id" HeaderText="Id" ApplyFormatInEditMode="false" ReadOnly="true"
                                            SortExpression="Id" />
                                        <asp:BoundField DataField="ProductCode" HeaderText="Ürün KOdu" ApplyFormatInEditMode="false"
                                            ReadOnly="true" SortExpression="ProductCode" />
                                        <asp:BoundField DataField="Title" HeaderText="Başlık" ApplyFormatInEditMode="false"
                                            ReadOnly="true" SortExpression="Title" />
                                              <asp:TemplateField HeaderText="Kategori">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblCategory" Text='<%# Eval("ProductCategory.Title")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Stok" HeaderText="Stok" ApplyFormatInEditMode="false"
                                            ReadOnly="true" SortExpression="Stok" />
                                        <asp:TemplateField HeaderText="Stok Durumu">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblProductStatus" Text='<%# Eval("ProductStatus.Value")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                      
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
