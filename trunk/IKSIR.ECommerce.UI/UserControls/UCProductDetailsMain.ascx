<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCProductDetailsMain.ascx.cs"
    Inherits="IKSIR.ECommerce.UI.UserControls.UCProductDetailsMain" %>
<script src="../js/jquery-1.6.js" type="text/javascript"></script>
<script src="../js/jquery.jqzoom-core.js" type="text/javascript"></script>
<link rel="stylesheet" href="../css/jquery.jqzoom.css" type="text/css" />
<style>
    body
    {
        margin: 0px;
        padding: 0px;
        font-family: Arial;
    }
    a img, :link img, :visited img
    {
        border: none;
    }
    table
    {
        border-collapse: collapse;
        border-spacing: 0;
    }
    :focus
    {
        outline: none;
    }
    *
    {
        margin: 0;
        padding: 0;
    }
    p, blockquote, dd, dt
    {
        margin: 0 0 8px 0;
        line-height: 1.5em;
    }
    fieldset
    {
        padding: 0px;
        padding-left: 7px;
        padding-right: 7px;
        padding-bottom: 7px;
    }
    fieldset legend
    {
        margin-left: 15px;
        padding-left: 3px;
        padding-right: 3px;
        color: #333;
    }
    dl dd
    {
        margin: 0px;
    }
    dl dt
    {
    }
    .clearfix:after
    {
        clear: both;
        content: ".";
        display: block;
        font-size: 0;
        height: 0;
        line-height: 0;
        visibility: hidden;
    }
    .clearfix
    {
        display: block;
        zoom: 1;
    }
    ul#thumblist
    {
        display: block;
    }
    ul#thumblist li
    {
        float: left;
        margin-right: 2px;
        list-style: none;
    }
    ul#thumblist li a
    {
        display: block;
        border: 1px solid #CCC;
    }
    ul#thumblist li a.zoomThumbActive
    {
        border: 1px solid red;
    }
    .jqzoom
    {
        text-decoration: none;
        float: left;
    }
</style>
<script type="text/javascript">

    $(document).ready(function () {
        $('.jqzoom').jqzoom({
            zoomType: 'reverse',
            lens: true,
            preloadImages: false,
            alwaysOn: false
        });
        //$('.jqzoom').jqzoom();
    });
</script>
<div class="urun_resimleri">
    <div class="urun_buyuk_resim">
        <div class="clearfix" id="content" style="text-align: center">
            <div class="clearfix" style="height: 225px; text-align: center; text-align:center; vertical-align:middle;">
                <a runat="server" id="anchorBigImage" class="jqzoom" rel="gal1" title="Büyük Resim">
                    <img runat="server" src="" id="imgMainImage" title="triumph" style="border: 1px solid #666;" alt="" />
                </a>
            </div>
            <br />
            <div class="clearfix" id="divOtherImages" runat="server">
            </div>
        </div>
    </div>
    <div class="urun_kucuk_resimler" runat="server">
    </div>
    <div class="urun_paylas">
        <ul>
            <li><a href="#">
                <img src="../images/urun_paylas_1.png" alt="" /></a></li>
            <li><a href="#">
                <img src="../images/urun_paylas_2.png" alt="" /></a></li>
            <li><a href="#">
                <img src="../images/urun_paylas_3.png" alt="" /></a></li>
            <li><a href="#">
                <img src="../images/urun_paylas_4.png" alt="" /></a></li>
            <li><a href="#">
                <img src="../images/urun_paylas_5.png" alt="" /></a></li>
            <li><a href="#">
                <img src="../images/urun_paylas_6.png" alt="" /></a></li>
            <li><a href="#">
                <img src="../images/urun_paylas_7.png" alt="" /></a></li>
        </ul>
    </div>
    <div class="urun_yildiz">
    </div>
    <div class="clear">
    </div>
</div>
<div class="urun_ozellikleri">
    <h2>
        LAVABO YARIM AYAK 60X50</h2>
    <div class="urun_fiyat">
        Fiyatı : <span style="color: #333;">
            <asp:Label runat="server" ID="lblBigProductPrice"></asp:Label>
        </span>
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
                    <asp:Label runat="server" ID="lblProductPrice"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    KDV Dahil Fiyatı :
                </td>
                <td style="text-align: right; color: #333">
                    <asp:Label runat="server" ID="lblProductPriceWithKDV"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <div class="urun_satis">
        <span>Hemen Al</span>
        <form action="">
        <label class="satis_label">
            Adet</label>
        <asp:DropDownList runat="server" ID="ddlProductCount" Width="40px">
        </asp:DropDownList>
        <asp:LinkButton runat="server" ID="lbtnAddToBasket" CssClass="satis_sepet" Text="Sepete At"
            OnClick="lbtnAddToBasket_Click"></asp:LinkButton>
        </form>
        <div class="clear">
        </div>
    </div>
</div>
