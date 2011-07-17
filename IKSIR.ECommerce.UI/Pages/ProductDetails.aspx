<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/UIDetailMasterPage.Master"
    AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="IKSIR.ECommerce.UI.Pages.ProductDetails" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="../UserControls/UCProductDetailProductInfos.ascx" TagName="UCProductDetailProductInfos"
    TagPrefix="uc1" %>
<%@ Register Src="../UserControls/UCProductDetailsComments.ascx" TagName="UCProductDetailsComments"
    TagPrefix="uc2" %>
<%@ Register Src="../UserControls/UCProductCreditCardAdvantages.ascx" TagName="UCProductCreditCardAdvantages"
    TagPrefix="uc3" %>
<%@ Register Src="../UserControls/UCProductDetailDocuments.ascx" TagName="UCProductDetailDocuments"
    TagPrefix="uc4" %>
<%@ Register Src="../UserControls/UCProductDetailsRelatedProducts.ascx" TagName="UCProductDetailsRelatedProducts"
    TagPrefix="uc5" %>
<%@ Register Src="../UserControls/UCProductDetailsSimilarProducts.ascx" TagName="UCProductDetailsSimilarProducts"
    TagPrefix="uc6" %>
<%@ Register Src="../UserControls/UCProductDetailsMain.ascx" TagName="UCProductDetailsMain"
    TagPrefix="uc7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="sepet_content">
        <div class="sepet_content_top">
            <div class="top_left">
                <a href="#">
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <img src="../images/sepet_content_top_home.jpg" alt="" />Anasayfa</a> <a href="#">Ürünler</a>
                <a href="#">Seramik Sağlık Gereçleri</a> <a href="#">Vega</a>
                <div class="clear">
                </div>
            </div>
            <div class="top_right">
                <a href="#">
                    <img src="../images/sepet_content_top_onceki.jpg" alt="" /></a> <a href="#">
                        <img src="../images/sepet_content_top_sonraki.jpg" alt="" /></a>
            </div>
            <div class="clear">
            </div>
        </div>
        <div class="urun_content">
            <uc7:UCProductDetailsMain ID="UCProductDetailsMain1" runat="server"/>
            <div class="clear">
            </div>
            <div class="urun_diger">
                <br />
                <br />
                <telerik:RadTabStrip ID="RadTabStrip1" runat="server" MultiPageID="RadMultiPage1">
                    <Tabs>
                        <telerik:RadTab Text="Ürün Bilgisi" Selected="true" PageViewID="pvProductInfo">
                        </telerik:RadTab>
                        <telerik:RadTab Text="Ürün Dökümanları" PageViewID="pvProductDocuments">
                        </telerik:RadTab>
                        <telerik:RadTab Text="Kart Avantajları" PageViewID="pvCreditCardAdvantages">
                        </telerik:RadTab>
                        <telerik:RadTab Text="Yorumlar" PageViewID="pvProductComments">
                        </telerik:RadTab>
                        <telerik:RadTab Text="Benzer Ürünler" PageViewID="pvSimilarProducts">
                        </telerik:RadTab>
                        <telerik:RadTab Text="İlişkili Ürünler" PageViewID="pvRelatedProducts">
                        </telerik:RadTab>
                    </Tabs>
                </telerik:RadTabStrip>
                <telerik:RadMultiPage ID="RadMultiPage1" runat="server">
                    <telerik:RadPageView ID="pvProductInfo" runat="server" Selected="true">
                        <uc1:UCProductDetailProductInfos ID="UCProductDetailProductInfos1" runat="server" />
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="pvProductDocuments" runat="server" Selected="true">
                        <uc4:UCProductDetailDocuments ID="UCProductDetailDocuments1" runat="server" />
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="pvCreditCardAdvantages" runat="server" Selected="true">
                        <uc3:UCProductCreditCardAdvantages ID="UCProductCreditCardAdvantages1" runat="server" />
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="pvProductComments" runat="server" Selected="true">
                        <uc2:UCProductDetailsComments ID="UCProductDetailsComments1" runat="server" />
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="pvSimilarProducts" runat="server" Selected="true">
                        <uc6:UCProductDetailsSimilarProducts ID="UCProductDetailsSimilarProducts1" runat="server" />
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="pvRelatedProducts" runat="server" Selected="true">
                        <uc5:UCProductDetailsRelatedProducts ID="UCProductDetailsRelatedProducts1" runat="server" />
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </div>
        </div>
        <div class="detay_content_bottom">
        </div>
    </div>
</asp:Content>
