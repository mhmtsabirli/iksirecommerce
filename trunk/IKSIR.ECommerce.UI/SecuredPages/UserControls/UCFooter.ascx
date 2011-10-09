<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCFooter.ascx.cs" Inherits="IKSIR.ECommerce.UI.SecuredPages.UserControls.UCFooter" %>
<%--Arama, login gibi textboxlarda üzerine geldiğinde içini temizleyen bölüm BAŞLANGIÇ--%>
<style type="text/css">
    input.blur
    {
        color: #808080;
    }
</style>
<script language="javascript" type="text/javascript">
    $(document).ready(
    function () {
        textboxHint("div_footer");
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
<div class="footer" id="div_footer">
    <h4>
        <a href="#">
            <img src="../images/footer_logo.jpg" alt="" /></a></h4>
    <div class="footer_module">
        <h3>
            Anasayfa</h3>
        <ul>
            <li><a href="/Pages/Content.aspx?cid=3">Müşteri Hizmetleri</a></li>
            <li><a href="/Pages/Content.aspx?cid=2">Kurumsal</a></li>
            <li><a href="/Pages/Content.aspx?cid=6">Sık Sorulan Sorular</a></li>
            <li><a href="/Pages/Content.aspx?cid=7">Yardım</a></li>
        </ul>
    </div>
    <div class="footer_module">
        <h3>
            Sipariş İşlemleri</h3>
        <ul>
            <li><a href="/Pages/Content.aspx?cid=5">Sipariş Yardım Formu</a></li>
            <li><a href="/Pages/Content.aspx?cid=5">Ödeme Bildirim Formu</a></li>
        </ul>
    </div>
    <div class="footer_module">
        <h3>
            Alışveriş İşlemleri</h3>
        <ul>
            <li><a href="/Pages/OrderBasket.aspx">Alışveriş Sepeti</a></li>
        </ul>
    </div>
    <div class="footer_module">
        <h3>
            Üyelik İşlemleri</h3>
        <ul>
            <li><a href="/SecuredPages/Register.aspx">Yeni Üyelik</a></li>
            <li><a href="/SecuredPages/Login.aspx">Üye Girişi</a></li>
            <li><a href="/SecuredPages/ForgotPassword.aspx">Şifre Hatırlatma</a></li>
        </ul>
    </div>
        <div class="footer_module">
            <h3>
                E-Bülten</h3>
            <asp:TextBox runat="server" ID="txtUserEmail" CssClass="footer_module_text" title="E-posta Adresiniz"></asp:TextBox>
            <asp:LinkButton runat="server" ID="lbtnSaveToList" OnClick="lbtnSaveToList_Click">Kayıt Ol</asp:LinkButton>
            <div class="clear">
            </div>
            <p>
                <asp:Label runat="server" ID="lblAlert"></asp:Label>
            </p>
            <p>
                Güncel gelişmelerden kolayca haberdar<br />
                olmak için e-bültenimize üye olun</p>
        </div>
    <div class="footer_verisign">
        <a href="#">
            <img src="../images/RapidSSL_logo.jpg" alt="" width="100px" /></a></div>
    <div class="clear">
    </div>
    <div class="footer_bottom">
        <p style="font: normal 12px trebuchet ms; color: #464646;">
            <a href="/Pages/Content.aspx?cid=1">&nbsp;Gizlilik Politikası&nbsp;</a>&nbsp;&nbsp;&nbsp;<a
                href="/Pages/Content.aspx?cid=12">&nbsp;Güvenlik Politikası&nbsp;</a>&nbsp;&nbsp;&nbsp;<a
                    href="/Pages/Content.aspx?cid=10">&nbsp;Garanti ve İade Koşulları&nbsp;</a></p>
        <br />
        <img src="../images/footer_bottom.jpg" alt="" />
        <p>
            Senar İnşaat © Copyright 2011</p>
    </div>
</div>
