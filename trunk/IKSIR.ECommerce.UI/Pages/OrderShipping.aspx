<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/UIDetailMasterPage.Master"
    AutoEventWireup="true" CodeBehind="OrderShipping.aspx.cs" Inherits="IKSIR.ECommerce.UI.Pages.OrderShipping" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="sepet_content_middle">
        <div class="sepet_content_header">
            <img src="../images/sepet_sepet.jpg" alt="" />
            <h3>
                Kargo Firmaları</h3>
            <h4>
                Kargo firmalarından birini seçiniz
            </h4>
        </div>
        <table>
            <tr>
                <td>
                    <asp:RadioButtonList runat="server" ID="rblShippingCompanies">
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <a href="#">
                        <img src="../images/sepet_end_iptal.jpg" alt="" /></a> 
                        <asp:ImageButton runat="server" ID="imgbtnContinue" ImageUrl="../images/sepet_end_devam.jpg"
                        AlternateText="Devam Et" OnClick="imgbtnContinue_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
