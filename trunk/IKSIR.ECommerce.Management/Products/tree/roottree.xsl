<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

 <xsl:template match="/SiteMap">
 <html>
 <head>
		<LINK href="tree/tree.css" type="text/css" rel="stylesheet"></LINK>
		
 </head>
 </html>
	<xsl:if test="0 &lt; count(Item)">
		<TABLE class="Tree" id="Tree" cellSpacing="0"  cellPadding="0">
               <TBODY>
                   <TR>
                      <TD class="Tree"  item="">
                         <DIV class="TreeContainer">
							<table cellpadding="0" cellspacing="0">
								<xsl:for-each select="Item">
									<tr parentId="0">
										<xsl:attribute name="itemId">
											<xsl:value-of select="@Value" />
										</xsl:attribute>
										<td valign="top" width="15"><img src="tree/ico_Plus.gif" style="margin-top:4px;cursor:hand;"/></td>
										<td><span class="TreeItem"><xsl:value-of select="@Text"/></span></td>
									</tr>
								</xsl:for-each>
							</table>
						</DIV>
					</TD>
				</TR>
			</TBODY>
		</TABLE>
	</xsl:if>
</xsl:template>
</xsl:stylesheet>
