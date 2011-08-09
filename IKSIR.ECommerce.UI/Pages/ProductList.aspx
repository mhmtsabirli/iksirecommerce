<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/UIMasterPage.Master"
    AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="IKSIR.ECommerce.UI.Pages.ProductList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DataList runat="server" ID="dlProductList" RepeatColumns="3" RepeatDirection="Horizontal">
        <ItemTemplate>
            <asp:HiddenField runat="server" ID="hdnProductId" Value='<%# Eval("Id")%>' />
            <div class="section">
                <h3>
                    <%# Eval("ProductCategory.Title")%>
                </h3>
                <div class="section_image">
                    <a href='<%# "../Pages/ProductDetails.aspx?pid="+ Eval("Id")%>'>
                        <asp:Image runat="server" ID="imgProduct" BorderWidth="0" />
                    </a>
                </div>
                <div class="section_info">
                    <div id="divcontainer">
                        <div id="divCode" style="padding-top: 3px;">
                            <span style="color: #848484;">
                                <%# Eval("ProductCode")%></span>
                        </div>
                        <div id="divTitle" style="padding-top: 3px;">
                            <span style="color: #848484;">
                                <%# Eval("Title")%></span>
                        </div>
                        <div id="divPrice" style="padding-top: 5px;">
                            <span style="color: #094073; font-weight: bold;">
                                <%# Eval("ProductPrice.UnitPrice")%>
                                TL + KDV</span>
                        </div>
                    </div>
                </div>
                <div class="section_links">
                    <a href='<%# "../Pages/ProductDetails.aspx?pid="+ Eval("Id")%>'>
                        <img src="../images/section_incele.jpg" alt="" /></a>
                    <asp:ImageButton runat="server" ID="imgbtnAddtoBasket" ImageUrl="../images/section_sepete_ekle.jpg"
                        AlternateText="Sepete Ekle" CommandArgument='<%# Eval("Id")%>' OnClick="imgbtnAddtoBasket_Click">
                    </asp:ImageButton>
                </div>
            </div>
        </ItemTemplate>
    </asp:DataList>
    <div class="page_array">
        <asp:DataList runat="server" ID="dlPaging" RepeatColumns="10" RepeatDirection="Horizontal"
            OnItemDataBound="dlPaging_ItemDataBound">
            <ItemTemplate>
                <asp:HyperLink runat="server" ID="hplPageNo" Text='<%# Eval("Key")%>' NavigateUrl='<%# Eval("Value")%>'></asp:HyperLink>
            </ItemTemplate>
        </asp:DataList>
        <div class="clear">
        </div>
    </div>
</asp:Content>
