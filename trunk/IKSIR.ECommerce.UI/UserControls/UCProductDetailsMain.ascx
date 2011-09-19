<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCProductDetailsMain.ascx.cs"
    Inherits="IKSIR.ECommerce.UI.UserControls.UCProductDetailsMain" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<style type="text/javascript">
    #image
    {
        border: 4px #666 solid;
        height: 250px;
        width: 350px;
    }
    #image img
    {
        border: none;
    }
    .thumb
    {
        float: left;
        margin-right: 10px;
        margin-top: 10px;
    }
    *
    {
        margin: 0;
        padding: 0;
    }
    body
    {
        background: #282828;
        font: 62.5%/1.2 Arial, Verdana, Sans-Serif;
        padding: 0 20px;
    }
    h1
    {
        font-family: Georgia;
        font-style: italic;
        margin-bottom: 10px;
    }
    h2
    {
        font-family: Georgia;
        font-style: italic;
        margin: 25px 0 5px 0;
    }
    p
    {
        font-size: 1.2em;
    }
    ul li
    {
        display: inline;
    }
    .wide
    {
        border-bottom: 1px #000 solid;
        width: 4000px;
    }
    .fleft
    {
        float: left;
        margin: 0 20px 0 0;
    }
    .cboth
    {
        clear: both;
    }
    #main
    {
        background: #fff;
        margin: 0 auto;
        padding: 30px;
        width: 1000px;
    }
</style>
<div class="urun_resimleri">
    <script type="text/javascript" charset="utf-8">
        $(document).ready(function () {
            $("area[rel^='prettyPhoto']").prettyPhoto();

            $(".gallery:first a[rel^='prettyPhoto']").prettyPhoto({ animation_speed: 'normal', theme: 'light_square', slideshow: 3000, autoplay_slideshow: false, social_tools: false });
            $(".gallery:gt(0) a[rel^='prettyPhoto']").prettyPhoto({ animation_speed: 'fast', slideshow: 10000, hideflash: true, social_tools: false });

            $("#custom_content a[rel^='prettyPhoto']:first").prettyPhoto({
                custom_markup: '<div id="map_canvas" style="width:260px; height:265px"></div>',
                changepicturecallback: function () { initialize(); }
            });

            $("#custom_content a[rel^='prettyPhoto']:last").prettyPhoto({
                custom_markup: '<div id="bsap_1259344" class="bsarocks bsap_d49a0984d0f377271ccbf01a33f2b6d6"></div><div id="bsap_1237859" class="bsarocks bsap_d49a0984d0f377271ccbf01a33f2b6d6" style="height:260px"></div><div id="bsap_1251710" class="bsarocks bsap_d49a0984d0f377271ccbf01a33f2b6d6"></div>',
                changepicturecallback: function () { _bsap.exec(); }
            });
        });
			</script>
    <div class="urun_buyuk_resim" style="float: left;">
        <div id="image" style="height: 250px; width: 350px; background-color: Gray; border: 4px #666 solid;
            text-align: center;">
            <a runat="server" id="anchorBigImage" class="highslide" onclick="return hs.expand(this)"
                title="Orjinal Boyut">
                <img runat="server" id="imgBig" style="border: none;" alt="Ana Resim" />
            </a>
        </div>
        <br />
        <div runat="server" id="divSmallImages">
        </div>
        <div class="clear">
        </div>
        <div class='favori' style='float: left; width: 350px; padding-top: 3px;'>
            <asp:LinkButton runat="server" ID="lbtnAddToFavorite" OnClick="lbtnAddToFavorite_Click">
        <img src='../images/urun_favorilere_ekle.jpg' alt='' />Favorilerime Ekle
            </asp:LinkButton>
        </div>
        <br />
        <br />
        <div class='urun_paylas' style='float: left; width: 225px;'>
            <ul>
                <li><a runat="server" id="anchor_Facebook" alt="Ürünü Facebook'ta paylaş">
                    <img src="../images/urun_paylas_3.png" alt="Ürünü Facebook'ta paylaş" /></a></li>
                <li><a runat="server" id="anchor_Twitter">
                    <img src='../images/urun_paylas_4.png' alt="Ürünü Twitter'da paylaş" /></a></li>
                <li><a runat="server" id="anchor_Delicious">
                    <img src='../images/urun_paylas_6.png' alt="Ürünü Delicious'da paylaş" /></a></li>
        </div>
        <div class="urun_yildiz" style="float: left;">
            <telerik:RadRating ID="RadRating" runat="server" Skin="WebBlue" OnRate="RadRating_Rate"
                AutoPostBack="true" />
        </div>
        <div class='clear'>
        </div>
        <div id="container" runat="server">
        </div>
        <script type="text/javascript">
            try {
                var pageTracker = _gat._getTracker("UA-7025232-1");
                pageTracker._trackPageview();
            } catch (err) { }</script>
    </div>
</div>
<div class="urun_ozellikleri">
    <h2>
        <asp:Label runat="server" ID="lblProductTitle"></asp:Label></h2>
    <div class="urun_fiyat">
        Fiyatı : <span style="color: #333;">
            <asp:Label runat="server" ID="lblBigProductPrice"></asp:Label>&nbsp;TL </span>
    </div>
    <div class="urun_table">
        <table>
            <tr>
                <td>
                    Ürün Kodu :
                </td>
                <td style="text-align: right; color: #333">
                    <asp:Label runat="server" ID="lblProductCode"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Ürün Adı :
                </td>
                <td style="text-align: right; color: #333">
                    <asp:Label runat="server" ID="lblProductName"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Garanti(Yıl) :
                </td>
                <td style="text-align: right; color: #333">
                    <asp:Label runat="server" ID="lblProductWarranty"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Stok Durumu :
                </td>
                <td style="text-align: right; color: #333">
                    <asp:Label runat="server" ID="lblProductStock"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Fiyatı :
                </td>
                <td style="text-align: right; color: #333">
                    <asp:Label runat="server" ID="lblProductPrice"></asp:Label>&nbsp;TL
                </td>
            </tr>
            <tr>
                <td>
                    KDV Dahil Fiyatı :
                </td>
                <td style="text-align: right; color: #333">
                    <asp:Label runat="server" ID="lblProductPriceWithKDV"></asp:Label>&nbsp;TL
                </td>
            </tr>
        </table>
    </div>
    <div class="urun_satis">
        <table width="292px">
            <tr>
                <td align="left">
                    <asp:ImageButton runat="server" ID="imgBtnBuyNow" ImageUrl="~/images/hemenal.png"
                        OnClick="imgBtnBuyNow_Click" />
                    &nbsp;
                </td>
                <td align="center">
                    <asp:DropDownList runat="server" ID="ddlProductCount" Width="40px" Font-Bold="true"
                        Font-Size="14px">
                    </asp:DropDownList>
                </td>
                <td align="right">
                    &nbsp;<asp:ImageButton runat="server" ID="imgBtnAddToBasket" ImageUrl="~/images/sepeteat.png"
                        OnClick="imgBtnAddToBasket_Click" />
                </td>
            </tr>
        </table>
        <div class="clear">
        </div>
    </div>
</div>
