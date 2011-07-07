<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterManagement.Master"
    AutoEventWireup="true" CodeBehind="ContactForm.aspx.cs" Inherits="IKSIR.ECommerce.Management.Common.ContactForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <h2>
        Yönetici Düzenleme</h2>
    <p>
        Sisteme yönetici tanımlama mevcut yöneticileri düzenleme ekranları.
    </p>
    <table id="tblMngForm">
        <tr>
            <td align="left">
                <asp:Label runat="server" ID="lblError" Visible="false"></asp:Label>
            </td>
            <td style="text-align: right">
             
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Panel runat="server" ID="pnlForm" Visible="false" CssClass="pnlForm">
                    <table>
                        <tr>
                            <td colspan="4">
                                <strong>Form</strong>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Id
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblId"></asp:Label>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Adı Soyadı
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtName"></asp:TextBox>
                            </td>
                            <td>
                              
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Başlık
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtTitle"></asp:TextBox>
                            </td>
                            <td>
                               
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Email
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtEmail"></asp:TextBox>
                            </td>
                            <td>
                              
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Ip
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtIp" ></asp:TextBox>
                            </td>
                            <td>
                               
                            </td>
                        </tr>
                        <tr>
                            <td>
                               Mesaj
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtMessage" TextMode="MultiLine"></asp:TextBox>
                            </td>
                            <td>
                               
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" style="text-align:center">
                                <asp:ValidationSummary runat="server" ID="vsForm" ValidationGroup="VGForm" ForeColor="Red" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" style="text-align:center">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" style="text-align:center">
                                <asp:Button runat="server" ID="btnSave" Text="Kaydet" ValidationGroup="VGForm" OnClick="btnSave_Click" />
                                &nbsp;<asp:Button runat="server" ID="btnCancel" Text="Vazgeç" OnClick="btnCancel_Click" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel runat="server" ID="pnlFilter" Visible="true">
                    <table>
                        <tr>
                            <td colspan="4">
                                <strong>Filtre</strong>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Site
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:DropDownList runat="server" ID="ddlFilterSite">
                                </asp:DropDownList>
                            </td>
                            <td rowspan="2">
                                <asp:Button runat="server" ID="btnFilter" Text="Filtrele" OnClick="btnFilter_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Kullanıcı Adı
                            </td>
                            <td>
                                :
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtFilterUserName"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <br />
                <asp:Panel runat="server" ID="pnlList" Visible="true">
                    <table>
                        <tr>
                            <td colspan="4">
                                <strong>Liste</strong>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:GridView runat="server" ID="gvList" AutoGenerateColumns="False" CellPadding="4"
                                    GridLines="None" PageSize="15" EnableModelValidation="True" Width="100%" EmptyDataText="Listede gösterilecek kayıt bulunamadı">
                                    <EmptyDataTemplate>
                                        Kayıt Bulunamadı
                                    </EmptyDataTemplate>
                                    <Columns>
                                        <asp:TemplateField ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbtnEdit" runat="server" OnClick="lbtnEdit_Click" CommandArgument='<%# Eval("Id")%>'>[Düzenle]</asp:LinkButton>
                                                <asp:LinkButton ID="lbtnDelete" runat="server" OnClick="lbtnDelete_Click" CommandArgument='<%# Eval("Id")%>'
                                                    OnClientClick="javascript:return confirm('Are you sure you want to delete this row?');"
                                                    CausesValidation="false" ForeColor="Red">[Sil]</asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Id" HeaderText="Id" ApplyFormatInEditMode="false" ReadOnly="true"
                                            SortExpression="Id" />
                                        <asp:BoundField DataField="Title" HeaderText="Başlık" ApplyFormatInEditMode="false"
                                            ReadOnly="true" SortExpression="Title" />
                                        <asp:BoundField DataField="Ip" HeaderText="Ip" ApplyFormatInEditMode="false"
                                            ReadOnly="true" SortExpression="Ip" />
                                        <asp:TemplateField HeaderText="Id" Visible="false">
                                            <ItemTemplate>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
        </tr>
    </table>
</asp:Content>
