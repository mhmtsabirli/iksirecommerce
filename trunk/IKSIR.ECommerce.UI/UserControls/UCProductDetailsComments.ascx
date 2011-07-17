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
            <asp:GridView runat="server" ID="gvProductComments">
                <Columns>
                    <asp:TemplateField HeaderText="Ekleyen">
                        <AlternatingItemTemplate>
                            <asp:Label runat="server" ID="lblCommandator"></asp:Label>
                        </AlternatingItemTemplate>
                    </asp:TemplateField>
                </Columns>
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
            Yorumunuz
        </td>
        <td valign="top">
            :
        </td>
        <td valign="top">
            <asp:TextBox runat="server" ID="txtComment" TextMode="MultiLine" Width="250px" Height="60px"></asp:TextBox>
        </td>
        <td valign="top">
            <asp:RequiredFieldValidator runat="server" ID="rfv1" ValidationGroup="vgCommentForm"
                ControlToValidate="txtComment" SetFocusOnError="true" ErrorMessage="Yorumunuzu giriniz">*</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td colspan="4">
            <asp:ValidationSummary runat="server" ID="vsProductComment" ValidationGroup="vgCommentForm" />
        </td>
    </tr>
    <tr>
        <td colspan="4">
            <asp:Button runat="server" ID="btnAddComment" Text="Yroum Ekle" ValidationGroup="vgCommentForm" />
        </td>
    </tr>
</table>
