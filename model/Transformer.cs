using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Xsl;

namespace model
{
    public class Transformer
    {
        string xslPath;

        public Transformer(string xslPath)
        {
            this.xslPath = xslPath;
        }

        public void SetStyle(string xslPath)
        {
            this.xslPath = xslPath;
        }

        public void Transform(string xmlPath, string resultPath)
        {
            XslCompiledTransform tr = new XslCompiledTransform();
            tr.Load(xslPath);
            tr.Transform(xmlPath, resultPath);
        }
    }
}
