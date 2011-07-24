<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCShowCaseProducts.ascx.cs"
    Inherits="IKSIR.ECommerce.UI.UserControls.UCShowCaseProducts" %>
<asp:DataList runat="server" ID="dlShowCaseProducts" RepeatColumns="3" RepeatDirection="Horizontal">
    <ItemTemplate>
        <asp:HiddenField runat="server" ID="hdnProductId" Value='<%# Eval("Id")%>' />
        <div class="section">
            <h3>
                <%# Eval("ProductCategory.Title")%>
            </h3>
            <div class="section_image">
                <asp:Image runat="server" ID="imgProduct" /></div>
            <div class="section_info">
                <table>
                    <tr>
                        <td>
                            Ürün Kodu
                        </td>
                        <td>
                            :
                        </td>
                        <td style="color: #848484;">
                            <%# Eval("ProductCode")%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Ürün Adı
                        </td>
                        <td>
                            :
                        </td>
                        <td style="color: #848484;">
                            <%# Eval("Title")%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Fiyatı
                        </td>
                        <td>
                            :
                        </td>
                        <td style="color: #094073;">
                            <%# Eval("ProductPrice.UnitPrice")%>
                            TL + KDV
                        </td>
                    </tr>
                </table>
            </div>
            <div class="section_links">
                <a href='<%# "../Pages/ProductDetails.aspx?pid="+ Eval("Id")%>'>
                    <img src="../images/section_incele.jpg" alt="" /></a> <a href="#">
                        <img src="../images/section_sepete_ekle.jpg" alt="" /></a>
            </div>
        </div>
    </ItemTemplate>
</asp:DataList>
<div style="float: right">
    <a runat="server" id="anchorContinue">Devamı</a>&nbsp;&nbsp;
</div>
