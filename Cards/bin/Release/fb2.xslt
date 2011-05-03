<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
	
	<xsl:template match="/">
		<FictionBook xmlns:xlink="http://www.w3.org/1999/xlink" xmlns="http://www.gribuser.ru/xml/fictionbook/2.0">
			<description>
				<title-info>
					<genre></genre>
					<author>
						<first-name></first-name>
						<middle-name></middle-name>
						<last-name></last-name>
					</author>
					<book-title>English - Russian Cards</book-title>
					<annotation></annotation>
				</title-info>
			</description>
			<document-info>
				<program-used>Cards</program-used>
			</document-info>
			<body xmlns:fb="http://www.gribuser.ru/xml/fictionbook/2.0" xmlns:xlink="http://www.w3.org/1999/xlink"><section><title><p>English - Russian Cards</p></title></section>
			<section><title><p>English - Russian Cards</p></title>

			<xsl:for-each select="ArrayOfCard/Card">
			 <p><strong><xsl:value-of select="Eng"/></strong> <xsl:value-of select="Transcription"/> - <xsl:value-of select="Rus"/> </p>
			 <p><xsl:value-of select="EngDesc"/> <xsl:value-of select="RusDesc"/></p>
			 <p></p>
			</xsl:for-each>	
					
		</section>
		</body>
		</FictionBook>
	</xsl:template>
    <xsl:output method="xml" indent="yes"/>
</xsl:stylesheet>
