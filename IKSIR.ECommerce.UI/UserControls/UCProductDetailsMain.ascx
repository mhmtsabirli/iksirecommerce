<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCProductDetailsMain.ascx.cs"
    Inherits="IKSIR.ECommerce.UI.UserControls.UCProductDetailsMain" %>
<div class="urun_resimleri">
    <div class="urun_buyuk_resim">
        <div class="x">
            <asp:Image runat="server" ID="imgMainImage" /></div>
        <div class="favori">
            <a href="#">
                <img src="../images/urun_favorilere_ekle.jpg" alt="" />Favorilerime Ekle</a></div>
    </div>
    <div class="urun_kucuk_resimler" runat="server" id="divOtherImages">
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
        <asp:TextBox runat="server" ID="txtCount" CssClass="satis_text"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ID="rfv1" ControlToValidate="txtCount"
            SetFocusOnError="true" ErrorMessage="Adet girmelisiniz." ValidationGroup="vgAddtoBasket">*</asp:RequiredFieldValidator>
        <asp:ValidationSummary runat="server" ID="vs1" ValidationGroup="vgAddtoBasket" DisplayMode="List" ShowMessageBox="true" />
        <asp:LinkButton runat="server" ID="lbtnAddToBasket" CssClass="satis_sepet" Text="Sepete At"
            OnClick="lbtnAddToBasket_Click" ValidationGroup="vgAddtoBasket"></asp:LinkButton>
        </form>
        <div class="clear">
        </div>
    </div>
</div>
