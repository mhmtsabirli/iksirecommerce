<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/UIMasterPage.Master"
    AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="IKSIR.ECommerce.UI.Pages.Default" %>

<%@ Register Src="../UserControls/UCShowCaseProducts.ascx" TagName="UCShowCaseProducts"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<%--<script language="javascript" type="text/javascript">
    debugger;
    document.getElementById("txtTest").value;
    alert($('#txtTest').val());
    $('#txtTest').focus(function () {
        alert('asdasd');
        //Check val for email
        if ($(this).val() == 'Arama') {
            $(this).val('');
        }
    }).blur(function () {   
        //check for empty input
        if ($(this).val() == '') {
            $(this).val('Arama');
        }
    });
    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UCShowCaseProducts ID="UCShowCaseProducts1" runat="server" />
    <div class="clear">
    </div>
</asp:Content>
