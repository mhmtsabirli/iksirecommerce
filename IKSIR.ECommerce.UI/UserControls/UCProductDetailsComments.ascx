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
        <td>
            Yorumunuz
        </td>
        <td>
            :
        </td>
        <td>
            <asp:TextBox runat="server" ID="txtComment" TextMode="MultiLine" Width="250px" Height="30px"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator runat="server" ID="rfv1" ValidationGroup="vgCommentForm"
                ControlToValidate="txtComment" SetFocusOnError="true">*</asp:RequiredFieldValidator>
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
