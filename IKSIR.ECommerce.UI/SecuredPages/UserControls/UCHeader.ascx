<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCHeader.ascx.cs" Inherits="IKSIR.ECommerce.UI.SecuredPages.UserControls.UCHeader" %>
<%--Arama, login gibi textboxlarda üzerine geldiğinde içini temizleyen bölüm BAŞLANGIÇ--%>
<script type="text/javascript" src="../../js/jquery-1.4.2.min.js"></script>
<script type="text/javascript" src="../../js/highslide.js"></script>
<script type="text/javascript" src="../../js/jquery.prettyPhoto.js"></script>
<style type="text/css">
    input.blur
    {
        color: #808080;
    }
</style>
<script language="javascript" type="text/javascript">
    $(document).ready(
    function () {
        textboxHint("div_header");
    });

    function textboxHint(id, options) {
        var o = { selector: 'input:text[title]', blurClass: 'blur' };
        $e = $('#' + id);
        $.extend(true, o, options || {});

        if ($e.is(':text')) {
            if (!$e.attr('title')) $e = null;
        } else {
            $e = $e.find(o.selector);
        }
        if ($e) {
            $e.each(function () {
                var $t = $(this);
                if ($.trim($t.val()).length == 0) { $t.val($t.attr('title')); }
                if ($t.val() == $t.attr('title')) {
                    $t.addClass(o.blurClass);
                } else {
                    $t.removeClass(o.blurClass);
                }

                $t.focus(function () {
                    if ($.trim($t.val()) == $t.attr('title')) {
                        $t.val('');
                        $t.removeClass(o.blurClass);
                    }
                }).blur(function () {
                    var val = $.trim($t.val());
                    if (val.length == 0 || val == $t.attr('title')) {
                        $t.val($t.attr('title'));
                        $t.addClass(o.blurClass);
                    }
                });

                // empty the text box on form submit
                $(this.form).submit(function () {
                    if ($.trim($t.val()) == $t.attr('title')) $t.val('');
                });
            });
        }
    }
</script>
<%--Arama, login gibi textboxlarda üzerine geldiğinde içini temizleyen bölüm BİTİŞ--%>
<div class="header" id="div_header">
    <div class="top_menu">
        <ul>
            <li style="border: 0;"><a href="/Pages/Content.aspx?cid=2">Kurumsal</a></li>
            <li><a href="/Pages/Content.aspx?cid=3">Müşteri Hizmetleri</a></li>
            <li><a href="/Pages/Content.aspx?cid=5">Sipariş Takibi</a></li>
            <li><a href="/Pages/Content.aspx?cid=6">Sık Sorulan Sorular</a></li>
            <li><a href="/Pages/Content.aspx?cid=7">Yardım</a></li>
        </ul>
    </div>
    <div class="logo">
        <a href="/Pages/Default.aspx">
            <img src="https://www.banyom.com.tr/images/logo.jpg" alt="" /></a></div>
    <div class="search" id="block">
        <asp:TextBox runat="server" ID="txtSearchText" title="Arama.." CssClass="search_text"></asp:TextBox>
        <asp:LinkButton runat="server" ID="lbtnSearch" CssClass="search_submit" OnClick="lbtnSearch_Click"></asp:LinkButton>
        <div class="clear">
        </div>
    </div>
    <div class="clear">
    </div>
</div>
<div class="navbar">
    <div class="nav_menu">
        <ul>
            <li><a style="background: none;" href="/Pages/Default.aspx">Anasayfa</a></li>
            <li><a href="/Pages/ProductList.aspx?modid=4">Yeni Ürünler</a></li>
            <li><a href="/Pages/ProductList.aspx?modid=5">Kampanyalı Ürünler</a></li>
            <li><a href="/Pages/ProductList.aspx?modid=6">İndirimli Ürünler</a></li>
            <li><a href="/SecuredPages/Register.aspx">Yeni Üyelik</a></li>
            <li><a href="/Pages/Contact.aspx">İletişim</a></li>
        </ul>
        <div class="clear">
        </div>
    </div>
    <div class="nav_info">
        <p>
            <img src="https://www.banyom.com.tr/images/navbar_sepet.png" alt="" style="border: none" />
            <asp:HyperLink runat="server" ID="hplToBasket" ForeColor="White" Text="Sepetinizde Ürün Yok"></asp:HyperLink>
        </p>
    </div>
    <div class="clear">
    </div>
</div>
