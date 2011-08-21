<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCProductDetailDocuments.ascx.cs"
    Inherits="IKSIR.ECommerce.UI.UserControls.UCProductDetailDocuments" %>
<table>
    <tr>
        <td>
            <strong>Ürün Dökümanları</strong> <i>(Ürünle ilgili dökümanlar)</i>
        </td>
    </tr>
    <tr>
        <td>
            <table>
                <asp:Repeater runat="server" ID="rptDocuments">
                    <ItemTemplate>
                        <a href='<%# String.Format("http://banyom.com.tr/CardImages/{0}", Eval("Image"))%>'>
                            <%# Eval("BasketItemPrice")%>
                        </a>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </td>
    </tr>
</table>
