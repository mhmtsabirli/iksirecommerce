<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterManagement.Master"
    AutoEventWireup="true" ValidateRequest="false" CodeBehind="StockControl.aspx.cs"
    Inherits="IKSIR.ECommerce.Management.ProductManagement.StockControl" %>

<%@ Register Assembly="RadAjax.Net2" Namespace="Telerik.WebControls" TagPrefix="rad" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <h2>
        Kritik Stok Durumundaki Ürünler
    </h2>
    <p>
        Kritik Stk durumundaki ürünlerin Listesi
    </p>
    <table id="tblMngForm">
        <tr>
            <td colspan="2">
                Blgi:<br />
                <div id="divAlert" runat="server" class="scrolledDiv">
                    <span style="color: Green;">Stok durumlarını güncellemek için ürün güncelleme ekranını
                        kullanınız.</span>
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
                                        <asp:BoundField DataField="Id" HeaderText="Id" ApplyFormatInEditMode="false" ReadOnly="true"
                                            SortExpression="Id" />
                                        <asp:BoundField DataField="ProductCode" HeaderText="Ürün KOdu" ApplyFormatInEditMode="false"
                                            ReadOnly="true" SortExpression="ProductCode" />
                                        <asp:BoundField DataField="Title" HeaderText="Başlık" ApplyFormatInEditMode="false"
                                            ReadOnly="true" SortExpression="Title" />
                                        <asp:BoundField DataField="Stok" HeaderText="Stok" ApplyFormatInEditMode="false"
                                            ReadOnly="true" SortExpression="Stok" />
                                        <asp:BoundField DataField="MinStock" HeaderText="Min Stok" ApplyFormatInEditMode="false"
                                            ReadOnly="true" SortExpression="MinStok" />
                                        <asp:TemplateField HeaderText="Ürün Durumu">
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
