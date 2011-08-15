<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCProductDetailsCreditCardAdvantages.ascx.cs"
    Inherits="IKSIR.ECommerce.UI.UserControls.UCProductDetailsCreditCardAdvantages" %>
<table>
    <tr>
        <td>
            <strong>Kredi Kartı Avantajları</strong> <i>(Kart Avantajları)</i>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Repeater runat="server" ID="rptCreditCards" 
                onitemdatabound="rptCreditCards_ItemDataBound">
                <ItemTemplate>
                    <%# Eval("Name")%>
                    <asp:HiddenField runat="server" ID="hdnCardId" Value='<%# Eval("Id")%>' />
                    <asp:Repeater runat="server" ID="rptCreditCardAdvantages">
                        <ItemTemplate>
                            <%# Eval("Month")%>/<%# Eval("Rate")%>
                        </ItemTemplate>
                    </asp:Repeater>
                </ItemTemplate>
            </asp:Repeater>
        </td>
    </tr>
</table>
