<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/UIDetailMasterPage.Master"
    AutoEventWireup="true" CodeBehind="OrderBasket.aspx.cs" Inherits="IKSIR.ECommerce.UI.Pages.OrderBasket" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
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
                                        <a href='<%# String.Format("ProductDetails.aspx?pid={0}", Eval("Product.Id"))%>'
                                            target="_blank">
                                            <%# Eval("Product.ProductCategory.Title")%>
                                            /
                                            <%# Eval("Product.Title")%>
                                        </a>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="table_first">
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:HiddenField runat="server" ID="hdnProductId" Value='<%# Eval("Product.Id")%>' />
                                                    <a href='<%# String.Format("ProductDetails.aspx?pid={0}", Eval("Product.Id"))%>'
                                                        target="_blank">
                                                        <asp:Image runat="server" ID="imgProduct" ImageUrl='<%# Eval("Product.MainImage", "http://banyom.com.tr/documents/Images/Small/small_{0:C}")%>'
                                                            BorderWidth="0  " />
                                                    </a>
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
                                        <asp:DropDownList ID="ddlItemCount" runat="server" OnSelectedIndexChanged="ddlItemCount_SelectedIndexChanged"
                                            ToolTip='<%# Eval("Product.Id")%>' AutoPostBack="true">
                                        </asp:DropDownList>
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
                                                CommandName="Delete" OnClientClick="javascript:return confirm('Sepetinizden bu ürünü silmek istediğinize emin misiniz?');"
                                                CommandArgument='<%# Eval("Product.Id")%>' />
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr>
                            <td colspan="5" align="right" style="text-align: right;">
                                <div class="sepet_content_footer" id="divBasketTotal" runat="server" style="float: right">
                                    <div style="float: right!important; text-align: right;">
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
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5">
                                <asp:CheckBox ID="cbxComfirmation" runat="server" Text="" />
                                <a href="#" id="anchorConfirmation">Genel Kurallar ve Koşullar&#39;ı okudum ve kabul
                                    ediyorum.</a><div id="dvAlert" runat="server" visible="false"></div>
                                <script type="text/javascript">
                                    $("#anchorConfirmation").click(function () {
                                        if ($(".divGeneralRules").is(':visible'))
                                            $(".divGeneralRules").slideUp('slow');
                                        else
                                            $(".divGeneralRules").slideDown('slow');
                                    });
                                </script>
                                <br />
                                <div style="width: 100%; height: 1px">
                                </div>
                                <div id="divRules" runat="server" class="divGeneralRules" style="display: none; width: 100%;
                                    background: #F3F6F7; font: normal 12px tahoma; color: #3F5968; height: 150px;
                                    overflow: auto; border: 1px solid #666; padding: 8px;">
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5" align="center" style="border: none;">
                                <asp:HyperLink ID="hplNoItem" runat="server" Font-Size="14px" ForeColor="Red" NavigateUrl="~/Pages/Default.aspx"
                                    Text="Sepetinizde ürün bulunmamaktadır. Ana sayfaya gitmek için tıklayınız."
                                    Visible="false"></asp:HyperLink>
                            </td>
                        </tr>
                    </table>
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
