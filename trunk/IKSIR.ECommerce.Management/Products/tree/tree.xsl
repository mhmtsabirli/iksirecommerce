<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:output method="xml" indent="no" encoding="UTF-8" omit-xml-declaration="yes"/>
 <xsl:template match="/SiteMap">



	<xsl:if test="0 &lt; count(Item)">

		<table cellpadding="0" cellspacing="0">

		<xsl:for-each select="Item">

			<tr>
				<xsl:attribute name="itemId">
					<xsl:value-of select="@Value" />
				</xsl:attribute>
					<xsl:attribute name="parentId">
											<xsl:value-of select="@Parent" />
										</xsl:attribute>
				<td valign="top" width="15"><img src="tree/ico_Plus.gif" style="margin-top:4px;cursor:hand;"/></td>
				<td><span class="TreeItem"><xsl:value-of select="@Text"/></span></td>
			</tr>

		</xsl:for-each>

		</table>

	</xsl:if>

</xsl:template>

</xsl:stylesheet>