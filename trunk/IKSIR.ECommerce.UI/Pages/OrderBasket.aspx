<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/UIDetailMasterPage.Master"
    AutoEventWireup="true" CodeBehind="OrderBasket.aspx.cs" Inherits="IKSIR.ECommerce.UI.Pages.OrderBasket" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="sepet_content_middle">
        <div class="sepet_content_header">
            <img src="../images/sepet_sepet.jpg" alt="" />
            <h3>
                Alışveriş Sepetiniz</h3>
            <h4>
                Sepetinizdeki ürünlerin yer aldığı sayfadır. Dilerseniz birden fazla ürünü aynı
                anda alabilirsiniz.
            </h4>
        </div>
        <br />
        <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="pnlBasket">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="pnlBasket" LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Web20">
        </telerik:RadAjaxLoadingPanel>
        <asp:Panel runat="server" ID="pnlBasket" CssClass="pnlBasket">
            <table>
                <asp:Repeater runat="server" ID="rptBasketProducts" OnItemDataBound="rptBasketProducts_ItemDataBound"
                    OnItemCommand="rptBasketProducts_ItemCommand">
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
                            <td class="table_header">
                            </td>
                        </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td colspan="5">
                                <%# Eval("Product.ProductCategory.Title")%>
                                /
                                <%# Eval("Product.Title")%>
                            </td>
                        </tr>
                        <tr>
                            <td class="table_first">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:HiddenField runat="server" ID="hdnProductId" Value='<%# Eval("Product.Id")%>' />
                                            <asp:Image runat="server" ID="imgProduct" ImageUrl='<%# Eval("Product.MainImage", "http://212.58.8.103/documents/Images/Small/small_{0:C}")%>' />
                                        </td>
                                        <td>
                                            <table>
                                                <asp:Repeater runat="server" ID="rptProductProperties">
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td>
                                                                <%# Eval("Property.Title")%></strong>
                                                            </td>
                                                            <td>
                                                                :
                                                            </td>
                                                            <td>
                                                                <%# Eval("Value")%>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td class="table_second">
                                <form action="">
                                <asp:TextBox runat="server" ID="txtItemCount" CssClass="table_second_text" Text='<%# Eval("Count")%>'></asp:TextBox><br />
                                <asp:ImageButton runat="server" ID="imgbtnRefreshItemCount" ImageUrl="../images/table_second_guncelle.png"
                                    CommandName="Update" CommandArgument='<%# Eval("Product.Id")%>' />
                                </form>
                            </td>
                            <td class="table_third">
                                <p>
                                    <%# Eval("ProductPrice.UnitPrice")%>
                                    TL</p>
                            </td>
                            <td class="table_fourth">
                                <p>
                                    <%# Eval("BasketItemPrice")%>
                                    TL</p>
                            </td>
                            <td class="table_fifth">
                                <a href="#">
                                    <asp:ImageButton runat="server" ID="imgbtnDeleteItem" ImageUrl="../images/table_fifth_one.jpg"
                                        CommandName="Delete" OnClientClick="javascript:return confirm('Sepetinizden bu ürünü silmek istediğinize emin misiniz?');" CommandArgument='<%# Eval("Product.Id")%>' />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <tr>
                    <td colspan="5">
                        <asp:CheckBox runat="server" ID="cbxComfirmation" Text="" /><a href="#" id="anchorConfirmation"
                            runat="server">Genel Kurallar ve Koşullar'ı okudum ve kabul ediyorum.</a>
                        <script type="text/javascript">
                            $("#anchorConfirmation").click(function () {
                                if ($(".divGeneralRules").is(':visible'))
                                    $(".divGeneralRules").slideUp('slow');
                                else
                                    $(".divGeneralRules").slideDown('slow');
                            });
                        </script>
                        <br />
                        <div runat="server" class="divGeneralRules" id="divRules" style="display: none; width: 100%;
                            background: #F3F6F7; font: normal 12px tahoma; color: #3F5968; height: 150px;
                            overflow: auto; border: 1px solid #666; padding: 8px;">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="5" align="center" style="border: none;">
                        <asp:HyperLink runat="server" ID="hplNoItem" ForeColor="Red" Font-Size="14px" Visible="false"
                            Text="Sepetinizde ürün bulunmamaktadır. Ana sayfaya gitmek için tıklayınız."
                            NavigateUrl="~/Pages/Default.aspx"></asp:HyperLink>
                    </td>
                </tr>
            </table>
            <div class="sepet_content_footer" id="divBasketTotal" runat="server">
                <div style="float: right!important; text-align: left;">
                    <br />
                    <strong>Sepet Toplamı:</strong>
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
                                    TL</strong>
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
                                    TL</strong>
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
                                    TL</strong>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="sepet_content_end" id="divBasketButtons" runat="server">
                <a href="#">
                    <img src="../images/sepet_end_iptal.jpg" alt="" /></a>
                <asp:ImageButton runat="server" ID="imgbtnContinue" ImageUrl="../images/sepet_end_devam.jpg"
                    AlternateText="Devam Et" OnClick="imgbtnContinue_Click" />
            </div>
            <div>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
