<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCProductDetailsMain.ascx.cs"
    Inherits="IKSIR.ECommerce.UI.UserControls.UCProductDetailsMain" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<div class="urun_resimleri">

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
            </ul>
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
