<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCProductDetailsMain.ascx.cs"
    Inherits="IKSIR.ECommerce.UI.UserControls.UCProductDetailsMain" %>
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.3.0/jquery.min.js"></script>
<script type="text/javascript">
    $(function () {
        $(".image").click(function () {
            var image = $(this).attr("rel");
            $('#image').hide();
            $('#image').fadeIn('slow');
            $('#image').html('<img src="' + image + '"/>');
            return false;
        });
    });
</script>
<style type="text/javascript">
    #image
    {
        border: 4px #666 solid;
        height: 250px;
        width: 350px;
    }
    .thumb
    {
        float: left;
        margin-right: 10px;
        margin-top: 10px;
    }
</style>
<div class="urun_resimleri">
    <div class="urun_buyuk_resim" style="float: left;">
        <div id="container" runat="server">
        </div>
        <script type="text/javascript">
            var gaJsHost = (("https:" == document.location.protocol) ? "https://ssl." : "http://www.");
            document.write(unescape("%3Cscript src='" + gaJsHost + "google-analytics.com/ga.js' type='text/javascript'%3E%3C/script%3E"));
    </script>
        <script type="text/javascript">
            try {
                var pageTracker = _gat._getTracker("UA-7025232-1");
                pageTracker._trackPageview();
            } catch (err) { }</script>
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
