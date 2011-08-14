<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCProductDetailsComments.ascx.cs"
    Inherits="IKSIR.ECommerce.UI.UserControls.UCProductDetailsComments" %>
<table>
    <tr>
        <td colspan="4">
            <strong>Ürün Yorumları</strong> <i>(Ürünle ilgili yorumlar)</i>
        </td>
    </tr>
    <tr>
        <td colspan="4">
            <asp:GridView runat="server" ID="gvProductComments" AutoGenerateColumns="False" Width="100%"
                ShowHeader="False" CellPadding="4" EnableModelValidation="True" ForeColor="#333333"
                GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <table width="100%">
                                <tr>
                                    <td align="left">
                                        <asp:Label runat="server" ID="lblTitle" Text='<%# Eval("Title")%>' Font-Bold="true"></asp:Label>
                                    </td>
                                    <td align="right">
                                        <asp:Label runat="server" ID="lblCreateDate" Text='<%# Eval("CreateDate")%>'></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" valign="top" align="left">
                                        <asp:Label runat="server" ID="lblContent" Text='<%# Eval("Content")%>'></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="right">
                                        <span style="font-style: italic">
                                            <%# Eval("User.FirstName")%>&nbsp;<%# Eval("User.LastName")%>
                                        </span>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td valign="top">
            Adınız
        </td>
        <td valign="top">
            :
        </td>
        <td valign="top">
            <asp:TextBox runat="server" ID="txtUserName"></asp:TextBox>
        </td>
        <td valign="top">
            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ValidationGroup="vgCommentForm"
                ControlToValidate="txtUserName" SetFocusOnError="true" ErrorMessage="Adınızı giriniz">*</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td valign="top">
            Başlık
        </td>
        <td valign="top">
            :
        </td>
        <td valign="top">
            <asp:TextBox runat="server" ID="txtTitle" Width="250px"></asp:TextBox>
        </td>
        <td valign="top">
            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ValidationGroup="vgCommentForm"
                ControlToValidate="txtTitle" SetFocusOnError="true" ErrorMessage="Yorumunuza başlık giriniz">*</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td valign="top">
            Yorumunuz
        </td>
        <td valign="top">
            :
        </td>
        <td valign="top">
            <asp:TextBox runat="server" ID="txtContent" TextMode="MultiLine" Width="250px" Height="60px"></asp:TextBox>
        </td>
        <td valign="top">
            <asp:RequiredFieldValidator runat="server" ID="rfv1" ValidationGroup="vgCommentForm"
                ControlToValidate="txtContent" SetFocusOnError="true" ErrorMessage="Yorumunuzu giriniz">*</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td colspan="4">
            <asp:Label runat="server" ID="lblAlert"></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="4">
            <asp:ValidationSummary runat="server" ID="vsProductComment" ValidationGroup="vgCommentForm" />
        </td>
    </tr>
    <tr>
        <td colspan="4">
            <asp:HyperLink runat="server" ID="hplLogin" Text="Yorum eklemek için üye girişi yapmalısınız"></asp:HyperLink>
            <asp:Button runat="server" ID="btnAddComment" Text="Yorum Ekle" ValidationGroup="vgCommentForm"
                OnClick="btnAddComment_Click" />
        </td>
    </tr>
</table>
