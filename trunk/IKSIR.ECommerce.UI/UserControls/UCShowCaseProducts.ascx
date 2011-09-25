<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCShowCaseProducts.ascx.cs"
    Inherits="IKSIR.ECommerce.UI.UserControls.UCShowCaseProducts" %>
<asp:DataList runat="server" ID="dlShowCaseProducts" RepeatColumns="3" RepeatDirection="Horizontal">
    <ItemTemplate>
        <asp:HiddenField runat="server" ID="hdnProductId" Value='<%# Eval("Id")%>' />
        <asp:Panel runat="server" ID="pnlShowCaseProducts" DefaultButton="lbtnAddToBasket">
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
                        <img src="../images/section_incele.jpg" alt="" style="border: none;" /></a>
                    <asp:LinkButton runat="server" ID="lbtnAddToBasket" CommandArgument='<%# Eval("Id")%>'
                        OnClick="lbtnAddToBasket_Click">
                <img src="../images/section_sepete_ekle.jpg" style="border:none" alt="Sepete Ekle" />
                    </asp:LinkButton>
                </div>
            </div>
        </asp:Panel>
    </ItemTemplate>
</asp:DataList>
<div style="float: right">
    <a runat="server" id="anchorContinue" visible="false">Devamı</a>&nbsp;&nbsp;
</div>
