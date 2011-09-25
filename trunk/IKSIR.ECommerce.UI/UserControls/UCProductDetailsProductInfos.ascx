<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCProductDetailsProductInfos.ascx.cs"
    Inherits="IKSIR.ECommerce.UI.UserControls.UCProductDetailsProductInfos" %>
<table>
    <tr>
        <td>
            <strong>Ürün Bilgisi</strong> <i>(Ürünle ilgili detaylı bilgi)</i>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label runat="server" ID="lblProductDetail" Font-Size="14px"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <asp:GridView runat="server" ID="gvProductProperties" AutoGenerateColumns="False"
                Width="100%" ShowHeader="False" CellPadding="0" CellSpacing="0" EnableModelValidation="True"
                ForeColor="#333333" GridLines="None" Font-Size="14px">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <table width="100%">
                                <tr>
                                    <td align="left">
                                        <asp:Label runat="server" ID="lblTitle" Text='<%# Eval("Property.Title")%>' Font-Bold="true"></asp:Label>
                                    </td>
                                    <td align="right">
                                        <p>
                                            <asp:Label runat="server" ID="lblCreateDate" Text='<%# DataBinder.Eval(Container.DataItem, "Value", "{0:c}") %>'></asp:Label>
                                        </p>
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
</table>
