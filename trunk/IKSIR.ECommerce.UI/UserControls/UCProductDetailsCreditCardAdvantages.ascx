<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCProductDetailsCreditCardAdvantages.ascx.cs"
    Inherits="IKSIR.ECommerce.UI.UserControls.UCProductDetailsCreditCardAdvantages" %>
<table>
    <tr>
        <td>
            <strong>Kredi Kartı Avantajları</strong> <i>(Kart Avantajları)</i>
        </td>
    </tr>
    <tr>
        <td valign="top">
            <asp:DataList runat="server" ID="dlCreditCards" OnItemDataBound="dlCreditCards_ItemDataBound"
                RepeatColumns="4" RepeatDirection="Horizontal">
                <ItemTemplate>
                    <table>
                        <tr>
                            <td valign="top">
                                <asp:HiddenField runat="server" ID="hdnCardId" Value='<%# Eval("Id")%>' />
                                <asp:Image runat="server" ID="imgCard" ImageUrl='<%# String.Format("http://212.58.8.103/CardImages/{0}", Eval("Image"))%>' />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%# Eval("Bank.Name")%>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%# Eval("Name")%>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <table>
                                    <tr>
                                        <td>
                                            Ay
                                        </td>
                                        <td>
                                            Vade
                                        </td>
                                    </tr>
                                    <asp:Repeater runat="server" ID="rptCreditCardAdvantages">
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <%# Eval("Month")%>
                                                </td>
                                                <td>
                                                    <%# Eval("Rate")%>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </table>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
            <asp:Repeater runat="server" ID="rptCreditCards" OnItemDataBound="rptCreditCards_ItemDataBound">
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
