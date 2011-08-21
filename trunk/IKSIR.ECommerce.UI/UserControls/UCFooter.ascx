<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCFooter.ascx.cs" Inherits="IKSIR.ECommerce.UI.UserControls.UCFooter" %>
<div class="footer">
    <h4>
        <a href="#">
            <img src="../images/footer_logo.jpg" alt="" /></a></h4>
    <div class="footer_module">
        <h3>
            <a href="../Pages/Default.aspx">Anasayfa</a></h3>
        <ul>
            <li><a href="../PagesContent.aspx?cid=3">Müşteri Hizmetleri</a></li>
            <li><a href="../PagesContent.aspx?cid=2">Kurumsal</a></li>
            <li><a href="../PagesContent.aspx?cid=6">Sık Sorulan Sorular</a></li>
            <li><a href="../PagesContent.aspx?cid=7">Yardım</a></li>
        </ul>
    </div>
    <div class="footer_module">
        <h3>
            <a href="../PagesContent.aspx?cid=5">Sipariş İşlemleri</a></h3>
        <ul>
            <li><a href="../PagesContent.aspx?cid=5">Sipariş Takip</a></li>
            <li><a href="../PagesContent.aspx?cid=5">Sipariş Yardım Formu</a></li>
            <li><a href="../PagesContent.aspx?cid=5">Ödeme Bildirim Formu</a></li>
        </ul>
    </div>
    <div class="footer_module">
        <h3>
            <a href="#">Alışveriş İşlemleri</a></h3>
        <ul>
            <li><a href="#">Alışveriş Sepeti</a></li>
            <li><a href="#">Alışveriş Listesi</a></li>
            <li><a href="#">Hesap Numaralarımız</a></li>
        </ul>
    </div>
    <div class="footer_module">
        <h3>
            <a href="#">Üyelik İşlemleri</a></h3>
        <ul>
            <li><a href="../SecuredPages/Register.aspx">Yeni Üyelik</a></li>
            <li><a href="../SecuredPages/Login.aspx">Üye Girişi</a></li>
            <li><a href="../SecuredPages/ForgotPassword.aspx">Şifre Hatırlatma</a></li>
        </ul>
    </div>
    <div class="footer_module">
        <h3>
            E-Bülten</h3>
        <asp:TextBox runat="server" ID="txtUserEmail" CssClass="footer_module_text"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3" ControlToValidate="txtUserEmail"
                    ErrorMessage="E-Bülten kaydı için mail adresi giriniz" ValidationGroup="vgNewsletter" SetFocusOnError="true">*</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator runat="server" ID="regex1" ControlToValidate="txtUserEmail"
            ErrorMessage="Geçersiz Eposta adresi" ValidationExpression="^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"
            ValidationGroup="vgNewsletter" SetFocusOnError="true">*</asp:RegularExpressionValidator>
        <asp:ImageButton runat="server" ID="imgbtnSaveNewsletter" ImageUrl="../images/footer_module_submit.png"
            CssClass="footer_module_submit" OnClick="imgbtnSaveNewsletter_Click" ValidationGroup="vgNewsletter" />
        <div class="clear">
        </div>
        <p>
            <asp:ValidationSummary runat="server" ID="vsForm" ValidationGroup="vgNewsletter" ForeColor="Red" />
            <asp:Label runat="server" ID="lblAlert"></asp:Label>
        </p>
        <p>
            Güncel gelişmelerden kolayca haberdar<br />
            olmak için e-bültenimize üye olun</p>
    </div>
    <div class="footer_verisign">
        <a href="#">
            <img src="../images/footer_verisign.jpg" alt="" /></a></div>
    <div class="clear">
    </div>
    <div class="footer_bottom">
        <img src="../images/footer_bottom.jpg" alt="" />
        <p>
            İdevit © Copyright 2011</p>
    </div>
</div>
