<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/UIDetailMasterPage.Master"
    AutoEventWireup="true" CodeBehind="OrderBasket.aspx.cs" Inherits="IKSIR.ECommerce.UI.Pages.OrderBasket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="sepet_content_middle">
        <div class="sepet_content_header">
            <img src="../images/sepet_sepet.jpg" alt="" />
            <h3>
                Alışveriş Sepetiniz</h3>
            <h4>
                Sepetinizdeki ürünlerin yer aldığı sayfadır. Dilerseniz birden fazla ürünü aynı
                anda alabilirsiniz.
            </h4>
        </div>
        <table>
            <tr>
                <td class="table_header">
                    Ürün
                </td>
                <td class="table_header">
                    Adet
                </td>
                <td class="table_header">
                    Tutar
                </td>
                <td class="table_header">
                    Toplam
                </td>
                <td class="table_header">
                </td>
            </tr>
            <asp:Repeater runat="server" ID="rptBasketProducts" OnItemDataBound="rptBasketProducts_ItemDataBound"
                OnItemCommand="rptBasketProducts_ItemCommand">
                <ItemTemplate>
                    <tr>
                        <td class="table_first">
                            <asp:HiddenField runat="server" ID="hdnProductId" Value='<%# Eval("Product.Id")%>' />
                            <asp:Image runat="server" ID="imgProduct" ImageUrl='<%# Eval("Product.MainImage", "http://212.58.8.103/documents/Images/Small/small_{0:C}")%>' />
                            <h2>
                                <%# Eval("Product.ProductCategory.Title")%>
                                /
                                <%# Eval("Product.Title")%></h2>
                            <table>
                                <asp:Repeater runat="server" ID="rptProductProperties">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <%# Eval("Property.Title")%></strong>
                                            </td>
                                            <td>
                                                :
                                            </td>
                                            <td>
                                                <%# Eval("Value")%>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </td>
                        <td class="table_second">
                            <form action="">
                            <asp:TextBox runat="server" ID="txtItemCount" CssClass="table_second_text" Text='<%# Eval("Count")%>'></asp:TextBox><br />
                            <asp:ImageButton runat="server" ID="imgbtnRefreshItemCount" ImageUrl="../images/table_second_guncelle.png"
                                CommandName="Refresh" CommandArgument='<%# Eval("Product.Id")%>' />
                            </form>
                        </td>
                        <td class="table_third">
                            <p>
                                <%# Eval("ProductPrice.UnitPrice")%>
                                TL</p>
                        </td>
                        <td class="table_fourth">
                            <p>
                                <%# Eval("BasketItemPrice")%>
                                TL</p>
                        </td>
                        <td class="table_fifth">
                            <a href="#">
                                <asp:ImageButton runat="server" ID="imgbtnDeleteItem" ImageUrl="../images/table_fifth_one.jpg"
                                    CommandName="Delete" CommandArgument='<%# Eval("Product.Id")%>' />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <tr>
                <td colspan="5">
                    <asp:CheckBox runat="server" ID="cbxComfirmation" Text="" /><a href="#" id="anchorConfirmation">Genel
                        Kurallar ve Koşullar'ı okudum ve kabul ediyorum.</a>
                    <script type="text/javascript">
                        $("#anchorConfirmation").click(function () {
                            if ($(".divGeneralRules").is(':visible'))
                                $(".divGeneralRules").slideUp('slow');
                            else
                                $(".divGeneralRules").slideDown('slow');
                        });
                    </script>
                    <br />
                    <div class="divGeneralRules" style="display: none; width: 100%; background: #F3F6F7;
                        font: normal 12px tahoma; color: #3F5968; height: 150px; overflow: auto; border: 1px solid #666;
                        padding: 8px;">
                        <strong>Genel Kural ve Koşullar</strong>
                        <p>
                            <span style="color: Red;">Bu içerik geçici olarak konmuştur düzenlenecektir</span></p>
                        <p>
                            Bu siteye girmek ve kullanmak suretiyle aşağıda belirtilen kurallara ve koşullara
                            bağlı kalmayı kabul etmiş bulunuyorsunuz. ATLASJET ULUSLARARASI HAVACILIK A.Ş.(Bundan
                            böyle olarak anılacaktır) herhangi bir bildirim yapmaksızın veya sorumluluk kabul
                            etmeksizin kurallar ve koşulları değiştirme hakkını saklı tutmaktadır. Kayıt anında
                            size bildirilen bilet ücretinin tamamı(vergiler,harçlar ve hizmet bedeli dahil)
                            kredi kartınızdan tahsil edilecektir.</p>
                        <p>
                            Ödeme yaptıktan sonra seyahatiniz kesinleşmiş kabul edilecek olup daha sonra rezervasyon
                            kaydınızda ve uçak biletinizde yapacağınız iptal ve değişiklikler aşağıdaki kurallar
                            doğrultusunda işlem görecektir. Yapılan rezervasyon bir başkasına devredilemez,
                            isim değişikliği yapılamaz. Yolcu rezervasyon kaydındaki uçuşu gerçekleştirmediği
                            taktirde hizmet bedeli ve ücret iadesi yapılmaz. Sefer iptali ve gecikme halinde
                            bir başka havayolu ile devam uçuşu olan yolcuların sorumluluğu Atlasjet Havayollarına
                            ait değildir. Yolcular devam uçuşları için yeni bilet talebinde bulunamazlar.</p>
                    </div>
                </td>
            </tr>
        </table>
        <div class="sepet_content_footer">
            <div style="float: right!important; text-align: left;">
                <br />
                <strong>Sepet Toplamı:</strong>
                <br />
                <table>
                    <tr>
                        <td>
                            Toplam Ürün Tutarı
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <strong>
                                <asp:Label runat="server" ID="lblTotalPrice"></asp:Label>
                                TL</strong>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Toplam KDV
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <strong>
                                <asp:Label runat="server" ID="lblTotalTax"></asp:Label>
                                TL</strong>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Toplam Ödenecek Tutar
                        </td>
                        <td>
                            :
                        </td>
                        <td>
                            <strong>
                                <asp:Label runat="server" ID="lblBasketTotal"></asp:Label>
                                TL</strong>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="sepet_content_end">
            <a href="#">
                <img src="../images/sepet_end_iptal.jpg" alt="" /></a>
            <asp:ImageButton runat="server" ID="imgbtnContinue" ImageUrl="../images/sepet_end_devam.jpg"
                AlternateText="Devam Et" onclick="imgbtnContinue_Click" />
        </div>
    </div>
</asp:Content>
