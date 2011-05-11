<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" 
				xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
	
	<xsl:template match="/">

		<html>
			<head>
				<title>English to Russian Cards</title>
				<style type="text/css">
					body {font-family: Verdana; font-size: small; }
					h1{ font-size: large; }
					h2{ font-size: medium; }
					.s2{color: #999999;font-style: italic;}
				</style>
			</head>
			<body>	

			<h1>Cards</h1>
			<h2>English to Russian</h2>
			<table>
				<xsl:for-each select="ArrayOfCard/Card">
					<tr class="s1">
						<td><strong><xsl:value-of select="Eng"/></strong></td>
						<td><xsl:value-of select="Transcription"/></td>
						<td><xsl:value-of select="Rus"/></td>
					</tr>
					<tr class="s2">
						<td colspan="3">
								<xsl:value-of select="EngDesc"/> - <xsl:value-of select="RusDesc"/>
						</td>
					</tr>
				</xsl:for-each>	
			</table>
			</body>	
		</html>		
		
	</xsl:template>
	
    <xsl:output method="xml" indent="yes"/>
	
</xsl:stylesheet>
