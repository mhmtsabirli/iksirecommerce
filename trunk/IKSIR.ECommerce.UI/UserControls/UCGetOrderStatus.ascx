<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCGetOrderStatus.ascx.cs"
    Inherits="IKSIR.ECommerce.UI.UserControls.UCGetOrderStatus" %>
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
        textboxHint("tabvanilla");
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
<div class="sidemenu">
    <div class="sidemenu_top">
    </div>
    <div class="sidemenu_middle">
        <div id="tabvanilla" class="tabmenu">
            <ul class="tabnav">
                <li><a href="#siparistakip"><span>Sipariş Takip</span></a></li>
            </ul>
            <div class="clear">
            </div>
            <div class="sidemenu_hr">
            </div>
            <div id="siparistakip" class="tabdiv">
                <p>
                    Siparişinizin ne durumda olduğunu buradan öğrene bilirsiniz. Lütfen size verilen
                    sipariş numarasını aşağıdaki kutucuğa girip takip ediniz</p>
            </div>
            <asp:Panel runat="server" ID="pnlOrderStatus" DefaultButton="btnGetOrder" CssClass="tabdiv">
                <div style="margin-left: 10px;">
                    <asp:TextBox runat="server" ID="txtOrderNo" title="Sipariş No..." CssClass="sidemenu_text"></asp:TextBox>
                </div>
                <div style="margin-left: 10px;">
                    <asp:Button runat="server" ID="btnGetOrder" CausesValidation="false" class="sidemenu_submit"
                        Text="Sipariş Durumu" OnClick="btnGetOrder_Click"/>
                </div>
            </asp:Panel>
        </div>
    </div>
    <div class="sidemenu_bottom">
    </div>
</div>
