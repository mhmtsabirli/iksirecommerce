<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCHeader.ascx.cs" Inherits="IKSIR.ECommerce.UI.UserControls.UCHeader" %>
<div class="header">
    <div class="top_menu">
        <ul>
            <li style="border: 0;"><a href="../Pages/Content.aspx?cid=2">Kurumsal</a></li>
            <li><a href="../Pages/Content.aspx?cid=3">Müşteri Hizmetleri</a></li>
            <li><a href="../Pages/Content.aspx?cid=5">Sipariş Takibi</a></li>
            <li><a href="../Pages/Content.aspx?cid=6">Sık Sorulan Sorular</a></li>
            <li><a href="../Pages/Content.aspx?cid=7">Yardım</a></li>
        </ul>
    </div>
    <div class="logo">
        <a href="../Pages/Default.aspx">
            <img src="../images/logo.jpg" alt="" /></a></div>
    <div class="search">
    </div>
    <input class="search_text" type="text" />
    <input class="search_submit" type="submit" value="" />
    <div class="clear">
    </div>
</div>
<div class="navbar">
    <div class="nav_menu">
        <ul>
            <li><a style="background: none;" href="../Pages/Default.aspx">Anasayfa</a></li>
            <li><a href="../Pages/ProductList.aspx?modid=4">Yeni Ürünler</a></li>
            <li><a href="../Pages/ProductList.aspx?modid=5">Kampanyalı Ürünler</a></li>
            <li><a href="../Pages/ProductList.aspx?modid=6">İndirimli Ürünler</a></li>
            <li><a href="../Pages/Register.aspx">Yeni Üyelik</a></li>
            <li><a href="../UserPanel/MyAccount.aspx">Hesabım</a></li>
            <li><a href="../Pages/Contact.aspx">İletişim</a></li>
        </ul>
        <div class="clear">
        </div>
    </div>
    <div class="nav_info">
        <p>
            <img src="../images/navbar_sepet.png" alt="" />Alışveriş Sepetim : 5 ürün (1500
            TL)</p>
    </div>
    <div class="clear">
    </div>
</div>
