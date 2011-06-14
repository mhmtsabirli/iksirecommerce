<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterManagement.Master"
    AutoEventWireup="true" CodeBehind="ProductCategories.aspx.cs" Inherits="IKSIR.ECommerce.Management.Products.ProductCategories" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>
                <iframe title="myTree" id="myTree" style="width: 300px; height: 300px" src="Categories.aspx"
                    frameborder="0" scrolling="no" height="40%" selectedid="0" selectedname=""></iframe>
            </td>
            <td>
            </td>
        </tr>
    </table>
</asp:Content>
