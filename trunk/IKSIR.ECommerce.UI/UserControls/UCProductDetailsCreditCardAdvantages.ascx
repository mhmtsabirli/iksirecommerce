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
                RepeatColumns="4" RepeatDirection="Horizontal" ItemStyle-VerticalAlign="Top">
                <ItemTemplate>
                    <table>
                        <tr>
                            <td valign="top">
                                <asp:HiddenField runat="server" ID="hdnCardId" Value='<%# Eval("Id")%>' />
                                <asp:Image runat="server" ID="imgCard" ImageUrl='<%# String.Format("http://banyom.com.tr/Management/CreditCardImages/{0}", Eval("Image"))%>' />
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
                                            Ay&nbsp;&nbsp;
                                        </td>
                                        <td>
                                            Vade
                                        </td>
                                    </tr>
                                    <asp:Repeater runat="server" ID="rptCreditCardAdvantages">
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <%# Eval("Month")%>&nbsp;&nbsp;
                                                </td>
                                                <td style="padding-top: 3px">
                                                    <%# Eval("Price")%>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <AlternatingItemTemplate>
                                            <tr style="background-color: #F7F6F3">
                                                <td>
                                                    <%# Eval("Month")%>&nbsp;&nbsp;
                                                </td>
                                                <td style="padding-top: 3px">
                                                    <%# Eval("Price")%>
                                                </td>
                                            </tr>
                                        </AlternatingItemTemplate>
                                    </asp:Repeater>
                                </table>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
        </td>
    </tr>
</table>
