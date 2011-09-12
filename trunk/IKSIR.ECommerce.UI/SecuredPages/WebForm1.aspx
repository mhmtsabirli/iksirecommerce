<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="IKSIR.ECommerce.UI.SecuredPages.WebForm1" %>

<%@ Register src="UserControls/UCFooter.ascx" tagname="UCFooter" tagprefix="uc1" %>
<%@ Register src="UserControls/UCHeader.ascx" tagname="UCHeader" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    
    <uc2:UCHeader ID="UCHeader1" runat="server" />
    <uc1:UCFooter ID="UCFooter1" runat="server" />
    
    </form>
</body>
</html>
