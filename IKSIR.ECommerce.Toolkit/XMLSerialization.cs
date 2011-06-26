using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace IKSIR.ECommerce.Toolkit
{
    public class XMLSerialization
    {
        public static object FromXml(string xml, Type p_Type)
        {
            object result = null;
            XmlSerializer serializer = new XmlSerializer(p_Type);
            MemoryStream ms = new MemoryStream();
            StreamWriter sw = new StreamWriter(ms, Encoding.UTF8);
            StreamReader sr = null;

            try
            {
                sw.Write(xml);
                sw.Flush();
                ms.Position = 0;
                sr = new StreamReader(ms, Encoding.UTF8);
                result = (object)serializer.Deserialize(sr);
            }
            finally
            {
                sw.Close();
                if (sr != null)
                { sr.Close(); }
                ms.Close();
            }

            return result;
        }
        public static string ToXml(object p_Object)
        {
            if (p_Object == null)
            {
                return string.Empty;
            }

            XmlSerializer serializer = new XmlSerializer(p_Object.GetType());
            MemoryStream ms = new MemoryStream();
            StreamWriter sw = new StreamWriter(ms, Encoding.UTF8);
            StreamReader sr = null;

            string result = "";

            try
            {
                serializer.Serialize(sw, p_Object);
                ms.Position = 0;
                sr = new StreamReader(ms, Encoding.UTF8);
                result = sr.ReadToEnd();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sw.Close();
                if (sr != null)
                { sr.Close(); }
                ms.Close();
            }

            return result;
        }
        public static string ToGenericXml(object p_Object)
        {
            if (p_Object == null)
            {
                return string.Empty;
            }

            //Create our own namespaces for the output
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();

            //Add an empty namespace and empty value
            ns.Add("", "");

            XmlSerializer serializer = new XmlSerializer(p_Object.GetType());
            MemoryStream ms = new MemoryStream();
            StreamReader sr = null;

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = true;
            XmlWriter sw = XmlWriter.Create(ms, settings);

            string result = "";

            try
            {
                serializer.Serialize(sw, p_Object, ns);
                ms.Position = 0;
                sr = new StreamReader(ms);
                result = sr.ReadToEnd();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sw.Close();
                if (sr != null)
                { sr.Close(); }
                ms.Close();
            }

            return result;
        }
    }
}
