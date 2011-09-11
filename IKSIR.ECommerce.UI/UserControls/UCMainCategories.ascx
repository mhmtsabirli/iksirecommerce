<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCMainCategories.ascx.cs"
    Inherits="IKSIR.ECommerce.UI.UserControls.UCMainCategories" %>
<h3>
    Ürün Kategorileri
</h3>
<div runat="server" id="divMainCategories">
</div>
<script type="text/javascript">
    $(document).ready(function () {
        setTimeout(function () {
            // Slide
            $('#menu1 > li > a.expanded + ul').slideToggle('medium');
            $('#menu1 > li > a').click(function () {
                $(this).toggleClass('expanded').toggleClass('collapsed').parent().find('> ul').slideToggle('medium');
            });
            $('#example1 .expand_all').click(function () {
                $('#menu1 > li > a.collapsed').addClass('expanded').removeClass('collapsed').parent().find('> ul').slideDown('medium');
            });
            $('#example1 .collapse_all').click(function () {
                $('#menu1 > li > a.expanded').addClass('collapsed').removeClass('expanded').parent().find('> ul').slideUp('medium');
            });
            // Appear/Disappear
            $('#menu4 > li > a.expanded + ul').show();
            $('#menu4 > li > a').click(function () {
                $(this).toggleClass('expanded').toggleClass('collapsed').parent().find('> ul').toggle();
            });
            $('#example4 .expand_all').click(function () {
                $('#menu4 > li > a.collapsed').addClass('expanded').removeClass('collapsed').parent().find('> ul').show();
            });
            $('#example4 .collapse_all').click(function () {
                $('#menu4 > li > a.expanded').addClass('collapsed').removeClass('expanded').parent().find('> ul').hide();
            });
            // Accordion
            $('#menu5 > li > a.expanded + ul').slideToggle('medium');
            $('#menu5 > li > a').click(function () {
                $('#menu5 > li > a.expanded').not(this).toggleClass('expanded').toggleClass('collapsed').parent().find('> ul').slideToggle('medium');
                $(this).toggleClass('expanded').toggleClass('collapsed').parent().find('> ul').slideToggle('medium');
            });
        }, 250);
    });
</script>
