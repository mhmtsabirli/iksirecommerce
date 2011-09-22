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
                        <a target="_blank" href='<%# String.Format("http://www.banyom.com.tr/management/ProductDocuments/Orginal/Others/{0}", Eval("FilePath"))%>'>
                            <%# Eval("Title")%>
                        </a>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </td>
    </tr>
</table>
