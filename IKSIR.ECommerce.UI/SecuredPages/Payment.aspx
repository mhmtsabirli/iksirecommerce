<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="IKSIR.ECommerce.UI.SecuredPages.Payment" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form name="form1" method="post" action="Moduler/posnettds.aspx" runat="server">
    <table width="87%" align="center" cellpadding="0" cellspacing="0" bordercolor="#ffffff">
        <tr bordercolor="#FFFFFF">
            <td width="25%" height="30">
                <font size="2" face="Geneva, Arial, Helvetica, sans-serif"><strong>&nbsp;Müşterinizin
                    Adı :</strong></font>
            </td>
            <td width="35%" height="30">
                <font size="2" face="Geneva, Arial, Helvetica, sans-serif">
                    <input name="custName" id="custName" value="ĞğÜüİı ŞşÖöÇç" size="25" maxlength="30">
                </font>
            </td>
            <td width="40%" height="30">
                <font size="2" face="Geneva, Arial, Helvetica, sans-serif"><em>Kredi kartı sahibinin
                    ismi</em></font>
            </td>
        </tr>
        <tr bordercolor="#FFFFFF">
            <td height="30">
                <font size="2" face="Geneva, Arial, Helvetica, sans-serif">&nbsp;<strong>Sipariş No
                    :</strong></font>
            </td>
            <td height="30">
                <font size="2" face="Geneva, Arial, Helvetica, sans-serif">
                    <input name="XID" id="XID" size="25" maxlength="20">
                </font>
            </td>
            <td height="30">
                <font size="2" face="Geneva, Arial, Helvetica, sans-serif"><em>Herbir alışveriş işlemi
                    için Üye İşyeri tarafından oluşturulan 20 karakterli alfa-numerik sipariş numarası</em></font>
            </td>
        </tr>
        <tr bordercolor="#FFFFFF">
            <td height="30">
                <font size="3" face="Geneva, Arial, Helvetica, sans-serif">&nbsp;<strong><font color="#0000FF"
                    size="2">Kredi Kart Bilgileri </font></strong></font>
            </td>
            <td height="30" bordercolor="#CCCCCC">
                <font size="2" face="Geneva, Arial, Helvetica, sans-serif">&nbsp;<strong>KK No :</strong>
                    <input name="ccno" id="ccno" value="5400637500005263" size="22" maxlength="16">
                </font>
            </td>
            <td height="30" bordercolor="#CCCCCC">
                <font size="2" face="Geneva, Arial, Helvetica, sans-serif"><em>Kredi Kartı Numarası</em></font>
            </td>
        </tr>
        <tr bordercolor="#FFFFFF">
            <td height="30">
                &nbsp;
            </td>
            <td height="30" bordercolor="#CCCCCC">
                <font size="2" face="Geneva, Arial, Helvetica, sans-serif">&nbsp;<strong>SKT :&nbsp;</strong>&nbsp;&nbsp;
                    <input name="expdate" id="expdate" value="0607" size="6" maxlength="4">
                </font>
            </td>
            <td height="30" bordercolor="#CCCCCC">
                <font size="2" face="Geneva, Arial, Helvetica, sans-serif"><em>Kredi Kartı Son Kullanma
                    Tarihi (YYAA)</em></font>
            </td>
        </tr>
        <tr bordercolor="#FFFFFF">
            <td height="30">
                &nbsp;
            </td>
            <td height="30" bordercolor="#CCCCCC">
                <font size="2" face="Geneva, Arial, Helvetica, sans-serif">&nbsp;<strong>CVV2 :</strong>&nbsp;
                    <input name="cvv" id="cvv" value="XXX" size="5" maxlength="3">
                </font>
            </td>
            <td height="30" bordercolor="#CCCCCC">
                <font size="2" face="Geneva, Arial, Helvetica, sans-serif"><em>Kredi Kartı CVV2 Numarası</em></font>
            </td>
        </tr>
        <tr bordercolor="#FFFFFF">
            <td height="30">
                <font size="2" face="Geneva, Arial, Helvetica, sans-serif">&nbsp;<strong>Tutar (x100)&nbsp;:</strong></font>
            </td>
            <td height="30">
                <font size="2" face="Geneva, Arial, Helvetica, sans-serif">
                    <input name="amount" id="amount" value="5696" maxlength="13">
                </font>
            </td>
            <td height="30">
                <font size="2" face="Geneva, Arial, Helvetica, sans-serif"><em>Alışveriş tutarı (14,8
                    TL için 1480 giriniz.)</em></font>
            </td>
        </tr>
        <tr bordercolor="#FFFFFF">
            <td height="30">
                <font size="2" face="Geneva, Arial, Helvetica, sans-serif">&nbsp;<strong>Taksit sayısı
                    :</strong></font>
            </td>
            <td height="30">
                <font size="2" face="Geneva, Arial, Helvetica, sans-serif">
                    <input name="instalment" id="instalment" value="00" size="2" maxlength="2">
                </font>
            </td>
            <td height="30">
                <font size="2" face="Geneva, Arial, Helvetica, sans-serif"><em>Taksit Sayısı</em></font>
            </td>
        </tr>
        <tr bordercolor="#FFFFFF">
            <td height="30">
                <font size="2" face="Geneva, Arial, Helvetica, sans-serif">&nbsp;<strong>İşlem Tipi
                    :</strong></font>
            </td>
            <td height="30">
                <font size="2" face="Geneva, Arial, Helvetica, sans-serif">
                    <select name="tranType" id="tranType">
                        <option value="Auth">Provizyon</option>
                        <option value="Sale" selected>Satış</option>
                        <option value="WP">Puan</option>
                        <option value="SaleWP">Puan + Satış</option>
                        <option value="Vft">Vade Farklı Satış</option>
                    </select>
                </font>
            </td>
            <td height="30">
                <font size="2" face="Geneva, Arial, Helvetica, sans-serif"><em>Yapılması istenilen işlem
                    tipi</em></font>
            </td>
        </tr>
        <tr bordercolor="#FFFFFF">
            <td height="30">
                <font size="2" face="Geneva, Arial, Helvetica, sans-serif">&nbsp;<strong>Para Birimi
                    :</strong></font>
            </td>
            <td height="30">
                <font size="2" face="Geneva, Arial, Helvetica, sans-serif">
                    <select name="currency" id="currency">
                        <option value="TL" selected>TL</option>
                        <option value="US">US</option>
                        <option value="EU">EU</option>
                    </select>
                </font>
            </td>
            <td height="30">
                <font size="2" face="Geneva, Arial, Helvetica, sans-serif">Para Birimi&nbsp;</font>
            </td>
        </tr>
        <tr bordercolor="#FFFFFF">
            <td height="30">
                <font size="2" face="Geneva, Arial, Helvetica, sans-serif">&nbsp;<strong>VFT Kampanya
                    Kodu :</strong></font>
            </td>
            <td height="30">
                <font size="2" face="Geneva, Arial, Helvetica, sans-serif">
                    <input name="vftCode" id="vftCode" value="K001" size="8" maxlength="4">
                </font>
            </td>
            <td height="30">
                <font size="2" face="Geneva, Arial, Helvetica, sans-serif"><em>Vade Farklı İşlem kampanya
                    kodu</em></font>
            </td>
        </tr>
    </table>
    <p align="center">
        <input type="submit" name="Submit" value="Gönder">
    </p>
    </form>
</body>
</html>
