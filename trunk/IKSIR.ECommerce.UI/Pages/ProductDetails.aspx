<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/UIDetailMasterPage.Master"
    AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="IKSIR.ECommerce.UI.Pages.ProductDetails" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="../UserControls/UCProductDetailsProductInfos.ascx" TagName="UCProductDetailsProductInfos"
    TagPrefix="uc1" %>
<%@ Register Src="../UserControls/UCProductDetailsComments.ascx" TagName="UCProductDetailsComments"
    TagPrefix="uc2" %>
<%@ Register Src="../UserControls/UCProductDetailsCreditCardAdvantages.ascx" TagName="UCProductDetailsCreditCardAdvantages"
    TagPrefix="uc3" %>
<%@ Register Src="../UserControls/UCProductDetailDocuments.ascx" TagName="UCProductDetailDocuments"
    TagPrefix="uc4" %>
<%@ Register Src="../UserControls/UCProductDetailsRelatedAndSimilarProducts.ascx"
    TagName="UCProductDetailsRelatedAndSimilarProducts" TagPrefix="uc6" %>
<%@ Register Src="../UserControls/UCProductDetailsMain.ascx" TagName="UCProductDetailsMain"
    TagPrefix="uc7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="sepet_content">
        <div class="sepet_content_top">
            <div class="top_left">
                <a href="Default.aspx">
                    <img src="../images/sepet_content_top_home.jpg" alt="" />Anasayfa</a> &nbsp;
                <a href="#" runat="server" id="anchorProductCategory"></a>&nbsp; <a href="#" runat="server"
                    id="anchorProduct"></a>
                <div class="clear">
                </div>
            </div>
            <div class="top_right">
                <asp:HyperLink runat="server" ID="hplPreviousProduct">
                    <img src="../images/sepet_content_top_onceki.jpg" style="border:none" alt="Önceki Ürün" />
                </asp:HyperLink>
                <asp:HyperLink runat="server" ID="hplNextProduct">
                    <img src="../images/sepet_content_top_sonraki.jpg" style="border:none" alt="Sonraki Ürün" />
                </asp:HyperLink>
            </div>
            <div class="clear">
            </div>
        </div>
        <div class="urun_content">
            <uc7:UCProductDetailsMain ID="UCProductDetailsMain1" runat="server" />
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
                        <telerik:RadTab Text="Benzer ve İlişkili Ürünler" PageViewID="pvSimilarProducts">
                        </telerik:RadTab>
                    </Tabs>
                </telerik:RadTabStrip>
                <telerik:RadMultiPage ID="RadMultiPage1" runat="server">
                    <telerik:RadPageView ID="pvProductInfo" runat="server" Selected="true">
                        <uc1:UCProductDetailsProductInfos ID="UCProductDetailsProductInfos1" runat="server" />
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="pvProductDocuments" runat="server">
                        <uc4:UCProductDetailDocuments ID="UCProductDetailDocuments1" runat="server" />
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="pvCreditCardAdvantages" runat="server">
                        <uc3:UCProductDetailsCreditCardAdvantages ID="UCProductDetailsCreditCardAdvantages1"
                            runat="server" />
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="pvProductComments" runat="server">
                        <uc2:UCProductDetailsComments ID="UCProductDetailsComments1" runat="server" />
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="pvSimilarProducts" runat="server">
                        <uc6:UCProductDetailsRelatedAndSimilarProducts ID="UCProductDetailsRelatedAndSimilarProducts1"
                            runat="server" />
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </div>
        </div>
    </div>
</asp:Content>
