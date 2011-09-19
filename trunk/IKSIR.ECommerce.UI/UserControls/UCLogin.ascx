<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCLogin.ascx.cs" Inherits="IKSIR.ECommerce.UI.UserControls.UCLogin" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
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
        textboxHint("div_login");
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
<div class="tabmenu">
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="pnlLogin">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="pnlLogin" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="pnlLogout">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="pnlLogout" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Web20">
    </telerik:RadAjaxLoadingPanel>
    <div id="div_login">
        <asp:Panel runat="server" ID="pnlLogin">
            <ul class="tabnav">
                <li><a href="#uyegirisi"><span>Üye Girişi</span></a></li>
            </ul>
            <div class="clear">
            </div>
            <div class="sidemenu_hr">
            </div>
            <div id="uyegirisi" class="tabdiv">
                <table cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td>
                            <asp:RequiredFieldValidator runat="server" ID="rfv1" ControlToValidate="txtEmail"
                                ErrorMessage="Kullanıcı adınızı girmelisiniz" SetFocusOnError="true" ValidationGroup="vgLoginControlForm"
                                title="E-posta Adresiniz" ForeColor="Red">*</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator runat="server" ID="regex1" ControlToValidate="txtEmail"
                                ErrorMessage="Geçersiz E-posta Adresi" ValidationExpression="^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"
                                ValidationGroup="vgLoginControlForm" SetFocusOnError="true" ForeColor="Red">*</asp:RegularExpressionValidator>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtEmail" MaxLength="50" class="sidemenu_kullanici_adi"
                                title="E-posta Adresiniz"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="txtPassword"
                                SetFocusOnError="true" ErrorMessage="Şifrenizi girmelisiniz" ValidationGroup="vgLoginControlForm"
                                ForeColor="Red">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtPassword" MaxLength="50" TextMode="Password" class="sidemenu_sifre"
                                title="Şifreniz"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:ValidationSummary runat="server" ForeColor="Red" ID="vsLoginForm" ValidationGroup="vgLoginControlForm" />
                            <asp:Label runat="server" ID="lblAlert" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button runat="server" ID="btnLogin" OnClick="btnLogin_Click" ValidationGroup="vgLoginControlForm"
                                class="footer_module_submit" />
                        </td>
                    </tr>
                </table>
            </div>
            <div class="clear">
            </div>
            <span class="sidemenu_link"><a href="../SecuredPages/ForgotPassword.aspx">
                <img src="../images/sidemenu_forgot.jpg" alt="" style="border: none; padding-left:5px; padding-right:3px;" />Parolamı
                Unuttum?</a></span> <span class="sidemenu_link"><a href="../SecuredPages/Register.aspx">
                    <img src="../images/sidemenu_forgot.jpg" alt="" style="border: none; padding-left:5px; padding-right:3px;" />Yeni Üyelik</a></span>
        </asp:Panel>
    </div>
    <asp:Panel runat="server" ID="pnlLogout" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" width="190px">
            <tr>
                <td align="center">
                    <img src="../images/default_user_picture.png" style="border: none;" alt=""/>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <p>
                        <asp:Label runat="server" ID="lblUserTitle" Text="lblUserTitle"></asp:Label>
                    </p>
                    <p>
                        <a href="../SecuredPages/UserAccount/UserInfos.aspx">[Hesabım]</a>
                    </p>
                    <p>
                        <a href="../Pages/OrderBasket.aspx">[Sepetim]</a>
                    </p>
                    <p>
                        <asp:LinkButton runat="server" ID="lbtnLogout" Style="color: Red" Text="[Oturumu Kapat]"
                            OnClick="lbtnLogout_Click"></asp:LinkButton>
                    </p>
                </td>
            </tr>
        </table>
    </asp:Panel>
</div>
