<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCLogin.ascx.cs" Inherits="IKSIR.ECommerce.UI.UserControls.UCLogin" %>
<div id="Div1" class="tabmenu">
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
                            ErrorMessage="Kullanıcı adınızı girmelisiniz" SetFocusOnError="true" ValidationGroup="vgLoginControlForm">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtEmail" class="sidemenu_kullanici_adi"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="txtPassword"
                            SetFocusOnError="true" ErrorMessage="Şifrenizi girmelisiniz" ValidationGroup="vgLoginControlForm">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtPassword" Text="******" TextMode="Password" class="sidemenu_sifre"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="color: Red !important;">
                        <asp:ValidationSummary runat="server" ID="vsLoginForm" ValidationGroup="vgLoginControlForm"
                            CssClass="ValidationSummaryClass" />
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
            <div class="clear">
            </div>
            <span class="sidemenu_link"><a href="#">
                <img src="../images/sidemenu_forgot.jpg" alt="" />Parolamı Unuttum?</a></span>
            <span class="sidemenu_link"><a href="#">
                <img src="../images/sidemenu_forgot.jpg" alt="" />Yeni Üyelik</a></span>
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlLogout" Visible="false">
        <table cellpadding="0" cellspacing="0" border="0" width="190px">
            <tr>
                <td align="center">
                    <img src="../images/default_user_picture.png" />
                </td>
            </tr>
            <tr>
                <td align="center">
                    <p>
                        <asp:Label runat="server" ID="lblUserTitle" Text="lblUserTitle"></asp:Label>
                    </p>
                    <p>
                        <a href="#">[Hesabım]</a>
                    </p>
                    <p>
                        <a href="#">[Favorilerim]</a>
                    </p>
                    <p>
                        <a href="#">[Sepetim]</a>
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
